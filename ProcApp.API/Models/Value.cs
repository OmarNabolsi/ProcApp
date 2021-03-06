using System;
using System.Collections.Generic;

namespace ProcApp.API.Models
{
    public class Value
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<ValuePhoto> Photos { get; set; }
    }
}