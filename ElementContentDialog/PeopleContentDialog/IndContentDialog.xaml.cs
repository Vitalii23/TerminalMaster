using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using TerminalMaster.Model.People;
using TerminalMaster.ViewModel;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace TerminalMaster.ElementContentDialog.PeopleContentDialog
{
    public sealed partial class indContentDialog : ContentDialog
    {
        private AddElement add = new AddElement();
        private UpdateElement update = new UpdateElement();
        private GetElement get = new GetElement();
        private Regex regex = new Regex(@"([A-Za-z0-9-\])}[{(,=/~`@!#№;%$:^&?*_|><\\\s]+)");

        public indContentDialog()
        {
            InitializeComponent();
        }

        public string SelectData { get; set; }
        public int SelectIndex { get; set; }

        public string People { get; set; }
        internal ObservableCollection<IndividualEntrepreneur> SelectInd { get; set; }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string[] ie = { FirstNameTextBox.Text, LastNameTextBox.Text, MiddleNameTextBox.Text, PSRNIETextBox.Text, TINTextBox.Text, };

            if (SelectData.Equals("ADD")) { add.AddDataElement((App.Current as App).ConnectionString, ie, People); }

            if (SelectData.Equals("UPDATE")) { update.UpdateDataElement((App.Current as App).ConnectionString, ie, SelectIndex, People); }

            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            MiddleNameTextBox.Text = string.Empty;
            PSRNIETextBox.Text = string.Empty;
            TINTextBox.Text = string.Empty;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            MiddleNameTextBox.Text = string.Empty;
            PSRNIETextBox.Text = string.Empty;
            TINTextBox.Text = string.Empty;
        }

        private void FirstNameTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            FirstNameTextBox.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(FirstNameTextBox.Text);
            FirstNameTextBox.Text = regex.Replace(FirstNameTextBox.Text, "");
        }

        private void LastNameTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            LastNameTextBox.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(LastNameTextBox.Text);
            LastNameTextBox.Text = regex.Replace(LastNameTextBox.Text, "");
        }

        private void MiddleNameTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            MiddleNameTextBox.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(MiddleNameTextBox.Text);
            MiddleNameTextBox.Text = regex.Replace(MiddleNameTextBox.Text, "");
        }

        private void PSRNIE_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void TIN_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            if (People.Equals("ie"))
            {
                if (SelectData.Equals("GET"))
                {
                    LastNameTextBox.Text = SelectInd[SelectIndex].LastName;
                    FirstNameTextBox.Text = SelectInd[SelectIndex].FirstName;
                    MiddleNameTextBox.Text = SelectInd[SelectIndex].MiddleName;
                    PSRNIETextBox.Text = SelectInd[SelectIndex].PSRNIE;
                    TINTextBox.Text = SelectInd[SelectIndex].TIN;
                    SelectData = "UPDATE";
                }
            }
        }
    }
}
