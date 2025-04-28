using System.ComponentModel.DataAnnotations;

namespace WebbAPI.Modules
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        [Phone]
        public string ?Phone { get; set; }

        // Navigation prop 
        public ICollection<PersonInterests> PersonInterests { get; set; } = new List<PersonInterests>();
    }
}
