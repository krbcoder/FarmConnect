coldroom.services.climateZones = coldroom.services.climateZones || {};

coldroom.services.climateZones.selectInfoByZoneId = function (zoneId, onSuccess, onError) {
    var url = "/api/climateZones/" + zoneId;
    var settings = {
        cache: false,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "get"
    };
    $.ajax(url, settings);
};