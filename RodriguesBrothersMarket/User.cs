using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RodriguesBrothersMarket
{
    
    class User
    {
        //Atributos:
        public string position;
        public string name;
        public string password;

        //Lists:
        public List<User> userList;

        public User()
        {
            this.userList = new List<User>();
        }

        //Construtor
        public User(string position, string name, string password)
        {
            this.position = position;
            this.name = name;
            this.password = password;
        }

        //Metodos:
        public User CreateUser(string position, string name, string password)
        {
            User newUser = new User(position, name, password);
            this.userList.Add(newUser);
            return newUser;
        }

        public override string ToString()
        {
            string result = "|     FUNÇÃO     |     NOME     |     PASSWORD     |" + "\n";
            foreach (User u in this.userList)
            {
                result += u.position + "     |     " + u.name + "     |     " + u.password;
            }
            return result;
        }

        public void SaveToFileUsers()
        {
            //Escolher diretorio
            string path = Directory.GetCurrentDirectory();

            //nome do ficheiro
            string fileName = "/Users.txt";

            //abrir o Stream para escrita

            StreamWriter streamWriter = new StreamWriter(path + fileName, false);

            //Percorrer e escrever a lista
            foreach(User item in this.userList)
            {
                streamWriter.Write(item.position + "," + item.name + "," + item.password + "\n");
            }

            //Fechar a stream de escrita
            streamWriter.Close();
        }

        public void ReadUsersFile()
        {
            string path = Directory.GetCurrentDirectory();
            string fileName = "/Users.txt";

            StreamReader streamReader = new StreamReader(path + fileName);

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
}
