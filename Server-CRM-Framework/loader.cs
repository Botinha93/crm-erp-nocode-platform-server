using Newtonsoft.Json;
using Server_CRM_Framework.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Server_CRM_Framework
{
    public class loader
    {
        static public Entities[] entities;
        public static void loade()
        {
            Server_CRM_Framework.Models.CryptoProvider.InitCryptoProvider(@"teste.pfx");
            ValuesModel.Init();
            using (StreamReader file = File.OpenText(@"entitylist.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                entities = (Entities[])serializer.Deserialize(file, typeof(Entities[]));
            }
            Models.UserModel.InitUserDB();
            Models.GroupModel.InitGroupDB();
        }
    }
}
