var app = angular.module('BloodBank', ['ui.grid.selection', 'ui.grid', 'ui.grid.pagination', 'ui.grid.exporter', 'datatables', 'angularUtils.directives.dirPagination', 'ngSanitize', 'ui.select', 'angularModalService', 'akFileUploader', '720kb.datepicker']);

app.run(function ($rootScope, $templateCache) {
	$rootScope.$on('$routeChangeStart', function (event, next, current) {
		if (typeof (current) !== 'undefined') {
			$templateCache.remove(current.templateUrl);
		}
	});
});
app.factory('Data', function () {
    return { obj: '' };
});
app.filter('propsFilter', function () {
    return function (items, props) {
        var out = [];

        if (angular.isArray(items)) {
            var keys = Object.keys(props);

            items.forEach(function (item) {
                var itemMatches = false;

                for (var i = 0; i < keys.length; i++) {
                    var prop = keys[i];
                    var text = props[prop].toLowerCase();
                    if (item[prop].toString().toLowerCase().indexOf(text) !== -1) {
                        itemMatches = true;
                        break;
                    }
                }

                if (itemMatches) {
                    out.push(item);
                }
            });
        } else {
            // Let the output be the input untouched
            out = items;
        }

        return out;
    };
});
app.factory("vrtlDirr", ['$location',function ($location) {
        var k = '';
        var lastChar = $location.$$absUrl[$location.$$absUrl.length - 1];
        if (lastChar == '/') {
            k = $location.$$absUrl.slice(0, -1);
        } else {
            k = $location.$$absUrl;
        }



        var ssn = sessionStorage.getItem("vrtlDrr");
        var orUrl = sessionStorage.getItem("orUrl");
        var vrtlDrr = '';
        var a = k.split("/").length - 1;
        if ((ssn == null || ssn == undefined) || (orUrl == null || orUrl == undefined)) {
            if (k != 'http://localhost:3987') {
                vrtlDrr = '/' + k.split('/')[3];
                sessionStorage.setItem("vrtlDrr", vrtlDrr);

            } else {
                vrtlDrr = '';
                sessionStorage.setItem("vrtlDrr", vrtlDrr);
            }
            sessionStorage.setItem("orUrl", k);
        } else {
            vrtlDrr = ssn;
        }
        return vrtlDrr;
}]);
app.config(['$provide', function ($provide) {
    $provide.decorator('$controller', ['$delegate', function ($delegate) {
        return function (constructor, locals, later, indent) {
            //&& !locals.$scope.controllerName
            if (typeof constructor === 'string') {
                locals.$scope.controllerName = constructor;
            }
            return $delegate(constructor, locals, later, indent);
        };
    }])
}]);
app.factory('$exceptionHandler', ['$injector', function ($injector) {
    return function (exception, cause) {
        try {
            var $http = $injector.get('$http');
            var $log = $injector.get('$log');
            var $location = $injector.get('$location');
            var a = $location.$$absUrl;
            if (exception.stack != undefined) {
                var vir = a.search('3987') < 0 ? '/' + a.split('/')[3] : '';
                var message = exception.stack.split('at')[0].trim();
                var source = exception.stack.split('at')[1].trim();
                //$http.post(vir + '/Account/setClientErrorLog', { controller: '', action: '', message: message, source: source });
            }
            //$log.error.apply($log, arguments);
        } catch (e) {
            console.log(e.message);
        }
    };
}]);

