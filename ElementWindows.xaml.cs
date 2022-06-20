using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TerminalMaster.Model;
using TerminalMaster.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace TerminalMaster
{
    public sealed partial class ElementWindows : ContentDialog
    {
        private string title;
        private int count;

        private DataGets dataGets = new DataGets();

        private ComboBox combo;
        private TextBox textBox;
        private CalendarDatePicker calendar;

        private Dictionary<string, string> ObjectDictionary;

        public ElementWindows()
        {
            InitializeComponent();
        }

        public void SetDataElement(string title, Dictionary<string, string> objectDictionary)
        {
            this.title = title;
            ObjectDictionary = new Dictionary<string, string>(objectDictionary);
        }

        public void AddComboxItem(string[] text, ComboBox combo)
        {
            for (int i = 0; i < text.Length; i++)
            {
                combo.Items.Add(text[i]);
            }
        }

        public void AddTextBoxMaxLength(string header)
        {
            switch (header)
            {
                case "Заводской номер":
                    textBox.MaxLength = 12;
                    break;
                case "Серийный номер":
                    textBox.MaxLength = 13;
                    break;
                case "Номер счета":
                    textBox.MaxLength = 8;
                    break;
                case "Внутренний номер":
                    textBox.MaxLength = 3;
                    break;
                case "Мобильный номер":
                    textBox.MaxLength = 11;
                    break;
                case "ККМ":
                    textBox.MaxLength = 9;
                    break;
                default:
                    textBox.MaxLength = 20;
                    break;
            }

        }

        private void handler(IUICommand command)
        {
            System.Diagnostics.Debug.WriteLine($"The user clicked {command.Label}");
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                dataGets.CashRegisterList.Add(new CashRegister());
                textBox.Text = string.Empty;
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
          
        }

        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            ElementContentDialog.Title = title;

            foreach (KeyValuePair<string, string> kvp in ObjectDictionary)
            {
                switch (kvp.Value)
                {
                    case "ComboBox":
                        combo = new ComboBox() { Header = kvp.Key};
                        string[] text = { "Запас", "Работает", "Пустой" };
                        AddComboxItem(text, combo);
                        WriteTextBoxStackPanel.Children.Add(combo);
                        break;
                    case "TextBox":
                        textBox = new TextBox { Header = kvp.Key, Name = "Name" + count++ };
                        AddTextBoxMaxLength(kvp.Key);
                        Debug.WriteLine(textBox.Name);
                        WriteTextBoxStackPanel.Children.Add(textBox);
                        break;
                    case "CalendarDatePicker":
                        calendar = new CalendarDatePicker { Header = kvp.Key };
                        WriteTextBoxStackPanel.Children.Add(calendar);
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
