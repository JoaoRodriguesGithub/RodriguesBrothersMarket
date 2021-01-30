using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RodriguesBrothersMarket
{
    class MarketTeam
    {
        //Lista de Utilizadores:
        public List<User> userList;

        //Construtores
        public MarketTeam()
        {
            this.userList = new List<User>();
        }

        //MÉTODOS:
        //Para criar utilizadores e gravar na lista de utilizadores:
        public User CreateUser(string position, string name, string password)
        {
            User newUser = new User(position, name, password);
            this.userList.Add(newUser);
            return newUser;
        }

        //Para efetuar login com verificação nome e password:
        public User Login(string position, string name, string password)
        {
            foreach (User u in this.userList)
            {
                if (u.position.Equals(position, StringComparison.OrdinalIgnoreCase) &&
                    u.name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                    u.password.Equals(password))
                {
                    return u;
                }
            }
            return null;
        }

        //Metodo apenas para referência
        public override string ToString()
        {
            string result = "|     FUNÇÃO     |     NOME     |     PASSWORD     |" + "\n";
            foreach (User u in this.userList)
            {
                result += u.position + "     |     " + u.name + "     |     " + u.password + "\n";
            }
            return result;
        }

        //Método para Apagar Utilizadores:
        public bool RemoveFromUsersList(string name)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (this.userList[i].name.ToLower().Equals(name.ToLower()))
                {
                    this.userList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        //Método para Gravar Utilizadores
        public void SaveToFileUsers()
        {
            //Escolher diretorio
            string path = Directory.GetCurrentDirectory();

            //nome do ficheiro
            string fileName = "/Users.txt";

            //abrir o Stream para escrita

            using (StreamWriter streamWriter = new StreamWriter(path + fileName, false))
            {
                //Percorrer e escrever a lista
                foreach (User item in this.userList)
                {
                    streamWriter.Write(item.position + "," + item.name + "," + item.password + "\n");
                }
            }
        }

        //Método para ler utilizadores:
        public void ReadUsersFile()
        {
            string path = Directory.GetCurrentDirectory();
            string fileName = "/Users.txt";

            try
            {
                using (StreamReader streamReader = new StreamReader(path + fileName))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string txtLine = streamReader.ReadLine();
                        string position = txtLine.Split(",")[0];
                        string name = txtLine.Split(",")[1];
                        string password = txtLine.Split(",")[2];

                        userList.Add(new User(position, name, password));
                    }
                }
            }
            catch (FileNotFoundException)
            {
            }
        }
    }
}
