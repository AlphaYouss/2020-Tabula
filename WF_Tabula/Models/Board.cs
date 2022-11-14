using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WF_Tabula.Models
{
    public class Board
    {
        public int id { get; set; }
        public string name { get; set; }
        public types type { get; set; }
        public enum types
        {
            Personal = 0,
            Project = 1
        }
        public ReadOnlyCollection<List> lists { get; set; }
        public DateTime createdAt { get; set; }
    }
}