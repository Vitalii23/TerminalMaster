using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using TerminalMaster.Model;
using TerminalMaster.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace TerminalMaster.ElementContentDialog
{
    public sealed partial class PhoneBookContentDialog : ContentDialog
    {
        private AddElement add = new AddElement();
        private UpdateElement update = new UpdateElement();
        private GetElement get = new GetElement();
        private Regex regex = new Regex(@"([A-Za-z0-9-\])}[{(,=\/~`@!#+№;%$:^&?*_|><\\\s]+)");
        public PhoneBookContentDialog()
        {
            this.InitializeComponent();
        }
        public string SelectData { get; set; }
        public int SelectIndex { get; set; }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string[] phoneBooks = { FirstNameTextBox.Text, LastNameTextBox.Text, MiddleNameTextBox.Text,
                PostTextBox.Text, LocationTextBox.Text, MobileNumberTextBox.Text};

            if (SelectData.Equals("ADD")) { add.AddDataElement((App.Current as App).ConnectionString, phoneBooks, "phoneBook"); }

            if (SelectData.Equals("UPDATE")) { update.UpdateDataElement((App.Current as App).ConnectionString, phoneBooks, SelectIndex, "phoneBook"); }

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

        /// <summary>
        /// TextChanging: writes with a capital letter, remove space firstname, lastname, middlename
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
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

        private void PostTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            Regex regexPost = new Regex(@"([A-Z2-9\])}[{(,=\/~`@!#+№;%$:^&?*_|><\\]+)");
            PostTextBox.Text = regexPost.Replace(PostTextBox.Text, "");
        }

        private void LocationTextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
    }
}