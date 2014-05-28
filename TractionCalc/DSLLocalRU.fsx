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
        let построенныйКак = builtAs
        let включающий = included
        let основанныйНа = basedOn
        let типа = typeA



        // единицы измерения
        [<Measure>]
        type Н = N

        [<Measure>]
        type т = t

        [<Measure>]
        type м = m

        [<Measure>]
        type км = km

        [<Measure>]
        type сек = sec

        [<Measure>]
        type час = hour



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

        let подшиникиКачения = RollerBearing
        let подшипникиСкольжения = SliderBearing

        let чугуннаяКолодка = CastIronBrakeShoe
        let композитнаяКолодка = CompositeBrakeShoe

        let масса = mass
        let числоОсей = axelNumber
        let числоТормозныхОсей = brakingAxels


        // локомотив
        let локомотив = locomotive

        let дизельныйЛокомотив = DieselLocomotive
        let электрическийЛокомотив = ElectricLocomotive
        let дизельЭлектрическийЛокомотив = DieselElectricLocomotive

        let расчетнаяСкорость = ratedSpeed
        let расчетнаяСилаТяги = ratedTractiveEffort
        let колиствоСекций = sectionNumber
        let осеваяНагрузка = axelLoad

        let безПозиции = NonePosition
        let Спозиция = S_Position
        let СПпозиция = SP_Position
        let ППпозиция = PP_Position
        let ОП1позиция = OP1_Position
        let ОП2позиция = OP2_Position

        let тяговаяХарактеристика = tractionCharacteristic
        let ОтсчетТяговойХарактеристики = tractionCharacteristicRecord


        let путь = track


        // участок пути
        let участокПути = section
        
        let длина = length
        let уклон = gradient
        let скорость = speed

        let кривая = curve
        let радиус = radius
        let угол = angle

        let звеньевойПуть = sectionRail
        let бестыковойПуть = longWeldedRail



        let расчетноеЗадание = calculationTask
        let задача1 = task1
        let задача2 = task2
        let задача3 = task3
        let задача4 = task4
        let задача5 = task5

