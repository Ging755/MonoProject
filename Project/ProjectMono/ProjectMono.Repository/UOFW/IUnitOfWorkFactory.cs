using ProjectMono.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Repository.UOFW
{
    public interface IUnitOfWorkFactory
    {
        UnitOfWork CreateUnitOfWork();
    }
}
