app.controller("T13054Controller", ["$scope", "Data", "T13054Service",
    function ($scope, Data, T13054Service) {
        clear();
        $scope.openModel = function () {
            getmodel();
        }
        $scope.openModelPopup = function (e) {
            if (e.keyCode === 120) {
                getmodel();
            }
        }
        $scope.onRowSelect = function (i) {
            $scope.obj.T13054.T_MODEL_CODE = $scope.obj.ModelList[i].T_MODEL_CODE;
            $scope.obj.T13054.ANALYZER_MODEL = $scope.obj.ModelList[i].ANALYZER_MODEL;
            document.getElementById('divModel').style.display = "none";
        }
        $scope.CloseModelPopup = function () {
            document.getElementById('divModel').style.display = "none";
        }
        $scope.onClear = function () {
            clear();
        }
        function getmodel() {
            var model = T13054Service.getModelData();
            model.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length>0) {
                    $scope.obj.ModelList = JSON.parse(data);
                    document.getElementById('divModel').style.display = "block";
                } else {
                    document.getElementById('divModel').style.display = "none";
                }
               
            });          
        }

        function clear() {
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.T13054 = {};
            document.getElementById("txtModelId").focus();
        }
    }]);