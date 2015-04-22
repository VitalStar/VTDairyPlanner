'use strict';

    angular.module('dairyApp', ['ngRoute']);

   angular.module('dairyApp').controller('mainController', function($scope) {       
        $scope.message = 'Everyone come and see how good I look!';
    });

// configure our routes
    angular.module('dairyApp').config(function ($routeProvider) {
    $routeProvider

        // route for the Today List
        .when('/', {
            templateUrl: 'Views/plan.html',
            controller: 'PlanListController'
        })
        
        // route for the Plan page
        .when('/plan', {
            templateUrl: 'Views/plan.html',
            controller: 'PlanListController'
        })

        // route for the History page
        .when('/history', {
            templateUrl: 'Views/history.html',
            controller: 'HistoryListController'
        })

        .otherwise({
            redirectTo: 'Views/plan.html',
            controller: 'PlanListController'
        });
});


function Task(id, title, desctiption) {
    this.Id = id;
    this.Title = title;
    this.Desctiption = desctiption;
}

function TaskToJSON(task) {
    return {
        "Id": task.Id,
        "Title": task.Title,
        "Description": task.Desctiption
    };
}

function GetToday() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }

    if (mm < 10) {
        mm = '0' + mm;
    }

    today = mm + '-' + dd + '-' + yyyy;
    return today;
}



   