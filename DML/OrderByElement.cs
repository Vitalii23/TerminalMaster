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
    }
}
