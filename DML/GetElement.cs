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
using Windows.UI.Popups;

namespace TerminalMaster.ViewModel
{
    class GetElement
    {
        public ObservableCollection<Cartridge> GetCartridges(string connection, string selection, int id)
        {
            string GetCartridgeQuery = null;
            if (selection.Equals("ALL"))
            {
                GetCartridgeQuery = "SELECT * FROM Cartrides;";
            }

            if (selection.Equals("ONE"))
            {
                GetCartridgeQuery = "SELECT * FROM Cartrides WHERE id = " + id;
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
        public ObservableCollection<CashRegister> GetCashRegister(string connection, string selection, int id)
        {

            string GetCashRegister = null;
            if (selection.Equals("ALL"))
            {
                GetCashRegister = "SELECT dbo.CashRegister.id, " +
                    "dbo.CashRegister.name, " +
                    "dbo.CashRegister.brand, " +
                    "dbo.CashRegister.factory_number, " +
                    "dbo.CashRegister.serial_number, " +
                    "dbo.CashRegister.payment_number, " +
                    "dbo.CashRegister.date_reception, " +
                    "dbo.CashRegister.date_end_fiscal_memory, " +
                    "dbo.CashRegister.date_key_activ_fisc_data, " +
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
                    "INNER JOIN dbo.UserDevice ON dbo.UserDevice.id = dbo.CashRegister.id_user;";
            }

            if (selection.Equals("ONE"))
            {
                GetCashRegister = "SELECT dbo.CashRegister.id, " +
                    "dbo.CashRegister.name, " +
                    "dbo.CashRegister.brand, " +
                    "dbo.CashRegister.factory_number, " +
                    "dbo.CashRegister.serial_number, " +
                    "dbo.CashRegister.payment_number, " +
                    "dbo.CashRegister.date_reception, " +
                    "dbo.CashRegister.date_key_activ_fisc_data, " +
                    "dbo.CashRegister.date_end_fiscal_memory, " +
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
                    "WHERE dbo.CashRegister.id =  " + id;
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
                                    cashRegister.DateEndFiscalMemory = reader.GetDateTime(7);
                                    cashRegister.DateEndFiscalMemoryString = cashRegister.DateEndFiscalMemory.ToShortDateString();
                                    cashRegister.DateKeyActivationFiscalDataOperator = reader.GetDateTime(8);
                                    cashRegister.DateKeyActivationFiscalDataOperatorString = cashRegister.DateKeyActivationFiscalDataOperator.ToShortDateString();
                                    cashRegister.Location = reader.GetString(9);
                                    cashRegister.IdHolder = reader.GetInt32(10);
                                    cashRegister.IdUser = reader.GetInt32(11);
                                    cashRegister.Holder = reader.GetString(12) + " " + reader.GetString(13) + " " + reader.GetString(14);
                                    cashRegister.User = reader.GetString(15) + " " + reader.GetString(16) + " " + reader.GetString(17);
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
        public ObservableCollection<PhoneBook> GetPhoneBook(string connection, string selection, int id)
        {
            string GetPhoneBook = null;
            if (selection.Equals("ALL"))
            {
                GetPhoneBook = "SELECT * FROM PhoneBook;";
            }

            if (selection.Equals("ONE"))
            {
                GetPhoneBook = "SELECT * FROM PhoneBook WHERE id = " + id;
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
        public ObservableCollection<Printer> GetPrinter(string connection, string selection, int id)
        {
            string GetPrinter = null;
            if (selection.Equals("ALL"))
            {
                GetPrinter = "SELECT * FROM Printer;";
            }

            if (selection.Equals("ONE"))
            {
                GetPrinter = "SELECT * FROM Printer WHERE id = " + id;
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
                                        BrandPrinter = reader.GetString(1),
                                        ModelPrinter = reader.GetString(2),
                                        Cartridge = reader.GetString(3),
                                        NamePort = reader.GetString(4),
                                        LocationPrinter = reader.GetString(5),
                                        OC = reader.GetString(6),
                                        Status = reader.GetString(7),
                                        VendorCodePrinter = reader.GetString(8),
                                        Сounters = reader.GetInt32(9),
                                        DatePrinter = reader.GetDateTime(10)
                                    };
                                    printer.DatePrinterString = printer.DatePrinter.ToShortDateString();
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
        public ObservableCollection<SimCard> GetSimCard(string connection, string selection, int id)
        {
            string GetSimCard = null;
            if (selection.Equals("ALL"))
            {
                GetSimCard = "SELECT dbo.SimCard.id, " +
                    "dbo.CashRegister.name, " +
                    "dbo.SimCard.operator, " +
                    "dbo.SimCard.identifaction_number, " +
                    "dbo.CashRegister.brand, " +
                    "dbo.SimCard.type_device, " +
                    "dbo.SimCard.tms, " +
                    "dbo.SimCard.icc, " +
                    "dbo.SimCard.status, " +
                    "dbo.SimCard.id_individual_entrepreneur, " +
                    "dbo.SimCard.id_cashRegister, " +
                    "dbo.IndividualEntrepreneur.last_name, " +
                    "dbo.IndividualEntrepreneur.first_name, " +
                    "dbo.IndividualEntrepreneur.middle_name " +
                    "FROM dbo.SimCard " +
                    "INNER JOIN dbo.IndividualEntrepreneur ON dbo.IndividualEntrepreneur.id = dbo.SimCard.id_individual_entrepreneur " +
                    "INNER JOIN dbo.CashRegister ON dbo.CashRegister.id = dbo.Simcard.id_cashRegister;";
            }

            if (selection.Equals("ONE"))
            {
                GetSimCard = "SELECT dbo.SimCard.id, " +
                  "dbo.CashRegister.name, " +
                  "dbo.SimCard.operator, " +
                  "dbo.SimCard.identifaction_number, " +
                  "dbo.CashRegister.brand, " +
                  "dbo.SimCard.type_device, " +
                  "dbo.SimCard.tms, " +
                  "dbo.SimCard.icc, " +
                  "dbo.SimCard.status, " +
                  "dbo.SimCard.id_individual_entrepreneur, " +
                  "dbo.SimCard.id_cashRegister, " +
                  "dbo.IndividualEntrepreneur.last_name, " +
                  "dbo.IndividualEntrepreneur.first_name, " +
                  "dbo.IndividualEntrepreneur.middle_name " +
                  "FROM dbo.SimCard " +
                  "INNER JOIN dbo.IndividualEntrepreneur ON dbo.IndividualEntrepreneur.id = dbo.SimCard.id_individual_entrepreneur " +
                  "INNER JOIN dbo.CashRegister ON dbo.CashRegister.id = dbo.Simcard.id_cashRegister " +
                  "WHERE dbo.SimCard.id = " + id;
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
                                    var simcard = new SimCard();
                                    simcard.Id = reader.GetInt32(0);
                                    simcard.NameTerminal = reader.GetString(1);
                                    simcard.Operator = reader.GetString(2);
                                    simcard.IdentNumber = reader.GetString(3);
                                    simcard.Brand = reader.GetString(4);
                                    simcard.TypeDevice = reader.GetString(5);
                                    simcard.TMS = reader.GetString(6);
                                    simcard.ICC = reader.GetString(7);
                                    simcard.Status = reader.GetString(8);
                                    simcard.IdIndividual = reader.GetInt32(9);
                                    simcard.IdCashRegister = reader.GetInt32(10);
                                    simcard.IndividualEntrepreneur = reader.GetString(11) + " " + reader.GetString(12) + " " + reader.GetString(13);
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
        public ObservableCollection<IndividualEntrepreneur> GetIndividual(string connection, string selection, int id)
        {
            string GetIndividual = null;
            if (selection.Equals("ALL"))
            {
                GetIndividual = "SELECT * FROM IndividualEntrepreneur;";
            }

            if (selection.Equals("ONE"))
            {
                GetIndividual = "SELECT * FROM IndividualEntrepreneur WHERE id = " + id;
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
        public ObservableCollection<Holder> GetHolder(string connection, string selection, int id)
        {
            string GetHolder = null;
            if (selection.Equals("ALL"))
            {
                GetHolder = "SELECT * FROM Holder;";
            }

            if (selection.Equals("ONE"))
            {
                GetHolder = "SELECT * FROM Holder WHERE id = " + id;
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
                                        Number = reader.GetString(4),
                                        Status = reader.GetString(5)
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
        public ObservableCollection<User> GetUser(string connection, string selection, int id)
        {
            string GetUser = null;
            if (selection.Equals("ALL"))
            {
                GetUser = "SELECT * FROM UserDevice;";
            }

            if (selection.Equals("ONE"))
            {
                GetUser = "SELECT * FROM UserDevice WHERE id = " + id;
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
                                        Number = reader.GetString(4),
                                        Status = reader.GetString(5)
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
    }
}
