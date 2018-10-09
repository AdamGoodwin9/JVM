using System;

namespace MyJVM
{
    class Program
    {
        private static readonly string rootDir = @"C:\Users\Adam Goodwin\Documents\VSCode\JavaTest\build\classes\java\main\";
        private static readonly string fileName = "Program.class";

        private static readonly string path = rootDir + fileName;

        
        static void Main(string[] args)
        {
            ClassFile mainClass = new ClassFile(path);

            int ret = 0;

            for (int i = 0; i < mainClass.Methods.Length; i++)
            {
                if(mainClass.Methods[i].Name == "main")
                {
                    ret = mainClass.Methods[i].Frame.Run().low;
                    break;
                }
            }

            Console.WriteLine(ret);
            Console.ReadKey();
        }
    }
}
