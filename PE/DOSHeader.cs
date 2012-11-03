using System;

namespace CoffLib.PE
{
    public class DOSHeader : HeaderBase
    {
        public string signature = "MZ";
        public ushort bytes_in_last_block = 0x90;
        public ushort blocks_in_file = 3;
        public ushort num_relocs = 0;
        public ushort header_paragraphs = 4;
        public ushort min_extra_paragraphs = 0;
        public ushort max_extra_paragraphs = 0xffff;
        public ushort ss = 0;
        public ushort sp = 0xb8;
        public ushort checksum = 0;
        public ushort ip = 0;
        public ushort cs = 0;
        public ushort reloc_table_offset = 0x40;
        public ushort overlay_number = 0;
    }
}
