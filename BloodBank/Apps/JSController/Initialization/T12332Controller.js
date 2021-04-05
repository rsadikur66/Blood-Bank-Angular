app.controller("T12332Controller", ["$scope", "$filter", "$http", "$window", "T12332Service", "Data",
    function ($scope, $filter, $http, $window, T12332Service, Data) { //$location,
        initializationData();
        GetGridData();
        $scope.New = function () { initializationData(); }

        $scope.Clear = function () { initializationData(); }

        function initializationData() {
            $scope.selectedRow = 0;
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.T_UNIT_TYPE = '';
            $scope.obj.T_LANG2_NAME = '';
            $scope.obj.T_LANG1_NAME = '';
            $scope.obj.T_NO_OF_BAG = '';
            $scope.obj.t12073 = {};
            document.getElementById("txtNumberOfBag").focus();
        }

        $scope.Next = function () { GetGridData(); }

        $scope.EnterControl = function (event) {
            if (event.keyCode === 13) {
                NextData();
            }
            else if (event.keyCode === 114) {
                event.preventDefault();
                NextData();
            }
        };
        
        function GetGridData() {
            $scope.Search = '';
            var gridData = T12332Service.GetGridData($scope.obj.t12073.T_UNIT_TYPE, $scope.obj.t12073.T_LANG2_NAME, $scope.obj.t12073.T_LANG1_NAME, $scope.obj.t12073.T_NO_OF_BAG);
            gridData.then(function (data) {
                $scope.obj.BagInfo = JSON.parse(data);
            });
        }

        $scope.onRowSelect = function (data) {
            $scope.obj.t12073.T_UNIT_TYPE = data.T_UNIT_TYPE;
            $scope.obj.t12073.T_LANG2_NAME = data.T_LANG2_NAME;
            $scope.obj.t12073.T_LANG1_NAME = data.T_LANG1_NAME;
            $scope.obj.t12073.T_NO_OF_BAG = data.T_NO_OF_BAG;
        }

        $scope.Save = function () {
            var insert = T12332Service.Insert_T12332($scope.obj.t12073);
            insert.then(function (data) {
                var dt = JSON.parse(data);
                alert($scope.getSingleMsg(dt));
                GetGridData();
                initializationData();
            });
        }
    }]);