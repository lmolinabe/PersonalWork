﻿angularFormsApp.controller('dashboardController',
    ["$scope", "$window", "$routeParams", "DataService",
    function dashboardController($scope, $window, $routeParams, DataService) {
        DataService.getRoomBookings().then(
                function (results) {
                    //on success
                    $scope.roomBookings = results.data;
                },
                function (results) {
                    //on error
                });;
    }]);