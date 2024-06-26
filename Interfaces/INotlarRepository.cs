﻿using NetCore8ApiDapper.Models;

namespace NetCore8ApiDapper.Interfaces
{
    public interface INotlarRepository : IGenericRepository<Notlar>
    {

        Task<IEnumerable<object>> GetAllAsync2();

        Task<IEnumerable<Notlar>> GetAllAsync3();
        Task<IEnumerable<object>> GetAllAsync4();
        Task<IEnumerable<object>> GetAllAsync5();

    }
}
