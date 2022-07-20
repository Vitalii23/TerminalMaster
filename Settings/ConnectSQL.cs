﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace TerminalMaster.Settings
{
    class ConnectSQL
    {
        private string connectionString =
@"Data Source=KV-149;Initial Catalog=dbTerminalMaster;User ID=dva;Password=Kolizey$;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void ConnectWrite(string connect)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["setting connect"] = "a device specific setting";

            ApplicationDataCompositeValue composite = new ApplicationDataCompositeValue();
            composite["connectionString"] = connect;
            localSettings.Values["Connect"] = composite;
        }

        public void ConnectRead()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

            string localValue = localSettings.Values["setting connect"] as string;

            ApplicationDataCompositeValue composite = (ApplicationDataCompositeValue)localSettings.Values["Connect"];
            if (composite != null)
            {
                (App.Current as App).ConnectionString = composite["connectionString"] as string;
            }
        }
    }
}
