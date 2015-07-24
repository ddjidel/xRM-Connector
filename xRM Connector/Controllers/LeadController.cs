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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace xRM_Connector.Controllers
{
    public class Lead
    {
        public string Subject { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public string NoteSubject { get; set; }
        // public string FileName { get; set; }
        // public string MimeType { get; set; }
        // public byte[] Data { get; set; }
    }
    public class LeadController : ApiController
    {
        // GET: api/Lead
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Lead/5
        public string Get(int id)
        {
            return "value";
        }

        public string Post(Lead lead)
        {
            CrmConnection crmConnection = CrmConnection.Parse(ConfigurationManager.ConnectionStrings["SwissDalilDemo"].ConnectionString);
            OrganizationService organizationService = new OrganizationService(crmConnection);
            Guid leadId = new Guid();

            using (organizationService)
            {
                Entity entity = new Entity("lead");
                entity.Attributes["subject"] = lead.Subject;
                entity.Attributes["firstname"] = lead.FirstName;
                entity.Attributes["lastname"] = lead.LastName;

                leadId = organizationService.Create(entity);

                /*
                EntityReference entRef = new EntityReference("lead", leadId);

                Entity note = new Entity("annotation");
                note.Attributes["subject"] = lead.NoteSubject;
                note.Attributes["filename"] = lead.FileName;
                note.Attributes["mimetype"] = lead.MimeType;
                note.Attributes["documentbody"] = Convert.ToBase64String(lead.Data);
                note.Attributes["objectid"] = entRef;

                organizationService.Create(note);
                */
            }

            return leadId.ToString();
        }

        // POST: api/Lead
        // public void Post([FromBody]string value)
        // {
        // }

        // PUT: api/Lead/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Lead/5
        public void Delete(int id)
        {
        }
    }
}
