using System;
using System.Collections.ObjectModel;
using TerminalMaster.Model;
using TerminalMaster.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage.Pickers;
using TerminalMaster.Logging;
using System.Text;

namespace TerminalMaster.ElementContentDialog
{
    public sealed partial class WaybillContentDialog : ContentDialog
    {
        AddElement add = new AddElement();
        UpdateElement update = new UpdateElement();
        GetElement get = new GetElement();
        private LogFile logFile = new LogFile();
        private ObservableCollection<Holder> holders;
        private string pdfFile;
        public WaybillContentDialog()
        {
            InitializeComponent();
            holders = get.GetHolder((App.Current as App).ConnectionString, "ALL", 0);

            FilePDFButton.IsEnabled = true;

            for (int i = 0; i < holders.Count; i++)
            {
                HolderComboBox.Items.Add(holders[i].LastName + " " + holders[i].FirstName + " " + holders[i].MiddleName);
            }
        }
        public string SelectData { get; set; }
        public int SelectIndex { get; set; }
        public int SelectId { get; set; }
        internal ObservableCollection<Waybill> SelectWaybill { get; set; }
        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            try
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
                    update.UpdateDataElement((App.Current as App).ConnectionString, waybills, Ids, SelectId, "waybill");
                }

                NameDocumentTextBox.Text = string.Empty;
                NumberDocumentTextBox.Text = string.Empty;
                NumberSuppliersTextBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "WaybillContentDialog_ContentDialog_PrimaryButtonClick");
            }
        }
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            NameDocumentTextBox.Text = string.Empty;
            NumberDocumentTextBox.Text = string.Empty;
            NumberSuppliersTextBox.Text = string.Empty;
        }
        private async void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            try
            {
                if (SelectData.Equals("GET"))
                {
                    NameDocumentTextBox.Text = SelectWaybill[SelectIndex].NameDocument;
                    NumberDocumentTextBox.Text = SelectWaybill[SelectIndex].NumberDocument;
                    NumberSuppliersTextBox.Text = SelectWaybill[SelectIndex].NumberSuppliers;
                    DateDocumentCalendarDatePicker.Date = SelectWaybill[SelectIndex].DateDocument;
                    FileNameTextblock.Text = SelectWaybill[SelectIndex].FileName;
                    HolderComboBox.SelectedValue = SelectWaybill[SelectIndex].Holder;
                    FilePDFButton.IsEnabled = false;
                    SelectData = "UPDATE";
                }
            }
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "WaybillContentDialog_ContentDialog_Opened");
            }
            
        }
        private async void FilePDF_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                await logFile.WriteLogAsync(ex.Message, "WaybillContentDialog_ContentDialog_Opened");
            }
        }
    }
}
