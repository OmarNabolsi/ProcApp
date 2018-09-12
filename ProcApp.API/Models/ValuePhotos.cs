using System;

namespace ProcApp.API.Models
{
    public class ValuePhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public Value Value { get; set; }
        public int ValueId { get; set; }
    }
}