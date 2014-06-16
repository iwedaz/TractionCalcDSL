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


            member private this.CarriagesAverageSRR (speed : float<km/hour>) (railType : RailType) : float<N/t> =
                let mutable result = 0.0<N/t>
                let carList = this._carriages |> Map.toList
                for car in carList do
                   let first = fst car
                   let second = snd car
                   result <- result + first.SpecificRunningResistance speed railType * second
                result


//            member this.StockMass (trackSectionName : string) (startSpeed : float<km/hour>) : float<t> =
//                let sectionOpt = this._track._sections |> List.tryFind(fun x -> x._name = trackSectionName)
//                if not sectionOpt.IsNone && sectionOpt.Value._speedLimit >= startSpeed
//                then this.StockMass sectionOpt.Value startSpeed
//                else 0.0<t>

            /// <summary>
            /// Расчётная максимальная масса состава на заданном участке
            /// при заданном локомотиве, Qmax, т
            /// </summary>
            /// <param name="trackSection"></param>
            /// <param name="startSpeed"></param>
            member this.StockMass (trackSection : TrackSection) (startSpeed : float<km/hour>) : float<t> =
                let loco = this._locomotive
                let sections = this._track._sections
                let sectionsByGradient = sections
                                         |> List.sortBy(fun x -> x.Gradient)
                                         |> Seq.distinctBy(fun x -> x.Gradient)
                                         |> List.ofSeq
                
                let sectionOne = sectionsByGradient.Item 1
                let sectionNull = sectionsByGradient.Item 0

                let trackSectionIndex = sections |> List.tryFindIndex(fun x -> x = trackSection)
                let sectionNullIndex = sections |> List.findIndex(fun x -> x = sectionNull)

                if not trackSectionIndex.IsNone && trackSectionIndex.Value <= sectionNullIndex
                then

                    let numerator = 
                        (loco._ratedTractiveEffort
                         - loco.Mass
                         * ((loco.SpecificRunningResistance loco._ratedSpeed sectionOne._railType true) + sectionOne.AdditionalSpecificRunningResistance))
                    let denominator =
                        (this.CarriagesAverageSRR loco._ratedSpeed sectionOne._railType + sectionOne.AdditionalSpecificRunningResistance)
                    let stockMassSectionOne = numerator / denominator


                    let getSpeedRange (start : float<km/hour>) (stop : float<km/hour>) (step : float<km/hour>) : float<km/hour> list =
                        let mutable s = start
                        let mutable result : float<km/hour> list = []
                        while s > stop - 1.0<km/hour> do
                            s <- s - 1.0<km/hour>
                            result <- result @ [s]
                        result @ [stop;]


                    let speedList = getSpeedRange 
                    //for x in speed .. 


                    //result
                    0.0<t>

                else 0.0<t>


        end
