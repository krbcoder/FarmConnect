coldroom.services.weatherStationCrops = coldroom.services.weatherStationCrops || {};

coldroom.services.weatherStationCrops.getYield = function (weatherStation, crop, onSuccess, onError) {
    var url = "/api/weatherStationCrops/yield?WeatherStation=" + weatherStation + "&Crop=" + crop;
    var settings = {
        cache: false,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "get"
    };
    $.ajax(url, settings);
};

coldroom.services.weatherStationCrops.getYields = function (zoneId, cropId, onSuccess, onError) {
    var url = "/api/weatherStationCrops/yields?zoneId=" + zoneId + "&Cropid=" + cropId;
    var settings = {
        cache: false,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "get"
    };
    $.ajax(url, settings);
};