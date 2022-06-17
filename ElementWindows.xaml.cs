using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TerminalMaster.Model;
using Toner.ConfigElement;
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

        private PropertyElement pe = new PropertyElement(); 
        public ElementWindows()
        {
            InitializeComponent();
        }

        public void SetDataElement(string title, List<string> list) {
            count = list.Count;
            this.title = title;
            header = new List<string>(list);
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
                    ComboBox combo = new ComboBox() {Header = header[i] };
                    ComboBoxItem boxItem = new ComboBoxItem();
                    if(i == 4)
                    {

                        string[] text = { "Запас", "Работает", "Пустой" };
                        for(int z = 0; z < text.Length; z++)
                        {
                            boxItem.Content = text[z];
                        }
                        
                    }  

                    if(i == 7)
                    {
                        string[] text = { "Нет сим-карты", "Работает", "Закончился ФН" };
                        for (int z = 0; z < text.Length; z++)
                        {
                            boxItem.Content = text[z];
                        }
                    }

                    combo.SelectedItem = boxItem;
                    WriteTextBoxStackPanel.Children.Add(combo);
                }
                else
                {
                    TextBox textBox = new TextBox { Header = header[i] };
                    pe.SetTextBoxMaxLength(10);
                    textBox.MaxLength = pe.GetTextBoxMaxLength();
                    WriteTextBoxStackPanel.Children.Add(textBox);
                }
            }
        }
    }
}
