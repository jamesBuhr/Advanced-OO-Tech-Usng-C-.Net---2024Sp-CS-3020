using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace battleship_CS2160
{
    public abstract class Ships
    {
        private int Health;
        private int Length;
        private int BowX;
        private int BowY;
        private int SternX;
        private int SternY;
        private string Name;

        public int get_health()

        {
            return this.Health;
            throw new System.NotImplementedException();
        }

        public void set_Health(int health)
        {   
            this.Health = health;
        }
                  

        public void set_BowX(int bowX)
        {
            this.BowX = bowX;
           
        }

        public void set_BowY(int bowY)
        {   this.BowY = bowY;
        }

        public void set_SternY(int sternY)
        {   this.SternY = sternY;
            throw new System.NotImplementedException();
        }

        public void set_SternX(int sternX)
        {   this.SternX = sternX;
           
        }

        public int get_SternX()
        {
            return this.SternX;
            throw new System.NotImplementedException();
        }

        public int get_SternY()
        {
            return this.SternY;
            throw new System.NotImplementedException();
        }

        public int get_BowX()
        {
            return this.BowX;
            throw new System.NotImplementedException();
        }

        public int get_BowY()
        {
            return this.BowX;
            throw new System.NotImplementedException();
        }

       public virtual int get_Length()
        {
            return this.Length;
            
        }

        public string get_name()
        {
            return this.Name;
            
        }
    }

    public class Destroyer : Ships
    {

        int length = 2;
         int BowX;
         int BowY;
         int SternX;
         int SternY;
        private string Name;

        public Destroyer()
        {
            Name = "Destroyer";
            this.length = 2;
            this.set_Health(this.length);
        }
    }

    public class Submarine : Ships
    {
        string Name;
        int BowX;
        int BowY;
        int SternX;
        int SternY;
        int length;
        public Submarine()
        {
            Name = "Submarine";
            this.length = 3;
            this.set_Health(this.length);
        }
    }

    public class Battleship : Ships
    {
        int BowX;
        int BowY;
        int SternX;
        int SternY;
        int length;
        string Name;

        public Battleship()
        {
            this.Name = "Battleship";
            this.length = 4;
            this.set_Health(this.length);
        }
    }

    public class Carrier : Ships
    {
         int BowX;
         int BowY;
         int SternX;
         int SternY;
         int length=5;
         string Name;

        public Carrier()
        {
            this.Name =  "Carrier";
            this.length = 5;
            this.set_Health(this.length);            
        }

        public override int get_Length()
        {
            return this.length;
        }
    }
}