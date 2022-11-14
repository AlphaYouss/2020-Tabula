using System;
using System.Collections.Generic;

namespace ASP_Tabula.Models
{
    public class List
    {
        // List properties

        public int id { get; set; }
        public int orderID { get; set; }
        public string name { get; set; }
        public IReadOnlyCollection<Card> cards { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}