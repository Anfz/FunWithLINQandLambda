using System;

namespace Linq
{
    public class Contact
    {
        public string Id { get; }
        public string Name { get; set; }

        public Contact(string Name)
        {
            Id = Guid.NewGuid().ToString(); 
        }
    }
}