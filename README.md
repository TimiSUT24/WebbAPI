1. Get all people
2. Request Url https://localhost:7122/api/Person
3. Response
```json
[
  {
    "firstname": "Alice",
    "lastname": "Smith",
    "phone": "0701111111"
  },
  {
    "firstname": "Bob",
    "lastname": "Johnson",
    "phone": "0702222222"
  },
```
1. Get all interests for a person
2. Request Url https://localhost:7122/api/Person/Interest-by-person?firstname=Alice
3. Response
```json
{
  "firstname": "Alice",
  "personsInterest": [
    {
      "interest": {
        "id": 1,
        "interest": "Programming",
        "description": "Writing and debugging code.",
        "personInterests": []
      }
    },
    {
      "interest": {
        "id": 2,
        "interest": "Photography",
        "description": "Capturing moments with a camera.",
        "personInterests": []
      }
    },
```
1. Get all links for a person
2. Request Url https://localhost:7122/api/Person/Links-by-person?firstname=Alice
3. Response
```json
{
  "firstname": "Alice",
  "personInterest": [
    {
      "id": 1,
      "link": "https://dev.to/alice",
      "personId": 1,
      "interestId": 1,
      "personInterests": null
    },
    {
      "id": 12,
      "link": "https://simma.nu",
      "personId": 1,
      "interestId": 16,
      "personInterests": null
    },
```
1. Add new interest to a person
2. Request Url https://localhost:7122/api/Person/JoinInterestToPerson?firstname=Grace&interest=MMA&description=Amateur
3. Response
```json
{
 "Id": "19",
 "Interest": "MMA",
 "Description": "Amateur"
}
```
1. Add links to interests for a person
2. Request Url https://localhost:7122/api/Person/NewLinks?firstname=Alice&interest=Programming&url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FComputer_programming
3. Response
```json
{
  "id": 16,
  "link": "https://en.wikipedia.org/wiki/Computer_programming",
  "personId": 1,
  "interestId": 1,
  "personInterests": null
}


