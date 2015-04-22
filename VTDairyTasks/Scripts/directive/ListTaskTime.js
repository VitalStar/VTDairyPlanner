'use strict';

angular.module('dairyApp').directive('listTaskTime', ['$parse', function ($parse) {
    return {
        restrict: 'E',
        templateUrl: '/Views/directives/listTaskTime.html'
    }
}]);