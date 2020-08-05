using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPractice.Models
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity _entity);
        void Update(TEntity _entity);
        void Delete(TEntity _entity);

    }
}
