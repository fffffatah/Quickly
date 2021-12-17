using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Providers;

namespace DataAccessLayer.IProviders
{
    public interface IEntityProvider<T, ID>
    {
        bool Add(T e);
        bool Edit(T e);
        bool Delete(ID id);
        List<T> Get();
        T Get(ID id);
    }
}
