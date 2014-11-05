using AzureBrowserApp.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AzureBrowserApp.Controllers
{
    public class AzureTableController : ApiController
    {
        private static CloudTableClient cloudTableClient;

        static AzureTableController()
        {
            cloudTableClient = new CloudStorageAccount(new StorageCredentials(Properties.Settings.Default.StorageAccountName, Properties.Settings.Default.PrimaryAccessKey), true).CreateCloudTableClient();
        }

        /// <summary>
        /// Gets all rows [maximum 500]
        /// </summary>
        /// <returns>IEnumerable<TableEntity> list of rows</returns>
        [Route("api/azuretable/{tableName}/getallrows")]
        public HttpResponseMessage GetTableEntities(string tableName)
        {
            var query = new TableQuery<ElasticTableEntity>();
            var table = cloudTableClient.GetTableReference(tableName);
            if (!table.Exists())
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError("Table Not Found"));
            }
            var items = table.ExecuteQuery(query).Take(500);
            return Request.CreateResponse(HttpStatusCode.OK, items);
        }

        /// <summary>
        /// Returns a subset of table rows
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="pageSize">page size</param>
        /// <param name="pageNo">page number</param>
        /// <returns>IEnumerable<TableEntity> list of rows</returns>
        [Route("api/azuretable/{tableName}/{pageSize:int=20}/{pageNo:int=0}")]
        public HttpResponseMessage GetTableEntities(string tableName, int pageSize, int pageNo)
        {
            var query = new TableQuery<ElasticTableEntity>();
            var table = cloudTableClient.GetTableReference(tableName);
            if (!table.Exists())
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError("Table Not Found"));
            }
            var items = table.ExecuteQuery(query).Skip(pageSize*pageNo).Take(pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, items);
        }

        /// <summary>
        /// Returns a list of all tables in the azure table storage
        /// </summary>
        /// <returns>IEnumerable<string> of table names</returns>
        [Route("api/azuretable/getalltables")]
        public IEnumerable<string> GetAllTables()
        {
            List<string> tableNames = new List<string>();
            foreach(var table in cloudTableClient.ListTables())
            {
                tableNames.Add(table.Name);
            }
            return tableNames;
        }
        
        /// <summary>
        /// Returns the number of rows of the given table
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <returns>number or rows in table</returns>
        [Route("api/azuretable/{tableName}")]
        public HttpResponseMessage GetTableRowCount(string tableName)
        {
            TableQuery<TableEntity> query = new TableQuery<TableEntity>();
            var table = cloudTableClient.GetTableReference(tableName);
            if(!table.Exists())
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError("Table Not Found"));
            }

            int count = table.ExecuteQuery(query).Count();

            return Request.CreateResponse(HttpStatusCode.OK, count);
        }
    }
}
