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
            MainDataGrid.ItemsSource = dataGets.PrinterList;
            MainDataGrid.ItemsSource = Get.GetPrinter((App.Current as App).ConnectionString, "ALL", 0);
            NameNavigationItem = "printer";
        }
        private void CartridesNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            MainDataGrid.ItemsSource = dataGets.CartridgesList;
            MainDataGrid.ItemsSource = Get.GetCartridges((App.Current as App).ConnectionString, "ALL", 0);
            NameNavigationItem = "cartrides";
        }
        private void CashRegystriNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            MainDataGrid.ItemsSource = dataGets.CashRegisterList;
            MainDataGrid.ItemsSource = Get.GetCashRegister((App.Current as App).ConnectionString, "ALL", 0);
            NameNavigationItem = "cashRegystry";
        }
        private void SimCardRegystriNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            MainDataGrid.ItemsSource = dataGets.SimCardList;
            MainDataGrid.ItemsSource = Get.GetSimCard((App.Current as App).ConnectionString, "ALL", 0);
            NameNavigationItem = "simCard";
        }
        private void PhoneBookNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            MainDataGrid.ItemsSource = dataGets.PhoneBookList;
            MainDataGrid.ItemsSource = Get.GetPhoneBook((App.Current as App).ConnectionString, "ALL", 0);
            NameNavigationItem = "phoneBook";
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
                default:
                    break;
                   
            }
        }
        private async void AppBarButtonEdit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            switch (NameNavigationItem)
            {
                case "printer":
                    PrinterContentDialog printer = new PrinterContentDialog();
                    await printer.ShowAsync();
                    break;
                case "cartrides":
                    CartridgeContentDialog cartridge = new CartridgeContentDialog();
                    cartridge.SelectData = "GET";
                    cartridge.SelectIndex = MainDataGrid.SelectedIndex + 1;
                    await cartridge.ShowAsync();
                    break;
                case "cashRegystry":
                    CashRegisterContentDialog cashRegister = new CashRegisterContentDialog();
                    await cashRegister.ShowAsync();
                    break;
                case "simCard":
                    SimCardContentDialog simCard = new SimCardContentDialog();
                    await simCard.ShowAsync();
                    break;
                case "phoneBook":
                    PhoneBookContentDialog phoneBook = new PhoneBookContentDialog();
                    await phoneBook.ShowAsync();
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
        private void SettingNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
        private void InstructionNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
        private void AboutNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
