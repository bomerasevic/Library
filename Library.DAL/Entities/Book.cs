using System.Collections.Generic;

namespace Library.DAL
{
    public class Book : BaseClass
    {
        public Book()
        {
            Authors = new List<AuthBooks>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual IList<AuthBooks> Authors { get; set; }
    }
}
