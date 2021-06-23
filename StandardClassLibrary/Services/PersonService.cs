using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack;

namespace StandardClassLibrary.Services
{
    public class PersonService
    {
        public IList<Person> People(int howMany = 10)
        {
            var list = new List<Person>();
            for (int i = 0; i < howMany; i++)
            {
                list.Add(new Person { Id = i, Name = $"Person #{i}" });
            }
            return list;

        }

        public string GetPersonAsJson(int id)
        {
            var person = People(id + 1).FirstOrDefault(f => f.Id == id);
            return person.ToJson();
        }
    }
}
