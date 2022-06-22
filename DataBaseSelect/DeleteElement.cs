using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalMaster.ViewModel
{
    class DeleteElement
    {

        public void DeleteDataElement(string connection, string id, string items)
        {
            try
            {
                string AddQuery = null;

                switch (items)
                {
                    case "cartrides":
                        AddQuery = "DELETE FROM dbo.Cartides WHERE id = ";
                        break;
                    case "cashRegister":
                        AddQuery = "DELETE FROM dbo.CashRegister WHERE id = ";
                        break;
                    case "phoneBook":
                        AddQuery = "DELETE FROM dbo.PhoneBook WHERE id = ";
                        break;
                    case "printer":
                        AddQuery = "DELETE FROM dbo.Printer WHERE id = ";
                        break;
                    case "simCard":
                        AddQuery = "DELETE FROM dbo.SimCard WHERE id = ";
                        break;
                    default:
                        break;
                }

                var connect = new SqlConnection(connection);
                connect.Open();
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand cmd = connect.CreateCommand();
                    cmd.CommandText = AddQuery;
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                }
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql);
            }

        }
    }
}
