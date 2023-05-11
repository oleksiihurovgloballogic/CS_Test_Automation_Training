/// https://www.codewars.com/kata/search/csharp?q=&tags=Object-oriented%20Programming&beta=false&order_by=rank_id%20asc

using NUnit.Framework;

using Homework_08._01_Object_Oriented_Piracy;
using Homework_08._02_Color_Ghost;
using Homework_08._03_Thinkful_Object_Drills_Quarks;
using Homework_08._04_Vectors_1;
using Homework_08._05_Fun_with_ES6_Classes_2_Animals_and_Inheritance;
using Homework_08._06_Building_blocks;
using Homework_08._07_Building_Spheres;
using Homework_08._08_RPS_Knockout_Tournament_Winner;
using Homework_08._09_Generic_type_Loop;
using Homework_08._10_PaginationHelper;
//using Homework_08._11_Constructing_a_car_1___Engine_and_Fuel_Tank;
//using Homework_08._12_Constructing_a_car_2___Driving;
//using Homework_08._13_Constructing_a_car_3___OnBoard_Computer;

namespace Homework_08
{
    internal class Hometask_08
    {
        public static void Main()
        {
            /// --- _01_Object_Oriented_Piracy ---
            //Ship titanic = new Ship(15, 10);
            //Assert.AreEqual(false, titanic.IsWorthIt());


            /// --- _02_Color_Ghost ---
            //for (int i = 0; i < 10; i++)
            //{
            //    var ghost = new Ghost();
            //    Console.WriteLine(ghost.color);
            //}


            /// --- _03_Thinkful_Object_Drills_Quarks ---
            //Quark q1 = new Quark("red", "up");
            //Quark q2 = new Quark("blue", "strange");
            //Assert.AreEqual("red", q1.Color);
            //Assert.AreEqual("strange", q2.Flavor);
            //Assert.AreEqual(1 / 3d, q2.BaryonNumber);
            //q1.Interact(q2);
            //Assert.AreEqual("blue", q1.Color);


            /// --- _04_Vectors_1 ---


            /// --- _05_Fun_with_ES6_Classes_2_Animals_and_Inheritance ---
            //Shark billy = new Shark("Billy", 3, "Alive and well");
            //Assert.AreEqual("Billy", billy.Name);
            //Assert.AreEqual(3, billy.Age);
            //Assert.AreEqual(0, billy.Legs);
            //Assert.AreEqual("shark", billy.Species);
            //Assert.AreEqual("Alive and well", billy.Status);
            //Assert.AreEqual("Hello, my name is Billy and I am 3 years old.", billy.Introduce());
            //Shark charles = new Shark("Charles", 8, "Looking for a mate");
            //Assert.AreEqual("Charles", charles.Name);
            //Assert.AreEqual(8, charles.Age);
            //Assert.AreEqual(0, charles.Legs);
            //Assert.AreEqual("shark", charles.Species);
            //Assert.AreEqual("Looking for a mate", charles.Status);
            //Assert.AreEqual("Hello, my name is Charles and I am 8 years old.", charles.Introduce());

            //Cat cathy = new Cat("Cathy", 7, "Playing with a ball of yarn");
            //Assert.AreEqual("Cathy", cathy.Name);
            //Assert.AreEqual(7, cathy.Age);
            //Assert.AreEqual(4, cathy.Legs);
            //Assert.AreEqual("cat", cathy.Species);
            //Assert.AreEqual("Playing with a ball of yarn", cathy.Status);
            //Assert.AreEqual("Hello, my name is Cathy and I am 7 years old.  Meow meow!", cathy.Introduce());
            //Cat spitsy = new Cat("Spitsy", 6, "sleeping");
            //Assert.AreEqual("Spitsy", spitsy.Name);
            //Assert.AreEqual(6, spitsy.Age);
            //Assert.AreEqual(4, spitsy.Legs);
            //Assert.AreEqual("cat", spitsy.Species);
            //Assert.AreEqual("sleeping", spitsy.Status);
            //Assert.AreEqual("Hello, my name is Spitsy and I am 6 years old.  Meow meow!", spitsy.Introduce());

            //Dog doug = new Dog("Doug", 12, "Serving his master", "Eliza");
            //Assert.AreEqual("Doug", doug.Name);
            //Assert.AreEqual(12, doug.Age);
            //Assert.AreEqual(4, doug.Legs);
            //Assert.AreEqual("dog", doug.Species);
            //Assert.AreEqual("Serving his master", doug.Status);
            //Assert.AreEqual("Hello Eliza", doug.GreetMaster());


            /// --- _06_Building_blocks ---
            //Block b = new Block(new int[] { 2, 2, 2 });
            //Assert.AreEqual(2, b.GetWidth());
            //Assert.AreEqual(2, b.GetLength());
            //Assert.AreEqual(2, b.GetHeight());
            //Assert.AreEqual(8, b.GetVolume());
            //Assert.AreEqual(24, b.GetSurfaceArea());


            /// --- _07_Building_Spheres ---
            //Sphere ball = new Sphere(2, 50);
            //Assert.AreEqual(2, ball.GetRadius(), "Check radius");
            //Assert.AreEqual(50, ball.GetMass(), "Check mass");
            //Assert.AreEqual(33.51032, ball.GetVolume(), "Check volume");
            //Assert.AreEqual(50.26548, ball.GetSurfaceArea(), "Check area");
            //Assert.AreEqual(1.49208, ball.GetDensity(), "Check density");


            /// --- _08_RPS_Knockout_Tournament_Winner ---
            //var playground = new RockPaperScissorsPlayground();
            //var player = new Player();
            //var result = playground.PlayTournament(player);

            //foreach (var l in playground.GetMatchResults())
            //{
            //    Console.WriteLine(l);
            //}

            //if (!result)
            //{
            //    Assert.Fail($"You are eliminated from the tournament by {playground.GetLastOpponent()}!");
            //}


            /// --- 09_Generic_type_Loop ---
            //Loop<string> myLoop = new Loop<string>() { "a", "b", "c", "d", "e", "f" };
            //StringAssert.AreEqualIgnoringCase("a", myLoop.ShowFirst());
            //myLoop.Rigth();
            //StringAssert.AreEqualIgnoringCase("f", myLoop.ShowFirst());
            //myLoop.Rigth();
            //StringAssert.AreEqualIgnoringCase("e", myLoop.ShowFirst());
            //myLoop.Left();
            //StringAssert.AreEqualIgnoringCase("f", myLoop.ShowFirst());
            //myLoop.Left();
            //StringAssert.AreEqualIgnoringCase("a", myLoop.PopOut());
            //StringAssert.AreEqualIgnoringCase("b", myLoop.PopOut());
            //StringAssert.AreEqualIgnoringCase("c", myLoop.PopOut());


            /// --- 10_PaginationHelper ---
            //IList<int> collection = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            //PagnationHelper<int> helper = new PagnationHelper<int>(collection, 10);

            //Assert.AreEqual(-1, helper.PageItemCount(-1));
            //Assert.AreEqual(10, helper.PageItemCount(1));
            //Assert.AreEqual(-1, helper.PageItemCount(3));
            //Assert.AreEqual(-1, helper.PageIndex(-1));
            //Assert.AreEqual( 1, helper.PageIndex(12));
            //Assert.AreEqual(-1, helper.PageIndex(24));
            //Assert.AreEqual(24, helper.ItemCount);
            //Assert.AreEqual(3, helper.PageCount);


            /// --- _11_Constructing_a_car_1___Engine_and_Fuel_Tank ---
            //var car = new Car();
            //Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
            //car.EngineStart();
            //Assert.IsTrue(car.EngineIsRunning, "Engine should be running.");
            //car.EngineStop();
            //Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");

            //car = new Car(1);
            //car.EngineStart();
            //Enumerable.Range(0, 3000).ToList().ForEach(s => car.RunningIdle());
            //Assert.AreEqual(0.10, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");

            //car = new Car(60);
            //Assert.IsTrue(car.fuelTankDisplay.IsComplete, "Fuel tank must be complete!");

            //car = new Car(4);
            //Assert.IsTrue(car.fuelTankDisplay.IsOnReserve, "Fuel tank must be on reserve!");

            //car = new Car(5);
            //car.Refuel(40);
            //Assert.AreEqual(45, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");


            /// --- _12_Constructing_a_car_2___Driving ---
            //var car = new Car();
            //car.EngineStart();
            //Assert.AreEqual(0, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

            //car = new Car();
            //car.EngineStart();
            //Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));
            //Assert.AreEqual(100, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            //car.FreeWheel();
            //car.FreeWheel();
            //car.FreeWheel();
            //Assert.AreEqual(97, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

            //car = new Car();
            //car.EngineStart();
            //Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));
            //car.Accelerate(160);
            //Assert.AreEqual(110, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            //car.Accelerate(160);
            //Assert.AreEqual(120, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            //car.Accelerate(160);
            //Assert.AreEqual(130, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            //car.Accelerate(160);
            //Assert.AreEqual(140, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            //car.Accelerate(145);
            //Assert.AreEqual(145, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

            //car = new Car();
            //car.EngineStart();
            //Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));
            //car.BrakeBy(20);
            //Assert.AreEqual(90, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            //car.BrakeBy(10);
            //Assert.AreEqual(80, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

            //car = new Car(1, 20);
            //car.EngineStart();
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //Assert.AreEqual(0.98, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");

            //// TestFreeWheelEndingAtZero
            //car = new Car();
            //car.EngineStart();
            //car.Accelerate(10);
            //Assert.AreEqual(10, car.drivingInformationDisplay.ActualSpeed);
            //car.FreeWheel();
            //Assert.AreEqual(9, car.drivingInformationDisplay.ActualSpeed);
            //car.FreeWheel();
            //car.FreeWheel();
            //car.FreeWheel();
            //car.FreeWheel();
            //car.FreeWheel();
            //car.FreeWheel();
            //car.FreeWheel();
            //car.FreeWheel();
            //Assert.AreEqual(1, car.drivingInformationDisplay.ActualSpeed);
            //car.FreeWheel();
            //Assert.AreEqual(0, car.drivingInformationDisplay.ActualSpeed);


            /// --- _13_Constructing_a_car_3___OnBoard_Computer ---
            //// TestRealAndDrivingTimeBeforeStarting
            //var car = new Car();
            //Assert.AreEqual(0, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            //Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            //Assert.AreEqual(0, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            //Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");

            //// TestRealAndDrivingTimeAfterDriving
            //car = new Car();
            //car.EngineStart();
            //car.RunningIdle();
            //car.RunningIdle();
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.BrakeBy(10);
            //car.BrakeBy(10);
            //car.Accelerate(30);
            //Assert.AreEqual(11, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            //Assert.AreEqual(8, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            //Assert.AreEqual(11, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            //Assert.AreEqual(8, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");

            //// TestActualSpeedBeforeDriving
            //car = new Car();
            //car.EngineStart();
            //car.RunningIdle();
            //car.RunningIdle();
            //Assert.AreEqual(0, car.onBoardComputerDisplay.ActualSpeed, "Wrong actual speed.");

            //// TestAverageSpeed1
            //car = new Car();
            //car.EngineStart();
            //car.RunningIdle();
            //car.RunningIdle();
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.BrakeBy(10);
            //car.BrakeBy(10);
            //car.BrakeBy(10);
            //Assert.AreEqual(18, car.onBoardComputerDisplay.TripAverageSpeed, "Wrong Trip-Average-Speed.");
            //Assert.AreEqual(18, car.onBoardComputerDisplay.TotalAverageSpeed, "Wrong Total-Average-Speed.");

            //// TestAverageSpeedAfterTripReset
            //car = new Car();
            //car.EngineStart();
            //car.RunningIdle();
            //car.RunningIdle();
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.BrakeBy(10);
            //car.BrakeBy(10);
            //car.BrakeBy(10);
            //car.onBoardComputerDisplay.TripReset();
            //car.Accelerate(20);
            //car.Accelerate(20);
            //Assert.AreEqual(15, car.onBoardComputerDisplay.TripAverageSpeed, "Wrong Trip-Average-Speed.");
            //Assert.AreEqual(20, car.onBoardComputerDisplay.TotalAverageSpeed, "Wrong Total-Average-Speed.");

            //// TestActualConsumptionEngineStart
            //car = new Car();
            //car.EngineStart();
            //Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            //Assert.AreEqual(double.NaN, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");

            //// TestActualConsumptionRunningIdle
            //car = new Car();
            //car.EngineStart();
            //car.RunningIdle();
            //Assert.AreEqual(0.0003, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            //Assert.AreEqual(double.NaN, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");

            //// TestActualConsumptionAccelerateTo100
            //car = new Car(40, 20);
            //car.EngineStart();
            //car.Accelerate(100);
            //car.Accelerate(100);
            //car.Accelerate(100);
            //car.Accelerate(100);
            //car.Accelerate(100);
            //Assert.AreEqual(0.0014, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            //Assert.AreEqual(5, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");

            //// TestActualConsumptionFreeWheel
            //car = new Car(40, 20);
            //car.EngineStart();
            //car.Accelerate(100);
            //car.Accelerate(100);
            //car.Accelerate(100);
            //car.Accelerate(100);
            //car.Accelerate(100);
            //car.FreeWheel();
            //Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            //Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");

            //// TestAverageConsumptionsAfterEngineStart
            //car = new Car();
            //car.EngineStart();
            //Assert.AreEqual(0, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            //Assert.AreEqual(0, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            //Assert.AreEqual(0, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            //Assert.AreEqual(0, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");

            //// TestAverageConsumptionsAfterAccelerating
            //car = new Car();
            //car.EngineStart();
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //Assert.AreEqual(0.0015, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            //Assert.AreEqual(0.0015, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            //Assert.AreEqual(44, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            //Assert.AreEqual(44, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");

            //// TestAverageConsumptionsAfterBraking
            //car = new Car();
            //car.EngineStart();
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.Accelerate(30);
            //car.BrakeBy(10);
            //car.BrakeBy(10);
            //car.BrakeBy(10);
            //Assert.AreEqual(0.0009, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            //Assert.AreEqual(0.0009, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            //Assert.AreEqual(26.4, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            //Assert.AreEqual(26.4, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");

            //// TestDrivenDistancesAfterEngineStart
            //car = new Car();
            //car.EngineStart();
            //Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
            //Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");

            //// TestDrivenDistancesAfterAccelerating
            //car = new Car();
            //car.EngineStart();
            //Enumerable.Range(0, 30).ToList().ForEach(c => car.Accelerate(30));
            //Assert.AreEqual(0.24, car.onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
            //Assert.AreEqual(0.24, car.onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");

            //// TestEstimatedRangeAfterDrivingOptimumSpeedForMoreThan100Seconds
            //car = new Car();
            //car.EngineStart();
            //Enumerable.Range(0, 150).ToList().ForEach(c => car.Accelerate(100));
            //Assert.AreEqual(393, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
        }
    }
}
