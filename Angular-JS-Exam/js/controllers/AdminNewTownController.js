'use strict';

app.controller('AdminNewTownController',
    function ($scope, $location, adminService, notifyService) {
        $scope.townData = {name: null};

        $scope.createTown = function(townData) {
            adminService.createTown(townData,
                function success() {
                    notifyService.showInfo("Town creation successful");
                    $location.path("/admin/towns");
                },
                function error(err) {
                    notifyService.showError("Town creation failed", err);
                }
            );
        };

        $scope.cancel = function() {
            $location.path('/admin/towns');
        };
    }
);
