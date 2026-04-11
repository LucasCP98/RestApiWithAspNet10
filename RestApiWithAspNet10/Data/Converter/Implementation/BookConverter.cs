using RestApiWithAspNet10.Data.Converter.Contract;
using RestApiWithAspNet10.Data.DTO;
using RestApiWithAspNet10.Model;

namespace RestApiWithAspNet10.Data.Converter.Implementation
{
    public class BookConverter : IParser<BookDTO, Book>, IParser<Book, BookDTO>
    {
        public Book Parse(BookDTO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate  
            };
        }
        public List<Book> ParseList(List<BookDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public BookDTO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookDTO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<BookDTO> ParseList(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
