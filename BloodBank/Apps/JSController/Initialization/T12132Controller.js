app.controller("T12132Controller", ["$scope", "$filter", "$http", "$window","T12132Service", "Data",
    function ($scope, $filter, $http, $window,T12132Service, Data) {
        //$scope.obj = {};
        //$scope.obj = Data;
        //$scope.obj.T_CONTROL_NAME = '';
        //$scope.obj.T_FORM_NAME = '';
        //$scope.obj.T_CONTROL_TEXT_LANG1 = '';
        //$scope.obj.T_CONTROL_TEXT_LANG2 = '';
        //$scope.obj.t12132 = {};
        //$scope.obj.f = {};
        //$scope.obj.f.selected = {};
        initializationData();

        $scope.Clear = function () { initializationData(); }

        function initializationData() {
            $scope.selectedRow = 0;
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.T_CONTROL_NAME = '';
            $scope.obj.T_FORM_NAME = '';
            $scope.obj.T_LINK_TEXT = '';
            $scope.obj.T_CONTROL_TEXT_LANG1 = '';
            $scope.obj.T_CONTROL_TEXT_LANG2 = '';
            $scope.obj.t12132 = {};
            $scope.obj.f = {};
            $scope.obj.f.selected = {};
            document.getElementById("txtLabelId").focus();
            document.getElementById("txtSearchBox").value="";
        }


        var alldata = T12132Service.GetGridData();
        alldata.then(function (data) {
            var jsonData = JSON.parse(data);
            $scope.obj.LabelList = jsonData;
        });


        //GetGridData();


        //function GetGridData() {
        //    $scope.Search = '';
        //    var gridData = T12132Service.GetGridData();
        //    gridData.then(function (data) {
        //        $scope.obj.LabelList = JSON.parse(data);
        //    });
        //}

        
        var formCode = T12132Service.getAllFormCodeData();
        formCode.then(function (data) {
            var jsonData = JSON.parse(data);
            $scope.obj.formList = jsonData;
        });


        $scope.Save_Click = function () {
            $scope.obj.t12132.T_FORM_NAME = $scope.obj.f.selected.T_LINK_TEXT;
            var save = T12132Service.saveData($scope.obj.t12132);
            save.then(function (data) {
                alert(data);
                //$scope.obj.t12132 = {};
                //$scope.obj.a.selected = { T_FORM_NAME: '' };
                initializationData();
                var alldata = T12132Service.GetGridData();
                alldata.then(function (data) {
                    var jsonData = JSON.parse(data);
                    $scope.obj.LabelList = jsonData;
                });
            });
        }


        $scope.onRowSelect = function (ind,data) {
            $scope.obj.t12132.T_CONTROL_NAME = data.T_CONTROL_NAME;
            $scope.obj.t12132.T_FORM_NAME = data.T_FORM_NAME;
            $scope.obj.t12132.T_LINK_TEXT = data.T_FORM_NAME;
            $scope.obj.t12132.T_CONTROL_TEXT_LANG1 = data.T_CONTROL_TEXT_LANG1;
            $scope.obj.t12132.T_CONTROL_TEXT_LANG2 = data.T_CONTROL_TEXT_LANG2;
            $scope.obj.t12132.T_LABEL_ID = data.T_LABEL_ID;
            $scope.obj.f.selected = { T_LINK_TEXT: data.T_FORM_NAME };
            $scope.obj.f.selected.T_LINK_TEXT = data.T_FORM_NAME;
        }

    }]);
