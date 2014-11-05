using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
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
        private CloudQueueClient cloudQueueClient;
        private CloudBlobClient cloudBlobClient;
        private CloudTableClient cloudTableClient;

        public CloudQueue TestQueue
        {
            get
            {
                var queue = cloudQueueClient.GetQueueReference(Properties.Settings.Default.TestQueueName);
                queue.CreateIfNotExists();
                return queue;
            }
        }

        public CloudTable TestTable
        {
            get
            {
                var table = cloudTableClient.GetTableReference(Properties.Settings.Default.TestTableName);
                table.CreateIfNotExists();
                return table;
            }
        }

        public CloudStorageAccount TestStorageAccount
        {
            get
            {
                return cloudStorageAccount;
            }
        }

        public CloudQueueClient TestQueueClient 
        { 
            get
            {
                return cloudQueueClient;
            }
        }

        public CloudBlobClient TestBlobClient
        {
            get
            {
                return cloudBlobClient;
            }
        }

        public CloudTableClient TestTableClient
        {
            get
            {
                return cloudTableClient;
            }
        }

        private AzureSettings()
        {
            cloudStorageAccount = new CloudStorageAccount(new StorageCredentials(Properties.Settings.Default.StorageAccountName, Properties.Settings.Default.PrimaryAccessKey), true);
            cloudQueueClient = cloudStorageAccount.CreateCloudQueueClient();
            cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
        }

        public static AzureSettings Instance()
        {
            if (_instance == null)
                _instance = new AzureSettings();
            return _instance;
        }
    }
}
