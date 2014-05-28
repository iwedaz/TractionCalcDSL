#load "DSLDeclaration.fsx"

open TractionCalc.MeasurementUnit
open TractionCalc.Consts
open TractionCalc.DSLDeclaration

locomotive "2ТЭ116" typeA DieselElectricLocomotive length 18.15<m> mass 138.0<t>
            withA ratedSpeed 24.2<km/hour> ratedTractiveEffort 506000.0<N>
            fromA sectionNumber 2  withA axelNumber 6 withA axelLoad 226000.0<N>;;

track "someTrack";;
section "someSection1" length 1500.0<m> withA gradient 0.01 builtAs sectionRail forA speed 60.0<km/hour>;;
section "someSection1" length 5100.0<m> withA gradient 0.05 builtAs longWeldedRail forA speed 55.0<km/hour>;;
section "someSection1" length 2800.0<m> withA gradient -0.03 builtAs sectionRail forA speed 48.5<km/hour>;;
section "someSection1" length 3200.0<m> withA gradient 0.08 builtAs sectionRail forA speed 59.7<km/hour>;;


let result = task2 "task1"