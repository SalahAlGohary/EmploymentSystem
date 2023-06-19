using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Presistence.Contracts
{
    public  interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
