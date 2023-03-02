using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_CRM_Framework.Models
{
    public class UserModel
    {
        //models the global user registry, users are store in the db but dont get querryed in execution time.
        public static IDictionary<string, UserModel> registry = new Dictionary<string, UserModel>();
        public string name;
        public string pass;
        public string image;
        public string email;
        public GroupModel group;
        public string _id;
         public UserModel(string user, string pass, string _id, GroupModel group)
        {
            this.name = user;
            this.pass = pass;
            this._id = _id;
            this.group = group;
        }
        UserModel(string user, string pass, GroupModel group)
        {
            this.name = user;
            this.pass = pass;
            this.group = group;
        }
        //restores db from resistence
        public static void InitUserDB()
        {
            registry = JsonConvert.DeserializeObject<IList<UserModel>>(ValuesModel.get("users")).ToDictionary(p => p.name);
        }
        //Registering new user from home controller
        public static void addUser(string user, string pass, string groupName)
        {
            var collection = ValuesModel.controller.db.GetCollection<BsonDocument>("users");
            var group = GroupModel.getGroup(groupName);
            if (group != null)
            {
                var newUser = new UserModel(user, pass, group);
                registry.Add(user, newUser);
                var b = BsonDocument.Parse(JsonConvert.SerializeObject(newUser));
                b.Remove("_id");
                collection.InsertOne(b);
            }
            InitUserDB();
        }
        //teste if the token is real and still valid
        public static Boolean userLogued(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                token = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                string[] pu = token.Split(',');
                if (pu.Length>2 && userExists(pu[1]) && registry[pu[1]].pass == pu[0] && DateTime.Now.Day+"" == pu[2])
                {
                    return true;
                }
            }
            return false;
        }
        //decodes token and returns the respective user
        public static UserModel getUserFromToken(string token)
        {
            token = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            string[] pu = token.Split(',');
            if (pu.Length > 2 && userExists(pu[1]) && registry[pu[1]].pass == pu[0] && DateTime.Now.Day + "" == pu[2])
            {
                return registry[pu[1]];
            }
            return null;
        }
        //handles loggin users in to the system. creates token and returns it
        public static string logUserIn(string name, string pass)
        {
            if(userExists(name) && registry[name].pass == pass)
            {
                string token = registry[name].pass+","+registry[name].name+","+ DateTime.Now.Day;
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            }
            return "Invalid";
        }
        //helper function tests if a user exists
        static Boolean userExists(string name)
        {
            if (registry.ContainsKey(name))
                return true;
            return false;
        }
    }
}
