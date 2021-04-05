app.controller("T12207Controller", ["$scope", "$filter", "T12207Service", "Data", "$interval",
    function ($scope, $filter, T12207Service, Data, $interval) {
        initializationData();
        $scope.New = function () { initializationData(); }
        $scope.Clear = function () { initializationData(); }
        function initializationData() {
            $scope.selectedRow = 0;
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.disableCheck = '';
            $scope.obj.t12207 = {};
            $scope.obj.t12207.T_BLOOD_REQNO = '';
            $scope.obj.t12207.T_BLOOD_REQDATE = '';
            $scope.obj.t12207.T_BLOOD_REQTIME = '';
            $scope.obj.t12207.T_REF_HOSP = '';
            $scope.obj.t12207.T_LANG_NAME = '';
            $scope.obj.t12207.T_BLOOD_GRP = '';
            $scope.obj.t12207.T_NAME = '';
            $scope.obj.t12207.T_PRODUCT_CODE = '';
            $scope.obj.t12207.T_LAN_NAME = '';
            $scope.obj.t12207.T_NUM_UNIT = '';
            $scope.obj.t12207.T_CROSSMATCH_FLAG = '';
            $scope.disabledField = true;
            $scope.obj.t12207.T_BLOOD_REQDATE = $filter('date')(new Date(), 'dd/MM/yyyy');
            $scope.obj.t12207.T_BLOOD_REQTIME = Time();
            document.getElementById("txtRefHospitalCode").focus();
            LoadGridData();
        }
        function Time() {
            var date = new Date();
            var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
            var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
            var gettime = hours + '' + minutes;
            return gettime;
        }
        //Refereal Hospital Function Start
        $scope.GetRefHospital = function (e) {
            GetRefHospital(e);
        }
        function GetRefHospital() {
            $scope.SearchRefHospital = '';
            var RefHospitalList = T12207Service.GetRefHospital();
            RefHospitalList.then(function (data) {
                $scope.RefHospitalList = JSON.parse(data);
                if ($scope.RefHospitalList.length > 0) {
                    document.getElementById("divRefHospital").style.display = 'block';
                } else {
                    alert($scope.getSingleMsg('N0070'));
                    document.getElementById("divRefHospital").style.display = 'none';
                }
            });
        }
        $scope.onRefHospitalSelect = function (index) {
            $scope.obj.t12207.T_REF_HOSP = $scope.RefHospitalList[index].T_REF_HOSP;
            $scope.obj.t12207.T_LANG_NAME = $scope.RefHospitalList[index].T_LANG_NAME;
            document.getElementById("divRefHospital").style.display = 'none';
            document.getElementById("txtBloodGroup").focus();
        }
        $scope.ClosePopup = function (e) {
            document.getElementById(e).style.display = 'none';
        }
        //Blood Group Function Start
        $scope.GetBlood = function (e) {
            GetBlood(e);
        }
        function GetBlood() {
            $scope.SearchBlood = '';
            var BloodList = T12207Service.GetBlood();
            BloodList.then(function (data) {
                $scope.BloodList = JSON.parse(data);
                if ($scope.BloodList.length > 0) {
                    document.getElementById("divBloodData").style.display = 'block';
                } else {
                    alert($scope.getSingleMsg('N0070'));
                    document.getElementById("divBloodData").style.display = 'none';
                }
            });
        }
        $scope.onBloodSelect = function (index) {
            $scope.obj.t12207.T_BLOOD_GRP = $scope.BloodList[index].T_BLOOD_GRP;
            $scope.obj.t12207.T_NAME = $scope.BloodList[index].T_NAME;
            document.getElementById("divBloodData").style.display = 'none';
            document.getElementById("txtProd").focus();
        }
        $scope.ClosePopup = function (e) {
            document.getElementById(e).style.display = 'none';
        }
        //Product Function Start
        $scope.GetProduct = function (e) {
            GetProduct(e);
        }
        function GetProduct() {
            $scope.SearchProduct = '';
            var ProductList = T12207Service.GetProduct();
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
            $scope.obj.t12207.T_PRODUCT_CODE = $scope.ProductList[index].T_PRODUCT_CODE;
            $scope.obj.t12207.T_LAN_NAME = $scope.ProductList[index].T_LAN_NAME;
            document.getElementById("divProduct").style.display = 'none';
            document.getElementById("txtNoOfUnit").focus();
            if ($scope.obj.t12207.T_PRODUCT_CODE == "PRBC") {
                $scope.disabledField = false;
            } else {
                $scope.disabledField = true;
            }
        }
        $scope.ClosePopup = function (e) {
            document.getElementById(e).style.display = 'none';
        }
        $scope.Save = function () {
            if ($scope.obj.t12207.T_REF_HOSP == '' || $scope.obj.t12207.T_REF_HOSP == null) {
                alert('Ref Hospital is Required.');
                return;
            }
            if ($scope.obj.t12207.T_BLOOD_GRP == '' || $scope.obj.t12207.T_BLOOD_GRP == null) {
                alert('Blood Group is Required.');
                return;
            } if ($scope.obj.t12207.T_PRODUCT_CODE == '' || $scope.obj.t12207.T_PRODUCT_CODE == null) {
                alert('Product is Required.');
                return;
            } if ($scope.obj.t12207.T_NUM_UNIT == '' || $scope.obj.t12207.T_NUM_UNIT == null) {
                alert('No of unit is Required.');
                return;
            }
            var insert = T12207Service.Insert_T12207($scope.obj.t12207);
            insert.then(function (data) {
                var dt = JSON.parse(data);
                alert($scope.getSingleMsg(dt));
                initializationData();
            });
        }        
        
        function LoadGridData() {
            var gridData = T12207Service.getGridDataForTransfusion();
            gridData.then(function (data) {
                $scope.gridDataList = JSON.parse(data);
                if ($scope.gridDataList.length > 0) {
                    $scope.obj.GridForTransfustion = [];
                    for (var i = 0; i < $scope.gridDataList.length; i++) {
                        $scope.obj.test = {};
                        $scope.obj.test.T_BLOOD_REQNO = $scope.gridDataList[i].T_BLOOD_REQNO;
                        $scope.obj.test.T_BLOOD_REQDATE = $scope.gridDataList[i].T_BLOOD_REQDATE;
                        $scope.obj.test.T_BLOOD_REQTIME = $scope.gridDataList[i].T_BLOOD_REQTIME;
                        $scope.obj.test.T_REF_HOSP = $scope.gridDataList[i].T_REF_HOSP;
                        $scope.obj.test.CENTR_HOSP_NAME = $scope.gridDataList[i].CENTR_HOSP_NAME;
                        $scope.obj.test.T_BB_RECEIVED_FLAG = $scope.gridDataList[i].T_BB_RECEIVED_FLAG;
                        $scope.obj.test.T_BB_RECEIVED_DATE = $scope.gridDataList[i].T_BB_RECEIVED_DATE;
                        $scope.obj.test.T_BB_RECEIVED_TIME = $scope.gridDataList[i].T_BB_RECEIVED_TIME;
                        $scope.obj.test.T_BB_RECEIVED_BY = $scope.gridDataList[i].T_BB_RECEIVED_BY;
                        $scope.obj.test.T_BB_ISSUED_DATE = $scope.gridDataList[i].T_BB_ISSUED_DATE;
                        $scope.obj.test.T_BB_ISSUED_TIME = $scope.gridDataList[i].T_BB_ISSUED_TIME;
                        $scope.obj.test.T_DELIVERY_MAN = $scope.gridDataList[i].T_DELIVERY_MAN;
                        $scope.obj.test.DEL_CODE = $scope.gridDataList[i].DEL_CODE;
                        $scope.obj.test.T_EST_DEL_TIME = $scope.gridDataList[i].T_EST_DEL_TIME;
                        $scope.obj.test.T_REQUEST_STATUS = $scope.gridDataList[i].T_REQUEST_STATUS;
                        $scope.obj.test.T_TRANSF_STATUS = $scope.gridDataList[i].T_TRANSF_STATUS;                        
                        $scope.obj.test.T_REQ_ACCEPT_FLG = $scope.gridDataList[i].T_REQ_ACCEPT_FLG;
                        $scope.obj.test.T_REQ_CANCEL_FLG = $scope.gridDataList[i].T_REQ_CANCEL_FLG;
                        $scope.obj.test.T_BLOOD_RCVD_FLG = $scope.gridDataList[i].T_BLOOD_RCVD_FLG;
                        $scope.obj.test.T_BLOOD_DROP_FLG = $scope.gridDataList[i].T_BLOOD_DROP_FLG;
                        $scope.obj.test.ACC_DT = $scope.gridDataList[i].ACC_DT;
                        $scope.obj.test.CAN_DT = $scope.gridDataList[i].CAN_DT;
                        $scope.obj.test.RCV_DT = $scope.gridDataList[i].RCV_DT;
                        $scope.obj.test.DROP_DT = $scope.gridDataList[i].DROP_DT;
                        //$scope.obj.test.T_TRANSF_STATUS = $scope.gridDataList[i].ACC_DT != " " ? "Delivery Accept" : $scope.obj.test.T_TRANSF_STATUS;
                        //$scope.obj.test.T_TRANSF_STATUS = $scope.gridDataList[i].CAN_DT != " " ? "Del Cancel" : $scope.obj.test.T_TRANSF_STATUS;
                        //$scope.obj.test.T_TRANSF_STATUS = $scope.gridDataList[i].RCV_DT != " " ? "Delivery Received" : $scope.obj.test.T_TRANSF_STATUS;
                        if ($scope.gridDataList[i].T_BLOOD_DROP_FLG == '1') {
                            $scope.obj.test.disableCheck = '';
                            //$scope.obj.test.T_TRANSF_STATUS = "Delivery Droped";
                        } else {
                            $scope.obj.test.disableCheck = 'disabled';
                            
                        }
                        $scope.obj.GridForTransfustion.push($scope.obj.test);
                    }
                }
                //else {
                //    //alert('No data available');
                //}
            });
        }
        $scope.BloodReceiveFromTransfusion = function (i, j) {                        
            var save = T12207Service.bloodReceiveFromTransfusion(j.DEL_CODE, j.T_BLOOD_REQNO);
            save.then(function (data) {
                var dt = JSON.parse(data);
                LoadGridData();                
                alert($scope.getSingleMsg(dt));                
            });
        }
        $interval(function () {
            LoadGridData();
        }, 15000);
        
        
    }]);


app.directive('numbersOnly', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {
                    var transformedInput = text.replace(/[^0-9]/g, '');

                    if (transformedInput !== text) {
                        ngModelCtrl.$setViewValue(transformedInput);
                        ngModelCtrl.$render();
                    }
                    return transformedInput;
                }
                return undefined;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    };
});