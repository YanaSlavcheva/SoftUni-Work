'use strict';

// The AppController holds the presentation logic for the entire app (common all screens)
app.controller('AppController',
    function ($scope, $location, authService, notifyService) {
        // Put the authService in the $scope to make it accessible from all screens
        $scope.authService = authService;

        // Implement the "logout" button click event handler
        $scope.logout = function() {
            authService.logout();
            notifyService.showInfo("Logout successful");
            $location.path("/");
        };
    }
);



////
//authService.login(userData,
//    function success() {
//        notifyService.showInfo("Login successful");
//        $location.path("/");
//    },
//    function error(err) {
//        notifyService.showError("Cannot login", err);
//    }
//);


