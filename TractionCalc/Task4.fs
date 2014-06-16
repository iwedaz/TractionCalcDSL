namespace TractionCalc

    open TractionCalc.MeasurementUnit
    open TractionCalc.Consts
    open TractionCalc.Carriage
    open TractionCalc.Stock
    open TractionCalc.Locomotive
    open TractionCalc.Train
    open TractionCalc.TrackSection
    open TractionCalc.Track

    open System.Collections.Generic;


    module Task4 =

        /// <summary>
        /// Расчёт длины состава по длинне приёмо-отправочных путей
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        type Task4 = class
            val _name : string
            val _train : Train
            val _length : float<m>


            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="name">Имя задания</param>
            /// <param name="train">Поезд</param>
            /// <param name="length">Длинна приёмо-отправочных путей, Lпр, м</param>
            new (name , train , length) =
                {
                    _name = name
                    _train = train
                    _length = length
                }


            /// <summary>
            /// Проверка длины поезда по длине приёмо-отправочных путей
            /// </summary>
            member this.TrainLengthCheck : bool =
                let carsLength = this._train._stocks |> List.sumBy(fun s -> s._carriages |> List.sumBy(fun c -> c._length))
                let locosLength = this._train._locomotives |> List.sumBy(fun l -> l._length)
                let trainLength = carsLength + locosLength + 10.0<m>
                if this._length >= trainLength
                then true
                else false

        end

