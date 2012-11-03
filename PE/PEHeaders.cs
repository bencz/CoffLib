using System;
using CoffLib.Binary;

namespace CoffLib.PE
{
    public class IMAGE_SUBSYSTEM
    {
        public const ushort WINDOWS_GUI = 2;
        public const ushort WINDOWS_CUI = 3;
    }

    public class IMAGE_SCN
    {
        public const uint CNT_CODE = 0x00000020;
        public const uint CNT_INITIALIZED_DATA = 0x00000040;
        public const uint CNT_UNINITIALIZED_DATA = 0x00000080;
        public const uint MEM_EXECUTE = 0x20000000;
        public const uint MEM_READ = 0x40000000;
        public const uint MEM_WRITE = 0x80000000;
    }

    public class PEFileHeader : HeaderBase
    {
        public ushort Machine = 0x14c;
        public ushort NumberOfSections;
        public uint TimeDateStamp = 0;
        public uint PointerToSymbolTable = 0;
        public uint NumberOfSymbols = 0;
        public ushort OptionalHeaderSize = 0xe0;
        public ushort Characteristics = 0x10e;
    }

    public class PEHeaderStandardFields : HeaderBase
    {
        public ushort Magic = 0x10b;
        public byte LMajor = 6;
        public byte LMinor = 0;
        public uint CodeSize;
        public uint InitializedDataSize;
        public uint UninitializedDataSize;
        public uint EntryPoint;
        public uint BaseOfCode;
        public uint BaseOfData;
    }

    public class PEHeaderWindowsNTSpecificFields : HeaderBase
    {
        public uint ImageBase = 0x400000;
        public uint SectionAlignment = 0x2000;
        public uint FileAlignment = 0x200;
        public ushort OSMajor = 4;
        public ushort OSMinor = 0;
        public ushort UserMajor = 0;
        public ushort UserMinor = 0;
        public ushort SubSysMajor = 4;
        public ushort SubSysMinor = 0;
        public uint Reserved = 0;
        public uint ImageSize;
        public uint HeaderSize = 0x400;
        public uint FileChecksum = 0;
        public ushort SubSystem = 3;
        public ushort DLLFlags = 0;
        public uint StackReserveSize = 0x100000;
        public uint StackCommitSize = 0x1000;
        public uint HeapReserveSize = 0x100000;
        public uint HeapCommitSize = 0x1000;
        public uint LoaderFlags = 0;
        public uint NumberOfDataDirectories = 0x10;
    }

    public class PEHeaderDataDirectories : HeaderBase
    {
        public Table ExportTable;
        public Table ImportTable;
        public Table ResourceTable;
        public Table ExceptionTable;
        public Table CertificateTable;
        public Table BaseRelocationTable;
        public Table Debug;
        public Table Copyright;
        public Table GlobalPtr;
        public Table TLSTable;
        public Table LoadConfigTable;
        public Table BoundImport;
        public Table IAT;
        public Table DelayImportDescriptor;
        public Table CLIHeader;
        public Table Reserved;
    }

    public class SectionHeader : HeaderBase
    {
        private string name = "";
        public string Name
        {
            get { return Trim(name); }
            set { name = Pad(8, value); }
        }

        public uint VirtualSize;
        public uint VirtualAddress;
        public uint SizeOfRawData = 0;
        public uint PointerToRawData = 0;
        public uint PointerToRelocations = 0;
        public uint PointerToLinenumbers = 0;
        public ushort NumberOfRelocations = 0;
        public ushort NumberOfLinenumbers = 0;
        public uint Characteristics;
    }

    public class ImportTable : HeaderBase
    {
        public uint ImportLookupTable = 0;
        public uint DateTimeStamp = 0;
        public uint ForwarderChain = 0;
        public uint Name = 0;
        public uint ImportAddressTable = 0;
    }
}
