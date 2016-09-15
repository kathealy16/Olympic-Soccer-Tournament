using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***************************
 * Kat Healy
 * September 13, 2016
 * Section 2, Group 6
 * Olympic Soccer Tournament
 ***************************/
namespace ConsoleApplication3
{
    class Program
    {
        public class Team
        {
            public string name;
            public int wins;
            public int losses;
        }

        //SoccerTeam inherits from Team
        public class SoccerTeam : Team
        {
            public int draw;
            public int goalsFor;
            public int goalsAgainst;
            public int differential;
            public int points;

            public SoccerTeam(string teamName, int teamPoints)
            {
                this.name = teamName;
                this.points = teamPoints;
            }
        }

        public class Game
        {
            string gameFunFact;
            int homeScore;
            int visitorScore;
            public Game(string somethingAboutTheGame)
            {
                this.gameFunFact = somethingAboutTheGame;
            }
        }

        static void Main(string[] args)
        {
            //try-catch statement in case the user puts something ridiculous
            //inside a while loop so that the program will keep trying until they don't put something ridiculous
            while (true)
            {
                try
                {
                    Console.Write("How many teams? ");
                    int numOfTeams = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n");
                    //Giant if statement because if there are no teams, it'd be dumb to print an empty list
                    if (numOfTeams <= 0)
                    {
                        Console.Write("K, cool. Have a fabulous day.");
                    }
                    else
                    {
                        //create the list to store team info in
                        List<SoccerTeam> unsortedTeams = new List<SoccerTeam>();

                        //while loop to take in user input for however many teams they choose
                        int i = 1;
                        while (i <= numOfTeams)
                        {
                            //try/catch in case the user inputs non-integers for a team's points
                            try
                            {
                                Console.Write("Enter Team " + i + "'s name: ");
                                string userInput = Console.ReadLine();
                                while (string.IsNullOrEmpty(userInput))
                                {
                                    Console.WriteLine("That was probably not what you meant, eh?");
                                    Console.Write("Enter Team " + i + "'s name: ");
                                    userInput = Console.ReadLine();
                                }
                                string teamName = UppercaseFirst(userInput);
                                Console.Write("Enter " + teamName + "'s points: ");
                                int teamPoints = Convert.ToInt32(Console.ReadLine());
                                SoccerTeam myTeam = new SoccerTeam(teamName, teamPoints);
                                unsortedTeams.Add(myTeam);
                                Console.WriteLine("\n");
                                i++;
                            }
                            catch
                            {
                                Console.WriteLine("That's not a number, dummy. Try again.");
                            }
                        }

                        //Sort the unsortedTeams list that took in the user's input and call it sortedTeams
                        List<SoccerTeam> sortedTeams = unsortedTeams.OrderByDescending(team => team.points).ToList();

                        Console.WriteLine("Here is the sorted list: ");
                        Console.WriteLine("\n");
                        //For the Position, Name, and Points headers
                        string displayHead;
                        displayHead = "Position".PadRight(25) + "Name".PadRight(25) + "Points";
                        Console.WriteLine(displayHead);
                        //For the underlines under the headers
                        string displayUnderline;
                        displayUnderline = "---------".PadRight(25) + "-----".PadRight(25) + "-------";
                        Console.WriteLine(displayUnderline);

                        //foreach loop will go through every team that I have stored and print out their results
                        int position = 1;
                        foreach (SoccerTeam myTeam in sortedTeams)
                        {
                            string printName = Convert.ToString(position).PadRight(25) + myTeam.name.PadRight(25) + myTeam.points;
                            Console.WriteLine(printName);
                            position++;
                        }
                    } //This is the end of the giant if-else statement
                    break;
                }
                catch
                {
                    Console.WriteLine("Put an actual number, please. K, thanks.");
                }
            }
            //To stop the console from closing so that we can look at the list...
            Console.ReadLine();
        }

        //Method to make first letters uppercase
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

    }
}