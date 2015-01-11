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

        $scope.adsParams = {
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



