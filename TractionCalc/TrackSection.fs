namespace TractionCalc

    open TractionCalc.MeasurementUnit
    open TractionCalc.Consts


    module TrackSection =

        /// <summary>Участок пути</summary>
        /// <para>Часть пути, которая включает в себя не больше одной кривой при одинаковом уклоне</para>
        type TrackSection = class

            /// <summary>Наименование</summary>
            val _name : string
            
            /// <summary>Длина</summary>
            val _length : float<m>
            
            /// <summary>Уклон, промилле</summary>
            val _gradient : float

            /// <summary>Тип рельсового полотна</summary>
            val _railType : RailType

            /// <summary>Ограничение скорости на участке</summary>
            val _speedLimit : float<km/hour>

            //кривая
            /// <summary>Длина кривой</summary>
            val _curveLength : float<m>

            /// <summary>Радиус кривой</summary>
            val _curveRadius : float<m>

            /// <summary>Угол кривой</summary>
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

            
            /// <summary>Удельное сопротивление движению от кривой, Н/т</summary>
            member this.CurveAdditionalSpecificRunningResistance : float<N/t> =
                if this._curveRadius > (0.0<m>)
                then 7000.0<m*N/t> / this._curveRadius
                else 0.0<N/t>


            /// <summary>Удельное сопротивление движению от уклона, Н/т</summary>
            member this.GradientAdditionalSpecificRunningResistance : float<N/t> =
                this._gradient * 10.0<N/t>


            /// <summary>Полное удельное сопротивление движению от профиля пути, Н/т</summary>
            member this.AdditionalSpecificRunningResistance : float<N/t> =
                let result = 
                    this.GradientAdditionalSpecificRunningResistance + this.CurveAdditionalSpecificRunningResistance
                result


            /// <summary>Фиктивный уклон для замены кривой, промилле</summary>
            member this.FictitiousCurveGradient : float =
                if this._length > (0.0<m>) && this._curveRadius > (0.0<m>)
                then 700.0<m> / this._length * this._curveLength / this._curveRadius
                else 0.0


            /// <summary>Приведённый (полный) уклон участка пути, промилле</summary>
            member this.Gradient : float =
                this._gradient + this.FictitiousCurveGradient

        end

