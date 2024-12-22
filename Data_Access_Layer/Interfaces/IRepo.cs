using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IRepo<Type, ID, RET>
    {
        RET Create(Type type);
        List<Type> Read();
        Type Read(ID id);
        RET Update(Type type);
        bool Delete(ID id);
    }
}
