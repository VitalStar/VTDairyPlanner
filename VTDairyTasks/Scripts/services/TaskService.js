angular.module('dairyApp').factory('taskFactory', function($http,$q, $log) {
    return {
        getRoot: function() {
            var deffered = $q.defer();

            $http.get('http://localhost:56999/DairyTask/GetRootTasks').
                success(function(data, status, headers, config) {
                    deffered.resolve(data);
                }).error(function(data, status, headers, config) {
                    deffered.reject(status);
                    $log.warn(data, status, headers, config);
                });
            return deffered.promise;
        },
        getAll: function() {
            var deffered = $q.defer();

            $http({ method: 'GET', url: 'http://localhost:56999/DairyTask/GetTasks' }).
                success(function(data, status, headers, config) {
                    deffered.resolve(data);
                }).error(function(data, status, headers, config) {
                    deffered.reject(status);
                    $log.warn(data, status, headers, config);
                });
            return deffered.promise;
        },
        getChildTasks: function (parentId) {
            var deffered = $q.defer();

            $http({ method: 'GET', url: 'http://localhost:56999/DairyTask/GetChildTasks/' + parentId }).
                success(function(data, status, headers, config) {
                    deffered.resolve(data);
                }).error(function(data, status, headers, config) {
                    deffered.reject(status);
                    $log.warn(data, status, headers, config);
                });
            return deffered.promise;
        }
}
}) 