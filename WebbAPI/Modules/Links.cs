namespace WebbAPI.Modules
{
    public class Links
    {
        public int Id { get; set; }
        public string Link { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public int InterestId { get; set; }

        public PersonInterests PersonInterests { get; set; } = null!;
    }
}
