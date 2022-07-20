using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TerminalMaster.Logging;
using TerminalMaster.Model;
using TerminalMaster.ViewModel;
using Windows.UI.Xaml.Controls;

namespace TerminalMaster.ElementContentDialog.PeopleContentDialog
{
    public sealed partial class PeopleContentDialog : ContentDialog
    {
        private AddElement add = new AddElement();
        private UpdateElement update = new UpdateElement();
        private Regex regex = new Regex(@"([A-Za-z0-9-\])}[{(,=/~`@!#№;%$:^&?*_|><\\\s]+)");
        private LogFile logFile = new LogFile();
        public PeopleContentDialog()
        {
            InitializeComponent();
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
        public int SelectId { get; set; }
        public string People { get; set; }
        internal ObservableCollection<User> SelectUser { get; set; }
        internal ObservableCollection<Holder> SelectHolder { get; set; }
        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            try
            {
                string statusValue = (string)StatusComboBox.SelectedValue;
                string[] peoples = { LastNameTextBox.Text, FirstNameTextBox.Text, MiddleNameTextBox.Text, MobileNumberTextBox.Text, statusValue };

                if (SelectData.Equals("ADD")) { add.AddDataElement((App.Current as App).ConnectionString, peoples, People); }

                if (SelectData.Equals("UPDATE")) { update.UpdateDataElement((App.Current as App).ConnectionString, peoples, SelectId, People); }

                FirstNameTextBox.Text = string.Empty;
                LastNameTextBox.Text = string.Empty;
                MiddleNameTextBox.Text = string.Empty;

            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, People + "_ContentDialog_PrimaryButtonClick");
            }
        }
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            MiddleNameTextBox.Text = string.Empty;
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
        private async void PeopleContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            try
            {
                if (People.Equals("holder"))
                {
                    PeopleCD.Title = "Владельцы";
                    if (SelectData.Equals("GET"))
                    {
                        LastNameTextBox.Text = SelectHolder[SelectIndex].LastName;
                        FirstNameTextBox.Text = SelectHolder[SelectIndex].FirstName;
                        MiddleNameTextBox.Text = SelectHolder[SelectIndex].MiddleName;
                        MobileNumberTextBox.Text = SelectHolder[SelectIndex].Number;
                        StatusComboBox.SelectedValue = SelectHolder[SelectIndex].Status;
                        SelectData = "UPDATE";
                    }
                }

                if (People.Equals("user"))
                {
                    PeopleCD.Title = "Пользователи";
                    if (SelectData.Equals("GET"))
                    {
                        LastNameTextBox.Text = SelectUser[SelectIndex].LastName;
                        FirstNameTextBox.Text = SelectUser[SelectIndex].FirstName;
                        MiddleNameTextBox.Text = SelectUser[SelectIndex].MiddleName;
                        MobileNumberTextBox.Text = SelectUser[SelectIndex].Number;
                        StatusComboBox.SelectedValue = SelectUser[SelectIndex].Status;
                        SelectData = "UPDATE";
                    }
                }
            }
            catch (Exception e)
            {
                await logFile.WriteLogAsync(e.Message, People + "_PeopleContentDialog_Opened");
            }

        }
    }
}
