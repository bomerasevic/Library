using System.Collections.Generic;

namespace Library.API.Models
{
    public class PublisherModel
    {
        public PublisherModel()
        {
            Books = new List<BookModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Road { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<BookModel> Books { get; set; }
    }
}
