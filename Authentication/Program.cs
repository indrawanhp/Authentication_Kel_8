using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;

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
                if(password.Length > 7 && password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsNumber))
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Password must have at least 8 characters \nwith at least one Capital letter, at least one lower case letter and at least one number.");
                    Console.Write("Password : ");
                    password = Console.ReadLine();
                    flag = true;
                }
            }
            while (flag);
            return password;
        }

        static void Create(List<string> first_name, List<string> last_name, List<string> username, List<string> password)
        {
            Console.Clear();

            Console.Write("First Name\t: ");
            string first = Console.ReadLine();
            first_name.Add(NameAuth(first));

            Console.Write("Last Name\t: ");
            string second = Console.ReadLine();
            last_name.Add(NameAuth(second));

            string combine = first.Substring(0, 2) + second.Substring(0, 2);
            username.Add(combine);

            Console.Write("Password\t: ");
            password.Add(PasswordAuth(Console.ReadLine()));

            Messages("Created");
            Console.ReadKey(true);
        }

        static void View(List<string> first_name, List<string> last_name, List<string> username, List<string> password)
        {
            Console.WriteLine("==SHOW USER==");

            int id = 0;
            for(int i = 0; i < first_name.Count; i++)
            {
                id++;
                Console.WriteLine("========================");
                Console.WriteLine($"ID\t: {id}");
                Console.WriteLine($"Name\t: {first_name[i]} {last_name[i]}");
                Console.WriteLine($"Username: {username[i]}");
                Console.WriteLine($"Password: {password[i]}");
                Console.WriteLine("========================");
            }
        }

        static void ShowUser(List<string> first_name, List<string> last_name, List<string> username, List<string> password)
        {
            Console.Clear();

            View(first_name, last_name, username, password);

            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");

            
        }

        static void EditUser(List<string> first_name, List<string> last_name, List<string> username, List<string> password)
        {
            bool flag = true;
            do
            {

                Console.WriteLine("Id Yang Ingin Di Ubah : ");
                int cekid = Convert.ToInt32(Console.ReadLine());
                if (first_name.Count >= cekid)
                {
                    cekid -= 1;
                    Console.Write("First Name : ");
                    string first = Console.ReadLine();
                    first_name[cekid] = NameAuth(first);
                    Console.Write("Last Name : ");
                    string second = Console.ReadLine();
                    last_name[cekid] = NameAuth(second);
                    username[cekid] = first.Substring(0, 2) + second.Substring(0, 2);
                    Console.Write("Password : ");
                    password[cekid] = PasswordAuth(Console.ReadLine());
                    Console.WriteLine("User Success to Edited!!!");
                    flag = false;
                }
                else
                {
                    Console.WriteLine("User Not Found!!!");
                }
            } while (flag);


            Console.ReadKey(true);
        }

        static void DeleteUser(List<string> first_name, List<string> last_name, List<string> username,List<string> password)
        {
            Console.WriteLine("Id Yang Ingin Di Hapus : ");
            int cekid = Convert.ToInt32(Console.ReadLine());
            if (first_name.Count >= cekid)
            {
                cekid -= 1;
                first_name.RemoveAt(cekid);
                last_name.RemoveAt(cekid);
                username.RemoveAt(cekid);
                password.RemoveAt(cekid);
                Console.WriteLine("User Success to Deleted!!!");
            }
            else
            {
                Console.WriteLine("User Not Found!!!");
            }
            Console.ReadKey(true);
        }

        static void SearchUser(List<string> first_name, List<string> last_name, List<string> username, List<string> password)
        {
            Console.WriteLine("==Cari Akun==");
            Console.Write("Masukan Nama : ");
            string cekNama = Console.ReadLine();
            int cekData = 0;

            for (int i = 0; i < first_name.Count; i++)
            {
                if (first_name[i].ToLower().Contains(cekNama.ToLower()) || last_name[i].ToLower().Contains(cekNama.ToLower()))
                {
                    int id = i + 1;
                    Console.WriteLine("=============");
                    Console.WriteLine("ID       : " + id);
                    Console.WriteLine("Nama     : " + first_name[i] + " " + last_name[i]);
                    Console.WriteLine("Username : " + username[i]);
                    Console.WriteLine("Password : " + password[i]);
                    Console.WriteLine("=============");
                    cekData = 1;
                }
            }

            if (cekData == 0)
            {
                Console.WriteLine("User Not Found!!!");
            }
            Console.ReadKey(true);
        }

        static void LoginUser(List<string> username, List<string> password)
        {
            Console.Clear();

            Console.WriteLine("==LOGIN==");
            Console.Write("USERNAME : ");
            string username_login = Console.ReadLine();
            Console.Write("PASSWORD : ");
            string password_login = Console.ReadLine();

            for(int i = 0; i < username.Count; i++)
            {
                if (username_login.Equals(username[i]) && password_login.Equals(password[i].ToString()))
                {
                    Console.WriteLine("MESSAGE : Login Success!");
                }
                else
                {
                    Console.WriteLine("User is not exist or username and password doesnt match!");
                    
                }
            }
            Console.ReadKey(true);
        }

        static void Messages(string message)
        {
            Console.WriteLine($"User Success to {message} !!!");
        }

        static void Main(string[] args)
        {
            List<string> first_name = new List<string>();
            List<string> last_name = new List<string>();
            List<string> username = new List<string>();
            List<string> password = new List<string>();

            bool main = true;
            while (main)
            {
                MainMenu();

                Console.Write("Input :");
                int option_menu = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (option_menu)
                    {
                        case 1:
                            Create(first_name, last_name, username, password);
                            break;
                        case 2:

                            bool flag = true;
                            while(flag)
                            {
                                ShowUser(first_name, last_name, username, password);

                                int option_user = Convert.ToInt32(Console.ReadLine());
                                if (option_user == 1)
                                {
                                    EditUser(first_name, last_name, username, password);
                                    flag = true;
                                }
                                else if (option_user == 2)
                                {
                                    DeleteUser(first_name, last_name, username, password);
                                    flag = true;
                                }
                                else if (option_user == 3)
                                {
                                    flag = false;
                                    main = true;
                                }
                                else
                                {
                                    Console.WriteLine("ERROR : Input Not Valid");

                                    Console.ReadKey(true);
                                    flag = true;
                                }
                            }
                            break;
                        case 3:
                            Console.Clear();
                            SearchUser(first_name, last_name, username, password);
                            main = true;
                            break;
                        case 4:
                            LoginUser(username, password);
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

                    main = true;
                }

            }
        }
    }
}