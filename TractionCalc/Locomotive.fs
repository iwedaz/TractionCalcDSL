namespace TractionCalc

    open TractionCalc.Consts
    open TractionCalc.MeasurementUnit

    module Locomotive =
     
        /// <summary>
        /// Локомотив
        /// </summary>
        type Locomotive = class
        
            val _name : string
            val _locomotivePowerType : LocomotivePowerType  // тип вагона
            val _length : float<m>                          // длина
            val _mass : float<t>                            // масса
            val _ratedSpeed : float<m/sec>                  // расчётная скорость
            val _ratedTractiveEffort : float<N>             // расчётная сила тяги
            val _sectionNumber : int                        // количество секций
            val _axelNumber : int                           // осей
            val _axelLoad : float<N>                        // осевая нагрузка
            val _tractionCharacteristic : Map< float<m/sec> , float<N> > 


            new (name , locomotivePowerType , length , mass , ratedSpeed ,
                 ratedTractiveEffort , sectionNumber , axelNumber , axelLoad) =
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
                    _tractionCharacteristic = Map.empty< float<m/sec> , float<N> >
                }


            /// <summary>
            /// Удельное сопротивление движению, w', Н/т
            /// </summary>
            /// <param name="speed">Скорость, м/с</param>
            /// <param name="railType">Тип рельсовых путей</param>
            /// <param name="hasTraction">true - в режиме тяги, false - в режиме холостого хода</param>
            member this.SpecificRunningResistance (speed : float<m/sec>) (railType : RailType) (hasTraction : bool) : float<N/t> =
                let speedKmPerHour = MetrePerSecToKmPerHour speed
                match railType with
                    | RailType.SectionRail ->
                        if hasTraction
                        then 1.0<N/t> * (19.0 + 0.10<hour/km> * speedKmPerHour + 0.0030<hour^2/km^2> * speedKmPerHour * speedKmPerHour)
                        else 1.0<N/t> * (24.0 + 0.11<hour/km> * speedKmPerHour + 0.0035<hour^2/km^2> * speedKmPerHour * speedKmPerHour)
                    | RailType.LongWeldedRail -> 
                        if hasTraction
                        then 1.0<N/t> * (19.0 + 0.08<hour/km> * speedKmPerHour + 0.0025<hour^2/km^2> * speedKmPerHour * speedKmPerHour)
                        else 1.0<N/t> * (24.0 + 0.09<hour/km> * speedKmPerHour + 0.0035<hour^2/km^2> * speedKmPerHour * speedKmPerHour)
                    | _ -> 0.0<N/t>


            /// <summary>
            /// Сопротивление движению, W', Н
            /// </summary>
            /// <param name="speed">Скорость, м/с</param>
            /// <param name="railType">Тип рельсовых путей</param>
            /// <param name="hasTraction">true - в режиме тяги, false - в режиме холостого хода</param>
            member this.RunningResistance (speed : float<m/sec>) (railType : RailType) (hasTraction : bool) : float<N> =
                this._mass * this.SpecificRunningResistance speed railType hasTraction

        end

