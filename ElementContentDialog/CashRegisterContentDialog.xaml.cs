using System.Collections.ObjectModel;
using TerminalMaster.Model;
using TerminalMaster.ViewModel;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace TerminalMaster.ElementContentDialog
{
    public sealed partial class CashRegisterContentDialog : ContentDialog
    {
        private AddElement add = new AddElement();
        private UpdateElement update = new UpdateElement();
        private GetElement get = new GetElement();
        public CashRegisterContentDialog()
        {
            this.InitializeComponent();
        }

        public string SelectData { get; set; }
        public int SelectIndex { get; set; }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string[] cashRehisters = { NameTextBox.Text, BrendTextBox.Text, FactoryNumberTextBox.Text, 
                SerialNumberTextBox.Text, PaymentNumberTextBox.Text, DateReceptionCalendarDatePicker.DateFormat, LocationTextBox.Text };

            if (SelectData.Equals("ADD")) { add.AddDataElement((App.Current as App).ConnectionString, cashRehisters, "cahsRegister"); }

            if (SelectData.Equals("UPDATE")) { update.UpdateDataElement((App.Current as App).ConnectionString, cashRehisters, SelectIndex, "cahsRegister"); }

            NameTextBox.Text = string.Empty;
            BrendTextBox.Text = string.Empty;
            FactoryNumberTextBox.Text = string.Empty;
            SerialNumberTextBox.Text = string.Empty;
            PaymentNumberTextBox.Text = string.Empty;
            HolderTextBox.Text = string.Empty;
            UserTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            NameTextBox.Text = string.Empty;
            BrendTextBox.Text = string.Empty;
            FactoryNumberTextBox.Text = string.Empty;
            SerialNumberTextBox.Text = string.Empty;
            PaymentNumberTextBox.Text = string.Empty;
            HolderTextBox.Text = string.Empty;
            UserTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
        }

        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            if (SelectData.Equals("GET"))
            {
                ObservableCollection<CashRegister> cashRegisters = get.GetCashRegister((App.Current as App).ConnectionString, "ONE", SelectIndex);
                NameTextBox.Text = cashRegisters[0].Name;
                BrendTextBox.Text = cashRegisters[0].Brend;
                FactoryNumberTextBox.Text = cashRegisters[0].FactoryNumber;
                SerialNumberTextBox.Text = cashRegisters[0].SerialNumber;
                PaymentNumberTextBox.Text = cashRegisters[0].PaymentNumber;
                HolderTextBox.Text = cashRegisters[0].Holder;
                UserTextBox.Text = cashRegisters[0].User;
                DateReceptionCalendarDatePicker.Date = cashRegisters[0].DateReception;
                LocationTextBox.Text = cashRegisters[0].Location;
                SelectData = "UPDATE";
            }
        }
    }
}
