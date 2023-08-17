using System;

namespace Smartwyre.DeveloperTest.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductDataStore productDataStore;
        private IRebateDataStore rebateDataStore;
        public IProductDataStore ProductDataStore
        {
            get
            {
                if (productDataStore == null)
                {
                    productDataStore = new ProductDataStore();
                }
                return productDataStore;
            }
        }

        public IRebateDataStore RebateDataStore
        {
            get
            {
                if (rebateDataStore == null)
                {
                    rebateDataStore = new RebateDataStore();
                }
                return rebateDataStore;
            }
        }

        public void Commit()
        {
            //logic to save changes
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            //logic to rollback
            throw new NotImplementedException();
        }
    }
}
