using System;

namespace GoldFinding
{
    class GoldFinding
    {
        
        public int goldCheck(string [,] gAndb2)
        {
            string compare;
            int score = 0;
            int guess = 5;

            do
            {
                guess--;
                Console.Write(" Enter x coordinate : ");
                int xCo = int.Parse(Console.ReadLine());
               // taking input from user for x-coordinate.         
                Console.WriteLine();
                Console.Write(" Enter y coordinate : ");
                int yCo = int.Parse(Console.ReadLine());
                // taking input from user for y-coordinate
                Console.WriteLine();
               
                compare = gAndb2[xCo, yCo];
                if (string.Compare(compare,"G") == 0) {
                    score++;
                    Console.WriteLine("You Found Gold !! , you got and extra move ");
                    Console.WriteLine();
                    gAndb2[xCo, yCo] = "F";
                }
                if (string.Compare(compare, "B") == 0) {
                    Console.WriteLine(" Game OVER  , bomb is here ");
                    Console.WriteLine();
                    break;
                }
                if (string.Compare(compare, " ") == 0) {
                    Console.WriteLine("Too Bad !! you have " + guess + " more to go ");
                    Console.WriteLine();
                }
              
            } while (guess > 0);

          
          
            return score;
        
        }
        public string[,] setGoldandBomb(string [,] gAndb)
        {
            
            int row, colum , rowLimit=7, columLimit=7;
            Random G = new Random(); // Placing Gold
            Random B = new Random(); // Placing bomb
            String[,] goldandBomb = new string[8, 8];
            for (int x = 0; x <= rowLimit; x++)
            {
                for (int y = 0; y <= columLimit; y++)
                {
                    goldandBomb[x, y] = " "; // initializing with blanck spaces
                }
            }

            for (int z = 0; z < 5; z++)
            {
                 row = G.Next(0, 7); //for x-coordinate
                 colum = G.Next(0, 7); //for y-coordinate
                 goldandBomb[row, colum] = "G"; // placing gold on random locations
               
                
           }

            row =B.Next(0, 7); //for x-coordinate
            colum = B.Next(0, 7); //for y-coordinate
            goldandBomb[row,colum] = "B";

            return goldandBomb;
       }
       


        public void display(string [,] loadedArray )
        {
            Console.WriteLine();
            Console.WriteLine("     1  2  3  4  5  6  7  8");
            Console.WriteLine("-----------------------------------");
            for (int y = 0; y <= 7; y++)
            {
                Console.Write(" ");
                Console.Write(y+1  + " | ");
                for (int z = 0; z <= 7; z++)
                {
                    Console.Write(loadedArray[y, z] + "  ");

                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------");
        }
    
        static void Main()
        {
            string input, opt = "y";
            const int rowSize = 8, colSize = 8;// constant integar declare
            // initializing the array with '?' (hidden board)
            String[,] hiddenBoard = new string[rowSize, colSize];
            Console.WriteLine();
            Console.WriteLine("     1  2  3  4  5  6  7  8");
            Console.WriteLine("-----------------------------------");
            for (int x = 0; x < colSize; x++)
            {
                Console.Write(" ");
                Console.Write(  x+1 +" | ");
                for (int y = 0; y < rowSize; y++)
                {
                    hiddenBoard[x, y] = "?"; // Assigning Values to the hiddenBoard
                    Console.Write(hiddenBoard[x,y] + "  " ); // Displaying the hidden board
                }
                    Console.WriteLine();
            }
             Console.WriteLine("  ----------------------------------- ");
             Console.WriteLine(" * *  ***************************  * *");
             Console.WriteLine(" * *          Find GOLD            * *");
             Console.WriteLine(" * *     You have 5 guesses,       * *");
             Console.WriteLine(" * *      5 pieces of Gold         * *");
             Console.WriteLine(" * *        And 1 Bomb             * *");
             Console.WriteLine(" * *        GOOD LUCK!             * *");
             Console.WriteLine(" * *  ***************************  * *");
  
        do
            {
              GoldFinding obj = new GoldFinding();// creatin object for function call
              String[,] GandB = obj.setGoldandBomb(hiddenBoard);// Function Call
              int score= obj.goldCheck(GandB);       
              Console.WriteLine(" You Earn " + score + " points");
              Console.WriteLine(" Better Luck Next Time !! ");
              Console.WriteLine(" Here is your board ");

              obj.display(GandB);  // parsing Array to the function

              Console.WriteLine("  Enter y to play again ");
              input= Console.ReadLine();
           } while (string.Compare(opt,input)==0);


            Console.ReadKey();
        }   
    }         
}           