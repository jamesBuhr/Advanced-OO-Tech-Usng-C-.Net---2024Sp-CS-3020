namespace battleship_CS2160

{
    /// <summary>
    ///  gives the outline of what the game should be:
    ///  player(you ) and the ,opponet 
    ///  
    /// </summary>
    public class Game
    {
        string[,] player_Board;
        int rows = 10; // rows of the board 
        int cols = 10; // cols on the board 

        private int opponent_Board;

        public bool cheak_win_condishions(Player player, Opponent opponent)
        {
            bool win = false;
            if (player.total_ship_health <= 0)
            {
                Console.WriteLine("YOU LOSE, YOU MUST REALLY SUCK!");
                win = true;
            }
            else if (opponent.number_of_total_health <= 0)
            {
                Console.WriteLine("YOU WIN ");
                win = true;
            }
            return win;

        }

        public void display_board(string[,] board)
        {
            string[] COLS = { "   [1]", "[2]", "[3]", "[4]", "[5]", "[6]", "[7]", "[8]", "[9]", "[10]" }; //create row and col array for user display interface
            string[] ROWS = { "[A]", "[B]", "[C]", "[D]", "[E]", "[F]", "[G]", "[H]", "[I]", "[J]" };

            //PRINT THE GAME BOARD :
            for (int col = 0; col < cols; col++)
            {                                                 //print 1:10 above the board for each col:
                Console.Write(COLS[col]);
            }

            Console.WriteLine();                                                                   //print a newline to seperate the 1:10 from the game board.

            for (int row = 0; row < rows; row++)
            {                                                 //print the game board.
                Console.Write(ROWS[row]);                                                          //print the grid display A:J for each row. 
                for (int col = 0; col < cols; col++)
                {

                    Console.Write(board[row, col]);                                               //write whats in each element of the 2D Array
                }
                Console.WriteLine();                                                               // print a new line char to seperate each row
            }
        }


        public string[,] create_Board()
        {
            // sets the board size to 10X10
            player_Board = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    player_Board[row, col] = "[ ]";
                }
            }
            return player_Board;
        }

        public bool cheak_If_Ship_Placed(int length_of_ship, int bowX, int bowY, int sternX, int sternY)
        {
            // Check if vertical
            if (bowX == sternX)
            {
                // Determine the start and end positions for the ship along the Y-axis
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
                // Determine the start and end positions for the ship along the X-axis
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

        public virtual bool get_Element(int x, int y)
        {
            bool is_There_A_Ship_At_This_Location = false;

            string element_of_board = player_Board[y, x];

            if (element_of_board == "[S]")
            {
                is_There_A_Ship_At_This_Location = true;
            }

            return is_There_A_Ship_At_This_Location;

            throw new System.NotImplementedException();
        }

        public void set_Ship_Inedx_On_Board(String[,] board, int x, int y)
        {


            board[y, x] = "[S]";

            Console.Clear();
            display_board(board);

        }

        public void play_game(Player player, Opponent opponent)
        {
            while (!cheak_win_condishions(player, opponent))
            {
                player.fire(opponent);
                opponent.fire(player);
            }
        }
    }

    public class Player : Game
    {
        List<Ships> player_Ship_List;
        private int starting_number_of_ships;
        public int total_ship_health = 0;
        private int ship_lengh_counter = 0;
        private int number_Of_Ships_Remaining;
        private int[,] ship_locations;
        public string[,] player_Board;


        public Player()
        {
            player_Ship_List = new List<Ships> {
                new Carrier(),
                new Battleship(),
                new Submarine(),
                new Submarine(),
                new Destroyer(),
                new Destroyer()
            };

            foreach (Ships ship in player_Ship_List)
            {
                this.total_ship_health += ship.get_Length();
            }

            ship_locations = new int[2, this.total_ship_health];
            starting_number_of_ships = player_Ship_List.Count;
            number_Of_Ships_Remaining = starting_number_of_ships;
            player_Board = create_Board();
            display_board(player_Board);
            place_Ships_on_Board();




        }

        public int[] convert_Cordents(string input)
        {
            // Ensure the input is in the correct format (e.g., "A4")
            if (input.Length < 2 || input.Length > 3 || !char.IsLetter(input[0]) || !char.IsDigit(input[input.Length - 1]))
            {
                throw new ArgumentException("Invalid input format. Please enter a location in the format 'A1' to 'J10'.");
            }

            // Convert the letter part to a numeric index (A -> 0, B -> 1, etc.)
            int col = char.ToUpper(input[0]) - 'A';

            // Convert the digit part to a numeric index (1 -> 0, 2 -> 1, etc.)
            int row = int.Parse(input.Substring(1)) - 1;

            // Return the indices as an array
            return new int[] { row, col };
        }

        public void set_Ship_Location(Ships ship)
        {
            int bow_x = 0;
            int bow_y = 0;
            int stern_x = 0;
            int stern_y = 0;
            int shipSize = ship.get_Length();
            int[] location = new int[2];
            bool place_ship = false;


            // while the distince of the ship isnt equial to the absolute value of size of the ship : "-ship.length / +ship.length
            // continue to try fo find a place for the ship
            while (!place_ship)
            {
                //prompt user what ship to place and how big the ship is :
                Console.WriteLine("\nPlace your " + ship.get_Name() + " of length " + shipSize);
                //select location to place the Bow


                Console.WriteLine("\nPlace Bow");

                string user_Input_Bow = Console.ReadLine();

                location = convert_Cordents(user_Input_Bow);
                bow_x = location[0];
                bow_y = location[1];


                //select location to place the Stern

                Console.WriteLine("Place stern");
                string user_Input_Stern = Console.ReadLine();
                location = convert_Cordents(user_Input_Stern);


                stern_x = location[0];
                stern_y = location[1];


                //cheak if ship in this location:
                if (!cheak_If_Ship_Placed(ship.get_Length(), bow_x, bow_y, stern_x, stern_y))
                {
                    //set global (X,Y)
                    for (int i = 0; i < ship.get_Length(); i++)
                    {
                        //if horizontal
                        if (bow_y == stern_y)
                        {

                            if (stern_x > bow_x)
                            {
                                set_Ship_Inedx_On_Board(player_Board, bow_x + i, stern_y);
                            }
                            else if (stern_x < bow_x)
                            {
                                set_Ship_Inedx_On_Board(player_Board, bow_x - i, stern_y);
                            }

                        }
                        //if vertical
                        else if (bow_x == stern_x)
                        {

                            if (stern_y > bow_y)
                            {
                                set_Ship_Inedx_On_Board(player_Board, bow_x, stern_y - i);
                            }
                            else if (stern_y < bow_y)
                            {
                                set_Ship_Inedx_On_Board(player_Board, bow_x, stern_y + i);
                            }
                        }
                    }



                    //set ships local (X,Y)
                    ship.set_BowX(bow_x);
                    ship.set_BowY(bow_y);
                    ship.set_SternX(stern_x);
                    ship.set_SternY(stern_y);
                    place_ship = true;

                }
                else
                {//triggers if there is ship overlap.
                    Console.WriteLine("ship cannot go there, please try again!");
                    break;
                }


            }


        }


        public bool cheak_hit(int x, int y, string[,] board)
        {
            bool is_There_A_Ship_At_This_Location = false;

            string element_of_board = board[x, y];

            if (board[y, x].Equals("[S]") || board[y, x].Equals("[X]"))
            {
                is_There_A_Ship_At_This_Location = true;
            }

            return is_There_A_Ship_At_This_Location;



        }

        public void fire(Opponent opponent)
        {
            string[,] board = opponent.opponent_board;
            int[] location = new int[2];
            Console.WriteLine("fire the cannon at location [X,Y]:");

            string user_Input_Stern = Console.ReadLine();
            location = convert_Cordents(user_Input_Stern);
            int x = location[0];
            int y = location[1];
            bool hit = cheak_hit(x, y, opponent.opponent_board);

            if (hit)
            {
                opponent.opponent_board[y, x] = "[X]";
                opponent.number_of_total_health--;
            }
            else
            {
                board[y, x] = "[0]";
            }

            Console.Clear();
            display_board(board);
            Console.WriteLine("");
            display_board(this.player_Board);




        }

        public void display()
        {
            throw new System.NotImplementedException();
        }

        public void get_ship_location()
        {
            throw new System.NotImplementedException();
        }

        public void place_Ships_on_Board()
        {
            foreach (Ships ship in player_Ship_List)
            {
                set_Ship_Location(ship);
                Console.Clear();
                display_board(player_Board);
            }
        }
    }

    public class Opponent : Game
    {
        List<Ships> ship_List;
        private int starting_number_of_ships;
        private int number_Of_Ships_Remaining;
        public int number_of_total_health;
        private string[] ship_locations;
        public string[,] opponent_board;
        String lastShot = "";
        int lastShotX = 0;
        int lastShotY = 0;



        public Opponent()
        {

            ship_List = new List<Ships> {
                new Carrier(),
                new Battleship(),
                new Submarine(),
                new Submarine(),
                new Destroyer(),
                new Destroyer()
            };
            number_of_total_health = 0;
            foreach (Ships ship in ship_List)
            {
                this.number_of_total_health += ship.get_Length();
            }


            opponent_board = create_Board();
            Console.WriteLine(" ");
            //display_board(opponent_board);
            set_Ship_Location();




            starting_number_of_ships = ship_List.Count;
            ship_locations = new string[starting_number_of_ships];
            number_Of_Ships_Remaining = starting_number_of_ships;


        }

        public void get_ship_locations()
        {
            foreach (Ships ship in ship_List)
                throw new System.NotImplementedException();
        }

        public void fire(Player player)
        {
            Random random = new Random();
            int x = 0;
            int y = 0;
            int i = random.Next(2);



            if (this.lastShot.Equals("[X]") && i % 1 == 0)
            {
                y = this.lastShotX + random.Next(2);
                if (y < 0)
                {
                    y = 0;
                }
                else if (y > 10)
                {
                    y = 10;
                }

            }
            else if (this.lastShotY.Equals("[X]") && i % 2 == 0)
            {
                x = this.lastShotY + random.Next(2);

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

            this.lastShotX = x;
            this.lastShotY = y;

            Console.Clear();
            display_board(opponent_board);
            Console.WriteLine("");
            display_board(player.player_Board);




        }

        public bool cheak_hit(int x, int y, string[,] board)
        {
            bool is_There_A_Ship_At_This_Location = false;

            string element_of_board = board[x, y];

            if (board[y, x].Equals("[S]") || board[y, x].Equals("[X]"))
            {
                is_There_A_Ship_At_This_Location = true;
            }

            return is_There_A_Ship_At_This_Location;



        }



        public void set_Ship_Location()
        {
            foreach (Ships ship in ship_List)
            {
                Random random = new Random();

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
