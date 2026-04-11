using RestApiWithAspNet10.Data.Converter.Implementation;
using RestApiWithAspNet10.Data.DTO;
using RestApiWithAspNet10.Model;
using RestApiWithAspNet10.Repositories;

namespace RestApiWithAspNet10.Service.Implementation
{
    public class BookServicesImplementation : IBookServices
    {
        private IRepository<Book> _repository;
        private readonly BookConverter _converter;
        public BookServicesImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookDTO> FindAll()
        {

            return _converter.ParseList(_repository.FindAll());
        }
        public BookDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookDTO Create(BookDTO book)
        {
            var entity = _converter.Parse(book);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }

        public BookDTO Update(BookDTO book)
        {
            var entity = _converter.Parse(book);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
