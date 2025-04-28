using System.ComponentModel.DataAnnotations;

namespace WebbAPI.Modules
{
    public class PersonInterests
    {
        public int PersonId { get; set; }

        public Person Person { get; set; } = null!;

        public int InterestId { get; set; }
        public Interests Interest { get; set; } = null!;

        public ICollection<Links> Links { get; set; } = new List<Links>();
    }
}
