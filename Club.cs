using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallClub
{
    internal class Club
    {
        public string Name;
        public int Points;
        public int GoalDifference;
        public int GoalsScored;

        public Club(string name, int points, int goalDifference, int goalsScored)
        {
            Name = name;
            Points = points;
            GoalDifference = goalDifference;
            GoalsScored = goalsScored;
        }
    }
}
