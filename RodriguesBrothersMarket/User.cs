using System;
using System.Collections.Generic;
using System.Text;

namespace RodriguesBrothersMarket
{
    enum Position{
        manager,
        chashier,
        replanisher
    }
    
    class User
    {
        //Atributos:
        public Position position;
        public string name;
        public string password;

        //Lists:
        public List<User> userList;

        public User()
        {
            this.userList = new List<User>();
        }

        //Construtor
        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        //Metodos:
        public User CreateUserSubMenu(string name, string password)
        {
            User newUser = new User(name, password);
            this.userList.Add(newUser);
            return newUser;

            //Console.WriteLine("Já estou a criar o funcionário");
        }

        public override string ToString()
        {
            string result = "NOME     |     PASSWORD" + "\n";
            foreach (User u in this.userList)
            {
                result += u.name +"   |   " + u.password;
            }
            return result;
        }

    }
}
