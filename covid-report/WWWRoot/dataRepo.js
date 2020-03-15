(function () {
    'use strict';

    angular
        .module('app')
        .factory('dataRepo', factory);

    factory.$inject = ['$http'];

    function factory($http) {
        var service = {
            getPositivi: getPositivi,
            getDeceduti: getDeceduti,
            getDate: getDate
        };

        return service;

        function getPositivi(regione) {
            return $http.get("/coviddata/positivi?regione=" + regione);
        }
        function getDeceduti(regione) {
            return $http.get("/coviddata/deceduti?regione=" + regione);
        }
        function getDate(regione) {
            return $http.get("/coviddata/date?regione=" + regione);
        }

    }
})();