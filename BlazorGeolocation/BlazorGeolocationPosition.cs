using System;

namespace BlazorGeolocation
{
    public class BlazorGeolocationPosition
    {
        public Double? Accuracy {get; set; }
        public Double? Latitude {get; set; }
        public Double? Longitude {get; set; }
        public Double? Altitude {get; set; }
        public Double? AltitudeAccuracy {get; set; }
        public Double? Heading {get; set; }
        public Double? Speed {get; set; }
        public int? ErrorCode {get; set; }
        public string ErrorMessage {get; set; }
    }
}