export function getCoordinates () {
    return new Promise(function(resolve, reject) {
        navigator.geolocation.getCurrentPosition(resolve, reject);
    });
}

export async function getCurrentPosition () {
    if ("geolocation" in navigator) {
        const position = await this.getCoordinates();
        if (position && position.coords) {
            console.log(position.coords);
            var coords = {
                accuracy: position.coords.accuracy,
                latitude: position.coords.latitude,
                longitude: position.coords.longitude
            };
            return coords;
        }
    }
}