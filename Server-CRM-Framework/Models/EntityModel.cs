using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_CRM_Framework.Models
{
    /// <summary>
    /// Model objects for the entity list
    /// </summary>
    public class Entities
    {
        public string name;
        public string localizedName;
        public string image;
        public string principalPropriety;
        public proprieties[] proprieties;
        public tables[] tables;
    }
    public class proprieties
    {
        public string name;
        public string localizedName;
        public string Type;
        public string image;
        public int coolSize;
        public Boolean unique;
        public Boolean required;
        public Boolean exposition;
        public Object[] dataArray;
    }
    public class tables
    {
        public string condiditons;
        public Boolean isEqual;
        public string name;
        public string localizedName;
        public string[] display;
    }

}
