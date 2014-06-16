namespace TractionCalc

    open TractionCalc.MeasurementUnit
    open TractionCalc.Consts
    open System

    // вагон
    module Carriage =

        /// <summary>Вагон</summary>
        type Carriage = class

            /// <summary>Наименование</summary>
            val _name : string

            /// <summary>Тип вагона</summary>
            val _carriageType : CarriageType
            
            /// <summary>Длина</summary>
            val _length : float<m>

            /// <summary>Масса</summary>
            val _mass : float<t>

            /// <summary>Количество осей</summary>
            val _axelNumber : int

            /// <summary>Тип буксовых подшипников</summary>
            val _bearingType : BearingType

            /// <summary>Тип тормозных колодок</summary>
            val _brakeShoeType : BrakeShoeType

            /// <summary>Количество тормозных осей</summary>
            val _brakingAxels : int

            /// <summary>Расчётное нажатие тормозных колодок на ось, Кр, Н/ось</summary>
            val _ratedBrakingPressurePerAxel : float<N>


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
            /// <param name="carriageType">Тип вагона</param>
            /// <param name="length">Длина вагона</param>
            /// <param name="mass">Масса вагона</param>
            /// <param name="axelNumber">Число осей</param>
            /// <param name="bearingType">Тип буксовых подшипников</param>
            /// <param name="brakingAxels">Число тормозных осей</param>
            /// <param name="brakeShoeType">Тип тормозных колодок</param>
            new (name , carriageType , length , mass , axelNumber ,
                 bearingType , brakingAxels , brakeShoeType , ratedBrakingPressurePerAxel) =
                {
                    _name = name
                    _carriageType = carriageType
                    _length = length
                    _mass = mass
                    _axelNumber = axelNumber
                    _bearingType = bearingType
                    _brakeShoeType = brakeShoeType
                    _brakingAxels = brakingAxels
                    _ratedBrakingPressurePerAxel = ratedBrakingPressurePerAxel
                }


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
            /// Дополнительное удельное сопротивление движению, w", Н/т
            /// </summary>
            /// <param name="speed">Скорость, V, м/с</param>
            /// <param name="railType">Тип рельсовых путей</param>
            /// <param name="hasTraction">true - в режиме тяги, false - в режиме холостого хода</param>
            member this.SpecificRunningResistance (speed : float<km/hour>) (railType : RailType) : float<N/t> =
                match this._carriageType with
                | CarriageType.PassengerCarriage ->
                    match railType with
                    | RailType.SectionRail    -> 7.0<N/t> + (80.0<N> + 1.8<N*hour/km> * speed + 0.030<N*hour^2/km^2> * speed * speed) / this.MassPerAxel
                    | RailType.LongWeldedRail -> 7.0<N/t> + (80.0<N> + 1.6<N*hour/km> * speed + 0.023<N*hour^2/km^2> * speed * speed) / this.MassPerAxel
                    | _ -> 0.0<N/t>
                | CarriageType.RefrigeratorCarriage ->
                    if this.MassPerAxel > 6.0<t> then
                        match railType with
                        | RailType.SectionRail    -> 7.0<N/t> + (30.0<N> + 1.0<N*hour/km> * speed + 0.025<N*hour^2/km^2> * speed * speed) / this.MassPerAxel
                        | RailType.LongWeldedRail -> 7.0<N/t> + (30.0<N> + 0.9<N*hour/km> * speed + 0.020<N*hour^2/km^2> * speed * speed) / this.MassPerAxel
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
                                then 7.0<N/t> + (30.0<N> + 1.0<N*hour/km> * speed + 0.025<N*hour^2/km^2> * speed * speed) / this.MassPerAxel
                                else (10.0<N> + 0.44<N*hour/km> * speed + 0.0024<N*hour^2/km^2> * speed * speed) / 1.0<t>
                            | BearingType.SliderBearing ->
                                if this.MassPerAxel > 6.0<t>
                                then 7.0<N/t> + (80.0<N> + 1.0<N*hour/km> * speed + 0.025<N*hour^2/km^2> * speed * speed) / this.MassPerAxel
                                else (15.0<N> + 0.45<N*hour/km> * speed + 0.0027<N*hour^2/km^2> * speed * speed) / 1.0<t>
                            | _ -> 0.0<N/t>
                        | 6 ->
                            match this._bearingType with
                            | BearingType.RollerBearing ->
                                if this.MassPerAxel > 6.0<t>
                                then 7.0<N/t> + (80.0<N> + 1.0<N*hour/km> * speed + 0.025<N*hour^2/km^2> * speed * speed) / this.MassPerAxel
                                else (10.0<N> + 0.44<N*hour/km> * speed + 0.0024<N*hour^2/km^2> * speed * speed) / 1.0<t>
                            | _ -> 0.0<N/t>
                        | 8 ->
                            match this._bearingType with
                            | BearingType.RollerBearing -> 7.0<N/t> + (60.0<N> + 0.38<N*hour/km> * speed + 0.021<N*hour^2/km^2> * speed * speed) / this.MassPerAxel
                            | BearingType.SliderBearing -> 0.0<N/t>
                            | _ -> 0.0<N/t>
                        | _ -> 0.0<N/t>
                    | RailType.LongWeldedRail ->
                        match this._axelNumber with
                        | 4 ->
                            match this._bearingType with
                            | BearingType.RollerBearing ->
                                if this.MassPerAxel > 6.0<t>
                                then 7.0<N/t> + (30.0<N> + 0.9<N*hour/km> * speed + 0.020<N*hour^2/km^2> * speed * speed) / this.MassPerAxel
                                else (10.0<N> + 0.042<N*hour/km> * speed + 0.00016<N*hour^2/km^2> * speed * speed) / 1.0<t>
                            | BearingType.SliderBearing ->
                                if this.MassPerAxel > 6.0<t>
                                then 7.0<N/t> + (80.0<N> + 0.8<N*hour/km> * speed + 0.020<N*hour^2/km^2> * speed * speed) / this.MassPerAxel
                                else (15.0<N> + 0.42<N*hour/km> * speed + 0.0018<N*hour^2/km^2> * speed * speed) / 1.0<t>
                            | _ -> 0.0<N/t>
                        | 6 ->
                            match this._bearingType with
                            | BearingType.RollerBearing ->
                                if this.MassPerAxel > 6.0<t>
                                then 7.0<N/t> + (80.0<N> + 0.8<N*hour/km> * speed + 0.020<N*hour^2/km^2> * speed * speed) / this.MassPerAxel
                                else (10.0<N> + 0.42<N*hour/km> * speed + 0.0016<N*hour^2/km^2> * speed * speed) / 1.0<t>
                            | _ -> 0.0<N/t>
                        | 8 ->
                            match this._bearingType with
                            | BearingType.RollerBearing -> 7.0<N/t> + (60.0<N> + 0.26<N*hour/km> * speed + 0.017<N*hour^2/km^2> * speed * speed) / this.MassPerAxel
                            | BearingType.SliderBearing -> 0.0<N/t>
                            | _ -> 0.0<N/t>
                        | _ -> 0.0<N/t>
                    | _ -> 0.0<N/t>
                | _ -> 0.0<N/t>


            /// <summary>
            /// Дополнительное сопротивление движению, W", Н
            /// </summary>
            /// <param name="speed">Скорость, м/с</param>
            /// <param name="railType">Тип рельсовых путей</param>
            /// <param name="hasTraction">true - в режиме тяги, false - в режиме холостого хода</param>
            member this.RunningResistance (speed : float<km/hour>) (railType : RailType) (hasTraction : bool) : float<N> =
                this._mass * this.SpecificRunningResistance speed railType

        end
