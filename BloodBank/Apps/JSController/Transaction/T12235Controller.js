//import { substr } from "../../../Scripts/angular/angular-datatables";

app.controller("T12235Controller", ["$scope", "$filter", "$http", "$window", "T12235Service", "Data",
    function ($scope, $filter, $http, $window, T12235Service, Data) { //$location,
        clear();
        $scope.EnterControl = function (event, controlkeyName) {
            if (event.keyCode === 13) {
                if (controlkeyName === "f") {
                    document.getElementById("txtUnitTo").focus();
                } else if (controlkeyName === "t") {
                    NextData();
                }
            }
            else if (event.keyCode === 114) {
                event.preventDefault();
                NextData();
            }
            else if (event.keyCode === 120) {
                GetUnitData(controlkeyName);
            }
        };
        $scope.GetUnitData = function  (e) {
            GetUnitData(e);
        }
        $scope.onUnitSelect = function (index,obj) {
            if ($scope.type === 'f') {
                //$scope.obj.UnitFrom = $scope.UnitList[index].T_UNIT_NO;
                $scope.obj.UnitFrom = obj.T_UNIT_NO;
                document.getElementById("txtUnitFrom").focus();
            }
            else if ($scope.type === 't') {
                //$scope.obj.UnitTo = $scope.UnitList[index].T_UNIT_NO;
                $scope.obj.UnitTo = obj.T_UNIT_NO;
                document.getElementById("txtUnitTo").focus();
            }
            document.getElementById("divUnit").style.display = 'none';
        }
        $scope.ClosePopup = function (e) {
            document.getElementById(e).style.display = 'none';
        }
        $scope.checkAll = function (p) {
            var e = p.target.defaultValue;
            for (var j = 0; j < $scope.obj.UnitInfo.length; j++) {
                if (e === $scope.getLabel('btnUncheckAll')) {
                    $scope.obj.UnitInfo[j].T_VERIFY = '2';
                } else {
                    $scope.obj.UnitInfo[j].T_VERIFY = '1';
                }
               
            }
            if ($scope.obj.UnitInfo.length > 0) {
                if (e === $scope.getLabel('btnUncheckAll')) {
                    $scope.obj.T_VERIFIED_BY = '';
                    $scope.obj.T_USER_NAME = '';
                    document.getElementById('btnConfirmAll').value = $scope.getLabel('btnConfirmAll');
                } else {
                    var verified = T12235Service.GetVerifidData();
                    verified.then(function (dts) {
                        var dt = JSON.parse(dts);
                        if (dt.length > 0) {
                            $scope.obj.T_VERIFIED_BY = dt[0].T_VERIFIED_BY;
                            $scope.obj.T_USER_NAME = dt[0].T_USER_NAME;
                            document.getElementById('btnConfirmAll').value = $scope.getLabel('btnUncheckAll');

                        }
                    });
                }
            }
        }
        var indx;
        $scope.GetBloodData = function (e) {
            getBloodData(e);
        }
        $scope.onBloodSelect = function (index) {
            var getDuDataList = T12235Service.GetDuData();
            getDuDataList.then(function (data) {
                var jsonData = JSON.parse(data);
                $scope.getdu = jsonData;
                $scope.obj.UnitInfo[indx].T_BLOOD_GROUP = $scope.bloodGroupList[index].T_BLOOD_GROUP;
                $scope.obj.UnitInfo[indx].T_LANG_NAME = $scope.bloodGroupList[index].T_LANG_NAME;
                document.getElementById("divBloodGroup").style.display = 'none';
            });
        }
        var anti;
        $scope.GetAntibodyData = function (e) {
            getAntibodyData(e);
        }
        $scope.onAntibodySelect = function (index) {
            var getAntibodyDataList = T12235Service.GetAntibodyData();
            getAntibodyDataList.then(function (data) {
                var jsonData = JSON.parse(data);
                $scope.getanti = jsonData;
                $scope.obj.UnitInfo[anti].T_ANTIBODY = $scope.AntibodyList[index].T_ANTIBODY;
                $scope.obj.UnitInfo[anti].T_ANTIBODY_1 = $scope.AntibodyList[index].T_ANTIBODY_1;
                document.getElementById("divAntibody").style.display = 'none';
            });
        }
        $scope.chkVerified = function () {
            var c = 0;
            for (var i = 0; i < $scope.obj.UnitInfo.length; i++) {
                if ($scope.obj.UnitInfo[i].T_VERIFY == '1') {
                    c++;
                }
            }
            if (c > 0) {
                var verified = T12235Service.GetVerifidData();
                verified.then(function (dts) {
                    var dt = JSON.parse(dts);
                    if (dt.length > 0) {
                        $scope.obj.T_VERIFIED_BY = dt[0].T_VERIFIED_BY;
                        $scope.obj.T_USER_NAME = dt[0].T_USER_NAME;
                    }
                });
            } else {
                $scope.obj.T_VERIFIED_BY = '';
                $scope.obj.T_USER_NAME = '';
            }
        }
        $scope.GetBloodDatabyKeyPress = function (e, i) {
            if (e.keyCode === 120) {
                e.preventDefault();
                getBloodData(i);
            }
        }
        $scope.GetAntibodyDataKeyPress = function (e, i) {
            if (e.keyCode === 120) {
                e.preventDefault();
                getAntibodyData(i);
            }
        }

        $scope.New = function () { clear(); }
        $scope.Clear = function () { clear(); }
        $scope.Next = function () { NextData(); }
        $scope.Save = function () {
            var k = [];
            var t12235 = $scope.obj.UnitInfo;
            var a = t12235.length;
            if (a > 0) {
                for (var i = 0; i < a; i++) {
                    if (t12235[i].T_BLOOD_GROUP != null) {
                        var t = {};
                        t.T_DU = t12235[i].T_DU;
                        t.T_VERIFY = t12235[i].T_VERIFY;
                        t.T_VERIFIED_BY = t12235[i].T_VERIFY == '1' ? $scope.obj.T_VERIFIED_BY : null;
                        t.T_NOTES = t12235[i].T_NOTES;
                        t.T_UNIT_NO = t12235[i].T_UNIT_NO;
                        t.T_BLOOD_GROUP = t12235[i].T_BLOOD_GROUP;
                        t.ABO = t12235[i].T_BLOOD_GROUP;
                        t.T_NOTES = t12235[i].RESULT;
                        t.T_ANTIBODY = t12235[i].T_ANTIBODY;
                        t.T_ANTIBODY_1 = t12235[i].T_ANTIBODY_1;
                        t.RH_KELL = t12235[i].RH_KELL;
                        t.RH_PHENO = t12235[i].RH_PHENO;
                        t.isInsert = t12235[i].isInsert;
                        k.push(t);
                    }
                }
                var insert = T12235Service.InsertT12220(k);
                insert.then(function (data) {
                    alert(data);
                    //NextData();
                    clear();
                });
            }
        }

        function NextData() {
            $scope.obj.UnitInfo = [];
            var gridData = T12235Service.GetGridData($scope.obj.UnitFrom, $scope.obj.UnitTo);
            gridData.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {

                    for (var i = 0; i < dt.length; i++) {
                        var t = {};
                        t.getdu = [];
                        t.du = {};
                        t.du.selected = { T_DU: '', T_DU_NAME: 'Select' };
                        t.T_VERIFY = dt[i].T_VERIFY;
                        t.T_UNIT_NO = dt[i].T_UNIT_NO;
                        t.T_BLOOD_GROUP = dt[i].T_BLOOD_GROUP;
                        t.T_LANG_NAME = dt[i].T_LANG_NAME;
                        t.T_ANTIBODY = dt[i].T_ANTIBODY;
                        t.T_ANTIBODY_1 = dt[i].T_ANTIBODY_1;
                        t.T_RH_NAME = dt[i].T_RH_NAME;
                        t.RH_KELL = dt[i].RH_KELL;
                        t.RH_PHENO = dt[i].RH_PHENO;
                        t.RESULT = dt[i].RESULT;
                        t.getdu = $scope.obj.duList;
                        t.isInsert = dt[i].T_BLOOD_GROUP != null ? 1 : 0;
                        t.du.selected = { T_DU: dt[i].T_DU == null ? '' : dt[i].T_DU, T_DU_NAME: dt[i].T_DU_NAME == null ? 'Select' : dt[i].T_DU_NAME };
                        $scope.obj.UnitInfo.push(t);
                    }
                    document.getElementById("btnConfirmAll").disabled = false;
                    document.getElementById("btnConfirmAll").style.cursor = 'pointer';

                } else {
                    alert($scope.getSingleMsg('N0043'));
                    document.getElementById("btnConfirmAll").disabled = true;
                    document.getElementById("btnConfirmAll").style.cursor = 'none';
                }
                $scope.obj.T_VERIFIED_BY = '';
                $scope.obj.T_USER_NAME = '';
            });
        }
        function clear() {
              $scope.selectedRow = 0;
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.T12235 = {};
            $scope.UnitList = [];
            $scope.obj.UnitInfo = [];
            $scope.obj.UnitFrom = '';
            $scope.obj.UnitTo = '';
            $scope.obj.T_VERIFIED_BY = '';
            $scope.obj.T_USER_NAME = '';
            document.getElementById("txtUnitFrom").focus();

            var getDuDataList = T12235Service.GetDuData();
            getDuDataList.then(function (data) {
                var jsonData = JSON.parse(data);
                $scope.obj.duList = jsonData;
            });
        }
        function GetUnitData(e) {
            $scope.SearchUnit = '';
            $scope.type = e;
            var UnitList = T12235Service.GetUnitData();
            UnitList.then(function (data) {
                $scope.UnitList = JSON.parse(data);
                if ($scope.UnitList.length > 0) {
                    document.getElementById("divUnit").style.display = 'block';
                } else {
                    alert($scope.getSingleMsg('N0070'));
                    document.getElementById("divUnit").style.display = 'none';

                }
            });
        }

        function getBloodData(e) {
            $scope.SearchBlood = '';
            indx = e;
            var bloodGroupList = T12235Service.GetBloodData();
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

        function getAntibodyData(e) {
            $scope.SearchAntiBody = '';
            anti = e;
            var AntibodyList = T12235Service.GetAntibodyData();
            AntibodyList.then(function (data) {
                $scope.AntibodyList = JSON.parse(data);
                if ($scope.AntibodyList.length > 0) {
                    document.getElementById("divAntibody").style.display = 'block';
                } else {
                    alert($scope.getSingleMsg('N0070'));
                }
            });
        }
        $scope.UnitValidate = function (unitNumber,naming) {
            CheckUnit(unitNumber, naming);
        }
        function CheckUnit(unitNo, naming) {
            debugger;
            if (unitNo !== "") {
                if (unitNo.substr(0, 1) !== '=') {
                    if (naming == 'UnitFrom') {
                        $scope.obj.UnitFrom = '';
                    } else if (naming == 'UnitTo') {
                        $scope.obj.UnitTo = '';
                    }
                    alert('Wrong Unit No');
                    return;
                }
                var bloodUnitData = T12235Service.getUnitData(unitNo);
                bloodUnitData.then(function (data) {
                    var bloodUnit = JSON.parse(data);
                    if (bloodUnit === null) {
                        alert('Wrong Unit No');
                        return;
                    }
                });
                if (naming == 'UnitFrom') {
                    $scope.obj.UnitFrom = unitNo.substr(1, 13);
                } else if (naming == 'UnitTo') {
                    $scope.obj.UnitTo = unitNo.substr(1, 13);
                }

            }//first if end
            
        }//function end
        
    }]);

app.directive('arrowSelector', ['$document', function ($document) {
    return {
        restrict: 'A',
        link: function ($scope, elem, attrs, ctrl) {
            var elemFocus = true;
            $document.bind('keydown', function (e) {
                if (elemFocus) {
                    if (e.keyCode == 38) {
                        if ($scope.selectedRow == 0) {
                            return;
                        }
                        $scope.selectedRow--;
                        $scope.$apply();
                        e.preventDefault();
                       
                    }
                    if (e.keyCode == 40) {
                        if ($scope.selectedRow == $scope.UnitList.length - 1) {
                            return;
                        }
                        $scope.selectedRow++;
                        $scope.$apply();
                        e.preventDefault();
                    }
                    if (e.keyCode == 13) {
                        $scope.$apply(function () {
                            $scope.$eval(attrs.arrowSelector);
                        });
                        e.preventDefault();
                    }
                   
                }
            });
        }
    };
}]);
