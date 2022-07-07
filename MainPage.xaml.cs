﻿using Microsoft.Toolkit.Uwp.UI.Controls;
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
using TerminalMaster;
using TerminalMaster.ElementContentDialog;
using TerminalMaster.ElementContentDialog.PeopleContentDialog;
using TerminalMaster.Model;
using Windows.UI.Popups;
using System.ComponentModel;
using Microsoft.Toolkit.Uwp.UI;
using System.Collections.ObjectModel;
using TerminalMaster.DML;
using TerminalMaster.Model.People;

namespace TerminalMaster
{
    public sealed partial class MainPage : Page
    {
        private string NameNavigationItem;
        private readonly DataGets dataGets = new DataGets();
        private GetElement Get = new GetElement();
        private DeleteElement Delete = new DeleteElement();
        private OrderByElement Order = new OrderByElement();
        private DataGridSortDirection? CheckSort;
        private bool triggerSort = true, triggerHeader, triggerPropertyNameList;
        private Dictionary<string, string> PropertyNameDictionary;
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
        private void UpdateTable(string items)
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
        public void AddComboxItem(List<string> text, ComboBox combo)
        {
            for (int i = 0; i < text.Count; i++)
            {
                combo.Items.Add(text[i]);
            }
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
            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
            NameNavigationItem = "printer";
            triggerSort = true;
            UpdateTable(NameNavigationItem);
        }
        private void CartridesNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            NameNavigationItem = "cartrides";
            triggerSort = true;
            UpdateTable(NameNavigationItem);
        }
        private void CashRegystriNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
            NameNavigationItem = "cashRegister";
            triggerSort = true;
            UpdateTable(NameNavigationItem);
        }
        private void SimCardRegystriNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
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
            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
            NameNavigationItem = "phoneBook";
            triggerSort = true;
            UpdateTable(NameNavigationItem);
        }
        private void HolderNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
            NameNavigationItem = "holder";
            triggerSort = true;
            UpdateTable(NameNavigationItem);
        }
        private void UserNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
            NameNavigationItem = "user";
            triggerSort = true;
            UpdateTable(NameNavigationItem);
        }
        private void IndividualEntrepreneurNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PropertyNameDictionary = new Dictionary<string, string>();
            MainCommandBar.IsEnabled = true;
            triggerPropertyNameList = true;
            triggerHeader = true;
            MainDataGrid.Columns.Clear();
            SelectionItemComboBox.Items.Clear();
            PropertyNameDictionary.Clear();
            NameNavigationItem = "ie";
            triggerSort = true;
            UpdateTable(NameNavigationItem);
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
                default:
                    break;
            }
        }
        private async void AppBarButtonEdit_Tapped(object sender, TappedRoutedEventArgs e)
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
                            SelectIndex = dataGets.PrinterList[MainDataGrid.SelectedIndex].Id
                        };
                        await printer.ShowAsync();
                        UpdateTable(NameNavigationItem);
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
                        UpdateTable(NameNavigationItem);
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
                        UpdateTable(NameNavigationItem);
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
                        UpdateTable(NameNavigationItem);
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
                        UpdateTable(NameNavigationItem);
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
                            People = NameNavigationItem
                        };
                        await holder.ShowAsync();
                        UpdateTable(NameNavigationItem);
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
                            People = NameNavigationItem
                        };
                        await user.ShowAsync();
                        UpdateTable(NameNavigationItem);
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
                        indContentDialog individual = new indContentDialog
                        {
                            SelectData = "GET",
                            SelectIndex = dataGets.IndividualEntrepreneurList[MainDataGrid.SelectedIndex].Id,
                            People = NameNavigationItem
                        };
                        await individual.ShowAsync();
                        UpdateTable(NameNavigationItem);
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
                default:
                    break;
            }
        }

        //private void AppBarButtonSave_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //}

        private void AppBarButtonUpdate_Tapped(object sender, TappedRoutedEventArgs e)
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
                default:
                    break;

            }
        }
        private void MainDataGrid_Sorting(object sender, DataGridColumnEventArgs e)
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
                        MainDataGrid.ItemsSource = Order.GetOrderByPrinter((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                    }
                    else
                    {
                        CheckSort = DataGridSortDirection.Descending;
                        MainDataGrid.ItemsSource = Order.GetOrderByPrinter((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                    }
                    break;
                case "cartrides":
                    if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                    {
                        CheckSort = DataGridSortDirection.Ascending;
                        MainDataGrid.ItemsSource = Order.GetOrderByCartridges((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                    }
                    else
                    {
                        CheckSort = DataGridSortDirection.Descending;
                        MainDataGrid.ItemsSource = Order.GetOrderByCartridges((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                    }
                    break;
                case "cashRegister":
                    if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                    {
                        CheckSort = DataGridSortDirection.Ascending;
                        MainDataGrid.ItemsSource = Order.GetOrderByCashRegister((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                    }
                    else
                    {
                        CheckSort = DataGridSortDirection.Descending;
                        MainDataGrid.ItemsSource = Order.GetOrderByCashRegister((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                    }
                    break;
                case "simCard":
                    if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                    {
                        CheckSort = DataGridSortDirection.Ascending;
                        MainDataGrid.ItemsSource = Order.GetOrderBySimCard((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                    }
                    else
                    {
                        CheckSort = DataGridSortDirection.Descending;
                        MainDataGrid.ItemsSource = Order.GetOrderBySimCard((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                    }
                    break;
                case "phoneBook":
                    if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                    {
                        CheckSort = DataGridSortDirection.Ascending;
                        MainDataGrid.ItemsSource = Order.GetOrderByPhoneBook((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                    }
                    else
                    {
                        CheckSort = DataGridSortDirection.Descending;
                        MainDataGrid.ItemsSource = Order.GetOrderByPhoneBook((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                    }
                    break;
                case "holder":
                    if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                    {
                        CheckSort = DataGridSortDirection.Ascending;
                        MainDataGrid.ItemsSource = Order.GetOrderByHolder((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                    }
                    else
                    {
                        CheckSort = DataGridSortDirection.Descending;
                        MainDataGrid.ItemsSource = Order.GetOrderByHolder((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                    }
                    break;
                case "user":
                    if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                    {
                        CheckSort = DataGridSortDirection.Ascending;
                        MainDataGrid.ItemsSource = Order.GetOrderByUser((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                    }
                    else
                    {
                        CheckSort = DataGridSortDirection.Descending;
                        MainDataGrid.ItemsSource = Order.GetOrderByUser((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                    }
                    break;
                case "ie":
                    if (CheckSort == null || CheckSort == DataGridSortDirection.Descending)
                    {
                        CheckSort = DataGridSortDirection.Ascending;
                        MainDataGrid.ItemsSource = Order.GetOrderByIndividual((App.Current as App).ConnectionString, "Ascending", e.Column.Tag.ToString());
                    }
                    else
                    {
                        CheckSort = DataGridSortDirection.Descending;
                        MainDataGrid.ItemsSource = Order.GetOrderByIndividual((App.Current as App).ConnectionString, "Descending", e.Column.Tag.ToString());
                    }
                    break;
                default:
                    break;
            }
        }
        private void MainDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
                    e.Column.Header = "Имена портов";
                    e.Column.Tag = "name_port";
                    break;
                case "LocationPrinter":
                    e.Column.Header = "Расположение принтера";
                    e.Column.Tag = "name_port";
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
        private void MainDataGrid_LoadingRowGroup(object sender, DataGridRowGroupHeaderEventArgs e)
        {

        }
        private void SearcherTextBox_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            triggerPropertyNameList = false;
            triggerHeader = false;
            foreach (KeyValuePair<string, string> kvp in PropertyNameDictionary)
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
                                    break;
                                case "holder":
                                    IEnumerable<Holder> HolderFilter = dataGets.HolderList.Where(Holder => Holder.LastName.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = HolderFilter;
                                    break;
                                case "user":
                                    IEnumerable<User> UserFilter = dataGets.UserList.Where(User => User.LastName.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = UserFilter;
                                    break;
                                case "ie":
                                    IEnumerable<IndividualEntrepreneur> IndividualEntrepreneurFilter = dataGets.IndividualEntrepreneurList.Where(IndividualEntrepreneur => IndividualEntrepreneur.LastName.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = IndividualEntrepreneurFilter;
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
                                    break;
                                case "holder":
                                    IEnumerable<Holder> HolderFilter = dataGets.HolderList.Where(Holder => Holder.FirstName.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = HolderFilter;
                                    break;
                                case "user":
                                    IEnumerable<User> UserFilter = dataGets.UserList.Where(User => User.FirstName.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = UserFilter;
                                    break;
                                case "ie":
                                    IEnumerable<IndividualEntrepreneur> IndividualEntrepreneurFilter = dataGets.IndividualEntrepreneurList.Where(IndividualEntrepreneur => IndividualEntrepreneur.FirstName.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = IndividualEntrepreneurFilter;
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
                                    break;
                                case "holder":
                                    IEnumerable<Holder> HolderFilter = dataGets.HolderList.Where(Holder => Holder.MiddleName.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = HolderFilter;
                                    break;
                                case "user":
                                    IEnumerable<User> UserFilter = dataGets.UserList.Where(User => User.MiddleName.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = UserFilter;
                                    break;
                                case "ie":
                                    IEnumerable<IndividualEntrepreneur> IndividualEntrepreneurFilter = dataGets.IndividualEntrepreneurList.Where(IndividualEntrepreneur => IndividualEntrepreneur.MiddleName.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = IndividualEntrepreneurFilter;
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
                                    break;
                                case "cartrides":
                                    IEnumerable<Cartridge> CartridgeStatusFilter = dataGets.CartridgesList.Where(Cartridge => Cartridge.Status.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CartridgeStatusFilter;
                                    break;
                                case "simCard":
                                    IEnumerable<SimCard> SimCardStatusFilter = dataGets.SimCardList.Where(SimCard => SimCard.Status.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = SimCardStatusFilter;
                                    break;
                                case "holder":
                                    IEnumerable<Holder> HolderStatusFilter = dataGets.HolderList.Where(Holder => Holder.Status.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = HolderStatusFilter;
                                    break;
                                case "user":
                                    IEnumerable<User> UserStatusFilter = dataGets.UserList.Where(User => User.Status.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = UserStatusFilter;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "PSRNIE":
                            IEnumerable<IndividualEntrepreneur> IndividualEntrepreneurPSTNIEFilter = dataGets.IndividualEntrepreneurList.Where(IndividualEntrepreneur => IndividualEntrepreneur.PSRNIE.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = IndividualEntrepreneurPSTNIEFilter;
                            break;
                        case "TIN":
                            IEnumerable<IndividualEntrepreneur> IndividualEntrepreneurTINFilter = dataGets.IndividualEntrepreneurList.Where(IndividualEntrepreneur => IndividualEntrepreneur.TIN.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = IndividualEntrepreneurTINFilter;
                            break;
                        case "Brand":
                            switch (NameNavigationItem)
                            {
                                case "cartrides":
                                    IEnumerable<Cartridge> CartridgeFilter = dataGets.CartridgesList.Where(Cartridge => Cartridge.Brand.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CartridgeFilter;
                                    break;
                                case "cashRegister":
                                    IEnumerable<CashRegister> CashRegisterFilter = dataGets.CashRegisterList.Where(CashRegister => CashRegister.Brand.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = CashRegisterFilter;
                                    break;
                                case "simCard":
                                    IEnumerable<SimCard> SimCardFilter = dataGets.SimCardList.Where(SimCard => SimCard.Brand.StartsWith(args.QueryText));
                                    MainDataGrid.ItemsSource = SimCardFilter;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Model":
                            IEnumerable<Cartridge> CartridgeModelFilter = dataGets.CartridgesList.Where(Cartridge => Cartridge.Model.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = CartridgeModelFilter;
                            break;
                        case "VendorCode":
                            IEnumerable<Cartridge> CartridgeVendorCodeFilter = dataGets.CartridgesList.Where(Cartridge => Cartridge.VendorCode.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = CartridgeVendorCodeFilter;
                            break;
                        case "NameDevice":
                            IEnumerable<CashRegister> CashRegisterNameFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.NameDevice.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = CashRegisterNameFilter;
                            break;
                        case "FactoryNumber":
                            IEnumerable<CashRegister> CashFactoryNumberFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.FactoryNumber.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = CashFactoryNumberFilter;
                            break;
                        case "SerialNumber":
                            IEnumerable<CashRegister> CashSerialNumberFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.SerialNumber.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = CashSerialNumberFilter;
                            break;
                        case "PaymentNumber":
                            IEnumerable<CashRegister> CashPaymentNumberFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.PaymentNumber.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = CashPaymentNumberFilter;
                            break;
                        case "Holder":
                            IEnumerable<CashRegister> CashHolderFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.Holder.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = CashHolderFilter;
                            break;
                        case "User":
                            IEnumerable<CashRegister> CashUserFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.User.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = CashUserFilter;
                            break;
                        case "DateReceptionString":
                            IEnumerable<CashRegister> CashDateFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.DateReceptionString.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = CashDateFilter;
                            break;
                        case "DateEndFiscalMemoryString":
                            IEnumerable<CashRegister> CashDateEndFiscalMemoryFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.DateEndFiscalMemoryString.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = CashDateEndFiscalMemoryFilter;
                            break;
                        case "DateKeyActivationFiscalDataOperatorString":
                            IEnumerable<CashRegister> CashDateActivationFiscalFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.DateKeyActivationFiscalDataOperatorString.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = CashDateActivationFiscalFilter;
                            break;
                        case "Location":
                            IEnumerable<CashRegister> CashLocationFilter = dataGets.CashRegisterList.Where(Cartridge => Cartridge.Location.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = CashLocationFilter;
                            break;
                        case "Post":
                            IEnumerable<PhoneBook> PhoneBookPostFilter = dataGets.PhoneBookList.Where(PhoneBook => PhoneBook.Post.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = PhoneBookPostFilter;
                            break;
                        case "InternalNumber":
                            IEnumerable<PhoneBook> PhoneBookInternalFilter = dataGets.PhoneBookList.Where(PhoneBook => PhoneBook.InternalNumber.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = PhoneBookInternalFilter;
                            break;
                        case "MobileNumber":
                            IEnumerable<PhoneBook> PhoneBookMobileFilter = dataGets.PhoneBookList.Where(PhoneBook => PhoneBook.InternalNumber.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = PhoneBookMobileFilter;
                            break;
                        case "ModelPrinter":
                            IEnumerable<Printer> PrinterFilter = dataGets.PrinterList.Where(Printer => Printer.ModelPrinter.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = PrinterFilter;
                            break;
                        case "NamePort":
                            IEnumerable<Printer> PrinterNamePortFilter = dataGets.PrinterList.Where(Printer => Printer.NamePort.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = PrinterNamePortFilter;
                            break;
                        case "LocationPrinter":
                            IEnumerable<Printer> PrinterLocationFilter = dataGets.PrinterList.Where(Printer => Printer.LocationPrinter.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = PrinterLocationFilter;
                            break;
                        case "OC":
                            IEnumerable<Printer> PrinterOCFilter = dataGets.PrinterList.Where(Printer => Printer.OC.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = PrinterOCFilter;
                            break;
                        case "NameTerminal":
                            IEnumerable<SimCard> SimCardNameFilter = dataGets.SimCardList.Where(SimCard => SimCard.NameTerminal.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = SimCardNameFilter;
                            break;
                        case "Operator":
                            IEnumerable<SimCard> SimCardOperatorFilter = dataGets.SimCardList.Where(SimCard => SimCard.Operator.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = SimCardOperatorFilter;
                            break;
                        case "IdentNumber":
                            IEnumerable<SimCard> SimCardIdentNumberFilter = dataGets.SimCardList.Where(SimCard => SimCard.IdentNumber.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = SimCardIdentNumberFilter;
                            break;
                        case "TypeDevice":
                            IEnumerable<SimCard> SimCardTypeDeviceFilter = dataGets.SimCardList.Where(SimCard => SimCard.TypeDevice.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = SimCardTypeDeviceFilter;
                            break;
                        case "TMS":
                            IEnumerable<SimCard> SimCardTMSFilter = dataGets.SimCardList.Where(SimCard => SimCard.TMS.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = SimCardTMSFilter;
                            break;
                        case "ICC":
                            IEnumerable<SimCard> SimCardICCFilter = dataGets.SimCardList.Where(SimCard => SimCard.ICC.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = SimCardICCFilter;
                            break;
                        case "IndividualEntrepreneur":
                            IEnumerable<SimCard> SimCardIndividualEntrepreneurFilter = dataGets.SimCardList.Where(SimCard => SimCard.IndividualEntrepreneur.StartsWith(args.QueryText));
                            MainDataGrid.ItemsSource = SimCardIndividualEntrepreneurFilter;
                            break;
                        default:
                            break;
                    }
                }
            }


            //IEnumerable<CashRegister> filtered = dataGets.CashRegisterList.Where(CashRegister => CashRegister.NameDevice.StartsWith(args.QueryText));
        }

        //private void ConnectNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //}
    }
}
