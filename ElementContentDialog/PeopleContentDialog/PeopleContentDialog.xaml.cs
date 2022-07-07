using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using TerminalMaster.Model;
using TerminalMaster.ViewModel;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace TerminalMaster.ElementContentDialog.PeopleContentDialog
{
    public sealed partial class PeopleContentDialog : ContentDialog
    {
        private AddElement add = new AddElement();
        private UpdateElement update = new UpdateElement();
        private GetElement get = new GetElement();
        private Regex regex = new Regex(@"([A-Za-z0-9-\])}[{(,=/~`@!#№;%$:^&?*_|><\\\s]+)");
        public PeopleContentDialog()
        {
            this.InitializeComponent();
            string[] status = { "Рабочий", "Уволен", "Стажировка" };
            AddComboxItem(status, StatusComboBox);
        }
        public void AddComboxItem(string[] text, ComboBox combo)
        {
            for (int i = 0; i < text.Length; i++)
            {
                combo.Items.Add(text[i]);
            }
        }
        public string SelectData { get; set; }
        public int SelectIndex { get; set; }
        public string People { get; set; }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string statusValue = (string)StatusComboBox.SelectedValue;
            string[] peoples = { LastNameTextBox.Text, FirstNameTextBox.Text, MiddleNameTextBox.Text, statusValue};

            if (SelectData.Equals("ADD")) { add.AddDataElement((App.Current as App).ConnectionString, peoples, People); }

            if (SelectData.Equals("UPDATE")) { update.UpdateDataElement((App.Current as App).ConnectionString, peoples, SelectIndex, People); }

            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            MiddleNameTextBox.Text = string.Empty;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
           
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

        private void PeopleContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            if (People.Equals("holder")) 
            {
                PeopleCD.Title = "Владельцы";
                if (SelectData.Equals("GET"))
                {
                    ObservableCollection<Holder> holders = get.GetHolder((App.Current as App).ConnectionString, "ONE", SelectIndex);
                    LastNameTextBox.Text = holders[0].LastName;
                    FirstNameTextBox.Text = holders[0].FirstName;
                    MiddleNameTextBox.Text = holders[0].MiddleName;
                    StatusComboBox.SelectedValue = holders[0].Status;
                    SelectData = "UPDATE";
                }
            }

            if (People.Equals("user"))
            {
                PeopleCD.Title = "Пользователи";
                if (SelectData.Equals("GET"))
                {
                    ObservableCollection<User> user = get.GetUser((App.Current as App).ConnectionString, "ONE", SelectIndex);
                    LastNameTextBox.Text = user[0].LastName;
                    FirstNameTextBox.Text = user[0].FirstName;
                    MiddleNameTextBox.Text = user[0].MiddleName;
                    StatusComboBox.SelectedValue = user[0].Status;
                    SelectData = "UPDATE";
                }
            }
        }
    }
}
