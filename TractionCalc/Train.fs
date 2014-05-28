namespace TractionCalc

    open TractionCalc.MeasurementUnit
    open TractionCalc.Consts
    open TractionCalc.Stock
    open TractionCalc.Locomotive

    module Train =


        /// <summary>Поезд</summary>
        type Train = class

            /// <summary>Наименование</summary>
            val _name : string

            /// <summary>Список присоединённых составов</summary>
            val mutable _stocks : Stock list

            /// <summary>Список присоединённых локомотивов</summary>
            val mutable _locomotives : Locomotive list

            new (name) =
                {
                    _name = name
                    _stocks = []
                    _locomotives = []
                }

            /// <summary>
            /// Масса поезда
            /// </summary>
            member this.Mass : float<t> =
                    let r1 = if this._stocks.Length <> 0
                             then this._stocks |> List.sumBy (fun x -> x.Mass)
                             else 0.0<t>

                    let r2 = if this._stocks.Length <> 0
                             then this._stocks |> List.sumBy (fun x -> x.Mass)
                             else 0.0<t>
                    r1 + r2

        end
