using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteSampleTestData
{
    public class SampleTableEntity : TableEntity
    {
        static int rowKey = 0;
        static readonly Guid partKey = Guid.NewGuid();
        public Guid TablePartitionKey { get; set; }

        public static int TableRowKey
        {
            get
            {
                return rowKey++;
            }
            set
            {
                rowKey = value;
            }
        }
        public int IntSample { get; set; }
        public double DoubleSample { get; set; }
        public string StringSample { get; set; }

        //Empty constructor is needed by TableEntity
        public SampleTableEntity()
        {
            TableRowKey = 1;
            this.PartitionKey = partKey.ToString();
            this.RowKey = TableRowKey.ToString();
        }

        public SampleTableEntity(int intSample, double dblSample, string stringSample)
        {
            TableRowKey = 1;
            this.PartitionKey = partKey.ToString();
            this.RowKey = TableRowKey.ToString();
            IntSample = intSample;
            DoubleSample = dblSample;
            StringSample = stringSample;
        }
    }
}
