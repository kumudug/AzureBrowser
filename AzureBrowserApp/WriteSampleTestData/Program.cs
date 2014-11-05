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
            var tblRows = Util.GetTableEntities(10);

            var builder = new ContainerBuilder();
            builder.RegisterInstance(tblRows).As<List<SampleTableEntity>>();



            // Open the configuration file and retrieve  
            // the connectionStrings section.
            Configuration config = ConfigurationManager.
                OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);

            //ConnectionStringsSection section = config.GetSection("userSettings") as ConnectionStringsSection;

            ConfigurationSection section = config.GetSection("userSettings/WriteSampleTestData.Properties.Settings");
            //section.SectionInformation.UnprotectSection();
            //section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

            section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");

            // Save the encrypted section.
            section.SectionInformation.ForceSave = true;

            config.Save(ConfigurationSaveMode.Full);


            //if (section.SectionInformation.IsProtected)
            //{
            //    // Remove encryption.
            //    section.SectionInformation.UnprotectSection();
            //}
            //else
            //{
            //    // Encrypt the section.
            //    section.SectionInformation.ProtectSection(
            //        "DataProtectionConfigurationProvider");
            //}
            // Save the current configuration.
            //config.Save();

            Console.WriteLine("Protected={0}",
                section.SectionInformation.IsProtected);


            Console.ReadKey();
        }
    }
}
