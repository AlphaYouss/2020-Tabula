using System;
using System.Collections.ObjectModel;

namespace WF_Tabula.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime createdAt { get; set; }
        public ReadOnlyCollection<Board> boards { get; set; }
    }
}