using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

using CoffLib.X86;
using CoffLib.PE;
using CoffLib.Binary;

namespace test
{
    class MainClass
    {
        private static string GetOutput(string exe)
        {
            var path = Path.GetDirectoryName(Environment.CurrentDirectory);
            return Path.Combine(path, exe);
        }

        private static void exe1()
        {
            var exe = GetOutput("01.exe");
            var module = new Module(IMAGE_SUBSYSTEM.WINDOWS_GUI);
            var c = new List<OpCode>();

            var MessageBox = module.GetFunction(CallType.Std, "user32.dll", "MessageBoxW");
            var ExitProcess = module.GetFunction(CallType.Std, "kernel32.dll", "ExitProcess");

            c.AddRange(MessageBox.Invoke(0, "Hello", "Hi", 0));
            c.AddRange(ExitProcess.Invoke(0));

            module.Text.OpCodes = c.ToArray();
            try { module.Link(exe); }
            catch (IOException ex) { Console.WriteLine(ex.Message); }
            Process.Start(exe);
        }

        private static void exe2()
        {
            var exe = GetOutput("02.exe");
            var module = new Module();
            var c = new List<OpCode>();

            const int STD_INPUT_HANDLE = -10;
            const int STD_OUTPUT_HANDLE = -11;
            var ExitProcess = module.GetFunction(CallType.Std, "kernel32.dll", "ExitProcess");
            var GetStdHandle = module.GetFunction(CallType.Std, "kernel32.dll", "GetStdHandle");
            var ReadConsole = module.GetFunction(CallType.Std, "kernel32.dll", "ReadConsoleW");
            var WriteConsole = module.GetFunction(CallType.Std, "kernel32.dll", "WriteConsoleW");

            // HANDLE stdin = GetStdHandle(STD_INPUT_HANDLE);
            var stdin = new Addr32(module.GetInt32("stdin"));
            c.AddRange(GetStdHandle.Invoke(STD_INPUT_HANDLE));
            c.Add(I386.Mov(stdin, Reg32.EAX));

            // HANDLE stdout = GetStdHandle(STD_OUTPUT_HANDLE);
            var stdout = new Addr32(module.GetInt32("stdout"));
            c.AddRange(GetStdHandle.Invoke(STD_OUTPUT_HANDLE));
            c.Add(I386.Mov(stdout, Reg32.EAX));

            var dummy = module.GetInt32("dummy");
            var buffer = module.GetBuffer("buffer", 16);
            var hello = "Ola mundo";
            var wait = "\r\n\r\nPress [Enter] to exit.\r\n";
            c.AddRange(WriteConsole.Invoke(stdout, hello, hello.Length, dummy, 0));
            c.AddRange(WriteConsole.Invoke(stdout, wait, wait.Length, dummy, 0));
            c.AddRange(ReadConsole.Invoke(stdin, buffer, 1, dummy, 0));
            c.AddRange(ExitProcess.Invoke(0));

            module.Text.OpCodes = c.ToArray();
            try { module.Link(exe); }
            catch (IOException) { }
            Process.Start(exe);
        }

        private static void exe3()
        {
            var exe = GetOutput("03.exe");
            var module = new Module(IMAGE_SUBSYSTEM.WINDOWS_GUI);
            var c = new List<OpCode>();

            var MessageBox = module.GetFunction(CallType.Std, "user32.dll", "MessageBoxW");
            var ExitProcess = module.GetFunction(CallType.Std, "kernel32.dll", "ExitProcess");

            c.Add(I386.Push(3));
            var label = new OpCode();
            c.Add(label);
            c.AddRange(MessageBox.Invoke(0, "yes", "no", 0));
            c.Add(I386.Dec(new Addr32(Reg32.ESP)));
            c.Add(I386.Jcc(Cc.NZ, label.Address));
            c.Add(I386.Add(Reg32.ESP, 4));
            c.AddRange(ExitProcess.Invoke(0));

            module.Text.OpCodes = c.ToArray();
            try { module.Link(exe); }
            catch (IOException) { }
            Process.Start(exe);
        }


        public static void Main(string[] args)
        {
            exe1();
            exe2();
            exe3();
        }
    }
}