
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
        public virtual async Task<OperationResult> Exists(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult result = new OperationResult();

            try
            {

                var exists = await this._entities.AnyAsync(filter);
                result.Data = exists;
                
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = $"Ocurrio un Error {ex.Message} verificando que existe el registro";
            }

            return result;
        }

        public virtual async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            try
            {
                var datos = await this._entities.ToListAsync();
                result.Data = datos;

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = $"Ocurrio un Error {ex.Message} obteniendo los datos ";
            }

            return result;
        }

        public virtual async Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();
            try
            {
                var entity = await this._entities.FindAsync(Id);
                result.Data = entity;

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = $"Ocurrio un Error {ex.Message} obteniendo la entidad ";
            }

            return result;
        }

        public virtual async Task<OperationResult> Remove(TEntity entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _entities.Remove(entity);
                await _medicalAppointmentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = $"Ocurrio un Error {ex.Message} borrando el registro ";
            }

            return result;
        }


        public virtual async Task<OperationResult> Save(TEntity entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _entities.Add(entity);
                await _medicalAppointmentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = $"Ocurrio un Error {ex.Message} guardando el registro ";
            }

            return result;
        }
   

        public virtual async Task<OperationResult> Update(TEntity entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _entities.Update(entity);
                await _medicalAppointmentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = $"Ocurrio un Error {ex.Message} actualizando el registro ";
            }

            return result;
        }
    }
}
