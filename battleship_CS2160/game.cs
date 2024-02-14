namespace battleship_CS2160

{
    /// <summary>
    ///  gives the outline of what the game should be:
    ///  player(you ) and the ,opponet 
    ///  
    /// </summary>
    public class Game
    {
        private string[,]? player_Board;
        private readonly int rows = 10; // rows of the board 
        private readonly int cols = 10; // cols on the board 

        public Game()
        {


        }

        public bool cheak_win_condishions(Player player, Opponent opponent)
        { ///will cheak if player has lost all heath points repersented by the number of total ship lengths  

            bool win = false;//has anyone won yet?
            if (player.total_ship_health <= 0)
            {   //if you lose. output text 
                Console.WriteLine("YOU LOSE, YOU MUST REALLY SUCK!");
                win = true;
            }
            else if (opponent.number_of_total_health <= 0)
            {   //if you win, ouput message
                Console.WriteLine("YOU WIN ");
                win = true; // flip bool to true, 
            }
            return win;// return if game is over 

        }

        //displays the board of the player of the opponet 
        public void display_board(string[,] board)
        {   //souranding navi
            string[] COLS = { "   [1]", "[2]", "[3]", "[4]", "[5]", "[6]", "[7]", "[8]", "[9]", "[10]" }; //create row and col array for user display interface
            string[] ROWS = { "[A]", "[B]", "[C]", "[D]", "[E]", "[F]", "[G]", "[H]", "[I]", "[J]" };

            //PRINT THE GAME BOARD :
            for (int col = 0; col < cols; col++)
            {                                                 //print 1:10 above the board for each col:
                Console.Write(COLS[col]);
            }

            Console.WriteLine();                                                                   //print a newline to seperate the 1:10 from the game board. arrays 

            //print the game board.
            for (int row = 0; row < rows; row++)
            {
                Console.Write(ROWS[row]);                                                          //print the grid display A:J for each row. 
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(board[row, col]);                                               //write whats in each element of the 2D Array
                }
                Console.WriteLine();                                                               // print a new line char to seperate each row
            }
        }

        // sreates the game board for the predetermaned size
        public string[,] create_Board()
        {
            // sets the board size to 10X10
            player_Board = new string[rows, cols];
            // rows
            for (int row = 0; row < rows; row++)
            {   // cols
                for (int col = 0; col < cols; col++)
                {  //create elements row by col  
                    player_Board[row, col] = "[ ]";
                }
            }//return player board/opponent to where it was called. 
            return player_Board;
        }
        //for a given location sheak if a ship overlaps for the length of the ship 
        public bool cheak_If_Ship_Placed(int length_of_ship, int bowX, int bowY, int sternX, int sternY)
        {
            // Check if vertical both X-axis of a ship stern and bow should be the same 
            if (bowX == sternX)
            {
                // Determine the start and end positions for the ship 
                int startY = Math.Min(bowY, sternY);
                int endY = Math.Max(bowY, sternY);

                // Check each position along the ship's length
                for (int y = startY; y <= endY; y++)
                {
                    // If ship at any position, return true
                    if (get_Element(bowX, y))
                    {
                        return true;
                    }
                }
            }
            // Check if horizontal
            else if (bowY == sternY)
            {
                // Determine the start and end positions for the ship.
                int startX = Math.Min(bowX, sternX);
                int endX = Math.Max(bowX, sternX);

                // Check each position along the ship's length
                for (int x = startX; x <= endX; x++)
                {
                    // If ship at any position, return true
                    if (get_Element(x, bowY))
                    {
                        return true;
                    }
                }
            }
            // No overlap found, return false
            return false;
        }
        //cheaks the players board if there is a ship in the location seclected of a 2d array.
        public virtual bool get_Element(int x, int y)
        {   // 

            // copy the element of the x and y values.
            string element_of_board = player_Board[y, x];

            //if rthe element at the location of the the boards 2d array is the same as a ship string, return true/ false 
            return element_of_board == "[S]";




        }
        //given the board of the player/opponet  , location: int x, int y.
        // places the ship token on the board 
        public void set_Ship_Inedx_On_Board(string[,] board, int x, int y)
        {
            board[y, x] = "[S]"; //chang the element to the ship token 
            Console.Clear();    // update the board : clear the board : redisplay board
            display_board(board);

        }
        //emulate the game.
        public void play_game(Player player, Opponent opponent)
        {//while one player has life keep playing
            while (!cheak_win_condishions(player, opponent))
            {   //turns // player=>opponet . repeat.
                player.fire(opponent);
                opponent.fire(player);
            }
        }
    }

    public class Player : Game
    {   //outlines player atrubutes and abilities 
        private readonly List<Ships> player_Ship_List;
        public int total_ship_health = 0; // : set to the total lengh of ships 
        public string[,] player_Board; // board


        public Player()
        {
            player_Ship_List = new List<Ships> {
                //default ship list.
                new Carrier(),
                new Battleship(),
                new Submarine(),
                new Submarine(),
                new Destroyer(),
                new Destroyer()
            };
            // count the amount of hit points a player has , by total lengh of ships.
            foreach (Ships ship in player_Ship_List)
            {   // add ship length to health.
                total_ship_health += ship.get_Length();
            }
            // create player's board, place ships on board
            player_Board = create_Board();
            display_board(player_Board);
            place_Ships_on_Board();
        }

        public int[] convert_Cordents(string input)
        {//convert (C3) -> 2,2 index value of a a 2d array: 

            // Ensure the input is in the correct format (e.g., "A4")
            if (input.Length < 2 || input.Length > 3 || !char.IsLetter(input[0]) || !char.IsDigit(input[^1]))
            {
                throw new ArgumentException("Invalid input format. Please enter a location in the format 'A1' to 'J10'.");
            }

            // Convert the letter part to a numeric index (A -> 0, B -> 1, etc.)
            int col = char.ToUpper(input[0]) - 'A';

            // Convert the digit part to a numeric index (1 -> 0, 2 -> 1, etc.)
            int row = int.Parse(input[1..]) - 1;

            // Return the indices as an array
            return new int[] { row, col };
        }

        public void set_Ship_Location(Ships ship)
        {
            int shipSize = ship.get_Length();
            _ = new int[2];
            bool place_ship = false;


            // while the ship hasnt been placed continue to try to place the ship
            while (!place_ship)
            {
                //prompt user what ship to place and how big the ship is :
                Console.WriteLine("\nPlace your " + ship.get_Name() + " of length " + shipSize);
                //select location to place the Bow


                Console.WriteLine("\nPlace Bow");

                string user_Input_Bow = Console.ReadLine();


                int[] location = convert_Cordents(user_Input_Bow);
                int bow_x = location[0];
                int bow_y = location[1];


                //select location to place the Stern

                Console.WriteLine("Place stern");
                string user_Input_Stern = Console.ReadLine();
                location = convert_Cordents(user_Input_Stern);
                int stern_x = location[0];
                int stern_y = location[1];


                //cheak if ship in this location:
                if (!cheak_If_Ship_Placed(ship.get_Length(), bow_x, bow_y, stern_x, stern_y))
                {
                    //set global (X,Y)
                    // for each element of the ships length: try to place the ship
                    for (int i = 0; i < ship.get_Length(); i++)
                    {
                        //if horizontal
                        if (bow_y == stern_y)
                        {
                            // place ship if the diffrince of the nonequial value is the size of the ship -1 
                            //if ship facing west 
                            if (stern_x > bow_x && stern_x + 1 - (bow_x + 1) == ship.get_Length() - 1)
                            {
                                // place ship 
                                set_Ship_Inedx_On_Board(player_Board, bow_x + i, stern_y);
                                //update while condishion.
                                place_ship = true;

                            }
                            // place ship if the diffrince of the nonequial value is the size of the ship -1 
                            //if ship facing east
                            else if (stern_x < bow_x && bow_x + 1 - (stern_x + 1) == ship.get_Length() - 1)
                            {
                                // place ship 
                                set_Ship_Inedx_On_Board(player_Board, bow_x - i, stern_y);
                                place_ship = true;
                            }

                        }
                        //if vertical
                        else if (bow_x == stern_x)
                        {
                            // place ship if the diffrince of the nonequial value is the size of the ship -1 
                            //if ship faceing south 
                            if (stern_y > bow_y && stern_y + 1 - (bow_y + 1) == ship.get_Length() - 1)
                            {
                                // place ship 
                                set_Ship_Inedx_On_Board(player_Board, bow_x, stern_y - i);
                                place_ship = true;
                            }
                            // place ship if the diffrince of the nonequial value is the size of the ship -1 
                            //if ship facing north 
                            else if (stern_y < bow_y && bow_y + 1 - (stern_y + 1) == ship.get_Length() - 1)
                            {
                                // place ship 
                                set_Ship_Inedx_On_Board(player_Board, bow_x, stern_y + i);
                                place_ship = true;
                            }
                        }
                    }
                    // if ship not placed 
                    if (!place_ship)
                    {   // clear console, print board , prompt error message ,itterate while loop to place ship.
                        Console.Clear();
                        display_board(player_Board);
                        Console.WriteLine("\nSorry please try again\n");

                    }

                }
                else
                {//triggers if there is ship overlap.
                 // clear console, print board , prompt error message ,itterate while loop to place ship.
                    Console.Clear();
                    display_board(player_Board);
                    Console.WriteLine("\nship cannot go there, please try again!\n");
                }
            }

        }

        //cheaks if there is a ship
        public bool cheak_hit(int x, int y, string[,] board)
        {   //set bool if there is a ship in the location,
            bool is_There_A_Ship_At_This_Location = false;
            //cheak if there is a ship at x,y
            if (board[y, x].Equals("[S]"))
            {   // if a ship at this location set bool to true
                is_There_A_Ship_At_This_Location = true;
            }
            //return value
            return is_There_A_Ship_At_This_Location;



        }
        //fires a rocket 
        public void fire(Opponent opponent)
        {

            Console.WriteLine("fire the cannon at location [X,Y]:");
            // read in location
            string user_Input_Stern = Console.ReadLine();
            //convert location to element values
            int[] location = convert_Cordents(user_Input_Stern);
            //parse values.
            int x = location[0];
            int y = location[1];
            //cheak if ship in location; set bool true/false 
            bool hit = cheak_hit(x, y, opponent.opponent_board);

            // if true reassine the value to a hit mark
            if (hit)
            {
                opponent.opponent_board[y, x] = "[X]";
                opponent.number_of_total_health--;
            }
            //if false reassine the location to a miss value
            else
            {
                opponent.opponent_board[y, x] = "[0]";
            }
            // reprint the boards 
            Console.Clear();
            display_board(opponent.opponent_board);
            Console.WriteLine("");
            display_board(player_Board);

        }
        // for each ship in the player's defult ship list place on the board 
        public void place_Ships_on_Board()
        {
            ///itterate through ship list.
            foreach (Ships ship in player_Ship_List)
            {
                //place ship
                set_Ship_Location(ship);
                //reprint board
                Console.Clear();
                display_board(player_Board);
            }
        }
    }

    public class Opponent : Game
    {
        //intince veriables
        private readonly List<Ships> ship_List;
        private readonly int starting_number_of_ships;
        public int number_of_total_health;
        public string[,] opponent_board;
        private readonly string lastShot = "";
        private int lastShotX = 0;
        private int lastShotY = 0;
        private int lastShotXX = 0;
        private int lastShotYY = 0;



        //constructor
        public Opponent()
        {
            //default ship list 
            ship_List = new List<Ships> {
                new Carrier(),
                new Battleship(),
                new Submarine(),
                new Submarine(),
                new Destroyer(),
                new Destroyer()
            };
            // amount of helth 
            number_of_total_health = 0;
            //get helth value
            foreach (Ships ship in ship_List)
            {
                number_of_total_health += ship.get_Length();
            }

            //create board , set ships on board 
            opponent_board = create_Board();
            Console.WriteLine(" ");
            set_Ship_Location();

        }
        // fire the rockets : based on a random number  (x,y)
        public void fire(Player player)
        {
            Random random = new();
            int i = random.Next(2);
            int x;
            int y;
            // sheak if should hit last hit  ajesent 
            if ((cheak_hit(lastShotX, lastShotY, player.player_Board) || cheak_hit(lastShotXX, lastShotYY, player.player_Board)) && i % 1 == 0)
            {
                if (cheak_hit(lastShotXX, lastShotYY, player.player_Board) && cheak_hit(lastShotX, lastShotY, player.player_Board))
                {
                    y = lastShotY - 1; // hit last shot -/+ 2 
                    if (y < 0)
                    {
                    }
                    else if (y > 10)
                    {
                    }
                }
                x = lastShotX;
                y = lastShotY + 1; // hit last shot -/+ 2 
                if (y < 0)
                {
                    y = 0;
                }
                else if (y > 10)
                {
                    y = 10;
                }

            } // sheak if should hit last hit  ajesent 
            else if ((cheak_hit(lastShotX, lastShotY, player.player_Board) || cheak_hit(lastShotXX, lastShotYY, player.player_Board)) && i % 2 == 0)
            {
                if (cheak_hit(lastShotXX, lastShotYY, player.player_Board) && cheak_hit(lastShotX, lastShotY, player.player_Board))
                {
                    x = lastShotX - 1;

                    if (x < 0)
                    {
                    }
                    else if (x > 10)
                    {
                    }
                }
                // rndom sho
                y = lastShotY;
                x = lastShotX + 1;

                if (x < 0)
                {
                    x = 0;
                }
                else if (x > 10)
                {
                    x = 10;
                }
            }
            else
            {
                //default to a randomshot if last hit was a miss 
                x = random.Next(10);
                y = random.Next(10);
            }



            bool hit = cheak_hit(x, y, player.player_Board);

            if (hit)
            {
                player.player_Board[y, x] = "[X]";
                player.total_ship_health--;



            }
            else
            {
                player.player_Board[y, x] = "[0]";
            }
            //save values 
            lastShotX = x;
            lastShotY = y;

            lastShotXX = lastShotX;
            lastShotYY = lastShotY;

            //clear board, reprint board 
            Console.Clear();
            display_board(opponent_board);
            Console.WriteLine("");
            display_board(player.player_Board);




        }
        // cheak if hit 
        public bool cheak_hit(int x, int y, string[,] board)
        {// bool for marking  grid hit
            bool is_There_A_Ship_At_This_Location = false;
            _ = board[x, y];
            // if ship located at this location, return true 
            if (board[y, x].Equals("[S]"))
            {
                is_There_A_Ship_At_This_Location = true;
            }

            return is_There_A_Ship_At_This_Location;



        }



        public void set_Ship_Location()
        {
            foreach (Ships ship in ship_List)
            {
                Random random = new();

                int length = ship.get_Length();
                bool ship_placed = false;

                while (!ship_placed)
                {
                    int orientation = random.Next(2); // Randomly choose 0 for horizontal or 1 for vertical

                    if (orientation == 0)
                    { // Horizontal placement
                        int ship_y = random.Next(10); // Randomly select a column
                        int ship_X_Bow = random.Next(10 - length + 1); // Ensure the entire ship can fit horizontally
                        int ship_X_Stern = ship_X_Bow + length - 1; // Calculate the position of the stern

                        if (!cheak_If_Ship_Placed(length, ship_X_Bow, ship_y, ship_X_Stern, ship_y))
                        {
                            // Place the ship on the opponent's board
                            for (int i = ship_X_Bow; i <= ship_X_Stern; i++)
                            {
                                set_Ship_Inedx_On_Board(opponent_board, i, ship_y);
                            }
                            ship_placed = true;
                        }
                    }
                    else
                    { // Vertical placement
                        int ship_x = random.Next(10); // Randomly select a row
                        int ship_Y_Bow = random.Next(10 - length + 1); // Ensure the entire ship can fit vertically
                        int ship_Y_Stern = ship_Y_Bow + length - 1; // Calculate the position of the stern

                        if (!cheak_If_Ship_Placed(length, ship_x, ship_Y_Bow, ship_x, ship_Y_Stern))
                        {
                            // Place the ship on the opponent's board
                            for (int i = ship_Y_Bow; i <= ship_Y_Stern; i++)
                            {
                                set_Ship_Inedx_On_Board(opponent_board, ship_x, i);
                            }
                            ship_placed = true;
                        }
                    }
                }
            }
        }
    }
}
