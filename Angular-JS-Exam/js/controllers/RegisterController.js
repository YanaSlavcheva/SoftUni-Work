'use strict';

app.controller('RegisterController',
    function ($scope, $location, townsService, authService, notifyService) {
        $scope.userData = {townId: null};

        townsService.getTowns(
            function success(data) {
                $scope.towns = data;
            },
            function error(err) {
                notifyService.showError("Cannot load towns", err);
            }
        );
        // TODO: load the towns in $scope (for the towns drop-down list)

        $scope.register = function(userData) {
            authService.register(userData,
                function success() {
                    notifyService.showInfo("Registration successful");
                    $location.path("/login");
                },
                function error(err) {
                    notifyService.showError("User registration failed", err);
                }
            );
        };
    }
);


