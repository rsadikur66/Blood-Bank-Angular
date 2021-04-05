app.controller("T12011Controller", ["$scope", "$filter", "$http", "$window", "T12011Service", "Data",function ($scope, $filter, $http, $window, T12011Service,  Data) { 
    initializationData();
    GetGridData();
    $scope.New = function () { initializationData(); }

    $scope.Clear = function () { initializationData(); }

    function initializationData() {
        $scope.selectedRow = 0;
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T_PRODUCT_CODE = '';
        $scope.obj.T_LANG2_NAME = '';
        $scope.obj.T_LANG1_NAME = '';
        $scope.obj.T_EXPIRY_DAYS = '';
        $scope.obj.T_PROD_PRIORITY = '';
        $scope.obj.T_STORE_AT = '';
        $scope.obj.T_ACTIVE = '';
        $scope.obj.t12011 = {};
        document.getElementById("txtProductCode").focus();
    }

    $scope.Next = function () { GetGridData(); }

    function GetGridData() {
        $scope.Search = '';
        var gridData = T12011Service.GetGridData();
        gridData.then(function (data) {
            $scope.obj.ProductInfo = JSON.parse(data);
        });
    }

    $scope.onRowSelect = function (data) {
        $scope.obj.t12011.T_PRODUCT_CODE = data.T_PRODUCT_CODE;
        $scope.obj.t12011.T_LANG2_NAME = data.T_LANG2_NAME;
        $scope.obj.t12011.T_LANG1_NAME = data.T_LANG1_NAME;
        $scope.obj.t12011.T_EXPIRY_DAYS = data.T_EXPIRY_DAYS;
        $scope.obj.t12011.T_PROD_PRIORITY = data.T_PROD_PRIORITY;
        $scope.obj.t12011.T_STORE_AT = data.T_STORE_AT;
        $scope.obj.t12011.T_ACTIVE = data.T_ACTIVE ;
    }

    $scope.Save = function () {
        var insert = T12011Service.Insert_T12011($scope.obj.t12011);
        insert.then(function (data) {
            var dt = JSON.parse(data);
            alert($scope.getSingleMsg(dt));
            GetGridData();
            initializationData();
        });
    }

    }]);
