using System;

namespace Library.DAL
{
    public class BaseClass
    {
        public BaseClass()
        {
            Created = DateTime.Now;
            Creator = 0;
            Deleted = false;
        }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int Creator { get; set; }
        public bool Deleted { get; set; }
    }
}