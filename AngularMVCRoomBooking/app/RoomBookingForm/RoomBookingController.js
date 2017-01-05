angularFormsApp.controller('roomBookingController',
    ["$scope", "$window", "$routeParams", "$uibModalInstance", "DataService", "Parameters",
    function roomBookingController($scope, $window, $routeParams, $uibModalInstance, DataService, Parameters) {

        if (Parameters.RoomBookingId > 0) {
            DataService.getRoomBooking(Parameters.RoomBookingId).then(
            function (results) {
                //on success
                $scope.roomBooking = results.data;
                //Recreate the date fields (this is necesary to fix the uib-datepicker-popup format)
                $scope.roomBooking.StartDate = new Date($scope.roomBooking.StartDate);
                $scope.roomBooking.EndDate = new Date($scope.roomBooking.EndDate);
                $scope.editableRoomBooking = angular.copy($scope.roomBooking);
            },
            function (results) {
                //on error
                var test = 1;
            });
        }
        else {
            $scope.roomBooking = { };
        }

        $scope.rooms = [
            { value: 1, label: 101 },
            { value: 2, label: 102 }
        ];

        $scope.bookingStatuses = [
            { value: 1, label: 'Free' },
            { value: 2, label: 'Reserved' }
        ];

        $scope.paymentStatuses = [
            { value: 1, label: 'Paid' },
            { value: 2, label: 'Advance' }
        ];

        $scope.paymentStatuses = [
            { value: 1, label: 'Single' },
            { value: 2, label: 'Double' }
        ];

        
        $scope.popupStartDate = {
            opened: false
        };

        $scope.popupEndDate = {
            opened: false
        };
        
        $scope.openStartDatePicker = function () {
            $scope.popupStartDate.opened = true;
        };

        $scope.openEndDatePicker = function () {
            $scope.popupEndDate.opened = true;
        };

        $scope.dateOptions = {
            formatYear: 'yy',
            maxDate: new Date(2025, 5, 22),
            minDate: new Date(),
            startingDay: 1,
            showWeeks: false
        };

        // Disable weekend selection
        function disabled(data) {
            var date = data.date,
              mode = data.mode;
            return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
        }

        $scope.submitForm = function () {

            $scope.submitted = true;

            if ($scope.roomBookingForm.$invalid) {
                return;
            }
            
            if ($scope.editableRoomBooking.Id == 0) {
                //insert new RoomBooking
                DataService.insertRoomBooking($scope.editableRoomBooking).then(
                    function (results) {
                        //on success
                        $scope.roomBooking = angular.copy($scope.editableRoomBooking);
                        $scope.roomBooking.Id = results.data.Id;
                        $uibModalInstance.close();
                    },
                    function (results) {
                        //on error
                        $scope.hasFormError = true;
                        $scope.formErrors = results.statusText;
                    });
            }
            else {
                //update the RoomBooking
                DataService.updateRoomBooking($scope.editableRoomBooking).then(
                    function (results) {
                        //on success
                        $scope.roomBooking = angular.copy($scope.editableRoomBooking);
                        $uibModalInstance.close();
                    },
                    function (results) {
                        //on error
                        $scope.hasFormError = true;
                        $scope.formErrors = results.statusText;
                    });;
            }
        }

        $scope.cancelForm = function () {
            $uibModalInstance.dismiss();
        }

        $scope.resetForm = function () {
            $scope.editableRoomBooking = angular.copy($scope.roomBooking);
            $scope.roomBookingForm.$setUntouched();
        }

    }]);