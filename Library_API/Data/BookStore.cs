using Library_API.Models;

namespace Library_API.Data
{
    public class BookStore
    {
        public static List<Book> bookList = new List<Book>
        {
            new Book{BookId=1, Author="Geore", Genre="genre one", IsAvailable=true, Published=DateTime.Now, Title="Geores Book"},
            new Book{BookId=2, Author="Gaga", Genre="genre two", IsAvailable=true, Published=DateTime.Now, Title="lalalala"},
            new Book{BookId=3, Author="Yuyu", Genre="genre one", IsAvailable=false, Published=DateTime.Now, Title="7567567"},
            new Book{BookId=4, Author="Nfnf", Genre="genre two", IsAvailable=true, Published=DateTime.Now, Title="....title...."}
        };
    }
}
