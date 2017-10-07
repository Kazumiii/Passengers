using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
    //represents start and end point of route 
 public   class Node
    {
        public string Address { get; protected set; }

        public double Longitiude { get; protected set; }

        public double Latitiude { get; protected set; }

        public DateTime UpdateAr { get; protected set; }

        protected Node()
        {

        }

        protected Node(string Adress,double longitiude,double latitiude)
        {
            SetAdress(Adress);
            SetLongitiude(longitiude);
            SetLatitiude(latitiude);
        }

        public void SetAdress(string adress)
        {
            if(adress==null)
            {
                throw new Exception("INcorrect adress");
            }
            Address = adress;
            UpdateAr = DateTime.UtcNow;
        }

        public void SetLongitiude(double longitiude)
        {
            if(longitiude==null)
            {
                throw new Exception("Incorrect longitiude");


            }
            Longitiude = longitiude;
            UpdateAr = DateTime.UtcNow;
                    }

        public void SetLatitiude(double latitiude)
        {
            if(latitiude==null)
            {
                throw new Exception("Incorect latitiude");
            }
            Latitiude = latitiude;
            UpdateAr = DateTime.UtcNow;
        }


        public static Node Create(string adres, double longitiude, double latitiude)
        => new Node(adres, longitiude, latitiude);
        
        
        
    }
}
