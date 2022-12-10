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

        static string NameAuth(string name)
        {
            bool flag = true;
            if (name.Length < 2)
            {
                Console.WriteLine("\nName has to be at least consisting 2 characters or more.");
                Console.Write("Input\t\t: ");
                name = Console.ReadLine();
                flag = false;
                return name;
            }
            flag = true;
            return name;
        }

        static string PasswordAuth(string password) 
        {
            bool flag = true;
            do
            {
                if(password.Length > 7 && password.Any<char>(new Func<char, bool>(char.IsUpper)) && password.Any<char>(new Func<char, bool>(char.IsLower)) && password.Any<char>(new Func<char, bool>(char.IsNumber)))
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Password must have at least 8 characters \nwith at least one Capital letter, at least one lower case letter and at least one number.");
                    Console.WriteLine("Password : ");
                    password = Console.ReadLine();
                    flag = true;
                }
            }
            while (flag);
            return password;
        }

        static void Create()
        {
            Console.Clear();

            Console.Write("First Name\t: ");
            string first_name = NameAuth(Console.ReadLine());

            Console.Write("Last Name\t: ");
            string last_name = NameAuth(Console.ReadLine());

            Console.Write("Password\t: ");
            string password = PasswordAuth(Console.ReadLine());

            Console.WriteLine("User Success to Created!!!");

            Console.ReadKey(true);
        }

        static void Main(string[] args)
        {
            bool main = true;
            while(main)
            {
                MainMenu();

                Console.Write("Input :");
                int option_menu = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (option_menu)
                    {
                        case 1:
                            Create();
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
                            if (option_user == 1)
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
                            else if (option_user == 2)
                            {
                                Console.Write("Id Yang Ingin Dihapus : ");
                                int id_user_delete = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("User Success to Deleted!!!");

                                Console.ReadKey(true);

                                goto case 2;
                            }
                            else if (option_user == 3)
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

                        case 3:
                            Console.Clear();

                            Console.WriteLine("==CARI AKUN==");
                            Console.Write("Masukan Nama : ");
                            string search_name = Console.ReadLine();

                            Console.WriteLine("========================");
                            Console.WriteLine("ID\t: ");
                            Console.WriteLine("Name\t: ");
                            Console.WriteLine("Username: ");
                            Console.WriteLine("Password: ");
                            Console.WriteLine("========================");

                            Console.ReadKey(true);
                            main = true;
                            break;
                        case 4:
                            Console.Clear();

                            Console.WriteLine("==LOGIN==");
                            Console.Write("USERNAME : ");
                            string username = Console.ReadLine();
                            Console.Write("PASSWORD : ");
                            string password_login = Console.ReadLine();

                            Console.WriteLine("MESSAGE : ");
                            Console.ReadKey(true);
                            main = true;
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("ERROR : Input Not Valid");

                            Console.ReadKey(true);

                            main = true;
                            break;
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("ERROR : Input Not Valid");

                    Console.ReadKey(true);

                    main= true;
                }
                
            }
            
        }
    }
}