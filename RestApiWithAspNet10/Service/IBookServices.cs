using RestApiWithAspNet10.Data.DTO;

namespace RestApiWithAspNet10.Service
{
    public interface IBookServices
    {
        BookDTO Create(BookDTO book);
        BookDTO FindById(long id);
        List<BookDTO> FindAll();
        BookDTO Update(BookDTO book);
        void Delete(long id);
    }
}
