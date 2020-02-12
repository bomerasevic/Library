using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL
{
    public class Author : BaseClass
    {
        public Author()
        {
            Books = new List<AuthBooks>();
        }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public virtual IList<AuthBooks> Books { get; set; }
    }
}
