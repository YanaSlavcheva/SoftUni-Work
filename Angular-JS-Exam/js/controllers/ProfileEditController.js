app.controller('ProfileEditController',
    function ($scope, $routeParams, $location, userService, categoriesService, townsService, notifyService) {

        $scope.towns = townsService.getTowns();
        $scope.password = {};

        userService.getUserInfo(
            function success(data) {
                $scope.userData = data;
            },
            function error(err) {
                notifyService.showError("Cannot load user info", err);
            }
        );

        $scope.editProfile = function(params) {

            userService.editProfile(
                params,
                function success(data) {
                    notifyService.showInfo('Successfully edited user profile');
                    $location.path('/user/editProfile');
                },
                function error(err) {
                    notifyService.showError("Cannot edit user profile", err);
                }
            );
        };

        $scope.changePassword = function(params) {

            userService.changePassword(
                params,
                function success(data) {
                    notifyService.showInfo('Successfully changed user password');
                    $location.path('/');
                },
                function error(err) {
                    notifyService.showError("Cannot edit user password", err);
                }
            );
        };

        $scope.cancel = function() {
            $location.path('/user/ads');
        };
    }
);

