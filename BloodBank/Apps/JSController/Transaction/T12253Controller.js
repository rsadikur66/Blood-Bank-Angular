app.controller("T12253Controller", ["$scope", "T12253Service", "Data", "$window", "$filter",
    function ($scope, T12253Service, Data, $window, $filter) {
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