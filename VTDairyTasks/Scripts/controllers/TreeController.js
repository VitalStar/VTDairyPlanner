'use strict';

angular.module('dairyApp').controller('TreeController',  ['$scope', '$attrs', 'taskFactory',  function($scope, $attrs, taskFactory) {
    $scope.message = 'Tree works!';

    $scope.delete = function(task) {
        task.nodes = [];
    };

    $scope.add = function(task) {
        task.nodes.push({Title: 'New Task', nodes: []});
    };

    $scope.get = function(data) {
    };

    $scope.ShowChildTasks = function(task) {
        taskFactory.getChildTasks(task.Id).then(
            function (data) {
                $scope.treeTasks = data;
            },
            function (statusCode) { console.log(statusCode); });
    };

    if (!$scope.treeTasks) {
        taskFactory.getRoot().then(
            function(data) {
                $scope.treeTasks = data;
            },
            function(statusCode) { console.log(statusCode); });
    }
    else
    {
        taskFactory.getChildTasks($attrs.parentId).then(
            function (data) {
                $scope.treeTasks = data;
            },
            function (statusCode) { console.log(statusCode); });
    }
}]);


