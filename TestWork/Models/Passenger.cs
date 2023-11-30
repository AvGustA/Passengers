using System;
using System.Text.Json.Serialization;
using System.Windows.Markup;

namespace TestWork.Models
{
    class Passenger
    {
        /// <summary>
        /// Номер рейса
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        /// ФИО пассажира
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Время отправки самолёта
        /// </summary>
        public DateTime DepartureTime { get; set; }
    }
}
