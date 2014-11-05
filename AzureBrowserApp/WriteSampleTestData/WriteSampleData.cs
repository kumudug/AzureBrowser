using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteSampleTestData
{
    public class WriteSampleData
    {
        private AzureSettings _settings;
        private TextWriter _log;

        public WriteSampleData(AzureSettings settings, TextWriter Log)
        {
            _settings = settings;
            _log = Log;
        }

        public void WriteSampleTableData(List<SampleTableEntity> entities)
        {
            TableBatchOperation insertOperation = new TableBatchOperation();

            foreach(var entity in entities)
            {
                insertOperation.Insert(entity);
            }

            try
            {
                var result = _settings.TestTable.ExecuteBatch(insertOperation);
                _log.WriteLine(string.Format("Wrote {0} items into {1} table", result.Count, _settings.TestTable.Name));
            }
            catch (StorageException ex)
            {
                _log.WriteLine(string.Format("Error when writing to table {0} : {1}", _settings.TestTable.Name, ex.Message));
            }
        }
    }
}
