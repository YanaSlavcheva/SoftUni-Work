'use strict';

app.controller('AdminController',
    function ($scope, $location, adminService, notifyService, pageSize) {

        adminService.getUsers(
            null,
            function success(data) {
                $scope.users = data;
            },
            function error(err) {
                notifyService.showError("Cannot load users", err);
            }
        );

        $scope.usersParams = {
            'startPage' : 1,
            'pageSize' : pageSize
        };

        $scope.reloadUsers = function() {
            adminService.getUsers(
                $scope.usersParams,
                function success(data) {
                    $scope.users = data;
                },
                function error(err) {
                    notifyService.showError("Cannot load users", err);
                }
            );
        };
    }
);
