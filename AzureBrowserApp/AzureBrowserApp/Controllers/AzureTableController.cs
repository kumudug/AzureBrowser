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
        /// <returns></returns>
        [Route("api/azuretable/getallrows")]
        public IEnumerable<TableEntity> GetTableEntities()
        {
            return null;
        }

        [Route("api/azuretable/{pageSize:int=20}/{pageNo:int=0}")]
        public IEnumerable<TableEntity> GetTableEntities(int pageSize, int pageNo)
        {
            return null;
        }
    }
}
