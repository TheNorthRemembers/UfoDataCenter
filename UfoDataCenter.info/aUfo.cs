using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UfoDB;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver;
namespace UfoDataCenter.info
{
    /// <summary>
    /// Abstract class with properties/methods for all collection data.
    /// </summary>
    public abstract partial class aUfo
    {   
        //constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="aUfo"/> class.
        /// </summary>
        /// <param name="c_name">The active collection name.</param>
        protected aUfo(string c_name)
        {
            this._activeCollection = this.reportCollections.Where(x => x.name == c_name).SingleOrDefault();
            this.perPage = 12;
        }
        /// <summary>
        /// Gets a random UfoDoc.
        /// </summary>
        /// <returns>UfoDoc</returns>
        public abstract UfoDoc GetRandom();
        /// <summary>
        /// Gets the count of all documents in the active collection.
        /// Exposed in public doc_count propery.
        /// </summary>
        /// <returns>int</returns>
        protected abstract int GetCount();
        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="Nth">The NTH.</param>
        /// <returns></returns>
        public abstract UfoDoc GetSingle(int Nth);
        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public abstract UfoDoc GetSingle(BsonObjectId id);
        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public abstract UfoDoc GetPage(int page);
        /// <summary>
        /// Gets the by search.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public abstract UfoDoc GetBySearch(UfoDoc criteria, int page);        
         
    }

    public class UfoError
    {
        public UfoError(string message)
        {
            error = message;
        }
        public static string UfoErrorResponse(string message)
        {
            return new UfoError(message).ToJson();
        }
        public string error;

    }


}
