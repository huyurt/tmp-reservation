using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Reservation.Shared.Models
{
    public class CheckReservationOutputModel
    {
        public CheckReservationOutputModel()
        {
            CheckReservations = new HashSet<CheckReservationDtoModel>();
        }

        [JsonPropertyName("RezervasyonYapilabilir")]
        public bool IsReservationPossible { get { return CheckReservations?.Any() ?? false; } }

        [JsonPropertyName("YerlesimAyrinti")]
        public ICollection<CheckReservationDtoModel> CheckReservations { get; set; }
    }
}
