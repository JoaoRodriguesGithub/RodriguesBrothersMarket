using System;
using System.Collections.Generic;

namespace RodriguesBrothersMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection = 0;
            
            //Variáveis de leitura do teclado:
            string nPosition, nUser, nPassword, nName, nCategory;
            int nProductQnt, nPrice;
            string saleProductName;
            int saleProductQnt;

            //Instanciar as listas:
            MarketTeam uList = new MarketTeam();
            Stock pList = new Stock();
            Finance finance = Finance.ReadFinalInvoice();
            Invoice.id = finance.allSalesList.Count;

            uList.ReadUsersFile();
            pList.ReadFromFileStock();

            //MENU PRINCIPAL
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

                        Console.WriteLine("Insira a função do utilizador(GERENTE|REPOSITOR|CAIXA): ");
                        nPosition = Console.ReadLine();
                        Console.WriteLine("Insira o nome de utilizador: ");
                        nUser = Console.ReadLine();
                        Console.WriteLine("Insira a password: ");
                        nPassword = Console.ReadLine();

                        User userMatch = uList.Login(nPosition, nUser, nPassword);
                        if (userMatch != null)
                        {
                            if (userMatch.position == "gerente")
                            {
                                Console.WriteLine("OPERAÇÂO LOGIN: Efetuada com sucesso!");
                                MenuManager();
                            }
                            if (userMatch.position == "repositor")
                            {
                                Console.WriteLine("OPERAÇÂO LOGIN: Efetuada com sucesso!");
                                MenuReplanisher();
                            }
                            if (userMatch.position == "caixa")
                            {
                                Console.WriteLine("OPERAÇÂO LOGIN: Efetuada com sucesso!");
                                MenuCashier();
                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine("     **Criar Funcionário**");

                        Console.WriteLine("Insira a função do novo utilizador (GERENTE|REPOSITOR|CAIXA):");
                        nPosition = Console.ReadLine();

                        Console.WriteLine("Insira o nome do novo utilizador:");
                        nUser = Console.ReadLine();

                        Console.WriteLine("Insira a password:");
                        nPassword = Console.ReadLine();

                        uList.CreateUser(nPosition, nUser, nPassword);

                        uList.SaveToFileUsers();
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

            //SUB-MENU GERENTE:
            void MenuManager()
            {
                int managerSelection = 0;
                while (managerSelection != 4)
                {
                    Console.WriteLine("     **MENU DO GERENTE**");

                    Console.WriteLine("1 - Apagar Funcionários");
                    Console.WriteLine("2 - Vender Produtos");
                    Console.WriteLine("3 - Listar todas as faturas");
                    Console.WriteLine("4 - Voltar");

                    managerSelection = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (managerSelection)
                    {
                        case 1:
                            Console.WriteLine("Introduza o nome do funcionário que pretende eliminar");
                            string managerInput = Console.ReadLine();
                            bool result = uList.RemoveFromUsersList(managerInput);
                            if (result)
                            {
                                Console.WriteLine("Utilizador eliminado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Operação sem sucesso!");
                            }
                            uList.SaveToFileUsers();
                            break;

                        case 2:
                            MenuForSales();
                            break;

                        case 3:
                            Console.WriteLine("LISTAGEM DE TODAS AS FATURAS:");
                            Console.WriteLine(finance.ToString());
                            break;
                        case 4: return;

                        default:
                            Console.WriteLine("Opção Inválida. Tente novamente");
                            break;
                    }
                
                    uList.SaveToFileUsers();
                }
            }
            
            //SUB-MENU REPOSITOR:
            void MenuReplanisher()
            {
                int replanisherSelection = 0;
                while (replanisherSelection != 4)
                {
                    Console.WriteLine("     **MENU DO REPOSITOR**");

                    Console.WriteLine("1 - Adicionar um novo produto ao stock");
                    Console.WriteLine("2 - Remover produtos ao stock");
                    Console.WriteLine("3 - Limpar stock");
                    Console.WriteLine("4 - Voltar");

                    replanisherSelection = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (replanisherSelection)
                    {
                        case 1:
                            Console.WriteLine("Intoduza o nome da categoria do produto (CONGELADOS|PRATELEIRA|ENLATADOS): ");
                            nCategory = Console.ReadLine();
                            Console.WriteLine("Intoduza o nome do produto: ");
                            nName = Console.ReadLine();
                            Console.WriteLine("Introduza a quantidade deste produto: ");
                            nProductQnt = int.Parse(Console.ReadLine());
                            Console.WriteLine("Introduza o preço do produto: ");
                            nPrice = int.Parse(Console.ReadLine());
                            pList.CreateProduct(Product.ConvertCategory(nCategory), nName, nProductQnt, nPrice);
                            pList.SaveToFileStock();
                            break;

                        case 2:
                            Console.WriteLine("Qual é o produto que pretende elimiar do stock: ");
                            string replanisherInput = Console.ReadLine();
                            bool result = pList.DeleteProductFromList(replanisherInput);
                            if (result)
                            {
                                Console.WriteLine("O Produto foi eliminado do stock com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Operação sem sucesso!");
                            }
                            pList.SaveToFileStock();
                            break;

                        case 3:
                            if (pList.ClearStock())
                            {
                                Console.WriteLine("O stock foi eliminado com sucesso!");
                            }
                            break;

                        case 4: return;

                        default:
                            Console.WriteLine("Opção Inválida. Tente novamente");
                            break;
                    }
                    pList.SaveToFileStock();
                }
            }
            
            //SUB-MENU CAIXA:
            void MenuCashier()
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
                            MenuForSales();
                            break;

                        case 2: return;

                        default:
                            Console.WriteLine("Opção Inválida. Tente novamente");
                            break;
                    }
                }
            }

            //SUB-MENU PARA VENDA DE PRODUTOS:
            void MenuForSales()
            {
                Invoice invoice = new Invoice();
                int selection = 0;
                while (selection != 2)
                {
                    Console.WriteLine("     **VENDA DE PRODUTOS**");
                    
                    Console.WriteLine(pList.ToString());
                    Console.WriteLine("0 - Finalizar compra");
                    Console.WriteLine("1 - Adicionar Produtos ao carrinho");
                    Console.WriteLine("2 - Voltar");

                    selection = int.Parse(Console.ReadLine());

                    switch (selection)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Introduza o nome do cliente para finalizar a compra e emitir a sua fatura: ");
                            invoice.userName = nUser;
                            invoice.customerName = Console.ReadLine();

                            Console.WriteLine(invoice.ToString());

                            invoice.SaveInvoice();
                            finance.AddInvoice(invoice);
                            finance.SaveFinalInvoice();
                            pList.SaveToFileStock();
                            
                            break;
                        
                        case 1:
                            Console.WriteLine("Escreva o nome do produto que quer adicionar ao carrinho: ");
                            saleProductName = Console.ReadLine();
                            Console.WriteLine("Indique a quantidade do produto selecionado que pretende adicionar ao carrinho: ");
                            saleProductQnt = int.Parse(Console.ReadLine());
                            
                            Product productMatch = pList.SelectProduct(saleProductName, saleProductQnt);
                            if (productMatch != null)
                            {
                                if (productMatch.productName == saleProductName && productMatch.productQnt >= saleProductQnt)
                                {
                                    productMatch.productQnt -= saleProductQnt;

                                    int priceT = (saleProductQnt * productMatch.price);

                                    invoice.CreateInvoiceLine(productMatch.productName, saleProductQnt, priceT);
                                }
                                else
                                {
                                    Console.WriteLine("Lamentamos, mas só dipomos de " + productMatch.productQnt + "unidades.");
                                }
                            }

                            break;

                        default:
                            Console.WriteLine("Opção Inválida. Tente novamente");
                            break;
                    }
                }
            }
        }
    }
}
