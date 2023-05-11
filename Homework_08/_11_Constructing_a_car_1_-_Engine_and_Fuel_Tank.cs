/// https://www.codewars.com/kata/578b4f9b7c77f535fc00002f

using System;

namespace Homework_08._11_Constructing_a_car_1___Engine_and_Fuel_Tank
{
    // --- Interfaces ----------------------------------------------------------
    public interface ICar
    {
        bool EngineIsRunning { get; }
        void EngineStart();
        void EngineStop();
        void Refuel(double liters);
        void RunningIdle();
    }

    public interface IEngine
    {
        bool IsRunning { get; }
        void Consume(double liters);
        void Start();
        void Stop();
    }

    public interface IFuelTank
    {
        double FillLevel { get; }
        bool IsOnReserve { get; }
        bool IsComplete { get; }
        bool IsEmpty { get; }
        void Consume(double liters);
        void Refuel(double liters);
    }

    public interface IFuelTankDisplay
    {
        double FillLevel { get; }
        bool IsOnReserve { get; }
        bool IsComplete { get; }
    }

    // --- Implementation ------------------------------------------------------

    public class Car : ICar
    {
        //private IEngine engine;
        //private IFuelTank fuelTank;
        //public IFuelTankDisplay fuelTankDisplay;
        private Engine engine;
        private FuelTank fuelTank;
        public FuelTankDisplay fuelTankDisplay;

        private const double _DefaultIdleFuelConsumption = 0.0003;  // litters


        public Car()
        {
            engine = new Engine();
            fuelTank = new FuelTank();
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
        }

        public Car(double fuelLevel)
        {
            engine = new Engine();
            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
        }

        public bool EngineIsRunning { get { return engine.IsRunning; } }

        public void EngineStart()
        {
            if (!fuelTank.IsEmpty) engine.Start();
        }
        public void EngineStop()
        {
            engine.Stop();
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()   
        {
            if (!engine.IsRunning) return;

            fuelTank.Consume(_DefaultIdleFuelConsumption);
            engine.Consume(_DefaultIdleFuelConsumption);
            
            if (fuelTank.IsEmpty) engine.Stop();
        }
    }

    public class Engine : IEngine
    {
        private bool _EngineIsRunning;

        public Engine()
        {
            _EngineIsRunning = false;
        }

        public bool IsRunning { get { return _EngineIsRunning; } }

        public void Consume(double liters)
        {

        }

        public void Start()
        {
            _EngineIsRunning = true;
        }

        public void Stop()
        {
            _EngineIsRunning = false;
        }

    }

    public class FuelTank : IFuelTank
    {
        private const double _DefaultStartFuelLevel = 20.0;  // litters
        private double _FuelLevel;                           // litters
        private const double _MaxFuelLevel = 60.0;           // litters

        public double FillLevel { get { return _FuelLevel; } }
        public bool IsOnReserve { get { return _FuelLevel < 5.0; } }
        public bool IsComplete { get { return _FuelLevel == _MaxFuelLevel; } }
        public bool IsEmpty { get { return _FuelLevel == 0.0; } }

        public FuelTank()
        {
            _FuelLevel = _DefaultStartFuelLevel;
        }

        public FuelTank(double liters)
        {
            //if (liters < 0.0)
            //    throw new ArgumentException(
            //        $"ERROR: it is impossible to initialize by negative value of fuel {liters}."
            //    );
            //if (liters > _MaxFuelLevel)
            //    throw new OverflowException(
            //        $"ERROR: it is not possible to initialize fuel tank by {liters} litters of fuel, " +
            //        $"because it exceeds maximum level of the tank {_MaxFuelLevel} litters."
            //    );

            //_FuelLevel = liters;
            _FuelLevel = Math.Min(Math.Max(liters, 0.0), _MaxFuelLevel);
        }

        public void Consume(double liters)
        {
            //if (liters < 0.0)
            //    throw new ArgumentException(
            //        $"ERROR: it is impossible to consume negative value of fuel {liters}."
            //    );
            //if (liters < FillLevel)
            //    throw new OverflowException(
            //        $"ERROR: it is not possible to consume {liters} litters of fuel " +
            //        $"due to current level of fuel tank {FillLevel} litters."
            //    );

            //_FuelLevel -= liters;
            _FuelLevel = Math.Max(_FuelLevel - liters, 0.0);
        }

        public void Refuel(double liters)
        {
            //if (liters < 0.0)
            //    throw new ArgumentException(
            //        $"ERROR: it is impossible to refuel negative value of fuel {liters}."
            //    );
            //if (FillLevel + liters > _MaxFuelLevel)
            //    throw new OverflowException(
            //        $"ERROR: it is not possible to refuel {liters} litters of fuel for the current fuel tank level {_FuelLevel} of litters, " +
            //        $"because it exceeds maximum level of the tank {_MaxFuelLevel} litters."
            //    );

            _FuelLevel = Math.Min(_FuelLevel + liters, _MaxFuelLevel);
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        private readonly IFuelTank _fuelTank;

        public FuelTankDisplay(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }

        public double FillLevel { get { return Math.Round(_fuelTank.FillLevel, 2); } }
        public bool IsOnReserve { get { return _fuelTank.IsOnReserve; } }
        public bool IsComplete { get { return _fuelTank.IsComplete; } }
    }
}
