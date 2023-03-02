using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Server_CRM_Framework.Models
{
    public class JsonSanitizer
    {
        //defines Bson functions to remove from JSON, seems easier than to deal with extended JSON in javacript
        //I I wont be doing that, ever, it introduces unecessary complexity
        //helper internal class 
        class remove
        {
            public string name;
            public Boolean number;
            public remove(string name, Boolean number)
            {
                this.name = name;
                this.number = number;
            }
        }
        //Bson type identifier to remove, name and if it is numeric
        static remove[] toRemove = new remove[]{
            new remove("ObjectId",false),
            new remove("NumberDecimal",true),
            new remove("Timestamp",true)
        };

        //Does the sanitization of that dirt json from the toJson that the driver provides
        static public string sanitizeJson(string doc)
        {
            foreach(remove str in toRemove)
            { 
                doc = Regex.Replace(doc, str.name + @"(\()+\""(.*?)\""+(\))", new MatchEvaluator(delegate (Match match) { return RegexReadTermF(match, str.number); }));
            }
            return doc;
        }
        static string RegexReadTermF(Match m, Boolean number)
        {
            if (!number)
            {
                return "\""+m.Groups[2].Value+ "\"";
            }
            return m.Groups[2].Value;
        }
    }
}
