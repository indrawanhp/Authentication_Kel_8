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
            Console.Write("Input : ");
        }
        static void Main(string[] args)
        {
            List<string> first_name = new List<string>();
            List<string> last_name = new List<string>();
            List<string> username = new List<string>();
            List<string> password = new List<string>();
            int ulang = 0;
            do
            {
                MainMenu();
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine();
                        InputUser(first_name, last_name, username, password);
                        break;
                    case 2:
                        Console.Clear();
                        TampilUser(first_name, last_name, username, password);
                        Console.WriteLine();
                        Console.WriteLine("Menu");
                        Console.WriteLine("1. Edit User");
                        Console.WriteLine("2. Delete User");
                        Console.WriteLine("3. Back");
                        int menu = Convert.ToInt32(Console.ReadLine());
                        if (menu == 1)
                        {
                            EditUser(first_name, last_name, password);
                        }
                        else if (menu == 2)
                        {
                            DeleteUser(first_name, last_name, password);
                        }
                        else if (menu == 3)
                        {
                            Console.WriteLine("Press enter to continue!");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        SearchUser(first_name, last_name, username, password);
                        break;
                    case 4:
                        Console.Clear();
                        LoginUser(username, password);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
                Console.ReadLine();
            } while (ulang != 1);
        }
        static void InputUser(List<string> first_name, List<string> last_name, List<string> username, List<string> password)
        {
            //unutuk username
            string CharUserName1 = null; 
            string CharUserName2 = null;
            string usernameFix = null;

            // cek password
            int legalPass = 0;

            //input first_name
            Console.Write("First Name : ");
            string fn = Console.ReadLine();
            first_name.Add(fn);

            //input last_name
            Console.Write("Last Name : ");
            string ln = Console.ReadLine();
            last_name.Add(ln);

            do
            {
                //input password
                Console.Write("password : ");
                string pass = Console.ReadLine();
                legalPass = cekPassword(pass);

                if (legalPass == 1)
                {
                    char[] charactersFirst = fn.ToCharArray();
                    foreach (char userChar in charactersFirst)
                    {
                        CharUserName1 = string.Concat(charactersFirst[0], charactersFirst[1]);
                    }
                    char[] charactersLast = ln.ToCharArray();
                    foreach (char userChar in charactersLast)
                    {
                        CharUserName2 = string.Concat(charactersLast[0], charactersLast[1]);
                    }

                    usernameFix = CharUserName1 + CharUserName2;
                    username.Add(usernameFix);
                    password.Add(pass);
                    legalPass = 2;
                }
                else
                {
                    Console.WriteLine("Password must have at least 8 characters\r\n with at least one Capital letter, at least one lower case letter and at least one number.");
                }

            } while (legalPass != 2);
            Console.WriteLine("User Success to Created!!!");

        }
        static void TampilUser(List<string> first_name, List<string> last_name, List<string> username, List<string> password)
        {
            Console.WriteLine("==SHOW USER==");
            Console.WriteLine("=============");
            for (int i = 0; i < first_name.Count; i++)
            {
                int id = i + 1;
                Console.WriteLine("ID       : " + id);
                Console.WriteLine("Name     : " + first_name[i] + " " + last_name[i]);
                Console.WriteLine("Username : " + username[i]);
                Console.WriteLine("Password : " + password[i]);
                Console.WriteLine();
            }
            Console.WriteLine("=============");
        }
        static void LoginUser(List<string> username, List<string> password)
        {
            bool usernm = false;
            bool pw = false;
            int index;
            Console.WriteLine("LOGIN");

            // input username
            Console.Write("USERNAME : ");
            string user = Console.ReadLine();

            // input Password
            Console.Write("PASSWORD : ");
            string pass = Console.ReadLine();
            for (int i = 0; i < username.Count; i++)
            {
                if (user == username[i])
                {
                    index= i;
                    usernm = true;
                    if(pass == password[index])
                    {
                        pw = true;

                    }
                }
            }
            if(usernm && pw)
            {
                Console.WriteLine("login Success!!!");
            }
            else
            {
                Console.WriteLine("MESSAGE : Username atau Password Tidak Ditemukan");
            }

        }
        static void EditUser(List<string> first_name, List<string> last_name, List<string> password)
        {
            Console.WriteLine("Id Yang Ingin Di Ubah : ");
            int cekid = Convert.ToInt32(Console.ReadLine());
            if (first_name.Count >= cekid)
            {
                cekid -= 1;
                Console.Write("First Name : ");
                first_name[cekid] = (Console.ReadLine());
                Console.Write("Last Name : ");
                last_name[cekid] = (Console.ReadLine());
                Console.Write("Password : ");
                password[cekid] = (Console.ReadLine());
                Console.WriteLine("User Success to Edited!!!");
            }
            else
            {
                Console.WriteLine("User Not Found!!!");
            }
        }
        static void DeleteUser(List<string> first_name, List<string> last_name, List<string> password)
        {
            Console.WriteLine("Id Yang Ingin Di Hapus : ");
            int cekid = Convert.ToInt32(Console.ReadLine());
            if (first_name.Count >= cekid)
            {
                cekid -= 1;
                first_name.RemoveAt(cekid);
                last_name.RemoveAt(cekid);
                password.RemoveAt(cekid);
                Console.WriteLine("User Success to Deleted!!!");
            }
            else
            {
                Console.WriteLine("User Not Found!!!");
            }
        }
        static void SearchUser(List<string> first_name, List<string> last_name, List<string> username, List<string> password)
        {
            Console.WriteLine("==Cari Akun==");
            Console.Write("Masukan Nama : ");
            string cekNama = Console.ReadLine();
            int cekData = 0;

            for (int i = 0; i < first_name.Count; i++)
            {
                if (cekNama == first_name[i] || cekNama == last_name[i])
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
        }
        static int cekPassword(string pass)
        {
            int legalPass = 0;
            bool upper = false;
            bool number = false;
            bool length = false;
            if(pass.Length >= 8)
            {
                length= true;
            }
            if(pass.Any(char.IsUpper))
            {
                upper= true;
            }
            if(pass.Any(char.IsNumber))
            {
                number= true;
            }
            if(upper && number && length)
            {
                legalPass= 1;
            }
            else
            {
                legalPass= 0;
            }
            return legalPass;
        }
    }
}