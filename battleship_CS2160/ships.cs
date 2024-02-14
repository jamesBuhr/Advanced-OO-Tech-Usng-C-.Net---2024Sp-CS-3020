namespace battleship_CS2160
{
    public abstract class Ships
    {
        // create ships atrubutes 
        private readonly int Health;
        private readonly int Length;
        private readonly string? Name;

        public int get_health()

        {
            return Health;
            throw new System.NotImplementedException();
        }

        public virtual int get_Length()
        {
            return Length;

        }

        public virtual string get_Name()
        {
            return Name;

        }
    }

    public class Destroyer : Ships
    {
        private readonly int length = 2;
        private readonly string Name;

        public Destroyer()
        {
            Name = "Destroyer";
            length = 2;

        }

        public override string get_Name()
        {
            return Name;

        }

        public override int get_Length()
        {
            return length;
        }
    }

    public class Submarine : Ships
    {
        private readonly string Name;

        private readonly int length;
        public Submarine()
        {
            Name = "Submarine";
            length = 3;

        }

        public override string get_Name()
        {
            return Name;

        }

        public override int get_Length()
        {
            return length;
        }
    }

    public class Battleship : Ships
    {
        private readonly int length;
        private readonly string Name;

        public Battleship()
        {
            Name = "Battleship";
            length = 4;

        }
        public override string get_Name()
        {
            return Name;

        }

        public override int get_Length()
        {
            return length;
        }
    }

    public class Carrier : Ships
    {
        private readonly int BowX;
        private readonly int BowY;
        private readonly int SternX;
        private readonly int SternY;
        private readonly int length = 5;
        private readonly string Name;

        public Carrier()
        {
            Name = "Carrier";
            length = 5;

        }

        public override string get_Name()
        {
            return Name;

        }

        public override int get_Length()
        {
            return length;
        }
    }
}