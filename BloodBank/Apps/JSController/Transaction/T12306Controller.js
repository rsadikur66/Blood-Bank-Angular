app.controller("T12306Controller", ["$scope", "T12306Service", "Data", "$window", "$filter",
    function ($scope, T12306Service, Data, $window, $filter) {
        $scope.obj = {};        
        $scope.obj = Data;        
    }]);