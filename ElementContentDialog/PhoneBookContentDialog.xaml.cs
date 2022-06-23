using System.Collections.ObjectModel;
using TerminalMaster.Model;
using TerminalMaster.ViewModel;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace TerminalMaster.ElementContentDialog
{
    public sealed partial class PhoneBookContentDialog : ContentDialog
    {
        private AddElement add = new AddElement();
        private UpdateElement update = new UpdateElement();
        private GetElement get = new GetElement();
        public PhoneBookContentDialog()
        {
            this.InitializeComponent();
        }
        public string SelectData { get; set; }
        public int SelectIndex { get; set; }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string[] phoneBooks = { FirstNameTextBox.Text, LastNameTextBox.Text, MiddleNameTextBox.Text,
                PostTextBox.Text, PostTextBox.Text, MobileNumberTextBox.Text};

            if (SelectData.Equals("ADD")) { add.AddDataElement((App.Current as App).ConnectionString, phoneBooks, "phoneBooK"); }

            if (SelectData.Equals("UPDATE")) { update.UpdateDataElement((App.Current as App).ConnectionString, phoneBooks, SelectIndex, "phoneBooK"); }

            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            MiddleNameTextBox.Text = string.Empty;
            PostTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
            MobileNumberTextBox.Text = string.Empty;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            MiddleNameTextBox.Text = string.Empty;
            PostTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
            MobileNumberTextBox.Text = string.Empty;
        }

        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            if (SelectData.Equals("GET"))
            {
                ObservableCollection<PhoneBook> phoneBooks = get.GetPhoneBook((App.Current as App).ConnectionString, "ONE", SelectIndex);
                FirstNameTextBox.Text = phoneBooks[0].FirstName;
                LastNameTextBox.Text = phoneBooks[0].LastName;
                MiddleNameTextBox.Text = phoneBooks[0].MiddleName;
                PostTextBox.Text = phoneBooks[0].Post;
                LocationTextBox.Text = phoneBooks[0].InternalNumber;
                MobileNumberTextBox.Text = phoneBooks[0].MobileNumber;
                SelectData = "UPDATE";
            }

        }
    }
}