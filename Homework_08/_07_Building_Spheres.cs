/// https://www.codewars.com/kata/55c1d030da313ed05100005d

namespace Homework_08._07_Building_Spheres
{
    public class Sphere
    {
        private double Radius { get; set; }
        private double Mass { get; set; }
        private double Volume { get; set; }
        private double SurfaceArea { get; set; }
        private double Density { get; set; }

        public Sphere(int radius, int mass)
        {
            this.Radius = (double)radius;
            this.Mass = (double)mass;
            this.Volume = (4.0 / 3.0) * Math.PI * Math.Pow(this.Radius, 3);
            this.SurfaceArea = 4.0 * Math.PI * Math.Pow(this.Radius, 2);
            this.Density = this.Mass / this.Volume;
        }

        public double GetRadius()
        {
            return Math.Round(this.Radius, 5);
        }

        public double GetMass()
        {
            return Math.Round(this.Mass, 5);
        }

        public double GetVolume()
        {
            return Math.Round(this.Volume, 5);
        }

        public double GetSurfaceArea()
        {
            return Math.Round(this.SurfaceArea, 5);
        }

        public double GetDensity()
        {
            return Math.Round(this.Density, 5);
        }
    }
}
