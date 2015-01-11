'use strict';

// The HomeController holds the presentation logic for the home screen
app.controller('HomeController',
    function ($scope, adsService, notifyService, pageSize, authService, adminService) {
//        load ads for users
        adsService.getAds(
            null,
            function success(data) {
                $scope.ads = data;
            },
            function error(err) {
                notifyService.showError("Cannot load ads", err);
            }
        );

        $scope.adsParams = {
            'startPage' : 1,
            'pageSize' : pageSize
        };

        $scope.reloadAds = function() {
            adsService.getAds(
                $scope.adsParams,
                function success(data) {
                    $scope.ads = data;
                },
                function error(err) {
                    notifyService.showError("Cannot load ads", err);
                }
            );
        };

//        load ads for admin
        adminService.getAdminAds(
            null,
            function success(data) {
                $scope.adminAds = data;
            }
        );

        $scope.adminAdsParams = {
            'startPage' : 1,
            'pageSize' : pageSize
        };

        $scope.reloadAdminAds = function() {
            adminService.getAdminAds(
                null,
                function success(data) {
                    $scope.adminAds = data;
                }
            );
        };

        $scope.approveAd = function(id) {
            adminService.approveAd(
                id,
                function success(data) {
                    notifyService.showInfo("Successfully approved the ad");
                    $scope.reloadAdminAds();
                },
                function error(err) {
                    notifyService.showError("Cannot approve the ad", err);
                }
            );
        };

        $scope.rejectAd = function(id) {
            adminService.rejectAd(
                id,
                function success(data) {
                    notifyService.showInfo("Successfully rejected the ad");
                    $scope.reloadAdminAds();
                },
                function error(err) {
                    notifyService.showError("Cannot reject the ad", err);
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



