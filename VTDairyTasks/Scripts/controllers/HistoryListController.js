'use strict';

angular.module('dairyApp').controller('HistoryListController', ['$scope', 'dayFactory', function ($scope, dayFactory) {

    $scope.message = 'HistoryListController works!';
    $scope.listtype = 'history';

    $scope.selectedDate = GetToday();

    if (!$scope.days) {
        dayFactory.getDay($scope.selectedDate).then(
            function (day) {
                $scope.days = new Array();
                $scope.days.push(day);
            },
            function (statusCode) { console.log(statusCode); });
    }
}]);