/// https://www.codewars.com/kata/57961d4e4be9121ec90001bd

using System;

namespace Homework_08._13_Constructing_a_car_3___OnBoard_Computer
{
    // --- Interfaces ----------------------------------------------------------
    public interface ICar
    {
        bool EngineIsRunning { get; }
        void BrakeBy(int speed);
        void Accelerate(int speed);
        void EngineStart();
        void EngineStop();
        void FreeWheel();
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

    public interface IDrivingProcessor
    {
        double ActualConsumption { get; }
        int ActualSpeed { get; }
        void EngineStart();
        void EngineStop();
        void IncreaseSpeedTo(int speed);
        void ReduceSpeed(int speed);
        double FuelConsumptionAccordingToConditions(bool isRealConsumption);
    }

    public interface IDrivingInformationDisplay
    {
        int ActualSpeed { get; }
    }

    public interface IOnBoardComputer
    {
        int TripRealTime { get; }
        int TripDrivingTime { get; }
        int TripDrivenDistance { get; }
        int TotalRealTime { get; }
        int TotalDrivingTime { get; }
        int TotalDrivenDistance { get; }
        double TripAverageSpeed { get; }
        double TotalAverageSpeed { get; }
        int ActualSpeed { get; }
        double ActualConsumptionByTime { get; }
        double ActualConsumptionByDistance { get; }
        double TripAverageConsumptionByTime { get; }
        double TotalAverageConsumptionByTime { get; }
        double TripAverageConsumptionByDistance { get; }
        double TotalAverageConsumptionByDistance { get; }
        int EstimatedRange { get; }
        void ElapseSecond();
        void TripReset();
        void TotalReset();
    }

    public interface IOnBoardComputerDisplay
    {
        int TripRealTime { get; }
        int TripDrivingTime { get; }
        double TripDrivenDistance { get; }
        int TotalRealTime { get; }
        int TotalDrivingTime { get; }
        double TotalDrivenDistance { get; }
        int ActualSpeed { get; }
        double TripAverageSpeed { get; }
        double TotalAverageSpeed { get; }
        double ActualConsumptionByTime { get; }
        double ActualConsumptionByDistance { get; }
        double TripAverageConsumptionByTime { get; }
        double TotalAverageConsumptionByTime { get; }
        double TripAverageConsumptionByDistance { get; }
        double TotalAverageConsumptionByDistance { get; }
        int EstimatedRange { get; }
        void TripReset();
        void TotalReset();
    }

    // --- Car Implementation --------------------------------------------------

    public class Car : ICar
    {
        private Engine engine;
        private FuelTank fuelTank;
        public FuelTankDisplay fuelTankDisplay;
        private DrivingProcessor drivingProcessor;
        public DrivingInformationDisplay drivingInformationDisplay;
        private OnBoardComputer onBoardComputer;
        public OnBoardComputerDisplay onBoardComputerDisplay;

        public Car()
        {
            fuelTank = new FuelTank();
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            drivingProcessor = new DrivingProcessor();
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            engine = new Engine(fuelTank);
        }

        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            drivingProcessor = new DrivingProcessor();
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            engine = new Engine(fuelTank);
        }

        public Car(double fuelLevel, int maxAcceleration)
        {
            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            drivingProcessor = new DrivingProcessor(maxAcceleration);
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            engine = new Engine(fuelTank);
        }

        public bool EngineIsRunning { get { return engine.IsRunning; } }

        public void BrakeBy(int speed)
        {
            if (!engine.IsRunning || fuelTank.IsEmpty) return;
            if (speed > drivingProcessor.ActualSpeed)
            {
                FreeWheel();
            }
            else
            {
                drivingProcessor.ReduceSpeed(speed);
                engine.Consume(drivingProcessor.FuelConsumptionAccordingToConditions());
                if (fuelTank.IsEmpty) engine.Stop();
            }
        }

        public void Accelerate(int speed)
        {
            if (!engine.IsRunning || fuelTank.IsEmpty) return;
            if (speed < drivingProcessor.ActualSpeed)
            {
                FreeWheel();
            }
            else
            {
                drivingProcessor.IncreaseSpeedTo(speed);
                engine.Consume(drivingProcessor.FuelConsumptionAccordingToConditions(true));
                if (fuelTank.IsEmpty) engine.Stop();
            }
        }

        public void EngineStart()
        {
            if (engine.IsRunning || fuelTank.IsEmpty) return;
            engine.Start();
        }

        public void EngineStop()
        {
            if (!engine.IsRunning) return;
            engine.Stop();
        }

        public void FreeWheel()
        {
            if (!engine.IsRunning || fuelTank.IsEmpty) return;
            if (drivingProcessor.ActualSpeed == 0)
            {
                RunningIdle();
            }
            else
            {
                drivingProcessor.ReduceSpeed(1);
                engine.Consume(drivingProcessor.FuelConsumptionAccordingToConditions());
                if (fuelTank.IsEmpty) engine.Stop();
            }
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            if (!engine.IsRunning) return;
            engine.Consume(drivingProcessor.FuelConsumptionAccordingToConditions(true));
            if (fuelTank.IsEmpty) engine.Stop();
        }
    }

    // --- Engine Implementation -----------------------------------------------

    public class Engine : IEngine
    {

        private bool _EngineIsRunning;

        private IFuelTank _fuelTank;

        public Engine(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
            _EngineIsRunning = false;
        }

        public bool IsRunning { get { return _EngineIsRunning; } }

        public void Consume(double liters)
        {
            _fuelTank.Consume(liters);
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

    // --- FuelTank Implementation ---------------------------------------------

    public class FuelTank : IFuelTank
    {
        private const double _DefaultStartFuelLevel = 20.0;  // litters
        private const double _MaxFuelLevel = 60.0;           // litters
        private double _FuelLevel;                           // litters

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
            _FuelLevel = Math.Min(Math.Max(liters, 0.0), _MaxFuelLevel);
        }

        public void Consume(double liters)
        {
            _FuelLevel = Math.Max(_FuelLevel - liters, 0.0);
        }

        public void Refuel(double liters)
        {
            _FuelLevel = Math.Min(_FuelLevel + liters, _MaxFuelLevel);
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        private readonly FuelTank _fuelTank;

        public FuelTankDisplay(FuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }

        public double FillLevel { get { return Math.Round(_fuelTank.FillLevel, 2); } }
        public bool IsOnReserve { get { return _fuelTank.IsOnReserve; } }
        public bool IsComplete { get { return _fuelTank.IsComplete; } }
    }

    // --- DrivingProcessor Implementation -------------------------------------

    public class DrivingProcessor : IDrivingProcessor
    {
        const double _DefaultIdleFuelConsumption = 0.0003;  // litters;

        private const int _MaxSpeed = 250;  // km/h
        private const int _DefaultAccelerationLimit = 10;   // km/h per second
        private const int _MaxAccelerationLowerLimit = 5;   // km/h per second
        private const int _MaxAccelerationUpperLimit = 20;  // km/h per second
        private const int _MaxDecelerationLimit = 10;       // km/h per second
        private int _Speed;  // km/h
        private int _MaxAcceleration;  // km/h per second

        public DrivingProcessor()
        {
            _Speed = 0;
            _MaxAcceleration = _DefaultAccelerationLimit;
        }

        public DrivingProcessor(int maxAcceleration)
        {
            _Speed = 0;
            _MaxAcceleration = Math.Min(Math.Max(maxAcceleration, _MaxAccelerationLowerLimit), _MaxAccelerationUpperLimit);
        }

        public int ActualSpeed { get { return _Speed; } }

        public void IncreaseSpeedTo(int speed)
        {
            if (speed < 0 || speed < _Speed) return;
            speed = Math.Min(_Speed + _MaxAcceleration, speed);
            _Speed = Math.Min(speed, _MaxSpeed);
        }

        public void ReduceSpeed(int speed)
        {
            if (speed < 0 || speed > _Speed) return;
            speed = Math.Min(_MaxDecelerationLimit, speed);
            _Speed = Math.Max(_Speed - speed, 0);
            //speed = Math.Max(_Speed - _MaxDecelerationLimit, speed);
            //_Speed = Math.Max(speed, 0);
        }

        public double FuelConsumptionAccordingToConditions(bool isRealConsumption = false)
        {
            if (!isRealConsumption) return 0.0;

            switch (_Speed)
            {
                case >= 1 and <= 60: return 0.0020;
                case >= 61 and <= 100: return 0.0014;
                case >= 101 and <= 140: return 0.0020;
                case >= 141 and <= 200: return 0.0025;
                case >= 201 and <= _MaxSpeed: return 0.0030;
                default: return _DefaultIdleFuelConsumption;
            }
        }
    }

    public class DrivingInformationDisplay : IDrivingInformationDisplay
    {
        private DrivingProcessor _drivingProcessor;

        public DrivingInformationDisplay(DrivingProcessor drivingProcessor)
        {
            _drivingProcessor = drivingProcessor;
        }

        public int ActualSpeed { get { return _drivingProcessor.ActualSpeed; } }
    }

    // --- OnBoardComputer Implementation --------------------------------------

    public class OnBoardComputer : IOnBoardComputer
    {

    }

    public class OnBoardComputerDisplay : IOnBoardComputerDisplay
    {

    }
}
