using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using TerminalMaster.Model;
using TerminalMaster.Model.People;
using TerminalMaster.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
        }

        public string SelectData { get; set; }
        public int SelectIndex { get; set; }
        public string people { get; set; }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string[] peoples = { FirstNameTextBox.Text, LastNameTextBox.Text, MiddleNameTextBox.Text};

            if (SelectData.Equals("ADD")) { add.AddDataElement((App.Current as App).ConnectionString, peoples, people); }

            if (SelectData.Equals("UPDATE")) { update.UpdateDataElement((App.Current as App).ConnectionString, peoples, SelectIndex, people); }

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
            if (people.Equals("holder")) 
            {
                PeopleCD.Title = "Владелецы";
                if (SelectData.Equals("GET"))
                {
                    ObservableCollection<Holder> holders = get.GetHolder((App.Current as App).ConnectionString, "ONE", SelectIndex);
                    FirstNameTextBox.Text = holders[0].FirstName;
                    LastNameTextBox.Text = holders[0].LastName;
                    MiddleNameTextBox.Text = holders[0].MiddleName;
                    SelectData = "UPDATE";
                }
            }

            if (people.Equals("user"))
            {
                PeopleCD.Title = "Пользователи";
                if (SelectData.Equals("GET"))
                {
                    ObservableCollection<User> user = get.GetUser((App.Current as App).ConnectionString, "ONE", SelectIndex);
                    FirstNameTextBox.Text = user[0].FirstName;
                    LastNameTextBox.Text = user[0].LastName;
                    MiddleNameTextBox.Text = user[0].MiddleName;
                    SelectData = "UPDATE";
                }
            }

            if(people.Equals("ie"))
            {
                PeopleCD.Title = "Индивидуальные предприниматели";
                if (SelectData.Equals("GET"))
                {
                    ObservableCollection<IndividualEntrepreneur> individual = get.GetIndividual((App.Current as App).ConnectionString, "ONE", SelectIndex);
                    FirstNameTextBox.Text = individual[0].FirstName;
                    LastNameTextBox.Text = individual[0].LastName;
                    MiddleNameTextBox.Text = individual[0].MiddleName;
                    SelectData = "UPDATE";
                }
            }

        }
    }
}
