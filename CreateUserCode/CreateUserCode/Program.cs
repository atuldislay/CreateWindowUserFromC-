using System;
using System.DirectoryServices;


namespace CreateUserCode
{
    class Program
    {
        public static string Name;
        public static string Pass;

        static void Main(string[] args)
        {
            //Console.WriteLine("Windows Account Creator");
            //Console.WriteLine("Enter User passedName");
            //Name = Console.ReadLine();
            //Console.WriteLine("Enter User Password");
            //Pass = Console.ReadLine();
            //ManageUser.CreateUser(Name, Pass);
            ManageUser.ChangePassword("rahulG",@"@@@qwe123");
        }
    }  
}
