using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_CRM_Framework.Models
{
    public class GroupModel
    {
        public static List<GroupModel> groups;
        public string name;
        public string _id;
        public IDictionary<string, int> permission = new Dictionary<string, int>();
        public GroupModel(string name)
        {
            this.name = name;
            foreach (var entity in loader.entities)
            {
                permission.Add(entity.name, 7);
            }
        }
        public static void InitGroupDB()
        {
            groups = JsonConvert.DeserializeObject<List<GroupModel>>(ValuesModel.get("groups"));
        }
        public static GroupModel getGroup(string gname)
        {
            foreach(var group in groups)
            {
                if (group.name == gname)
                    return group;
            }
            return null;
        }
        //Registering new group from home controller
        public static void addGroup(string group)
        {
            var collection = ValuesModel.controller.db.GetCollection<BsonDocument>("groups");
            var newG = new GroupModel(group);
            var b = BsonDocument.Parse(JsonConvert.SerializeObject(newG));
            b.Remove("_id");
            collection.InsertOne(b);
            InitGroupDB();
        }
    }
}
