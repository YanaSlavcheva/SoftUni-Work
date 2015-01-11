app.controller('AdminEditCategoryController',
    function ($scope, $routeParams, $location, adminService, adsService, notifyService, categoriesService, townsService) {
        $scope.id = $routeParams.id;
        $scope.username = $routeParams.username;
        $scope.categoryData = {};

        $scope.editCategory = function(params) {
            adminService.editCategory(params,
                function success(data) {
                    notifyService.showInfo('Successfully edited the category');
                    $location.path('/admin/categories');
                },
                function error(err) {
                    notifyService.showError("Cannot edit the category", err);
                }
            );
        };

        $scope.cancel = function() {
            $location.path('/admin/categories');
        };
    }
);

