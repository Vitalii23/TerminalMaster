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
            MainDataGrid.ItemsSource = Get.GetPrinter((App.Current as App).ConnectionString);
            NameNavigationItem = "printer";
        }
        private void CartridesNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            MainDataGrid.ItemsSource = dataGets.CartridgesList;
            MainDataGrid.ItemsSource = Get.GetCartridges((App.Current as App).ConnectionString);
            NameNavigationItem = "cartrides";
        }
        private void CashRegystriNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            MainDataGrid.ItemsSource = dataGets.CashRegisterList;
            MainDataGrid.ItemsSource = Get.GetCashRegister((App.Current as App).ConnectionString);
            NameNavigationItem = "cashRegystry";
        }
        private void SimCardRegystriNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            MainDataGrid.ItemsSource = dataGets.SimCardList;
            MainDataGrid.ItemsSource = Get.GetSimCard((App.Current as App).ConnectionString);
            NameNavigationItem = "simCard";
        }
        private void PhoneBookNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            MainDataGrid.ItemsSource = dataGets.PhoneBookList;
            MainDataGrid.ItemsSource = Get.GetPhoneBook((App.Current as App).ConnectionString);
            NameNavigationItem = "phoneBook";
        }
        private async void AppBarButtonAdd_Tapped(object sender, TappedRoutedEventArgs e)
        {
            switch (NameNavigationItem)
            {
                case "printer":
                    PrinterContentDialog printer = new PrinterContentDialog();
                    await printer.ShowAsync();
                    break;
                case "cartrides":
                    CartridgeContentDialog cartridge = new CartridgeContentDialog();
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
        private void AppBarButtonEdit_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
        private void AppBarButtonDelete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            switch (NameNavigationItem)
            {
                case "printer":
                    MainDataGrid.ItemsSource = Delete.DeleteDataElement((App.Current as App).ConnectionString, ,NameNavigationItem);
                    break;
                case "cartrides":
                    MainDataGrid.ItemsSource = Delete.DeleteDataElement((App.Current as App).ConnectionString, ,NameNavigationItem);
                    break;
                case "cashRegystry":
                    MainDataGrid.ItemsSource = Delete.DeleteDataElement((App.Current as App).ConnectionString, ,NameNavigationItem);
                    break;
                case "simCard":
                    MainDataGrid.ItemsSource = Delete.DeleteDataElement((App.Current as App).ConnectionString, ,NameNavigationItem);
                    break;
                case "phoneBook":
                    MainDataGrid.ItemsSource = Delete.DeleteDataElement((App.Current as App).ConnectionString, ,NameNavigationItem);
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
                    MainDataGrid.ItemsSource = Get.GetPrinter((App.Current as App).ConnectionString);
                    break;
                case "cartrides":
                    MainDataGrid.ItemsSource = Get.GetCartridges((App.Current as App).ConnectionString);
                    break;
                case "cashRegystry":
                    MainDataGrid.ItemsSource = Get.GetCashRegister((App.Current as App).ConnectionString);
                    break;
                case "simCard":
                    MainDataGrid.ItemsSource = Get.GetSimCard((App.Current as App).ConnectionString);
                    break;
                case "phoneBook":
                    MainDataGrid.ItemsSource = Get.GetPhoneBook((App.Current as App).ConnectionString);
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
