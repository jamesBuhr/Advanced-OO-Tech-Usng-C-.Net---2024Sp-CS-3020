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

        static int[] ConvertInputToIndices(string input)
        {
            // Ensure the input is in the correct format (e.g., "A4")
            if (input.Length != 2 || !char.IsLetter(input[0]) || !char.IsDigit(input[1]))
            {
                throw new ArgumentException("Invalid input format. Please enter a location in the format 'A4'.");
            }

            // Convert the letter part to a numeric index (A -> 0, B -> 1, etc.)
            int col = char.ToUpper(input[0]) - 'A';

            // Convert the digit part to a numeric index (1 -> 0, 2 -> 1, etc.)
            int row = int.Parse(input[1].ToString()) - 1;

            // Return the indices as an array
            return new int[] { row, col };
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
            create_Board();
            display_board();   

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

        public void get_ship_location()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Other_Player : Game
    {
        List<Ships> ship_List;
        private int starting_number_of_ships;
        private int number_Of_Ships_Remaining;
        private string[] ship_locations;
        


        public Other_Player()
        {
            ship_List = new List<Ships> {
                new Carrier(),
                new Battleship(),
                new Submarine(),
                new Submarine(),
                new Destroyer(),
                new Destroyer()
            };

            starting_number_of_ships = ship_List.Count;
            ship_locations = new string[starting_number_of_ships];
            number_Of_Ships_Remaining = starting_number_of_ships;

            throw new System.NotImplementedException();
        }

        public void get_ship_locations()
        {   
            foreach (Ships ship in ship_List)
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

        public void set_Ship_Location()
        {
            throw new System.NotImplementedException();
        }
    }
}