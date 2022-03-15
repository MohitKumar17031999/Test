using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinTableTry.Interface
{
  public  interface IRepository<T>
    {
        public Task<T> Create(T _object);

        public void Update(T _object);

        public IEnumerable<T> GetAll();
        public IEnumerable<object> JoinService(string name);

        public T GetById(int Id);

        public void Delete(T _object);

    }
}
