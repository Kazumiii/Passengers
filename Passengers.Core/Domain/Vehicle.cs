using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
    //this class is treated like value object. I create ths object only once and i will never change it 
    public class Vehicle
    {
        public string Name { get; protected set; }

        public string Brnad { get; protected set; }



        public int Seats { get; protected set; }



        protected Vehicle()
        {
            //constructos for  mapping libraries 


        }
        public Vehicle(string Brnad,string Name,int Seats)
        {
            SetBrand(Brnad);
            SetName(Name);
            SetSets(Seats);
        }

        public static Vehicle Create(string brand, string name, int seats)
        {
         return   new Vehicle(brand, name, seats);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Put the name of car");
            }
            else
            {
                return;
            }
            Name = name;
        }
        private void SetBrand(string brand)
        {
            if(string.IsNullOrEmpty(brand))
            {
                throw new Exception("Put brand of the car");
            }
            else
            {
                return;
            }
            Brnad = brand;
        }

        private void SetSets(int seats)
        {
            if (seats > 9)
            {
                throw new Exception("You can take only 9 passangers");
            }
            else
                return;

            Seats = seats;
        }

    }
}
