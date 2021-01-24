using System;

namespace RodriguesBrothersMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection = 0;
            string nPosition, nUser, nPassword;
            
            /*
            User testerManager = new User("gerente", "jorge", "aaa");
            //User testerReplanisher = new User("repositor", "alberto", "bbb");
            //User testerCashier = new User("caixa", "maria", "ccc");
            */
            MarketTeam uList = new MarketTeam();
            uList.ReadUsersFile();
            
            /*
            uList.userList.Add(testerManager);
            uList.userList.Add(testerReplanisher);
            uList.userList.Add(testerCashier);
            */

            while (selection != 3)
            {
                Console.WriteLine("     **RodriguesBrothersMarket**");
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Criar Funcionário");
                Console.WriteLine("3 - Sair");

                selection = int.Parse(Console.ReadLine());
                Console.Clear();


                switch (selection)
                {
                    case 1:
                        Console.WriteLine("     **Efetue o seu login**");

                        Console.WriteLine("Insire o nome de utilizador: ");
                        nUser = Console.ReadLine();
                        Console.WriteLine("Insira a password: ");
                        nPassword = Console.ReadLine();

                        User userMatch = uList.Login(nUser, nPassword);
                        if (userMatch != null)
                        {
                            Console.WriteLine("Sucesso");
                            MenuManager();
                        }
                        else
                        {
                            Console.WriteLine("Utilizador ou password inválidas. Tente novamente");
                        }
                        break;

                    case 2:
                        Console.WriteLine("     **Criar Funcionário**");

                        Console.WriteLine("Insira a função do novo utilizador:");
                        nPosition = Console.ReadLine();

                        Console.WriteLine("Insira o nome do novo utilizador:");
                        nUser = Console.ReadLine();

                        Console.WriteLine("Insira a password:");
                        nPassword = Console.ReadLine();

                        uList.CreateUser(nPosition,nUser,nPassword);
                       
                        uList.SaveToFileUsers();
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

            
            static void MenuManager()
            {
                int managerSelection = 0;
                while (managerSelection != 3)
                {
                    Console.WriteLine("     **MENU DO GERENTE**");

                    Console.WriteLine("1 - Apagar Funcionários");
                    Console.WriteLine("2 - Vender Produtos");
                    Console.WriteLine("3 - Voltar");

                    managerSelection = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (managerSelection)
                    {
                        case 1:
                            Console.WriteLine("Funcionalidade de Apagar funcionários");
                            break;

                        case 2:
                            Console.WriteLine("Funcionalidade de Vender Produtos");
                            break;

                        case 3: return;

                        default:
                            Console.WriteLine("Opção Inválida. Tente novamente");
                            break;
                    }
                }

                static void MenuReplanisher()
                {
                    int replanisherSelection = 0;
                    while (replanisherSelection != 4)
                    {
                        Console.WriteLine("     **MENU DO REPOSITOR**");

                        Console.WriteLine("1 - Adicionar novos produtos ao stock");
                        Console.WriteLine("2 - Remover produtos ao stock");
                        Console.WriteLine("3 - Limpar stock");
                        Console.WriteLine("4 - Voltar");

                        replanisherSelection = int.Parse(Console.ReadLine());
                        Console.Clear();

                        switch (replanisherSelection)
                        {
                            case 1:
                                Console.WriteLine("Funcionalidade de adicionar novos produtos ao stock");
                                break;

                            case 2:
                                Console.WriteLine("Funcionalidade Remover produtos ao stock");
                                break;

                            case 3:
                                Console.WriteLine("Funcionalidade limpar stock");
                                break;

                            case 4: return;

                            default:
                                Console.WriteLine("Opção Inválida. Tente novamente");
                                break;
                        }
                    }
                }

                static void MenuCashier()
                {
                    int cashierSelection = 0;
                    while (cashierSelection != 4)
                    {
                        Console.WriteLine("     **MENU DO CAIXA**");

                        Console.WriteLine("1 - Vender Produtos");
                        Console.WriteLine("2 - Voltar");

                        cashierSelection = int.Parse(Console.ReadLine());
                        Console.Clear();

                        switch (cashierSelection)
                        {
                            case 1:
                                Console.WriteLine("Funcionalidade que permite venda de produtos");
                                break;

                            case 2: return;

                            default:
                                Console.WriteLine("Opção Inválida. Tente novamente");
                                break;
                        }
                    }
                }
            }
        }
    }
}
