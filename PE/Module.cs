using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CoffLib.Binary;
using CoffLib.X86;

namespace CoffLib.PE
{
    public class Module
    {
        public DOSHeader DOSHeader = new DOSHeader();
        public OpCode[] DOSStub = new[]
            {
                I8086.Push(SegReg.CS),
                I8086.Pop(SegReg.DS),
                I8086.Mov(Reg16.DX, 0x000e),
                I8086.Mov(Reg8.AH, 0x09),
                I8086.Int(0x21),
                I8086.Mov(Reg16.AX, 0x4c01),
                I8086.Int(0x21),
                new OpCode("This program cannot be run in DOS mode.\r\n$")
            };

        public PEFileHeader PEHeader = new PEFileHeader();
        public PEHeaderStandardFields Standard = new PEHeaderStandardFields();
        public PEHeaderWindowsNTSpecificFields Specific = new PEHeaderWindowsNTSpecificFields();
        public PEHeaderDataDirectories DataDirs = new PEHeaderDataDirectories();

        private List<SectionBase> Sections = new List<SectionBase>();
        public TextSection Text = new TextSection();
        public DataSection Data = new DataSection(".data");
        public DataSection RData = new DataSection(".rdata");
        public DataSection BSS = new DataSection(".bss");
        public ImportSection Import = new ImportSection();

        public static Encoding DefaultEncoding = Encoding.Unicode;

        public Module() { }
        public Module(ushort subsys) { Specific.SubSystem = subsys; }

        public Function GetFunction(CallType call, string lib, string sym)
        {
            Addr32 ad = new Addr32(Import.Add(lib, sym).ImportRef);
            return new Function(this, ad, call);
        }

        public Val32 GetString(string s)
        {
            return RData.AddString(s).Address;
        }

        public Val32 GetBuffer(string name, int size)
        {
            return BSS.AddBuffer(name, size).Address;
        }

        public Val32 GetInt32(string name)
        {
            return Data.AddBuffer(name, sizeof(int)).Address;
        }

        public SectionHeader GetSection(string name)
        {
            foreach (SectionBase sb in Sections)
                if (sb.Name == name) return sb.Header;
            return null;
        }

        public Block CreateBlock(SectionBase sb)
        {
            uint vaddr = sb.Header != null ? sb.Header.VirtualAddress : GetNextVirtualAddress();
            return sb.ToBlock(vaddr);
        }

        public SectionHeader AddSection(SectionBase sb)
        {
            if (Sections.Count == 16)
            {
                throw new Exception("Maximum sections.");
            }

            SectionHeader ret = new SectionHeader();
            ret.Name = sb.Name;
            ret.VirtualSize = CreateBlock(sb).Length;
            ret.VirtualAddress = GetNextVirtualAddress();
            ret.SizeOfRawData = Align(ret.VirtualSize, Specific.FileAlignment);
            ret.PointerToRawData = GetNextPointerToRawData();
            switch (ret.Name)
            {
                case ".text":
                    ret.Characteristics =
                        IMAGE_SCN.CNT_CODE | IMAGE_SCN.CNT_INITIALIZED_DATA |
                        IMAGE_SCN.MEM_EXECUTE | IMAGE_SCN.MEM_READ;
                    break;
                case ".rdata":
                    ret.Characteristics =
                        IMAGE_SCN.CNT_INITIALIZED_DATA |
                        IMAGE_SCN.MEM_READ;
                    break;
                case ".bss":
                    ret.Characteristics =
                        IMAGE_SCN.CNT_UNINITIALIZED_DATA |
                        IMAGE_SCN.MEM_READ | IMAGE_SCN.MEM_WRITE;
                    break;
                default:
                    ret.Characteristics =
                        IMAGE_SCN.CNT_INITIALIZED_DATA |
                        IMAGE_SCN.MEM_READ | IMAGE_SCN.MEM_WRITE;
                    break;
            }
            sb.Header = ret;
            Sections.Add(sb);
            return ret;
        }

        public uint GetNextVirtualAddress()
        {
            if (Sections.Count == 0) return Specific.SectionAlignment;
            SectionHeader last = Sections[Sections.Count - 1].Header;
            return last.VirtualAddress + Align(last.VirtualSize, Specific.SectionAlignment);
        }

        public uint GetNextPointerToRawData()
        {
            if (Sections.Count == 0) return Specific.HeaderSize;
            SectionHeader last = Sections[Sections.Count - 1].Header;
            return last.PointerToRawData + last.SizeOfRawData;
        }

        public void Link(string output)
        {
            SectionHeader text = AddSection(Text);
            AddSection(Data);
            if (!RData.IsEmtpy) AddSection(RData);
            if (!BSS.IsEmtpy) AddSection(BSS);
            AddSection(Import);
            PEHeader.TimeDateStamp = (uint)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds;
            Standard.EntryPoint = text.VirtualAddress;

            FileStream fs = new FileStream(output, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.ASCII);
            Write(bw);
            bw.Close();
            fs.Close();
        }

        public void Write(BinaryWriter bw)
        {
            PEHeader.NumberOfSections = (ushort)Sections.Count;
            Standard.InitializedDataSize = 0;
            Standard.UninitializedDataSize = 0;
            foreach (SectionBase sb in Sections)
            {
                SectionHeader sh = sb.Header;
                if ((sh.Characteristics & IMAGE_SCN.CNT_INITIALIZED_DATA) != 0)
                    Standard.InitializedDataSize += sh.VirtualSize;
                else if ((sh.Characteristics & IMAGE_SCN.CNT_UNINITIALIZED_DATA) != 0)
                    Standard.UninitializedDataSize += sh.VirtualSize;
            }
            Specific.ImageSize = GetNextVirtualAddress();
            Standard.CodeSize = Text.Header.VirtualSize;
            Standard.BaseOfCode = Text.Header.VirtualAddress;
            Standard.BaseOfData = Data.Header.VirtualAddress;
            DataDirs.ImportTable.Address = Import.Header.VirtualAddress;
            DataDirs.ImportTable.Size = Import.Header.VirtualSize;

            // write headers
            DOSHeader.Write(bw);
            SetPosition(bw, 0x3c);
            const int peSignPos = 0x80;
            bw.Write(peSignPos);
            Write(bw, DOSStub);
            SetPosition(bw, peSignPos);
            Write(bw, "PE\0\0");
            PEHeader.Write(bw);
            Standard.Write(bw);
            Specific.Write(bw);
            DataDirs.Write(bw);
            foreach (SectionBase sb in Sections)
            {
                sb.Header.Write(bw);
            }

            // write sections
            foreach (SectionBase sb in Sections)
            {
                SetPosition(bw, sb.Header.PointerToRawData);
                Block block = CreateBlock(sb);
                byte[] bytes = block.ToByteArray();
                foreach (uint reloc in block.Relocations)
                {
                    uint v = BitConverter.ToUInt32(bytes, (int)reloc);
                    Util.SetBytes(bytes, (int)reloc, v + Specific.ImageBase);
                    //Console.WriteLine("reloc[{0:X16}]{1:X16}", reloc, v);
                }
                bw.Write(bytes);
            }
            SetPosition(bw, GetNextPointerToRawData());
        }

        public static void SetPosition(BinaryWriter bw, uint offset)
        {
            uint len = offset - (uint)bw.BaseStream.Position;
            if (len > 0) bw.Write(new byte[len]);
        }

        public static void Write(BinaryWriter bw, OpCode[] ops)
        {
            foreach (OpCode op in ops)
            {
                bw.Write(op.GetCodes());
            }
        }

        public static void Write(BinaryWriter bw, string s)
        {
            bw.Write(s.ToCharArray());
        }

        public static void Write(BinaryWriter bw, int pad, string s)
        {
            Write(bw, s);
            int len = pad - s.Length;
            if (len > 0) bw.Write(new byte[len]);
        }

        public static uint Align(uint size, uint align)
        {
            return (size + align - 1) / align * align;
        }
    }
}
