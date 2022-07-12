using System;
using System.Collections.ObjectModel;
using TerminalMaster.Model;
using TerminalMaster.ViewModel;
using TerminalMaster.Logging;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace TerminalMaster.ElementContentDialog
{
    public sealed partial class PrinterContentDialog : ContentDialog
    {
        private AddElement add = new AddElement();
        private UpdateElement update = new UpdateElement();
        private GetElement get = new GetElement();
        private LogFile logFile = new LogFile();
        public PrinterContentDialog()
        {
            InitializeComponent();

            string[] status = { "В работе", "Сервис", "Списан", "Не исправен" };
            AddComboxItem(status, StatusComboBox);

        }
        public string SelectData { get; set; }
        public int SelectIndex { get; set; }
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
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            try
            {
                string status = (string)StatusComboBox.SelectedValue;
                DateTimeOffset? dateTime = DatePrinterCalendarDatePicker.Date;
                string datePrinter = dateTime.Value.Year.ToString() + "-" + dateTime.Value.Month.ToString() + "-" + dateTime.Value.Day.ToString();
                string[] printers = { BrandTextBox.Text, ModelTextBox.Text, CartridgeTextBox.Text, NamePortTextBox.Text, LocationTextBox.Text, OcTextBox.Text, status, VendorCodeTextBox.Text, PaperTextBox.Text, datePrinter };

                if (SelectData.Equals("ADD"))
                {
                    add.AddDataElement((App.Current as App).ConnectionString, printers, "printer");
                }

                if (SelectData.Equals("UPDATE"))
                {
                    update.UpdateDataElement((App.Current as App).ConnectionString, printers, SelectIndex, "printer");
                }

                ModelTextBox.Text = string.Empty;
                NamePortTextBox.Text = string.Empty;
                LocationTextBox.Text = string.Empty;
                OcTextBox.Text = string.Empty;
            }
            catch (Exception e) 
            {
                logFile.WriteLogAsync(e.Message, "ContentDialog_PrimaryButtonClick");
            }
            
        }
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ModelTextBox.Text = string.Empty;
            NamePortTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
            OcTextBox.Text = string.Empty;
        }
        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            try 
            {
                if (SelectData.Equals("GET"))
                {

                    ObservableCollection<Printer> printers = get.GetPrinter((App.Current as App).ConnectionString, "ONE", SelectIndex);
                    BrandTextBox.Text = printers[0].BrandPrinter;
                    ModelTextBox.Text = printers[0].ModelPrinter;
                    CartridgeTextBox.Text = printers[0].Cartridge;
                    NamePortTextBox.Text = printers[0].NamePort;
                    LocationTextBox.Text = printers[0].LocationPrinter;
                    OcTextBox.Text = printers[0].OC;
                    StatusComboBox.SelectedValue = printers[0].Status;
                    VendorCodeTextBox.Text = printers[0].VendorCodePrinter;
                    PaperTextBox.Text = Convert.ToString(printers[0].Сounters);
                    DatePrinterCalendarDatePicker.Date = printers[0].DatePrinter;
                    SelectData = "UPDATE";
                }
            }
            catch (Exception e)
            {
                logFile.WriteLogAsync(e.Message, "ContentDialog_Opened(GET)");
            }
        }
        private void ModelTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
           // NextGoTextBox(e);
        }
    }
}
