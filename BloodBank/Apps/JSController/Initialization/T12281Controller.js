
app.controller("T12281Controller", ["$scope", "T12281Service", "Data",
    function ($scope, T12281Service, Data) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12281 = {};
        $scope.obj.a = {};
        $scope.obj.a.selected = {};
        var alldata = T12281Service.getAllData();
        alldata.then(function(data) {
            var jsonData = JSON.parse(data);
            $scope.obj.weightList = jsonData;
        });
        var unit = T12281Service.getAllUnitData();
        unit.then(function (data) {
            var jsonData = JSON.parse(data);
            $scope.obj.UnitList = jsonData;
        });
        $scope.Save_Click = function() {
            var save = T12281Service.saveData($scope.obj.T12281 );
            save.then(function (data) {
                alert(data);
                document.getElementById("txtWeightCode").readOnly = false;
                $scope.obj.T12281 = {};
                $scope.obj.a.selected = { T_UNIT_NAME: '' };
                var alldata = T12281Service.getAllData();
                alldata.then(function (data) {
                    var jsonData = JSON.parse(data);
                    $scope.obj.weightList = jsonData;
                });
            });
        }
        $scope.setClickedRow = function(ind,data) {
            $scope.obj.T12281.T_WEIGHT_CODE = data.T_WEIGHT_CODE;
            $scope.obj.T12281.T_WEIGHT_NAME = data.T_WEIGHT_NAME;
            $scope.obj.T12281.T_WEIGHT_FR = data.T_WEIGHT_FR;
            $scope.obj.T12281.T_WEIGHT_TO = data.T_WEIGHT_TO;
            $scope.obj.T12281.T_DISCARD_REASON_CODE = data.T_DISCARD_REASON_CODE;
            $scope.obj.T12281.T_WEIGHT_GM = data.T_WEIGHT_GM;
            $scope.obj.T12281.T_WEIGHT_GMT = data.T_WEIGHT_GMT;
            $scope.obj.a.selected = { T_UNIT_NAME: data.UNIT_NAME };
            $scope.obj.a.selected.T_UNIT_TYPE = data.T_ACTION; 
            document.getElementById("txtWeightCode").readOnly = true;
        }

    }]);