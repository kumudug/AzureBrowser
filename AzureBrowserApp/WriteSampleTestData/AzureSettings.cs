using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteSampleTestData
{
    public class AzureSettings
    {
        private static AzureSettings _instance;
        private CloudStorageAccount cloudStorageAccount;

        public CloudStorageAccount TestStorageAccount
        {
            get
            {
                return cloudStorageAccount;
            }
        }
        private AzureSettings()
        {
            cloudStorageAccount = new CloudStorageAccount(new StorageCredentials(Properties.Settings.Default.StorageAccountName, Properties.Settings.Default.PrimaryAccessKey), true);
        }

        public static AzureSettings Instance()
        {
            if (_instance == null)
                _instance = new AzureSettings();
            return _instance;
        }
    }
}
