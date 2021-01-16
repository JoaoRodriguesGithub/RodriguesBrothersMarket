using System;

namespace RodriguesBrothersMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection = 0;
            string nUser, nPassword;

            //User one = new User(Position.manager, "João Rodrigues", "abc");
            //User two = new User(Position.manager, "Jorge Rodrigues", "def");

            User uList = new User();


            while (selection != 3)
            {
                Console.WriteLine("**RodriguesBrothersMarket**");
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Criar Funcionário");
                Console.WriteLine("3 - Sair");

                selection = int.Parse(Console.ReadLine());
                Console.Clear();


                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Vai entrar na opção Login");
                        break;

                    case 2:
                        
                        Console.WriteLine("Insira o nome do Utilizador:");
                        nUser = Console.ReadLine();
                        Console.WriteLine("Insira a password:");
                        nPassword = Console.ReadLine();
                        uList.CreateUserSubMenu(nUser,nPassword);
                        Console.WriteLine(uList.ToString());
                        break;

                    case 3:
                        Console.WriteLine("Vai Sair");
                        break;

                    default:
                        Console.WriteLine("Opção Inválida. Tente novamente");
                        break;
                }
                Console.ReadKey();
                Console.Clear(); 
            }
            Console.WriteLine("Obrigado Pela Preferência | R&R Market!!!");
        }
    }
}
