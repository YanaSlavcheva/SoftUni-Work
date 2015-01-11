'use strict';

app.controller('AdminController',
    function ($scope, $location, adminService, notifyService, pageSize, $routeParams, $route) {
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
                    $route.reload();
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

        $scope.deleteCategory = function(id) {
            adminService.deleteCategory(
                id,
                function success(data) {
                    notifyService.showInfo('Successfully deleted the category');
                    $location.path('/admin/categories');
                    $route.reload();
                },
                function error(err) {
                    notifyService.showError("Cannot delete the category", err);
                }
            );
        };

        adminService.getTowns(
            null,
            function success(data) {
                $scope.towns = data;
            },
            function error(err) {
                notifyService.showError("Cannot load towns", err);
            }
        );

        $scope.townsParams = {
            'startPage' : 1,
            'pageSize' : pageSize
        };

        $scope.reloadTowns = function() {
            adminService.getTowns(
                $scope.townsParams,
                function success(data) {
                    $scope.towns = data;
                },
                function error(err) {
                    notifyService.showError("Cannot load towns", err);
                }
            );
        };

        $scope.deleteTown = function(id) {
            adminService.deleteTown(
                id,
                function success(data) {
                    notifyService.showInfo('Successfully deleted the town');
                    $location.path('/admin/towns');
                    $route.reload();
                },
                function error(err) {
                    notifyService.showError("Cannot delete the town", err);
                }
            );
        };

        $scope.cancel = function() {
            $location.path('/admin/users');
        };
    }
);
