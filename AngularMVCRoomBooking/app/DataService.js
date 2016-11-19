angularFormsApp.factory('DataService',
    ["$http",
    function ($http) {

        var getRoomBookings = function () {
            return $http.get("api/RoomBooking/Get");
        }

        var getRoomBooking = function (id) {
            if (id == 123) {
                return {
                    id: 2,
                    room: { id: 2 },
                    startDate: new Date(),
                    endDate: new Date(),
                    bookingStatus: { id: 2 },
                    paymentStatus: { id: 2 },
                    advancePaid: 2,
                    totalPaid: 2
                }
                return undefined;
            }
        }

        var insertRoomBooking = function (newRoomBooking) {
            return $http.post("api/RoomBookingWebApi/Post", newRoomBooking);
        }

        var updateRoomBooking = function (roomBooking) {
            return $http.put("api/RoomBookingWebApi/Put", roomBooking);
        }

        return {
            insertRoomBooking: insertRoomBooking,
            updateRoomBooking: updateRoomBooking,
            getRoomBooking: getRoomBooking,
            getRoomBookings: getRoomBookings
        }

    }]);