app.controller("T12256Controller", ["$scope", "T12256Service", "Data", "$window", "$filter",
    function ($scope, T12256Service, Data, $window, $filter) {
        $scope.obj = {};
        $scope.obj = Data;
        //---------Dummy
        document.querySelector('#myDiv').addEventListener('keyup',
            function(e) {
                console.log(e.key);
            });
    }]);