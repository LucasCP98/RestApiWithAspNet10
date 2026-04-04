using RestApiWithAspNet10.Model;
using RestApiWithAspNet10.Repositories;

namespace RestApiWithAspNet10.Service.Implementation
{
    public class BookServicesImplementation : IBookServices
    {
        private IBookRepository _repository;
        public BookServicesImplementation(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> FindAll()
        {

            return _repository.FindAll();
        }
        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            book.Id = 0;
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
