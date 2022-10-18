using InterfaceAbstractDemo.Abstract;
using InterfaceAbstractDemo.Adapters;
using InterfaceAbstractDemo.Concrete;
using InterfaceAbstractDemo.Entities;

namespace InterfaceAbstractDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            basl:
            Console.WriteLine("Merhaba, Lütfen bilgilerinizi giriniz.\n");
            Console.Write("Adınız : ");
            string ad = Console.ReadLine();
            Console.Write("Soyadınız : ");
            string soyad = Console.ReadLine();
            Console.Write("Doğum tarihiniz(gg.aa.yyyy): ");
            DateTime dogumTarihi = Convert.ToDateTime(Console.ReadLine());
            Console.Write("TCKN : ");
            string TcNo = Console.ReadLine();

            Customer customer1 = new Customer()
            {
                Id = 1,
                FirstName = ad,
                LastName = soyad,
                DateofBirth = dogumTarihi,
                NationalityId = TcNo

            };
            Console.WriteLine();
            git:
            Console.WriteLine("Nereye üye olmak istiyorsunuz?");
            Console.WriteLine("Starbucks için 1'e, Nero için 2'ye basınız");
            int secenek = Convert.ToInt32(Console.ReadLine());

            if (secenek == 1)
            {
                try
                {
                    BaseCustomerManager customerManager = new StarbucksCustomerManager(new MernisServiceAdapter());
                    customerManager.Save(customer1);
                }
                catch (Exception)
                {
                    goto basl;
                }
               
            }
            else if (secenek == 2)
            {
                BaseCustomerManager customerManager = new NeroCustomerManager();
                customerManager.Save(customer1);
            }
            else
            {
                Console.WriteLine("Lütfen 1 veya 2 giriniz !");
                goto git;
            }

            Console.ReadLine();

        }
    }
}