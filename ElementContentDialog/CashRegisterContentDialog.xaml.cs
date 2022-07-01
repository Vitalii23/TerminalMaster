using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

            string[] brend = { "AZUR", "MSPOS" };
            AddComboxItem(brend, BrendComboBox);
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
            
            string brandValue = (string)BrendComboBox.SelectedValue;

            var dateTime = DateReceptionCalendarDatePicker.Date;
            string date = dateTime.Value.Year.ToString() + "-"+ dateTime.Value.Month.ToString() + "-" + dateTime.Value.Day.ToString();
            string[] cashRehisters = { NameTextBox.Text, brandValue, FactoryNumberTextBox.Text,
                SerialNumberTextBox.Text, PaymentNumberTextBox.Text, date, LocationTextBox.Text};
            int[] Ids = new int[] { holders[HolderComboBox.SelectedIndex].Id, users[UserComboBox.SelectedIndex].Id };

            if (SelectData.Equals("ADD")) 
            {
                
                add.AddDataElement((App.Current as App).ConnectionString, cashRehisters, Ids, "cashRegister"); 
            }

            if (SelectData.Equals("UPDATE")) 
            {
                update.UpdateDataElement((App.Current as App).ConnectionString, cashRehisters, Ids, SelectIndex, "cashRegister"); 
            }

            NameTextBox.Text = string.Empty;
            FactoryNumberTextBox.Text = string.Empty;
            SerialNumberTextBox.Text = string.Empty;
            PaymentNumberTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            NameTextBox.Text = string.Empty;
            FactoryNumberTextBox.Text = string.Empty;
            SerialNumberTextBox.Text = string.Empty;
            PaymentNumberTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
        }

        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            if (SelectData.Equals("GET"))
            {
                ObservableCollection<CashRegister> cashRegisters = get.GetCashRegister((App.Current as App).ConnectionString, "ONE", SelectIndex);
                NameTextBox.Text = cashRegisters[0].Name;
                BrendComboBox.SelectedValue = cashRegisters[0].Brend;
                FactoryNumberTextBox.Text = cashRegisters[0].FactoryNumber;
                SerialNumberTextBox.Text = cashRegisters[0].SerialNumber;
                PaymentNumberTextBox.Text = cashRegisters[0].PaymentNumber;
                HolderComboBox.SelectedValue = cashRegisters[0].Holder;
                UserComboBox.SelectedValue = cashRegisters[0].User;
                DateReceptionCalendarDatePicker.Date = cashRegisters[0].DateReception;
                LocationTextBox.Text = cashRegisters[0].Location;
                SelectData = "UPDATE";
            }
        }
    }
}
