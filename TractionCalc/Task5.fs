namespace TractionCalc

    open TractionCalc.MeasurementUnit
    open TractionCalc.Consts
    open TractionCalc.Carriage
    open TractionCalc.Stock
    open TractionCalc.Locomotive
    open TractionCalc.Train
    open TractionCalc.TrackSection
    open TractionCalc.Track

    open System.Collections.Generic;


    module Task5 =

        /// <summary>Построение диаграммы удельных равнодествующих сил</summary>
        type Task5 = class
            val _name : string
            val _train : Train

            new (name , train) =
                {
                    _name = name
                    _train = train
                }


            end

