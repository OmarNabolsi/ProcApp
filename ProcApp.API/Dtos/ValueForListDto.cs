using System;

namespace ProcApp.API.Dtos
{
    public class ValueForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public string PhotoUrl { get; set; }
    }
}