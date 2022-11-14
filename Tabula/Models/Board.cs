using System;
using System.Collections.Generic;

namespace ASP_Tabula.Models
{
    public class Board
    {
        // Board properties

        public int id { get; set; }
        public string name { get; set; }
        public types type { get; set; }
        public enum types
        {
            Personal = 0,
            Project = 1
        }
        public IReadOnlyCollection<List> lists { get; set; }
        public DateTime createdAt { get; set; }
    }
}