using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLConsoleApp
{
    class Prog()
    {
        static void Main(string[] args){
            Console.WriteLine("Enter UserName:");
            String username = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            String password = Console.ReadLine();
            Console.WriteLine(username + " , " + password);

        }
    }
}
 