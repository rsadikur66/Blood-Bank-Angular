app.controller("T12328Controller", ["$scope", "$filter", "$http", "$window", "T12328Service", "Data",
    function ($scope, $filter, $http, $window, T12328Service, Data) { //$location,
        
        clear();
        function clear() {
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.b = {};
            $scope.obj.b.selected = { NAME: 'Select' };
            $scope.obj.T_UNIT_NO = '';
            $scope.obj.fromDate = '';
            $scope.obj.toDate = '';
            //$scope.obj.selected = '';
            $scope.obj.unitList = [];
            document.getElementById("unitInfo").style.display = "none";
            var bagTypeList = T12328Service.getBagType();
            bagTypeList.then(function (data) {
                $scope.bagTypeList = JSON.parse(data);
            });
        }
     
        $scope.DateSetonEnter = function (e,p) {
            if (e.keyCode===13) {
                $scope.obj.fromDate = $scope.DatewrOnHand(p);
                $scope.obj.toDate = $filter('date')(new Date(), "dd/MM/yyyy");
            }
        }
        $scope.DateSetonBlur = function () {
                $scope.obj.toDate = $filter('date')(new Date(), "dd/MM/yyyy");
        }
        
        $scope.onNextClick = function (u, fD, tD) {
            //if ($scope.obj.selected === '1') {
                //var f = $filter('date')(new Date(fD), "dd-MMM-yyyy");
                //var t = $filter('date')(new Date(tD), "dd-MMM-yyyy");
                var f = $filter('date')($scope.dateParse(fD, "/"), "dd-MMM-yyyy");
                var t = $filter('date')($scope.dateParse(tD, "/"), "dd-MMM-yyyy");
                var getUnitList = T12328Service.getUnitList(u, f, t);
                getUnitList.then(function(data) {
                    var dt = JSON.parse(data);
                    if (dt.length > 0) {
                        document.getElementById("unitInfo").style.display = "inline-block";
                        $scope.obj.unitList = dt;
                    } else {
                        //alert('Please select Date or Unit No');
                        document.getElementById("unitInfo").style.display = "none";
                    }

                });
            //} else {
            //    alert('Please select Bag Type');
            //    document.getElementById("unitInfo").style.display = "none";
            //}
        }

        //$scope.onbagTypeSelect = function() {
        //    $scope.obj.selected = '1';
        //    $scope.obj.unitList = [];
        //    //document.getElementById("unitInfo").style.display = "none";
        //}
        $scope.getUnitList = function(e) {
            if (e.keyCode===114) {
                e.preventDefault();
                $scope.onNextClick($scope.obj.T_UNIT_NO, $scope.obj.fromDate, $scope.obj.toDate);
            }
        }
        $scope.validateUnit = function (e, i) {
            if (document.getElementById('chkRecieve' + i).checked === true) {
                $scope.obj.unitList[i].T_WEIGHT_CODE = null;
                $scope.obj.unitList[i].T_UNIT_WEIGHT = null;
                $scope.obj.unitList[i].T_EMP_NAME = null;
                $scope.obj.unitList[i].T_RECEIVED_USER = null;
                $scope.obj.unitList[i].T_RECEIVED_DATE = null;  
                document.getElementById('chkRecieve' + i).checked = false;
            }
            if (e.keyCode === 13 || e.keyCode === 9) {
                var weight = $scope.obj.unitList[i].T_UNIT_WEIGHT;
                var bagType = $scope.obj.b.selected.T_UNIT_TYPE;
                var validateWeight = T12328Service.validateWeight(weight, bagType);
                validateWeight.then(function (data) {
                    var dt = JSON.parse(data);
                    if (dt.length>0) {
                        $scope.obj.unitList[i].T_WEIGHT_CODE = dt[0].T_WEIGHT_CODE;
                        document.getElementById('chkRecieve' + i).focus();
                    } else {
                        alert('Please enter a valid weight or Bag Type');
                        $scope.obj.unitList[i].T_WEIGHT_CODE = null;
                        $scope.obj.unitList[i].T_UNIT_WEIGHT = null;
                        $scope.obj.unitList[i].T_EMP_NAME = null;
                        $scope.obj.unitList[i].T_RECEIVED_USER = null;
                        $scope.obj.unitList[i].T_RECEIVED_DATE = null;
                        document.getElementById('chkRecieve' + i).checked = false;                      

                    }
                    

                });
                
            }
        }
          $scope.validateUnit_blur = function (i) {
            if (document.getElementById('chkRecieve' + i).checked === true) {
                $scope.obj.unitList[i].T_WEIGHT_CODE = null;
                $scope.obj.unitList[i].T_UNIT_WEIGHT = null;
                $scope.obj.unitList[i].T_EMP_NAME = null;
                $scope.obj.unitList[i].T_RECEIVED_USER = null;
                $scope.obj.unitList[i].T_RECEIVED_DATE = null;  
                document.getElementById('chkRecieve' + i).checked = false;
            }
            //if (e.keyCode === 13 || e.keyCode === 9) {
                var weight = $scope.obj.unitList[i].T_UNIT_WEIGHT;
                var bagType = $scope.obj.b.selected.T_UNIT_TYPE;
                var validateWeight = T12328Service.validateWeight(weight, bagType);
                validateWeight.then(function (data) {
                    var dt = JSON.parse(data);
                    if (dt.length>0) {
                        $scope.obj.unitList[i].T_WEIGHT_CODE = dt[0].T_WEIGHT_CODE;
                        document.getElementById('chkRecieve' + i).focus();
                    } else {
                        alert('Please enter a valid weight or Bag Type');
                        $scope.obj.unitList[i].T_WEIGHT_CODE = null;
                        $scope.obj.unitList[i].T_UNIT_WEIGHT = null;
                        $scope.obj.unitList[i].T_EMP_NAME = null;
                        $scope.obj.unitList[i].T_RECEIVED_USER = null;
                        $scope.obj.unitList[i].T_RECEIVED_DATE = null;
                        document.getElementById('chkRecieve' + i).checked = false;                      

                    }
                    

                });
                
           // }
        }
        $scope.onRecieve = function (e, i) {
            var weight = $scope.obj.unitList[i].T_UNIT_WEIGHT;
            if (e === true && weight!==null) {
                    var getReciever = T12328Service.getReciever();
                    getReciever.then(function (data) {
                        var dt = JSON.parse(data);
                        $scope.obj.unitList[i].T_EMP_NAME = dt.split(",")[0];
                        $scope.obj.unitList[i].T_RECEIVED_USER = dt.split(",")[1];
                        $scope.obj.unitList[i].T_RECEIVED_DATE = $filter('date')(new Date(), "dd-MMM-yyyy");;
                    }); 
              
                
            } else {
                $scope.obj.received = false;
                document.getElementById('chkRecieve' + i).checked = false;
                $scope.obj.unitList[i].T_EMP_NAME =null;
                $scope.obj.unitList[i].T_RECEIVED_USER = null;
                $scope.obj.unitList[i].T_RECEIVED_DATE = null;
            }
        }
        $scope.insert = function () {
            var l = $scope.obj.unitList;
            var a = [];
            if (l.length>0) {
                for (var i = 0; i < l.length; i++) {
                    if (l[i].received===true) {
                        var t = {};
                        t.T_UNIT_NO = l[i].T_UNIT_NO;
                        t.T_DONATION_DATE = $filter('date')(new Date(l[i].T_DONATION_DATE), "dd-MMM-yyyy");
                        t.T_WEIGHT_CODE = l[i].T_WEIGHT_CODE;
                        t.T_BAG_TYPE = $scope.obj.b.selected.T_UNIT_TYPE;
                        a.push(t);
                    }
                }
            }
            if (a.length>0) {
                var insert = T12328Service.insert(a);
                insert.then(function (data) {
                    var dt = JSON.parse(data);
                    alert(dt);
                    $scope.onNextClick($scope.obj.T_UNIT_NO, $scope.obj.fromDate, $scope.obj.toDate);
                });
            }
           
        }
        $scope.clear = function() {
            clear();
        }
       // $scope.t = '';
       // $scope.toggled = false;
       // $scope.visibility = false;
       //// $scope.dbclck = false;
       // //$scope.cal= function() {
       // //    $scope.visibility = true;
       // //    $scope.t = '_720kb-datepicker-open';
       // //}
       ////$scope.visibility = false;
       // //$scope.toggled = false;
       // //$scope.t = '_720kb-datepicker-open';

       // $scope.toggle = function () {
       //    // $scope.dbclck = true;
       //     //$scope.t = '_720kb-datepicker-open';
       //     $scope.visibility = !$scope.visibility;
       //     $scope.toggled = !$scope.toggled;
       //     //$scope.dbclck =!$scope.dbclck;
       // }
        $scope.UnitValidate = function(unitNumber) {
            CheckUnit(unitNumber);
        }
        function CheckUnit(unitNo) {
            
            if (unitNo !== "") {
                if (unitNo.substr(0, 1) !== '=') {
                    $scope.obj.T_UNIT_NO = '';
                    alert('Wrong Unit No');
                    return;
                }
                var bloodUnitData = T12328Service.getUnitData(unitNo);
                bloodUnitData.then(function (data) {
                    var bloodUnit = JSON.parse(data);
                    if (bloodUnit === null) {
                        alert('Wrong Unit No');
                        return;
                    }
                });
                $scope.obj.T_UNIT_NO = unitNo.substr(1, 13);
                //alert(unitNo);
            }//first if end
        }//function end
        
       
    }]);




