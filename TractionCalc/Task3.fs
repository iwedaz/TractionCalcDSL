namespace TractionCalc

    open TractionCalc.MeasurementUnit
    open TractionCalc.Consts
    open TractionCalc.Carriage
    open TractionCalc.Stock
    open TractionCalc.Locomotive
    open TractionCalc.Train
    open TractionCalc.TrackSection
    open TractionCalc.Track


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
                let locoTractiveEffort = locos |> List.sumBy(fun l -> (l._tractionCharacteristic |> List.sumBy(fun r -> if r._speed = 0.0<km/hour> then r._tractiveEffort else 0.0<N>)))
                let locosMass = locos |> List.sumBy(fun l  -> l.Mass)

                let stocks = this._train._stocks
                let stockGetawayResistance = stocks |> List.sumBy(fun s -> s.GetawayResistance)
                let stockMass = stocks |> List.sumBy(fun s -> s.Mass)

                let calcStockMass = locoTractiveEffort / (stockGetawayResistance + this._trackSection.AdditionalSpecificRunningResistance) - locosMass
                let result = stockMass < calcStockMass

                if locos.Length > 1
                then result && locoTractiveEffort <= (930000.0<N> + stockMass * (stockGetawayResistance + this._trackSection.AdditionalSpecificRunningResistance))
                else result

            end

