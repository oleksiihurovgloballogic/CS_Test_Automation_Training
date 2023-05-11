/// https://www.codewars.com/kata/58691792a44cfcf14700027c

namespace Homework_08._08_RPS_Knockout_Tournament_Winner
{
    public interface IRockPaperScissorsPlayer
    {
        // Your name as displayed in match results.
        string Name { get; }

        // Used by playground to notify you that a new match will start.
        void SetNewMatch(string opponentName);

        // Used by playground to get your game shape (values: "R", "P" or "S").
        string GetShape();

        // Used by playground to inform you about the shape your opponent played in the game. 
        void SetOpponentShape(string shape);
    }

    public class Player : IRockPaperScissorsPlayer
    {
        private Random random;

        private string Shape = "";
        private string NameOpponent = "";
        private string SequenceOpponent = "";
        private int Count = 0;

        public Player()
        {
            random = new Random((int)DateTime.UtcNow.Ticks);
        }
        public string Name
        {
            get
            {
                return "MyPlayer";
            }
        }

        public void SetNewMatch(string nameOpponent)
        {
            this.NameOpponent = nameOpponent;
            switch (nameOpponent)
            {
                case "Vitraj Bachchan": { SequenceOpponent = "SSSSSSSSSSSSSSSSSSSSSSSS"; break; }  // constant cyclic sequence
                case "Bin Jinhao"     : { SequenceOpponent = "SRSPRPSRSPRPSRSPRPSRSPRP"; break; }  // constant cyclic sequence
                case "Sven Johanson"  : { SequenceOpponent = "SSPRRSSSPRRSSSPRRSSSPRRS"; break; }  // constant cyclic sequence
                case "Jonathan Hughes": { SequenceOpponent = "RPSRPSRPSRPSRPSRPSRPSRPS"; break; }  // repeat my previous shape
                case "Max Janssen"    : { SequenceOpponent = "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR"; break; }  // no scissors
            }
            this.Count = 0;
        }

        private string WinnerToTheShape(char shape)
        {
            switch(shape)
            {
                case 'R': return "P";
                case 'P': return "S";
                case 'S': return "R";
                default: return "?";
            }
        }

        public string GetShape()
        {
            //switch (random.Next(1, 4))
            //{
            //    case 1: { Shape = "P"; break; }
            //    case 2: { Shape = "R"; break; }
            //    default: { Shape = "S"; break; }
            //}
            //return Shape;

            Shape = WinnerToTheShape(SequenceOpponent[Count++]);
            return Shape;
        }

        public void SetOpponentShape(string shape)
        {
            Console.WriteLine($"{Count, 2}   MyPlayer : {NameOpponent}  -  {Shape} : {shape}");
        }
    }

}
