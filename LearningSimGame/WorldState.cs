using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSimGame
{
    public class WorldState
    {
        static int[,] worldMap = new int[100,100];


        public int[,] getMap()
        {
            return worldMap;
        }

    }
}
