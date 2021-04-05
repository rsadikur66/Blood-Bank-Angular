app.controller("T12087Controller", ["$scope", "T12087Service", "Data",
    function ($scope, T12087Service, Data) {
        initializationData();
        
        $scope.New = function () { initializationData(); }

        $scope.Clear = function () { initializationData(); }

        function initializationData() {
            $scope.selectedRow = 0;
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.t12087 = {};
            GetGridData();
        }

        $scope.Next = function () {
            GetGridData();
        }
        
        function GetGridData() {
            $scope.sedGridVirus = [];
            $scope.obj.VirusInfo = [];
            $scope.Search = '';
            var gridData = T12087Service.GetGridData();
            gridData.then(function (data) {
                $scope.obj.Virus = JSON.parse(data);
                for (var j = 0; j < $scope.obj.Virus.length; j++) {
                    var childgridData = T12087Service.GetGridDataChild($scope.obj.Virus[j].T_VITAL_CODE);
                    childgridData.then(function (data1) {
                        var jsonData = JSON.parse(data1);
                        $scope.obj.frist = {};
                        $scope.obj.frist.List = [];
                        $scope.obj.frist.T_VITAL_CODE = jsonData[0].T_VITAL_CODE;
                        $scope.obj.frist.T_VTL_SIGNS = jsonData[0].T_VTL_SIGNS;
                        $scope.obj.frist.T_NORML_VALUE = jsonData[0].T_NORML_VALUE;
                        $scope.obj.frist.T_MIN_VALUE = jsonData[0].T_MIN_VALUE;
                        $scope.obj.frist.T_MAX_VALUE = jsonData[0].T_MAX_VALUE;
                            for (var k = 0; k < jsonData.length; k++) {
                                $scope.obj.second = {};
                                $scope.obj.second.T_RES_CODE = jsonData[k].T_RES_CODE;
                                $scope.obj.second.T_LANG_NAME = jsonData[k].T_LANG_NAME;
                                $scope.obj.frist.List.push($scope.obj.second );
                            }
                        $scope.sedGridVirus.push($scope.obj.frist);
                    });
                    $scope.obj.VirusInfo = $scope.sedGridVirus;
                }
            });
        }

        $scope.onRowSelect = function (data) {
            $scope.obj.t12087.T_VITAL_CODE = data.T_VITAL_CODE;
            $scope.obj.t12087.T_NORML_VALUE = data.T_NORML_VALUE;
            $scope.obj.t12087.T_MIN_VALUE = data.T_MIN_VALUE;
            $scope.obj.t12087.T_MAX_VALUE = data.T_MAX_VALUE;
            $scope.obj.t12087.T_VTL_SIGNS = data.T_VTL_SIGNS;
        }

        $scope.Save = function () {
            $scope.obj.t12087 = [];
            $scope.obj.M12087 = [];
            for (var i = 0; i < $scope.obj.VirusInfo.length; i++) {
                $scope.fristList = {};
                $scope.fristList.T_VITAL_CODE = $scope.obj.VirusInfo[i].T_VITAL_CODE;
                $scope.fristList.T_NORML_VALUE = $scope.obj.VirusInfo[i].T_NORML_VALUE;
                $scope.fristList.T_MIN_VALUE = $scope.obj.VirusInfo[i].T_MIN_VALUE;
                $scope.fristList.T_MAX_VALUE = $scope.obj.VirusInfo[i].T_MAX_VALUE;
                $scope.obj.t12087.push($scope.fristList);
                for (var j = 0; j < $scope.obj.VirusInfo[i].List.length; j++) {
                    $scope.secondList = {};
                    $scope.secondList.T_VITAL_CODE = $scope.obj.VirusInfo[i].T_VITAL_CODE;
                    $scope.secondList.T_RES_CODE = $scope.obj.VirusInfo[i].List[j].T_RES_CODE;
                    $scope.secondList.T_LANG_NAME = $scope.obj.VirusInfo[i].List[j].T_LANG_NAME;
                    $scope.obj.M12087.push($scope.secondList);
                }
            }

            var update = T12087Service.Update_T12087($scope.obj.t12087, $scope.obj.M12087);
            update.then(function (data) {
                var dt = JSON.parse(data);
                alert($scope.getSingleMsg(dt));
                initializationData();
            });
        }

    }]);