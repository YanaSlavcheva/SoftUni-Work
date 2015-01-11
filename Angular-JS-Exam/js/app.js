'use strict';

var app = angular.module('app', ['ngRoute', 'ngResource', 'angular-loading-bar', 'ui.bootstrap.pagination']);

app.constant('baseServiceUrl', 'http://softuni-ads.azurewebsites.net');
app.constant('pageSize', 2);

app.config(function ($routeProvider) {

    $routeProvider.when('/', {
        templateUrl: 'templates/home.html',
        controller: 'HomeController'
    });

    $routeProvider.when('/login', {
        templateUrl: 'templates/login.html',
        controller: 'LoginController'
    });

    $routeProvider.when('/register', {
        templateUrl: 'templates/register.html',
        controller: 'RegisterController'
    });

    $routeProvider.when('/user/profile/edit', {
        templateUrl: 'templates/user/editProfile.html',
        controller: 'ProfileEditController'
    });

    $routeProvider.when('/user/ads', {
        templateUrl: 'templates/user/myAds.html',
        controller: 'UserMyAdsController'
    });

    $routeProvider.when('/user/ads/publish', {
        templateUrl: 'templates/user/publish-new-ad.html',
        controller: 'UserPublishNewAdController'
    });

    $routeProvider.when('/user/ads/edit/:id', {
        templateUrl: 'templates/user/editAd.html',
        controller: 'AdEditController'
    });

    $routeProvider.when('/user/ads/delete/:id', {
        templateUrl: 'templates/user/deleteAd.html',
        controller: 'AdDeleteController'
    });

    $routeProvider.when('/admin/users', {
        templateUrl: 'templates/admin/users.html',
        controller: 'AdminController'
    });

    $routeProvider.when('/admin/users/delete/:username', {
        templateUrl: 'templates/admin/deleteUser.html',
        controller: 'AdminController'
    });

    $routeProvider.when('/admin/ads/edit/:id', {
        templateUrl: 'templates/admin/editAd.html',
        controller: 'AdminAdEditController'
    });

    $routeProvider.when('/admin/ads/delete/:id', {
        templateUrl: 'templates/admin/deleteAd.html',
        controller: 'AdminAdDeleteController'
    });

    $routeProvider.when('/admin/categories', {
        templateUrl: 'templates/admin/categories.html',
        controller: 'AdminController'
    });

    $routeProvider.when('/admin/categories/create', {
        templateUrl: 'templates/admin/createCategory.html',
        controller: 'AdminController'
    });

    $routeProvider.otherwise(
        { redirectTo: '/' }
    );
});

app.run(function ($rootScope, $location, authService) {
    $rootScope.$on('$locationChangeStart', function (event) {
        if (($location.path().indexOf("/user/") != -1 && !authService.isLoggedIn()) || ($location.path().indexOf("/admin/") != -1 && !authService.isLoggedIn())) {
            // Authorization check: anonymous site visitors cannot access user routes
            $location.path("/");
        }
    });
});






