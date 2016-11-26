angularFormsApp.factory('DataService',
    ["$http",
    function ($http) {

        var getRoomBookings = function () {
            return $http.get("api/RoomBookingWebApi/");
        }

        var getRoomBooking = function (id) {
            return $http.get("api/RoomBookingWebApi/"+id);
        }

        var insertRoomBooking = function (newRoomBooking) {
            return $http.post("api/RoomBookingWebApi", newRoomBooking);
        }

        var updateRoomBooking = function (roomBooking) {
            return $http.put("api/RoomBookingWebApi/", roomBooking);
        }

        return {
            insertRoomBooking: insertRoomBooking,
            updateRoomBooking: updateRoomBooking,
            getRoomBooking: getRoomBooking,
            getRoomBookings: getRoomBookings
        }

    }]);