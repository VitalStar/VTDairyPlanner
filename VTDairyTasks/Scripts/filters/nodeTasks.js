'use strict';

angular.module('dairyApp').filter('nodeTasks', function() {
    return function(tasks) {
        var taskToReturn = [];
        for (var i=0; i< tasks.length; i++) {
                if (tasks[i].ParentId.toUpperCase() == '742011D0-F27B-4FD1-A48A-4A34305B7B9C') {
                    taskToReturn.push(tasks[i]);
                }
            }

        return taskToReturn;
    }
});