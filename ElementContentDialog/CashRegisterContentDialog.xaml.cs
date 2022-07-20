using System;
using System.Collections.ObjectModel;
using TerminalMaster.Logging;
using TerminalMaster.Model;
using TerminalMaster.ViewModel;
using Windows.UI.Xaml.Controls;

namespace TerminalMaster.ElementContentDialog
{
    public sealed partial class CashRegisterContentDialog : ContentDialog
    {
        private AddElement add = new AddElement();
        private UpdateElement update = new UpdateElement();
        private GetElement get = new GetElement();
        private LogFile logFile = new LogFile();
        private ObservableCollection<Holder> holders;
        private ObservableCollection<User> users;

        public CashRegisterContentDialog()
        {
            InitializeComponent();
            holders = get.GetHolder((App.Current as App).ConnectionString, "ALL", 0);
            users = get.GetUser((App.Current as App).ConnectionString, "ALL", 0);


            for (int i = 0; i < holders.Count; i++)
            {
                HolderComboBox.Items.Add(holders[i].LastName + " " + holders[i].FirstName + " " + holders[i].MiddleName);
            }

            for (int i = 0; i < users.Count; i++)
            {
                UserComboBox.Items.Add(users[i].LastName + " " + users[i].FirstName + " " + users[i].MiddleName);
            }

            string[] brend = { "AZUR", "MSPOS", "Атол FPrint-22ПТК", "Атол 55Ф" };
            AddComboxItem(brend, BrendComboBox);
        }
        public string SelectData { get; set; }
        public int SelectIndex { get; set; }
        public int SelectId { get; set; }
        internal ObservableCollection<CashRegister> SelectCashRegister;
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
                string brandValue = (string)BrendComboBox.SelectedValue;

                DateTimeOffset? dateTime = DateReceptionCalendarDatePicker.Date;
                string dateReception = dateTime.Value.Year.ToString() + "-" + dateTime.Value.Month.ToString() + "-" + dateTime.Value.Day.ToString();

                dateTime = DateEndFiscalMemoryCalendarDatePicker.Date;
                string dateEndFiscal = dateTime.Value.Year.ToString() + "-" + dateTime.Value.Month.ToString() + "-" + dateTime.Value.Day.ToString();

                dateTime = DateKeyActivationFiscalDataOperatorCalendarDatePicker.Date;
                string dateActivatFiscal = dateTime.Value.Year.ToString() + "-" + dateTime.Value.Month.ToString() + "-" + dateTime.Value.Day.ToString();

                string[] cashRehisters = { NameTextBox.Text, brandValue, FactoryNumberTextBox.Text,
                SerialNumberTextBox.Text, PaymentNumberTextBox.Text, dateReception, dateActivatFiscal, dateEndFiscal, LocationTextBox.Text};
                int[] Ids = new int[] { holders[HolderComboBox.SelectedIndex].Id, users[UserComboBox.SelectedIndex].Id };

                if (SelectData.Equals("ADD"))
                {

                    add.AddDataElement((App.Current as App).ConnectionString, cashRehisters, Ids, "cashRegister");
                }

                if (SelectData.Equals("UPDATE"))
                {
                    update.UpdateDataElement((App.Current as App).ConnectionString, cashRehisters, Ids, SelectId, "cashRegister");
                }

                NameTextBox.Text = string.Empty;
                FactoryNumberTextBox.Text = string.Empty;
                SerialNumberTextBox.Text = string.Empty;
                PaymentNumberTextBox.Text = string.Empty;
                LocationTextBox.Text = string.Empty;

            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "CashRegister_ContentDialog_PrimaryButtonClick");
            }
        }
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            NameTextBox.Text = string.Empty;
            FactoryNumberTextBox.Text = string.Empty;
            SerialNumberTextBox.Text = string.Empty;
            PaymentNumberTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
        }
        private async void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            try
            {
                if (SelectData.Equals("GET"))
                {
                    NameTextBox.Text = SelectCashRegister[SelectIndex].NameDevice;
                    BrendComboBox.SelectedValue = SelectCashRegister[SelectIndex].Brand;
                    FactoryNumberTextBox.Text = SelectCashRegister[SelectIndex].FactoryNumber;
                    SerialNumberTextBox.Text = SelectCashRegister[SelectIndex].SerialNumber;
                    PaymentNumberTextBox.Text = SelectCashRegister[SelectIndex].PaymentNumber;
                    HolderComboBox.SelectedValue = SelectCashRegister[SelectIndex].Holder;
                    UserComboBox.SelectedValue = SelectCashRegister[SelectIndex].User;
                    DateReceptionCalendarDatePicker.Date = SelectCashRegister[SelectIndex].DateReception;
                    DateEndFiscalMemoryCalendarDatePicker.Date = SelectCashRegister[SelectIndex].DateEndFiscalMemory;
                    DateKeyActivationFiscalDataOperatorCalendarDatePicker.Date = SelectCashRegister[SelectIndex].DateKeyActivationFiscalDataOperator;
                    LocationTextBox.Text = SelectCashRegister[SelectIndex].Location;
                    SelectData = "UPDATE";
                }
            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "CashRegister_ContentDialog_Opened");
            }
        }
    }
}
