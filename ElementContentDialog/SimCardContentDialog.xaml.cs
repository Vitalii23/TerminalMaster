using System;
using System.Collections.ObjectModel;
using System.Linq;
using TerminalMaster.Model;
using TerminalMaster.Model.People;
using TerminalMaster.ViewModel;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace TerminalMaster.ElementContentDialog
{
    public sealed partial class SimCardContentDialog : ContentDialog
    {

        private AddElement add = new AddElement();
        private UpdateElement update = new UpdateElement();
        private GetElement get = new GetElement();
        private ObservableCollection<IndividualEntrepreneur> individuals;
        private ObservableCollection<CashRegister> cashRegisters;
        private string brand;
        public SimCardContentDialog()
        {
            this.InitializeComponent();

            string[] @operator = { "Билайн", "МТС", "Мегафон", "Теле2" };
            AddComboxItem(@operator, OperatorComboBox);

            individuals = get.GetIndividual((App.Current as App).ConnectionString, "ALL", 0);
            for (int i = 0; i < individuals.Count; i++)
            {
                IndividualEntrepreneurComboBox.Items.Add(individuals[i].LastName + " " + individuals[i].FirstName + " " + individuals[i].MiddleName);
            }

            cashRegisters = get.GetCashRegister((App.Current as App).ConnectionString, "ALL", 0);
            for(int i = 0; i < cashRegisters.Count; i++)
            {
                nameCashRegisterComboBox.Items.Add(cashRegisters[i].NameDevice);
            }

            string[] typeDevice = { "ККМ" };
            AddComboxItem(typeDevice, TypeDeviceComboBox);

            string[] status = { "Нет симки-карты", "Замена", "Сервис", "Истек срок ФН" };
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
            string @operator = (string)OperatorComboBox.SelectedValue;
            string status = (string)StatusComboBox.SelectedValue;
            string typeDevice = (string)TypeDeviceComboBox.SelectedValue;
            int[] Ids = new int[] { individuals[IndividualEntrepreneurComboBox.SelectedIndex].Id};
            string[] simCards = { @operator, IdentNumberTextBox.Text, typeDevice,
                TmsTextBox.Text, IccTextBox.Text, status };

            if (SelectData.Equals("ADD")) { add.AddDataElement((App.Current as App).ConnectionString, simCards, Ids, "simCard"); }

            if (SelectData.Equals("UPDATE")) { update.UpdateDataElement((App.Current as App).ConnectionString, simCards, Ids, SelectIndex, "simCard"); }

            IdentNumberTextBox.Text = string.Empty;
            TmsTextBox.Text = string.Empty;
            IccTextBox.Text = string.Empty;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            IdentNumberTextBox.Text = string.Empty;
            TmsTextBox.Text = string.Empty;
            IccTextBox.Text = string.Empty;
        }

        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            if (SelectData.Equals("GET"))
            {
                ObservableCollection<SimCard> simCards = get.GetSimCard((App.Current as App).ConnectionString, "ONE", SelectIndex);
                nameCashRegisterComboBox.SelectedValue = simCards[0].NameTerminal;
                OperatorComboBox.SelectedValue = simCards[0].Operator;
                IdentNumberTextBox.Text = simCards[0].IdentNumber;
                TypeDeviceComboBox.SelectedValue = simCards[0].TypeDevice;
                TmsTextBox.Text = simCards[0].TMS;
                IccTextBox.Text = simCards[0].ICC;
                IndividualEntrepreneurComboBox.SelectedValue = simCards[0].IndividualEntrepreneur;
                StatusComboBox.SelectedValue = simCards[0].Status;
                SelectData = "UPDATE";
            }
        }

        private void IccTextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
    }
}
