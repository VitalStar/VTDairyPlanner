angular.module('dairyApp').factory('dayFactory', function($http,$q, $log) {
    return {
        getDay: function (date, type) {
            var deffered = $q.defer();

            $http.get('http://localhost:56999/DairyTask/GetDay/'+ date).
                success(function (data, status, headers, config) {
                    deffered.resolve(data);
                }).error(function (data, status, headers, config) {
                    deffered.reject(status);
                    $log.warn(data, status, headers, config);
                });
            return deffered.promise;
        }        
    }
}) 