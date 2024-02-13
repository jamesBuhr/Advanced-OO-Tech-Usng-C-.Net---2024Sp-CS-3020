namespace battleship_CS2160

{

    public abstract class Game
    {
        int turn_Number;
        int rows =10;
        int cols = 10; 
        String [,] player_Board;
        private int opponent_Board;

        public void cycle_Turn()
        {
            this.turn_Number++;
            throw new System.NotImplementedException();
        }

        public void cheak_win_condishions()
        {
            throw new System.NotImplementedException();
        }

        public void display_board(string[,]board)
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

        public string[,] create_Board()
        {
            // sets the board size to 10X10
            string[,] player_Board = new string[rows, cols];

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
            bool ship_overlaped = false;
            for (int i = 0; i < length_of_ship; i++) {

                //if vertical
                if (bowX == sternX)
                {
                    if (sternY < bowY)
                    {
                        ship_overlaped = get_Element(bowX, sternY + i);
                    }
                    else if (sternY > bowY)
                    {
                        ship_overlaped = get_Element(bowX, sternY - i);

                    }
                }

                //if horizontal
                if (bowY == sternY) {

                    if (sternX > bowX)
                    {
                        ship_overlaped = get_Element(bowX+i, sternY);
                    }
                    else if (sternX < bowX)
                    {
                        ship_overlaped = get_Element(bowX-i, sternY);

                    }


                }
                

            }

            return ship_overlaped;
            throw new System.NotImplementedException();

        }

        public void set_Ship_Inedx_On_Board(String[,] board,int row, int col)
        {
            board[row, col] = "[S]";
            throw new System.NotImplementedException();
        }
    }

    public class Player : Game
    {
        List<Ships> player_Ship_List;
        private int starting_number_of_ships;
        private int total_ship_health = 0;
        private int ship_lengh_counter = 0;
        private int number_Of_Ships_Remaining;
        private int[,] ship_locations;
        private string[,] player_Board;

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

            foreach (Ships ship in player_Ship_List) {
                this.total_ship_health += ship.get_Length();
            }

            ship_locations = new int[2,this.total_ship_health];
            starting_number_of_ships = player_Ship_List.Count;
            number_Of_Ships_Remaining = starting_number_of_ships;
            player_Board = create_Board();
            display_board(player_Board);
            place_Ships_on_Board();




        }

        public int[] convert_Cordents(string input)
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

        public void set_Ship_Location(Ships ship)
        {
            int bow_x = 0;
            int bow_y = 0;
            int stern_x = 0;
            int stern_y = 0;
            int shipSize = ship.get_Length();
            int[] location;
            

            // while the distince of the ship isnt equial to the absolute value of size of the ship : "-ship.length / +ship.length
            // continue to try fo find a place for the ship
            while (bow_x - stern_x != ship.get_Length()
        || bow_x - stern_x != ship.get_Length() * -1
        || stern_y - bow_y != ship.get_Length()
        || stern_y - bow_y != ship.get_Length() * -1

                )                           
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

                    //if ship vertical
                    if (bow_x == stern_x && bow_x - stern_x == ship.get_Length() || bow_x - stern_x == ship.get_Length() * -1)
                    {
                        for (int i = 0; i < ship.get_Length(); i++)
                        {
                            if (stern_y < bow_y)
                            {
                                ship_locations[0, ship_lengh_counter] = stern_y + i;
                                ship_locations[1, ship_lengh_counter] = bow_x;
                            }
                            else if (stern_y > bow_y)
                            {
                                ship_locations[0, ship_lengh_counter] = stern_y - i;
                                ship_locations[1, ship_lengh_counter] = bow_x;
                            }
                            ship_lengh_counter++;
                        }


                    }
                    //if ship horizontal
                    else if (bow_y == stern_y && bow_x - stern_x == ship.get_Length() || bow_x - stern_x == ship.get_Length() * -1)
                    {

                        for (int i = 0; i < ship.get_Length(); i++)
                        {

                            if (stern_x > bow_x)
                            {
                                ship_locations[0, ship_lengh_counter] = bow_x + i;
                                ship_locations[1, ship_lengh_counter] = bow_y;
                            }
                            else if (stern_x < bow_x)
                            {
                                ship_locations[0, ship_lengh_counter] = bow_x - i;
                                ship_locations[1, ship_lengh_counter] = bow_y;
                            }
                            ship_lengh_counter++;

                        }

                    }
                    else
                    {
                        Console.WriteLine("ship cannot go there, please try again!");
                    }

                    //set ships local (X,Y)
                    ship.set_BowX(bow_x);
                    ship.set_BowY(bow_y);
                    ship.set_SternX(stern_x);
                    ship.set_SternY(stern_y);

                    //set global (X,Y)
                    for (int i = 0; i < ship.get_Length(); i++) {

                        //set_Ship_On_Board()
                        //ship_locations[0, ship_lengh_counter - i];//x cord
                        //ship_locations[1, ship_lengh_counter - i]; //y cord 
                        
                    }


                }else
                {//triggers if there is ship overlap.
                    Console.WriteLine("ship cannot go there, please try again!");
                }
                

                
                

           }


        }

        public bool get_Element(int row, int col)
        {
            bool is_There_A_Ship_At_This_Location = false;

            string element_of_board = player_Board[row, col];

            if (element_of_board == "[S]")
            {
                is_There_A_Ship_At_This_Location = true;
            }

            return is_There_A_Ship_At_This_Location;

            throw new System.NotImplementedException();
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

        public void place_Ships_on_Board()
        {
            foreach (Ships ship in player_Ship_List) {
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
        private string[] ship_locations;
        


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