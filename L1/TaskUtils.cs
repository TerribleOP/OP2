using System.Collections.Generic;
using System;

namespace L1
{
    /// <summary> 
    /// Class meant to store task related methods 
    /// </summary> 
    public class TaskUtils
    {
        /// <summary> 
        /// generates the random numbers used for the random colour layout 
        /// </summary> 
        /// <param name="N"></param> 
        /// <param name="M"></param> 
        /// <returns></returns> 
        public static Square[,] GenerateMap(int N, int M)
        {
            Random rnd = new Random();
            Square[,] Map = new Square[N, M];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    int colour = rnd.Next(0, 3);
                    Map[i, j] = new Square(i, j, colour);
                }
            }
            return Map;
        } 
        /// <summary> 
        /// Finds the largest area  
        /// </summary> 
        /// <param name="map"></param> 
        /// <param name="N"></param> 
        /// <param name="M"></param> 
        /// <param name="size"></param> 
        /// <param name="largestColor"></param> 
        public static void FindLargestConnectedArea(Square[,] map, int N, int M,ref int size, ref int largestColor)
        {
            int largestArea = 0;
            List<(int, int)> largestRegion = new List<(int, int)>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (!map[i, j].AlreadyIterated)
                    {
                        List<(int, int)> currentRegion = new List<(int, int)>();
                        int areaSize = DFS(map, N, M, i, j, map[i, j].Colour,currentRegion);

                        if (areaSize > largestArea)
                        {
                            largestArea = areaSize;
                            largestRegion = new List<(int, int)>(currentRegion);
                            largestColor = map[i, j].Colour;
                        }
                    }
                }
            }
            AnswerSetting(map, largestRegion, ref size);
        } 
        /// <summary> 
        /// finds the largest area that is connected but only of the specified "Winner" colour
        /// </summary> 
        /// <param name="map"></param> 
        /// <param name="N"></param> 
        /// <param name="M"></param> 
        /// <param name="size"></param> 
        /// <param name="largestColor"></param> 
        public static void FindLargestConnectedAreaColour(Square[,] map, int N,int M, ref int size, ref int largestColor)
        {
            int largestArea = 0;
            List<(int, int)> largestRegion = new List<(int, int)>();

            ResetAnswerTag(map, N, M);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (!map[i, j].AlreadyIterated && map[i, j].Colour ==largestColor)
                    {
                        List<(int, int)> currentRegion = new List<(int, int)>();
                        int areaSize = DFS(map, N, M, i, j, largestColor,currentRegion);

                        if (areaSize > largestArea)
                        {
                            largestArea = areaSize;
                            largestRegion = new List<(int, int)>(currentRegion);
                        }
                    }
                }
            }
            AnswerSetting(map, largestRegion, ref size);
        }
        /// <summary> 
        /// Resets the visited before status. Used so that it can count the second (smaller) blob without logic problems
        /// </summary> 
        /// <param name="map"></param> 
        /// <param name="N"></param> 
        /// <param name="M"></param> 
        public static void ResetAnswerTag(Square[,] map, int N, int M)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    map[i, j].AlreadyIterated = false;
                }
            }
        }

        /// <summary> 
        /// Recursive path finding method, that finds the largest blob of the same colour
        /// </summary> 
        /// <param name="map"></param> 
        /// <param name="N"></param> 
        /// <param name="M"></param> 
        /// <param name="x"></param> 
        /// <param name="y"></param> 
        /// <param name="color"></param> 
        /// <param name="region"></param> 
        /// <returns></returns> 
        static int DFS(Square[,] map, int N, int M, int x, int y, int color, List<(int, int)> region)
        {
            if (x < 0 || x >= N || y < 0 || y >= M || map[x, y].AlreadyIterated || map[x, y].Colour != color) 
                return 0;

            map[x, y].AlreadyIterated = true;
            region.Add((x, y));

            int size = 1;
            size += DFS(map, N, M, x - 1, y, color, region); // Up 
            size += DFS(map, N, M, x + 1, y, color, region); // Down 
            size += DFS(map, N, M, x, y - 1, color, region); // Left 
            size += DFS(map, N, M, x, y + 1, color, region); // Right 

            return size;
        }
        /// <summary> 
        /// Purges the previously set .Answer tag to false. Used to correctly set the path in the second(smaller) square
        /// </summary> 
        /// <param name="map"></param> 
        /// <param name="N"></param> 
        /// <param name="M"></param> 
        public static void RemoveAnswerTag(Square[,] map, int N, int M)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    map[i, j].Answer = false;
                }
            }
        }
        /// <summary> 
        /// Sets the Square.Answer property to true if it was found to the in the largest area blob
        /// </summary> 
        /// <param name="map"></param> 
        /// <param name="largestRegion"></param> 
        /// <param name="size"></param> 
        public static void AnswerSetting(Square[,] map, List<(int, int)>largestRegion, ref int size)
        {
            foreach (var (x, y) in largestRegion)
            {
                map[x, y].Answer = true;
                size++;
            }
        }
        /// <summary> 
        /// Finds the coordinates of the shared vectical point (same colour above and bellow) 
        /// </summary> 
        /// <param name="mapOne"></param> 
        /// <param name="mapTwo"></param> 
        /// <param name="N"></param> 
        /// <param name="M"></param> 
        /// <param name="sharedX"></param> 
        /// <param name="sharedY"></param> 
        public static void SharedPoint(Square[,] mapOne, Square[,] mapTwo, int N,int M, ref int sharedX, ref int sharedY)
        {
            if (N > 2 && M > 2)
            {
                for (int i = 1; i < N - 1; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (mapOne[i, j].Answer && mapTwo[i, j].Answer)
                        {
                            bool hasAbove = (mapOne[i - 1, j].Answer || mapTwo[i -1, j].Answer);
                            bool hasBelow = (mapOne[i + 1, j].Answer || mapTwo[i +1, j].Answer);

                            if (hasAbove && hasBelow)
                            {
                                sharedX = i;
                                sharedY = j;
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}