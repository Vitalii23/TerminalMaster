using System.Collections.ObjectModel;
using TerminalMaster.Model;
using TerminalMaster.ViewModel;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace TerminalMaster.ElementContentDialog
{
    public sealed partial class PrinterContentDialog : ContentDialog
    {
        private AddElement add = new AddElement();
        private UpdateElement update = new UpdateElement();
        private GetElement get = new GetElement();
        public PrinterContentDialog()
        {
            InitializeComponent();

            string[] status = { "В работе", "Сервис", "Списан", "Не исправен" };
            AddComboxItem(status, StatusComboBox);
        }

        public string SelectData { get; set; }
        public int SelectIndex { get; set; }
        public void AddComboxItem(string[] text, ComboBox combo)
        {
            for (int i = 0; i < text.Length; i++)
            {
                combo.Items.Add(text[i]);
            }
        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

            string status = (string)StatusComboBox.SelectedValue;
            string[] printers = { NameUserTextBox.Text, NamePrinterTextBox.Text, ModelTextBox.Text,
                NamePortTextBox.Text, LocationTextBox.Text, OcTextBox.Text, status };

            if (SelectData.Equals("ADD")) { add.AddDataElement((App.Current as App).ConnectionString, printers, "printer"); }

            if (SelectData.Equals("UPDATE")) { update.UpdateDataElement((App.Current as App).ConnectionString, printers, SelectIndex, "printer"); }

            NameUserTextBox.Text = string.Empty;
            NamePrinterTextBox.Text = string.Empty;
            ModelTextBox.Text = string.Empty;
            NamePortTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
            OcTextBox.Text = string.Empty;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            NameUserTextBox.Text = string.Empty;
            NamePrinterTextBox.Text = string.Empty;
            ModelTextBox.Text = string.Empty;
            NamePortTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
            OcTextBox.Text = string.Empty;
        }

        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            if (SelectData.Equals("GET"))
            {
                ObservableCollection<Printer> printers = get.GetPrinter((App.Current as App).ConnectionString, "ONE", SelectIndex);
                NameUserTextBox.Text = printers[0].NameUser;
                NamePrinterTextBox.Text = printers[0].NamePrinter;
                ModelTextBox.Text = printers[0].Model;
                NamePortTextBox.Text = printers[0].NamePort;
                LocationTextBox.Text = printers[0].Location;
                OcTextBox.Text = printers[0].OC;
                StatusComboBox.SelectedValue = printers[0].Status;
                SelectData = "UPDATE";
            }

        }
    }
}
