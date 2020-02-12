using System.Collections.Generic;

namespace Library.API.Models
{
    public class BookModel
    {
        public BookModel()
        {
            Authors = new List<MasterModel>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public MasterModel Publisher { get; set; }
        public List<MasterModel> Authors { get; set; }
    }
}
