app.controller("R12016Controller", ["$scope", "Data", "R12016Service","$window",
    function ($scope, Data, R12016Service, $window) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.formUnit = '';
        $scope.obj.toUnit = '';
        $scope.obj.ProductCode = '';

        $scope.obj.T_PAT_NO = '00000003';
        
        $scope.getUnitList = function (t) {
            $scope.type = '';
            var unitList = R12016Service.getUnit();
            unitList.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length>0) {
                    $scope.obj.UnitList = dt;
                    $scope.type = t;
                    document.getElementById("divUnit").style.display = "inline-block";
                    
                } else {
                    alert('Data Not Found');
                    document.getElementById("divUnit").style.display = "none";
                    return;
                }
               
            });
        }
        $scope.onUnitSelect = function(i) {
            if ($scope.type=='f') {
                $scope.obj.formUnit = $scope.obj.UnitList[i].T_UNIT_NO;
            }
            else if ($scope.type == 't') {
                $scope.obj.toUnit = $scope.obj.UnitList[i].T_UNIT_NO;
            }
            document.getElementById("divUnit").style.display = "none";
            $scope.type = '';
        }
        $scope.CloseUnitPopup = function () {
            document.getElementById("divUnit").style.display = "none";
            $scope.type = '';
        }

        $scope.getProductList = function () {
            var f = $scope.obj.formUnit;
            var t = $scope.obj.toUnit;

            if (f == '' || t == '' ) {
                alert('Please Select both of the units');
                return;
            }
            var getPRCode = R12016Service.getPRCode(f,t);
            getPRCode.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    $scope.obj.ProductList = dt;
                    document.getElementById("divProduct").style.display = "inline-block";

                } else {
                    alert('Data Not Found');
                    document.getElementById("divProduct").style.display = "none";
                    return;
                }

            });
        }
        $scope.onProductSelect = function (i) {
            $scope.obj.ProductCode = $scope.obj.ProductList[i].T_PRODUCT_CODE;
            $scope.obj.ProductDesc = $scope.obj.ProductList[i].PRODUCT_DESC;
            document.getElementById("divProduct").style.display = "none";
        }
        $scope.CloseProductPopup = function () {
            document.getElementById("divProduct").style.display = "none";
        }

        $scope.obj.onPrint = function () {
            var f=$scope.obj.formUnit;
            var t=$scope.obj.toUnit;
            var p = $scope.obj.ProductCode;
            //if (f!=''&&t!=''&&p!='') {
                $window.open("../R12016/getReport?from=" + f + "&&to=" + t + "&&prod=" + p , "popup", "width=600,height=600,left=100,top=50");
            //} else {
               // alert('Please select Both Unit and Product');
            //}
             
        }

        $scope.T12304_print = function () {
            $window.open("../R12006/getR12006_Report?patNo=" + $scope.obj.T_PAT_NO, "popup", "width=600,height=600,left=100,top=50");
        }
        
    }]);
