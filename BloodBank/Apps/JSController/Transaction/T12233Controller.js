app.controller("T12233Controller", ["$scope", "$filter", "$http", "$window", "T12233Service","T12241Service","Data",
    function ($scope, $filter, $http, $window, T12233Service, T12241Service, Data) {
        initializationData();
        
        function initializationData() {
            $scope.selectedRow = 0;
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.T12233 = {};
            $scope.obj.UnitInfo = [];
            document.getElementById("txtUnitNo").focus();
            var getVerifyList = T12233Service.GetVerifyData();
            getVerifyList.then(function (data) {
                var jsonData = JSON.parse(data);
                $scope.obj.getverify = jsonData;
            });
            document.getElementById("maingrid").style.display = 'none';
        }
        $scope.Next = function () { NextData(); }
        $scope.EnterControl = function (event, controlkeyName) {
            if (event.keyCode === 13) {
                    NextData();
            }else if (event.keyCode === 114) {
                event.preventDefault();
                NextData();
            }
            else if (event.keyCode === 120) {
                GetUnitData(controlkeyName);
            }
        };
        angular.element(document.getElementById('btnSave'))[0].disabled = true;
        function NextData() {
            $scope.obj.UnitInfo = [];
            var gridData = T12233Service.GetGridData($scope.obj.T_UNIT_NO);
            gridData.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    for (var i = 0; i < dt.length; i++) {
                        var t = {};
                        t.obj = {};
                        t.getverify = {};
                        t.verify = {};
                        t.T_UNIT_NO = dt[i].T_UNIT_NO;
                        t.T_VIRUS_CODE = dt[i].T_VIRUS_CODE;
                        t.VIRUS_DESC = dt[i].VIRUS_DESC;
                        t.VIROLOGY_TEST_BY = dt[i].USER_NAME_BY;
                        t.T_POS1_VERIFIED_BY = dt[i].T_POS1_VERIFIED_BY;
                        t.T_POS1_VERIFIED_DATE = dt[i].T_POS1_VERIFIED_DATE;
                        t.T_SEND_FLAG = dt[i].T_SEND_FLAG;
                        t.T_LAB_REQ_NO = dt[i].T_LAB_REQ_NO;
                        t.T_LAB_REQ_DATE = dt[i].T_LAB_REQ_DATE;
                        t.getverify = $scope.obj.getverify;
                        if (dt[i].T_POS2_VERIFY == 'Yes') {
                            t.verify.selected = { T_POS2_VERIFY: '2', T_VERIFY: dt[i].T_POS2_VERIFY };
                        } else if (dt[i].T_POS2_VERIFY == 'No') {
                            t.verify.selected = { T_POS2_VERIFY: '1', T_VERIFY: dt[i].T_POS2_VERIFY };
                        }
                        //if (t.T_LAB_REQ_DATE !== null) {
                        //    t.HiddenValue = '2';
                        //}
                        t.HiddenValue = t.T_LAB_REQ_DATE !== null ? t.HiddenValue = '2' : '';
                        
                        //t.verify.selected = { T_POS2_VERIFY: dt[i].T_POS2_VERIFY};
                        $scope.obj.UnitInfo.push(t);
                        document.getElementById("maingrid").style.display = 'block';
                    }

                } else {
                    alert($scope.getSingleMsg('N0043'));
                    document.getElementById("maingrid").style.display = 'none';
                }
                
            });
            
        }
        $scope.GetUnitData = function (e) {
            GetUnitData(e);
        }
        function GetUnitData() {
            $scope.SearchUnit = '';
            var unitGroupList = T12233Service.GetUnitData();
            unitGroupList.then(function (data) {
                $scope.unitGroupList = JSON.parse(data);
                if ($scope.unitGroupList.length > 0) {
                    document.getElementById("divUnitGroup").style.display = 'block';
                } else {
                    alert($scope.getSingleMsg('N0070'));
                    document.getElementById("divUnitGroup").style.display = 'none';
                }
            });
        }
        $scope.onUnitSelect = function (index) {
            $scope.obj.T_UNIT_NO = $scope.unitGroupList[index].T_UNIT_NO;
            document.getElementById("txtUnitNo").focus();
            document.getElementById("divUnitGroup").style.display = 'none';
        }
        $scope.ClosePopup = function (e) {
            document.getElementById(e).style.display = 'none';
        }

        //$scope.checked = function (index) {
        //    var firstCompoCheck = document.getElementById("chksend" + index).checked;
        //    //alert(firstCompoCheck);
        //    if (firstCompoCheck == true) {
        //        $scope.obj.UnitInfo[index].T_LAB_REQ_DATE = $filter('date')(new Date(), 'dd/MM/yyyy');

        //    } else {
        //        $scope.obj.UnitInfo[index].T_LAB_REQ_DATE = '';
        //    }
        //}

        $scope.SendToLabCheckboxClicked = function (index) {
            var firstCompoCheck = document.getElementById("chksend" + index).checked;
            //alert(firstCompoCheck);
            if (firstCompoCheck == true) {
                var checkIsDoctor = T12241Service.DocEmpCode();
                checkIsDoctor.then(function(data) {
                    var testData = JSON.parse(data);
                    if (testData.length > 0) {
                        $scope.obj.UnitInfo[index].T_LAB_REQ_DATE = $filter('date')(new Date(), 'dd/MM/yyyy');
                        angular.element(document.getElementById('btnSave'))[0].disabled = false;

                    } else {
                        alert('Only Doctor can verify.');
                        document.getElementById("chksend" + index).checked = false;
                       
                    }
                });


            } else {
                $scope.obj.UnitInfo[index].T_LAB_REQ_DATE = '';
                angular.element(document.getElementById('btnSave'))[0].disabled = true;
            }

        }

        $scope.Save = function () {
            var k = [];
            var t12233 = $scope.obj.UnitInfo;
            var a = t12233.length;
            if (a > 0) {
                for (var i = 0; i < a; i++) {
                    if (t12233[i].T_SEND_FLAG != null) {
                        var t = {};
                        t.T_UNIT_NO = t12233[i].T_UNIT_NO;
                        t.T_VIRUS_CODE = t12233[i].T_VIRUS_CODE;
                        //t.T_POS2_VERIFY = t12233[i].T_POS2_VERIFY == '1' ? $scope.obj. T_VERIFY: null;
                        t.T_POS2_VERIFY = t12233[i].T_POS2_VERIFY;
                        t.T_POS2_VERIFIED_BY = t12233[i].T_POS1_VERIFIED_BY;
                        t.T_POS2_VERIFIED_DATE = t12233[i].T_POS1_VERIFIED_DATE;
                        t.T_SEND_FLAG = t12233[i].T_SEND_FLAG;
                        t.T_LAB_REQ_NO = t12233[i].T_LAB_REQ_NO;
                        t.T_LAB_REQ_DATE = t12233[i].T_LAB_REQ_DATE;
                        t.isInsert = t12233[i].isInsert;
                        k.push(t);
                    }
                }
                var insert = T12233Service.Insert_T13016(k);
                insert.then(function (data) {
                    alert(data);
                    NextData();
                });
            }
        }

        $scope.checkvalue = function (i) {
            if ($scope.obj.UnitInfo[i].HiddenValue !== '') {
                return true;
            } else {
                return false;   
            }
        }

        $scope.UnitValidate = function (unitNumber) {
            CheckUnit(unitNumber);
        }
        function CheckUnit(unitNo) {
            if (unitNo !== "") {
                if (unitNo.substr(0, 1) !== '=') {
                    $scope.obj.T_UNIT_NO = '';
                    alert('Wrong Unit No');
                    return;
                }
                var bloodUnitData = T12233Service.getUnitData(unitNo);
                bloodUnitData.then(function (data) {
                    var bloodUnit = JSON.parse(data);
                    if (bloodUnit === null) {
                        alert('Wrong Unit No');
                        return;
                    }
                });
                $scope.obj.T_UNIT_NO = unitNo.substr(1, 13);
            }//first if end

        }//function end
    }]);