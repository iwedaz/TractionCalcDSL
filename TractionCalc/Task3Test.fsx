#load "DSLDeclaration.fsx"

open TractionCalc.MeasurementUnit
open TractionCalc.Consts
open TractionCalc.DSLDeclaration

train "someTrain";;

stock "someStock1";;
carriage "someCarriage1" typeA OpenCarriage length 11.5<m> mass 10.1<t> withA axelNumber 4
                         onA RollerBearing withA brakingAxels 4 onA CastIronFromPlainMaterialBrakeShoe;;
carriage "someCarriage2" typeA FlatCarriage length 12.3<m> mass 11.6<t> withA axelNumber 8
                         onA RollerBearing withA brakingAxels 8 onA Composite8166BrakeShoe;;
carriage "someCarriage3" typeA TankCarriage length 10.0<m> mass 9.0<t> withA axelNumber 4
                         onA SliderBearing withA brakingAxels 3 onA Composite328303BrakeShoe;;
carriage "someCarriage4" typeA СoveredCarriage length 13.4<m> mass 12.3<t> withA axelNumber 6
                         onA RollerBearing withA brakingAxels 6 onA CastIronFromPlainMaterialBrakeShoe;;

locomotive "2ТЭ116" typeA DieselElectricLocomotive length 18.15<m> mass 138.0<t>
            withA ratedSpeed 24.2<km/hour> ratedTractiveEffort 506000.0<N>
            fromA sectionNumber 2  withA axelNumber 6 withA axelLoad 226000.0<N>;;

tractionCharacteristic "tch1"
tractionCharacteristicRecord forA speed 00.0<km/hour>  inA locomotiveEngineMode PP_Mode  withA ratedTractiveEffort 813000.0<N>
tractionCharacteristicRecord forA speed 05.0<km/hour>  inA locomotiveEngineMode PP_Mode  withA ratedTractiveEffort 737100.0<N>
tractionCharacteristicRecord forA speed 10.0<km/hour>  inA locomotiveEngineMode PP_Mode  withA ratedTractiveEffort 680200.0<N>
tractionCharacteristicRecord forA speed 15.0<km/hour>  inA locomotiveEngineMode PP_Mode  withA ratedTractiveEffort 638600.0<N>
tractionCharacteristicRecord forA speed 19.5<km/hour>  inA locomotiveEngineMode PP_Mode  withA ratedTractiveEffort 608000.0<N>
tractionCharacteristicRecord forA speed 24.2<km/hour>  inA locomotiveEngineMode PP_Mode  withA ratedTractiveEffort 506000.0<N>
tractionCharacteristicRecord forA speed 30.0<km/hour>  inA locomotiveEngineMode PP_Mode  withA ratedTractiveEffort 416700.0<N>
tractionCharacteristicRecord forA speed 32.0<km/hour>  inA locomotiveEngineMode PP_Mode  withA ratedTractiveEffort 392800.0<N>
tractionCharacteristicRecord forA speed 40.0<km/hour>  inA locomotiveEngineMode PP_Mode  withA ratedTractiveEffort 320000.0<N>
tractionCharacteristicRecord forA speed 43.5<km/hour>  inA locomotiveEngineMode PP_Mode  withA ratedTractiveEffort 295800.0<N>

tractionCharacteristicRecord forA speed 32.0<km/hour>  inA locomotiveEngineMode OP1_Mode withA ratedTractiveEffort 386000.0<N>
tractionCharacteristicRecord forA speed 40.0<km/hour>  inA locomotiveEngineMode OP1_Mode withA ratedTractiveEffort 315600.0<N>
tractionCharacteristicRecord forA speed 43.5<km/hour>  inA locomotiveEngineMode OP1_Mode withA ratedTractiveEffort 292000.0<N>
tractionCharacteristicRecord forA speed 46.0<km/hour>  inA locomotiveEngineMode OP1_Mode withA ratedTractiveEffort 277600.0<N>
tractionCharacteristicRecord forA speed 50.0<km/hour>  inA locomotiveEngineMode OP1_Mode withA ratedTractiveEffort 256800.0<N>
tractionCharacteristicRecord forA speed 58.5<km/hour>  inA locomotiveEngineMode OP1_Mode withA ratedTractiveEffort 220800.0<N>

tractionCharacteristicRecord forA speed 46.0<km/hour>  inA locomotiveEngineMode OP2_Mode withA ratedTractiveEffort 273000.0<N>
tractionCharacteristicRecord forA speed 50.0<km/hour>  inA locomotiveEngineMode OP2_Mode withA ratedTractiveEffort 252600.0<N>
tractionCharacteristicRecord forA speed 58.5<km/hour>  inA locomotiveEngineMode OP2_Mode withA ratedTractiveEffort 217600.0<N>
tractionCharacteristicRecord forA speed 70.0<km/hour>  inA locomotiveEngineMode OP2_Mode withA ratedTractiveEffort 183400.0<N>
tractionCharacteristicRecord forA speed 80.0<km/hour>  inA locomotiveEngineMode OP2_Mode withA ratedTractiveEffort 161000.0<N>
tractionCharacteristicRecord forA speed 90.0<km/hour>  inA locomotiveEngineMode OP2_Mode withA ratedTractiveEffort 143400.0<N>
tractionCharacteristicRecord forA speed 100.0<km/hour> inA locomotiveEngineMode OP2_Mode withA ratedTractiveEffort 129000.0<N>


section "someSection1" length 1500.0<m> withA gradient 0.01 builtAs sectionRail forA speed 50.0<km/hour>;;

let result = task3 "task3"