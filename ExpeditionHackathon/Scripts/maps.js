var weatherStationLocs = [
    {
        id:1 , title: "Agadir", lat: 30.317, lng: -9.4
    },
    {
        id:2 ,title: "BeniMellal", lat: 32.366, lng: -6.4
    },
    {
        id:3 ,title: "FesSais", lat: 33.933, lng: -4.983
    },
    {
        id:4 ,title: "Marrackech", lat: 31.617, lng: -8.032
    },
    {
        id:5 ,title: "Meknes", lat: 33.883, lng: -5.533
    },
    {
        id:6 ,title: "NadorArwi", lat: 34.983, lng: -3.017
    },
    {
        id:7 ,title: "Nouasser", lat: 33.367, lng: -7.583
    },
    {
        id:8 ,title: "Safi", lat: 32.283, lng: -9.233
    },
    {
        id:9 ,title: "Tanger", lat: 35.733, lng: -5.9
    }
]

var map;
stationMarkersArray = [];

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 6,
        center: new google.maps.LatLng(31.947624, -6.451068),
        mapTypeId: 'terrain'
    });
    setWeatherStationMarkers();
}

function setWeatherStationMarkers() {
    for (var i = 0; i < weatherStationLocs.length; i++) {
        var coords = weatherStationLocs[i];
        var latLng = new google.maps.LatLng(coords.lat, coords.lng);
        var marker = new google.maps.Marker({
            position: latLng,
            map: map,
            title: coords.title
        });
        stationMarkersArray.push(marker);
    }
}


