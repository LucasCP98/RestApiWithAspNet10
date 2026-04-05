using RestApiWithAspNet10.Model.Base;
using RestApiWithAspNet10.Repositories.Implementation;

namespace RestApiWithAspNet10.Repositories.Implementation
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        public List<T> FindAll()
        {
            throw new NotImplementedException();
        }
        public T FindById(long id)
        {
            throw new NotImplementedException();
        }
        public T Create(T item)
        {
            throw new NotImplementedException();
        }
        public T Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }

    }
}
