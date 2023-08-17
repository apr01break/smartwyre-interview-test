using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Data
{
    public interface IUnitOfWork
    {
        public void Commit();
        public void Rollback();
        public IProductDataStore ProductDataStore { get; }
        public IRebateDataStore RebateDataStore { get; }

    }
}
