namespace TractionCalc

    module MeasurementUnit =

        /// <summary> Килограмм*Сила - единица измерения </summary>
        [<Measure>]
        type kgs

        /// <summary> Ньютон - единица измерения </summary>
        [<Measure>]
        type N

        /// <summary> Функция приведения кгс в Ньютоны </summary>
        /// <param name="kgsValue">Величина в кгс</param>
        let kgsToNewton (kgsValue : float<kgs>) : float<N> = 9.80665<N/kgs> * kgsValue

        /// <summary> Функция приведения Ньютоны в кгс </summary>
        /// <param name="newtonValue">Величина в Ньютонах</param>
        let NewtonToKGS (newtonValue : float<N>) : float<kgs> = newtonValue / 9.80665<N/kgs>

        /// <summary> Тонна - единица измерения </summary>
        [<Measure>]
        type t


//        [<Measure>]
//        type deg


        /// <summary> Метр - единица измерения </summary>
        [<Measure>]
        type m


        /// <summary> Километр - единица измерения </summary>
        [<Measure>]
        type km

        /// <summary> Функция приведения километров в метры </summary>
        /// <param name="kilometreValue"> Величина в километрах </param>
        let KmToMetre (kilometreValue : float<km>) : float<m> = 1000.0<m/km> * kilometreValue


        /// <summary> Функция приведения метров в километры </summary>
        /// <param name="metreValue"> Величина в метрах </param>
        let MetreToKm (metreValue : float<m>) : float<km>  = 0.001<km/m> * metreValue


        /// <summary> Секунда - единица измерения </summary>
        [<Measure>]
        type sec


        /// <summary> Час - единица измерения </summary>
        [<Measure>]
        type hour


        /// <summary> Функция приведения часов в секунда </summary>
        /// <param name="hourValue"> Величина в часах </param>
        let HourToSec (hourValue : float<hour>) : float<sec> = 3600.0<sec/hour> * hourValue


        /// <summary> Функция приведения секунд в часы </summary>
        /// <param name="secValue"> Величина в секундах </param>
        let SecToHour (secValue : float<sec>) : float<hour> = secValue / (3600.0<sec/hour>)


        /// <summary> Функция приведения километров/час в метры/секунду </summary>
        /// <param name="kmPerHourValue"> Величина в км/ч </param>
        let KmPerHourToMetrePerSec (kmPerHourValue : float<km/hour>) : float<m/sec> = kmPerHourValue * 1000.0<m/km> / (3600.0<sec/hour>)


        /// <summary> Функция приведения метров/секунду в километры/час </summary>
        /// <param name="metrePersecValue"> Величина в м/с </param>
        let MetrePerSecToKmPerHour (metrePersecValue : float<m/sec>) : float<km/hour> = metrePersecValue * 0.001<km/m> * 3600.0<sec/hour>
