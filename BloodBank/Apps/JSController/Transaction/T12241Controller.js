app.controller("T12241Controller", ["$scope", "T12241Service", "$filter", "$http", "$window", "Data",
    function ($scope, T12241Service, $filter, $http, $window, Data) {
        $scope.obj = {};
        $scope.obj = Data;
        document.getElementById("1stDiv").style.display = 'none';
        document.getElementById("txtUnitFrom").focus();
        //page load

        function fnGetGridData() {
            document.getElementById("1stDiv").style.display = 'block';
            var virologyGridResult = T12241Service.GridResultVirology($scope.obj.T_UNIT_NO_FROM, $scope.obj.T_UNIT_NO_TO);
            virologyGridResult.then(function (data) {
                var testData = JSON.parse(data);
                if (testData.length>0) {
                    $scope.obj.Virology = [];
                    for (var i = 0; i < testData.length; i++) {
                        $scope.obj.test = {};
                        $scope.obj.test.UnitNo = testData[i].T_UNIT_NO;
                        $scope.obj.test.SegmentNo = testData[i].T_SEGMENT_NO;
                        //$scope.obj.test.T_LANG2_NAME = testData[i].T_LANG2_NAME;
                        $scope.obj.test.DonationDate = testData[i].T_DONATION_DATE;
                        $scope.obj.test.EnteredBy_Code = testData[i].T_EMP_CODE;
                        $scope.obj.test.EnteredBy_Name = testData[i].T_USER_NAME;
                        if (testData[i].T_NEG_VERIFY === '1') {
                            $scope.obj.test.VIROLOGY_CHECK = true;
                            $scope.obj.test.VerifyBy_Code = testData[i].T_NEG_VARIFY_BY;
                            $scope.obj.test.VerifyBy_Name = testData[i].T_NEG_VARIFY_BY_NAME;
                            $scope.obj.test.HiddenField = '2';

                        } else {
                            $scope.obj.test.VIROLOGY_CHECK = false;
                            $scope.obj.test.VerifyBy_Code = '';
                            $scope.obj.test.VerifyBy_Name = '';
                            $scope.obj.test.HiddenField = '';
                        }

                        //$scope.obj.test.txtVerificationDate = testData[i].T_UNIT_NO;

                        //var date = testData[i].T_DONATION_DATE;
                        //$scope.obj.test.T_DONATION_DATE = $filter('date')(date, "dd/MM/yyyy");
                        //var Exdate = testData[i].EXPIRY_DATE;
                        //$scope.obj.test.T_EXPIRY_DAYS = $filter('date')(Exdate, "dd/MM/yyyy");
                        $scope.obj.Virology.push($scope.obj.test);
                        document.getElementById("VerifyAll").style.display = 'block';
                        document.getElementById('btnNegativeResults').style.cursor = "none";
                    }//for lood end
                } else {
                    alert('No Data Found!!!');
                }
                
            });
        }
        function fnUnitPopUpData() {
            var UnitList = T12241Service.GetUnitPopUpData();
            UnitList.then(function (data) {
                $scope.UnitList = JSON.parse(data);
            });
        }
        $scope.UnitFromPopup = function () {
            fnUnitPopUpData();
            document.getElementById("divUnitFrom").style.display = 'block';
        };
        $scope.UnitToPopup = function () {
            fnUnitPopUpData();
            document.getElementById("divUnitTo").style.display = 'block';
        };
        $scope.btnf9_UnitFrom = function (e) {
            if (e.keyCode === 120) {
                fnUnitPopUpData();
                document.getElementById("divUnitFrom").style.display = 'block';
            }
        }
        $scope.CloseUnitFromPopup = function () {
            document.getElementById("divUnitFrom").style.display = 'none';
        }
        $scope.CloseUnitToPopup = function () {
            document.getElementById("divUnitTo").style.display = 'none';
        }
        $scope.onUnitFromSelect = function (i,data) {
            $scope.obj.T_UNIT_NO_FROM = data.CODE;
            document.getElementById("divUnitFrom").style.display = 'none';
            document.getElementById("txtUnitTo").focus();
        }
        $scope.onUnitToSelect = function (i,data) {
            $scope.obj.T_UNIT_NO_TO = data.CODE;
            document.getElementById("divUnitTo").style.display = 'none';
            document.getElementById("txtUnitTo").focus();
        }

        $scope.Next = function () {

            if ($scope.obj.T_UNIT_NO_FROM == null || $scope.obj.T_UNIT_NO_FROM === '' || $scope.obj.T_UNIT_NO_FROM == undefined && $scope.obj.T_UNIT_NO_TO == null || $scope.obj.T_UNIT_NO_TO === '' || $scope.obj.T_UNIT_NO_TO == undefined) {
                alert('please input unit numbers!!!');
            } else {
                fnGetGridData();
            }

        }
        $scope.GetDataWithEnterOrF3 = function () {
            if (event.keyCode === 114 || event.keyCode === 13) {
                if ($scope.obj.T_UNIT_NO_FROM == null || $scope.obj.T_UNIT_NO_FROM === '' || $scope.obj.T_UNIT_NO_FROM == undefined && $scope.obj.T_UNIT_NO_TO == null || $scope.obj.T_UNIT_NO_TO === '' || $scope.obj.T_UNIT_NO_TO == undefined) {
                    alert('please input unit numbers!!!');
                } else {
                    fnGetGridData();
                    event.preventDefault();
                }
            } else if (event.keyCode === 120) {
                fnUnitPopUpData();
                document.getElementById("divUnitTo").style.display = 'block';
            }
        }
        $scope.VirologyCheckboxClicked = function(index) {
            var firstCompoCheck = document.getElementById("virology" + index).checked;
            //alert(firstCompoCheck);
            if (firstCompoCheck == true) {
                var checkIsDoctor = T12241Service.DocEmpCode();
                checkIsDoctor.then(function(data) {
                    var testData = JSON.parse(data);
                    if (testData.length > 0) {
                        $scope.obj.Virology[index].VerifyBy_Code = testData[0].T_EMP_CODE;
                        $scope.obj.Virology[index].VerifyBy_Name = testData[0].T_USER_NAME;
                        document.getElementById('btnNegativeResults').style.cursor = "pointer";
                    } else {
                        alert('Only Doctor can verify.');
                        document.getElementById("virology" + index).checked = false;
                    }
                });
            }
        };
        $scope.NegativeResultsUpdate = function () {
            if ($scope.obj.Virology.length > 0) {
                for (var i = 0; i < $scope.obj.Virology.length; i++) {
                    if ($scope.obj.Virology[i].VerifyBy_Code !=='' && $scope.obj.Virology[i].HiddenField !== '2') {
                        T12241Service.updateVirologyResults($scope.obj.Virology[i].UnitNo);
                        alert('Negative result is entered for unit : ' + $scope.obj.Virology[i].UnitNo + '');
                    }
                }//for loop
            } else {
                alert('else part');
            }
        };
        $scope.checkvalue = function(i) {
            if ($scope.obj.Virology[i].HiddenField !== '') {
                return true;
            } else {
                return false;
            }
        };

        $scope.Save = function() {
            var insert = T12241Service.InsertT12223($scope.obj.T_UNIT_NO_TO);
            alert("Data Save Successfully");
        };


        //T12241Service.updateVirologyResults($scope.obj.Virology[i].UnitNo);
        //alert('Negative result is entered for unit' + $scope.obj.Virology[i].UnitNo + '');
        $scope.UnitValidate = function (unitNumber, naming) {
            CheckUnit(unitNumber, naming);
        }
        function CheckUnit(unitNo, naming) {
            if (unitNo !== "") {
                if (unitNo.substr(0, 1) !== '=') {
                    if (naming == 'UnitFrom') {
                        $scope.obj.T_UNIT_NO_FROM = '';
                    } else if (naming == 'UnitTo') {
                        $scope.obj.T_UNIT_NO_TO = '';
                    }
                    alert('Wrong Unit No');
                    return;
                }
                var bloodUnitData = T12241Service.getUnitData(unitNo);
                bloodUnitData.then(function (data) {
                    var bloodUnit = JSON.parse(data);
                    if (bloodUnit === null) {
                        alert('Wrong Unit No');
                        return;
                    }
                });
                if (naming == 'UnitFrom') {
                    $scope.obj.T_UNIT_NO_FROM = unitNo.substr(1, 13);
                } else if (naming == 'UnitTo') {
                    $scope.obj.T_UNIT_NO_TO = unitNo.substr(1, 13);
                }

            }//first if end

        }//function end

    }]);