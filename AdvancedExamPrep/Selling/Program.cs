using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Channels;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var bakeryShape = new char[n, n];
            int rowStartPosition = 0;
            int colStartPosition = 0;
            for (int rows = 0; rows < n; rows++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < currRow.Length; cols++)
                {
                    bakeryShape[rows, cols] = currRow[cols];
                    if (currRow[cols] == 'S')
                    {
                        rowStartPosition = rows;
                        colStartPosition = cols;
                    }
                }
            }

            /* You will be placed on a random position, marked with the letter 'S'. On random positions
             there will be clients, marked with a single digit. There may also be pillars. Their count 
             will be either 0 or 2 and they are marked with the letter - 'O'. All of the empty positions 
             will be marked with '-'.*/
            /*
             7 7 7 7
             7 7 7 7
             7 7 7 7
             7 7 7 7
             */
            int moneyNeeded = 0;
            bool isInVoid = true;
            while (moneyNeeded<50)
            {
                string inoutCommand = Console.ReadLine();
                if (inoutCommand == "up")
                {
                    if (rowStartPosition - 1 >= 0)
                    {
                        bakeryShape[rowStartPosition, colStartPosition] = '-';
                        if (bakeryShape[rowStartPosition - 1, colStartPosition] >= '0' &&
                            bakeryShape[rowStartPosition - 1, colStartPosition] <= '9')
                        {
                            moneyNeeded += int.Parse(bakeryShape[rowStartPosition - 1, colStartPosition].ToString());
                            bakeryShape[rowStartPosition - 1, colStartPosition] = 'S';
                            rowStartPosition = rowStartPosition - 1;
                        }
                        else if (bakeryShape[rowStartPosition - 1, colStartPosition]=='O')
                        {
                            bakeryShape[rowStartPosition - 1, colStartPosition] = '-';
                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (bakeryShape[rows,cols]=='O')
                                    {
                                        rowStartPosition = rows;
                                        colStartPosition = cols;
                                        bakeryShape[rows, cols] = 'S';
                                    }
                                }
                            }
                        }
                        else
                        {
                            bakeryShape[rowStartPosition - 1, colStartPosition] = 'S';
                            rowStartPosition = rowStartPosition - 1;
                        }
                    }
                    else
                    {
                        bakeryShape[rowStartPosition, colStartPosition] = '-';
                        isInVoid = false;
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }
                }
                else if (inoutCommand == "down")
                {
                    if (rowStartPosition + 1 <= n-1)
                    {
                        bakeryShape[rowStartPosition, colStartPosition] = '-';
                        if (bakeryShape[rowStartPosition + 1, colStartPosition] >= '0' &&
                            bakeryShape[rowStartPosition + 1, colStartPosition] <= '9')
                        {
                            moneyNeeded += int.Parse(bakeryShape[rowStartPosition + 1, colStartPosition].ToString());
                            bakeryShape[rowStartPosition + 1, colStartPosition] = 'S';
                            rowStartPosition = rowStartPosition + 1;
                        }
                        else if (bakeryShape[rowStartPosition + 1, colStartPosition]=='O')
                        {
                            bakeryShape[rowStartPosition + 1, colStartPosition] = '-';
                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (bakeryShape[rows,cols]=='O')
                                    {
                                        rowStartPosition = rows;
                                        colStartPosition = cols;
                                        bakeryShape[rows, cols] = 'S';
                                    }
                                }
                            }
                        }
                        else
                        {
                            bakeryShape[rowStartPosition + 1, colStartPosition] = 'S';
                            rowStartPosition = rowStartPosition + 1;
                        }
                    }
                    else
                    {
                        bakeryShape[rowStartPosition, colStartPosition] = '-';
                        isInVoid = false;
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }
                }
                else if (inoutCommand == "left")
                {
                    if (colStartPosition - 1 >= 0)
                    {
                        bakeryShape[rowStartPosition, colStartPosition] = '-';
                        if (bakeryShape[rowStartPosition, colStartPosition - 1] >= '0' &&
                            bakeryShape[rowStartPosition, colStartPosition - 1] <= '9')
                        {
                            moneyNeeded += int.Parse(bakeryShape[rowStartPosition, colStartPosition - 1].ToString());
                            bakeryShape[rowStartPosition, colStartPosition - 1] = 'S';
                            colStartPosition = colStartPosition - 1;
                        }
                        else if (bakeryShape[rowStartPosition, colStartPosition - 1]=='O')
                        {
                            bakeryShape[rowStartPosition, colStartPosition - 1] = '-';
                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (bakeryShape[rows,cols]=='O')
                                    {
                                        rowStartPosition = rows;
                                        colStartPosition = cols;
                                        bakeryShape[rows, cols] = 'S';
                                    }
                                }
                            }
                        }
                        else
                        {
                            bakeryShape[rowStartPosition, colStartPosition - 1] = 'S';
                            colStartPosition = colStartPosition - 1;
                        }
                    }
                    else
                    {
                        bakeryShape[rowStartPosition, colStartPosition] = '-';
                        isInVoid = false;
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }
                }
                else
                {
                    if (colStartPosition + 1 <= n-1)
                    {
                        bakeryShape[rowStartPosition, colStartPosition] = '-';
                        if (bakeryShape[rowStartPosition, colStartPosition + 1] >= '0' &&
                            bakeryShape[rowStartPosition, colStartPosition + 1] <= '9')
                        {
                            moneyNeeded += int.Parse(bakeryShape[rowStartPosition, colStartPosition + 1].ToString());
                            bakeryShape[rowStartPosition, colStartPosition + 1] = 'S';
                            colStartPosition = colStartPosition + 1;
                        }
                        else if (bakeryShape[rowStartPosition, colStartPosition + 1]=='O')
                        {
                            bakeryShape[rowStartPosition, colStartPosition + 1] = '-';
                            for (int rows = 0; rows < n; rows++)
                            {
                                for (int cols = 0; cols < n; cols++)
                                {
                                    if (bakeryShape[rows,cols]=='O')
                                    {
                                        rowStartPosition = rows;
                                        colStartPosition = cols;
                                        bakeryShape[rows, cols] = 'S';
                                    }
                                }
                            }
                        }
                        else
                        {
                            bakeryShape[rowStartPosition, colStartPosition + 1] = 'S';
                            colStartPosition = colStartPosition + 1;
                        }
                    }
                    else
                    {
                        bakeryShape[rowStartPosition, colStartPosition] = '-';
                        isInVoid = false;
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }
                }
            }

            if (isInVoid)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {moneyNeeded}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(bakeryShape[i,j]);
                }

                Console.WriteLine();
            }
        }
    }
}