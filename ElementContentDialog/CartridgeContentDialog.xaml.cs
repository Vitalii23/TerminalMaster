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
        DeleteElement delete = new DeleteElement();
        public CartridgeContentDialog()
        {
            this.InitializeComponent();

            string[] brand = { "Kyocera", "Sakura", "HP LaserJat", "NetProduct" };
            AddComboxItem(brand, BrandComboBox);

            string[] model = { "ТК3190", "ТК160", "ТК170/172", "ТК1140" };
            AddComboxItem(model, ModelComboBox);

            string[] status = { "Заправлен", "Не заправлен", "Сервисе", "Не исправно" };
            AddComboxItem(status, StatusComboBox);
        }

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
            add.addDataElement((App.Current as App).ConnectionString, cartridges, "cartrides");

            VendorCodeTextBox.Text = string.Empty;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
