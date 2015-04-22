'use strict';

angular.module('dairyApp').directive('taskTree', ['$parse', function($parse) {
    return {        
        restrict: 'C',
        controller: 'TreeController',
        compile : function (element, attrs)
        {
            if (!attrs.parentId) { attrs.parentId = '00000000-0000-0000-0000-000000000001' };
        },
        templateUrl: '/Views/directives/taskTree.html',
        scope: {

        }
    }
}]);