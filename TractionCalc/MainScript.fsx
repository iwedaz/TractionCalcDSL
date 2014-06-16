#load "DSLDeclaration.fsx"

open TractionCalc.MeasurementUnit
open TractionCalc.Consts
open TractionCalc.DSLDeclaration

train "someTrain";;

stock "someStock1";;
#load "CarriagesPreset.fsx"

#load "LocomotivePreset.fsx"

track "someTrack";;
#load "TrackSectionsPreset.fsx"

printTrackSectionProfile "someSection2";;
printTrackSectionProfile "someSection3";;
printTrackProfile "someTrack";;

