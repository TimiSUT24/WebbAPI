using Microsoft.EntityFrameworkCore;
using WebbAPI.Modules;

namespace WebbAPI.Data
{
    public class SystemDbContext : DbContext
    {

        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Links> Links => Set<Links>();
        public DbSet<Interests> Interests => Set<Interests>();
        public DbSet<PersonInterests> PersonInterests => Set<PersonInterests>();
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.PersonInterests)
                .WithOne(pi => pi.Person)
                .HasForeignKey(pi => pi.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Interests>()
                .HasMany(i => i.PersonInterests)
                .WithOne(pi => pi.Interest)
                .HasForeignKey(pi => pi.InterestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonInterests>()
                .HasMany(pi => pi.Links)
                .WithOne(l => l.PersonInterests)
                .HasForeignKey(l => new { l.PersonId, l.InterestId })
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<PersonInterests>()
                .HasKey(pi => new {pi.PersonId, pi.InterestId });

            SeedData(modelBuilder);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasData(
                new Person { Id = 1, Firstname = "Alice", Lastname = "Smith", Phone = "0701111111" },
                new Person { Id = 2, Firstname = "Bob", Lastname = "Johnson", Phone = "0702222222" },
                new Person { Id = 3, Firstname = "Clara", Lastname = "Williams", Phone = "0703333333" },
                new Person { Id = 4, Firstname = "David", Lastname = "Brown", Phone = "0704444444" },
                new Person { Id = 5, Firstname = "Ella", Lastname = "Jones", Phone = "0705555555" },
                new Person { Id = 6, Firstname = "Felix", Lastname = "Garcia", Phone= "0706666666" },
                new Person { Id = 7, Firstname = "Grace", Lastname = "Miller", Phone = "0707777777" },
                new Person { Id = 8, Firstname = "Harry", Lastname = "Davis", Phone = "0708888888" },
                new Person { Id = 9, Firstname = "Isla", Lastname = "Martinez", Phone = "0709999999" },
                new Person { Id = 10, Firstname = "Jack", Lastname = "Taylor", Phone = "0701010101" });

            modelBuilder.Entity<Interests>()
                .HasData(
                new Interests { Id = 1, Interest = "Programming", Description = "Writing and debugging code." },
                new Interests { Id = 2, Interest = "Photography", Description = "Capturing moments with a camera." },
                new Interests { Id = 3, Interest = "Cooking", Description = "Making delicious meals." },
                new Interests { Id = 4, Interest = "Gaming", Description = "Playing video games competitively or for fun." },
                new Interests { Id = 5, Interest = "Reading", Description = "Enjoying books and novels." },
                new Interests { Id = 6, Interest = "Music", Description = "Listening to and creating music." },
                new Interests { Id = 7, Interest = "Traveling", Description = "Exploring new places and cultures." },
                new Interests { Id = 8, Interest = "Fitness", Description = "Staying active and healthy." },
                new Interests { Id = 9, Interest = "Gardening", Description = "Growing and taking care of plants." },
                new Interests { Id = 10, Interest = "Technology", Description = "Exploring the latest in tech." });

            modelBuilder.Entity<PersonInterests>()
                .HasData(
                new PersonInterests { PersonId = 1, InterestId = 1 },
                new PersonInterests { PersonId = 1, InterestId = 2 },
                new PersonInterests { PersonId = 1, InterestId = 3 },
                new PersonInterests { PersonId = 2, InterestId = 2 },
                new PersonInterests { PersonId = 3, InterestId = 3 },
                new PersonInterests { PersonId = 4, InterestId = 4 },
                new PersonInterests { PersonId = 5, InterestId = 5 },
                new PersonInterests { PersonId = 6, InterestId = 6 },
                new PersonInterests { PersonId = 7, InterestId = 7 },
                new PersonInterests { PersonId = 8, InterestId = 8 },
                new PersonInterests { PersonId = 9, InterestId = 9 },
                new PersonInterests { PersonId = 10, InterestId = 10 });

            modelBuilder.Entity<Links>()
                .HasData(
                new Links { Id = 1, Link = "https://dev.to/alice", PersonId = 1, InterestId = 1 },
                new Links { Id = 2, Link = "https://unsplash.com/bob", PersonId = 2, InterestId = 2 },
                new Links { Id = 3, Link = "https://recipes.com/clara", PersonId = 3, InterestId = 3 },
                new Links { Id = 4, Link = "https://twitch.tv/davidplays", PersonId = 4, InterestId = 4 },
                new Links { Id = 5, Link = "https://goodreads.com/ella", PersonId = 5, InterestId = 5 },
                new Links { Id = 6, Link = "https://soundcloud.com/felix", PersonId = 6, InterestId = 6 },
                new Links { Id = 7, Link = "https://travelblog.com/grace", PersonId = 7, InterestId = 7 },
                new Links { Id = 8, Link = "https://fitgram.com/harry", PersonId = 8, InterestId = 8 },
                new Links { Id = 9, Link = "https://gardenershub.com/isla", PersonId = 9, InterestId = 9 },
                new Links { Id = 10, Link = "https://techtrends.com/jack", PersonId = 10, InterestId = 10 });
        }
    }
}
