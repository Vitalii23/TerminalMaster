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
        /// <summary>
        /// Taped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            dataGets.PrinterList = Get.GetPrinter((App.Current as App).ConnectionString, "ALL", 0);
            MainDataGrid.ItemsSource = dataGets.PrinterList;
            NameNavigationItem = "printer";
        }
        private void CartridesNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            dataGets.CartridgesList = Get.GetCartridges((App.Current as App).ConnectionString, "ALL", 0);
            MainDataGrid.ItemsSource = dataGets.CartridgesList;
            NameNavigationItem = "cartrides";
        }
        private void CashRegystriNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            dataGets.CashRegisterList = Get.GetCashRegister((App.Current as App).ConnectionString, "ALL", 0);
            MainDataGrid.ItemsSource = dataGets.CashRegisterList;
            NameNavigationItem = "cashRegystry";
        }
        private void SimCardRegystriNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            dataGets.SimCardList = Get.GetSimCard((App.Current as App).ConnectionString, "ALL", 0);
            MainDataGrid.ItemsSource = dataGets.SimCardList;
            NameNavigationItem = "simCard";
        }
        private void PhoneBookNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            dataGets.PhoneBookList = Get.GetPhoneBook((App.Current as App).ConnectionString, "ALL", 0);;
            MainDataGrid.ItemsSource = dataGets.PhoneBookList;
            NameNavigationItem = "phoneBook";
        }
        private void HolderNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            dataGets.HolderList = Get.GetHolder((App.Current as App).ConnectionString, "ALL", 0);
            MainDataGrid.ItemsSource = dataGets.HolderList;
            NameNavigationItem = "holder";
        }
        private void UserNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            dataGets.UserList = Get.GetUser((App.Current as App).ConnectionString, "ALL", 0);
            MainDataGrid.ItemsSource = dataGets.UserList;
            NameNavigationItem = "user";
        }
        private void IndividualEntrepreneurNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            dataGets.IndividualEntrepreneurList = Get.GetIndividual((App.Current as App).ConnectionString, "ALL", 0);
            MainDataGrid.ItemsSource = dataGets.IndividualEntrepreneurList;
            NameNavigationItem = "ie";
        }
        private void SettingNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
        private void InstructionNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
        private void AboutNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
        private async void AppBarButtonAdd_Tapped(object sender, TappedRoutedEventArgs e)
        {
            switch (NameNavigationItem)
            {
                case "printer":
                    PrinterContentDialog printer = new PrinterContentDialog();
                    printer.SelectData = "ADD";
                    await printer.ShowAsync();
                    break;
                case "cartrides":
                    CartridgeContentDialog cartridge = new CartridgeContentDialog();
                    cartridge.SelectData = "ADD";
                    await cartridge.ShowAsync();
                    break;
                case "cashRegystry":
                    CashRegisterContentDialog cashRegister = new CashRegisterContentDialog();
                    cashRegister.SelectData = "ADD";
                    await cashRegister.ShowAsync();
                    break;
                case "simCard":
                    SimCardContentDialog simCard = new SimCardContentDialog();
                    simCard.SelectData = "ADD";
                    await simCard.ShowAsync();
                    break;
                case "phoneBook":
                    PhoneBookContentDialog phoneBook = new PhoneBookContentDialog();
                    phoneBook.SelectData = "ADD";
                    await phoneBook.ShowAsync();
                    break;
                case "holder":
                    PeopleContentDialog holder = new PeopleContentDialog();
                    holder.SelectData = "ADD";
                    holder.people = NameNavigationItem;
                    await holder.ShowAsync();
                    break;
                case "user":
                    PeopleContentDialog user = new PeopleContentDialog();
                    user.SelectData = "ADD";
                    user.people = NameNavigationItem;
                    await user.ShowAsync();
                    break;
                case "ie":
                    PeopleContentDialog individual = new PeopleContentDialog();
                    individual.SelectData = "ADD";
                    individual.people = NameNavigationItem;
                    await individual.ShowAsync();
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
                        PrinterContentDialog printer = new PrinterContentDialog();
                        printer.SelectData = "GET";
                        printer.SelectIndex = dataGets.PrinterList[MainDataGrid.SelectedIndex].Id;
                        await printer.ShowAsync();
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
                        CartridgeContentDialog cartridge = new CartridgeContentDialog();
                        cartridge.SelectData = "GET";
                        cartridge.SelectIndex = dataGets.CartridgesList[MainDataGrid.SelectedIndex].Id;
                        await cartridge.ShowAsync();
                    }
                    else
                    {
                        MessageDialog message = new MessageDialog("Выберите строку для изменения");
                        await message.ShowAsync();
                    }
                    break;
                case "cashRegystry":
                    if (MainDataGrid.SelectedIndex >= 0)
                    {
                        CashRegisterContentDialog cashRegister = new CashRegisterContentDialog();
                        cashRegister.SelectData = "GET";
                        cashRegister.SelectIndex = dataGets.CashRegisterList[MainDataGrid.SelectedIndex].Id;
                        await cashRegister.ShowAsync();
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
                        SimCardContentDialog simCard = new SimCardContentDialog();
                        simCard.SelectData = "GET";
                        simCard.SelectIndex = dataGets.SimCardList[MainDataGrid.SelectedIndex].ID;
                        await simCard.ShowAsync();
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
                        PhoneBookContentDialog phoneBook = new PhoneBookContentDialog();
                        phoneBook.SelectData = "GET";
                        phoneBook.SelectIndex = dataGets.PhoneBookList[MainDataGrid.SelectedIndex].Id;
                        await phoneBook.ShowAsync();
                    }
                    else
                    {
                        MessageDialog message = new MessageDialog("Выберите строку для изменения");
                        await message.ShowAsync();
                    }
                    break;
                case "holder":
                    if(MainDataGrid.SelectedIndex >= 0)
                    {
                        PeopleContentDialog holder = new PeopleContentDialog();
                        holder.SelectData = "GET";
                        holder.SelectIndex = dataGets.HolderList[MainDataGrid.SelectedIndex].Id;
                        holder.people = NameNavigationItem;
                        await holder.ShowAsync();
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
                        PeopleContentDialog user = new PeopleContentDialog();
                    user.SelectData = "GET";
                    user.SelectIndex = dataGets.UserList[MainDataGrid.SelectedIndex].Id;
                    user.people = NameNavigationItem;
                    await user.ShowAsync();
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
                        PeopleContentDialog individual = new PeopleContentDialog();
                        individual.SelectData = "GET";
                        individual.SelectIndex = dataGets.IndividualEntrepreneurList[MainDataGrid.SelectedIndex].Id;
                        individual.people = NameNavigationItem;
                        await individual.ShowAsync();
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
            MessageDialog message = new MessageDialog("Вы точно хотите удалить этот элемент.");
            message.Commands.Add(new UICommand("Да", null));
            message.Commands.Add(new UICommand("Нет", null));
            message.DefaultCommandIndex = 0;
            message.CancelCommandIndex = 1;

            IUICommand cmd = await message.ShowAsync();
            switch (NameNavigationItem)
            {
                case "printer":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, MainDataGrid.SelectedIndex + 1, NameNavigationItem); }
                    break;
                case "cartrides":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, MainDataGrid.SelectedIndex + 1, NameNavigationItem); }
                    break;
                case "cashRegystry":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, MainDataGrid.SelectedIndex + 1, NameNavigationItem); }
                    break;
                case "simCard":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, MainDataGrid.SelectedIndex + 1, NameNavigationItem); }
                    break;
                case "phoneBook":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, MainDataGrid.SelectedIndex + 1, NameNavigationItem); }
                    break;
                case "holder":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, MainDataGrid.SelectedIndex + 1, NameNavigationItem); }
                    break;
                case "user":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, MainDataGrid.SelectedIndex + 1, NameNavigationItem); }
                    break;
                case "ie":
                    if (cmd.Label == "Да") { Delete.DeleteDataElement((App.Current as App).ConnectionString, MainDataGrid.SelectedIndex + 1, NameNavigationItem); }
                    break;
                default:
                    break;
            }
        }
        private void AppBarButtonSave_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
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
                case "cashRegystry":
                    MainDataGrid.ItemsSource = Get.GetCashRegister((App.Current as App).ConnectionString, "ALL", 0);
                    break;
                case "simCard":
                    MainDataGrid.ItemsSource = Get.GetSimCard((App.Current as App).ConnectionString, "ALL", 0);
                    break;
                case "phoneBook":
                    MainDataGrid.ItemsSource = Get.GetPhoneBook((App.Current as App).ConnectionString, "ALL", 0);
                    break;
                default:
                    break;

            }
        }
        private void ConnectNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

    }
}
