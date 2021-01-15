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
        //Variables:
        public Position position;
        public string name;
        public string password;

        //Constructor
        public User(Position position, string name, string password)
        {
            this.position = position;
            this.name = name;
            this.password = password;
        }

        //List:
        public List<User> userList;

        public User()
        {
            this.userList = new List<User>();
        }

        //Methods:
        
    }
}
