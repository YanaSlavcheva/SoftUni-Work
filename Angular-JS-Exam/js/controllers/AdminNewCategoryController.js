'use strict';

app.controller('AdminNewCategoryController',
    function ($scope, $location, adminService, notifyService) {
        $scope.categoryData = {name: null};

        $scope.createCategory = function(categoryData) {
            adminService.createCategory(categoryData,
                function success() {
                    notifyService.showInfo("Category creation successful");
                    $location.path("/admin/categories");
                },
                function error(err) {
                    notifyService.showError("Category creation failed", err);
                }
            );
        };

        $scope.cancel = function() {
            $location.path('/admin/categories');
        };
    }
);
