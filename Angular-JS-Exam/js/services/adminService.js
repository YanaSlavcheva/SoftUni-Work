'use strict';

app.factory('adminService',
    function ($http, baseServiceUrl, authService) {
        return{
            getUsers: function (params, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/admin/users',
                    headers: authService.getAuthHeaders(),
                    params: params
                };
                $http(request).success(success).error(error);
            }
        }
    }
);