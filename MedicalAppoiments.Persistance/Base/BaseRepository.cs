
using MedicalAppoiments.Domain.Repositories;
using MedicalAppoiments.Domain.Result;
using MedicalAppoiments.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedicalAppoiments.Persistance.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly MedicalAppointmentContext _medicalAppointmentContext;
        private DbSet<TEntity> _entities;


        public BaseRepository(MedicalAppointmentContext medicalAppointmentContext)
        {
            _medicalAppointmentContext = medicalAppointmentContext;
            this._entities = medicalAppointmentContext.Set<TEntity>();
        }
        public Task<OperationResult> Exists(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
