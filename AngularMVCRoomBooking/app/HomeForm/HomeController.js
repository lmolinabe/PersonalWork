//Add create a specific folder and controller for this
angularFormsApp.controller('homeController',
    ["$scope", "$location", "$uibModal", "DataService",
    function ($scope, $location, $uibModal, DataService) {

        $scope.showCreateRoomBookingForm = function () {
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