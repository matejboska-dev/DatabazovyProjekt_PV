using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DatabaseProject_MatejBoska.Interfaces
{
    internal interface IDAO<T> where T : IBase
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        void Save(T item);
        void Delete(T item);
        string TableName { get; }
    }
}
