using System;
using System.Collections.Generic;
using Microsoft.FSharp.Collections;
using TractionCalc;
using Record = TractionCalc.Locomotive.LocomotiveThrottlePositionRecordType;

namespace DebugApp
{
	class Program
	{
		static Locomotive.Locomotive locomotive = new Locomotive.Locomotive("2ТЭ116" ,
			Consts.LocomotivePowerType.DieselElectricLocomotive ,
			18.15 , 138.0 , MeasurementUnit.KmPerHourToMetrePerSec(24.2) ,
			506000.0 , 2 , 6 , 226000.0 , 12 , Consts.BrakeShoeType.Composite8166BrakeShoe , 120000.0)
		{
			_tractionCharacteristic = ListModule.Empty<Record>()
		};


		static TrackSection.TrackSection section01 = new TrackSection.TrackSection("section1" ,
			1500.0 , 0.01 , Consts.RailType.SectionRail , 20);


		static Carriage.Carriage car01 = new Carriage.Carriage("car1" , Consts.CarriageType.OpenCarriage ,
			11.5 , 10.1 , 4 , Consts.BearingType.RollerBearing , 4 ,
			Consts.BrakeShoeType.CastIronFromPlainMaterialBrakeShoe , 100000.0);

		static Carriage.Carriage car02 = new Carriage.Carriage("car2" , Consts.CarriageType.FlatCarriage ,
			12.3 , 11.6 , 8 , Consts.BearingType.RollerBearing , 8 ,
			Consts.BrakeShoeType.Composite328303BrakeShoe , 100000.0);

		static Carriage.Carriage car03 = new Carriage.Carriage("car3" , Consts.CarriageType.TankCarriage ,
			10.0 , 9.0 , 4 , Consts.BearingType.SliderBearing , 3 ,
			Consts.BrakeShoeType.Composite8166BrakeShoe , 100000.0);

		static Carriage.Carriage car04 = new Carriage.Carriage("car4" , Consts.CarriageType.СoveredCarriage ,
			13.4 , 12.3 , 6 , Consts.BearingType.RollerBearing , 6 ,
			Consts.BrakeShoeType.CastIronWithHighPhosphorusBrakeShoe , 100000.0);


		static void Main(string [] args)
		{
			//Task1Test();
			Task2Test();
			//Task3Test();
			//Task4Test();
			//Task5Test();
		}



		static void Task1Test()
		{
			TrackSection.TrackSection section = new TrackSection.TrackSection("section1" ,
				1500.0 , 8 , Consts.RailType.SectionRail , 20 , 1000 , 1500);

			Carriage.Carriage car1 = new Carriage.Carriage("car1" , Consts.CarriageType.OpenCarriage ,
				25 , 80 , 4 , Consts.BearingType.RollerBearing , 4 ,
				Consts.BrakeShoeType.CastIronFromPlainMaterialBrakeShoe , 100000.0);

			var map = MapModule.Empty<Carriage.Carriage , double>();
			map = map.Add(car1 , 1);

			Task1.Task1 task = new Task1.Task1("task1" , locomotive , section);
			task._carriages = map;

			var result = task.StockMass;
		}

		static void Task2Test()
		{
			//Task2Test();
		}

		static void Task3Test()
		{
			TrackSection.TrackSection section = new TrackSection.TrackSection("section1" ,
				1500.0 , 8 , Consts.RailType.SectionRail , 20 , 1000 , 1500);

			var rec1 = new Record(0 , Consts.LocomotiveTractionEngineModeType.PP , 813000);

			List<Record> recList = new List<Locomotive.LocomotiveThrottlePositionRecordType>(23);

			recList.Add(new Record(0005 , Consts.LocomotiveTractionEngineModeType.PP , 737100));
			recList.Add(new Record(0010 , Consts.LocomotiveTractionEngineModeType.PP , 680200));
			recList.Add(new Record(0015 , Consts.LocomotiveTractionEngineModeType.PP , 638600));
			recList.Add(new Record(19.5 , Consts.LocomotiveTractionEngineModeType.PP , 608000));
			recList.Add(new Record(24.2 , Consts.LocomotiveTractionEngineModeType.PP , 506000));
			recList.Add(new Record(0030 , Consts.LocomotiveTractionEngineModeType.PP , 416700));
			recList.Add(new Record(0032 , Consts.LocomotiveTractionEngineModeType.PP , 392800));
			recList.Add(new Record(0040 , Consts.LocomotiveTractionEngineModeType.PP , 320000));
			recList.Add(new Record(43.5 , Consts.LocomotiveTractionEngineModeType.PP , 295800));

			recList.Add(new Record(0032 , Consts.LocomotiveTractionEngineModeType.OP1 , 386000));
			recList.Add(new Record(0040 , Consts.LocomotiveTractionEngineModeType.OP1 , 315600));
			recList.Add(new Record(43.5 , Consts.LocomotiveTractionEngineModeType.OP1 , 292000));
			recList.Add(new Record(0046 , Consts.LocomotiveTractionEngineModeType.OP1 , 277600));
			recList.Add(new Record(0050 , Consts.LocomotiveTractionEngineModeType.OP1 , 256800));
			recList.Add(new Record(58.5 , Consts.LocomotiveTractionEngineModeType.OP1 , 220800));

			recList.Add(new Record(0046 , Consts.LocomotiveTractionEngineModeType.OP2 , 273000));
			recList.Add(new Record(0050 , Consts.LocomotiveTractionEngineModeType.OP2 , 252600));
			recList.Add(new Record(58.5 , Consts.LocomotiveTractionEngineModeType.OP2 , 217600));
			recList.Add(new Record(0070 , Consts.LocomotiveTractionEngineModeType.OP2 , 183400));
			recList.Add(new Record(0080 , Consts.LocomotiveTractionEngineModeType.OP2 , 161000));
			recList.Add(new Record(0090 , Consts.LocomotiveTractionEngineModeType.OP2 , 143400));
			recList.Add(new Record(0100 , Consts.LocomotiveTractionEngineModeType.OP2 , 129000));


			var recordList = new FSharpList<Record>(rec1 , ListModule.Empty<Record>());
			foreach(var rec in recList)
				recordList = new FSharpList<Record>(rec , recordList);

			locomotive._tractionCharacteristic = recordList;


			var carList = new FSharpList<Carriage.Carriage>(car01 , ListModule.Empty<Carriage.Carriage>());
			carList = new FSharpList<Carriage.Carriage>(car02 , carList);
			carList = new FSharpList<Carriage.Carriage>(car03 , carList);
			carList = new FSharpList<Carriage.Carriage>(car04 , carList);

			var stock = new Stock.Stock("stock1")
			{
				_carriages = carList
			};

			Train.Train train1 = new Train.Train("train1")
			{
				_locomotives = new FSharpList<Locomotive.Locomotive>(locomotive , ListModule.Empty<Locomotive.Locomotive>()) ,
				_stocks = new FSharpList<Stock.Stock>(stock , ListModule.Empty<Stock.Stock>())
			};


			Task3.Task3 task = new Task3.Task3("task3" , train1 , section);
			var result = task.StockGetawayResistanceCheck;
		}

		static void Task4Test()
		{
			var carList = new FSharpList<Carriage.Carriage>(car01 , ListModule.Empty<Carriage.Carriage>());
			carList = new FSharpList<Carriage.Carriage>(car02 , carList);
			carList = new FSharpList<Carriage.Carriage>(car03 , carList);
			carList = new FSharpList<Carriage.Carriage>(car04 , carList);

			var stock = new Stock.Stock("stock1")
			{
				_carriages = carList
			};

			Train.Train train1 = new Train.Train("train1")
			{
				_locomotives = new FSharpList<Locomotive.Locomotive>(locomotive , ListModule.Empty<Locomotive.Locomotive>()) ,
				_stocks = new FSharpList<Stock.Stock>(stock , ListModule.Empty<Stock.Stock>())
			};


			Task4.Task4 task = new Task4.Task4("task4" , train1 , 100);
			var result = task.TrainLengthCheck;
		}

		static void Task5Test()
		{
		}
	}
}
