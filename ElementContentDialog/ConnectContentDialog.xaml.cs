using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TerminalMaster.Settings;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace TerminalMaster.ElementContentDialog
{
    public sealed partial class ConnectContentDialog : ContentDialog
    {
        ConnectSQL connectSQL = new ConnectSQL();
        public ConnectContentDialog()
        {
            InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            connectSQL.ConnectWrite(ConectStringTextBox.Text); 
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            connectSQL.ConnectRead();
        }
    }
}
