'use strict';

app.controller('AdminController',
    function ($scope, $location, adminService, notifyService, pageSize, $routeParams) {
//        $scope.username = $routeParams.username;

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

//        adminService.getUserInfo(
//            $scope.username,
//            function success(data) {
//                notifyService.showInfo("User info loaded successfully");
//                $scope.ad = data;
//            },
//            function error(err) {
//                notifyService.showError("Cannot load user info", err);
//            }
//        );

        $scope.deleteUser = function(username) {
            adminService.deleteUser(
                username,
                function success(data) {
                    notifyService.showInfo('Successfully deleted the user');
                    $location.path('/admin/users');
                },
                function error(err) {
                    notifyService.showError("Cannot delete the user", err);
                }
            );
        };

        adminService.getCategories(
            null,
            function success(data) {
                $scope.categories = data;
            },
            function error(err) {
                notifyService.showError("Cannot load categories", err);
            }
        );

        $scope.categoriesParams = {
            'startPage' : 1,
            'pageSize' : pageSize
        };

        $scope.reloadCategories = function() {
            adminService.getCategories(
                $scope.categoriesParams,
                function success(data) {
                    $scope.categories = data;
                },
                function error(err) {
                    notifyService.showError("Cannot load categories", err);
                }
            );
        };

        $scope.cancel = function() {
            $location.path('/admin/users');
        };
    }
);
