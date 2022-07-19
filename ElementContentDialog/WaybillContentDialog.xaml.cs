using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TerminalMaster.Model;
using TerminalMaster.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TerminalMaster.ElementContentDialog
{
    public sealed partial class WaybillContentDialog : ContentDialog
    {
        AddElement add = new AddElement();
        UpdateElement update = new UpdateElement();
        GetElement get = new GetElement();
        private ObservableCollection<Holder> holders;
        private string pdfFile;
        public WaybillContentDialog()
        {
            InitializeComponent();
            holders = get.GetHolder((App.Current as App).ConnectionString, "ALL", 0);

            for (int i = 0; i < holders.Count; i++)
            {
                HolderComboBox.Items.Add(holders[i].LastName + " " + holders[i].FirstName + " " + holders[i].MiddleName);
            }
        }

        public string SelectData { get; set; }
        public int SelectIndex { get; set; }
        internal ObservableCollection<Waybill> SelectWaybill { get; set; }
        public void AddComboxItem(string[] text, ComboBox combo)
        {
            for (int i = 0; i < text.Length; i++)
            {
                combo.Items.Add(text[i]);
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string holderValue = (string)HolderComboBox.SelectedValue;

            DateTimeOffset? dateTime = DateDocumentCalendarDatePicker.Date;
            string dateDocument = dateTime.Value.Year.ToString() + "-" + dateTime.Value.Month.ToString() + "-" + dateTime.Value.Day.ToString();

            string[] waybills = { NameDocumentTextBox.Text, NumberDocumentTextBox.Text, NumberSuppliersTextBox.Text, dateDocument, FileNameTextblock.Text };
            int[] Ids = new int[] { holders[HolderComboBox.SelectedIndex].Id };

            if (SelectData.Equals("ADD"))
            {

                add.AddDataElement((App.Current as App).ConnectionString, waybills, Ids, pdfFile, "waybill");
            }

            if (SelectData.Equals("UPDATE"))
            {
                update.UpdateDataElement((App.Current as App).ConnectionString, waybills, Ids, SelectIndex, pdfFile, "waybill");
            }

            NameDocumentTextBox.Text = string.Empty;
            NumberDocumentTextBox.Text = string.Empty;
            NumberSuppliersTextBox.Text = string.Empty;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            if (SelectData.Equals("GET"))
            {
                NameDocumentTextBox.Text = SelectWaybill[SelectIndex].NameDocument;
                NumberDocumentTextBox.Text = SelectWaybill[SelectIndex].NumberDocument;
                NumberSuppliersTextBox.Text = SelectWaybill[SelectIndex].NumberSuppliers;
                DateDocumentCalendarDatePicker.Date = SelectWaybill[SelectIndex].DateDocument;
                FileNameTextblock.Text = SelectWaybill[SelectIndex].FileName;
                HolderComboBox.SelectedValue = SelectWaybill[SelectIndex].Holder;
                SelectData = "UPDATE";
            }
        }

        private async void FilePDF_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".pdf");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                pdfFile = "(SELECT * FROM  OPENROWSET(BULK '" + file.Path + "', SINGLE_BLOB) AS file_pdf)";
                FileNameTextblock.Text = file.Name;
            }
        }
    }
}
