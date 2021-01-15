using System;

namespace RodriguesBrothersMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            User one = new User(Position.manager, "João Rodrigues", "abc");
            User two = new User(Position.manager, "Jorge Rodrigues", "def");

            int mainOption = 0;
                while (mainOption != 3)
                {
                    Console.WriteLine("**RodriguesBrothersMarket**");
                    Console.WriteLine("1 - Login");
                    Console.WriteLine("2 - Criar Funcionário");
                    Console.WriteLine("3 - Sair");

                mainOption = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (mainOption)
                    {
                        case 1:
                            Console.WriteLine("Testar Login");
                            break;

                        case 2:
                            Console.WriteLine("Testar criar Funcionário");
                            break;

                        case 3:
                            Console.WriteLine("Testar Sair");
                            break;

                        default:
                            Console.WriteLine("Escolha uma opção válida");
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }

                Console.WriteLine("Obrigado pela sua preferência");
        }
    }
}
