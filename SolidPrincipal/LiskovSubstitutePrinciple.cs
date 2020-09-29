using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciple
{
    /*
     LSP The Liskov Substitution Principle: — 
    If any module is using a Base class then the reference to that Base class can be replaced 
    with a Derived class without affecting the functionality of the module.
     */
    class LiskovSubstitutePrinciple
    {
        public void MainMethod()
        {
            List<Customer> Customers = new List<Customer>();
            Customers.Add(new SilverCustomer());
            Customers.Add(new goldCustomer());
            //Customers.Add(new Enquiry());//error
        }
    }

    internal class goldCustomer : Customer
    {
    }

    internal class SilverCustomer : Customer
    {
    }

    interface IDiscount
    {
        double getDiscount(double TotalSales);
    }


    interface IDatabase
    {
        void Add();
    }
    class Enquiry : IDiscount
    {
        public double getDiscount(double TotalSales)
        {
            return TotalSales - 5;
        }
    }
    class Customer : IDiscount, IDatabase
    {
        public virtual void Add()
        {
            // Database code goes here  
        }

        public virtual double getDiscount(double TotalSales)
        {
            return TotalSales;
        }
    }
}
