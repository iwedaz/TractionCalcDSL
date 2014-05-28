#load "DSLDeclaration.fsx"

open TractionCalc.Consts
open TractionCalc.MeasurementUnit
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

locomotive "2ТЭ116" typeA DieselElectricLocomotive length 18.15<m> mass 138.0<t>
            withA ratedSpeed 24.2<km/hour> ratedTractiveEffort 506000.0<N>
            fromA sectionNumber 2  withA axelNumber 6 withA axelLoad 226000.0<N>;;

let result = task4 "task1" forA length 1534.4<m>