using System;
using System.Collections.ObjectModel;

namespace WF_Tabula.Models
{
    public class List
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public string name { get; set; }
        public ReadOnlyCollection<Card> cards { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}