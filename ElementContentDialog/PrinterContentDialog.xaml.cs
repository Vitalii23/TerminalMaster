using System;
using System.Collections.ObjectModel;
using TerminalMaster.Model;
using TerminalMaster.ViewModel;
using TerminalMaster.Logging;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace TerminalMaster.ElementContentDialog
{
    public sealed partial class PrinterContentDialog : ContentDialog
    {
        private AddElement add = new AddElement();
        private UpdateElement update = new UpdateElement();
        private LogFile logFile = new LogFile();
        

        public PrinterContentDialog()
        {
            InitializeComponent();

            string[] status = { "В работе", "Сервис", "Списан", "Не исправен" };
            AddComboxItem(status, StatusComboBox);

        }
        public string SelectData { get; set; }
        public int SelectIndex { get; set; }
        public int SelectId { get; set; }
        internal ObservableCollection<Printer> SelectPrinter { get; set; }
        public void NextGoTextBox(TextBox previousBox, TextBox nextBox, object sender, KeyRoutedEventArgs e, bool trigger)
        {
            TextBox textbox = sender as TextBox;
            if (e.Key == VirtualKey.Enter && !string.IsNullOrEmpty(textbox.Text.Trim()))
            {
                nextBox.Focus(FocusState.Keyboard);
            }

            if (e.Key == VirtualKey.PageUp)
            {
                if (!string.IsNullOrEmpty(textbox.Text.Trim()))
                {
                    previousBox.Focus(FocusState.Keyboard);
                }
            }

            if (e.Key == VirtualKey.PageDown)
            {
                if (!string.IsNullOrEmpty(textbox.Text.Trim()))
                {
                    nextBox.Focus(FocusState.Keyboard);
                }
            }
        }
        public void AddComboxItem(string[] text, ComboBox combo)
        {
            for (int i = 0; i < text.Length; i++)
            {
                combo.Items.Add(text[i]);
            }
        }
        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            try
            {
                string status = (string)StatusComboBox.SelectedValue;
                DateTimeOffset? dateTime = DatePrinterCalendarDatePicker.Date;
                string datePrinter = dateTime.Value.Year.ToString() + "-" + dateTime.Value.Month.ToString() + "-" + dateTime.Value.Day.ToString();
                string[] printers = { BrandTextBox.Text, ModelTextBox.Text, CartridgeTextBox.Text, NamePortTextBox.Text, LocationTextBox.Text, status, VendorCodeTextBox.Text, PaperTextBox.Text, datePrinter };

                if (SelectData.Equals("ADD"))
                {
                    add.AddDataElement((App.Current as App).ConnectionString, printers, "printer");
                }

                if (SelectData.Equals("UPDATE"))
                {
                    update.UpdateDataElement((App.Current as App).ConnectionString, printers, SelectId, "printer");
                }

                ModelTextBox.Text = string.Empty;
                NamePortTextBox.Text = string.Empty;
                LocationTextBox.Text = string.Empty;
            }
            catch (Exception e) 
            {
                await logFile.WriteLogAsync(e.Message, "Printer_ContentDialog_PrimaryButtonClick");
            }
            
        }
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ModelTextBox.Text = string.Empty;
            NamePortTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
        }
        private async void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            try 
            {
                if (SelectData.Equals("GET"))
                {
                    BrandTextBox.Text = SelectPrinter[SelectIndex].BrandPrinter;
                    ModelTextBox.Text = SelectPrinter[SelectIndex].ModelPrinter;
                    CartridgeTextBox.Text = SelectPrinter[SelectIndex].Cartridge;
                    NamePortTextBox.Text = SelectPrinter[SelectIndex].NamePort;
                    LocationTextBox.Text = SelectPrinter[SelectIndex].LocationPrinter;
                    StatusComboBox.SelectedValue = SelectPrinter[SelectIndex].Status;
                    VendorCodeTextBox.Text = SelectPrinter[SelectIndex].VendorCodePrinter;
                    PaperTextBox.Text = Convert.ToString(SelectPrinter[SelectIndex].Сounters);
                    DatePrinterCalendarDatePicker.Date = SelectPrinter[SelectIndex].DatePrinter;
                    SelectData = "UPDATE";
                }
            }
            catch (Exception e)
            {
                await logFile.WriteLogAsync(e.Message, "Printer_ContentDialog_Opened");
            }
        }
        private void ModelTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
           // NextGoTextBox(e);
        }
    }
}
