export function getCoordinates (enableHighAccuracy, timeout, maximumAge) {
    var options = {
        enableHighAccuracy: enableHighAccuracy,
        timeout: timeout,
        maximumAge: maximumAge
    };

    return new Promise(function(resolve, reject) {
        navigator.geolocation.getCurrentPosition(resolve, reject, options);
    });
}

export async function getCurrentPosition (enableHighAccuracy, timeout, maximumAge) {
    var coords;

    if ("geolocation" in navigator) {
        try {
            const position = await this.getCoordinates(enableHighAccuracy, timeout, maximumAge);
            if (position && position.coords) {
                console.log(position.coords);
                coords = {
                    Accuracy: position.coords.accuracy,
                    Latitude: position.coords.latitude,
                    Longitude: position.coords.longitude,
                    Altitude: position.coords.altitude,
                    AltitudeAccuracy: position.coords.altitudeAccuracy,
                    Heading: position.coords.heading,
                    Speed: position.coords.speed
                };
            }
        }
        catch (e) {
            console.error(e);
            coords = {
                ErrorCode: e.code,
                ErrorMessage: e.message
            };
        }
    }
    return coords;
}