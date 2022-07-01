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
                    case "phoneBook":
                        AddQuery = "UPDATE dbo.PhoneBook SET first_name = '" + element[0] + "', last_name = '" + element[1] + "', middle_name = '"
                            + element[2] + "', post = '" + element[3] + "', internal_number = '" + element[4]+ "', mobile_number = '" + element[5] + "' WHERE id = " +  id;
                        break;
                    case "printer":
                        AddQuery = "UPDATE dbo.Printer SET name_user = '" + element[0] + "', name_printer = '" + element[1] + "', model = '" + element[2] + "', name_port = '"
                            + element[3] + "', location = '" + element[4] + "', operation_system = '" + element[5] + "' WHERE id = " + id;
                        break;
                    case "holder":
                        AddQuery = "UPDATE dbo.Holder SET first_name = '" + element[0] + "', last_name = '" + element[1] + "', middle_name = '" + element[2] + "', status = '" + element[3] + "'  WHERE id = " + id;
                        break;
                    case "user":
                        AddQuery = "UPDATE dbo.UserDevice SET first_name = '" + element[0] + "', last_name = '" + element[1] + "', middle_name = '" + element[2] + "', status = '" + element[3] + "'  WHERE id = " + id;
                        break;
                    case "ie":
                        AddQuery = "UPDATE dbo.IndividualEntrepreneur SET first_name = '" + element[0] + "', last_name = '" + element[1] + "', middle_name = '" + element[2] + "'  WHERE id = " + id;
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

        public void UpdateDataElement(string connection, string[] element, int[] ids, int id, string items)
        {
            try
            {
                string AddQuery = null;


                if (items.Equals("simCard")) 
                {
                    AddQuery = "UPDATE dbo.SimCard SET operator = '" + element[0] + "', identifaction_number =  '" + element[1] + "', type_device =  '" + element[2] +
                        "', tms =  '" + element[3] + "', icc =  '" + element[4] + "', status =  '" + element[5] + "', id_individual_entrepreneur = " + ids[0] + ", id_cahsRegister = " + ids[1] + " WHERE id = " + id;
                }


                if (items.Equals("cashRegister"))
                {
                    AddQuery = "UPDATE dbo.CashRegister SET name = '" + element[0] + "', brand = '" + element[1] + "', factory_number =  '" + element[2] + "', serial_number =  '" + element[3] + "', " +
                           "payment_number =  '" + element[4] + "', date_reception =  '" + element[5] + "', location =  '" + element[6] + "', id_holder =  '" + ids[0] + "', id_user = '" + ids[1] + "' WHERE Id = " + id;
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
