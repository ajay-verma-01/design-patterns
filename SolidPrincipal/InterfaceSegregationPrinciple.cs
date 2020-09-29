using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciple
{
    /*
     Clients should not be forced to depend upon interfaces that they do not use.
     */
    class InterfaceSegregationPrinciple
    {
    }

    interface IToy
    {
        void setPrice(int price);
        void setColor(String color);
    }
    interface IMovable
    {
        void move();
    }
    interface IFlyable
    {
        void fly();
    }

    class ToyHouse : IToy
    {
        int price;
        String color;
        public void setPrice(int price)
        {
            this.price = price;
        }
        public void setColor(String color)
        {
            this.color = color;
        }
    }
    public class ToyPlane : IToy, IMovable, IFlyable
    {
        double price;
        String color;
        public void setPrice(int price)
        {
            this.price = price;
        }
        public void setColor(String color)
        {
            this.color = color;
        }
        public void move()
        {//code related to moving plane}

        }
        public void fly()
        {// code related to flying plane}
        }
    }
}
