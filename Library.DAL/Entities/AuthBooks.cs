namespace Library.DAL
{
    public class AuthBooks
    {
        public int Id { get; set; }
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
