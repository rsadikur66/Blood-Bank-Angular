app.controller("T12287Controller", ["$scope", "T12287Service", "Data", "$window", "$filter",
    function ($scope, T12287Service, Data, $window, $filter) {
        $scope.obj = {};        
        $scope.obj = Data;     
        //---------Dummy
        $scope.obj.demo = [];
        for (var i = 0; i < 5; i++) {
            var x = {};
            $scope.obj.demo.push(x);
        }
        //---------Dummy
    }]);