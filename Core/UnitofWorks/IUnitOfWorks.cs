using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitofWorks
{
    public interface IUnitOfWorks
    {
        void Commit();
        Task CommitAsync();

    }
}
