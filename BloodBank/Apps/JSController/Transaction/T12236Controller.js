app.controller("T12236Controller", ["$scope", "T12236Service", "$filter", "$http", "$window", "Data",
    function ($scope, T12236Service, $filter, $http, $window, Data) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.UnitInfo = {};
        $scope.obj.t12019 = [];
        document.getElementById('txtUnitFrom').focus();
        ////Get BloodGroup List
        var GetBloodGroupList = T12236Service.GetBloodGroupList();
        GetBloodGroupList.then(function (data) {
            $scope.GetBloodGroupList = JSON.parse(data);
        });

        //Grid Function Start
        $scope.Next = function () {
            var gridData = T12236Service.GetUnitNo($scope.obj.UnitFrom, $scope.obj.UnitTo);
            gridData.then(function (data) {
                var jsonData = JSON.parse(data);
                $scope.obj.UnitInfo = [];
                for (var i = 0; i < jsonData.length; i++) {
                    $scope.obj.test = {};
                    $scope.obj.test.UnitFrom = jsonData[i].T_UNIT_NO;
                    $scope.obj.test.T_ABO_CODE = '';
                    $scope.obj.test.T_ABO_NAME = '';
                    $scope.obj.UnitInfo.push($scope.obj.test);
                }
            });
        }
        $scope.EnterButton = function (event, e) {
            if (event.keyCode === 13) {
                if (e == 'txtUnitFrom')
                    document.getElementById('txtUnitTo').focus();
                if (e == 'txtUnitTo')
                    $scope.Next(e);
            }
            if(event.keyCode === 114) {
                event.preventDefault();
                $scope.Next();
            }
            if (event.keyCode === 114) {
                event.preventDefault();
                $scope.Next();
            }
        }
        $scope.CloseBloodGroupPopup = function () {
            document.getElementById("divBloodGroup").style.display = 'none';
        }
        var indx = '';
        $scope.GetBloodData = function (unit_in) {
            indx = unit_in;
            var bloodGroupList = T12236Service.GetBloodGroupList();
            bloodGroupList.then(function (data) {
                $scope.bloodGroupList = JSON.parse(data);
                if ($scope.bloodGroupList.length > 0) {
                    document.getElementById("divBloodGroup").style.display = 'block';
                } else {
                    alert('No Data is available.');
                }
            });
        }

        //For Select Grid Data
        $scope.obj.UnitInfo = [];
        $scope.obj.NewInfo = [];
        $scope.onBloodSelect = function (index, data) {
            $scope.selectedRow = index;
            for (var i = 0; i < $scope.obj.UnitInfo.length; i++) {
                $scope.newobj = {};
                if (i === indx) {
                    var checkABOCode = T12236Service.CheckABOCode(data.T_ABO_CODE, $scope.obj.UnitInfo[i].UnitFrom);
                    checkABOCode.then(function (data) {
                        var dt = JSON.parse(data);
                        if (dt == 'Blood group not matched') {
                            alert(dt);
                            $scope.newobj.T_ABO_CODE = '';
                            $scope.newobj.T_ABO_NAME = '';
                            return;
                        }
                    });
                    $scope.newobj.UnitFrom = $scope.obj.UnitInfo[i].UnitFrom;
                    $scope.newobj.T_ABO_CODE = data.T_ABO_CODE;
                    $scope.newobj.T_ABO_NAME = data.T_ABO_NAME;
                    $scope.obj.NewInfo.push($scope.newobj);
                    $scope.obj.t12019.push($scope.newobj);
                } else {
                    $scope.newobj.UnitFrom = $scope.obj.UnitInfo[i].UnitFrom;
                    $scope.newobj.T_ABO_CODE = $scope.obj.UnitInfo[i].T_ABO_CODE;
                    $scope.newobj.T_ABO_NAME = $scope.obj.UnitInfo[i].T_ABO_NAME;
                    $scope.obj.NewInfo.push($scope.newobj);
                }
            }
            $scope.obj.UnitInfo = $scope.obj.NewInfo;
            $scope.obj.NewInfo = [];
            document.getElementById("divBloodGroup").style.display = 'none';
        }

        $scope.Clear = function () {
            $scope.obj.UnitFrom = '';
            $scope.obj.UnitTo = '';
            document.getElementById("divBloodGroup").style.display = 'none';
            $scope.obj.UnitInfo = [];
            $scope.obj.t12019 = [];
        }
        ////Blood Group Function End
        $scope.Save = function () {
            var t12019 = $scope.obj.t12019;
            if (t12019.length != '0') {
                var update = T12236Service.updateT12019(t12019);
                update.then(function (data) {
                    var dt = JSON.parse(data);
                    alert(dt);
                    $scope.Next();
                    $scope.obj.t12019 = [];
                });
            }
        }

        $scope.UnitValidate = function (unitNumber, naming) {
            CheckUnit(unitNumber, naming);
        }
        function CheckUnit(unitNo, naming) {
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
                var bloodUnitData = T12236Service.getUnitData(unitNo);
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