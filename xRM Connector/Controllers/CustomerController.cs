using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;

namespace xRM_Connector.Controllers
{
    public class Customer
    {
        public string Name { get; set; }
    }
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/5
        // public string Get(int id)
        // {
        //     return "value";
        // }
        public string Get(string Name, string sfdcId)
        {
            CrmConnection crmConnection = CrmConnection.Parse(ConfigurationManager.ConnectionStrings["SwissDalilDemo"].ConnectionString);
            OrganizationService organizationService = new OrganizationService(crmConnection);
            Guid accountId = new Guid();

            using (organizationService)
            {
                Entity entity = new Entity("account");
                entity.Attributes["name"] = Name;
                entity.Attributes["new_sfdcid"] = sfdcId;

                accountId = organizationService.Create(entity);
            }

            return accountId.ToString();
        }
        public string Post(Customer customer)
        {
            CrmConnection crmConnection = CrmConnection.Parse(ConfigurationManager.ConnectionStrings["SwissDalilDemo"].ConnectionString);
            OrganizationService organizationService = new OrganizationService(crmConnection);
            Guid accountId = new Guid();

            using (organizationService)
            {
                Entity entity = new Entity("account");
                entity.Attributes["name"] = customer.Name;

                accountId = organizationService.Create(entity);
            }

            return accountId.ToString();
        }

        // POST: api/Customer
        // public void Post([FromBody]string value)
        // {
        // }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
