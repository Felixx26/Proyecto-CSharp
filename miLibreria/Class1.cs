using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MiLibreria
{
    public class Utilidades
    {
        public static DataSet Ejecutar(string cmd)
        {
            const string ConnectionString = "Data Source=DESKTOP-N1UDO6A\\FELIXDB;Database=axuradb; Initial Catalog=axuradb; Integrated Security=True";
            SqlConnection CON = new SqlConnection(ConnectionString);
            CON.Open();
            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(cmd, CON);

            DP.Fill(DS);

            CON.Close();

            return DS;
        }
    }
}
