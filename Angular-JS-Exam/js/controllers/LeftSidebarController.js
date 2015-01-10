'use strict';

// The LeftSidebarController controls the content displayed in the left sidebar
app.controller('LeftSidebarController',
    function ($scope, $rootScope) {
        $scope.statusClicked = function(clickedStatusString) {
            $scope.clickedStatusString = clickedStatusString;
            $rootScope.$broadcast("statusSelectionChanged", clickedStatusString);
        };
    }
);
