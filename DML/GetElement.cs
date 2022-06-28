﻿using System;
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
        public ObservableCollection<CashRegister> GetCashRegister(string connection, string selection, int id)
        {

            string GetCashRegister = null;
            if (selection.Equals("ALL"))
            {
                GetCashRegister = "SELECT * FROM CashRegister;";
            }

            if (selection.Equals("ONE"))
            {
                GetCashRegister = "SELECT * FROM CashRegister WHERE id = " + id;
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
                                    cashRegister.Name = reader.GetString(1);
                                    cashRegister.Brend = reader.GetString(2);
                                    cashRegister.FactoryNumber = reader.GetString(3);
                                    cashRegister.SerialNumber = reader.GetString(4);
                                    cashRegister.PaymentNumber = reader.GetString(5);
                                    cashRegister.DateReception = reader.GetDateTime(6);
                                    cashRegister.Location = reader.GetString(7);
                                    cashRegister.IdHolder = reader.GetInt32(8);
                                    cashRegister.IdUser = reader.GetInt32(9);
                                    cashRegisters.Add(cashRegister);
                                }
                            }

                           // GetCashRegister = "SELECT CONCAT(last_name, ' ', first_name, ' ', middle_name) AS фио FROM dbo.Holder WHERE id = " + cashRegister.IdHolder;
                            cmd.CommandText = GetCashRegister;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                   // cashRegister.Holder = reader.GetString(0);
                                   // cashRegisters.Add(cashRegister);
                                }
                            }

                          //  GetCashRegister = "SELECT CONCAT(last_name, ' ', first_name, ' ', middle_name) AS фио FROM dbo.UserDevice WHERE id = " + cashRegister.IdUser;
                            cmd.CommandText = GetCashRegister;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                   // cashRegister.User = reader.GetString(0);
                                 //   cashRegisters.Add(cashRegister);
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
                                        NameUser = reader.GetString(1),
                                        NamePrinter = reader.GetString(2),
                                        Model = reader.GetString(3),
                                        NamePort = reader.GetString(4),
                                        Location = reader.GetString(5),
                                        OC = reader.GetString(6),
                                        Status = reader.GetString(7)
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
        public ObservableCollection<SimCard> GetSimCard(string connection, string selection, int id)
        {
            string GetSimCard = null;
            if (selection.Equals("ALL"))
            {
                GetSimCard = "SELECT * FROM SimCard;";
            }

            if (selection.Equals("ONE"))
            {
                GetSimCard = "SELECT * FROM SimCard WHERE id = " + id;
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
                                        Operator = reader.GetString(1),
                                        IdentNumber = reader.GetString(2),
                                        Brend = reader.GetString(3),
                                        TypeDevice = reader.GetString(4),
                                        TMS = reader.GetString(5),
                                        ICC = reader.GetString(6),
                                        Status = reader.GetString(7),
                                        IdIndividual = reader.GetInt32(8)
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
                                    var individual = new IndividualEntrepreneur()
                                    {
                                        Id = reader.GetInt32(0),
                                        FirstName = reader.GetString(1),
                                        LastName = reader.GetString(2),
                                        MiddleName = reader.GetString(3),
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
                                        FirstName = reader.GetString(1),
                                        LastName = reader.GetString(2),
                                        MiddleName = reader.GetString(3),
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
                                        FirstName = reader.GetString(1),
                                        LastName = reader.GetString(2),
                                        MiddleName = reader.GetString(3),
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
