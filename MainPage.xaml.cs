using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TerminalMaster.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using TerminalMaster.ElementContentDialog;
using TerminalMaster.ElementContentDialog.PeopleContentDialog;
using TerminalMaster.Model;
using Windows.UI.Popups;
using System.Collections.ObjectModel;
using TerminalMaster.DML;
using TerminalMaster.Model.People;
using TerminalMaster.Logging;
using System.Runtime.Serialization.Formatters.Binary;
using Windows.Storage;
using System.Threading.Tasks;
using TerminalMaster.Settings;

namespace TerminalMaster
{
    public sealed partial class MainPage : Page
    {
        private string NameNavigationItem;
        private readonly DataGets dataGets = new DataGets();
        private GetElement Get = new GetElement();
        private DeleteElement Delete = new DeleteElement();
        private OrderByElement Order = new OrderByElement();
        private ConnectSQL connect = new ConnectSQL();
        private DataGridSortDirection? CheckSort;
        private bool triggerSort = true, triggerHeader, triggerPropertyNameList;
        private Dictionary<string, string> PropertyNameDictionary;
        private LogFile logFile = new LogFile();
        public MainPage()
        {
            InitializeComponent();
            connect.ConnectRead();
        }
        private async void UpdateTable(string items)
        {
            try
            {
                switch (items)
                {
                    case "printer":
                        MainDataGrid.ItemsSource = dataGets.PrinterList;
                        break;
                    case "cartrides":
                        MainDataGrid.ItemsSource = dataGets.CartridgesList;
                        break;
                    case "cashRegister":
                        MainDataGrid.ItemsSource = dataGets.CashRegisterList;
                        break;
                    case "simCard":
                        MainDataGrid.ItemsSource = dataGets.SimCardList;
                        break;
                    case "phoneBook":
                        MainDataGrid.ItemsSource = dataGets.PhoneBookList;
                        break;
                    case "holder":
                        MainDataGrid.ItemsSource = dataGets.HolderList;
                        break;
                    case "user":
                        MainDataGrid.ItemsSource = dataGets.UserList;
                        break;
                    case "ie":
                        MainDataGrid.ItemsSource = dataGets.IndividualEntrepreneurList;
                        break;
                    case "waybill":
                        MainDataGrid.ItemsSource = dataGets.WaybillList;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "UpdateTable");
            }
        }
        public void AddComboxItem(List<string> text, ComboBox combo)
        {
            for (int i = 0; i < text.Count; i++)
            {
                combo.Items.Add(text[i]);
            }
        }
        private static async Task<StorageFile> AsStorageFile(byte[] data, string fileName)
        {
            StorageFolder storageFolder = KnownFolders.DocumentsLibrary;
            StorageFile sampleFile = await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteBytesAsync(sampleFile, data);
            await new MessageDialog("Файл успешно скачан").ShowAsync();
            return sampleFile;
        }
        /// <summary>
        /// Taped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            AppBarButtonDowloand.IsEnabled = false;

            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
            NameNavigationItem = "printer";
            triggerSort = true;

            dataGets.PrinterList = Get.GetPrinter((App.Current as App).ConnectionString, "ALL", 0);

            UpdateTable(NameNavigationItem);
        }
        private void CartridesNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            AppBarButtonDowloand.IsEnabled = false;

            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
            NameNavigationItem = "cartrides";
            triggerSort = true;

            dataGets.CartridgesList = Get.GetCartridges((App.Current as App).ConnectionString, "ALL", 0);

            UpdateTable(NameNavigationItem);
        }
        private void CashRegystriNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            AppBarButtonDowloand.IsEnabled = false;

            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
            NameNavigationItem = "cashRegister";
            triggerSort = true;

            dataGets.CashRegisterList = Get.GetCashRegister((App.Current as App).ConnectionString, "ALL", 0);

            UpdateTable(NameNavigationItem);
        }
        private void SimCardRegystriNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            AppBarButtonDowloand.IsEnabled = false;

            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();

            dataGets.SimCardList = Get.GetSimCard((App.Current as App).ConnectionString, "ALL", 0);

            NameNavigationItem = "simCard";
            triggerSort = true;
            UpdateTable(NameNavigationItem);
        }
        private void PhoneBookNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            AppBarButtonDowloand.IsEnabled = false;

            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
            NameNavigationItem = "phoneBook";
            triggerSort = true;

            dataGets.PhoneBookList = Get.GetPhoneBook((App.Current as App).ConnectionString, "ALL", 0); ;

            UpdateTable(NameNavigationItem);
        }
        private void HolderNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            AppBarButtonDowloand.IsEnabled = false;

            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
            NameNavigationItem = "holder";
            triggerSort = true;

            dataGets.HolderList = Get.GetHolder((App.Current as App).ConnectionString, "ALL", 0);

            UpdateTable(NameNavigationItem);
        }
        private void UserNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            AppBarButtonDowloand.IsEnabled = false;

            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
            NameNavigationItem = "user";
            triggerSort = true;

            dataGets.UserList = Get.GetUser((App.Current as App).ConnectionString, "ALL", 0);

            UpdateTable(NameNavigationItem);
        }
        private void IndividualEntrepreneurNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            AppBarButtonDowloand.IsEnabled = false;

            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();

            NameNavigationItem = "ie";
            triggerSort = true;

            dataGets.IndividualEntrepreneurList = Get.GetIndividual((App.Current as App).ConnectionString, "ALL", 0);

            UpdateTable(NameNavigationItem);
        }
        private void WaybillNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            AppBarButtonDowloand.IsEnabled = true;

            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();

            NameNavigationItem = "waybill";
            triggerSort = true;

            dataGets.WaybillList = Get.GetWaybill((App.Current as App).ConnectionString, "ALL", 0);

            UpdateTable(NameNavigationItem);
        }
        private async void ConnectNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                triggerPropertyNameList = false;
                triggerHeader = false;
                ConnectContentDialog connect = new ConnectContentDialog();
                await connect.ShowAsync();
            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "ConnectNavigationItem_Tapped");
            }
        }
        private async void AppBarButtonAdd_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                triggerPropertyNameList = false;
                triggerHeader = false;
                switch (NameNavigationItem)
                {
                    case "printer":
                        PrinterContentDialog printer = new PrinterContentDialog
                        {
                            SelectData = "ADD"
                        };
                        await printer.ShowAsync();
                        UpdateTable(NameNavigationItem);
                        break;
                    case "cartrides":
                        CartridgeContentDialog cartridge = new CartridgeContentDialog
                        {
                            SelectData = "ADD"
                        };
                        await cartridge.ShowAsync();
                        UpdateTable(NameNavigationItem);
                        break;
                    case "cashRegister":
                        CashRegisterContentDialog cashRegister = new CashRegisterContentDialog
                        {
                            SelectData = "ADD"
                        };
                        await cashRegister.ShowAsync();
                        UpdateTable(NameNavigationItem);
                        break;
                    case "simCard":
                        SimCardContentDialog simCard = new SimCardContentDialog
                        {
                            SelectData = "ADD"
                        };
                        await simCard.ShowAsync();
                        UpdateTable(NameNavigationItem);
                        break;
                    case "phoneBook":
                        PhoneBookContentDialog phoneBook = new PhoneBookContentDialog
                        {
                            SelectData = "ADD"
                        };
                        await phoneBook.ShowAsync();
                        UpdateTable(NameNavigationItem);
                        break;
                    case "holder":
                        PeopleContentDialog holder = new PeopleContentDialog
                        {
                            SelectData = "ADD",
                            People = NameNavigationItem
                        };
                        await holder.ShowAsync();
                        UpdateTable(NameNavigationItem);
                        break;
                    case "user":
                        PeopleContentDialog user = new PeopleContentDialog
                        {
                            SelectData = "ADD",
                            People = NameNavigationItem
                        };
                        await user.ShowAsync();
                        UpdateTable(NameNavigationItem);
                        break;
                    case "ie":
                        indContentDialog individual = new indContentDialog
                        {
                            SelectData = "ADD",
                            People = NameNavigationItem
                        };
                        await individual.ShowAsync();
                        UpdateTable(NameNavigationItem);
                        break;
                    case "waybill":
                        WaybillContentDialog waybill = new WaybillContentDialog
                        {
                            SelectData = "ADD"
                        };
                        await waybill.ShowAsync();
                        UpdateTable(NameNavigationItem);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "AppBarButtonAdd_Tapped");
            }

        }
        private async void AppBarButtonEdit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                triggerPropertyNameList = false;
                triggerHeader = false;
                switch (NameNavigationItem)
                {
                    case "printer":
                        if (MainDataGrid.SelectedIndex >= 0)
                        {
                            PrinterContentDialog printer = new PrinterContentDialog
                            {
                                SelectData = "GET",
                                SelectIndex = MainDataGrid.SelectedIndex,
                                SelectId = dataGets.PrinterList[MainDataGrid.SelectedIndex].Id,
                                SelectPrinter = dataGets.PrinterList
                            };
                            await printer.ShowAsync();
                            UpdateTable(NameNavigationItem);
                        }
                        else
                        {
                            await new MessageDialog("Выберите строку для изменения").ShowAsync();
                        }
                        break;
                    case "cartrides":
                        if (MainDataGrid.SelectedIndex >= 0)
                        {
                            CartridgeContentDialog cartridge = new CartridgeContentDialog
                            {
                                SelectData = "GET",
                                SelectIndex = MainDataGrid.SelectedIndex,
                                SelectId = dataGets.CartridgesList[MainDataGrid.SelectedIndex].Id,
                                SelectCartrides = dataGets.CartridgesList
                            };
                            await cartridge.ShowAsync();
                            UpdateTable(NameNavigationItem);
                        }
                        else
                        {
                            await new MessageDialog("Выберите строку для изменения").ShowAsync();
                        }
                        break;
                    case "cashRegister":
                        if (MainDataGrid.SelectedIndex >= 0)
                        {
                            CashRegisterContentDialog cashRegister = new CashRegisterContentDialog
                            {
                                SelectData = "GET",
                                SelectIndex = MainDataGrid.SelectedIndex,
                                SelectId = dataGets.CashRegisterList[MainDataGrid.SelectedIndex].Id,
                                SelectCashRegister = dataGets.CashRegisterList
                            };
                            await cashRegister.ShowAsync();
                            UpdateTable(NameNavigationItem);
                        }
                        else
                        {
                            await new MessageDialog("Выберите строку для изменения").ShowAsync();
                        }
                        break;
                    case "simCard":
                        if (MainDataGrid.SelectedIndex >= 0)
                        {
                            SimCardContentDialog simCard = new SimCardContentDialog
                            {
                                SelectData = "GET",
                                SelectIndex = MainDataGrid.SelectedIndex,
                                SelectId = dataGets.SimCardList[MainDataGrid.SelectedIndex].Id,
                                SelectSimCard = dataGets.SimCardList
                            };
                            await simCard.ShowAsync();
                            UpdateTable(NameNavigationItem);
                        }
                        else
                        {
                            await new MessageDialog("Выберите строку для изменения").ShowAsync();
                        }
                        break;
                    case "phoneBook":

                        if (MainDataGrid.SelectedIndex >= 0)
                        {
                            PhoneBookContentDialog phoneBook = new PhoneBookContentDialog
                            {
                                SelectData = "GET",
                                SelectIndex = MainDataGrid.SelectedIndex,
                                SelectId = dataGets.PhoneBookList[MainDataGrid.SelectedIndex].Id,
                                SelectPhoneBook = dataGets.PhoneBookList
                            };
                            await phoneBook.ShowAsync();
                            UpdateTable(NameNavigationItem);
                        }
                        else
                        {
                            await new MessageDialog("Выберите строку для изменения").ShowAsync();
                        }
                        break;
                    case "holder":
                        if (MainDataGrid.SelectedIndex >= 0)
                        {
                            PeopleContentDialog holder = new PeopleContentDialog
                            {
                                SelectData = "GET",
                                SelectIndex = MainDataGrid.SelectedIndex,
                                SelectId = dataGets.HolderList[MainDataGrid.SelectedIndex].Id,
                                SelectHolder = dataGets.HolderList,
                                People = NameNavigationItem
                            };
                            await holder.ShowAsync();
                            UpdateTable(NameNavigationItem);
                        }
                        else
                        {
                            await new MessageDialog("Выберите строку для изменения").ShowAsync();
                        }
                        break;
                    case "user":
                        if (MainDataGrid.SelectedIndex >= 0)
                        {
                            PeopleContentDialog user = new PeopleContentDialog
                            {
                                SelectData = "GET",
                                SelectIndex = MainDataGrid.SelectedIndex,
                                SelectId = dataGets.UserList[MainDataGrid.SelectedIndex].Id,
                                SelectUser = dataGets.UserList,
                                People = NameNavigationItem
                            };
                            await user.ShowAsync();
                            UpdateTable(NameNavigationItem);
                        }
                        else
                        {
                            await new MessageDialog("Выберите строку для изменения").ShowAsync();
                        }
                        break;
                    case "ie":
                        if (MainDataGrid.SelectedIndex >= 0)
                        {
                            indContentDialog individual = new indContentDialog
                            {
                                SelectData = "GET",
                                SelectIndex = MainDataGrid.SelectedIndex,
                                SelectId = dataGets.IndividualEntrepreneurList[MainDataGrid.SelectedIndex].Id,
                                SelectInd = dataGets.IndividualEntrepreneurList,
                                People = NameNavigationItem
                            };
                            await individual.ShowAsync();
                            UpdateTable(NameNavigationItem);
                        }
                        else
                        {
                            await new MessageDialog("Выберите строку для изменения").ShowAsync();
                        }
                        break;
                    case "waybill":
                        if (MainDataGrid.SelectedIndex >= 0)
                        {
                            WaybillContentDialog waybill = new WaybillContentDialog
                            {
                                SelectData = "GET",
                                SelectIndex = MainDataGrid.SelectedIndex,
                                SelectId = dataGets.WaybillList[MainDataGrid.SelectedIndex].Id,
                                SelectWaybill = dataGets.WaybillList
                            };
                            await waybill.ShowAsync();
                            UpdateTable(NameNavigationItem);
                        }
                        else
                        {
                            await new MessageDialog("Выберите строку для изменения").ShowAsync();
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "AppBarButtonEdit_Tapped");
            }
        }
        private async void AppBarButtonDelete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                MessageDialog message;

                triggerPropertyNameList = false;
                triggerHeader = false;
                if (MainDataGrid.SelectedIndex >= 0)
                {
                    message = new MessageDialog("Вы точно хотите удалить этот элемент.");
                    message.Commands.Add(new UICommand("Да", null));
                    message.Commands.Add(new UICommand("Нет", null));
                    message.DefaultCommandIndex = 0;
                    message.CancelCommandIndex = 1;
                }
                else
                {
                    message = new MessageDialog("Выберите строку для удаления");
                }

                IUICommand cmd = await message.ShowAsync();
                switch (NameNavigationItem)
                {
                    case "printer":
                        if (cmd.Label == "Да")
                        {
                            Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.PrinterList[MainDataGrid.SelectedIndex].Id, NameNavigationItem);
                        }
                        UpdateTable(NameNavigationItem);
                        break;
                    case "cartrides":
                        if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.CartridgesList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                        UpdateTable(NameNavigationItem);
                        break;
                    case "cashRegister":
                        if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.CashRegisterList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                        UpdateTable(NameNavigationItem);
                        break;
                    case "simCard":
                        if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.SimCardList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                        UpdateTable(NameNavigationItem);
                        break;
                    case "phoneBook":
                        if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.PhoneBookList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                        UpdateTable(NameNavigationItem);
                        break;
                    case "holder":
                        if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.HolderList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                        UpdateTable(NameNavigationItem);
                        break;
                    case "user":
                        if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.UserList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                        UpdateTable(NameNavigationItem);
                        break;
                    case "ie":
                        if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.IndividualEntrepreneurList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                        UpdateTable(NameNavigationItem);
                        break;
                    case "waybill":
                        if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.WaybillList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                        UpdateTable(NameNavigationItem);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "AppBarButtonDelete_Tapped");
            }

        }
        private async void AppBarButtonUpdate_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                triggerPropertyNameList = false;
                triggerHeader = false;
                switch (NameNavigationItem)
                {
                    case "printer":
                        MainDataGrid.ItemsSource = Get.GetPrinter((App.Current as App).ConnectionString, "ALL", 0);
                        break;
                    case "cartrides":
                        MainDataGrid.ItemsSource = Get.GetCartridges((App.Current as App).ConnectionString, "ALL", 0);
                        break;
                    case "cashRegister":
                        MainDataGrid.ItemsSource = Get.GetCashRegister((App.Current as App).ConnectionString, "ALL", 0);
                        break;
                    case "simCard":
                        MainDataGrid.ItemsSource = Get.GetSimCard((App.Current as App).ConnectionString, "ALL", 0);
                        break;
                    case "phoneBook":
                        MainDataGrid.ItemsSource = Get.GetPhoneBook((App.Current as App).ConnectionString, "ALL", 0);
                        break;
                    case "holder":
                        MainDataGrid.ItemsSource = Get.GetHolder((App.Current as App).ConnectionString, "ALL", 0);
                        break;
                    case "user":
                        MainDataGrid.ItemsSource = Get.GetUser((App.Current as App).ConnectionString, "ALL", 0);
                        break;
                    case "ie":
                        MainDataGrid.ItemsSource = Get.GetIndividual((App.Current as App).ConnectionString, "ALL", 0);
                        break;
                    case "waybill":
                        MainDataGrid.ItemsSource = Get.GetWaybill((App.Current as App).ConnectionString, "ALL", 0);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "AppBarButtonUpdate_Tapped");
            }
        }
        private async void AppBarButtonDowloand_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                triggerPropertyNameList = false;
                triggerHeader = false;

                if (MainDataGrid.SelectedIndex >= 0)
                {
                    BinaryFormatter binaryformatter = new BinaryFormatter();
                    MemoryStream memorystream = new MemoryStream();
                    binaryformatter.Serialize(memorystream, dataGets.WaybillList[MainDataGrid.SelectedIndex].FilePDF);
                    byte[] data = memorystream.ToArray();
                    await AsStorageFile(data, dataGets.WaybillList[MainDataGrid.SelectedIndex].FileName);

                }
                else
                {
                    await new MessageDialog("Выберите строку для скачивания").ShowAsync();
                }

            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "AppBarButtonDowloand_Tapped");
            }
        }
        private async void MainDataGrid_Sorting(object sender, DataGridColumnEventArgs e)
        {
            try
            {
                if (triggerSort)
                {
                    CheckSort = e.Column.SortDirection;
                    triggerSort = false;
                }

                triggerPropertyNameList = false;
                triggerHeader = false;

                switch (NameNavigationItem)
                {
                    case "printer":
                        if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                        {
                            CheckSort = DataGridSortDirection.Ascending;
                            dataGets.PrinterList.Clear();
                            dataGets.PrinterList = Order.GetOrderByPrinter((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.PrinterList;
                        }
                        else
                        {
                            CheckSort = DataGridSortDirection.Descending;
                            dataGets.PrinterList.Clear();
                            dataGets.PrinterList = Order.GetOrderByPrinter((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.PrinterList;
                        }
                        break;
                    case "cartrides":
                        if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                        {
                            CheckSort = DataGridSortDirection.Ascending;
                            dataGets.CartridgesList.Clear();
                            dataGets.CartridgesList = Order.GetOrderByCartridges((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.CartridgesList;
                        }
                        else
                        {
                            CheckSort = DataGridSortDirection.Descending;
                            dataGets.CartridgesList.Clear();
                            dataGets.CartridgesList = Order.GetOrderByCartridges((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.CartridgesList;
                        }
                        break;
                    case "cashRegister":
                        if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                        {
                            CheckSort = DataGridSortDirection.Ascending;
                            dataGets.CashRegisterList.Clear();
                            dataGets.CashRegisterList = Order.GetOrderByCashRegister((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.CashRegisterList;
                        }
                        else
                        {
                            CheckSort = DataGridSortDirection.Descending;
                            dataGets.CashRegisterList.Clear();
                            dataGets.CashRegisterList = Order.GetOrderByCashRegister((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.CashRegisterList;
                        }
                        break;
                    case "simCard":
                        if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                        {
                            CheckSort = DataGridSortDirection.Ascending;
                            dataGets.SimCardList.Clear();
                            dataGets.SimCardList = Order.GetOrderBySimCard((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.SimCardList;
                        }
                        else
                        {
                            CheckSort = DataGridSortDirection.Descending;
                            dataGets.SimCardList.Clear();
                            dataGets.SimCardList = Order.GetOrderBySimCard((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.SimCardList;
                        }
                        break;
                    case "phoneBook":
                        if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                        {
                            CheckSort = DataGridSortDirection.Ascending;
                            dataGets.PhoneBookList.Clear();
                            dataGets.PhoneBookList = Order.GetOrderByPhoneBook((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.PhoneBookList;
                        }
                        else
                        {
                            CheckSort = DataGridSortDirection.Descending;
                            dataGets.PhoneBookList.Clear();
                            dataGets.PhoneBookList = Order.GetOrderByPhoneBook((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.PhoneBookList;
                        }
                        break;
                    case "holder":
                        if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                        {
                            CheckSort = DataGridSortDirection.Ascending;
                            dataGets.HolderList.Clear();
                            dataGets.HolderList = Order.GetOrderByHolder((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.HolderList;
                        }
                        else
                        {
                            CheckSort = DataGridSortDirection.Descending;
                            dataGets.HolderList.Clear();
                            dataGets.HolderList = Order.GetOrderByHolder((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.HolderList;
                        }
                        break;
                    case "user":
                        if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                        {
                            CheckSort = DataGridSortDirection.Ascending;
                            dataGets.UserList.Clear();
                            dataGets.UserList = Order.GetOrderByUser((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.UserList;
                        }
                        else
                        {
                            CheckSort = DataGridSortDirection.Descending;
                            dataGets.UserList.Clear();
                            dataGets.UserList = Order.GetOrderByUser((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.UserList;
                        }
                        break;
                    case "ie":
                        if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                        {
                            CheckSort = DataGridSortDirection.Ascending;
                            dataGets.IndividualEntrepreneurList.Clear();
                            dataGets.IndividualEntrepreneurList = Order.GetOrderByIndividual((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.IndividualEntrepreneurList;
                        }
                        else
                        {
                            CheckSort = DataGridSortDirection.Descending;
                            dataGets.IndividualEntrepreneurList.Clear();
                            dataGets.IndividualEntrepreneurList = Order.GetOrderByIndividual((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.IndividualEntrepreneurList;
                        }
                        break;
                    case "waybill":
                        if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                        {
                            CheckSort = DataGridSortDirection.Ascending;
                            dataGets.WaybillList.Clear();
                            dataGets.WaybillList = Order.GetOrderByWaybill((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.WaybillList;
                        }
                        else
                        {
                            CheckSort = DataGridSortDirection.Descending;
                            dataGets.WaybillList.Clear();
                            dataGets.WaybillList = Order.GetOrderByWaybill((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                            MainDataGrid.ItemsSource = dataGets.WaybillList;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "MainDataGrid_Sorting");
            }
        }
        private void MainDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

        }
        private void MainDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
        private void MainDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private async void MainDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            try
            {
                switch (e.PropertyName)
                {
                    case "Id":
                        e.Column.Header = "ID";
                        e.Column.Tag = "id";
                        break;
                    case "LastName":
                        e.Column.Header = "Фамилия";
                        e.Column.Tag = "last_name";
                        break;
                    case "FirstName":
                        e.Column.Header = "Имя";
                        e.Column.Tag = "first_name";
                        break;
                    case "MiddleName":
                        e.Column.Header = "Отчество";
                        e.Column.Tag = "middle_name";
                        break;
                    case "Status":
                        e.Column.Header = "Статус";
                        e.Column.Tag = "status";
                        break;
                    case "PSRNIE":
                        e.Column.Header = "ОГРНИП";
                        e.Column.Tag = "psrnie";
                        break;
                    case "TIN":
                        e.Column.Header = "ИНН";
                        e.Column.Tag = "tin";
                        break;
                    case "Brand":
                        e.Column.Header = "Бренд";
                        e.Column.Tag = "brand";
                        break;
                    case "Model":
                        e.Column.Header = "Модель";
                        e.Column.Tag = "model";
                        break;
                    case "VendorCode":
                        e.Column.Header = "Артикуль";
                        e.Column.Tag = "vendor_code";
                        break;
                    case "NameDevice":
                        e.Column.Header = "ККМ";
                        e.Column.Tag = "name";
                        break;
                    case "FactoryNumber":
                        e.Column.Header = "Заводской номер";
                        e.Column.Tag = "factory_number";
                        break;
                    case "SerialNumber":
                        e.Column.Header = "Серийный номер";
                        e.Column.Tag = "serial_number";
                        break;
                    case "PaymentNumber":
                        e.Column.Header = "Номер счета";
                        e.Column.Tag = "payment_number";
                        break;
                    case "Holder":
                        e.Column.Header = "Владелец";
                        e.Column.Tag = "holder";
                        break;
                    case "User":
                        e.Column.Header = "Пользователь";
                        e.Column.Tag = "user";
                        break;
                    case "DateReception":
                        e.Column.CanUserSort = false;
                        e.Column.Header = "Дата получения";
                        e.Column.Tag = "date_reception";
                        e.Column.Visibility = Visibility.Collapsed;
                        triggerPropertyNameList = false;
                        triggerHeader = false;
                        break;
                    case "DateReceptionString":
                        e.Column.Header = "Дата получения";
                        e.Column.Tag = "date_reception";
                        break;
                    case "DateEndFiscalMemory":
                        e.Column.CanUserSort = false;
                        e.Column.Header = "Дата окончания ФН";
                        e.Column.Tag = "date_end_fiscal_memory";
                        e.Column.Visibility = Visibility.Collapsed;
                        triggerPropertyNameList = false;
                        triggerHeader = false;
                        break;
                    case "DateEndFiscalMemoryString":
                        e.Column.Header = "Дата окончания ФН";
                        e.Column.Tag = "date_end_fiscal_memory";
                        break;
                    case "DateKeyActivationFiscalDataOperator":
                        e.Column.CanUserSort = false;
                        e.Column.Header = "Дата активации ОФД";
                        e.Column.Tag = "date_key_activ_fisc_data";
                        e.Column.Visibility = Visibility.Collapsed;
                        triggerPropertyNameList = false;
                        triggerHeader = false;
                        break;
                    case "DateKeyActivationFiscalDataOperatorString":
                        e.Column.Header = "Дата активации ОФД";
                        e.Column.Tag = "date_key_activ_fisc_data";
                        break;
                    case "Location":
                        e.Column.Header = "Место нахождения";
                        e.Column.Tag = "location";
                        break;
                    case "Post":
                        e.Column.Header = "Должность";
                        e.Column.Tag = "post";
                        break;
                    case "InternalNumber":
                        e.Column.Header = "Внутренный номер";
                        e.Column.Tag = "internal_number";
                        break;
                    case "MobileNumber":
                        e.Column.Header = "Мобильный номер";
                        e.Column.Tag = "mobile_number";
                        break;
                    case "ModelPrinter":
                        e.Column.Header = "Модель";
                        e.Column.Tag = "model";
                        break;
                    case "NamePort":
                        e.Column.Header = "IP-Адрес";
                        e.Column.Tag = "name_port";
                        break;
                    case "LocationPrinter":
                        e.Column.Header = "Расположение принтера";
                        e.Column.Tag = "location";
                        break;
                    case "OC":
                        e.Column.Header = "Среда ОС";
                        e.Column.Tag = "operation_system";
                        break;
                    case "NameTerminal":
                        e.Column.Header = "Имя терминала";
                        e.Column.Tag = "name_terminal";
                        break;
                    case "Operator":
                        e.Column.Header = "Оператор связи";
                        e.Column.Tag = "operator";
                        break;
                    case "IdentNumber":
                        e.Column.Header = "Идентификационный номер (ИН)";
                        e.Column.Tag = "identifaction_number";
                        break;
                    case "TypeDevice":
                        e.Column.Header = "Тип устройства";
                        e.Column.Tag = "type_device";
                        break;
                    case "TMS":
                        e.Column.Header = "Номер телефона (TMS)";
                        e.Column.Tag = "tms";
                        break;
                    case "ICC":
                        e.Column.Header = "Уникальный серийный номер (ICC)";
                        e.Column.Tag = "icc";
                        break;
                    case "IndividualEntrepreneur":
                        e.Column.Header = "Индивидуальный предприниматель (ИП)";
                        e.Column.Tag = "individual_entrepreneur";
                        break;
                    case "IdHolder":
                        e.Column.CanUserSort = false;
                        e.Column.Header = "IdHolder";
                        e.Column.Tag = "IdHolder";
                        e.Column.Visibility = Visibility.Collapsed;
                        triggerPropertyNameList = false;
                        triggerHeader = false;
                        break;
                    case "IdUser":
                        e.Column.CanUserSort = false;
                        e.Column.Header = "IdUser";
                        e.Column.Tag = "IdUser";
                        e.Column.Visibility = Visibility.Collapsed;
                        triggerPropertyNameList = false;
                        triggerHeader = false;
                        break;
                    case "IdIndividual":
                        e.Column.CanUserSort = false;
                        e.Column.Header = "IdIndividual";
                        e.Column.Tag = "IdIndividual";
                        e.Column.Visibility = Visibility.Collapsed;
                        triggerPropertyNameList = false;
                        triggerHeader = false;
                        break;
                    case "IdCashRegister":
                        e.Column.CanUserSort = false;
                        e.Column.Header = "IdCashRegister";
                        e.Column.Tag = "IdCashRegister";
                        e.Column.Visibility = Visibility.Collapsed;
                        triggerPropertyNameList = false;
                        triggerHeader = false;
                        break;
                    case "VendorCodePrinter":
                        e.Column.Header = "Артикули";
                        e.Column.Tag = "vendor_code";
                        break;
                    case "Сounters":
                        e.Column.Header = "Распечатанных страниц";
                        e.Column.Tag = "counters";
                        break;
                    case "BrandPrinter":
                        e.Column.Header = "Фирма";
                        e.Column.Tag = "brand";
                        break;
                    case "Cartridge":
                        e.Column.Header = "Картридж";
                        e.Column.Tag = "cartridge";
                        break;
                    case "DatePrinter":
                        e.Column.CanUserSort = false;
                        e.Column.Header = "Дата состояния";
                        e.Column.Tag = "date";
                        e.Column.Visibility = Visibility.Collapsed;
                        triggerPropertyNameList = false;
                        triggerHeader = false;
                        break;
                    case "DatePrinterString":
                        e.Column.Header = "Дата состояния";
                        e.Column.Tag = "date";
                        break;
                    case "NameDocument":
                        e.Column.Header = "Имя документа";
                        e.Column.Tag = "name_document";
                        break;
                    case "NumberSuppliers":
                        e.Column.Header = "Номер документа";
                        e.Column.Tag = "number_document";
                        break;
                    case "DateDocument":
                        e.Column.CanUserSort = false;
                        e.Column.Header = "Дата документа";
                        e.Column.Tag = "date_document";
                        e.Column.Visibility = Visibility.Collapsed;
                        triggerPropertyNameList = false;
                        triggerHeader = false;
                        break;
                    case "DateDocumentString":
                        e.Column.Header = "Дата документа";
                        e.Column.Tag = "date_document";
                        break;
                    case "FileName":
                        e.Column.Header = "Имя файла";
                        e.Column.Tag = "file_name";
                        break;
                    case "FilePDF":
                        e.Column.CanUserSort = false;
                        e.Column.Header = "Файлы";
                        e.Column.Tag = "file_pdf";
                        break;
                    default:
                        break;
                }
                if (triggerPropertyNameList)
                {
                    PropertyNameDictionary.Add(e.Column.Header.ToString(), e.PropertyName);
                }

                if (triggerHeader)
                {
                    SelectionItemComboBox.Items.Add(e.Column.Header);
                }
            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "MainDataGrid_AutoGeneratingColumn");
            }

        }
        private async void SearcherTextBox_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            try
            {
                triggerPropertyNameList = false;
                triggerHeader = false;
                foreach (KeyValuePair<string, string> kvp in PropertyNameDictionary)
                {
                    try
                    {
                        if (SelectionItemComboBox.SelectedValue.Equals(kvp.Key))
                        {
                            switch (kvp.Value)
                            {
                                case "Id":
                                    switch (NameNavigationItem)
                                    {
                                        case "printer":
                                            break;
                                        case "cartrides":
                                            break;
                                        case "cashRegister":
                                            break;
                                        case "simCard":
                                            break;
                                        case "phoneBook":
                                            break;
                                        case "holder":
                                            break;
                                        case "user":
                                            break;
                                        case "ie":
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "LastName":
                                    switch (NameNavigationItem)
                                    {
                                        case "phoneBook":
                                            IEnumerable<PhoneBook> PhoneBookFilter = dataGets.PhoneBookList.Where(PhoneBook => PhoneBook.LastName.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = PhoneBookFilter;
                                            dataGets.PhoneBookList = new ObservableCollection<PhoneBook>(PhoneBookFilter);
                                            break;
                                        case "holder":
                                            IEnumerable<Holder> HolderFilter = dataGets.HolderList.Where(Holder => Holder.LastName.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = HolderFilter;
                                            dataGets.HolderList = new ObservableCollection<Holder>(HolderFilter);
                                            break;
                                        case "user":
                                            IEnumerable<User> UserFilter = dataGets.UserList.Where(User => User.LastName.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = UserFilter;
                                            dataGets.UserList = new ObservableCollection<User>(UserFilter);
                                            break;
                                        case "ie":
                                            IEnumerable<IndividualEntrepreneur> IndividualEntrepreneurFilter = dataGets.IndividualEntrepreneurList.Where(IndividualEntrepreneur => IndividualEntrepreneur.LastName.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = IndividualEntrepreneurFilter;
                                            dataGets.IndividualEntrepreneurList = new ObservableCollection<IndividualEntrepreneur>(IndividualEntrepreneurFilter);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "FirstName":
                                    switch (NameNavigationItem)
                                    {
                                        case "phoneBook":
                                            IEnumerable<PhoneBook> PhoneBookFilter = dataGets.PhoneBookList.Where(PhoneBook => PhoneBook.FirstName.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = PhoneBookFilter;
                                            dataGets.PhoneBookList = new ObservableCollection<PhoneBook>(PhoneBookFilter);
                                            break;
                                        case "holder":
                                            IEnumerable<Holder> HolderFilter = dataGets.HolderList.Where(Holder => Holder.FirstName.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = HolderFilter;
                                            dataGets.HolderList = new ObservableCollection<Holder>(HolderFilter);
                                            break;
                                        case "user":
                                            IEnumerable<User> UserFilter = dataGets.UserList.Where(User => User.FirstName.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = UserFilter;
                                            dataGets.UserList = new ObservableCollection<User>(UserFilter);
                                            break;
                                        case "ie":
                                            IEnumerable<IndividualEntrepreneur> IndividualEntrepreneurFilter = dataGets.IndividualEntrepreneurList.Where(IndividualEntrepreneur => IndividualEntrepreneur.FirstName.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = IndividualEntrepreneurFilter;
                                            dataGets.IndividualEntrepreneurList = new ObservableCollection<IndividualEntrepreneur>(IndividualEntrepreneurFilter);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "MiddleName":
                                    switch (NameNavigationItem)
                                    {
                                        case "phoneBook":
                                            IEnumerable<PhoneBook> PhoneBookFilter = dataGets.PhoneBookList.Where(PhoneBook => PhoneBook.MiddleName.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = PhoneBookFilter;
                                            dataGets.PhoneBookList = new ObservableCollection<PhoneBook>(PhoneBookFilter);
                                            break;
                                        case "holder":
                                            IEnumerable<Holder> HolderFilter = dataGets.HolderList.Where(Holder => Holder.MiddleName.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = HolderFilter;
                                            dataGets.HolderList = new ObservableCollection<Holder>(HolderFilter);
                                            break;
                                        case "user":
                                            IEnumerable<User> UserFilter = dataGets.UserList.Where(User => User.MiddleName.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = UserFilter;
                                            dataGets.UserList = new ObservableCollection<User>(UserFilter);
                                            break;
                                        case "ie":
                                            IEnumerable<IndividualEntrepreneur> IndividualEntrepreneurFilter = dataGets.IndividualEntrepreneurList.Where(IndividualEntrepreneur => IndividualEntrepreneur.MiddleName.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = IndividualEntrepreneurFilter;
                                            dataGets.IndividualEntrepreneurList = new ObservableCollection<IndividualEntrepreneur>(IndividualEntrepreneurFilter);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "Status":
                                    switch (NameNavigationItem)
                                    {
                                        case "printer":
                                            IEnumerable<Printer> PrinterStatusFilter = dataGets.PrinterList.Where(Printer => Printer.Status.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = PrinterStatusFilter;
                                            dataGets.PrinterList = new ObservableCollection<Printer>(PrinterStatusFilter);
                                            break;
                                        case "cartrides":
                                            IEnumerable<Cartridge> CartridgeStatusFilter = dataGets.CartridgesList.Where(Cartridge => Cartridge.Status.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = CartridgeStatusFilter;
                                            dataGets.CartridgesList = new ObservableCollection<Cartridge>(CartridgeStatusFilter);
                                            break;
                                        case "simCard":
                                            IEnumerable<SimCard> SimCardStatusFilter = dataGets.SimCardList.Where(SimCard => SimCard.Status.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = SimCardStatusFilter;
                                            dataGets.SimCardList = new ObservableCollection<SimCard>(SimCardStatusFilter);
                                            break;
                                        case "holder":
                                            IEnumerable<Holder> HolderStatusFilter = dataGets.HolderList.Where(Holder => Holder.Status.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = HolderStatusFilter;
                                            dataGets.HolderList = new ObservableCollection<Holder>(HolderStatusFilter);
                                            break;
                                        case "user":
                                            IEnumerable<User> UserStatusFilter = dataGets.UserList.Where(User => User.Status.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = UserStatusFilter;
                                            dataGets.UserList = new ObservableCollection<User>(UserStatusFilter);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "PSRNIE":
                                    IEnumerable<IndividualEntrepreneur> IndividualEntrepreneurPSTNIEFilter = dataGets.IndividualEntrepreneurList.Where(IndividualEntrepreneur => IndividualEntrepreneur.PSRNIE.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = IndividualEntrepreneurPSTNIEFilter;
                                    dataGets.IndividualEntrepreneurList = new ObservableCollection<IndividualEntrepreneur>(IndividualEntrepreneurPSTNIEFilter);
                                    break;
                                case "TIN":
                                    IEnumerable<IndividualEntrepreneur> IndividualEntrepreneurTINFilter = dataGets.IndividualEntrepreneurList.Where(IndividualEntrepreneur => IndividualEntrepreneur.TIN.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = IndividualEntrepreneurTINFilter;
                                    dataGets.IndividualEntrepreneurList = new ObservableCollection<IndividualEntrepreneur>(IndividualEntrepreneurTINFilter);
                                    break;
                                case "Brand":
                                    switch (NameNavigationItem)
                                    {
                                        case "cartrides":
                                            IEnumerable<Cartridge> CartridgeFilter = dataGets.CartridgesList.Where(Cartridge => Cartridge.Brand.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = CartridgeFilter;
                                            dataGets.CartridgesList = new ObservableCollection<Cartridge>(CartridgeFilter);
                                            break;
                                        case "cashRegister":
                                            IEnumerable<CashRegister> CashRegisterFilter = dataGets.CashRegisterList.Where(CashRegister => CashRegister.Brand.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = CashRegisterFilter;
                                            dataGets.CashRegisterList = new ObservableCollection<CashRegister>(CashRegisterFilter);
                                            break;
                                        case "simCard":
                                            IEnumerable<SimCard> SimCardFilter = dataGets.SimCardList.Where(SimCard => SimCard.Brand.StartsWith(args.QueryText));
                                            MainDataGrid.ItemsSource = SimCardFilter;
                                            dataGets.SimCardList = new ObservableCollection<SimCard>(SimCardFilter);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "Model":
                                    IEnumerable<Cartridge> CartridgeModelFilter = dataGets.CartridgesList.Where(Cartridge => Cartridge.Model.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CartridgeModelFilter;
                                    dataGets.CartridgesList = new ObservableCollection<Cartridge>(CartridgeModelFilter);
                                    break;
                                case "VendorCode":
                                    IEnumerable<Cartridge> CartridgeVendorCodeFilter = dataGets.CartridgesList.Where(Cartridge => Cartridge.VendorCode.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CartridgeVendorCodeFilter;
                                    dataGets.CartridgesList = new ObservableCollection<Cartridge>(CartridgeVendorCodeFilter);
                                    break;
                                case "NameDevice":
                                    IEnumerable<CashRegister> CashRegisterNameFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.NameDevice.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CashRegisterNameFilter;
                                    dataGets.CashRegisterList = new ObservableCollection<CashRegister>(CashRegisterNameFilter);
                                    break;
                                case "FactoryNumber":
                                    IEnumerable<CashRegister> CashFactoryNumberFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.FactoryNumber.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CashFactoryNumberFilter;
                                    dataGets.CashRegisterList = new ObservableCollection<CashRegister>(CashFactoryNumberFilter);
                                    break;
                                case "SerialNumber":
                                    IEnumerable<CashRegister> CashSerialNumberFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.SerialNumber.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CashSerialNumberFilter;
                                    dataGets.CashRegisterList = new ObservableCollection<CashRegister>(CashSerialNumberFilter);
                                    break;
                                case "PaymentNumber":
                                    IEnumerable<CashRegister> CashPaymentNumberFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.PaymentNumber.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CashPaymentNumberFilter;
                                    dataGets.CashRegisterList = new ObservableCollection<CashRegister>(CashPaymentNumberFilter);
                                    break;
                                case "Holder":
                                    IEnumerable<CashRegister> CashHolderFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.Holder.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CashHolderFilter;
                                    dataGets.CashRegisterList = new ObservableCollection<CashRegister>(CashHolderFilter);
                                    break;
                                case "User":
                                    IEnumerable<CashRegister> CashUserFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.User.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CashUserFilter;
                                    dataGets.CashRegisterList = new ObservableCollection<CashRegister>(CashUserFilter);
                                    break;
                                case "DateReceptionString":
                                    IEnumerable<CashRegister> CashDateFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.DateReceptionString.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CashDateFilter;
                                    dataGets.CashRegisterList = new ObservableCollection<CashRegister>(CashDateFilter);
                                    break;
                                case "DateEndFiscalMemoryString":
                                    IEnumerable<CashRegister> CashDateEndFiscalMemoryFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.DateEndFiscalMemoryString.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CashDateEndFiscalMemoryFilter;
                                    dataGets.CashRegisterList = new ObservableCollection<CashRegister>(CashDateEndFiscalMemoryFilter);
                                    break;
                                case "DateKeyActivationFiscalDataOperatorString":
                                    IEnumerable<CashRegister> CashDateActivationFiscalFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.DateKeyActivationFiscalDataOperatorString.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CashDateActivationFiscalFilter;
                                    dataGets.CashRegisterList = new ObservableCollection<CashRegister>(CashDateActivationFiscalFilter);
                                    break;
                                case "Location":
                                    IEnumerable<CashRegister> CashLocationFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.Location.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CashLocationFilter;
                                    dataGets.CashRegisterList = new ObservableCollection<CashRegister>(CashLocationFilter);
                                    break;
                                case "Post":
                                    IEnumerable<PhoneBook> PhoneBookPostFilter = dataGets.PhoneBookList.Where(PhoneBook => PhoneBook.Post.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = PhoneBookPostFilter;
                                    dataGets.PhoneBookList = new ObservableCollection<PhoneBook>(PhoneBookPostFilter);
                                    break;
                                case "InternalNumber":
                                    IEnumerable<PhoneBook> PhoneBookInternalFilter = dataGets.PhoneBookList.Where(PhoneBook => PhoneBook.InternalNumber.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = PhoneBookInternalFilter;
                                    dataGets.PhoneBookList = new ObservableCollection<PhoneBook>(PhoneBookInternalFilter);
                                    break;
                                case "MobileNumber":
                                    IEnumerable<PhoneBook> PhoneBookMobileFilter = dataGets.PhoneBookList.Where(PhoneBook => PhoneBook.InternalNumber.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = PhoneBookMobileFilter;
                                    dataGets.PhoneBookList = new ObservableCollection<PhoneBook>(PhoneBookMobileFilter);
                                    break;
                                case "BrandPrinter":
                                    IEnumerable<Printer> PrinterBrandFilter = dataGets.PrinterList.Where(Printer => Printer.BrandPrinter.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = PrinterBrandFilter;
                                    dataGets.PrinterList = new ObservableCollection<Printer>(PrinterBrandFilter);
                                    break;
                                case "ModelPrinter":
                                    IEnumerable<Printer> PrinterFilter = dataGets.PrinterList.Where(Printer => Printer.ModelPrinter.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = PrinterFilter;
                                    dataGets.PrinterList = new ObservableCollection<Printer>(PrinterFilter);
                                    break;
                                case "Cartridge":
                                    IEnumerable<Printer> PrinterCartridgeFilter = dataGets.PrinterList.Where(Printer => Printer.Cartridge.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = PrinterCartridgeFilter;
                                    dataGets.PrinterList = new ObservableCollection<Printer>(PrinterCartridgeFilter);
                                    break;
                                case "NamePort":
                                    IEnumerable<Printer> PrinterNamePortFilter = dataGets.PrinterList.Where(Printer => Printer.NamePort.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = PrinterNamePortFilter;
                                    dataGets.PrinterList = new ObservableCollection<Printer>(PrinterNamePortFilter);
                                    break;
                                case "LocationPrinter":
                                    IEnumerable<Printer> PrinterLocationFilter = dataGets.PrinterList.Where(Printer => Printer.LocationPrinter.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = PrinterLocationFilter;
                                    dataGets.PrinterList = new ObservableCollection<Printer>(PrinterLocationFilter);
                                    break;
                                case "VendorCodePrinter":
                                    IEnumerable<Printer> PrinterVendorCodeFilter = dataGets.PrinterList.Where(Printer => Printer.VendorCodePrinter.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = PrinterVendorCodeFilter;
                                    dataGets.PrinterList = new ObservableCollection<Printer>(PrinterVendorCodeFilter);
                                    break;
                                case "Сounters":
                                    IEnumerable<Printer> PrinterСountersFilter = dataGets.PrinterList.Where(Printer => Printer.Сounters.ToString().StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = PrinterСountersFilter;
                                    dataGets.PrinterList = new ObservableCollection<Printer>(PrinterСountersFilter);
                                    break;
                                case "DatePrinterString":
                                    IEnumerable<Printer> PrinterDatePrinterStringFilter = dataGets.PrinterList.Where(Printer => Printer.DatePrinterString.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = PrinterDatePrinterStringFilter;
                                    dataGets.PrinterList = new ObservableCollection<Printer>(PrinterDatePrinterStringFilter);
                                    break;
                                case "NameTerminal":
                                    IEnumerable<SimCard> SimCardNameFilter = dataGets.SimCardList.Where(SimCard => SimCard.NameTerminal.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = SimCardNameFilter;
                                    dataGets.SimCardList = new ObservableCollection<SimCard>(SimCardNameFilter);
                                    break;
                                case "Operator":
                                    IEnumerable<SimCard> SimCardOperatorFilter = dataGets.SimCardList.Where(SimCard => SimCard.Operator.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = SimCardOperatorFilter;
                                    dataGets.SimCardList = new ObservableCollection<SimCard>(SimCardOperatorFilter);
                                    break;
                                case "IdentNumber":
                                    IEnumerable<SimCard> SimCardIdentNumberFilter = dataGets.SimCardList.Where(SimCard => SimCard.IdentNumber.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = SimCardIdentNumberFilter;
                                    dataGets.SimCardList = new ObservableCollection<SimCard>(SimCardIdentNumberFilter);
                                    break;
                                case "TypeDevice":
                                    IEnumerable<SimCard> SimCardTypeDeviceFilter = dataGets.SimCardList.Where(SimCard => SimCard.TypeDevice.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = SimCardTypeDeviceFilter;
                                    dataGets.SimCardList = new ObservableCollection<SimCard>(SimCardTypeDeviceFilter);
                                    break;
                                case "TMS":
                                    IEnumerable<SimCard> SimCardTMSFilter = dataGets.SimCardList.Where(SimCard => SimCard.TMS.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = SimCardTMSFilter;
                                    dataGets.SimCardList = new ObservableCollection<SimCard>(SimCardTMSFilter);
                                    break;
                                case "ICC":
                                    IEnumerable<SimCard> SimCardICCFilter = dataGets.SimCardList.Where(SimCard => SimCard.ICC.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = SimCardICCFilter;
                                    dataGets.SimCardList = new ObservableCollection<SimCard>(SimCardICCFilter);
                                    break;
                                case "IndividualEntrepreneur":
                                    IEnumerable<SimCard> SimCardIndividualEntrepreneurFilter = dataGets.SimCardList.Where(SimCard => SimCard.IndividualEntrepreneur.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = SimCardIndividualEntrepreneurFilter;
                                    dataGets.SimCardList = new ObservableCollection<SimCard>(SimCardIndividualEntrepreneurFilter);
                                    break;
                                case "NameDocument":
                                    IEnumerable<Waybill> WaybillNameDocumentFilter = dataGets.WaybillList.Where(Waybill => Waybill.NameDocument.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = WaybillNameDocumentFilter;
                                    dataGets.WaybillList = new ObservableCollection<Waybill>(WaybillNameDocumentFilter);
                                    break;
                                case "NumberDocument":
                                    IEnumerable<Waybill> WaybillNumberDocumentFilter = dataGets.WaybillList.Where(Waybill => Waybill.NumberDocument.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = WaybillNumberDocumentFilter;
                                    dataGets.WaybillList = new ObservableCollection<Waybill>(WaybillNumberDocumentFilter);
                                    break;
                                case "NumberSuppliers":
                                    IEnumerable<Waybill> WaybillNumberSuppliersFilter = dataGets.WaybillList.Where(Waybill => Waybill.NumberSuppliers.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = WaybillNumberSuppliersFilter;
                                    dataGets.WaybillList = new ObservableCollection<Waybill>(WaybillNumberSuppliersFilter);
                                    break;
                                case "DateDocumentString":
                                    IEnumerable<Waybill> WaybillDateDocumentStringFilter = dataGets.WaybillList.Where(Waybill => Waybill.DateDocumentString.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = WaybillDateDocumentStringFilter;
                                    dataGets.WaybillList = new ObservableCollection<Waybill>(WaybillDateDocumentStringFilter);
                                    break;
                                case "FileName":
                                    IEnumerable<Waybill> WaybillFileNameFilter = dataGets.WaybillList.Where(Waybill => Waybill.FileName.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = WaybillFileNameFilter;
                                    dataGets.WaybillList = new ObservableCollection<Waybill>(WaybillFileNameFilter);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch (NullReferenceException exNull)
                    {
                        await logFile.WriteLogAsync(exNull.Message, "SearcherTextBox_QuerySubmitted");
                        await new MessageDialog("Ячейки пусты").ShowAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "SearcherTextBox_QuerySubmitted");
            }
        }

        //private void AppBarButtonSave_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //}
        //private void SettingNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //}
        //private void InstructionNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //}
        //private void AboutNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //}
    }
}
