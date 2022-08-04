using MongoDB.Bson;
using MongoDB.Driver;

namespace Account.Data.Service.Access
{
    internal class AccountDao<T> where T : class
    {
        /// <summary> 
        /// The MDB Interface.
        /// </summary>
        private readonly IMongoDatabase db;

        /// <summary> 
        /// The Database Name.
        /// </summary>
        private const string db_name = "Account";

        /// <summary> 
        /// The Local Connection String.
        /// </summary>
        private const string localConnectionString = "localhost:27017";

        /// <summary> 
        /// Constructor to take in and Get database.
        /// </summary>
        public AccountDao()
        {
            MongoClient client = new(localConnectionString);
            this.db = client.GetDatabase(db_name);
        }

        /// <summary> 
        /// Load an Object Record from a specified Table.
        /// </summary>
        public List<T> LoadAllRecords(string table)
        {
            IMongoCollection<T> collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        /// <summary> 
        /// Load an Object Record from a specified Table by Guid.
        /// </summary>
        public T LoadRecordById(string table, Guid id)
        {
            IMongoCollection<T> collection = db.GetCollection<T>(table);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).FirstOrDefault();
        }

        /// <summary> 
        /// INSERT an Object Record into specified Table.
        /// </summary>
        public void InsertRecord(string table, T record)
        {
            if (string.IsNullOrEmpty(table) || record == null)
                return;
            else
            {
                IMongoCollection<T> collection = db.GetCollection<T>(table);
                collection.InsertOne(record);
            }
        }

        /// <summary>
        /// UPSERT an Object Record from a specified Table by Guid and T Record.
        /// </summary>
        public void UpsertRecord(string table, Guid id, T record)
        {
            IMongoCollection<T> collection = db.GetCollection<T>(table);
            collection.ReplaceOne(
                new BsonDocument("_id", new BsonBinaryData(id, GuidRepresentation.Standard)),
                record,
                new ReplaceOptions { IsUpsert = true });
        }

        /// <summary>
        /// DELETE an Object Record from a specified Table by Guid.
        /// </summary>
        public void DeleteRecord(string table, Guid id)
        {
            IMongoCollection<T> collection = db.GetCollection<T>(table);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }
    }
}