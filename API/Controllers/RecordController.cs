using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UfoDataCenter.info;
using MongoDB.Bson;
using Newtonsoft.Json;
namespace API.Controllers
{
    public class RecordController : ApiController
    {
        // GET record/{id}
        // Either record by #
        // or record by object id
        public UfoDoc Get(string id)
        {
            UfoText vw = new UfoText("uforeports");
            UfoDoc doc = null;
            int results;
            List<string> result = new List<string>();
            switch (Int32.TryParse(id, out results))
            {
                case true:
                    doc = vw.GetSingle(results);
                    string nextR = (results < 0) ? "" : (results - 1).ToString();
                    string prevR = (results > vw.doc_count) ? "" : (results + 1).ToString();
                    doc.pageInfo.href = new Href
                    {
                        prevUrl = "record/" + prevR,
                        nextUrl = "record/" + nextR   
                    };

                    //result.Add(JsonConvert.SerializeObject(doc));
                    
                    break;
                case false:
                    try
                    {
                        BsonObjectId _id = new BsonObjectId(new ObjectId(id));
                        doc = vw.GetSingle(_id);
                        //result.Add(JsonConvert.SerializeObject(doc));
                        break;
                    }
                    catch (Exception e)
                    {                        
                        result.Add(JsonConvert.SerializeObject(UfoError.UfoErrorResponse("Please supply an integer or valid BSON ID")));
                        break;
                    }
            }
            return doc;
        }

        

        // POST record/{page}/{perpage}
        // FORM data: collection:"collection"
        public UfoDoc Post([FromBody]string collection, int perpage, int page )
        {
            UfoText vw;

            try
            {
                vw = new UfoText(collection);
            }
            catch (Exception e)
            {
                 return null;
            }

            if (perpage != 0)
                vw.perPage = perpage;

            UfoDoc doc = vw.GetPage(page);

            return doc;
        }

       
    }
}