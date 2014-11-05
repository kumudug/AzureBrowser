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
        /// <summary>
        /// Gets all rows [maximum 500]
        /// </summary>
        /// <returns>IEnumerable<TableEntity> list of rows</returns>
        [Route("api/azuretable/{tableName}/getallrows")]
        public IEnumerable<TableEntity> GetTableEntities(string tableName)
        {
            return null;
        }

        /// <summary>
        /// Returns a subset of table rows
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="pageSize">page size</param>
        /// <param name="pageNo">page number</param>
        /// <returns>IEnumerable<TableEntity> list of rows</returns>
        [Route("api/azuretable/{tableName}/{pageSize:int=20}/{pageNo:int=0}")]
        public IEnumerable<TableEntity> GetTableEntities(string tableName, int pageSize, int pageNo)
        {
            return null;
        }

        /// <summary>
        /// Returns a list of all tables in the azure table storage
        /// </summary>
        /// <returns>IEnumerable<string> of table names</returns>
        [Route("api/azuretable/getalltables")]
        public IEnumerable<string> GetAllTables()
        {
            return null;
        }

        /// <summary>
        /// Returns the number of rows of the given table
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <returns>number or rows in table</returns>
        [Route("api/azuretable/{tableName}")]
        public int GetTableRowCount(string tableName)
        {
            return 0;
        }
    }
}
