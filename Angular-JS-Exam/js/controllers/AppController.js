'use strict';

// The AppController holds the presentation logic for the entire app (common all screens)
app.controller('AppController',
    function ($scope, $location, authService, notifyService) {
        $scope.authService = authService;

        $scope.logout = function() {
            authService.logout();
            notifyService.showInfo("Logout successful");
            $location.path("/");
        };
    }
);


