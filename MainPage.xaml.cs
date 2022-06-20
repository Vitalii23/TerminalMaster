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
        private void DirectoryNavigationItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainCommandBar.IsEnabled = true;
            MainDataGrid.Columns.Clear(); 
            MainDataGrid.ItemsSource = dataGets.PhoneBookList;
            NameNavigationItem = "directory";
        }
        private async void AppBarButtonAdd_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ElementWindows windows = new ElementWindows();
            switch (NameNavigationItem) {
                case "printer":
                    windows.SetDataElement("Принтеры", dataGets.GetNameDisplayPrinterList());
                    break;
                case "cartrides":
                    windows.SetDataElement("Картриджи", dataGets.GetNameDisplayCartridesList());
                    break;
                case "cashRegystry":
                    windows.SetDataElement("Контрольная-кассовая машина (ККМ)", dataGets.GetNameDisplayCashRegisterList());
                    break;
                case "simCard":
                    windows.SetDataElement("Сим-карты", dataGets.GetNameDisplaySimCardList());
                    break;
                case "directory":
                    windows.SetDataElement("Телефоны сотрудники", dataGets.GetNameDisplayPhoneBookList());
                    break;
            }
            await windows.ShowAsync();
        }
        private async void AppBarButtonEdit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ElementWindows windows = new ElementWindows();
            switch (NameNavigationItem)
            {
                case "printer":
                    windows.SetDataElement("Принтеры", dataGets.GetNameDisplayPrinterList());
                    break;
                case "cartrides":
                    windows.SetDataElement("Картриджи", dataGets.GetNameDisplayCartridesList());
                    break;
                case "cashRegystry":
                    windows.SetDataElement("Контрольная-кассовая машина (ККМ)", dataGets.GetNameDisplayCashRegisterList());
                    break;
                case "simCard":
                    windows.SetDataElement("Сим-карты", dataGets.GetNameDisplaySimCardList());
                    break;
                case "directory":
                    windows.SetDataElement("Телефоны сотрудники", dataGets.GetNameDisplayPhoneBookList());
                    break;
            }
            await windows.ShowAsync();
        }
        private async void AppBarButtonDelete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ElementWindows windows = new ElementWindows();
            await windows.ShowAsync();
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
