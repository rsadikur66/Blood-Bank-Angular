
app.controller("T12215Controller", ["$scope", "T12215Service", "Data", "$window", "$filter",
    function ($scope, T12215Service, Data, $window, $filter) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12215 = {};
        var tst = T12215Service.test();
        tst.then(function (data) {
            var d = data;
        });

    }]);