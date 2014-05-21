namespace TractionCalc

    open TractionCalc.Consts
    open TractionCalc.MeasurementUnit
    open System

    // вагон
    module Carriage =
        
        /// <summary>
        /// Вагон
        /// </summary>
        type Carriage = class
                    
            val _name : string
            val _carriageType : CarriageType    // тип вагона
            val _length : float<m>              // длина
            val _mass : float<t>                // масса
            val _axelNumber : int               // количество осей
            val _bearingType : BearingType      // тип буксовых подшипников
            val _brakeShoeType : BrakeShoeType  // тип тормозных колодок
            val _brakingAxels : int             // тормозных осей


            interface IComparable<Carriage> with
                member this.CompareTo(obj) =
                    if this._name = obj._name &&
                       this._carriageType = obj._carriageType &&
                       this._length = obj._length &&
                       this._mass = obj._mass &&
                       this._axelNumber = obj._axelNumber &&
                       this._bearingType = obj._bearingType &&
                       this._brakeShoeType = obj._brakeShoeType &&
                       this._brakingAxels = obj._brakingAxels
                    then 0
                    else this._name.CompareTo(obj._name)


            interface IComparable with
                member this.CompareTo(obj1) =
                    let obj = obj1 :?> Carriage
                    if this._name = obj._name &&
                       this._carriageType = obj._carriageType &&
                       this._length = obj._length &&
                       this._mass = obj._mass &&
                       this._axelNumber = obj._axelNumber &&
                       this._bearingType = obj._bearingType &&
                       this._brakeShoeType = obj._brakeShoeType &&
                       this._brakingAxels = obj._brakingAxels
                    then 0
                    else this._name.CompareTo(obj._name)

            
            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="name">Имя вагона</param>
            /// <param name="carriageType"></param>
            /// <param name="length"></param>
            /// <param name="mass"></param>
            /// <param name="axelNumber"></param>
            /// <param name="bearingType"></param>
            /// <param name="brakingAxels"></param>
            /// <param name="brakeShoeType"></param>
            new (name , carriageType , length , mass , axelNumber , bearingType , brakingAxels , brakeShoeType) =
                {
                    _name = name
                    _carriageType = carriageType
                    _length = length
                    _mass = mass
                    _axelNumber = axelNumber
                    _bearingType = bearingType
                    _brakeShoeType = brakeShoeType
                    _brakingAxels = brakingAxels
                }


            // сопротивление троганию
            /// <summary>
            /// Удельное сопротивление троганию вагона, w"тр, Н/т
            /// </summary>
            member this.GetawayResistance : float<N/t> =
                match this._bearingType with
                    | BearingType.RollerBearing -> 280.0<N> / (this._mass + 7.0<t>)
                    | BearingType.SliderBearing -> 1420.0<N> / (this._mass + 7.0<t>)
                    | _ -> 0.0<N/t>


            /// <summary>
            /// Масса, приходящаяся на одну ось, q0, т/ось
            /// </summary>
            member this.MassPerAxel : float<t> =
                this._mass / (float)this._axelNumber


            /// <summary>
            /// Удельное сопротивление движению, w", Н/т
            /// </summary>
            /// <param name="speed">Скорость, V, м/с</param>
            /// <param name="railType">Тип рельсовых путей</param>
            /// <param name="hasTraction">true - в режиме тяги, false - в режиме холостого хода</param>
            member this.SpecificRunningResistance (speed : float<m/sec>) (railType : RailType) : float<N/t> =
                let speedKmPerHour = MetrePerSecToKmPerHour speed
                match this._carriageType with
                | CarriageType.PassengerCarriage -> 
                    match railType with
                    | RailType.SectionRail    -> 7.0<N/t> + (80.0<N> + 1.8<N*hour/km> * speedKmPerHour + 0.030<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / this.MassPerAxel
                    | RailType.LongWeldedRail -> 7.0<N/t> + (80.0<N> + 1.6<N*hour/km> * speedKmPerHour + 0.023<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / this.MassPerAxel
                    | _ -> 0.0<N/t>
                | CarriageType.RefrigeratorCarriage ->
                    if this.MassPerAxel > 6.0<t> then
                        match railType with
                        | RailType.SectionRail    -> 7.0<N/t> + (30.0<N> + 1.0<N*hour/km> * speedKmPerHour + 0.025<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / this.MassPerAxel
                        | RailType.LongWeldedRail -> 7.0<N/t> + (30.0<N> + 0.9<N*hour/km> * speedKmPerHour + 0.020<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / this.MassPerAxel
                        | _ -> 0.0<N/t>
                    else 0.0<N/t>
                | x when x.GetType().Equals(typeof<CarriageType>) ->
                    match railType with
                    | RailType.SectionRail    ->
                        match this._axelNumber with
                        | 4 ->
                            match this._bearingType with
                            | BearingType.RollerBearing ->
                                if this.MassPerAxel > 6.0<t>
                                then 7.0<N/t> + (30.0<N> + 1.0<N*hour/km> * speedKmPerHour + 0.025<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / this.MassPerAxel
                                else (10.0<N> + 0.44<N*hour/km> * speedKmPerHour + 0.0024<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / 1.0<t>
                            | BearingType.SliderBearing ->
                                if this.MassPerAxel > 6.0<t>
                                then 7.0<N/t> + (80.0<N> + 1.0<N*hour/km> * speedKmPerHour + 0.025<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / this.MassPerAxel
                                else (15.0<N> + 0.45<N*hour/km> * speedKmPerHour + 0.0027<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / 1.0<t>
                            | _ -> 0.0<N/t>
                        | 6 ->
                            match this._bearingType with
                            | BearingType.RollerBearing ->
                                if this.MassPerAxel > 6.0<t>
                                then 7.0<N/t> + (80.0<N> + 1.0<N*hour/km> * speedKmPerHour + 0.025<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / this.MassPerAxel
                                else (10.0<N> + 0.44<N*hour/km> * speedKmPerHour + 0.0024<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / 1.0<t>
                            | _ -> 0.0<N/t>
                        | 8 ->
                            match this._bearingType with
                            | BearingType.RollerBearing -> 7.0<N/t> + (60.0<N> + 0.38<N*hour/km> * speedKmPerHour + 0.021<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / this.MassPerAxel
                            | BearingType.SliderBearing -> 0.0<N/t>
                            | _ -> 0.0<N/t>
                        | _ -> 0.0<N/t>
                    | RailType.LongWeldedRail ->
                        match this._axelNumber with
                        | 4 ->
                            match this._bearingType with
                            | BearingType.RollerBearing ->
                                if this.MassPerAxel > 6.0<t>
                                then 7.0<N/t> + (30.0<N> + 0.9<N*hour/km> * speedKmPerHour + 0.020<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / this.MassPerAxel
                                else (10.0<N> + 0.042<N*hour/km> * speedKmPerHour + 0.00016<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / 1.0<t>
                            | BearingType.SliderBearing ->
                                if this.MassPerAxel > 6.0<t>
                                then 7.0<N/t> + (80.0<N> + 0.8<N*hour/km> * speedKmPerHour + 0.020<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / this.MassPerAxel
                                else (15.0<N> + 0.42<N*hour/km> * speedKmPerHour + 0.0018<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / 1.0<t>
                            | _ -> 0.0<N/t>
                        | 6 ->
                            match this._bearingType with
                            | BearingType.RollerBearing ->
                                if this.MassPerAxel > 6.0<t>
                                then 7.0<N/t> + (80.0<N> + 0.8<N*hour/km> * speedKmPerHour + 0.020<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / this.MassPerAxel
                                else (10.0<N> + 0.42<N*hour/km> * speedKmPerHour + 0.0016<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / 1.0<t>
                            | _ -> 0.0<N/t>
                        | 8 ->
                            match this._bearingType with
                            | BearingType.RollerBearing -> 7.0<N/t> + (60.0<N> + 0.26<N*hour/km> * speedKmPerHour + 0.017<N*hour^2/km^2> * speedKmPerHour * speedKmPerHour) / this.MassPerAxel
                            | BearingType.SliderBearing -> 0.0<N/t>
                            | _ -> 0.0<N/t>
                        | _ -> 0.0<N/t>
                    | _ -> 0.0<N/t>
                | _ -> 0.0<N/t>
               

            /// <summary>
            /// Сопротивление движению, W", Н
            /// </summary>
            /// <param name="speed">Скорость, м/с</param>
            /// <param name="railType">Тип рельсовых путей</param>
            /// <param name="hasTraction">true - в режиме тяги, false - в режиме холостого хода</param>
            member this.RunningResistance (speed : float<m/sec>) (railType : RailType) (hasTraction : bool) : float<N> =
                this._mass * this.SpecificRunningResistance speed railType
            
        end
