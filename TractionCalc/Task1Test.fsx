#load "DSLDeclaration.fsx"

open TractionCalc.MeasurementUnit
open TractionCalc.Consts
open TractionCalc.DSLDeclaration

stock "someStock1";;
carriage "someCarriage1" typeA OpenCarriage length 25.0<m> mass 80.0<t> withA axelNumber 4
                         onA RollerBearing withA brakingAxels 4 onA CastIronFromPlainMaterialBrakeShoe;;


locomotive "2ТЭ116" typeA DieselElectricLocomotive length 18.15<m> mass 138.0<t>
            withA ratedSpeed 24.2<km/hour> ratedTractiveEffort 506000.0<N>
            fromA sectionNumber 2  withA axelNumber 6 withA axelLoad 226000.0<N>;;

sectionWithRadius "someSection1" length 1500.0<m> withA gradient 8.0 builtAs sectionRail forA speed 20.0<km/hour>
           included curve length 1000.0<m> withA radius 1500.0<m>;;

let result = task1 "task1";;