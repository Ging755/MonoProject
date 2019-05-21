using Ninject.Modules;
using ProjectMono.Common.Parameters;
using ProjectMono.Common.ParametersCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Common
{
    public class DImodule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFilterParameters>().To<FilterParameters>();
            Bind<ISortParameters>().To<SortParameters>();
            Bind<IPageParameters>().To<PageParameters>();
        }
    }
}
