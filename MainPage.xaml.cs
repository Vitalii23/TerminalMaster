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

namespace TerminalMaster
{
    public sealed partial class MainPage : Page
    {
        private string NameNavigationItem;
        private readonly DataGets dataGets = new DataGets();
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
            dataGets.WriteElementList();
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
            NameNavigationItem = "printer";
        }
        private void CartridesNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            MainDataGrid.ItemsSource = dataGets.CartridgesList;
            NameNavigationItem = "cartrides";
        }
        private void CashRegystriNavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            MainDataGrid.ItemsSource = dataGets.CashRegisterList;
            NameNavigationItem = "cashRegystry";
        }
        private void SimCardRegystriNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            MainDataGrid.ItemsSource = dataGets.SimCardList;
            NameNavigationItem = "simCard";
        }
        private void PhoneBookNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear();
            MainDataGrid.ItemsSource = dataGets.PhoneBookList;
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
        private async void AppBarButtonEdit_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
        private async void AppBarButtonDelete_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
        private void AppBarButtonSave_Tapped(object sender, TappedRoutedEventArgs e)
        {

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
