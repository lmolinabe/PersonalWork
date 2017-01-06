//Routing configuration
angularFormsApp.config(
    ["$routeProvider", "$locationProvider",
    function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/home', {
                templateUrl: 'app/Home.html',
                controller: 'homeController'
            })
            .when('/dashboard', {
                templateUrl: 'app/Dashboard.html',
                controller: 'dashboardController'
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