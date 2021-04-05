app.controller("T12003Controller", ["$scope", "$filter", "$http", "$window", "T12003Service", "Data",
    function ($scope, $filter, $http, $window, T12003Service, Data) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        //document.getElementById("txtUnitNo0").focus();
        document.getElementById("txtHospitalNo").focus();
        //page load
        
        //blank row start
        $scope.obj.Test = [];
        $scope.obj.NewListv = {};
        $scope.obj.Test.push($scope.obj.NewListv);
        $scope.obj.ProductData = $scope.obj.Test;
        //blank row end

        $scope.btnf9_HospitalList = function(e) {
            if (e.keyCode === 120) {
                e.preventDefault();
                HospitalPopUp();
            }
        };
        $scope.PopUpHospitalList = function () {
            HospitalPopUp();
        };
        $scope.onHospitalSelect = function (i) {
            $scope.obj.T_HOSPITAL_CODE = $scope.HospitalList[i].CODE;
            $scope.obj.T_HOSPITAL_NAME = $scope.HospitalList[i].NAME;
            document.getElementById("divHospitalList").style.display = 'none';
            //document.getElementById("txtUnitTo").focus();
        };
        $scope.CloseHospitalListPopup = function () {
            document.getElementById("divHospitalList").style.display = 'none';
        };
        $scope.SetIssueDate = function() {
            $scope.obj.T_ISSUE_DATE = $filter('date')(new Date(), 'dd/MM/yyyy');
        };
        
        $scope.GetProductWithUnitNo = function (unitNo, index) {
            //console.log($scope.obj.Test);
            var deletedindex = $scope.obj.Test.indexOf(index);
            if (deletedindex == -1) {
                $scope.obj.Test.splice(deletedindex, 1);
            }
            //console.log($scope.obj.Test);
            var GetProduct = T12003Service.GetProductWithUnitNo(unitNo);
            GetProduct.then(function (data) {
                var dummyData = JSON.parse(data);
                for (var i = 0; i < dummyData.length; i++) {
                    $scope.obj.m = {};
                    $scope.obj.m.UnitNo = dummyData[i].T_UNIT_NO;
                    $scope.obj.m.Product = dummyData[i].T_PRODUCT_CODE;
                    $scope.obj.m.BloodGroup = dummyData[i].T_BLOOD_GROUP;
                    $scope.obj.m.ExpiryDate = $filter('date')(dummyData[i].T_EXPIRY_DATE, 'dd/MM/yyyy');
                    $scope.obj.ProductData.push($scope.obj.m);
                }
                gridLine();
                //var d = $scope.obj.ProductData.length - 1;
                //var id = document.getElementById("txtUnitNo" + d); /*txtUnitNo2*/
                ////document.getElementById("txtUnitNo"+d).focus();
                //console.log(id);
            });
        };
        $scope.ProductListPopUp = function() {
            var ProductList = T12003Service.GetProductListData($scope.obj.NewListv.UnitNo);
            ProductList.then(function(data) {
                $scope.ProductList = JSON.parse(data);
                document.getElementById("divProductList").style.display = 'block';
            });
        };
        $scope.onProductSelect = function(i) {
            debugger;
            $scope.obj.NewListv.Product = $scope.ProductList[i].NAME;
            $scope.obj.NewListv.BloodGroup = $scope.ProductList[i].T_ABO_CODE;
            $scope.obj.NewListv.ExpiryDate = $filter('date')($scope.ProductList[i].T_EXPIRY_DATE,'dd/MM/yyyy');
            document.getElementById("divProductList").style.display = 'none';
        };
        $scope.CloseProductPopup = function () {
            document.getElementById("divProductList").style.display = 'none';
        }
        $scope.addnewrow = function() {
            $scope.obj.NewListv = {};
            $scope.obj.Test.push($scope.obj.NewListv);
            $scope.obj.ProductData = $scope.obj.Test;
        }
        $scope.Next = function () {
            $scope.obj.BLOOD_ISSUED_BY = "Mohammad Sadikur Rahman";
            $scope.obj.T_ISSUE_DATE_2 = $filter('date')(new Date(), 'dd/MM/yyyy');
        };
        function gridDummyData() {
            $scope.obj.UnitProducts = [];
            for (var i = 0; i < 5; i++) {
                $scope.obj.test = {};
                $scope.obj.test.UnitNo = '';
                $scope.obj.test.Product = '';
                $scope.obj.test.BloodGroup = " +";
                $scope.obj.test.ExpiryDate = "21/12/2019";
                $scope.obj.test.PatientName = "MD. RAFIQUL ISLAM";
                $scope.obj.UnitProducts.push($scope.obj.test);
                //document.getElementById("VerifyAll").style.display = 'block';
                //document.getElementById('btnNegativeResults').style.cursor = "none";
            }//for lood end
        }
        function gridLine() {
            for (var j = 0; j < 1; j++) {
                $scope.obj.d = {};
                $scope.obj.d.UnitNo = '';

                $scope.obj.d.Product = '';
                $scope.obj.d.BloodGroup = '';
                $scope.obj.d.ExpiryDate = '';
                $scope.obj.Test.push($scope.obj.d);
                $scope.obj.ProductData = $scope.obj.Test;


            }
        }
        function HospitalPopUp() {
            var HospitalList = T12003Service.GetHospitalListData();
            HospitalList.then(function (data) {
                $scope.HospitalList = JSON.parse(data);
            });
            document.getElementById("divHospitalList").style.display = 'block';
        }
        function fnProductList() {
            
        }
    }]);
