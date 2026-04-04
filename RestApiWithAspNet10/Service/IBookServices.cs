using RestApiWithAspNet10.Model;

namespace RestApiWithAspNet10.Service
{
    public interface IBookServices
    {
        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
