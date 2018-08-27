(function () {
    'use strict';

    angular
        .module('app', ['ngRoute', 'ngCookies', 'ngMask', 'angular-file-input', 'ngFileUpload'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider', '$locationProvider'];
    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', {
                controller: 'HomeController',
                templateUrl: 'home/home.view.html',
                controllerAs: 'vm'
            })
            .when('/approve/:id/:token', {
                controller: 'ApproveController',
                templateUrl: 'approve/approve.view.html',
            })
            .when('/feedback/:id', {
                controller: 'FeedbackController',
                templateUrl: 'feedback/feedback.view.html',
                controllerAs: 'vm'
            })
            .when('/nopermission', {
              controller: 'UnauthorizationController',
              templateUrl: 'unauthorization/unauthorization.view.html'
            })
            .when('/success', {
              controller: 'SuccessController',
              templateUrl: 'success/success.view.html'
            })
            .otherwise({ redirectTo: '/' });
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];
    function run($rootScope, $location, $cookieStore, $http) {

    }

})();
