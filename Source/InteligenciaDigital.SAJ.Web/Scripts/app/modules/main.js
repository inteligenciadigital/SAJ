'use strict';

// Declare app level module which depends on filters, and services
angular.module('main', []).
  config(['$routeProvider', function ($routeProvider) {
      $routeProvider.when('/', { templateUrl: 'Content/html/home/Default.html', controller: null });
      $routeProvider.when('/ServidorTEF', { templateUrl: 'Content/html/ServidorTEF/Index.html', controller: ServidorTEFController });
      $routeProvider.otherwise({ redirectTo: '/' });
  }]);