var angularFormsApp = angular.module('angularFormsApp', ['ngRoute', 'ui.bootstrap']);

//Routing configuration
angularFormsApp.config(
    ["$routeProvider", "$locationProvider",
    function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/home', {
            templateUrl: 'app/Home.html',
            controller: 'homeController'
        })
        .when('/newRoomBookingForm', {
            templateUrl: 'app/RoomBookingForm/RoomBookingTemplate.html',
            controller: 'roomBookingController'
        })
        .when('/updateRoomBookingForm/:id', {
            templateUrl: 'app/RoomBookingForm/RoomBookingTemplate.html',
            controller: 'roomBookingController'
        })
        .otherwise({
            redirectTo: '/home'
        })
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);

//Add create a specific folder and controller for this
angularFormsApp.controller('homeController',
    ["$scope", "$location", "$uibModal", "DataService",
    function ($scope, $location, $uibModal, DataService) {

        DataService.getRoomBookings().then(function (results) {
            var data = results.data;
        });

        $scope.showCreateRoomBookingForm = function () {
            //$location.path('/newRoomBookingForm');

            $uibModal.open({
                templateUrl: 'app/RoomBookingForm/RoomBookingTemplate.html',
                controller: 'roomBookingController',
                resolve: {
                    Parameters: function () {
                        return { RoomBookingId: 0 };
                    }
                }
            });

        };

        $scope.showUpdateRoomBookingForm = function (id) {
            //$location.path('/updateRoomBookingForm/' + id);

            $uibModal.open({
                templateUrl: 'app/RoomBookingForm/RoomBookingTemplate.html',
                controller: 'roomBookingController',
                resolve: {
                    Parameters: function () {
                        return { RoomBookingId: id };
                    }
                }
            });
        };

    }]);