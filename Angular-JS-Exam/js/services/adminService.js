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
            },

            getUserInfo: function (username, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/admin/users/' + username,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            deleteUser: function (username, success, error) {
                var request = {
                    method: 'DELETE',
                    url: baseServiceUrl + '/api/admin/user/' + username,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            getAdminAds: function (params, success) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/admin/ads',
                    headers: authService.getAuthHeaders(),
                    params: params
                };
                $http(request).success(success);
            },

            getAdInfo: function (id, success, error) {
            var request = {
                method: 'GET',
                url: baseServiceUrl + '/api/admin/ads/' + id,
                headers: authService.getAuthHeaders()
            };
            $http(request).success(success).error(error);
            },

            approveAd: function (id, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/admin/ads/approve/' + id,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            rejectAd: function (id, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/admin/ads/reject/' + id,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            editAd: function (adData, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/admin/ads/'+ adData.id,
                    headers: authService.getAuthHeaders(),
                    data: adData
                };
                $http(request).success(success).error(error);
            },

            deleteAd: function (id, success, error) {
                var request = {
                    method: 'DELETE',
                    url: baseServiceUrl + '/api/admin/ads/' + id,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            getCategories: function (params, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/admin/categories',
                    headers: authService.getAuthHeaders(),
                    params: params
                };
                $http(request).success(success).error(error);
            },

            createCategory: function (categoryData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/admin/categories',
                    headers: authService.getAuthHeaders(),
                    data: categoryData
                };
                $http(request).success(success).error(error);
            },

            editCategory: function (categoryData, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + '/api/admin/categories/' + categoryData.id,
                    headers: authService.getAuthHeaders(),
                    data: categoryData
                };
                $http(request).success(success).error(error);
            },

            deleteCategory: function (id, success, error) {
                var request = {
                    method: 'DELETE',
                    url: baseServiceUrl + '/api/admin/categories/' + id,
                    headers: authService.getAuthHeaders()
                };
                $http(request).success(success).error(error);
            },

            getTowns: function (params, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + '/api/admin/towns',
                    headers: authService.getAuthHeaders(),
                    params: params
                };
                $http(request).success(success).error(error);
            },

            createTown: function (townData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + '/api/admin/towns',
                    headers: authService.getAuthHeaders(),
                    data: townData
                };
                $http(request).success(success).error(error);
            }
        }
    }
);