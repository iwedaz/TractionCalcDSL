#load "Consts.fs"
#load "MeasurementUnit.fs"
#load "Carriage.fs"
#load "Stock.fs"
#load "Locomotive.fs"
#load "Train.fs"
#load "TrackSection.fs"
#load "Track.fs"
#load "Task1.fs"
#load "Task2.fs"
#load "Task3.fs"
#load "Task4.fs"
#load "Task5.fs"
#load "CalculationTask.fs"
#load "DSLDeclaration.fs"

open TractionCalc.Consts
open TractionCalc.MeasurementUnit
open TractionCalc.Carriage
open TractionCalc.Stock
open TractionCalc.Locomotive
open TractionCalc.Train
open TractionCalc.TrackSection
open TractionCalc.Track
open TractionCalc.Task1
open TractionCalc.Task2
open TractionCalc.Task3
open TractionCalc.Task4
open TractionCalc.Task5
open TractionCalc.CalculationTask
open TractionCalc.DSLDeclaration

train "someTrain";;

stock "someStock1";;
carriage "someCarriage1" typeA OpenCarriage length 11.5<m> mass 10.1<t> withA axelNumber 4 
                         onA RollerBearing withA brakingAxels 4 onA CastIronBrakeShoe;;
carriage "someCarriage2" typeA FlatCarriage length 12.3<m> mass 11.6<t> withA axelNumber 8 
                         onA RollerBearing withA brakingAxels 8 onA CompositeBrakeShoe;;
carriage "someCarriage3" typeA TankCarriage length 10.0<m> mass 9.0<t> withA axelNumber 4
                         onA SliderBearing withA brakingAxels 3 onA CompositeBrakeShoe;;
carriage "someCarriage4" typeA СoveredCarriage length 13.4<m> mass 12.3<t> withA axelNumber 6
                         onA RollerBearing withA brakingAxels 6 onA CastIronBrakeShoe;;
        
locomotive "2ТЭ116" typeA DieselElectricPower length 18.15<m> mass 138.0<t>
            withA ratedSpeed (KmPerHourToMetrePerSec 24.2<km/hour>) ratedTractiveEffort 248.0<N> 
            fromA sectionNumber 2  withA axelNumber 6 withA axelLoad 226000.0<N>;;
        
track "someTrack";;
section "someSection1" length 1500.0<m> withA gradient 0.01 builtAs sectionRail forA speed 20.0<m/sec>;;
section "someSection1" length 5100.0<m> withA gradient 0.05 builtAs longWeldedRail forA speed 25.0<m/sec>;;
section "someSection1" length 2800.0<m> withA gradient -0.03 builtAs sectionRail forA speed 11.2<m/sec>;;
section "someSection1" length 3200.0<m> withA gradient 0.08 builtAs sectionRail forA speed 15.7<m/sec>;;

let task =
    calculationTask "newTask";;

runTask task;;