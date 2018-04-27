using System;
using System.DirectoryServices;



namespace CreateUserCode
{
    class ManageUser
    {
        public static void CreateUser(string passedName, string pass)
        {
            try
            {
                DirectoryEntry ad = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry newUser = ad.Children.Add(passedName, "user");
                newUser.Invoke("SetPassword", new object[] { pass });
                newUser.Invoke("Put", new object[] { "Description", "Test User from .NET" });
                newUser.CommitChanges();
                DirectoryEntry grp;

                grp = ad.Children.Find("Administrators", "group");
                if (grp != null) { grp.Invoke("Add", new object[] { newUser.Path }); }
                Console.WriteLine("Account Created Successfully");
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();

            }

        }

        public static void DeleteUser(string passedName)
        {
            DirectoryEntry localDirectory = new DirectoryEntry("WinNT://" + Environment.MachineName);
            DirectoryEntries users = localDirectory.Children;
            DirectoryEntry user = users.Find(passedName);
            users.Remove(user);
        }

       public static void ChangePassword(string passedName, string pass)
        {
            DirectoryEntry localDirectory = new DirectoryEntry("WinNT://" + Environment.MachineName);
            DirectoryEntries users = localDirectory.Children;
            DirectoryEntry user = users.Find(passedName);
            user.Password = pass;
        }
    }
}
