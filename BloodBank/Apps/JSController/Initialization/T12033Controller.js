
app.controller("T12033Controller", ["$scope", "T12033Service", "Data",
    function ($scope, T12033Service, Data) {
        initializationData();
        GetGridData();
        $scope.New = function () { initializationData(); }

        $scope.Clear = function () { initializationData(); }

        function initializationData() {
            $scope.selectedRow = 0;
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.T_VIRUS_CODE = '';
            $scope.obj.T_LANG2_NAME = '';
            $scope.obj.T_LANG1_NAME = '';
            $scope.obj.T_PN = '';
            $scope.obj.T_ACTIVE = '';
            $scope.obj.t12033 = {};
            document.getElementById("txtVirusCode").focus();
        }

        $scope.Next = function () { GetGridData(); }
        
        function GetGridData() {
            $scope.Search = '';
            var gridData = T12033Service.GetGridData();
            gridData.then(function (data) {
                $scope.obj.VirusInfo = JSON.parse(data);
            });
        }

        $scope.onRowSelect = function (data) {
            $scope.obj.t12033.T_VIRUS_CODE = data.T_VIRUS_CODE;
            $scope.obj.t12033.T_LANG2_NAME = data.T_LANG2_NAME;
            $scope.obj.t12033.T_LANG1_NAME = data.T_LANG1_NAME;
            $scope.obj.t12033.T_PN = data.T_PN;
            $scope.obj.t12033.T_ACTIVE = data.T_ACTIVE;
        }

        $scope.Save = function () {
            var insert = T12033Service.Insert_T12033($scope.obj.t12033);
            insert.then(function (data) {
                var dt = JSON.parse(data);
                alert($scope.getSingleMsg(dt));
                GetGridData();
                initializationData();
            });
        }
    }]);