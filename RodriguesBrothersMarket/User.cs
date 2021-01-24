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

        //Construtor
        public User(string position, string name, string password)
        {
            this.position = position;
            this.name = name;
            this.password = password;
        }

    }
}
