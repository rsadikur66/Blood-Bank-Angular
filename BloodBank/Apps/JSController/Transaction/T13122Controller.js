app.controller("T13122Controller", ["$scope", "T13122Service", "Data", "$window", "$filter",
    function ($scope, T13122Service, Data, $window, $filter) {
        $scope.obj = {};        
        $scope.obj = Data;     

        //---------Dummy
        $scope.obj.demo = [];
        for (var i = 0; i < 10; i++) {
            var x = {};
            $scope.obj.demo.push(x);
        }
        //---------Dummy
    }]);