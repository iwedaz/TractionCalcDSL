namespace TractionCalc

    module Consts =
        
        /// <summary>
        /// Тип рельсовых путей:
        /// <para>LongWeldedRail - бесстыковой</para>
        /// <para>SectionRail    - звеньевой</para>
        /// <para>SectionRail160 - звеньевой до 160 км/ч</para>
        /// </summary>
        type RailType =
            | LongWeldedRail        //бесстыковой
            | SectionRail           //звеньевой
            //| SectionRail160        //звеньевой до 160 км/ч


        /// <summary>
        /// Тип вагона
        /// <para>OpenCarriage    - полувагон</para>
        /// <para>СoveredCarriage - крытый</para>
        /// <para>FlatCarriage    - платформа</para>
        /// <para>TankCarriage    - цистерна</para>
        /// </summary>
        type CarriageType =
            | PassengerCarriage     // пассажирский
            | RefrigeratorCarriage  // рефрижераторный
            | OpenCarriage          // полувагон
            | СoveredCarriage       // крытый
            | FlatCarriage          // платформа
            | TankCarriage          // цистерна


        /// <summary>
        /// Тип буксовых подшипников
        /// <para>RollerBearing - подшипник качения (роликовый)</para>
        /// <para>SliderBearing - подшипник скольжения</para>
        /// </summary>
        type BearingType =
            | RollerBearing         // подшипник качения (роликовый)
            | SliderBearing         // подшипник скольжения


        /// <summary>
        /// Тип тормозных колодок
        /// <para>CastIronBrakeShoe  - чугунная колодка</para>
        /// <para>CompositeBrakeShoe - композитная колодка</para>
        /// </summary>
        type BrakeShoeType =
            | CastIronBrakeShoe     // чугунная колодка
            | CompositeBrakeShoe    // композитная колодка


        /// <summary>
        /// Тип тяги локомотива
        /// </summary>
        type LocomotivePowerType =
            | DieselPower
            | ElectricPower
            | DieselElectricPower



        let TokenConst = -11
        let TokenConstTrackSection = -12
        let TokenConstCarriage = -13
        let TokenConstLocomotive = -14

        type AndAType = class new () = {} end
        let andA = AndAType()

        type WithAType = class new () = {} end
        let withA = WithAType()
            
        type ForAType = class new () = {} end
        let forA = ForAType()

        type FromAType = class new () = {} end
        let fromA = FromAType()

        type OnAType = class new () = {} end
        let onA = OnAType()

        type BuildAsType = class new () = {} end
        let builtAs = BuildAsType()

        type IncludedType = class new () = {} end
        let included = IncludedType()

        type BasedOnType = class new () = {} end
        let basedOn = BasedOnType()

        type TypeAType = class new () = {} end
        let typeA = TypeAType()
