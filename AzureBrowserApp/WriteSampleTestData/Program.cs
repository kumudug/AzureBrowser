using Autofac;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteSampleTestData
{
    class Program
    {
        static void Main(string[] args)
        {
            var tblRows = Util.GetTableEntities(10);
            
            var builder = new ContainerBuilder();
            builder.RegisterInstance(tblRows).As<List<SampleTableEntity>>();
            builder.RegisterInstance(AzureSettings.Instance()).As<AzureSettings>().SingleInstance();
            builder.RegisterInstance(Console.Out).As<TextWriter>().ExternallyOwned();
            builder.Register(c => new WriteSampleData(c.Resolve<AzureSettings>(), c.Resolve<TextWriter>()));

            using(var container = builder.Build())
            {
                container.Resolve<WriteSampleData>().WriteSampleTableData(container.Resolve<List<SampleTableEntity>>());
            }

            Console.ReadKey();
        }
    }
}
