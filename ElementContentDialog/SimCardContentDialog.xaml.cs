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
        public SimCardContentDialog()
        {
            this.InitializeComponent();

            string[] @operator = { "Билайн", "МТС", "Мегафон", "Теле2" };
            AddComboxItem(@operator, OperatorComboBox);

            string[] individualEntrepreneur = { "Клязьмина Марина Юрьевна", "Волков Михайл Михалович"};
            AddComboxItem(individualEntrepreneur, IndividualEntrepreneurComboBox);

            string[] brend = { "AZUR", "MSPOS" };
            AddComboxItem(brend, BrendComboBox);

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
            string individualEntrepreneur = (string)IndividualEntrepreneurComboBox.SelectedValue;
            string typeDevice = (string)TypeDeviceComboBox.SelectedValue;
            string brend = (string)BrendComboBox.SelectedValue;
            string[] simCards = { @operator, IdentNumberTextBox.Text, brend, typeDevice,
                TmsTextBox.Text, IccTextBox.Text, individualEntrepreneur, status };

            if (SelectData.Equals("ADD")) { add.AddDataElement((App.Current as App).ConnectionString, simCards, "simCard"); }

            if (SelectData.Equals("UPDATE")) { update.UpdateDataElement((App.Current as App).ConnectionString, simCards, SelectIndex, "simCard"); }

            IdentNumberTextBox.Text = string.Empty;
            TmsTextBox.Text = string.Empty;
            IccTextBox.Text = string.Empty;
            IndividualEntrepreneurComboBox.Text = string.Empty;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            IdentNumberTextBox.Text = string.Empty;
            TmsTextBox.Text = string.Empty;
            IccTextBox.Text = string.Empty;
            IndividualEntrepreneurComboBox.Text = string.Empty;
        }

        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            if (SelectData.Equals("GET"))
            {
                ObservableCollection<SimCard> cashRegisters = get.GetSimCard((App.Current as App).ConnectionString, "ONE", SelectIndex);
                ObservableCollection<IndividualEntrepreneur> individuals = get.GetIndividual((App.Current as App).ConnectionString, "ONE", SelectIndex);
                OperatorComboBox.SelectedValue = cashRegisters[0].Operator;
                IdentNumberTextBox.Text = cashRegisters[0].IdentNumber;
                BrendComboBox.SelectedValue = cashRegisters[0].Brend;
                TypeDeviceComboBox.SelectedValue = cashRegisters[0].TypeDevice;
                string tms = Convert.ToString(cashRegisters[0].TMS);
                string icc = Convert.ToString(cashRegisters[0].ICC);
                TmsTextBox.Text = tms;
                IccTextBox.Text = icc;
                IndividualEntrepreneurComboBox.SelectedValue = cashRegisters[0].IndividualEntrepreneur;
                StatusComboBox.SelectedValue = cashRegisters[0].Status;
                SelectData = "UPDATE";
            }
        }

        private void IccTextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
    }
}
