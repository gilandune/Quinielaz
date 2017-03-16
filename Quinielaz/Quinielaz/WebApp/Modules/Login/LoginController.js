angular.module('Login').controller('LoginController', ['$scope', '$rootScope', '$cookieStore', '$mdDialog', '$location', 'LoginServices',
function ($scope, $rootScope, $cookieStore, $mdDialog, $location, LoginServices) {
    $scope.logeando = false;
    $rootScope.dataLoading = false;
    $scope.Request = { Username: '', Password: '' };
    var clearGlobals = function () {
        $rootScope.Globals = {};
        $cookieStore.remove('Globals');
        $rootScope.dataLoading = false;
        $rootScope.logeado = false;
    };
    clearGlobals();
    var setGlobals = function (data) {
        $rootScope.Globals = data;
        $cookieStore.put('Globals', $rootScope.Globals);
    };
    var ShowDialog = function (message, ev) {
        $mdDialog.show(
            $mdDialog.alert()
            .parent(angular.element(document.querySelector('#MainContainer')))
            .clickOutsideToClose(false)
            .title('Mensaje de sistema')
            .textContent(message)
            .ariaLabel('Mensaje')
            .ok('Aceptar')
            .targetEvent(ev)
        );
    };
    $scope.Ingresar = function (data, event) {
        $rootScope.dataLoading = true;
        $scope.logeando = true;
        LoginServices.Login(data, function (response) {
            if (response.d.CurrentUser.Id > 0) {
                setGlobals(response.d);
                $rootScope.logeado = true;
                $location.path('/');
            }
            else {
                ShowDialog('Usuario o contraseña incorrectos', event);
            }
            $rootScope.dataLoading = false;
            $scope.logeando = false;
        });
    };
    $scope.Registrar = function (evt) {
        //$location.path('/Registro');
    };
}]);