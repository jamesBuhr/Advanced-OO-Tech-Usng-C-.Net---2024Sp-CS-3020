namespace battleship_CS2160
{
    public abstract class Game
    {
        int turn_Number;
        int rows =10;
        int cols = 10; 
        String[,] board;
        
       

        public void cycle_Turn()
        {
            this.turn_Number++;
            throw new System.NotImplementedException();
        }

        public void cheak_win_condishions()
        {
            throw new System.NotImplementedException();
        }

        public void display_board()
        {    
            string[] COLS = { "   [1]", "[2]","[3]","[4]","[5]","[6]","[7]","[8]","[9]","[10]"}; //create row and col array for user display interface
            string[] ROWS = {"[A]","[B]","[C]","[D]","[E]","[F]","[G]","[H]","[I]","[J]"};
            
            //PRINT THE GAME BOARD :
            for (int col = 0; col < cols; col++){                                                 //print 1:10 above the board for each col:
                Console.Write(COLS[col]);
            }

            Console.WriteLine();                                                                   //print a newline to seperate the 1:10 from the game board.

            for (int row = 0; row < rows; row++) {                                                 //print the game board.
                Console.Write(ROWS[row]);                                                          //print the grid display A:J for each row. 
                for (int col = 0; col < cols; col++) {                                             
                    Console.Write(board[row, col] );                                               //write whats in each element of the 2D Array
                }
                Console.WriteLine();                                                               // print a new line char to seperate each row
            }
        }

        public void cheat_Mode()
        {
            throw new System.NotImplementedException();
        }

        public void create_Board()
        {
            // sets the board size to 10X10
            this.board = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    this.board[row, col] = "[ ]";
                }
            }
        }
    }

    public class Player : Game
    {
        List<Ships> ships;
        private int starting_number_of_ships;
        private int number_Of_Ships_Remaining;
        private String[] ship_locations;



        public Player()
        {
            ships = new List<Ships> {
                new Carrier(),
                new Battleship(),
                new Submarine(),
                new Submarine(),
                new Destroyer(),
                new Destroyer()
            };

            starting_number_of_ships = ships.Count;
            ship_locations = new string[starting_number_of_ships];
            number_Of_Ships_Remaining = starting_number_of_ships;

        }

        public void cheak_hit(string location)
        {
            throw new System.NotImplementedException();
        }

        public void fire()
        {   
            throw new System.NotImplementedException();
        }

        public void display()
        {   
            throw new System.NotImplementedException();
        }
    }

    public class Other_Player : Game
    {
        List<Ships> ships;
        private int starting_number_of_ships;
        private int number_Of_Ships_Remaining;
        private string[] ship_locations;
        


        public Other_Player()
        {
            ships = new List<Ships> {
                new Carrier(),
                new Battleship(),
                new Submarine(),
                new Submarine(),
                new Destroyer(),
                new Destroyer()
            };

            starting_number_of_ships = ships.Count;
            ship_locations = new string[starting_number_of_ships];
            number_Of_Ships_Remaining = starting_number_of_ships;



            throw new System.NotImplementedException();
        }

        public void place_Ships()
        {
            throw new System.NotImplementedException();
        }

        public void get_ship_locations()
        {
            throw new System.NotImplementedException();
        }

        public void fire()
        {
            throw new System.NotImplementedException();
        }

        public void cheak_hit()
        {
            throw new System.NotImplementedException();
        }

        public void display()
        {
            throw new System.NotImplementedException();
        }
    }
}