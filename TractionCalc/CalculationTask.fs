namespace TractionCalc

    open TractionCalc.Consts
    open TractionCalc.MeasurementUnit
    open TractionCalc.Train
    open TractionCalc.Track


    module CalculationTask =

        type CalculationTask = class
            val _name : string
            [<DefaultValue>] val mutable _train : Train
            [<DefaultValue>] val mutable _track : Track
            
            new (name) =
                {
                    _name = name
                }

//            new (name , train , track) =
//                {
//                    _name = name
//                    _train = train
//                    _track = track
//                }

        end
