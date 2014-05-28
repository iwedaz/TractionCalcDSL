namespace TractionCalc

    open TractionCalc.MeasurementUnit

    module Consts =


        /// <summary>Тип рельсовых путей:</summary>
        type RailType =
            /// <summary>Бесстыковой путь</summary>
            | LongWeldedRail
            /// <summary>Звеньевой путь</summary>
            | SectionRail



        /// <summary>Тип вагона</summary>
        type CarriageType =
            /// <summary>Пассажирский</summary>
            | PassengerCarriage
            /// <summary>Рефрижераторный</summary>
            | RefrigeratorCarriage
            /// <summary>Полувагон</summary>
            | OpenCarriage
            /// <summary>Крытый</summary>
            | СoveredCarriage
            /// <summary>Платформа</summary>
            | FlatCarriage
            /// <summary>Цистерна</summary>
            | TankCarriage



        /// <summary>Тип буксовых подшипников</summary>
        type BearingType =
            /// <summary>Подшипник качения (роликовый)</summary>
            | RollerBearing
            /// <summary>Подшипник скольжения</summary>
            | SliderBearing



        /// <summary>Тип тормозных колодок</summary>
        type BrakeShoeType =
            /// <summary>Чугунная колодка</summary>
            | CastIronBrakeShoe
            /// <summary>Композитная колодка</summary>
            | CompositeBrakeShoe



        /// <summary>Тип тяги локомотива</summary>
        type LocomotivePowerType =
            /// <summary>Дизельный</summary>
            | DieselLocomotive
            /// <summary>Электрический</summary>
            | ElectricLocomotive
            /// <summary>Дизель-электрический</summary>
            | DieselElectricLocomotive



        /// <summary>Позиция контроллера машиниста</summary>
        type LocomotiveThrottlePositionType =
            /// <summary>Не задействована</summary>
            | None
            /// <summary>Последовательное возбуждение</summary>
            | S
            /// <summary>Последовательно-параллельное возбуждение</summary>
            | SP
            /// <summary>Параллельное возбуждение</summary>
            | PP
            /// <summary>Режим ослабления магнитного поля 1</summary>
            | OP1
            /// <summary>Режим ослабления магнитного поля 2</summary>
            | OP2


        /// <summary>Кортеж (tuple), описывающий одну запись тяговой характеристики локомотива</summary>
        type LocomotiveThrottlePositionRecordType = class
            val _speed : float<km/hour>
            val _throttlePosition : LocomotiveThrottlePositionType 
            val _tractiveEffort : float<N>

            new (speed , throttlePosition , tractiveEffort) =
                {
                    _speed = speed
                    _throttlePosition = throttlePosition
                    _tractiveEffort = tractiveEffort
                }
        end
        