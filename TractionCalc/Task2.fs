﻿namespace TractionCalc

    open TractionCalc.MeasurementUnit
    open TractionCalc.Consts
    open TractionCalc.Carriage
    open TractionCalc.Stock
    open TractionCalc.Locomotive
    open TractionCalc.Train
    open TractionCalc.TrackSection
    open TractionCalc.Track

    open System.Collections.Generic;


    module Task2 =

        /// <summary>
        /// Расчёт массы состава с учётом использования
        /// кинетической энергии поезда
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        type Task2 = class
            val _name : string
            val _locomotive : Locomotive
            val mutable _carriages : Map<Carriage , float>
            val _track : Track

            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="name">Имя задачи</param>
            /// <param name="locomotive">Локомотив</param>
            /// <param name="track"></param>
            new (name , locomotive , track) =
                {
                    _name = name
                    _locomotive = locomotive
                    _carriages = Map.empty<Carriage , float>
                    _track = track
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
//                m |> Map.map (fun key value -> value / (float)m.Count) |> ignore
//                {
//                    _name = name
//                    _locomotive = train._locomotives.Head
//                    _carriages = m
//                    _trackSection = trackSection
//                }

            static member StocksToMap (stockList : Stock list) : Map<Carriage , float>=
                let m = ref Map.empty<Carriage , float>
                for stock in stockList do
                    for car in stock._carriages do
                        (*if !m |> Map.containsKey car
                        then
                            let v = ((!m).Item car) + 1.0
                            m := !m |> Map.remove car
                            m := !m |> Map.add car v
                        else*) m := !m |> Map.add car 1.0
                m := !m |> Map.map(fun key value -> value / (float)(!m).Count) 
                !m


            member this.CarriagesAverageSRR (speed : float<km/hour>) (railType : RailType) : float<N/t> =
                let mutable result = 0.0<N/t>
                let carList = this._carriages |> Map.toList
                for car in carList do
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
                let track = (this._track._sections |> List.sortBy(fun x -> x.Gradient)).Item 1
                let up = 
                    (loco._ratedTractiveEffort
                     - loco.Mass
                     * ((loco.SpecificRunningResistance loco._ratedSpeed track._railType true) + track.AdditionalSpecificRunningResistance))
                let down =
                    (this.CarriagesAverageSRR loco._ratedSpeed track._railType + track.AdditionalSpecificRunningResistance)
                let result = up / down
                result



            end
