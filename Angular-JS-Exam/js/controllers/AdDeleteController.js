app.controller('AdDeleteController',
    function ($scope, $routeParams, $location, userService, adsService, notifyService, categoriesService, townsService) {
        $scope.id = $routeParams.id;
        $scope.categories = categoriesService.getCategories();
        $scope.towns = townsService.getTowns();
        $scope.adData = {};

        userService.getAdInfo(
            $scope.id,
            function success(data) {
                notifyService.showInfo("Ad info loaded successfully");
                $scope.ad = data;
            },
            function error(err) {
                notifyService.showError("Cannot load add info", err);
            }
        );

        $scope.deleteAd = function(adId) {
            userService.deleteAd(
                adId,
                function success(data) {
                    notifyService.showInfo('Successfully deleted the ad');
                    $location.path('/user/ads');
                },
                function error(err) {
                    notifyService.showError("Cannot delete the ad", err);
                }
            );
        };

        $scope.cancel = function() {
            $location.path('/user/ads');
        };
    }
);