'use strict';

angular.module('dairyApp').controller('PlanListController', ['$scope', 'dayFactory', function ($scope, dayFactory) {

    $scope.message = 'PlanListController works!';
    $scope.listtype = 'plan';
    
    $scope.selectedDate = GetToday();    

    if (!$scope.day) {
        dayFactory.getDay($scope.selectedDate).then(
            function (day) {                
                $scope.day = day;
            },
            function (statusCode) { console.log(statusCode); });
    }
}]);
   