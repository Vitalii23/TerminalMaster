using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TerminalMaster.Model;
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

namespace TerminalMaster
{
    public sealed partial class ElementWindows : ContentDialog
    {
        private int count;
        private string title;
        private List<string> header;

        private ComboBox combo;
        private TextBox textBox;

        private List<object> objectList = new List<object>();

        public ElementWindows()
        {
            InitializeComponent();
        }

        public void SetDataElement(string title, List<string> list) {
            count = list.Count;
            this.title = title;
            header = new List<string>(list);
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

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
           
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
          
        }

        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            ElementContentDialog.Title = title;
            for (int i = 0; i < count; i++)
            {
                if (header[i].Equals("Дата получения"))
                {
                    CalendarDatePicker calendar = new CalendarDatePicker();
                    calendar.Header = header[i];
                    WriteTextBoxStackPanel.Children.Add(calendar);

                }
                else if (header[i].Equals("Статус"))
                {
                    combo = new ComboBox() {Header = header[i] };
                    if(i == 3)
                    {
                        string[] text = { "Запас", "Работает", "Пустой" };
                        AddComboxItem(text, combo);
                    }

                    if(i == 6)
                    {
                        string[] text = { "Нет сим-карты", "Работает", "Закончился ФН" };
                        AddComboxItem(text, combo);
                    }
                    WriteTextBoxStackPanel.Children.Add(combo);
                }
                else
                {
                    textBox = new TextBox { Header = header[i] };
                    AddTextBoxMaxLength(header[i]);
                    WriteTextBoxStackPanel.Children.Add(textBox);
                }
            }
        }

    }
}
