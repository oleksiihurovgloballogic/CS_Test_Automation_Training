/// https://www.codewars.com/kata/5882b052bdeafec15e0000e6

namespace Homework_08._03_Thinkful_Object_Drills_Quarks
{
    public class Quark
    {
        public string Color { get; set; }
        public string Flavor { get; set; }
        public double BaryonNumber = 1.0 / 3.0;

        public Quark(string color, string flavor)
        {
            this.Color = color;
            this.Flavor = flavor;
        }

        public void Interact(Quark quark)
        {
            string tmp = quark.Color;
            quark.Color = this.Color;
            this.Color = tmp;
        }
    }
}
