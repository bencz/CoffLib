using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.PE
{
    public class ImportSection : SectionBase
    {
        public override string Name { get { return ".idata"; } }

        private Dictionary<string, Library> libraries = new Dictionary<string, Library>();

        public void Add(Library lib)
        {
            libraries.Add(lib.Name, lib);
        }

        public Symbol Add(string libname, string sym)
        {
            Library lib;
            if (libraries.ContainsKey(libname))
            {
                lib = libraries[libname];
            }
            else
            {
                lib = new Library(libname);
                libraries.Add(libname, lib);
            }
            return lib.Add(sym);
        }

        public override void Write(Block block)
        {
            foreach (Library lib in libraries.Values) lib.WriteImportTable(block);
            new ImportTable().Write(block);

            foreach (Library lib in libraries.Values) lib.WriteImportLookupTable(block);
            foreach (Library lib in libraries.Values) lib.WriteImportAddressTable(block);
            foreach (Library lib in libraries.Values) lib.WriteSymbols(block);
            foreach (Library lib in libraries.Values) lib.WriteName(block);
        }
    }
}
