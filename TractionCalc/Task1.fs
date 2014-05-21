namespace TractionCalc

    open TractionCalc.Consts
    open TractionCalc.MeasurementUnit
    open TractionCalc.Carriage
    open TractionCalc.Stock
    open TractionCalc.Locomotive
    open TractionCalc.Train
    open TractionCalc.TrackSection
    open TractionCalc.Track

    open System.Collections.Generic;

    
    module Task1 =
        
        /// <summary>
        /// Расчёт массы состава при уловии, что проезд движется
        /// с равновесной скоростью на расчётном подъёме
        /// </summary>
        type Task1 = class
            val _name : string
            val _locomotive : Locomotive
            val mutable _carriages : Map<Carriage , float>
            val _trackSection : TrackSection

            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="name">Имя задачи</param>
            /// <param name="locomotive">Локомотив</param>
            /// <param name="trackSection">Участок пути</param>
            new (name , locomotive , trackSection) =
                {
                    _name = name
                    _locomotive = locomotive
                    _carriages = Map.empty<Carriage , float>
                    _trackSection = trackSection
                }

//            new (name , train : Train , trackSection) =
//                let m = Map.empty<Carriage , float>
//                for stock in train._stock do
//                    for car in stock._carriages do
//                        if m |> Map.containsKey car
//                        then 
//                            let v = m.Item car + 1.0
//                            m |> Map.remove car |> ignore
//                            m |> Map.add car v |> ignore
//                        else m |> Map.add car 1.0 |> ignore
//                m |> Map.map(fun key value -> value / (float)m.Count) |> ignore
//                {
//                    _name = name
//                    _locomotive = train._locomotives.Head
//                    _carriages = m
//                    _trackSection = trackSection
//                }

            static member StocksToMap (stocks : Stock list) : Map<Carriage , float>=
                let m = Map.empty<Carriage , float>
                for stock in stocks do
                    for car in stock._carriages do
                        if m |> Map.containsKey car
                        then 
                            let v = m.Item car + 1.0
                            m |> Map.remove car |> ignore
                            m |> Map.add car v |> ignore
                        else m |> Map.add car 1.0 |> ignore
                m |> Map.map(fun key value -> value / (float)m.Count)


            member this.AverageSpecificRunningResistance (speed : float<m/sec>) (railType : RailType) : float<N/t> =
                let mutable result = 0.0<N/t>
                let l = this._carriages |> Map.toList
                for car in l do
                   let first = fst car 
                   let second = snd car 
                   result <- result + first.SpecificRunningResistance speed railType * second
                result


            /// <summary>
            /// Расчётная максимальная масса состава на заданном участке
            /// при заданном локомотиве, Qmax, т
            /// </summary>
            member this.StockMass : float<t> =
                let loco = this._locomotive
                let track = this._trackSection
                (loco._ratedTractiveEffort - loco._mass * ((loco.SpecificRunningResistance loco._ratedSpeed track._railType true) + 10.0<N/t> * track.Gradient))
                /
                (this.AverageSpecificRunningResistance loco._ratedSpeed track._railType + 10.0<N/t> * track.Gradient)


            end
