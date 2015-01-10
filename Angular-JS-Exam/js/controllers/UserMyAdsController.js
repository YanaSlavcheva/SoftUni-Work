'use strict';

// The HomeController holds the presentation logic for the home screen
app.controller('UserMyAdsController',
    function ($scope, userService, notifyService, pageSize) {
        userService.getUserAds(
            null,
            function success(data) {
                $scope.ads = data;
            },
            function error(err) {
                notifyService.showError("Cannot load your ads", err);
            }
        );

        $scope.adsParams = {
            'startPage' : 1,
            'pageSize' : pageSize
        };

        $scope.reloadUserAds = function() {
            userService.getUserAds(
                $scope.adsParams,
                function success(data) {
                    $scope.ads = data;
                },
                function error(err) {
                    notifyService.showError("Cannot load your ads", err);
                }
            );
        };

        $scope.deactivateAd = function(id) {
            userService.deactivateAd(
                id,
                function success(data) {
                    notifyService.showInfo("Successfully deactivated your ad");
                    $scope.reloadAds();
                },
                function error(err) {
                    notifyService.showError("Cannot deactivate your ad", err);
                }
            );
        };

        $scope.publishAgainAd = function(id) {
            userService.publishAgainAd(
                id,
                function success(data) {
                    notifyService.showInfo("Successfully published again your ad");
                    $scope.reloadAds();
                },
                function error(err) {
                    notifyService.showError("Cannot publish again your ad", err);
                }
            );
        };

        $scope.$on("categorySelectionChanged", function(event, selectedCategoryId) {
            $scope.adsParams.categoryId = selectedCategoryId;
            $scope.adsParams.startPage = 1;
            $scope.reloadAds();
        });

        $scope.$on("townSelectionChanged", function(event, selectedTownId) {
            $scope.adsParams.townId = selectedTownId;
            $scope.adsParams.startPage = 1;
            $scope.reloadAds();
        });
    }
);
