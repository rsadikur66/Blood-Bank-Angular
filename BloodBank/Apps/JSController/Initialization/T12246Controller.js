app.controller("T12246Controller", ["$scope", "$filter", "$http", "$window", "T12246Service", "Data",
    function ($scope, $filter, $http, $window, T12246Service, Data) { //$location,
        initializationData();
        $scope.New = function () {initializationData();}

        $scope.Clear = function () {initializationData();}

        function initializationData() {
            $scope.selectedRow = 0;
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.T_PRODUCT_CODE = '';
            $scope.obj.T_NAME = '';
            $scope.obj.T_BLOOD_GROUP = '';
            $scope.obj.T_LANG_NAME = '';
            document.getElementById("txtProcuctCode").focus();
        }

        $scope.GetProductData = function () {
            GetProductData();
        }

        function GetProductData() {
            $scope.SearchProduct = '';
            var ProductList = T12246Service.GetProductData();
            ProductList.then(function (data) {
                $scope.ProductList = JSON.parse(data);
                if ($scope.ProductList.length > 0) {
                    document.getElementById("divProduct").style.display = 'block';
                } else {
                    alert($scope.getSingleMsg('N0070'));
                    document.getElementById("divProduct").style.display = 'none';
                }
            });
        }

        $scope.onProductSelect = function (index) {
            $scope.obj.T_PRODUCT_CODE = $scope.ProductList[index].T_PRODUCT_CODE;
            $scope.obj.T_NAME = $scope.ProductList[index].T_NAME;
            document.getElementById("divProduct").style.display = 'none';
            document.getElementById("txtPatBloodGroup").focus();
        }

        $scope.ClosePopup = function (e) {
            document.getElementById(e).style.display = 'none';
        }

        $scope.GetBloodData = function () {
            GetBloodData();
        }

        function GetBloodData() {
            $scope.SearchBlood = '';
            var bloodGroupList = T12246Service.GetBloodData();
            bloodGroupList.then(function (data) {
                $scope.bloodGroupList = JSON.parse(data);
                if ($scope.bloodGroupList.length > 0) {
                    document.getElementById("divBloodGroup").style.display = 'block';
                } else {
                    alert($scope.getSingleMsg('N0070'));
                    document.getElementById("divBloodGroup").style.display = 'none';
                }
            });
        }

        $scope.onBloodSelect = function (index) {
            $scope.obj.T_BLOOD = $scope.bloodGroupList[index].T_BLOOD_GROUP;
            $scope.obj.T_LANG_NAME = $scope.bloodGroupList[index].T_LANG_NAME;
            document.getElementById("divBloodGroup").style.display = 'none';
            document.getElementById("txtPatBloodGroup").focus();
        }

        $scope.ClosePopup = function (e) {
            document.getElementById(e).style.display = 'none';
        }

        $scope.Next = function () { NextData(); }

        $scope.EnterControl = function (event, controlkeyName) {
            if (event.keyCode === 13) {
                    NextData();
            }
            else if (event.keyCode === 114) {
                event.preventDefault();
                NextData();
            }
            else if (event.keyCode === 120) {
                if (controlkeyName === "a") {
                    GetProductData(controlkeyName);
                } else if (controlkeyName === "b") {
                    GetBloodData(controlkeyName);
                }
            }
        };

        function NextData() {
            $scope.obj.BloodInfo = [];
            var gridData = T12246Service.GetGridData($scope.obj.T_PRODUCT_CODE, $scope.obj.T_BLOOD);
            gridData.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    for (var i = 0; i < dt.length; i++) {
                        var t = {};
                        t.obj = {};
                        t.T_BLOOD_GROUP = dt[i].T_BLOOD_GROUP;
                        t.T_LANG_NAME = dt[i].T_LANG_NAME;
                        if (dt[i].T_TECH==null) {
                            t.T_TECH = '2';
                        } else {
                            t.T_TECH = dt[i].T_TECH;
                        }
                       
                        $scope.obj.BloodInfo.push(t);
                        document.getElementById("maingrid").style.display = 'block';
                    }

                } else {
                    alert($scope.getSingleMsg('N0043'));
                    document.getElementById("maingrid").style.display = 'none';
                }

            });

        }

        $scope.Save = function () {
           
            var p = $scope.obj.T_PRODUCT_CODE;
            var b = $scope.obj.T_BLOOD;
            var insert = T12246Service.Insert_T12211($scope.obj.BloodInfo,p,b);
            insert.then(function (data) {
                var dt = JSON.parse(data);
                    alert($scope.getSingleMsg(dt));
                    NextData();
                });
            //}
        }
    }]);