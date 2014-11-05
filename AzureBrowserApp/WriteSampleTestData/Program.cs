using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteSampleTestData
{
    class Program
    {
        static void Main(string[] args)
        {
            var tblRows = Util.GetTableEntities(1000);
            //AzureSettings.i

            var builder = new ContainerBuilder();
            builder.RegisterInstance(tblRows).As<List<SampleTableEntity>>();
            builder.RegisterInstance(AzureSettings.Instance()).As<AzureSettings>().SingleInstance();

            Console.ReadKey();
        }
    }
}
