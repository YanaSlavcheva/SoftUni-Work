'use strict';

app.factory('adminService',
    function ($resource, baseServiceUrl) {
        var usersResource = $resource(
                baseServiceUrl + '/api/admin/users'
        );

        return {
            getUsers: function(success, error) {
                return usersResource.query(success, error);
            }
        }
    }
);