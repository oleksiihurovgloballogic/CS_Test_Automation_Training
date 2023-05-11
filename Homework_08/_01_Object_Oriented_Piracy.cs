/// https://www.codewars.com/kata/54fe05c4762e2e3047000add

namespace Homework_08._01_Object_Oriented_Piracy
{
    public class Ship
    {
        public int Draft;
        public int Crew;

        public Ship(int draft, int crew)
        {
            Draft = draft;
            Crew = crew;
        }

        public bool IsWorthIt()
        {
            return this.Draft - 1.5 * this.Crew > 20 ? true : false;
        }
    }
}
