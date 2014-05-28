namespace TractionCalc

    open TractionCalc.MeasurementUnit
    open TractionCalc.Consts
    open TractionCalc.TrackSection

    module Track =

        /// <summary>
        /// Общее представление пути
        /// </summary>
        type Track = class

            val _name : string
            val mutable _sections : TrackSection list

            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="name">Имя пути</param>
            new (name) =
                {
                    _name = name
                    _sections = []
                }

            //
            /// <summary>
            /// Сумма удельных сопротивлений движению всех участков (TrackSection) пути
            /// </summary>
            member this.AdditionalSpecificRunningResistance : float<N/t> =
                let result =
                    if this._sections.Length <> 0
                    then this._sections |> List.sumBy (fun x -> x.AdditionalSpecificRunningResistance)
                    else 0.0<N/t>
                result


            // суммарный реальный подъём всех участков (TrackSection) пути
            member this.RealGradient : float =
                if  this._sections.Length <> 0
                then this._sections |> List.sumBy (fun x -> x._gradient)
                else 0.0

            // суммарный фиктивный подъём всех участков (TrackSection) пути
            member this.FictitiousCurveGradient : float =
                if  this._sections.Length <> 0
                then this._sections |> List.sumBy (fun x -> x.FictitiousCurveGradient)
                else 0.0

            // суммарный подъём всех участков (TrackSection) пути
            member this.Gradient : float =
                this.RealGradient + this.FictitiousCurveGradient

        end
