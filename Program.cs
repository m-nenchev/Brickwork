using System;

namespace Wall
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 0;
            int n = 0;

            // check if М is integer
            Console.Write("Insert M: ");
            string mStr = Console.ReadLine();
            if (!int.TryParse(mStr, out m))
            {
                Console.WriteLine("M is not an integer. End of program.");
                return;
            }

            // check if M is even
            if (m % 2 != 0)
            {
                Console.WriteLine("M is not an even integer. End of program.");
                return;
            }

            // check if N is  integer
            Console.Write("Insert N: ");
            string nStr = Console.ReadLine();
            if (!int.TryParse(nStr, out n))
            {
                Console.WriteLine("N is not an integer. End of program.");
                return;
            }

            // check if N is even
            if (n % 2 != 0 )
            {
                Console.WriteLine("N is not an even integer. End of program.");
                return;
            }
             //check if N is > 3 lines
            if (n > 3)
	        {
                Console.WriteLine(" N cannot be more than the number 3");
                return;
	        }

            int sumNAndM = n*m;
             //check if M is > 100 lines
            if (sumNAndM > 100)
	        {
             Console.WriteLine("cannot have more than 100 columns");
	          return;
	        }
            Wall wall = CreateWall(m, n);
            PrintWall(wall);

            Console.ReadLine();

        }

        private static Wall CreateWall(int m, int n)
        {
            // create objeckt in array Wall and initialization on params
            Wall wall = new Wall();
            wall.M = m;
            wall.N = n;
            wall.Layers = new Layer[n];

            // each layer is set as an object in the array:
            for (int l = 0; l < n; l++)
            {
                Layer layer = new Layer();
                // whether an even row is used and it is checked whether l is / 2 without remainder
                layer.IsEven = (l-1) % 2 == 0;

                // the array with the number of bricks is initialized
                layer.Bricks = new Brick[m];

                // vsiaka tuhla se sazdava v masiva s tuhli
                for (int t = 0; t < m; t++)
                {
                    Brick brick = new Brick();

                    // the brick number is considered as:
                    // t + 1, because t starts from 0 - index of the array, and the numbering of the bricks starts from 1
                    brick.Number =  t + 1; 

                    // add the brick to the row:
                    layer.Bricks[t] = brick;
                }

                // add row to the wall array
                wall.Layers[l] = layer;
            }

            return wall;
        }

        private static void PrintWall(Wall wall)
        {
            for(int l = 0; l < wall.Layers.Length; l++)
            {
                Layer layer = wall.Layers[l];
                if (layer.IsEven)
                {
                    // Finding an even order: 2,4,6,...
                    Brick firstBrick = layer.Bricks[1];
                    Brick lastBrick = layer.Bricks[layer.Bricks.Length - 1];

                    //washing the middle of the bricks:
                    var half = wall.M / 2;

                    // Draw the first line:
                    //the zero index is the first brick, which is vertically executed
                    // all other bricks will be horizontal to the penultimate index
                    // the last index will be on the last brick in the row, which will also be vertical
                    
                    Console.Write($"{firstBrick.Number} ");
                    
                    
                    for (int i = 1; i < half; i++)
                    {
                        Brick brick = layer.Bricks[0];
                        Console.Write($"{brick.Number} {brick.Number} ");
                    }

                    Console.Write($"{lastBrick.Number} ");

                    Console.WriteLine();

                    // Derivation of the second row / Starts again with the index of the first brick, all other bricks from the second half of the row
                    // and ends with an index of the last brick

                    Console.Write($"{firstBrick.Number} ");

                    // starts from the middle and ends to the penultimate brick of the second half of the row
                    for (int i = half; i < layer.Bricks.Length - 1; i++)
                    {
                        Brick brick = layer.Bricks[i];
                        Console.Write($"{brick.Number} {brick.Number} ");
                    }

                    Console.Write($"{lastBrick.Number} ");

                    Console.WriteLine();
                }
                else
                {
                    // Out of odd order: number 1,3,5,...
                    // half of the bricks will be displayed in the first row:
                    // the second half in the second row:
                    var half = wall.M / 2;

                    // drawing the first line:
                    for(int i = 0; i < half; i++)
                    {
                        Brick brick = layer.Bricks[i];
                        Console.Write($"{brick.Number} {brick.Number} ");
                    }

                    Console.WriteLine();

                    // drawing the second  line::
                    for (int i = half; i < layer.Bricks.Length; i++)
                    {
                        Brick brick = layer.Bricks[i];
                        Console.Write($"{brick.Number} {brick.Number} ");
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
