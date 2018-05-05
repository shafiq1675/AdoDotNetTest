using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                SqlCommand selectCMD = new SqlCommand("SELECT *  FROM [RASolarERP_SecurityAdmin].[dbo].[UserInformation]", connection);
                selectCMD.CommandTimeout = 30;
                SqlDataAdapter customerDA = new SqlDataAdapter();
                customerDA.SelectCommand = selectCMD;
                connection.Open();

                DataTable t = new DataTable();
                customerDA.Fill(t);
                connection.Close();
                foreach (DataRow sr in t.Rows)
                {
                    Console.WriteLine(sr["EmailID"]);
                }

              
                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }
            
            Console.ReadKey();
        }
        public static string GetConnectionString()
        {
           
            //return "Data Source=" + databaseName + ";Initial Catalog=RASolarERP; User ID=rsfit;Password=rsfit1234; providerName=System.Data.SqlClient;Persist Security Info=True;";
            string strRASolarERPServerName = "";//System.Configuration.ConfigurationManager.AppSettings["ServerName"];
            string strRASolarERPDatabase = "";//System.Configuration.ConfigurationManager.AppSettings["Database"];
            string strRASolarERPUserName = "";//System.Configuration.ConfigurationManager.AppSettings["UserName"];
            string strRASolarERPPassword = "";//System.Configuration.ConfigurationManager.AppSettings["Password"];

            string cStrConnectionStringToRSFERP = "Data Source=" + strRASolarERPServerName + ";Initial Catalog=" + strRASolarERPDatabase + ";Persist Security Info=True;User ID=" + strRASolarERPUserName + ";Password=" + strRASolarERPPassword;
            return cStrConnectionStringToRSFERP;
        }
    }

}
