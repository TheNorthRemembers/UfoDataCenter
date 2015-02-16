using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UfoDataCenter.info;
using MongoDB.Bson;

namespace API.Controllers
{
    public class RecordController : ApiController
    {
        // GET record/{id}
        // Either record by #
        // or record by object id
        public string Get(string id)
        {
            UfoText vw = new UfoText("uforeports");
            UfoDoc doc = null;
            int results;
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
                    break;
                case false:
                    try
                    {
                        BsonObjectId _id = new BsonObjectId(new ObjectId(id));
                        doc = vw.GetSingle(_id);
                        break;
                    }
                    catch (Exception e)
                    {
                        return UfoError.UfoErrorResponse("Please supply an integer or valid BSON ID");
                    }
            }
            return doc.ToJson();
        }

        

        // POST record/{page}/{perpage}
        // FORM data: collection:"collection"
        public string Post([FromBody]string collection, int perpage, int page )
        {
            UfoText vw;

            try
            {
                vw = new UfoText(collection);
            }
            catch (Exception e)
            {
                 return UfoError.UfoErrorResponse("Invalid collection name.");
            }

            if (perpage != 0)
                vw.perPage = perpage;

            UfoDoc doc = vw.GetPage(page);

            return doc.ToJson();
        }

       
    }
}