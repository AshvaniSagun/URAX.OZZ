using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraxBpcPno34Api.Models
{
    public interface ICache
    {
        Task<T> GetAsync<T>(string key);
        Task AddAsync<T>(string key, T entity);

    }
}
