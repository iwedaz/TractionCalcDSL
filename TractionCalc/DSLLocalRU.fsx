#load "MeasurementUnit.fs"
#load "Consts.fs"
#load "DSLDeclaration.fsx"

namespace TractionCalc

    open TractionCalc.MeasurementUnit
    open TractionCalc.Consts
    open TractionCalc.DSLDeclaration

    module DSLLocalRU =

        // слова-связки
        let и = andA
        let с = withA
        let для = forA
        let из = fromA
        let на = onA
        let в = inA
        let построенныйКак = builtAs
        let включающий = included
        let основанныйНа = basedOn
        let типа = typeA



        // единицы измерения
        [<Measure>]
        type кгс = kgs

        [<Measure>]
        type Н = N

        let кгсПреобрНьютоны = kgsToNewton
        let НьютоныПреобрКГС = NewtonToKGS

        [<Measure>]
        type т = t

        [<Measure>]
        type м = m

        [<Measure>]
        type км = km

        let кмПреобрМетры = KmToMetre
        let МетрыПреобрКм = MetreToKm


        [<Measure>]
        type сек = sec

        [<Measure>]
        type час = hour

        let часыПреобрСек = HourToSec
        let СекПреобрЧасы = SecToHour
        let кмВчасПреобрМетрыВсек = KmPerHourToMetrePerSec
        let метрыВсекПреобрКмВчас = MetrePerSecToKmPerHour




        // ключевые слова

        let поезд = train

        let состав = stock

        // вагон
        let вагон = carriage

        let пассажирскийВагон = PassengerCarriage
        let полувагон = OpenCarriage
        let крытыйВагон = СoveredCarriage
        let платформа = FlatCarriage
        let цистерна = TankCarriage

        let подшиникахКачения = RollerBearing
        let подшипникахСкольжения = SliderBearing

        let чугунныхКолодках = CastIronFromPlainMaterialBrakeShoe
        let чугунныхВысокофосфористыхКолодках = CastIronWithHighPhosphorusBrakeShoe
        let чугунныхС3ПроцентамиФосфораКолодках = CastIronWith3PercentPhosphorusBrakeShoe
        let композитных8166Колодках = Composite8166BrakeShoe
        let композитных328303Колодках = Composite328303BrakeShoe

        let массой = mass
        let числомОсей = axelNumber
        let числомТормозныхОсей = brakingAxels
        let нажатиемНаОсь = brakingPressurePerAxel


        // локомотив
        let локомотив = locomotive

        let дизельныйЛокомотив = DieselLocomotive
        let электрическийЛокомотив = ElectricLocomotive
        let дизельЭлектрическийЛокомотив = DieselElectricLocomotive

        let расчетнойСкоростью = ratedSpeed
        let расчетнойСилойТяги = ratedTractiveEffort
        let колиствоСекций = sectionNumber
        let осевойНагрузкой = axelLoad

        let режимеТяговыхДвигателей = locomotiveEngineMode
        let безРежима = NoneMode
        let С_Режим = S_Mode
        let СП_Режим = SP_Mode
        let ПП_Режим = PP_Mode
        let ОП1_Режим = OP1_Mode
        let ОП2_Режим = OP2_Mode

        let тяговаяХарактеристика = tractionCharacteristic
        let отсчетТяговойХарактеристики = tractionCharacteristicRecord


        let путь = track


        // участок пути
        let участокПути = section
        let участокПутиСКривойПоРадиусу = sectionWithRadius
        let участокПутиСКривойПоУглу = sectionWithAngle
        
        let длиной = length
        let уклоном = gradient
        let скорости = speed

        let кривую = curve
        let радиусом = radius
        let уголом = angle

        let звеньевойПуть = sectionRail
        let бестыковойПуть = longWeldedRail

        // задачи
        let задача1 = task1
        let задача2 = task2
        let задача3 = task3
        let задача4 = task4
        let задача5 = task5
//        let задача6 = task6
//        let задача7 = task7
//        let задача8 = task8


        //
        let отобразитьУчастокПути = printTrackSectionProfile
        let отобразитьПрофильПути = printTrackProfile
