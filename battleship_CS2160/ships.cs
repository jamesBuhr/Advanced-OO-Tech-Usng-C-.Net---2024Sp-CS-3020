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
        private int size;
        private String[] location; 

        public int get_health()

        {
            return this.health;
            throw new System.NotImplementedException();
        }

        public void set_Health(int health)
        {   
            this.health = health;
        }

        public void set_location(string[] location)
        {   
            this.location = location;
            throw new System.NotImplementedException();
        }

        public void create_Location_Size(int size)
        {   this.location = new String[size];
        }
    }

    public class Destroyer : Ships
    { int size = 2;

        public Destroyer()
        {
            this.set_Health(this.size);
            create_Location_Size(this.size);
        }
    }

    public class Submarine : Ships
    {
        int size = 3;
        public Submarine()
        {
            this.set_Health(this.size);
            create_Location_Size(this.size);
        }
    }

    public class Battleship : Ships
    {
        int size = 4;
        public Battleship()
        {
            this.set_Health(this.size);
            create_Location_Size(this.size);
        }
    }

    public class Carrier : Ships
    {
        int size = 5;
        public Carrier()
        {
            this.set_Health(this.size);
            create_Location_Size(this.size);
            
        }
    }
}