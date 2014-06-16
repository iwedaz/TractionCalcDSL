#load "MeasurementUnit.fs"
#load "Consts.fs"
#load "Carriage.fs"
#load "Stock.fs"
#load "Locomotive.fs"
#load "Train.fs"
#load "TrackSection.fs"
#load "Track.fs"
#load "Task1.fs"
#load "Task2.fs"
#load "Task3.fs"
#load "Task4.fs"
#load "Task5.fs"
#load "CalculationTask.fs"
#load "..\packages\FSharp.Charting.0.90.6\FSharp.Charting.fsx"

namespace TractionCalc

    open TractionCalc.MeasurementUnit
    open TractionCalc.Consts
    open TractionCalc.Carriage
    open TractionCalc.Stock
    open TractionCalc.Locomotive
    open TractionCalc.Train
    open TractionCalc.TrackSection
    open TractionCalc.Track
    open TractionCalc.Task1
    open TractionCalc.Task2
    open TractionCalc.Task3
    open TractionCalc.Task4
    open TractionCalc.Task5
    open TractionCalc.CalculationTask
    open FSharp.Charting

    module DSLDeclaration =

// ############################# TOKEN WORDS ###############################################

        /////////////////// general tokens
        type AndATokenType = class new() = {} end
        let andA = AndATokenType()

        type WithATokenType = class new() = {} end
        let withA = WithATokenType()

        type ForATokenType = class new() = {} end
        let forA = ForATokenType()

        type FromATokenType = class new() = {} end
        let fromA = FromATokenType()

        type OnATokenType = class new() = {} end
        let onA = OnATokenType()

        type InATokenType = class new() = {} end
        let inA = InATokenType()

        type BuiltAsTokenType = class new() = {} end
        let builtAs = BuiltAsTokenType()

        type IncludedTokenType = class new() = {} end
        let included = IncludedTokenType()

        type BasedOnTokenType = class new() = {} end
        let basedOn = BasedOnTokenType()

        type TypeATokenType = class new() = {} end
        let typeA = TypeATokenType()


        /////////////////// carriage tokens

        /// <summary>Пассажирский</summary>
        let PassengerCarriage = CarriageType.PassengerCarriage

        /// <summary>Полувагон</summary>
        let OpenCarriage = CarriageType.OpenCarriage

        /// <summary>Крытый</summary>
        let СoveredCarriage = CarriageType.СoveredCarriage

        /// <summary>Платформа</summary>
        let FlatCarriage = CarriageType.FlatCarriage

        /// <summary>Цистерна</summary>
        let TankCarriage = CarriageType.TankCarriage

        /// <summary>Подшипник качения (роликовый)</summary>
        let RollerBearing = BearingType.RollerBearing

        /// <summary>Подшипник скольжения</summary>
        let SliderBearing = BearingType.SliderBearing

        /// <summary>Чугунная колодка</summary>
        let CastIronFromPlainMaterial = BrakeShoeType.CastIronFromPlainMaterialBrakeShoe

        /// <summary>Чугунная колодка</summary>
        let CastIronWithHighPhosphorusBrakeShoe = BrakeShoeType.CastIronWithHighPhosphorusBrakeShoe

        /// <summary>Чугунная колодка</summary>
        let CastIronWith3PercentPhosphorusBrakeShoe = BrakeShoeType.CastIronWith3PercentPhosphorusBrakeShoe

        /// <summary>Композитная колодка</summary>
        let Composite8166BrakeShoe = BrakeShoeType.Composite8166BrakeShoe

        /// <summary>Композитная колодка</summary>
        let Composite328303BrakeShoe = BrakeShoeType.Composite328303BrakeShoe

        type MassTokenType = class new() = {} end
        let mass = MassTokenType()

        type AxelNumberTokenType = class new() = {} end
        let axelNumber = AxelNumberTokenType()

        type BrakingAxelsTokenType = class new() = {} end
        let brakingAxels = BrakingAxelsTokenType()

        type BrakingPressurePerAxelType = class new() = {} end
        let brakingPressurePerAxel = BrakingPressurePerAxelType()


        /////////////////// locomotive tokens

        /// <summary>Дизельный</summary>
        let DieselLocomotive = LocomotivePowerType.DieselLocomotive

        /// <summary>Электрический</summary>
        let ElectricLocomotive = LocomotivePowerType.ElectricLocomotive

        /// <summary>Дизель-электрический</summary>
        let DieselElectricLocomotive = LocomotivePowerType.DieselElectricLocomotive

        type RatedSpeedTokenType = class new() = {} end
        let ratedSpeed = RatedSpeedTokenType()

        type RatedTractiveEffortTokenType = class new() = {} end
        let ratedTractiveEffort = RatedTractiveEffortTokenType()

        type SectionNumberTokenType = class new() = {} end
        let sectionNumber = SectionNumberTokenType()

        type AxelLoadTokenType = class new() = {} end
        let axelLoad = AxelLoadTokenType()


        /////////////////// section tokens
        type LengthTokenType = class new() = {} end
        let length = LengthTokenType()

        type GradientTokenType = class new() = {} end
        let gradient = GradientTokenType()

        type SpeedTokenType = class new() = {} end
        let speed = SpeedTokenType()

        type CurveTokenType = class new() = {} end
        let curve = CurveTokenType()

        type CurveRadiusTokenType = class new() = {} end
        let radius = CurveRadiusTokenType()
        
        type CurveAngleTokenType = class new() = {} end
        let angle = CurveAngleTokenType()

        let sectionRail = RailType.SectionRail
        let longWeldedRail = RailType.LongWeldedRail


        /////////////////// tractionCharacteristic

        /// <summary>Не задействована</summary>
        let NoneMode = LocomotiveTractionEngineModeType.None

        /// <summary>Последовательное возбуждение</summary>
        let S_Mode = LocomotiveTractionEngineModeType.S

        /// <summary>Последовательно-параллельное возбуждение</summary>
        let SP_Mode = LocomotiveTractionEngineModeType.SP

        /// <summary>Параллельное возбуждение</summary>
        let PP_Mode = LocomotiveTractionEngineModeType.PP

        /// <summary>Режим ослабления магнитного поля 1</summary>
        let OP1_Mode = LocomotiveTractionEngineModeType.OP1

        /// <summary>Режим ослабления магнитного поля 2</summary>
        let OP2_Mode = LocomotiveTractionEngineModeType.OP2

        type EngineModeTokenType = class new() = {} end
        let locomotiveEngineMode = EngineModeTokenType()

// ################################   TRAIN   ###############################################

        /////////////////// ключевое слово train

        let mutable _train : Train list = []

        // train "someTrain"
        let train (valueName : string)
            =
            let t = new Train(valueName)
            _train <- _train @ [t]
            t



        ///////////////////// ключевое слово stock

        let mutable _stock : Stock list = []

        // stock "someStock"
        let stock (valueName : string)
            =
            let s = new Stock(valueName)
            if _train.Length > 0 then _train.Head._stocks <- _train.Head._stocks @ [s]
            _stock <- _stock @ [s]
            s



        /////////////////// ключевое слово carriage

        let mutable _carriage : Carriage list = []


        // carriage "someCarriage" typeA OpenCarriage length 11.5<m> mass 10.1<t> withA axelNumber 4 onA RollerBearing withA brakingAxels 4 onA CompositeBrakeShoe
        // carriage "someCarriage"
        //     typeA  OpenCarriage
        //     length                         11.5<m>
        //     mass                           10.1<t>
        //     withA  axelNumber              4
        //     onA                            RollerBearing
        //     withA  brakingAxels            4
        //     onA                            CompositeBrakeShoe
        //     withA  brakingPressurePerAxel  90000.0<N>
        let carriage (valueName : string)
            (keyTypeA : TypeATokenType)                                                        (valueCarriageType : CarriageType)
            (keyLength : LengthTokenType)                                                      (valueLength : float<m>)
            (keyMass : MassTokenType)                                                          (valueMass : float<t>)
            (keyWithA : WithATokenType)   (keyAxelNumber : AxelNumberTokenType)                (valueAxels : int)
            (keyOnA : OnATokenType)                                                            (valueBearingType : BearingType)
            (keyWithAA : WithATokenType)  (keyBrakingAxels : BrakingAxelsTokenType)            (valueBrakingAxels : int)
            (keyOnAA : OnATokenType)                                                           (valueBrakeShoeType : BrakeShoeType)
            (keyWithAB : WithATokenType)  (keyBrakingPressurePerAxel : BrakingPressurePerAxelType)  (valueBrakingPressure : float<N>)
            =
            let car = new Carriage(valueName , valueCarriageType , valueLength , valueMass , valueAxels ,
                                 valueBearingType , valueBrakingAxels , valueBrakeShoeType , valueBrakingPressure)
            if _stock.Length > 0 then _stock.Head._carriages <- _stock.Head._carriages @ [car]
            _carriage <- _carriage @ [car]
            car



        /////////////////// ключевое слово locomotive

        let mutable _locomotive : Locomotive list = []

        

        // locomotive "2ТЭ116" typeA DieselElectricLocomotive length 18.15<m> mass 138.0<t> withA ratedSpeed (KmPerHourToMetrePerSec 24.2<km/hour>) ratedTractiveEffort 506000.0<N> fromA sectionNumber 2  withA axelNumber 6 withA axelLoad 226000.0<N>
        // locomotive "2ТЭ116"
        //     typeA                          DieselElectricLocomotive
        //     length                         18.15<m>
        //     mass                           138.0<t>
        //     withA ratedSpeed               (KmPerHourToMetrePerSec 24.2<km/hour>)
        //     ratedTractiveEffort            506000.0<N>
        //     fromA sectionNumber            2
        //     withA axelNumber               6
        //     withA axelLoad                 226000.0<N>
        //     withA  brakingAxels            4
        //     onA                            CompositeBrakeShoe
        //     withA  brakingPressurePerAxel  120000.0<N>
        let locomotive (valueName : string)
            (keyTypeA : TypeATokenType)                                                 (valueLocomotivePowerType : LocomotivePowerType)
            (keyLength : LengthTokenType)                                               (valueLength : float<m>)
            (keyMass : MassTokenType)                                                   (valueMass : float<t>)
            (keyWithA : WithATokenType)    (keyRatedSpeed : RatedSpeedTokenType)        (valueRatedSpeed : float<km/hour>)
            (keyRatedTractiveEffort : RatedTractiveEffortTokenType)                     (valueRatedTractiveEffort : float<N>)
            (keyFromA : FromATokenType)    (keySectionNumber : SectionNumberTokenType)  (valueSectionNumber : int)
            (keyWithAA : WithATokenType)   (keyAxelNumber : AxelNumberTokenType)        (valueAxelNumber : int)
            (keyWithAB : WithATokenType)   (keyAxelLoad : AxelLoadTokenType)            (valueAxelLoad : float<N>)
            (keyWithAC : WithATokenType)  (keyBrakingAxels : BrakingAxelsTokenType)            (valueBrakingAxels : int)
            (keyOnAA : OnATokenType)                                                           (valueBrakeShoeType : BrakeShoeType)
            (keyWithAD : WithATokenType)  (keyBrakingPressurePerAxel : BrakingPressurePerAxelType)  (valueBrakingPressure : float<N>)
            =
            let l = new Locomotive(valueName , valueLocomotivePowerType , valueLength , valueMass ,
                                   valueRatedSpeed , valueRatedTractiveEffort , valueSectionNumber ,
                                   valueAxelNumber , valueAxelLoad , valueBrakingAxels , valueBrakeShoeType , valueBrakingPressure)
            if _train.Length > 0 then _train.Head._locomotives <- _train.Head._locomotives @ [l]
            _locomotive <- _locomotive @ [l]
            l



        /////////////////// ключевое слово tractionCharacteristic

        let mutable _charactList : string list = []

        let tractionCharacteristic (valueName : string)
            =
            _charactList <- _charactList @ [valueName]
            valueName


        /////////////////// ключевое слово tractionCharacteristicRecord

        let mutable _charactRecordList : LocomotiveThrottlePositionRecordType list = []
        

        // tractionCharacteristicRecord forA speed 10.1<km/hour> withA locomotiveThrottlePosition S_Mode andA ratedTractiveEffort 120900.0<N>
        // tractionCharacteristicRecord
        //     forA speed 10.1<km/hour>
        //     withA locomotiveThrottlePosition S_Mode
        //     andA ratedTractiveEffort 120900.0<N>
        let tractionCharacteristicRecord
            (keyForA : ForATokenType)    (keySpeed : SpeedTokenType)                                            (valueSpeed : float<km/hour>)
            (keyInA : InATokenType)      (keyEngineMode : EngineModeTokenType)  (valueLocomotiveEngineMode : LocomotiveTractionEngineModeType)
            (keyWithA : WithATokenType)  (keyRatedTractiveEffort : RatedTractiveEffortTokenType)                (valueRatedTractiveEffort : float<N>)
            =
            let record : LocomotiveThrottlePositionRecordType =
                new LocomotiveThrottlePositionRecordType(valueSpeed , valueLocomotiveEngineMode , valueRatedTractiveEffort)
            if _locomotive.Length > 0 then _locomotive.Head._tractionCharacteristic <- _locomotive.Head._tractionCharacteristic
            _charactRecordList <- _charactRecordList @ [record]
            record


// ################################   TRACK   ###############################################

        /////////////////// ключевое слово track

        let mutable _track : Track list = []

        // track "someTrack"
        let track (valueName : string) =
            let t = new Track(valueName)
            _track <- _track @ [t]
            t



        /////////////////// ключевое слово section

        let mutable _trackSection : TrackSection list = []


        // section "someSection" length 1500.0<m> withA gradient 0.01 builtAs sectionRail forA speed 20.0<km/hour>
        // section "someSection"
        //     length 1500.0<m>
        //     withA gradient 0.01
        //     builtAs sectionRail
        //     forA speed 20.0<km/hour>
        let section (valueName : string)
            (keyLength : LengthTokenType)                                       (valueLength : float<m>)
            (keyWithA : WithATokenType)      (keyGradient : GradientTokenType)  (valueGradient : float)
            (keyBuiltAs : BuiltAsTokenType)                                     (valueRailType : RailType)
            (keyForA : ForATokenType)        (keySpeed : SpeedTokenType)        (valueSpeed : float<km/hour>)
            =
            let s = new TrackSection(valueName , valueLength , valueGradient , valueRailType , valueSpeed)
            if _track.Length > 0 then _track.Head._sections <- _track.Head._sections @ [s]
            _trackSection <- _trackSection @ [s]
            s


        // section "someSection" length 1500.0<m> withA gradient 0.01 builtAs longWeldedRail forA speed 20<km/hour> included curve length 700.0<m> withA radius 300.0<m>
        // section "someSection"
        //     length 1500.0<m>
        //     withA gradient 0.01
        //     builtAs longWeldedRail
        //     forA speed 20<km/hour>
        //     included curve
        //     length 700.0<m>
        //     withA radius 300.0<m>
        let sectionWithRadius (valueName : string)
            (keyLength : LengthTokenType)                                               (valueLength : float<m>)
            (keyWithA : WithATokenType)        (keyGradient : GradientTokenType)        (valueGradient : float)
            (keyBuiltAs : BuiltAsTokenType)                                             (valueRailType : RailType)
            (keyForA : ForATokenType)          (keySpeed : SpeedTokenType)              (valueSpeed : float<km/hour>)
            (keyIncluded : IncludedTokenType)  (keyCurve : CurveTokenType)
            (keyLengthA : LengthTokenType)                                              (valueCurveLength : float<m>)
            (keyWithAA : WithATokenType)       (keyCurveRadius : CurveRadiusTokenType)  (valueCurveRadius : float<m>)
            =
            let s = new TrackSection(valueName , valueLength , valueGradient , valueRailType , valueSpeed , valueCurveLength , valueCurveRadius)
            if _track.Length > 0 then _track.Head._sections <- _track.Head._sections @ [s]
            _trackSection <- _trackSection @ [s]
            s


        // section "someSection" length 1500.0<m> withA gradient 0.01 builtAs sectionRail forA speed 20<km/hour> included curve withA angle 20.0
        // section "someSection"
        //     length 1500.0<m>
        //     withA gradient 0.01
        //     builtAs sectionRail
        //     forA speed 20<km/hour>
        //     included curve
        //     withA angle 20.0
        let sectionWithAngle (valueName : string)
            (keyLength : LengthTokenType)                                         (valueLength : float<m>)
            (keyWithA : WithATokenType)        (keyGradient : GradientTokenType)  (valueGradient : float)
            (keyBuiltAs : BuiltAsTokenType)                                       (valueRailType : RailType)
            (keyForA : ForATokenType)          (keySpeed : SpeedTokenType)        (valueSpeed : float<km/hour>)
            (keyIncluded : IncludedTokenType)  (keyCurve : CurveTokenType)
            (keyWithAA : WithATokenType)       (keyAngle : CurveAngleTokenType)   (valueCurveAngle : float)
            =
            let s = new TrackSection(valueName , valueLength , valueGradient , valueRailType , valueSpeed , valueCurveAngle)
            if _track.Length > 0 then _track.Head._sections <- _track.Head._sections @ [s]
            _trackSection <- _trackSection @ [s]
            s

// ################################   SERVICE   ###############################################

        let private printTrackSectionProfileBase (section : TrackSection) (startPoint : float * float) =
            let plotName = section._name

            let sectionLength = section._length
            let sectionGradient = section._gradient / 1000.0

            let dx = fst startPoint + sqrt((sectionLength * sectionLength) / (1.0 + sectionGradient * sectionGradient) / 1.0<m^2>)
            let dy = snd startPoint + dx * sectionGradient
            let endPoint = (dx , dy)

            let plot = Chart.Line([ startPoint ; endPoint ] , Name = plotName)
            plot.WithXAxis(Title = "Длина, м" , Min = 0.0) |> ignore
            plot.WithYAxis(Title = "Высота, м") |> ignore
            plot.WithLegend(Title = "Track section" , InsideArea = false , Docking = ChartTypes.Docking.Bottom) |> ignore

            plot , endPoint
            


        let printTrackSectionProfile (sectionName : string) =
            let sectionOpt = _trackSection |> List.tryFind(fun x -> x._name = sectionName)
            let plotName = "Track section profile plot - " + sectionName
            if not sectionOpt.IsNone
            then 
                let section = sectionOpt.Value
                fst (printTrackSectionProfileBase section (0.0 , 0.0))
            else
                let plot = Chart.Line([ (0.0 , 0.0) ], Name = plotName , Title = "Section not found")
                plot.WithXAxis(Min = 0.0) |> ignore
                plot.WithYAxis(Min = 0.0) |> ignore
                plot


        let printTrackProfile (trackName : string) =
            let trackOpt = _track |> List.tryFind(fun x -> x._name = trackName)
            if not trackOpt.IsNone
            then
                let sections = trackOpt.Value._sections
                let startPoint = ref (0.0 , 0.0)
                let v = [for section in sections do
                            let p = printTrackSectionProfileBase section !startPoint
                            startPoint := snd p
                            yield fst p ]
                let plot = Chart.Combine(v)
                plot.WithXAxis(Title = "Длина, м" , Min = 0.0) |> ignore
                plot.WithYAxis(Title = "Высота, м") |> ignore
                plot.WithLegend(Title = "Профиль пути" , InsideArea = false , Docking = ChartTypes.Docking.Bottom) |> ignore
                plot
            else 
                let plot = Chart.Line([ (0.0 , 0.0) ], Name = "Track section profile plot - " , Title = "Section not found")
                plot.WithXAxis(Min = 0.0) |> ignore
                plot.WithYAxis(Min = 0.0) |> ignore
                plot






// ################################   CALC   ###############################################

        /////////////////// ключевое слово calculationTask

//        let mutable _calcTask : CalculationTask = Unchecked.defaultof<CalculationTask>
//
//        // calculationTask "task"
//        let calculationTask (valueName : string)
//            =
//            let ct = new CalculationTask(valueName)// , valueTrain , valueTrack)
//            ct._train <- _train.Head
//            ct._track <- _track.Head
//            _calcTask <- ct
//            _calcTask


        /////////////////// ключевое слово task1

        // task1 "task1"
        let task1 (valueName : string)
            =
            let t = new Task1(valueName , _locomotive.Head , _trackSection.Head)
            t._carriages <- Task1.StocksToMap [_stock.Head]
            t.StockMass


        /////////////////// ключевое слово task2

        // task2 "task2"
        let task2 (valueName : string)
            =
            let t = new Task2(valueName , _locomotive.Head , _track.Head)
            t
            //t.StockMass


        /////////////////// ключевое слово task3

        // task3 "task3"
        let task3 (valueName : string)
            =
            let t = new Task3(valueName , _train.Head , _trackSection.Head)
            t.StockGetawayResistanceCheck


        /////////////////// ключевое слово task4

        // task4 "task4" for length 1534.4<m>
        let task4 (valueName : string)
            (keyForA : ForATokenType) (keyLength : LengthTokenType) (length : float<m>)
            =
            let t = new Task4(valueName , _train.Head  , length)
            t.TrainLengthCheck


        /////////////////// ключевое слово task5

        // task5 "task5"
        let task5 (valueName : string)
            =
            let t = new Task5(valueName , _train.Head)
            t
            //t.StockMass

