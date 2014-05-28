namespace TractionCalc

    open TractionCalc.MeasurementUnit
    open TractionCalc.Consts
    open TractionCalc.Carriage

    module Stock =

        /// <summary>Состав</summary>
        type Stock = class

            /// <summary>Наименование</summary>
            val _name : string

            /// <summary>Список вагонов</summary>
            val mutable _carriages : Carriage list

            new (name) =
                {
                    _name = name
                    _carriages = []
                }


            /// <summary>Масса состава, Q, т</summary>
            member this.Mass : float<t> =
                if this._carriages.Length <> 0
                then this._carriages |> List.sumBy (fun x -> x._mass)
                else 0.0<t>


            /// <summary>Масса, приходящаяся на одну ось, q0, т/ось</summary>
            member this.MassPerAxel : float<t> =
                let axelNumber = 
                    if this._carriages.Length <> 0
                    then this._carriages |> List.sumBy (fun x -> x._axelNumber)
                    else 0
                this.Mass / (float)axelNumber


            /// <summary>Удельное сопротивление троганию состава, w"тр, Н/т</summary>
            member this.GetawayResistance : float<N/t> =
                if this._carriages.Length <> 0
                then this._carriages |> List.sumBy (fun x -> x.GetawayResistance)
                else 0.0<N/t>

        end

