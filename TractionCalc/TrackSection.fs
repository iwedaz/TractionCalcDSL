namespace TractionCalc

    open TractionCalc.Consts
    open TractionCalc.MeasurementUnit


    // часть пути, которая включает в себя не больше одной кривой при одинаковом уклоне
    module TrackSection =
        
        type TrackSection = class
        
            val _name : string
            val _length : float<m>          // длина
            val _gradient : float           // уклон, промили
            val _railType : RailType        // тип рельсового полотна
            val _speedLimit : float<m/sec>  // ограничение скорости на участке

            //кривая
            val _curveLength : float<m>
            val _curveRadius : float<m>
            val _curveAngle : float

            new (name , length , gradient , railType , speedLimit) =
                {
                    _name = name
                    _length = length
                    _gradient = gradient
                    _railType = railType
                    _speedLimit = speedLimit
                    _curveLength = 0.0<m>
                    _curveRadius = 0.0<m>
                    _curveAngle = 0.0
                }

            new (name , length , gradient , railType , speedLimit , curveLength , curveRadius) =
                {
                    _name = name
                    _length = length
                    _gradient = gradient
                    _railType = railType
                    _speedLimit = speedLimit
                    _curveLength = curveLength
                    _curveRadius = curveRadius

                    _curveAngle = 
                        if curveRadius > (0.0<m>)
                        then (float)(700.0 / 12.2 * (float)curveLength / (float)curveRadius)
                        else 0.0
                }

            new (name , length , gradient , railType , speedLimit , curveAngle) =
                {
                    _name = name
                    _length = length
                    _gradient = gradient
                    _railType = railType
                    _speedLimit = speedLimit
                    _curveLength = (LanguagePrimitives.FloatWithMeasure<m>)((float)(curveAngle * 12.2 / (float)700))
                    _curveRadius = 1.0<m>
                    _curveAngle = curveAngle
                }


            // удельное сопротивление движению
            member this.SpecificRunningResistance : float<N/t> = 
                if this._curveRadius > (0.0<m>)
                then 700.0<m*N/t> / this._curveRadius
                else 0.0<N/t>
            

            // фиктивный подъём для замены кривой
            member this.FictitiousCurveGradient : float = 
                if this._length > (0.0<m>) && this._curveRadius > (0.0<m>)
                then 700.0<m> / this._length * this._curveLength / this._curveRadius
                else 0.0


            // суммарный подъём участка пути
            member this.Gradient : float = 
                this._gradient + this.FictitiousCurveGradient

        end

