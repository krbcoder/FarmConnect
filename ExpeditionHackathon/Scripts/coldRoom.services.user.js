coldroom.services.user = coldroom.services.user || {};

coldroom.services.user.getNeighbors = function (weatherStation, onSuccess, onError) {
    var url = "/api/users/neighbors?WeatherStation=" + weatherStation;
    var settings = {
        cache: false,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "get"
    };
    $.ajax(url, settings);
};

coldroom.services.user.getSimilarUsers = function (crop, zone, onSuccess, onError) {
    var url = "/api/users/similarusers?Crop=" + crop + "&Zone=" + zone;
    var settings = {
        cache: false,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "get"
    };
    $.ajax(url, settings);
};
