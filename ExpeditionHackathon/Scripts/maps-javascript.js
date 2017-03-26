$(document).ready(function () {
    console.log("ready!");
    initMap();
    findClosestWeatherStation();
    $("#map").on("click", coldroom.page.render)
});


var weatherStationLocs = [
    {
        id: 1, title: "Agadir", lat: 30.317, lng: -9.4, climateZone:6001
    },
    {
        id: 2, title: "BeniMellal", lat: 32.366, lng: -6.4, climateZone:6102
    },
    {
        id: 3, title: "FesSais", lat: 33.933, lng: -4.983, climateZone:6102
    },
    {
        id: 4, title: "Marrackech", lat: 31.617, lng: -8.032, climateZone:6002
    },
    {
        id: 5, title: "Meknes", lat: 33.883, lng: -5.533, climateZone:6202
    },
    {
        id: 6, title: "NadorArwi", lat: 34.983, lng: -3.017, climateZone:6002
    },
    {
        id: 7, title: "Nouasser", lat: 33.367, lng: -7.583, climateZone:6102
    },
    {
        id: 8, title: "Safi", lat: 32.283, lng: -9.233, climateZone:6102
    },
    {
        id: 9, title: "Tanger", lat: 35.733, lng: -5.9, climateZone:6502
    }
]

var map;
var stationMarkersArray = [];
var markersArray = [];
var initialMarkerArray = [];

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 6,
        center: new google.maps.LatLng(31.947624, -6.451068),
        mapTypeId: 'terrain'
    });
    setWeatherStationMarkers();
    setInitialMarker();

    function setInitialMarker() {
        var latLng = new google.maps.LatLng(coldroom.page.userLat, coldroom.page.userLng);
        var marker = new google.maps.Marker({
            position: latLng,
            map: map,
            title: "Your location",
            opacity: 1
        });
        initialMarkerArray.push(marker);
    }


    google.maps.event.addListener(map, "click", function (event) {
        // place a marker
        placeMarker(event.latLng);

        // display the lat/lng in your form's lat/lng fields
        coldroom.page.userLat = event.latLng.lat();
        coldroom.page.userLng = event.latLng.lng();
        findClosestWeatherStation();
    });

    function placeMarker(location) {
        initialMarkerArray[0].setMap(null);
        // first remove all markers if there are any
        deleteOverlays();

        var marker = new google.maps.Marker({
            position: location,
            map: map
        });

        // add marker in markers array
        markersArray.push(marker);

        //map.setCenter(location);
    }

    // Deletes all markers in the array by removing references to them
    function deleteOverlays() {
        if (markersArray ) {
            for (i in markersArray) {
                markersArray[i].setMap(null);
            }
            markersArray.length = 0;
        }
    }


}



function setWeatherStationMarkers() {
    for (var i = 0; i < weatherStationLocs.length; i++) {
        var coords = weatherStationLocs[i];
        var latLng = new google.maps.LatLng(coords.lat, coords.lng);
        var marker = new google.maps.Marker({
            position: latLng,
            map: map,
            title: coords.title,
            id: coords.id,
            climateZone: coords.climateZone,
            opacity:0
        });
        stationMarkersArray.push(marker);
    }
}






coldroom.page.userClosestWeatherStationId = null;

/*
Haversine Formula
*/
function rad(x) { return x * Math.PI / 180; }

var findClosestWeatherStation = function () {
    var lat = coldroom.page.userLat;
    var lng = coldroom.page.userLng;
    var latLng = new google.maps.LatLng(lat, lng);

    var R = 6371; // radius of earth in km
    var distances = [];
    var closest = -1;
    for (i = 0; i < stationMarkersArray.length; i++) {
        var mlat = stationMarkersArray[i].position.lat();
        var mlng = stationMarkersArray[i].position.lng();
        var dLat = rad(mlat - lat);
        var dLong = rad(mlng - lng);
        var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
            Math.cos(rad(lat)) * Math.cos(rad(lat)) * Math.sin(dLong / 2) * Math.sin(dLong / 2);
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        var d = R * c;
        distances[i] = d;
        if (closest == -1 || d < distances[closest]) {
            closest = i;
        }
    }

    coldroom.page.userClosestWeatherStationId = stationMarkersArray[closest].id;
    coldroom.page.userClimateZoneId = stationMarkersArray[closest].climateZone;

    console.log("users closest weather station id is " + coldroom.page.userClosestWeatherStationId);
    console.log("users climate zone id is " + coldroom.page.userClimateZoneId);

    coldroom.page.render();
};


