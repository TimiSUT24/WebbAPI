using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using WebbAPI.Data;
using WebbAPI.Modules;

namespace WebbAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly SystemDbContext _context;

        public PersonController(SystemDbContext context)
        {
            _context = context; 
        }

        [HttpGet(Name = "GetAllPersons")]  

        public async Task<ActionResult<ICollection<Person>>> GetAllPersons()//Returns ICollection of Person so a list of people
        {
            var persons = await _context.Persons        // ActionResult allows us to return HTTP responses with data and status codes
                .Select(s => new
                {
                    s.Firstname,
                    s.Lastname,
                    s.Phone,
                    
                })
                .ToListAsync();

            if (persons == null) return NotFound();

            return Ok(persons);
        }
     
        [HttpGet("Interest-by-person", Name = "GetInterest")]
        public async Task<ActionResult<Person>> GetInterest(string firstname) // Returns a person with their interests 
        {
            var person = await _context.Persons
                 .Where(p => p.Firstname == firstname)
                .Select(s => new
                {
                    s.Firstname,
                    PersonsInterest = s.PersonInterests.Select(pi => new
                    {
                        pi.Interest,
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpGet("Links-by-person", Name = "GetLinksByPerson")]

        public async Task<ActionResult<Links>> GetLinks(string firstname) //Get all links for a specific person 
        {
            var person = await _context.Persons
                .Where(p => p.Firstname == firstname)
                .Select(p => new
                {
                    p.Firstname,
                    PersonInterest = p.PersonInterests.Where(pi => pi.Links != null && pi.Links.Count != 0)
                    .SelectMany(pi => pi.Links)
                    .Where(l => !string.IsNullOrEmpty(l.Link))
                    .ToList(),
                   
                }).FirstOrDefaultAsync();

            if (person == null) return NotFound();

            return Ok(person); 
        }

        [HttpPut("JoinInterestToPerson", Name = "AddInterest")]

        public async Task<ActionResult<Person>> AddInterestToPerson(string firstname, string interest, string description)
        {
            var person = await _context.Persons                     //Add new interest to a person
                .Where(p => p.Firstname == firstname)
                .Select(p => new
                {
                    p.Firstname,
                    p.Id,
                }).FirstOrDefaultAsync();
               
                if (person == null)
                {
                   return NotFound();
                }

            var interests = await _context.Interests
                .FirstOrDefaultAsync(i => i.Interest == interest);

            if(interests == null)
            {
                interests = new Interests { Interest = interest, Description = description };
                _context.Interests.Add(interests);
                await _context.SaveChangesAsync();
                
            }
            var personInterest = new PersonInterests
            {            
                PersonId = person.Id,
                Interest = interests,
            };
            _context.PersonInterests.Add(personInterest);
            await _context.SaveChangesAsync();
            return Ok($" Id: {interests.Id}\n Interest: {interests.Interest}\n Description: {interests.Description}"); 
        }

        [HttpPost("NewLinks", Name = "NewLinkForPerson")]

        public async Task<ActionResult<Person>> AddLinkForPerson( string firstname, string interest, string url)
        {
            var person = await _context.Persons
                .FirstOrDefaultAsync(p => p.Firstname == firstname);        //Add new links to a person and interest 

            if (person == null) { return NotFound(); }

            var interests = await _context.Interests
                .FirstOrDefaultAsync(i => i.Interest == interest);

            if (interests == null) { return NotFound(); }     
                   
                var link = new Links
                {
                    PersonId = person.Id,
                    InterestId = interests.Id,
                    Link = url
                };
                _context.Links.Add(link);
                await _context.SaveChangesAsync();
            

            return Ok(link);
        }
    }
}
