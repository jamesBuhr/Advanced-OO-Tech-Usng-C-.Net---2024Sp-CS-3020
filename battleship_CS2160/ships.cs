using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace battleship_CS2160
{
    public abstract class Ships
    {
        private int health;
        private int length;
        private String[] location;
        private int BowX;
        private int BowY;
        private int SternX;
        private int SternY;

        public int get_health()

        {
            return this.health;
            throw new System.NotImplementedException();
        }

        public void set_Health(int health)
        {   
            this.health = health;
        }

        public void set_location(Ships ship)
        {
            
            throw new System.NotImplementedException();
        }

        public void create_Location_Size(int size)
        {   this.location = new String[size];
        }

        public void set_BowX(int bowX)
        {
            this.BowX = bowX;
            throw new System.NotImplementedException();
        }

        public void set_BowY(int bowY)
        {   this.BowY = bowY;
            throw new System.NotImplementedException();
        }

        public void set_SternY(int sternY)
        {   this.SternY = sternY;
            throw new System.NotImplementedException();
        }

        public void set_sternX(int sternX)
        {   this.SternX = sternX;
            throw new System.NotImplementedException();
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

        public int get_bowX()
        {
            return this.BowX;
            throw new System.NotImplementedException();
        }

        public int get_BowY()
        {
            return this.BowX;
            throw new System.NotImplementedException();
        }
    }

    public class Destroyer : Ships
    {    int length = 2;
         int BowX;
         int BowY;
         int SternX;
         int SternY;

        public Destroyer()
        {
            this.set_Health(this.length);
            create_Location_Size(this.length);
        }
    }

    public class Submarine : Ships
    {
        int BowX;
        int BowY;
        int SternX;
        int SternY;
        int length = 3;
        public Submarine()
        {
            this.set_Health(this.length);
            create_Location_Size(this.length);
        }
    }

    public class Battleship : Ships
    {
        int BowX;
        int BowY;
        int SternX;
        int SternY;
        int length = 4;
        public Battleship()
        {
            this.set_Health(this.length);
            create_Location_Size(this.length);
        }
    }

    public class Carrier : Ships
    {
         int BowX;
         int BowY;
         int SternX;
         int SternY;
        int length = 5;
        public Carrier()
        {
            this.set_Health(this.length);
            create_Location_Size(this.length);
            
        }
    }
}