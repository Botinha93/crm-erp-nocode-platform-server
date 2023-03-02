using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_CRM_Framework.Models
{
    public class ValuesModel
    {
        //define base static connection, mongodb seems to like it open (That is what she ...)
        //Also defines the actions that the controlles will take
        MongoClient dbClient;
        public IMongoDatabase db;
        public static ValuesModel controller;
        private ValuesModel()
        {
            dbClient = new MongoClient("mongodb://localhost:27017");
            db = dbClient.GetDatabase("mydb");
        }
        //senf contained registry
        public static void Init()
        {
            controller = new ValuesModel();
        }
        //difine put operation from controller
        public static void Put(string entity, ExpandoObject json)
        {
            var collection = controller.db.GetCollection<BsonDocument>(entity);
            collection.InsertOne(ExpandoToBson(json));
        }
        //See controller for more
        public static void Update(string entity,string id, ExpandoObject json)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var collection = controller.db.GetCollection<BsonDocument>(entity);
            collection.UpdateOne(filter, new BsonDocument("$set", ExpandoToBson(json)));
        }
        public static void Update(string entity, string[] id, ExpandoObject json)
        {
            var arrayid = new List<ObjectId>();
            foreach (var _id in id)
            {
                arrayid.Add(ObjectId.Parse(_id));
            }
            var filter = Builders<BsonDocument>.Filter.In("_id", id);
            var collection = controller.db.GetCollection<BsonDocument>(entity);
            collection.UpdateMany(filter, new BsonDocument("$set", ExpandoToBson(json)));
        }
        //See controller for more
        public static String get(string entity)
        {
            var filter = Builders<BsonDocument>.Filter.Empty;
            var list = controller.db.GetCollection<BsonDocument>(entity).Find(filter).ToList().ToJson();
            return JsonSanitizer.sanitizeJson(list);
        }
        //See controller for more
        public static String getFilter(string entity, ExpandoObject value, Boolean equal = true)
        {
            
            IList<FilterDefinition<BsonDocument>> filters = new List<FilterDefinition<BsonDocument>>();
            var eqfilter = new BsonDocument();
            foreach (var el in value)
            {
                var element = (System.Text.Json.JsonElement)el.Value;
                FilterDefinition<BsonDocument> cfilter;
                if (element.ValueKind.ToString().Contains("Boolean")){
                    cfilter = Builders<BsonDocument>.Filter.Eq(el.Key, element.GetBoolean());
                } else if(element.ValueKind.ToString().Contains("Number")) {
                    cfilter =Builders<BsonDocument>.Filter.Eq(el.Key, element.GetDecimal());
                }else
                {
                    cfilter = Builders<BsonDocument>.Filter.Regex(el.Key, new BsonRegularExpression(element.ToString(), @"\B"));
                }
                filters.Add(cfilter);
             }
            var filter = Builders<BsonDocument>.Filter.Or(filters);
            if (equal)
            {
                filter = Builders<BsonDocument>.Filter.And(filters);
            }
            if (filters.Count() == 0)
            {
                return get(entity);
            }
            string list = controller.db.GetCollection<BsonDocument>(entity).Find(filter).ToList().ToJson();
            return JsonSanitizer.sanitizeJson(list);
        }
        //See controller for more
        public static String getID(string entity, String[] categoryIds)
        {
            IList<FilterDefinition<BsonDocument>> filters = new List<FilterDefinition<BsonDocument>>();
            foreach (var str in categoryIds)
            {
                filters.Add(Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(str)));
            }
            var list = controller.db.GetCollection<BsonDocument>(entity).Find(Builders<BsonDocument>.Filter.Or(filters)).ToList().ToJson();
            return JsonSanitizer.sanitizeJson(list);
        }
        public static void Delete(string entity, string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var collection = controller.db.GetCollection<BsonDocument>(entity);
            collection.DeleteOne(filter);
        }
        public static void Delete(string entity, string[] id)
        {
            var arrayid = new List<ObjectId>();
            foreach (var _id in id)
            {
                arrayid.Add(ObjectId.Parse(_id));
            }
            var filter = Builders<BsonDocument>.Filter.In("_id", arrayid);
            var collection = controller.db.GetCollection<BsonDocument>(entity);
            collection.DeleteMany(filter);
        }
        //converts ExpandoObject to Bson, the mongo db driver function returns variable : type instead of variable : value
        private static BsonDocument ExpandoToBson(ExpandoObject json)
        {
            var document = new BsonDocument();
            foreach(var prop in json)
            {
                System.Text.Json.JsonElement element = (System.Text.Json.JsonElement)prop.Value;
                if (element.ValueKind.ToString().ToLower().Contains("string"))
                    document.Add(new BsonElement(prop.Key, BsonValue.Create(element.ToString())));
                if ( element.ValueKind.ToString().ToLower().Contains("number"))
                    document.Add(new BsonElement(prop.Key, BsonValue.Create(element.GetDecimal())));
                if (element.ValueKind.ToString().ToLower().Contains("true") || element.ValueKind.ToString().ToLower().Contains("false"))
                {
                    var teste = element.GetBoolean();
                    document.Add(new BsonElement(prop.Key, BsonValue.Create(element.GetBoolean())));
                }
                if (element.ValueKind.ToString().ToLower().Contains("array"))
                {
                    BsonDocument tempdoc = BsonDocument.Parse("{" + prop.Key + ":" + prop.Value.ToString() + "}");
                    document.Add(tempdoc.GetElement(prop.Key));
                }
            }
            return document;
        }
    }
}
