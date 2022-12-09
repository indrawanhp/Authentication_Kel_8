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
            List<int> id = new List<int>();
            List<string> first_name = new List<string>();
            List<string> last_name = new List<string>();
            List<string> username = new List<string>();
            List<string> password = new List<string>();
            int input2;
            do
            {
                MainMenu();
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine();
                        InputUser(id, first_name, last_name, password);
                        break;
                    case 2:
                        Console.Clear();
                        TampilUser(id, first_name, last_name, password);
                        break;
                    case 3:
                        Console.Clear();
                        CariAkun();
                        break;
                    case 4:
                        Console.Clear();
                        LoginUser();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
                Console.WriteLine("Kembali Ke Home?");
                Console.WriteLine("1. Ya");
                Console.WriteLine("2. tidak");
                Console.Write("Masukan Pilihan : ");
                input2 = Convert.ToInt32(Console.ReadLine());
            } while (input2 != 2);
        }
        static void InputUser(List<int> id, List<string> first_name, List<string> last_name, List<string> password)
        {
            //input first_name
            Console.Write("First Name : ");
            first_name.Add(Console.ReadLine());

            //input last_name
            Console.Write("Last Name : ");
            last_name.Add(Console.ReadLine());

            //input password
            Console.Write("Password : ");
            password.Add(Console.ReadLine());

            //input id
            int idinput = first_name.Count + 1;
            id.Add(idinput);

        }
        static void TampilUser(List<int> id, List<string> first_name, List<string> last_name, List<string> password)
        {
            Console.WriteLine("==SHOW USER==");
            Console.WriteLine("=============");
            for (int i = 0; i < first_name.Count; i++)
            {
                Console.WriteLine("ID       : " + id);
                Console.WriteLine("Name     : " + first_name[i] + " " + last_name[i]);
                Console.WriteLine("Username : " + last_name[i]);
                Console.WriteLine("Password : " + password[i]);
            }
            Console.WriteLine("=============");
        }
        static void CariAkun()
        {
            Console.WriteLine("==CARI AKUN==");
            Console.Write("Masukan Nama : ");
            string name = Console.ReadLine();

        }
        static void LoginUser ()
        {
            Console.WriteLine("LOGIN");

            // input username
            Console.Write("USERNAME : ");
            string username = Console.ReadLine();

            // input Password
            Console.Write("PASSWORD : ");
            string pass = Console.ReadLine();
        }
    }
}