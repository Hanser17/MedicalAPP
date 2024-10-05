
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicalAppoiments.Domain.Repositories
{
    
    public interface IBaseRepository <TEntity> where TEntity : class
    {
     
        Task Save(TEntity entity);
      
        Task Update (TEntity entity);
       
        Task Remove(TEntity entity);
       
        List <TEntity> GetAll ();
       
        TEntity GetEntityBy(Type Id);
        bool Exists(Expression<Func<TEntity, bool>> filter);

    }
}
