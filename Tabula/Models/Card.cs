using System;

namespace ASP_Tabula.Models
{
    public class Card
    {
        // Card properties

        public int id { get; set; }
        public int orderID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Priorities priority { get; set; }
        public enum Priorities
        {
            Critical = 0,
            Important = 1,
            Normal = 2,
            Low = 3,
            None = 4
        }
        public DateTime? deadline { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}