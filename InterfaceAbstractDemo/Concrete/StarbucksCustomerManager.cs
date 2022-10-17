using InterfaceAbstractDemo.Abstract;
using InterfaceAbstractDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAbstractDemo.Concrete
{
    class StarbucksCustomerManager:BaseCustomerManager
    {
        private ICustomerCheckService _cutomerCheckService;

        public StarbucksCustomerManager(ICustomerCheckService cutomerCheckService)
        {
            _cutomerCheckService = cutomerCheckService;
        }

        public override void Save(Customer customer)
        {
            if (_cutomerCheckService.CheckIfRealPerson(customer))
            {
                base.Save(customer);
            }
            else
            {
                Console.WriteLine("Bilgileriniz doğrulanamadı lütfen tekrar deneyiniz !\n");
                throw new Exception();
            }
        }

    }
}
