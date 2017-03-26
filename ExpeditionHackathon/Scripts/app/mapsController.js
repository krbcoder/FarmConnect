(function () {

    "use strict"

    angular.module("app").controller("mapsController", MapsController);

    MapsController.$inject = ["$log", "$scope"];

    function MapsController($log, $scope) {

        var vm = this;

        vm.$scope = $scope;

        vm.climateZoneInfo = null;

        coldroom.page.selectInfoByZoneId = function (zoneId, onSuccess, onError) {
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


        coldroom.page.render = function() {
            getZoneInfo();
        };

        coldroom.page.render();


        function getZoneInfo() {
            coldroom.page.selectInfoByZoneId(coldroom.page.userClimateZoneId, displayZoneInfo, ajaxError);
            console.log(coldroom.page.userClimateZoneId)
        };

        function displayZoneInfo(data) {
            vm.$scope.$apply(function () {
          
               vm.climateZoneInfo = data.Items[0];

            })
        }

        function ajaxError(jqxhr) {
            console.log(jqxhr)
        }
    }

}());