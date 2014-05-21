namespace TractionCalc

    open TractionCalc.Consts
    open TractionCalc.MeasurementUnit
    open TractionCalc.Stock
    open TractionCalc.Locomotive

    module Train =


        // поезд
        type Train = class
        
            val _name : string
            val mutable _stocks : Stock list
            val mutable _locomotives : Locomotive list
            
            new (name) =
                {
                    _name = name
                    _stocks = []
                    _locomotives = []
                }

            // масса поезда
            member this.Mass : float<t> = 
                    let r1 = if this._stocks.Length <> 0
                             then this._stocks |> List.sumBy (fun x -> x.Mass)
                             else 0.0<t>
                    
                    let r2 = if this._stocks.Length <> 0
                             then this._stocks |> List.sumBy (fun x -> x.Mass)
                             else 0.0<t>
                    r1 + r2

        end
