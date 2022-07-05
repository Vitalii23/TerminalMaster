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
using TerminalMaster;
using TerminalMaster.ElementContentDialog;
using TerminalMaster.ElementContentDialog.PeopleContentDialog;
using TerminalMaster.Model;
using Windows.UI.Popups;
using System.ComponentModel;
using Microsoft.Toolkit.Uwp.UI;
using System.Collections.ObjectModel;
using TerminalMaster.DML;

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
        private bool triggerSort = true;
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
            triggerSort = true;
            updateTable(NameNavigationItem);
        }
        private void CartridesNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "cartrides";
            triggerSort = true;
            updateTable(NameNavigationItem);
        }
        private void CashRegystriNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "cashRegister";
            triggerSort = true;
            updateTable(NameNavigationItem);
        }
        private void SimCardRegystriNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "simCard";
            triggerSort = true;
            updateTable(NameNavigationItem);
        }
        private void PhoneBookNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "phoneBook";
            triggerSort = true;
            updateTable(NameNavigationItem);
        }
        private void HolderNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "holder";
            triggerSort = true;
            updateTable(NameNavigationItem);
        }
        private void UserNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "user";
            triggerSort = true;
            updateTable(NameNavigationItem);
        }
        private void IndividualEntrepreneurNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            NameNavigationItem = "ie";
            triggerSort = true;
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
                        People = NameNavigationItem
                    };
                    await holder.ShowAsync();
                    updateTable(NameNavigationItem);
                    break;
                case "user":
                    PeopleContentDialog user = new PeopleContentDialog
                    {
                        SelectData = "ADD",
                        People = NameNavigationItem
                    };
                    await user.ShowAsync();
                    updateTable(NameNavigationItem);
                    break;
                case "ie":
                    indContentDialog individual = new indContentDialog
                    {
                        SelectData = "ADD",
                        People = NameNavigationItem
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
                            People = NameNavigationItem
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
                            People = NameNavigationItem
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
                        indContentDialog individual = new indContentDialog
                        {
                            SelectData = "GET",
                            SelectIndex = dataGets.IndividualEntrepreneurList[MainDataGrid.SelectedIndex].Id,
                            People = NameNavigationItem
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
        private void MainDataGrid_Sorting(object sender, DataGridColumnEventArgs e)
        {
            if (triggerSort)
            {
                CheckSort = e.Column.SortDirection;
                triggerSort = false;
            }


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
                    break;
                case "DateReceptionString":
                    e.Column.Header = "Дата получения";
                    e.Column.Tag = "date_reception";
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
                    break;
                case "IdUser":
                    e.Column.CanUserSort = false;
                    e.Column.Header = "IdUser";
                    e.Column.Tag = "IdUser";
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
                case "IdIndividual":
                    e.Column.CanUserSort = false;
                    e.Column.Header = "IdIndividual";
                    e.Column.Tag = "IdIndividual";
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
                case "IdCashRegister":
                    e.Column.CanUserSort = false;
                    e.Column.Header = "IdCashRegister";
                    e.Column.Tag = "IdCashRegister";
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }
        private void MainDataGrid_LoadingRowGroup(object sender, DataGridRowGroupHeaderEventArgs e)
        {

        }

        private void SearcherTextBox_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            Debug.WriteLine(args.QueryText);
        }
        //private void ConnectNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //}
    }
}
