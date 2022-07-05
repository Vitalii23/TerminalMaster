using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalMaster.Model;
using TerminalMaster.Model.People;

namespace TerminalMaster.DML
{
    class OrderByElement
    {
        public ObservableCollection<Holder> GetOrderByHolder(string connection, string sort, string element)
        {
            string GetHolder = null;
            if (sort.Equals("Ascending"))
            {
                GetHolder = "SELECT * FROM Holder ORDER BY " + element + ";";
            }

            if (sort.Equals("Descending"))
            {
                GetHolder = "SELECT * FROM Holder ORDER BY " + element + " DESC;";
            }

            var holders = new ObservableCollection<Holder>();
            try
            {
                using (var connect = new SqlConnection(connection))
                {
                    connect.Open();
                    if (connect.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = connect.CreateCommand())
                        {
                            cmd.CommandText = GetHolder;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var holder = new Holder()
                                    {
                                        Id = reader.GetInt32(0),
                                        LastName = reader.GetString(1),
                                        FirstName = reader.GetString(2),
                                        MiddleName = reader.GetString(3),
                                        Status = reader.GetString(4)
                                    };
                                    holders.Add(holder);
                                }
                            }
                        }
                    }
                }
                return holders;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql);
            }
            return null;
        }
        public ObservableCollection<User> GetOrderByUser(string connection, string sort, string element)
        {
            string GetUser = null;
            if (sort.Equals("Ascending"))
            {
                GetUser = "SELECT * FROM UserDevice ORDER BY " + element + ";";
            }

            if (sort.Equals("Descending"))
            {
                GetUser = "SELECT * FROM UserDevice ORDER BY " + element + " DESC;";
            }

            var users = new ObservableCollection<User>();
            try
            {
                using (var connect = new SqlConnection(connection))
                {
                    connect.Open();
                    if (connect.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = connect.CreateCommand())
                        {
                            cmd.CommandText = GetUser;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var user = new User()
                                    {
                                        Id = reader.GetInt32(0),
                                        LastName = reader.GetString(1),
                                        FirstName = reader.GetString(2),
                                        MiddleName = reader.GetString(3),
                                        Status = reader.GetString(4)
                                    };
                                    users.Add(user);
                                }
                            }
                        }
                    }
                }
                return users;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql);
            }
            return null;
        }
        public ObservableCollection<Cartridge> GetOrderByCartridges(string connection, string sort, string element)
        {
            string GetCartridgeQuery = null;
            if (sort.Equals("Ascending"))
            {
                GetCartridgeQuery = "SELECT * FROM Cartrides ORDER BY " + element + ";";
            }

            if (sort.Equals("Descending"))
            {
                GetCartridgeQuery = "SELECT * FROM Cartrides ORDER BY " + element + " DESC;";
            }


            ObservableCollection<Cartridge> cartridges = new ObservableCollection<Cartridge>();
            try
            {
                using (SqlConnection connect = new SqlConnection(connection))
                {
                    connect.Open();
                    if (connect.State == System.Data.ConnectionState.Open)
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
        public ObservableCollection<CashRegister> GetOrderByCashRegister(string connection, string sort, string element)
        {

            string GetCashRegister = null;
            if (sort.Equals("Ascending"))
            {
                if (element.Equals("holder"))
                {
                    GetCashRegister = "SELECT dbo.CashRegister.id, " +
                   "dbo.CashRegister.name, " +
                   "dbo.CashRegister.brand, " +
                   "dbo.CashRegister.factory_number, " +
                   "dbo.CashRegister.serial_number, " +
                   "dbo.CashRegister.payment_number, " +
                   "dbo.CashRegister.date_reception, " +
                   "dbo.CashRegister.location, " +
                   "dbo.CashRegister.id_holder," +
                   "dbo.CashRegister.id_user," +
                   "dbo.Holder.last_name, " +
                   "dbo.Holder.first_name, " +
                   "dbo.Holder.middle_name, " +
                   "dbo.UserDevice.last_name, " +
                   "dbo.UserDevice.first_name, " +
                   "dbo.UserDevice.middle_name " +
                   "FROM dbo.CashRegister " +
                   "INNER JOIN dbo.Holder ON dbo.Holder.id = dbo.CashRegister.id_holder " +
                   "INNER JOIN dbo.UserDevice ON dbo.UserDevice.id = dbo.CashRegister.id_user " +
                   "ORDER BY dbo.Holder.last_name;";
                } else if (element.Equals("user"))
                {
                    GetCashRegister = "SELECT dbo.CashRegister.id, " +
                                       "dbo.CashRegister.name, " +
                                       "dbo.CashRegister.brand, " +
                                       "dbo.CashRegister.factory_number, " +
                                       "dbo.CashRegister.serial_number, " +
                                       "dbo.CashRegister.payment_number, " +
                                       "dbo.CashRegister.date_reception, " +
                                       "dbo.CashRegister.location, " +
                                       "dbo.CashRegister.id_holder," +
                                       "dbo.CashRegister.id_user," +
                                       "dbo.Holder.last_name, " +
                                       "dbo.Holder.first_name, " +
                                       "dbo.Holder.middle_name, " +
                                       "dbo.UserDevice.last_name, " +
                                       "dbo.UserDevice.first_name, " +
                                       "dbo.UserDevice.middle_name " +
                                       "FROM dbo.CashRegister " +
                                       "INNER JOIN dbo.Holder ON dbo.Holder.id = dbo.CashRegister.id_holder " +
                                       "INNER JOIN dbo.UserDevice ON dbo.UserDevice.id = dbo.CashRegister.id_user " +
                                       "ORDER BY dbo.UserDevice.last_name;";
                }
                else
                {
                    GetCashRegister = "SELECT dbo.CashRegister.id, " +
                                       "dbo.CashRegister.name, " +
                                       "dbo.CashRegister.brand, " +
                                       "dbo.CashRegister.factory_number, " +
                                       "dbo.CashRegister.serial_number, " +
                                       "dbo.CashRegister.payment_number, " +
                                       "dbo.CashRegister.date_reception, " +
                                       "dbo.CashRegister.location, " +
                                       "dbo.CashRegister.id_holder," +
                                       "dbo.CashRegister.id_user," +
                                       "dbo.Holder.last_name, " +
                                       "dbo.Holder.first_name, " +
                                       "dbo.Holder.middle_name, " +
                                       "dbo.UserDevice.last_name, " +
                                       "dbo.UserDevice.first_name, " +
                                       "dbo.UserDevice.middle_name " +
                                       "FROM dbo.CashRegister " +
                                       "INNER JOIN dbo.Holder ON dbo.Holder.id = dbo.CashRegister.id_holder " +
                                       "INNER JOIN dbo.UserDevice ON dbo.UserDevice.id = dbo.CashRegister.id_user " +
                                       "ORDER BY " + element + ";";
                }
               
            }

            if (sort.Equals("Descending"))
            {
                if (element.Equals("holder"))
                {
                    GetCashRegister = "SELECT dbo.CashRegister.id, " +
                   "dbo.CashRegister.name, " +
                   "dbo.CashRegister.brand, " +
                   "dbo.CashRegister.factory_number, " +
                   "dbo.CashRegister.serial_number, " +
                   "dbo.CashRegister.payment_number, " +
                   "dbo.CashRegister.date_reception, " +
                   "dbo.CashRegister.location, " +
                   "dbo.CashRegister.id_holder," +
                   "dbo.CashRegister.id_user," +
                   "dbo.Holder.last_name, " +
                   "dbo.Holder.first_name, " +
                   "dbo.Holder.middle_name, " +
                   "dbo.UserDevice.last_name, " +
                   "dbo.UserDevice.first_name, " +
                   "dbo.UserDevice.middle_name " +
                   "FROM dbo.CashRegister " +
                   "INNER JOIN dbo.Holder ON dbo.Holder.id = dbo.CashRegister.id_holder " +
                   "INNER JOIN dbo.UserDevice ON dbo.UserDevice.id = dbo.CashRegister.id_user " +
                   "ORDER BY dbo.Holder.last_name DESC;";
                }
                else if (element.Equals("user"))
                {
                    GetCashRegister = "SELECT dbo.CashRegister.id, " +
                                       "dbo.CashRegister.name, " +
                                       "dbo.CashRegister.brand, " +
                                       "dbo.CashRegister.factory_number, " +
                                       "dbo.CashRegister.serial_number, " +
                                       "dbo.CashRegister.payment_number, " +
                                       "dbo.CashRegister.date_reception, " +
                                       "dbo.CashRegister.location, " +
                                       "dbo.CashRegister.id_holder," +
                                       "dbo.CashRegister.id_user," +
                                       "dbo.Holder.last_name, " +
                                       "dbo.Holder.first_name, " +
                                       "dbo.Holder.middle_name, " +
                                       "dbo.UserDevice.last_name, " +
                                       "dbo.UserDevice.first_name, " +
                                       "dbo.UserDevice.middle_name " +
                                       "FROM dbo.CashRegister " +
                                       "INNER JOIN dbo.Holder ON dbo.Holder.id = dbo.CashRegister.id_holder " +
                                       "INNER JOIN dbo.UserDevice ON dbo.UserDevice.id = dbo.CashRegister.id_user " +
                                       "ORDER BY dbo.UserDevice.last_name DESC;";
                }
                else
                {
                    GetCashRegister = "SELECT dbo.CashRegister.id, " +
                                       "dbo.CashRegister.name, " +
                                       "dbo.CashRegister.brand, " +
                                       "dbo.CashRegister.factory_number, " +
                                       "dbo.CashRegister.serial_number, " +
                                       "dbo.CashRegister.payment_number, " +
                                       "dbo.CashRegister.date_reception, " +
                                       "dbo.CashRegister.location, " +
                                       "dbo.CashRegister.id_holder," +
                                       "dbo.CashRegister.id_user," +
                                       "dbo.Holder.last_name, " +
                                       "dbo.Holder.first_name, " +
                                       "dbo.Holder.middle_name, " +
                                       "dbo.UserDevice.last_name, " +
                                       "dbo.UserDevice.first_name, " +
                                       "dbo.UserDevice.middle_name " +
                                       "FROM dbo.CashRegister " +
                                       "INNER JOIN dbo.Holder ON dbo.Holder.id = dbo.CashRegister.id_holder " +
                                       "INNER JOIN dbo.UserDevice ON dbo.UserDevice.id = dbo.CashRegister.id_user " +
                                       "ORDER BY " + element + " DESC   ;";
                }
            }

            ObservableCollection<CashRegister> cashRegisters = new ObservableCollection<CashRegister>();
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
                                    var cashRegister = new CashRegister();
                                    cashRegister.Id = reader.GetInt32(0);
                                    cashRegister.NameDevice = reader.GetString(1);
                                    cashRegister.Brand = reader.GetString(2);
                                    cashRegister.FactoryNumber = reader.GetString(3);
                                    cashRegister.SerialNumber = reader.GetString(4);
                                    cashRegister.PaymentNumber = reader.GetString(5);
                                    cashRegister.DateReception = reader.GetDateTime(6);
                                    cashRegister.DateReceptionString = cashRegister.DateReception.ToShortDateString();
                                    cashRegister.Location = reader.GetString(7);
                                    cashRegister.IdHolder = reader.GetInt32(8);
                                    cashRegister.IdUser = reader.GetInt32(9);
                                    cashRegister.Holder = reader.GetString(10) + " " + reader.GetString(11) + " " + reader.GetString(12);
                                    cashRegister.User = reader.GetString(13) + " " + reader.GetString(14) + " " + reader.GetString(15);
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
        public ObservableCollection<PhoneBook> GetOrderByPhoneBook(string connection, string sort, string element)
        {
            string GetPhoneBook = null; ;
            if (sort.Equals("Ascending"))
            {
                GetPhoneBook = "SELECT * FROM PhoneBook ORDER BY " + element + ";";
            }

            if (sort.Equals("Descending"))
            {
                GetPhoneBook = "SELECT * FROM PhoneBook ORDER BY " + element + " DESC;";
            }

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
                            cmd.CommandText = GetPhoneBook;
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
                                        InternalNumber = Convert.ToString(reader.GetInt32(5)),
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
        public ObservableCollection<Printer> GetOrderByPrinter(string connection, string sort, string element)
        {
            string GetPrinter = null;
            if (sort.Equals("Ascending"))
            {
                GetPrinter = "SELECT * FROM Printer ORDER BY " + element + ";";
            }

            if (sort.Equals("Descending"))
            {
                GetPrinter = "SELECT * FROM Printer ORDER BY " + element + " DESC;";
            }

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
                                        ModelPrinter = reader.GetString(1),
                                        NamePort = reader.GetString(2),
                                        LocationPrinter = reader.GetString(3),
                                        OC = reader.GetString(4),
                                        Status = reader.GetString(5)
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
        public ObservableCollection<SimCard> GetOrderBySimCard(string connection, string sort, string element)
        {
            string GetSimCard = null;
            if (sort.Equals("Ascending"))
            {
                GetSimCard = "SELECT dbo.SimCard.id, " +
                   "dbo.CashRegister.name, " +
                   "dbo.SimCard.operator, " +
                   "dbo.SimCard.identifaction_number, " +
                   "dbo.CashRegister.brand, " +
                   "dbo.SimCard.type_device, " +
                   "dbo.SimCard.tms, " +
                   "dbo.SimCard.icc, dbo.SimCard.status, " +
                   "dbo.SimCard.id_individual_entrepreneur, " +
                   "dbo.IndividualEntrepreneur.last_name, " +
                   "dbo.IndividualEntrepreneur.first_name, " +
                   "dbo.IndividualEntrepreneur.middle_name " +
                   "FROM dbo.SimCard " +
                   "INNER JOIN dbo.IndividualEntrepreneur ON dbo.IndividualEntrepreneur.id = dbo.SimCard.id_individual_entrepreneur " +
                   "INNER JOIN dbo.CashRegister ON dbo.CashRegister.id = dbo.Simcard.id_cashRegister " +
                   "ORDER BY " + element + ";";
            }

            if (sort.Equals("Descending"))
            {
                GetSimCard = "SELECT dbo.SimCard.id, " +
                   "dbo.CashRegister.name, " +
                   "dbo.SimCard.operator, " +
                   "dbo.SimCard.identifaction_number, " +
                   "dbo.CashRegister.brand, " +
                   "dbo.SimCard.type_device, " +
                   "dbo.SimCard.tms, " +
                   "dbo.SimCard.icc, dbo.SimCard.status, " +
                   "dbo.SimCard.id_individual_entrepreneur, " +
                   "dbo.IndividualEntrepreneur.last_name, " +
                   "dbo.IndividualEntrepreneur.first_name, " +
                   "dbo.IndividualEntrepreneur.middle_name " +
                   "FROM dbo.SimCard " +
                   "INNER JOIN dbo.IndividualEntrepreneur ON dbo.IndividualEntrepreneur.id = dbo.SimCard.id_individual_entrepreneur " +
                   "INNER JOIN dbo.CashRegister ON dbo.CashRegister.id = dbo.Simcard.id_cashRegister " +
                   "ORDER BY " + element + " DESC;";
            }

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
                                    var simcard = new SimCard
                                    {
                                        Id = reader.GetInt32(0),
                                        NameTerminal = reader.GetInt32(1),
                                        Operator = reader.GetString(2),
                                        IdentNumber = reader.GetString(3),
                                        Brand = reader.GetString(4),
                                        TypeDevice = reader.GetString(5),
                                        TMS = reader.GetString(6),
                                        ICC = reader.GetString(7),
                                        Status = reader.GetString(8),
                                        IdIndividual = reader.GetInt32(7),
                                        IdCashRegister = reader.GetInt32(8),
                                        IndividualEntrepreneur = reader.GetString(9) + " " + reader.GetString(10) + " " + reader.GetString(11)
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
        public ObservableCollection<IndividualEntrepreneur> GetOrderByIndividual(string connection, string sort, string element)
        {
            string GetIndividual = null;
            if (sort.Equals("Ascending"))
            {
                GetIndividual = "SELECT * FROM IndividualEntrepreneur ORDER BY " + element + ";";
            }

            if (sort.Equals("Descending"))
            {
                GetIndividual = "SELECT * FROM IndividualEntrepreneur ORDER BY " + element + " DESC;";
            }

            var individuals = new ObservableCollection<IndividualEntrepreneur>();
            try
            {
                using (var connect = new SqlConnection(connection))
                {
                    connect.Open();
                    if (connect.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = connect.CreateCommand())
                        {
                            cmd.CommandText = GetIndividual;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    IndividualEntrepreneur individual = new IndividualEntrepreneur()
                                    {
                                        Id = reader.GetInt32(0),
                                        LastName = reader.GetString(1),
                                        FirstName = reader.GetString(2),
                                        MiddleName = reader.GetString(3),
                                        PSRNIE = reader.GetString(4),
                                        TIN = reader.GetString(5),
                                    };
                                    individuals.Add(individual);
                                }
                            }
                        }
                    }
                }
                return individuals;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql);
            }
            return null;
        }
    }
}
