using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;

namespace RazorPages.Pages
{
    public class PersonModel : PageModel
    {
        List<Person> people;
        public List<Person> DisplayedPeople { get; set; }
        public PersonModel()
        {
            people = new List<Person>()
            {
                new Person{ Name="Tom", Age=23},
                new Person {Name = "Sam", Age=25},
                new Person {Name="Bob", Age=23},
                new Person{Name="Tom", Age=25}
            };
        }

        public void OnGet()
        {
            DisplayedPeople = people;
        }

        public void OnGetByName(string name)
        {
            DisplayedPeople = people.Where(p => p.Name.Contains(name)).ToList();
        }
        public void OnGetByAge(int age)
        {
            DisplayedPeople = people.Where(p => p.Age == age).ToList();
        }

        public void OnPostGreaterThan(int age, string name)
        {
            DisplayedPeople = people.Where(p => p.Age > age && p.Name==name).ToList();
        }
        public void OnPostLessThan(int age)
        {
            DisplayedPeople = people.Where(p => p.Age < age).ToList();
        }
    }
}