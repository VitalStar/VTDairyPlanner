'use strict';

angular.module('dairyApp').directive('dayDairy', ['$parse', function ($parse) {
    return {
        
        restrict: 'E',
        templateUrl: '/Views/directives/dayDairy.html'
    }
}]);