using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalMaster.Model;

namespace TerminalMaster.ViewModel
{
    class AddElement
    {
        public void AddDataElement(string connection, string[] element, string items)
        {
            try
            {
                string AddQuery = null;
                string values = null;

                for (int i = 0; i < element.Length; i++)
                {
                    if (i == 0)
                    {
                        values += "('" + element[i] + "','";
                    }
                    else if (i == element.Length - 1)
                    {
                        values += element[i] + "')";
                    }
                    else
                    {
                        values += element[i] + "','";
                    }
                }

                switch (items)
                {
                    case "cartrides":
                        AddQuery = "INSERT INTO dbo.Cartrides (brand, model, vendor_code, status) VALUES " + values;
                        break;
                    case "cashRegister":
                        AddQuery = "INSERT INTO dbo.CashRegister (name, brand, factory_number, serial_number, serial_number, date_reception, location) VALUES " + values;
                        break;
                    case "phoneBook":
                        AddQuery = "INSERT INTO dbo.PhoneBook (first_name, last_name, middle_name, post, internal_number, mobile_number) VALUES " + values;
                        break;
                    case "printer":
                        AddQuery = "INSERT INTO dbo.Printer (name_user, name_printer, model, name_port, location, operation_system) VALUES " + values;
                        break;
                    case "simCard":
                        AddQuery = "INSERT INTO dbo.SimCard (operator, identifaction_number, type_device, tms, icc, status) VALUES " + values;
                        break;
                    case "holder":
                        AddQuery = "INSERT INTO dbo.Holder (first_name, last_name, middle_name) VALUES " + values;
                        break;
                    case "user":
                        AddQuery = "INSERT INTO dbo.UserDevice (first_name, last_name, middle_name) VALUES " + values;
                        break;
                    case "ie":
                        AddQuery = "INSERT INTO dbo.IndividualEntrepreneur (first_name, last_name, middle_name) VALUES " + values;
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
