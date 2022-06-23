using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalMaster.ViewModel
{
    class UpdateElement
    {
        public void UpdateDataElement(string connection, string[] element, int id, string items)
        {
            try
            {
                string AddQuery = null;

                switch (items)
                {
                    case "cartrides":
                        AddQuery = "UPDATE dbo.Cartrides SET brand = '" + element[0] + "', model = '" + element[1] + "', vendor_code = '" + element[2] + "', status = '" + element[3] + "' WHERE id = " + id;
                        break;
                    case "cashRegister":
                        AddQuery = "UPDATE dbo.CashRegister SET name = '" + element[0] + "', brand = '" + element[1] + "', factory_number = '" + element[2] + "', serial_number = '"
                            + element[3] + "', serial_number = '" + element[4] + "', date_reception = '" + element[5] + "', location = '" + element[6] + "' WHERE id = " + id;
                        break;
                    case "phoneBook":
                        AddQuery = "UPDATE dbo.PhoneBook SET first_name = '" + element[1] + "', last_name = '" + element[2] + "', middle_name = '"
                            + element[3] + "', post = '" + element[4] + "', internal_number = '" + element[5] + "', mobile_number = '" + element[6] + "' WHERE id = " +  id;
                        break;
                    case "printer":
                        AddQuery = "UPDATE dbo.Printer SET name_user = '" + element[0] + "', name_printer = '" + element[1] + "', model = '" + element[2] + "', name_port = '"
                            + element[3] + "', location = '" + element[4] + "', operation_sustem = '" + element[5] + "' WHERE id = " + id;
                        break;
                    case "simCard":
                        AddQuery = "UPDATE dbo.SimCard SET operator = , identifaction_number = '" + element[0] + "', type_device = '" + element[1] + "', tms = '" + element[2] + "', icc = '"
                            + element[3] + "', status = '" + element[5] + "' WHERE id = " + id;
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
