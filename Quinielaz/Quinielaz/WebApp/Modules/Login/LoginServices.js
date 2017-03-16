angular.module('Login').factory('LoginServices', ['$http',
    function ($http) {
        var service = {};
        service.Login = function (data, callback) {
            $http.post('http://' + location.host + '/QuinielazServices/UsuarioService.svc/json/Login',
            { Request: data }).success(function (response) {
                callback(response);
            });
        };
        return service;
    }]);