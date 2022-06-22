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
    class GetElement
    {
        public ObservableCollection<Cartridge> GetCartridges(string connection)
        {
            const string GetCartridgeQuery = "SELECT * FROM Cartrides;";

            var cartridges = new ObservableCollection<Cartridge>();
            try
            {
                using (var connect = new SqlConnection(connection))
                {
                    connect.Open();
                    if(connect.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = connect.CreateCommand())
                        {
                            cmd.CommandText = GetCartridgeQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var cartridge = new Cartridge
                                    {
                                        Id = reader.GetInt32(0),
                                        Brand = reader.GetString(1),
                                        Model = reader.GetString(2),
                                        VendorCode = reader.GetString(3),
                                        Status = reader.GetString(4)
                                    };
                                    cartridges.Add(cartridge);
                                }
                            }
                        }
                    }
                }
                return cartridges;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql);
            }
            return null;
        }

        public ObservableCollection<CashRegister> GetCashRegister(string connection)
        {
            const string GetCashRegister = "SELECT * FROM CashRegister;";

            var cashRegisters = new ObservableCollection<CashRegister>();
            try
            {
                using (var connect = new SqlConnection(connection))
                {
                    connect.Open();
                    if (connect.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = connect.CreateCommand())
                        {
                            cmd.CommandText = GetCashRegister;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var cashRegister = new CashRegister()
                                    {
                                        Id = reader.GetInt32(0),
                                        Name = reader.GetString(1),
                                        Brend = reader.GetString(2),
                                        FactoryNumber = reader.GetString(3),
                                        SerialNumber = reader.GetString(4),
                                        PaymentNumber = reader.GetString(5),
                                        Holder = reader.GetString(6),
                                        User = reader.GetString(7),
                                        DateReception = reader.GetDateTime(8),
                                        Location = reader.GetString(9)
                                    };
                                    cashRegisters.Add(cashRegister);
                                }
                            }
                        }
                    }
                }
                return cashRegisters;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql);
            }
            return null;
        }

        public ObservableCollection<PhoneBook> GetPhoneBook(string connection)
        {
            const string GetCashRegister = "SELECT * FROM PhoneBook;";

            var phoneBooks = new ObservableCollection<PhoneBook>();
            try
            {
                using (var connect = new SqlConnection(connection))
                {
                    connect.Open();
                    if (connect.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = connect.CreateCommand())
                        {
                            cmd.CommandText = GetCashRegister;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var phoneBook = new PhoneBook()
                                    {
                                        Id = reader.GetInt32(0),
                                        FirstName = reader.GetString(1),
                                        LastName = reader.GetString(2),
                                        MiddleName = reader.GetString(3),
                                        Post = reader.GetString(4),
                                        InternalNumber = reader.GetString(5),
                                        MobileNumber = reader.GetString(6)
                                    };
                                    phoneBooks.Add(phoneBook);
                                }
                            }
                        }
                    }
                }
                return phoneBooks;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql);
            }
            return null;
        }

        public ObservableCollection<Printer> GetPrinter(string connection)
        {
            const string GetPrinter = "SELECT * FROM Printer;";

            var printers = new ObservableCollection<Printer>();
            try
            {
                using (var connect = new SqlConnection(connection))
                {
                    connect.Open();
                    if (connect.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = connect.CreateCommand())
                        {
                            cmd.CommandText = GetPrinter;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var printer = new Printer()
                                    {
                                        Id = reader.GetInt32(0),
                                        NameUser = reader.GetString(1),
                                        NamePrinter = reader.GetString(2),
                                        Model = reader.GetString(3),
                                        NamePort = reader.GetString(4),
                                        Location = reader.GetString(5),
                                        OC = reader.GetString(6)
                                    };
                                    printers.Add(printer);
                                }
                            }
                        }
                    }
                }
                return printers;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql);
            }
            return null;
        }

        public ObservableCollection<SimCard> GetSimCard(string connection)
        {
            const string GetSimCard = "SELECT * FROM SimCard;";

            var simCards = new ObservableCollection<SimCard>();
            try
            {
                using (var connect = new SqlConnection(connection))
                {
                    connect.Open();
                    if (connect.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = connect.CreateCommand())
                        {
                            cmd.CommandText = GetSimCard;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var simcard = new SimCard()
                                    {
                                        ID = reader.GetInt32(0),
                                        Operator = reader.GetString(1),
                                        IdentNumber = reader.GetString(2),
                                        TypeDevice = reader.GetString(3),
                                        TMS = reader.GetInt32(4),
                                        ICC = reader.GetInt32(5),
                                        IndividualEntrepreneur = reader.GetString(6),
                                        Status = reader.GetString(7)
                                    };
                                    simCards.Add(simcard);
                                }
                            }
                        }
                    }
                }
                return simCards;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql);
            }
            return null;
        }
    }
}
