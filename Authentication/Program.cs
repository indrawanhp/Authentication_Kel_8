using System.Diagnostics;

namespace Authentication
{
    class Program
    {
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("==BASIC AUTHENTICATION==");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User");
            Console.WriteLine("5. Exit");
        }

        static void Main(string[] args)
        {
            bool main = true;
            while(main)
            {
                MainMenu();

                Console.Write("Input :");
                int option_menu = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(option_menu);

                switch (option_menu)
                {
                    case 1:
                        //main = false;
                        Console.Clear();

                        //Input First Name
                        Console.Write("First Name\t: ");
                        string first_name = Console.ReadLine();

                        //Input Last Name
                        Console.Write("Last Name\t: ");
                        string last_name = Console.ReadLine();

                        //Input Password 
                        Console.Write("Password\t: ");
                        string password = Console.ReadLine();

                        Console.WriteLine("User Success to Created!!!");

                        Console.ReadKey(true);
                        break;
                    case 2:
                        main = false;
                        Console.Clear();
                        Console.WriteLine("==SHOW USER==");
                        Console.WriteLine("========================");
                        Console.WriteLine("ID\t: ");
                        Console.WriteLine("Name\t: ");
                        Console.WriteLine("Username: ");
                        Console.WriteLine("Password: ");
                        Console.WriteLine("========================");

                        Console.WriteLine("\nMenu");
                        Console.WriteLine("1. Edit User");
                        Console.WriteLine("2. Delete User");
                        Console.WriteLine("3. Back");

                        int option_user = Convert.ToInt32(Console.ReadLine());
                        if(option_user == 1)
                        {
                            Console.Write("Id Yang Ingin Diubah : ");
                            int id_user = Convert.ToInt32(Console.ReadLine());

                            Console.Write("First Name : ");
                            string first_name_edit = Console.ReadLine();

                            Console.Write("Last Name : ");
                            string last_name_edit = Console.ReadLine();

                            Console.Write("Password : ");
                            string password_edit = Console.ReadLine();

                            Console.WriteLine("User Success to Edited!!!");

                            Console.ReadKey(true);

                            goto case 2;
                        }
                        else if(option_user == 2)
                        {

                        }
                        else if(option_user == 3)
                        {
                            main = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR : Input Not Valid");

                            Console.ReadKey(true);
                            goto case 2;
                        }

                        break;

                    default:
                        break;
                }
            }
            
        }
    }
}