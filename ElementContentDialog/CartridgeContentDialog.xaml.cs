using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TerminalMaster.Model;
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

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace TerminalMaster.ElementContentDialog
{
    public sealed partial class CartridgeContentDialog : ContentDialog
    {
        AddElement add = new AddElement();
        UpdateElement update = new UpdateElement();
        GetElement get = new GetElement();

        public CartridgeContentDialog()
        {
            this.InitializeComponent();

            string[] brand = { "Kyocera", "Sakura", "HP LaserJat", "NetProduct" };
            AddComboxItem(brand, BrandComboBox);

            string[] model = {  "TK-160", "TK-170/172", "TK-475", "TK-1140", "TK-1150", "TK-1200", "TK-3190",
                "P3055dn", "CE505X/CRG719H", "7553X", "N-CE505A", "(05X)CE505X", "(53X) Q7553X", "(85A)CE285", "DV-1140E", "DK-150", "DK-170" };
            AddComboxItem(model, ModelComboBox);

            string[] status = { "Заправлен", "Не заправлен", "Сервисе", "Не исправно" };
            AddComboxItem(status, StatusComboBox);
        }
        public string SelectData { get; set; }
        public int SelectIndex { get; set; }
        internal ObservableCollection<Cartridge> SelectCartrides { get; set; }
        public void AddComboxItem(string[] text, ComboBox combo)
        {
            for (int i = 0; i < text.Length; i++)
            {
                combo.Items.Add(text[i]);
            }
        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string brandValue = (string)BrandComboBox.SelectedValue;
            string modelValue = (string)ModelComboBox.SelectedValue;
            string statusValue = (string)StatusComboBox.SelectedValue;

            string[] cartridges = { brandValue, modelValue, VendorCodeTextBox.Text, statusValue };

            if (SelectData.Equals("ADD")) { add.AddDataElement((App.Current as App).ConnectionString, cartridges, "cartrides"); }

            if (SelectData.Equals("UPDATE")) { update.UpdateDataElement((App.Current as App).ConnectionString, cartridges, SelectIndex, "cartrides"); }

            VendorCodeTextBox.Text = string.Empty;
        }
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            VendorCodeTextBox.Text = string.Empty;
        }
        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            if (SelectData.Equals("GET"))
            {
                BrandComboBox.SelectedValue = SelectCartrides[SelectIndex].Brand;
                ModelComboBox.SelectedValue = SelectCartrides[SelectIndex].Model;
                VendorCodeTextBox.Text = SelectCartrides[SelectIndex].VendorCode;
                StatusComboBox.SelectedValue = SelectCartrides[SelectIndex].Status;
                SelectData = "UPDATE";
            }
        }

        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {

        }
    }
}
