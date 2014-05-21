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

    
    module Task3 =
        
        /// <summary>
        /// Проверка массы состава на трогание
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        type Task3 = class
            val _name : string
            val _train : Train
            val _trackSection : TrackSection

            new (name , train , trackSection) =
                {
                    _name = name
                    _train = train
                    _trackSection = trackSection
                }


            /// <summary>
            /// true - если поезд сможет тронуться при текущей массе состава,
            /// false - в обратном случае
            /// </summary>
            member this.StockGetawayResistanceCheck : bool =
                let locos = this._train._locomotives
                let locoTractiveEffort = locos |> List.sumBy(fun l -> l._tractionCharacteristic.Item 0.0<m/sec>)
                let locosMass = locos |> List.sumBy(fun l  -> l._mass)

                let stocks = this._train._stocks
                let stockGetawayResistance = stocks |> List.sumBy(fun s -> s.GetawayResistance)
                let stockMass = stocks |> List.sumBy(fun s -> s.Mass)
                
                let calcStockMass = locoTractiveEffort / (stockGetawayResistance + 10.0<N/t> * this._trackSection.Gradient) - locosMass
                let result = stockMass < calcStockMass

                if locos.Length > 1
                then result && locoTractiveEffort <= (930000.0<N> + stockMass * (stockGetawayResistance + 10.0<N/t> * this._trackSection.Gradient))
                else result

            end

