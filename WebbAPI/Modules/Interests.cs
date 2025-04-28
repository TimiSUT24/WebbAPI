namespace WebbAPI.Modules
{
    public class Interests
    {
        public int Id { get; set; }
        public string Interest { get; set; } = string.Empty;
        public string ?Description { get; set; }

        public ICollection<PersonInterests> PersonInterests { get; set; } = new List<PersonInterests>();

    }
}
