﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Functions.Interfaces
{
    public interface ICRUD
    {
        Task<T> Create<T>(T objectForDb) where T : class;
        Task<T> Read<T>(int entityId) where T : class;

        T ReadSync<T>(int entityId) where T: class;
        Task<List<T>> ReadAll<T>() where T : class;
Task<T> Update<T>(T objectToUpdate, int entityId) where T : class;
        Task<bool> Delete<T>(int entityId) where T : class;
    }
}
