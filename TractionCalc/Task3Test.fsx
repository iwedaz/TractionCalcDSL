#load "DSLDeclaration.fsx"

open TractionCalc.MeasurementUnit
open TractionCalc.Consts
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

tractionCharacteristic "tch1"
tractionCharacteristicRecord forA speed 00.0<km/hour> withA locomotiveThrottlePosition PP_Position andA ratedTractiveEffort 813000.0<N>
tractionCharacteristicRecord forA speed 05.0<km/hour> withA locomotiveThrottlePosition PP_Position andA ratedTractiveEffort 737100.0<N>
tractionCharacteristicRecord forA speed 10.0<km/hour> withA locomotiveThrottlePosition PP_Position andA ratedTractiveEffort 680200.0<N>
tractionCharacteristicRecord forA speed 15.0<km/hour> withA locomotiveThrottlePosition PP_Position andA ratedTractiveEffort 638600.0<N>
tractionCharacteristicRecord forA speed 19.5<km/hour> withA locomotiveThrottlePosition PP_Position andA ratedTractiveEffort 608000.0<N>
tractionCharacteristicRecord forA speed 24.2<km/hour> withA locomotiveThrottlePosition PP_Position andA ratedTractiveEffort 506000.0<N>
tractionCharacteristicRecord forA speed 30.0<km/hour> withA locomotiveThrottlePosition PP_Position andA ratedTractiveEffort 416700.0<N>
tractionCharacteristicRecord forA speed 32.0<km/hour> withA locomotiveThrottlePosition PP_Position andA ratedTractiveEffort 392800.0<N>
tractionCharacteristicRecord forA speed 40.0<km/hour> withA locomotiveThrottlePosition PP_Position andA ratedTractiveEffort 320000.0<N>
tractionCharacteristicRecord forA speed 43.5<km/hour> withA locomotiveThrottlePosition PP_Position andA ratedTractiveEffort 295800.0<N>

tractionCharacteristicRecord forA speed 32.0<km/hour> withA locomotiveThrottlePosition OP1_Position andA ratedTractiveEffort 386000.0<N>
tractionCharacteristicRecord forA speed 40.0<km/hour> withA locomotiveThrottlePosition OP1_Position andA ratedTractiveEffort 315600.0<N>
tractionCharacteristicRecord forA speed 43.5<km/hour> withA locomotiveThrottlePosition OP1_Position andA ratedTractiveEffort 292000.0<N>
tractionCharacteristicRecord forA speed 46.0<km/hour> withA locomotiveThrottlePosition OP1_Position andA ratedTractiveEffort 277600.0<N>
tractionCharacteristicRecord forA speed 50.0<km/hour> withA locomotiveThrottlePosition OP1_Position andA ratedTractiveEffort 256800.0<N>
tractionCharacteristicRecord forA speed 58.5<km/hour> withA locomotiveThrottlePosition OP1_Position andA ratedTractiveEffort 220800.0<N>

tractionCharacteristicRecord forA speed 46.0<km/hour>  withA locomotiveThrottlePosition OP2_Position andA ratedTractiveEffort 273000.0<N>
tractionCharacteristicRecord forA speed 50.0<km/hour>  withA locomotiveThrottlePosition OP2_Position andA ratedTractiveEffort 252600.0<N>
tractionCharacteristicRecord forA speed 58.5<km/hour>  withA locomotiveThrottlePosition OP2_Position andA ratedTractiveEffort 217600.0<N>
tractionCharacteristicRecord forA speed 70.0<km/hour>  withA locomotiveThrottlePosition OP2_Position andA ratedTractiveEffort 183400.0<N>
tractionCharacteristicRecord forA speed 80.0<km/hour>  withA locomotiveThrottlePosition OP2_Position andA ratedTractiveEffort 161000.0<N>
tractionCharacteristicRecord forA speed 90.0<km/hour>  withA locomotiveThrottlePosition OP2_Position andA ratedTractiveEffort 143400.0<N>
tractionCharacteristicRecord forA speed 100.0<km/hour> withA locomotiveThrottlePosition OP2_Position andA ratedTractiveEffort 129000.0<N>


section "someSection1" length 1500.0<m> withA gradient 0.01 builtAs sectionRail forA speed 50.0<km/hour>;;

let result = task3 "task3"