namespace FootBallClub
{
    class Program
    {
        static void Main(string[] args)
        {
            Club[] clubs =
            {
                new Club("Sheffield United", 12, 5, 14),
                new Club("Leeds United", 12, 8, 16),
                new Club("Sunderland", 9, 3, 11),
                new Club("Burnley", 12, 8, 19),
                new Club("Bristol City", 9, 3, 13),
                new Club("Norwich City", 15, 7, 18),
                new Club("Coventry City", 12, 8, 16),
                new Club("Derby County", 6, -4, 8),
                new Club("Hull City", 9, 1, 10),
                new Club("Watford", 15, 4, 17)
            };

            Activity1(clubs);
            Activity2(clubs);
            Activity3(clubs);
        }

        // Display a list of clubs
        static void DisplayClubs(Club[] clubs)
        {
            Console.WriteLine("{0,-20} {1,7} {2,12} {3,12}","Club", "Points", "Goal Diff.", "Goals");

            foreach (Club club in clubs)
                  Console.WriteLine("{0,-20} {1,7} {2,12} {3,12}", club.Name, club.Points, club.GoalDifference, club.GoalsScored);
        }

        // =====================================================
        // ACTIVITY 1: MERGE SORT BY POINTS ONLY
        // =====================================================

        static void Activity1(Club[] original)
        {
            Console.WriteLine("\nACTIVITY 1: SORT BY POINTS");

            // Create a copy so the original remains unchanged.
            Club[] clubs = (Club[])original.Clone();

            MergeSortByPoints(clubs, 0, clubs.Length - 1);

            DisplayClubs(clubs);

            Console.WriteLine("\nFirst place: " + clubs[0].Name);
            Console.WriteLine("Lowest points: " + clubs[clubs.Length - 1].Name);

            int derbyPosition = FindClubPosition(clubs, "Derby County");

            Console.WriteLine("Derby County position: " + derbyPosition);

            Console.WriteLine("Second place: " + clubs[1].Name);

            Console.WriteLine("Third place: " + clubs[2].Name);
        }

        static void MergeSortByPoints(Club[] clubs, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                MergeSortByPoints(clubs, left, middle);
                MergeSortByPoints(clubs, middle + 1, right);
                MergeByPoints(clubs, left, middle, right);
            }
        }

        static void MergeByPoints(Club[] clubs, int left, int middle, int right)
        {
            Club[] temp = new Club[right - left + 1];

            int i = left;
            int j = middle + 1;
            int k = 0;

            while (i <= middle && j <= right)
            {
                // Descending points.
                // Select left first when points are equal.
                if (clubs[i].Points > clubs[j].Points ||
                    !(clubs[i].Points < clubs[j].Points))
                {
                    temp[k] = clubs[i];
                    i++;
                }
                else
                {
                    temp[k] = clubs[j];
                    j++;
                }

                k++;
            }

            while (i <= middle)
            {
                temp[k] = clubs[i];
                i++;
                k++;
            }

            while (j <= right)
            {
                temp[k] = clubs[j];
                j++;
                k++;
            }

            for (int p = 0; p < temp.Length; p++)            
                clubs[left + p] = temp[p];            
        }

        static int FindClubPosition(Club[] clubs, string name)
        {
            for (int i = 0; i < clubs.Length; i++)
            {
                if (clubs[i].Name == name)
                    return i + 1; // Positions start at 1.
            }

            return -1;
        }

        // =====================================================
        // ACTIVITY 2: BINARY SEARCH BY CLUB NAME
        // =====================================================

        static void Activity2(Club[] original)
        {
            Console.WriteLine("\nACTIVITY 2: BINARY SEARCH");

            // Make a separate copy and sort it alphabetically.
            Club[] clubs = (Club[])original.Clone();

            MergeSortByName(clubs, 0, clubs.Length - 1);

            Console.WriteLine("\nAlphabetical order:");
            foreach (Club club in clubs)           
                Console.WriteLine(club.Name);
            
            SearchClub(clubs, "Leeds United");
            SearchClub(clubs, "Manchester City");
        }

        static void MergeSortByName(Club[] clubs, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                MergeSortByName(clubs, left, middle);
                MergeSortByName(clubs, middle + 1, right);

                MergeByName(clubs, left, middle, right);
            }
        }

        static void MergeByName(Club[] clubs, int left, int middle, int right)
        {
            Club[] temp = new Club[right - left + 1];

            int i = left;
            int j = middle + 1;
            int k = 0;

            while (i <= middle && j <= right)
            {
                int result = string.Compare(
                    clubs[i].Name,
                    clubs[j].Name,
                    StringComparison.OrdinalIgnoreCase);

                // Alphabetical ascending order.
                if (result < 1)
                {
                    temp[k] = clubs[i];
                    i++;
                }
                else
                {
                    temp[k] = clubs[j];
                    j++;
                }

                k++;
            }

            while (i <= middle)
            {
                temp[k] = clubs[i];
                i++;
                k++;
            }

            while (j <= right)
            {
                temp[k] = clubs[j];
                j++;
                k++;
            }

            for (int p = 0; p < temp.Length; p++)
            {
                clubs[left + p] = temp[p];
            }
        }

        static int BinarySearch(Club[] clubs, string target)
        {
            int left = 0;
            int right = clubs.Length - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                int result = string.Compare(
                    clubs[middle].Name,
                    target,
                    StringComparison.OrdinalIgnoreCase);

                if (result == 0)
                    return middle;

                if (result < 0)
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            return -1;
        }

        static void SearchClub(Club[] clubs, string target)
        {
            int position = BinarySearch(clubs, target);

            if (position >= 0)
                Console.WriteLine(target + " found at array index " + position);            
            else            
                Console.WriteLine(target + " was not found.");            
        }

        // =====================================================
        // ACTIVITY 3: MULTI-CRITERIA MERGE SORT
        // =====================================================

        static void Activity3(Club[] original)
        {
            Console.WriteLine("\nACTIVITY 3: RANK USING THREE CRITERIA");

            Club[] clubs = (Club[])original.Clone();

            MergeSortByRanking(clubs, 0, clubs.Length - 1);

            DisplayClubs(clubs);

            Console.WriteLine("\nFirst place: " + clubs[0].Name);
            Console.WriteLine("Last place: " + clubs[clubs.Length - 1].Name);
            Console.WriteLine("Third place: " + clubs[2].Name);

            int watfordPosition = FindClubPosition(clubs, "Watford");

            if (watfordPosition > 0 && watfordPosition < clubs.Length)
                   Console.WriteLine("Club immediately below Watford: " + clubs[watfordPosition].Name);            
        }

        static void MergeSortByRanking(Club[] clubs, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                MergeSortByRanking(clubs, left, middle);
                MergeSortByRanking(clubs, middle + 1, right);
                MergeByRanking(clubs, left, middle, right);
            }
        }

        // Returns true when the left club should appear first.
        static bool ShouldComeFirst(Club left, Club right)
        {
            // Criterion 1: points descending.
            if (left.Points > right.Points)
                return true;

            if (left.Points < right.Points)
                return false;

            // Criterion 2: goal difference descending.
            if (left.GoalDifference > right.GoalDifference)
                return true;

            if (left.GoalDifference < right.GoalDifference)
                return false;

            // Criterion 3: goals scored descending.
            if (left.GoalsScored > right.GoalsScored)
                return true;

            if (left.GoalsScored < right.GoalsScored)
                return false;

            // All criteria are equal: preserve stability.
            return true;
        }

        static void MergeByRanking(Club[] clubs, int left, int middle, int right)
        {
            Club[] temp = new Club[right - left + 1];

            int i = left;
            int j = middle + 1;
            int k = 0;

            while (i <= middle && j <= right)
            {
                if (ShouldComeFirst(clubs[i], clubs[j]))
                {
                    temp[k] = clubs[i];
                    i++;
                }
                else
                {
                    temp[k] = clubs[j];
                    j++;
                }

                k++;
            }

            while (i <= middle)
            {
                temp[k] = clubs[i];
                i++;
                k++;
            }

            while (j <= right)
            {
                temp[k] = clubs[j];
                j++;
                k++;
            }

            for (int p = 0; p < temp.Length; p++)
            {
                clubs[left + p] = temp[p];
            }
        }
    }
}
