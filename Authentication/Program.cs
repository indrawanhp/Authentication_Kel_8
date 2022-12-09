namespace Authentication
{
    class Program
    {
        static void MainMenu()
        {
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
            MainMenu();

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.WriteLine();
                    Console.Clear();

                    //input first_name
                    Console.Write("First Name : ");
                    String first_name = Console.ReadLine();

                    //input last_name
                    Console.Write("Last Name : ");
                    String last_name = Console.ReadLine();

                    //input password

                    Console.Write("Password : ");
                    String password = Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("==SHOW USER==");
                    Console.WriteLine("=============");
                    Console.WriteLine();
                    Console.WriteLine("=============");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("==CARI AKUN==");
                    Console.Write("Masukan Nama : ");
                    String name = Console.ReadLine();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("LOGIN");
                    Console.Write("USERNAME : ");
                    // input username
                    String username = Console.ReadLine();

                    Console.Write("PASSWORD : ");
                    // input Password
                    String pass = Console.ReadLine();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }
    }
}