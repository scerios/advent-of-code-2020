using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class DayFive
    {
        public static void PartOne(string[] lines)
        {
            double minRow = 0;
            double maxRow = 127.0;
            double minSeat = 0;
            double maxSeat = 7.0;

            int indexer = 0;
            int row = 0;
            int seat = 0;
            int highestSeatId = 0;

            foreach (string line in lines)
            {
                while (indexer < 6)
                {
                    if (line[indexer] == 'F')
                    {
                        maxRow = Math.Floor((minRow + maxRow) / 2);
                        indexer++;
                        continue;
                    }
                    minRow = Math.Ceiling((minRow + maxRow) / 2);

                    indexer++;
                }

                if (line[indexer] == 'F')
                {
                    row = Convert.ToInt32(minRow);
                }
                else
                {
                    row = Convert.ToInt32(maxRow);
                }

                indexer++;

                while (indexer < 9)
                {
                    if (line[indexer] == 'L')
                    {
                        maxSeat = Math.Floor((minSeat + maxSeat) / 2);
                        indexer++;
                        continue;
                    }
                    minSeat = Math.Ceiling((minSeat + maxSeat) / 2);

                    indexer++;
                }

                if (line[indexer] == 'L')
                {
                    seat = Convert.ToInt32(minSeat);
                }
                else
                {
                    seat = Convert.ToInt32(maxSeat);
                }

                int seatId = row * 8 + seat;

                if (seatId > highestSeatId)
                {
                    highestSeatId = seatId;
                }

                indexer = 0;
                minRow = 0;
                maxRow = 127.0;
                minSeat = 0;
                maxSeat = 7.0;

            }

            Console.WriteLine(highestSeatId);
        }

        public static void PartTwo(string[] lines)
        {
            double minRow = 0;
            double maxRow = 127.0;
            double minSeat = 0;
            double maxSeat = 7.0;

            int indexer = 0;
            int row = 0;
            int seat = 0;
            int mySeatId = 0;
            List<int> seatIds = new List<int>();

            foreach (string line in lines)
            {
                while (indexer < 6)
                {
                    if (line[indexer] == 'F')
                    {
                        maxRow = Math.Floor((minRow + maxRow) / 2);
                        indexer++;
                        continue;
                    }
                    minRow = Math.Ceiling((minRow + maxRow) / 2);

                    indexer++;
                }

                if (line[indexer] == 'F')
                {
                    row = Convert.ToInt32(minRow);
                }
                else
                {
                    row = Convert.ToInt32(maxRow);
                }

                indexer++;

                while (indexer < 9)
                {
                    if (line[indexer] == 'L')
                    {
                        maxSeat = Math.Floor((minSeat + maxSeat) / 2);
                        indexer++;
                        continue;
                    }
                    minSeat = Math.Ceiling((minSeat + maxSeat) / 2);

                    indexer++;
                }

                if (line[indexer] == 'L')
                {
                    seat = Convert.ToInt32(minSeat);
                }
                else
                {
                    seat = Convert.ToInt32(maxSeat);
                }

                int seatId = row * 8 + seat;

                seatIds.Add(seatId);

                indexer = 0;
                minRow = 0;
                maxRow = 127.0;
                minSeat = 0;
                maxSeat = 7.0;

            }

            var ascendingOrder = seatIds.OrderBy(i => i).ToList();

            foreach (int id in ascendingOrder)
            {
                if (!ascendingOrder.Contains(id + 1))
                {
                    if (ascendingOrder.Contains(id + 2))
                    {
                        mySeatId = id + 1;
                        break;
                    }
                }
            }

            Console.WriteLine(mySeatId);
        }
    }
}
