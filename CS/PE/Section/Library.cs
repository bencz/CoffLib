using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.PE
{
    public class Library
    {
        private string name;
        public string Name { get { return name; } }

        private ImportTable table = new ImportTable();
        private Dictionary<string, Symbol> symbols = new Dictionary<string, Symbol>();

        public Library(string name)
        {
            this.name = name;
        }

        public void Add(Symbol sym)
        {
            symbols.Add(sym.Name, sym);
        }

        public Symbol Add(string name)
        {
            Symbol sym;
            if (symbols.ContainsKey(name))
            {
                sym = symbols[name];
            }
            else
            {
                sym = new Symbol(0, name);
                symbols.Add(name, sym);
            }
            return sym;
        }

        public int NameSize
        {
            get
            {
                return HeaderBase.GetPaddedSize(4, name);
            }
        }

        public void WriteImportTable(Block block)
        {
            table.Write(block);
        }

        public void WriteImportLookupTable(Block block)
        {
            table.ImportLookupTable = block.Current;
            foreach (Symbol sym in symbols.Values) sym.Write(block, true);
            block.Add(0);
        }

        public void WriteImportAddressTable(Block block)
        {
            table.ImportAddressTable = block.Current;
            foreach (Symbol sym in symbols.Values) sym.Write(block, false);
            block.Add(0);
        }

        public void WriteSymbols(Block block)
        {
            foreach (Symbol sym in symbols.Values) sym.Write(block);
        }

        public void WriteName(Block block)
        {
            table.Name = block.Current;
            block.Add(HeaderBase.Pad(NameSize, name));
        }
    }
}
