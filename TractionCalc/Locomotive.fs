namespace TractionCalc

    open TractionCalc.MeasurementUnit
    open TractionCalc.Consts

    module Locomotive =

        /// <summary>Кортеж (tuple), описывающий одну запись тяговой характеристики локомотива</summary>
        type LocomotiveThrottlePositionRecordType = class
            val _speed : float<km/hour>
            val _engineMode : LocomotiveTractionEngineModeType 
            val _tractiveEffort : float<N>

            new (speed , throttlePosition , tractiveEffort) =
                {
                    _speed = speed
                    _engineMode = throttlePosition
                    _tractiveEffort = tractiveEffort
                }
        end


        /// <summary>Локомотив</summary>
        type Locomotive = class

            /// <summary>Наименование</summary>
            val _name : string

            /// <summary>Тип тяги</summary>
            val _locomotivePowerType : LocomotivePowerType

            /// <summary>Длина</summary
            val _length : float<m>

            /// <summary>Масса секции</summary>
            val _mass : float<t>

            /// <summary>Расчётная скорость</summary>
            val _ratedSpeed : float<km/hour>

            /// <summary>Расчётная сила тяги</summary>
            val _ratedTractiveEffort : float<N>

            /// <summary>Количество секций</summary>
            val _sectionNumber : int

            /// <summary>Количество осей</summary>
            val _axelNumber : int

            /// <summary>Осевая нагрузка</summary>
            val _axelLoad : float<N>

            /// <summary>Тип тормозных колодок</summary>
            val _brakeShoeType : BrakeShoeType

            /// <summary>Количество тормозных осей</summary>
            val _brakingAxels : int

            /// <summary>Расчётное нажатие тормозных колодок на ось, Кр, Н/ось</summary>
            val _ratedBrakingPressurePerAxel : float<N>

            /// <summary>Тяговая характеристика, [скорость , [позиция контроллера , сила тяги]]</summary>
            val mutable _tractionCharacteristic : LocomotiveThrottlePositionRecordType list


            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="name"></param>
            /// <param name="locomotivePowerType"></param>
            /// <param name="length"></param>
            /// <param name="mass"></param>
            /// <param name="ratedSpeed"></param>
            /// <param name="ratedTractiveEffort"></param>
            /// <param name="sectionNumber"></param>
            /// <param name="axelNumber"></param>
            /// <param name="axelLoad"></param>
            new (name , locomotivePowerType , length , mass , ratedSpeed ,
                 ratedTractiveEffort , sectionNumber , axelNumber , axelLoad ,
                 brakingAxels , brakeShoeType , ratedBrakingPressurePerAxel) =
                {
                    _name = name
                    _locomotivePowerType = locomotivePowerType
                    _length = length
                    _mass = mass
                    _ratedSpeed = ratedSpeed
                    _ratedTractiveEffort = ratedTractiveEffort
                    _sectionNumber = sectionNumber
                    _axelNumber = axelNumber
                    _axelLoad = axelLoad
                    _brakeShoeType = brakeShoeType
                    _brakingAxels = brakingAxels
                    _ratedBrakingPressurePerAxel = ratedBrakingPressurePerAxel
                    _tractionCharacteristic = []
                }


            /// <summary>
            /// Основное удельное сопротивление движению, w', Н/т
            /// </summary>
            /// <param name="speed">Скорость, м/с</param>
            /// <param name="railType">Тип рельсовых путей</param>
            /// <param name="hasTraction">true - в режиме тяги, false - в режиме холостого хода</param>
            member this.SpecificRunningResistance (speed : float<km/hour>) (railType : RailType) (hasTraction : bool) : float<N/t> =
                let result =
                    match railType with
                        | RailType.SectionRail ->
                            if hasTraction
                            then 1.0<N/t> * (19.0 + 0.10<hour/km> * speed + 0.0030<hour^2/km^2> * speed * speed)
                            else 1.0<N/t> * (24.0 + 0.11<hour/km> * speed + 0.0035<hour^2/km^2> * speed * speed)
                        | RailType.LongWeldedRail ->
                            if hasTraction
                            then 1.0<N/t> * (19.0 + 0.08<hour/km> * speed + 0.0025<hour^2/km^2> * speed * speed)
                            else 1.0<N/t> * (24.0 + 0.09<hour/km> * speed + 0.0035<hour^2/km^2> * speed * speed)
                        | _ -> 0.0<N/t>
                result


            /// <summary>
            /// Основное сопротивление движению, W', Н
            /// </summary>
            /// <param name="speed">Скорость, м/с</param>
            /// <param name="railType">Тип рельсовых путей</param>
            /// <param name="hasTraction">true - в режиме тяги, false - в режиме холостого хода</param>
            member this.RunningResistance (speed : float<km/hour>) (railType : RailType) (hasTraction : bool) : float<N> =
                this._mass * this.SpecificRunningResistance speed railType hasTraction


            /// <summary>
            /// Суммарная масса всех секций
            /// </summary>
            member this.Mass : float<t> =
                this._mass * (float)this._sectionNumber


            member this.GetTractiveEffortBySpeed (speed : float<km/hour>) : float<N> =
                if this._tractionCharacteristic.Length > 0
                then
                    let recordsBySpeed = this._tractionCharacteristic |> List.sortBy(fun x -> x._speed)
                    let majorRecordIndex = recordsBySpeed |> List.tryFindIndex(fun x -> x._speed >= speed)

                    if not majorRecordIndex.IsNone && majorRecordIndex.Value > 0
                    then 
                        let majorRecord = recordsBySpeed.Item majorRecordIndex.Value
                        let minorRecord = recordsBySpeed.Item (majorRecordIndex.Value - 1)

                        let majorEffort = majorRecord._tractiveEffort
                        let minorEffort = minorRecord._tractiveEffort
                        let majorSpeed = majorRecord._speed
                        let minorSpeed = minorRecord._speed
                        let result = minorEffort + abs(majorEffort - minorEffort) * abs(speed - minorSpeed) / abs(majorSpeed - minorSpeed)
                        result

                    else 0.0<N>
                else 0.0<N>

        end
