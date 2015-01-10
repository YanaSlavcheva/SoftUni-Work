app.controller('AdEditController',
    function ($scope, $routeParams, $location, userService, adsService, notifyService, categoriesService, townsService) {
        $scope.id = $routeParams.id;
        $scope.categories = categoriesService.getCategories();
        $scope.towns = townsService.getTowns();
        $scope.adData = {};

        userService.getAdInfo(
            $scope.id,
            function success(data) {
                notifyService.showInfo("Are you sure you want to delete this Ad?");
                $scope.ad = data;
            },
            function error(err) {
                notifyService.showError("You cannot delete this ad", err);
            }
        );

        $scope.editAd = function(params) {
            if($scope.adData.changeimage == true) {
                params.changeimage = true;
                params.imageDataUrl = $scope.adData.imageDataUrl;
            }

            userService.editAd(
                params,
                function success(data) {
                    notifyService.showInfo('Successfully edited the ad');
                    $location.path('/user/ads');
                },
                function error(err) {
                    notifyService.showError("Cannot edit the ad", err);
                }
            );
        };

        $scope.deleteImage = function() {
            $scope.adData.changeimage = true;
            $scope.adData.imageDataUrl = '';
            notifyService.showInfo('The image was deleted successfully');
        };

        $scope.fileSelected = function(fileInputField) {
            $scope.adData.imageDataUrl = '';
            var file = fileInputField.files[0];
            if (file.type.match(/image\/.*/)) {
                $scope.adData.changeimage = true;
                var reader = new FileReader();
                reader.onload = function() {
                    $scope.adData.imageDataUrl = reader.result;
                    $(".image-box").html("<img src='" + reader.result + "'>");
                };
                reader.readAsDataURL(file);
            } else {
                $(".image-box").html("<p>This file type is not supported!</p>");
            }
        };

        $scope.cancel = function() {
            $location.path('/user/ads');
        };
    }
);
