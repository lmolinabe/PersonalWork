//Routing configuration
angularFormsApp.config(
    ["$routeProvider", "$locationProvider",
    function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/home', {
                templateUrl: 'app/Views/Home.html',
                controller: 'homeController'
            })
            .when('/dashboard', {
                templateUrl: 'app/Views/Dashboard.html',
                controller: 'dashboardController'
            })
            .when('/newRoomBookingForm', {
                templateUrl: 'app/Views/RoomBookingTemplate.html',
                controller: 'roomBookingController'
            })
            .when('/updateRoomBookingForm/:id', {
                templateUrl: 'app/Views/RoomBookingTemplate.html',
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