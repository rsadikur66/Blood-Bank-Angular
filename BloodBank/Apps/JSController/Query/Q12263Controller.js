
app.controller("Q12263Controller", ["$scope", "Data", "Q12263Service",
    function ($scope, Data, Q12263Service) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.t12266 = {};

        var gridData = Q12263Service.getGridData();
        gridData.then(function (data) {
            $scope.obj.AllGridData = JSON.parse(data);
            
        })
    }]);
