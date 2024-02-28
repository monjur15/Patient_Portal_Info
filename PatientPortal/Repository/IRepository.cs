﻿using PatientPortal.Entity;

namespace PatientPortal.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);   
        Task<T> AddAsync (T entity);
        Task<T> UpdateAsync (T entity); 
        Task<T> DeleteAsync (int id);
        Task DeleteAsync(PatientsInformation patient);
    }
}
