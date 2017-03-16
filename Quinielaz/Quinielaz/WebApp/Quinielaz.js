angular.module('Login', ['ngMaterial', 'ngMessages']);
angular.module('Quinielaz', ['ngMaterial', 'ngRoute', 'ngCookies', 'Login'])
.config(function ($mdThemingProvider) {
    $mdThemingProvider.theme('default')
        .primaryPalette('blue', {
            'default': '500',
            'hue-1': '100',
            'hue-2': '600',
            'hue-3': 'A100'
        })
        .accentPalette('red')
        .backgroundPalette('grey', {
            'default': '200'
        });
})
.config(function ($mdDateLocaleProvider) {
    $mdDateLocaleProvider.months = ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
                                    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'];
    $mdDateLocaleProvider.shortMonths = ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
                                    'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'];
    $mdDateLocaleProvider.days = ['Domingo', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sábado'];
    $mdDateLocaleProvider.shortDays = ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'];
    $mdDateLocaleProvider.firstDayOfWeek = 1;
    $mdDateLocaleProvider.weekNumberFormatter = function (weekNumber) {
        return 'Semana ' + weekNumber;
    };
    $mdDateLocaleProvider.msgCalendar = 'Calendario';
    $mdDateLocaleProvider.msgOpenCalendar = 'Abrir calendario';
    $mdDateLocaleProvider.formatDate = function (date) {
        return moment(date).format('DD/MM/YYYY');
    };
    $mdDateLocaleProvider.parseDate = function (dateString) {
        var m = moment(dateString, 'DD/MM/YYYY', true);
        return m.isValid() ? m.toDate() : new Date(NaN);
    };
})
.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
    .when('/Login', {
        templateUrl: 'WebApp/Modules/Login/LoginView.html',
        controller: 'LoginController'
    })
    .when('/', {
        templateUrl: 'WebApp/Modules/Main/MainView.html',
        controller: 'MainController'
    })
}])
.run(['$rootScope', '$location', '$cookieStore', '$http',
    function ($rootScope, $location, $cookieStore, $http) {
        $rootScope.logeado = false;
        $rootScope.Globals = $cookieStore.get('Globals') || {};
        if ($rootScope.Globals.CurrentUser) {
            $rootScope.logeado = true;
        }
        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            if ($location.path() !== '/Login' && !$rootScope.Globals.CurrentUser)
                $location.path('/Login');

            var lastString = '';
            var res = next.split("/");
            while (lastString === '')
                lastString = res.pop();
            switch (lastString) {
                case 'Login':
                    $location.path('/Login');
                    break;
                default:
                    if ($rootScope.Globals.CurrentUser) {
                        $location.path('/');
                    }
                    else
                        $location.path('/Login');
                    break;
            }
        })
    }]);