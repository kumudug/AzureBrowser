using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteSampleTestData
{
    public class Util
    {
        public static List<SampleTableEntity> GetTableEntities(int rowCount)
        {
            List<SampleTableEntity> tblEntityList = new List<SampleTableEntity>();

            for (int i = 0; i < rowCount; i++)
            {
                var entity = new SampleTableEntity(int.MaxValue - i, double.MaxValue - i, "value-" + i.ToString());
                tblEntityList.Add(entity);
            }

            return tblEntityList;
        }
    }
}
