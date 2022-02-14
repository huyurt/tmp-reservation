using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reservation.Shared.Models
{
    public class TrainModel
    {
        public TrainModel()
        {
            Wagons = new HashSet<WagonModel>();
        }

        [JsonPropertyName("Ad")]
        public string Title { get; set; }

        [JsonPropertyName("Vagonlar")]
        public ICollection<WagonModel> Wagons { get; set; }
    }
}
