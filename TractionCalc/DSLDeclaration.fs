//#load "Consts.fs"
//#load "MeasurementUnit.fs"
//#load "Carriage.fs"
//#load "Stock.fs"
//#load "Locomotive.fs"
//#load "Train.fs"
//#load "TrackSection.fs"
//#load "Track.fs"
//#load "Task1.fs"
//#load "Task2.fs"
//#load "Task3.fs"
//#load "Task4.fs"
//#load "Task5.fs"
//#load "CalculationTask.fs"

namespace TractionCalc

    open TractionCalc.Consts
    open TractionCalc.MeasurementUnit
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

    module DSLDeclaration =

// ################################   TRAIN   ############################################### 
        
        /////////////////// ключевое слово train

        let mutable _train : Train list = []

        // train "someTrain"
        let train (valueName : string) =
            let t = new Train(valueName)
            //_calcTask._train <- t
            _train <- t :: _train
            t



        ///////////////////// ключевое слово stock

        let mutable _stock : Stock list = []

        // stock "someStock"
        let stock (valueName : string) =
            let s = new Stock(valueName)
            _train.Head._stocks <- s :: _train.Head._stocks
            _stock <- s :: _stock
            s



        /////////////////// ключевое слово carriage

        let mutable _carriage : Carriage list = []

        let PassengerCarriage = CarriageType.PassengerCarriage      // пассажирский
        let OpenCarriage = CarriageType.OpenCarriage                // полувагон
        let СoveredCarriage = CarriageType.СoveredCarriage          // крытый
        let FlatCarriage = CarriageType.FlatCarriage                // платформа
        let TankCarriage = CarriageType.TankCarriage                // цистерна

        let RollerBearing = BearingType.RollerBearing               // подшипник качения (роликовый)
        let SliderBearing = BearingType.SliderBearing               // подшипник скольжения

        let CastIronBrakeShoe = BrakeShoeType.CastIronBrakeShoe     // чугунная колодка
        let CompositeBrakeShoe = BrakeShoeType.CompositeBrakeShoe   // композитная колодка

        let mass = TokenConstCarriage
        let axelNumber = TokenConstCarriage
        let brakingAxels = TokenConstCarriage

        
        // carriage "someCarriage" typeA OpenCarriage length 11.5<m> mass 10.1<t> withA axelNumber 4 onA RollerBearing withA brakingAxels 4 onA CompositeBrakeShoe
        let carriage (valueName : string)
            keyTypeA (valueCarriageType : CarriageType)
            keyLength (valueLength : float<m>)
            keyMass (valueMass : float<t>)
            (keyWithA : WithAType) keyAxelNumber (valueAxels : int)
            keyOnA (valueBearingType : BearingType)
            (keyWithAA : WithAType) keyBrakingAxels (valueBrakingAxels : int)
            keyOnAA (valueBrakeShoeType : BrakeShoeType)
            = 
            let c = new Carriage(valueName , valueCarriageType , valueLength , valueMass ,
                                 valueAxels , valueBearingType , valueBrakingAxels , valueBrakeShoeType)
            _stock.Head._carriages <- c :: _stock.Head._carriages
            _carriage <- c :: _carriage
            c



        /////////////////// ключевое слово locomotive

        let mutable _locomotive : Locomotive list = []

        let DieselPower = LocomotivePowerType.DieselPower
        let ElectricPower = LocomotivePowerType.ElectricPower
        let DieselElectricPower = LocomotivePowerType.DieselElectricPower

        let ratedSpeed = TokenConstLocomotive
        let ratedTractiveEffort = TokenConstLocomotive
        let sectionNumber = TokenConstLocomotive
        let axelLoad = TokenConstLocomotive

        // locomotive "2ТЭ116" typeA DieselElectricPower length 18.15<m> mass 138.0<t> withA ratedSpeed (KmPerHourToMetrePerSec 24.2<km/hour>) ratedTractiveEffort 248<N> fromA sectionNumber 2  withA axelNumber 6 withA axelLoad 226000.0<N>
        let locomotive (valueName : string)
            keyTypeA (valueLocomotivePowerType : LocomotivePowerType)
            keyLength (valueLength : float<m>)
            keyMass (valueMass : float<t>)
            (keyWithA : WithAType) keyRatedSpeed (valueRatedSpeed : float<m/sec>)
            keyRatedTractiveEffort (valueRatedTractiveEffort : float<N>)
            keyFromA keySectionNumber (valueSectionNumber : int)
            (keyWithAA : WithAType) keyAxelNumber (valueAxelNumber : int)
            (keyWithAB : WithAType) keyAxelLoad (valueAxelLoad : float<N>)
            = 
            let l = new Locomotive(valueName , valueLocomotivePowerType , valueLength , valueMass ,
                                     valueRatedSpeed , valueRatedTractiveEffort , valueSectionNumber , valueAxelNumber , valueAxelLoad)
            _train.Head._locomotives <- l :: _train.Head._locomotives
            _locomotive <- l :: _locomotive
            l



// ################################   TRACK   ############################################### 
        
        /////////////////// ключевое слово track

        let mutable _track : Track list = []

        // track "someTrack"
        let track (valueName : string) =
            let t = new Track(valueName)
            //_calcTask._track <- t
            _track <- t :: _track
            t



        /////////////////// ключевое слово section

        let mutable _trackSection : TrackSection list = []

        let length = TokenConstTrackSection
        let gradient = TokenConstTrackSection
        let speed = TokenConstTrackSection

        let curve = TokenConstTrackSection
        let radius = TokenConstTrackSection
        let angle = TokenConstTrackSection

        let sectionRail = RailType.SectionRail
        let longWeldedRail = RailType.LongWeldedRail


        // section "someSection" length 1500.0<m> withA gradient 0.01 builtAs sectionRail forA speed 20.0<m/sec>
        let section (valueName : string)
            keyLength (valueLength : float<m>)
            (keyWithA : WithAType) keyGradient (valueGradient : float)
            keyBuiltAs (valueRailType : RailType)
            keyForA keySpeed (valueSpeed : float<m/sec>)
            = 
            let s = new TrackSection(valueName , valueLength , valueGradient , valueRailType , valueSpeed)
            _track.Head._sections <- s :: _track.Head._sections
            _trackSection <- s :: _trackSection
            s


        // section "someSection" length 1500.0<m> withA gradient 0.01 builtAs longWeldedRail forA speed 20<m/sec> included curve length 700.0<m> withA radius 300.0<m>
        let sectionWithRadius (valueName : string)
            keyLength (valueLength : float<m>)
            (keyWithA : WithAType) keyGradient (valueGradient : float)
            keyBuiltAs (valueRailType : RailType)
            keyForA keySpeed (valueSpeed : float<m/sec>)
            keyIncluded keyCurve keyLengthA (valueCurveLength : float<m>)
            (keyWithAA : WithAType) keyCurveRadius (valueCurveRadius : float<m>)
            = 
            let s = new TrackSection(valueName , valueLength , valueGradient , valueRailType , valueSpeed , valueCurveLength , valueCurveRadius)
            _track.Head._sections <- s :: _track.Head._sections
            _trackSection <- s :: _trackSection
            s


        // section "someSection" length 1500.0<m> withA gradient 0.01 builtAs sectionRail forA speed 20<m/sec> included curve withA angle 20.0
        let sectionWithAngle (valueName : string)
            keyLength (valueLength : float<m>)
            (keyWithA : WithAType) keyGradient (valueGradient : float)
            keyBuiltAs (valueRailType : RailType)
            keyForA keySpeed (valueSpeed : float<m/sec>) 
            keyIncluded keyCurve (keyWithAA : WithAType) keyAngle (valueCurveAngle : float)
            = 
            let s = new TrackSection(valueName , valueLength , valueGradient , valueRailType , valueSpeed , valueCurveAngle)
            _track.Head._sections <- s :: _track.Head._sections
            _trackSection <- s :: _trackSection
            s



// ################################   CALC   ############################################### 

        /////////////////// ключевое слово calculationTask

        let mutable _calcTask : CalculationTask = Unchecked.defaultof<CalculationTask>

        // calculationTask "task"
        let calculationTask (valueName : string)
            = 
            let ct = new CalculationTask(valueName)// , valueTrain , valueTrack)
            ct._train <- _train.Head
            ct._track <- _track.Head
            _calcTask <- ct
            _calcTask


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
            (keyForA : ForAType) keyLength (length : float<m>)
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


        let runTask (task : CalculationTask) =
            printfn("task done")