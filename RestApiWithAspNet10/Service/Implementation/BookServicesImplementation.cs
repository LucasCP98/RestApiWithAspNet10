using Mapster;
using RestApiWithAspNet10.Data.DTO;
using RestApiWithAspNet10.Model;
using RestApiWithAspNet10.Repositories;
// Ultilizando o Mapster para converter os objetos, ao invés de criar uma classe de conversão manualmente.
//91. 1207 Substituindo o Converter Manual pelo Mapster
namespace RestApiWithAspNet10.Service.Implementation
{
    public class BookServicesImplementation : IBookServices
    {
        private IRepository<Book> _repository;
        public BookServicesImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public List<BookDTO> FindAll()
        {

            return _repository.FindAll().Adapt<List<BookDTO>>();
        }
        public BookDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<BookDTO>();
        }

        public BookDTO Create(BookDTO book)
        {
            var entity = book.Adapt<Book>();
            entity = _repository.Create(entity);
            return entity.Adapt<BookDTO>();
        }

        public BookDTO Update(BookDTO book)
        {
            var entity = book.Adapt<Book>();
            entity = _repository.Update(entity);
            return entity.Adapt<BookDTO>();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
