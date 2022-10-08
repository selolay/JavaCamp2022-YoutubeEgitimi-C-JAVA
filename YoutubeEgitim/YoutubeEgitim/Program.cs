using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeEgitim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new Customer(),new MilitaryCreditManager()); 
            customerManager.GiveCredit();
            
            Console.ReadLine();
        }
    }

    class CreditManager
    {
        public void Calculate()
        {
            Console.WriteLine("hesaplandı");
        }

        public void Save()
        {
            Console.WriteLine("Kredi verildi");
        }
    }

    class Customer
    {
        public Customer()
        {
            Console.WriteLine("Müşteri nesnesi başlatıldı");
        }
        public int Id { get; set; }
        public string City { get; set; }
    }

    interface ICreditManager
    {
        void Calculate();
        void Save();
    }

    abstract class BaseCreditManager: ICreditManager
    {
        public abstract void Calculate();// her yerde değişiklik gösterebilir

        public virtual  void Save() //virtual --> sanal
        {
            Console.WriteLine("kaydedildi");
        }
    }

    class TeacherCreditManager :BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            //hesaplamalar
           Console.WriteLine("öğretmen kredisi hesaplandı");
        }

        public override void Save()
        {
            base.Save();
        }
        
    }
    class MilitaryCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Asker kredisi hesaplandı");
        }


    }

    class CatCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Araba kredisi hesaplandı");
        }


    }


    class Person : Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
    }


    class Company : Customer
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }

    }
    
    //katmanlı mimariler
    class CustomerManager
    {
        private ICreditManager _creditManager;
       
        private Customer _customer;
        public CustomerManager(Customer customer, ICreditManager creditManager)
        {
            _customer= customer;
            _creditManager= creditManager;
            
        }
        public void Save()
        {
            
            Console.WriteLine("Müşteri verildi : ");
        }

        public void Delete()
        {

            Console.WriteLine("Müşteri silindi : ");
        }
        public void GiveCredit()
        {
            _creditManager.Calculate();
            Console.WriteLine("Kredi verildi");
        }
    }
}