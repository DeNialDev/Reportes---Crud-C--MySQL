using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_Ima
{
    class ParamBD
    {
        String DataBase = "saveimage";
        String Server = "localhost";
        String Port = "3306";
        String User = "root";
        String PassWord = "123456";

        public String getDBName()
        {
            return DataBase;
        }
        public String getDBServer()
        {
            return Server;
        }
        public String getDBPort()
        {
            return Port;
        }
        public String getDBUser()
        {
            return User;
        }
        public String getDBPass()
        {
            return PassWord;
        }

    }
}
