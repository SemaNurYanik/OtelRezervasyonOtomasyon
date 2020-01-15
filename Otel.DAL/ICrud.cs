using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL
{
    public interface ICrud<T> where T : class
    {
        int Add(T entity);
        int Update(T entity);        
        List<T> GetAll();
        T GetByID(int ID);
    }
}
