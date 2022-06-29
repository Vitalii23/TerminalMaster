using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TerminalMaster.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.UI.ViewManagement;
using TerminalMaster.ElementContentDialog;
using TerminalMaster.ElementContentDialog.PeopleContentDialog;
using TerminalMaster.Model;
using Windows.UI.Popups;

namespace TerminalMaster
{
    public sealed partial class MainPage : Page
    {
        private string NameNavigationItem;
        private readonly DataGets dataGets = new DataGets();
        private GetElement Get = new GetElement();
        private DeleteElement Delete = new DeleteElement();
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;


        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var result = ApplicationView.GetForCurrentView().TryResizeView(new Size(1080, 1920));
            Debug.WriteLine("OnLoaded TryResizeView: " + result);
        }

        private void updateTable(string items)
        {
            switch (items)
            {
                case "printer":
                    dataGets.PrinterList = Get.GetPrinter((App.Current as App).ConnectionString, "ALL", 0);
                    MainDataGrid.ItemsSource = dataGets.PrinterList;
                    break;
                case "cartrides":
                    dataGets.CartridgesList = Get.GetCartridges((App.Current as App).ConnectionString, "ALL", 0);
                    MainDataGrid.ItemsSource = dataGets.CartridgesList;
                    break;
                case "cashRegister":
                    dataGets.CashRegisterList = Get.GetCashRegister((App.Current as App).ConnectionString, "ALL", 0);
                    MainDataGrid.ItemsSource = dataGets.CashRegisterList;
                    break;
                case "simCard":
                    dataGets.SimCardList = Get.GetSimCard((App.Current as App).ConnectionString, "ALL", 0);
                    MainDataGrid.ItemsSource = dataGets.SimCardList;
                    break;
                case "phoneBook":
                    dataGets.PhoneBookList = Get.GetPhoneBook((App.Current as App).ConnectionString, "ALL", 0); ;
                    MainDataGrid.ItemsSource = dataGets.PhoneBookList;
                    break;
                case "holder":
                    dataGets.HolderList = Get.GetHolder((App.Current as App).ConnectionString, "ALL", 0);
                    MainDataGrid.ItemsSource = dataGets.HolderList;
                    break;
                case "user":
                    dataGets.UserList = Get.GetUser((App.Current as App).ConnectionString, "ALL", 0);
                    MainDataGrid.ItemsSource = dataGets.UserList;
                    break;
                case "ie":
                    dataGets.IndividualEntrepreneurList = Get.GetIndividual((App.Current as App).ConnectionString, "ALL", 0);
                    MainDataGrid.ItemsSource = dataGets.IndividualEntrepreneurList;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Taped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "printer";
            updateTable(NameNavigationItem);
        }
        private void CartridesNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "cartrides";
            updateTable(NameNavigationItem);
        }
        private void CashRegystriNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "cashRegister";
            updateTable(NameNavigationItem);
        }
        private void SimCardRegystriNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "simCard";
            updateTable(NameNavigationItem);
        }
        private void PhoneBookNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "phoneBook";
            updateTable(NameNavigationItem);
        }
        private void HolderNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "holder";
            updateTable(NameNavigationItem);
        }
        private void UserNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "user";
            updateTable(NameNavigationItem);
        }
        private void IndividualEntrepreneurNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "ie";
            updateTable(NameNavigationItem);
        }
        //private void SettingNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //}
        //private void InstructionNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //}
        //private void AboutNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //}
        private async void AppBarButtonAdd_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine(MainDataGrid.SelectedIndex);
            switch (NameNavigationItem)
            {
                case "printer":
                    PrinterContentDialog printer = new PrinterContentDialog
                    {
                        SelectData = "ADD"
                    };
                    await printer.ShowAsync();
                    updateTable(NameNavigationItem);
                    break;
                case "cartrides":
                    CartridgeContentDialog cartridge = new CartridgeContentDialog
                    {
                        SelectData = "ADD"
                    };
                    await cartridge.ShowAsync();
                    updateTable(NameNavigationItem);
                    break;
                case "cashRegister":
                    CashRegisterContentDialog cashRegister = new CashRegisterContentDialog
                    {
                        SelectData = "ADD"
                    };
                    await cashRegister.ShowAsync();
                    updateTable(NameNavigationItem);
                    break;
                case "simCard":
                    SimCardContentDialog simCard = new SimCardContentDialog
                    {
                        SelectData = "ADD"
                    };
                    await simCard.ShowAsync();
                    updateTable(NameNavigationItem);
                    break;
                case "phoneBook":
                    PhoneBookContentDialog phoneBook = new PhoneBookContentDialog
                    {
                        SelectData = "ADD"
                    };
                    await phoneBook.ShowAsync();
                    updateTable(NameNavigationItem);
                    break;
                case "holder":
                    PeopleContentDialog holder = new PeopleContentDialog
                    {
                        SelectData = "ADD",
                        people = NameNavigationItem
                    };
                    await holder.ShowAsync();
                    updateTable(NameNavigationItem);
                    break;
                case "user":
                    PeopleContentDialog user = new PeopleContentDialog
                    {
                        SelectData = "ADD",
                        people = NameNavigationItem
                    };
                    await user.ShowAsync();
                    updateTable(NameNavigationItem);
                    break;
                case "ie":
                    PeopleContentDialog individual = new PeopleContentDialog
                    {
                        SelectData = "ADD",
                        people = NameNavigationItem
                    };
                    await individual.ShowAsync();
                    updateTable(NameNavigationItem);
                    break;
                default:
                    break;
            }
        }
        private async void AppBarButtonEdit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine(MainDataGrid.SelectedIndex);
            Debug.WriteLine(dataGets.PrinterList.Count);
            switch (NameNavigationItem)
            {
                case "printer":
                    if (MainDataGrid.SelectedIndex >= 0)
                    {
                        PrinterContentDialog printer = new PrinterContentDialog
                        {
                            SelectData = "GET",
                            SelectIndex = dataGets.PrinterList[MainDataGrid.SelectedIndex].Id
                        };
                        await printer.ShowAsync();
                        updateTable(NameNavigationItem);
                    }
                    else
                    {
                        MessageDialog message = new MessageDialog("Выберите строку для изменения");
                        await message.ShowAsync();
                    }
                    break;
                case "cartrides":
                    if (MainDataGrid.SelectedIndex >= 0)
                    {
                        CartridgeContentDialog cartridge = new CartridgeContentDialog
                        {
                            SelectData = "GET",
                            SelectIndex = dataGets.CartridgesList[MainDataGrid.SelectedIndex].Id
                        };
                        await cartridge.ShowAsync();
                        updateTable(NameNavigationItem);
                    }
                    else
                    {
                        MessageDialog edit = new MessageDialog("Выберите строку для изменения");
                        await edit.ShowAsync();
                    }
                    break;
                case "cashRegister":
                    if (MainDataGrid.SelectedIndex >= 0)
                    {
                        CashRegisterContentDialog cashRegister = new CashRegisterContentDialog
                        {
                            SelectData = "GET",
                            SelectIndex = dataGets.CashRegisterList[MainDataGrid.SelectedIndex].Id
                        };
                        await cashRegister.ShowAsync();
                        updateTable(NameNavigationItem);
                    }
                    else
                    {
                        MessageDialog message = new MessageDialog("Выберите строку для изменения");
                        await message.ShowAsync();
                    }
                    break;
                case "simCard":
                    if (MainDataGrid.SelectedIndex >= 0)
                    {
                        SimCardContentDialog simCard = new SimCardContentDialog
                        {
                            SelectData = "GET",
                            SelectIndex = dataGets.SimCardList[MainDataGrid.SelectedIndex].Id
                        };
                        await simCard.ShowAsync();
                        updateTable(NameNavigationItem);
                    }
                    else
                    {
                        MessageDialog message = new MessageDialog("Выберите строку для изменения");
                        await message.ShowAsync();
                    }
                    break;
                case "phoneBook":

                    if (MainDataGrid.SelectedIndex >= 0)
                    {
                        PhoneBookContentDialog phoneBook = new PhoneBookContentDialog
                        {
                            SelectData = "GET",
                            SelectIndex = dataGets.PhoneBookList[MainDataGrid.SelectedIndex].Id
                        };
                        await phoneBook.ShowAsync();
                        updateTable(NameNavigationItem);
                    }
                    else
                    {
                        MessageDialog message = new MessageDialog("Выберите строку для изменения");
                        await message.ShowAsync();
                    }
                    break;
                case "holder":
                    if (MainDataGrid.SelectedIndex >= 0)
                    {
                        PeopleContentDialog holder = new PeopleContentDialog
                        {
                            SelectData = "GET",
                            SelectIndex = dataGets.HolderList[MainDataGrid.SelectedIndex].Id,
                            people = NameNavigationItem
                        };
                        await holder.ShowAsync();
                        updateTable(NameNavigationItem);
                    }
                    else
                    {
                        MessageDialog message = new MessageDialog("Выберите строку для изменения");
                        await message.ShowAsync();
                    }
                    break;
                case "user":
                    if (MainDataGrid.SelectedIndex >= 0)
                    {
                        PeopleContentDialog user = new PeopleContentDialog
                        {
                            SelectData = "GET",
                            SelectIndex = dataGets.UserList[MainDataGrid.SelectedIndex].Id,
                            people = NameNavigationItem
                        };
                        await user.ShowAsync();
                        updateTable(NameNavigationItem);
                    }
                    else
                    {
                        MessageDialog message = new MessageDialog("Выберите строку для изменения");
                        await message.ShowAsync();
                    }
                    break;
                case "ie":
                    if (MainDataGrid.SelectedIndex >= 0)
                    {
                        PeopleContentDialog individual = new PeopleContentDialog
                        {
                            SelectData = "GET",
                            SelectIndex = dataGets.IndividualEntrepreneurList[MainDataGrid.SelectedIndex].Id,
                            people = NameNavigationItem
                        };
                        await individual.ShowAsync();
                        updateTable(NameNavigationItem);
                    }
                    else
                    {
                        MessageDialog message = new MessageDialog("Выберите строку для изменения");
                        await message.ShowAsync();
                    }
                    break;
                default:
                    break;

            }

        }
        private async void AppBarButtonDelete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MessageDialog message;
            Debug.WriteLine(MainDataGrid.SelectedIndex);

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
                    updateTable(NameNavigationItem);
                    break;
                case "cartrides":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.CartridgesList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                    updateTable(NameNavigationItem);
                    break;
                case "cashRegister":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.CashRegisterList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                    updateTable(NameNavigationItem);
                    break;
                case "simCard":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.SimCardList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                    updateTable(NameNavigationItem);
                    break;
                case "phoneBook":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.PhoneBookList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                    updateTable(NameNavigationItem);
                    break;
                case "holder":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.HolderList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                    updateTable(NameNavigationItem);
                    break;
                case "user":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.UserList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                    updateTable(NameNavigationItem);
                    break;
                case "ie":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, dataGets.IndividualEntrepreneurList[MainDataGrid.SelectedIndex].Id, NameNavigationItem); }
                    updateTable(NameNavigationItem);
                    break;
                default:
                    break;
            }
            Debug.WriteLine(MainDataGrid.SelectedIndex);
        }
        //private void AppBarButtonSave_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //}
        private void AppBarButtonUpdate_Tapped(object sender, TappedRoutedEventArgs e)
        {
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
                default:
                    break;

            }
        }
        //private void ConnectNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //}
    }
}
