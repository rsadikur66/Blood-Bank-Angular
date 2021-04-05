app.controller("T12232Controller", ["$scope", "T12232Service", "Data", "$window", "$filter",
    function ($scope, T12232Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.M12034 = [];
        var Language = JSON.parse(sessionStorage.getItem("LangName"));
        document.getElementById("VerifyAll").style.display = 'none';
        document.getElementById("1stDiv").style.display = 'none';
        //Page load data end
        document.getElementById('txtUnit').focus();
        //PopUp
        $scope.getVirusList = function (ind) {
            index = ind;
            fnVirusListData();
        }
        $scope.onVirusSelect = function (i) {
            $scope.obj.VirusInfo[index].T_VIURS_CODE = $scope.VirusList[i].CODE;
            $scope.obj.VirusInfo[index].VirusDesc = $scope.VirusList[i].NAME;
            document.getElementById("VirusDiv").style.display = 'none';
        }
        $scope.CloseVirusPopup = function () {
            document.getElementById("VirusDiv").style.display = 'none';
        }



        //Others Functionalities
        $scope.CheckAllCheckBox = function (p) {
            var CheckDoctorUser = T12232Service.CheckDoctorUser();
            CheckDoctorUser.then(function (data) {
                var newDataJSON = JSON.parse(data);
                var e = p.target.defaultValue;
                $scope.obj.M12034 = [];
                if (newDataJSON.length > 0) {
                    for (var j = 0; j < $scope.obj.VirusInfo.length; j++) {
                        if (e === $scope.getLabel('btnVerifyAll')) {
                            var a = document.getElementById("chkPos1Verify" + j).checked;
                            if (a === false) {
                                document.getElementById("chkPos1Verify" + j).checked = true;
                            }
                            $scope.obj.VirusInfo[j].POS1_VERIFY = true;
                            $scope.newobj = {};
                            $scope.obj.VirusInfo[j].Verify_By = newDataJSON[0].T_USER_NAME;
                            $scope.obj.VirusInfo[j].Verification_Date = $filter('date')(new Date(), 'dd/MM/yyyy');
                            $scope.newobj.T_UNIT_NO = $scope.obj.VirusInfo[j].T_UNIT_NO;
                            $scope.newobj.T_VIRUS_CODE = $scope.obj.VirusInfo[j].T_VIRUS_CODE;
                            $scope.obj.M12034.push($scope.newobj);
                        }
                    }
                } else {
                    alert('You are not authorized to verify');
                }
            });
        }
        $scope.CheckboxClicked = function (index) {
            var CheckDoctorUser = T12232Service.CheckDoctorUser();
            CheckDoctorUser.then(function (data) {
                var newDataJSON = JSON.parse(data);
                if (newDataJSON.length > 0) {
                    var firstCompoCheck = document.getElementById("chkPos1Verify" + index).checked;
                }
                else {
                    document.getElementById("chkPos1Verify" + index).checked = false;
                    alert('You are not authorized to verify');
                }
                //alert(firstCompoCheck);
                if (firstCompoCheck == true) {
                    $scope.newobj = {};
                    $scope.obj.VirusInfo[index].Verify_By = newDataJSON[0].T_USER_NAME;
                    $scope.obj.VirusInfo[index].Verification_Date = $filter('date')(new Date(), 'dd/MM/yyyy');
                    $scope.newobj.T_UNIT_NO = $scope.obj.VirusInfo[index].T_UNIT_NO;
                    $scope.newobj.T_VIRUS_CODE = $scope.obj.VirusInfo[index].T_VIRUS_CODE;
                    $scope.obj.M12034.push($scope.newobj);

                }
                if (firstCompoCheck == false) {
                    $scope.obj.VirusInfo[index].Verify_By = '';
                    $scope.obj.VirusInfo[index].Verification_Date = '';
                    $scope.obj.M12034.splice([index], 1);
                }

            });

        }

        //All Buttons
        $scope.Next = function () {
            if ($scope.obj.T_UNIT_NO == null || $scope.obj.T_UNIT_NO === '' || $scope.obj.T_UNIT_NO == undefined) {
                alert('Please Input Unit no.');
            } else {
                var CheckT12022 = T12232Service.CheckT12022($scope.obj.T_UNIT_NO);
                CheckT12022.then(function (data) {
                    var checkData = JSON.parse(data);
                    if (checkData.length > 0) {
                        var CheckT12075_T_VIROLOGY_RESULT = T12232Service.CheckT12075_T_VIROLOGY_RESULT($scope.obj.T_UNIT_NO);
                        CheckT12075_T_VIROLOGY_RESULT.then(function (data) {
                            var checkData = JSON.parse(data);
                            if (checkData.length > 0) {
                                alert('Result Closed As Negative For This Unit');
                                $scope.Clear();
                                return;
                            } else {
                                var CheckT12075_T_UNIT_DISCARD = T12232Service.CheckT12075_T_UNIT_DISCARD($scope.obj.T_UNIT_NO);
                                CheckT12075_T_UNIT_DISCARD.then(function (data) {
                                    var checkData = JSON.parse(data);
                                    if (checkData.length > 0) {
                                        $scope.Clear();
                                        alert($scope.getSingleMsg('N0062'));
                                        return;
                                    }
                                });
                                getDonationDate();
                                fnGetGridData();
                            }
                        });
                    } else {
                        $scope.Clear();
                        alert($scope.getSingleMsg('N0055'));
                        return;
                    }
                });
            }
        }
        $scope.Clear = function () {
            document.getElementById("1stDiv").style.display = 'none';
            $scope.obj.T_UNIT_NO = '';
            $scope.obj.T_DONATION_DATE = '';
            $scope.obj.T_DONATION_DATE_HIZRI = '';
            $scope.obj.T_DONATION_DATE = '';
            $scope.obj.T_DONATION_DATE_HIZRI = '';
            $scope.obj.VirusInfo = [];
        }
        //All Keyboard Events
        $scope.EnterAndF3 = function () {
            if (event.keyCode === 114 || event.keyCode === 13) {
                if ($scope.obj.T_UNIT_NO === '' || $scope.obj.T_UNIT_NO == undefined) {
                    alert('Please Input Unit no.');
                    event.preventDefault();
                } else {
                    var checkAvailability = T12232Service.ValidateUnitNo($scope.obj.T_UNIT_NO);
                    checkAvailability.then(function (data) {
                        var checkUnitNo = JSON.parse(data);
                        if (checkUnitNo.length == '1') {
                            alert('Result Closed As Negative For This Unit');
                        } else {
                            $scope.Next();
                            //getDonationDate();
                            //fnGetGridData();
                            //event.preventDefault();
                        }
                    });
                }
            } else {
                return;
            }

        }//end function

        //All functions
        function fnVirusListData() {
            var VirusList = T12232Service.GetVirusList();
            VirusList.then(function (data) {
                $scope.VirusList = JSON.parse(data);
                if ($scope.VirusList.length > 0) {
                    document.getElementById("VirusDiv").style.display = 'block';
                } else {
                    alert($scope.getSingleMsg('S0005'));
                    //alert('No Data is available.');

                }
            });
        }


        function fnGetGridData() {
            document.getElementById("1stDiv").style.display = 'block';
            var getAllData = T12232Service.GetAllData($scope.obj.T_UNIT_NO);
            getAllData.then(function (data) {
                var newDataJSON = JSON.parse(data);
                $scope.obj.VirusInfo = [];
                for (var i = 0; i < newDataJSON.length; i++) {
                    $scope.obj.test = {};
                    $scope.obj.test.T_UNIT_NO = $scope.obj.T_UNIT_NO;
                    $scope.obj.test.T_VIRUS_CODE = newDataJSON[i].T_VIRUS_CODE;
                    $scope.obj.test.VirusDesc = newDataJSON[i].T_VIRUS_NAME;
                    $scope.obj.test.TestBy = newDataJSON[i].T_USER_NAME;
                    if (newDataJSON[i].T_POS1_VERIFY == '1') {
                        $scope.obj.test.T_POS1_VERIFY = true;
                        $scope.obj.test.Verify_By = newDataJSON[i].VERIFIED_NAME;
                        var a = Date.parse(newDataJSON[i].T_POS1_VERIFIED_DATE);
                        var b = $filter('date')(a, "dd/MM/yyyy");
                        $scope.obj.test.Verification_Date = b;
                        $scope.obj.test.HiddenField = '2';
                    } else {
                        $scope.obj.test.HiddenField = '';  
                    }
                    
                    $scope.obj.VirusInfo.push($scope.obj.test);
                    document.getElementById("VerifyAll").style.display = 'block';
                }
            });
        }
        function getDonationDate() {
            if ($scope.obj.T_UNIT_NO != '') {
                var donationDate = T12232Service.GetDonationDate($scope.obj.T_UNIT_NO);
                donationDate.then(function (data) {
                    var donationDate = JSON.parse(data);
                    if (donationDate != 0) {
                        var a = Date.parse(donationDate[0].T_DONATION_DATE);
                        var b = $filter('date')(a, "dd/MM/yyyy");
                        $scope.obj.T_DONATION_DATE = b;
                        var c = $filter('date')(a, "dd-MMM-yyyy");
                        $scope.obj.T_DONATION_DATE_HIZRI = moment(c).format('iYYYY/iMM/iDD');
                        document.getElementById("txtDonationDate").focus();
                    }

                });
            } else {
                alert("No data found!!!");
            }
        }
        $scope.Save = function () {
            var t12034 = $scope.obj.M12034;
            if (t12034.length != '0') {
                var update = T12232Service.updateT12034(t12034);
                update.then(function (data) {
                    var dt = JSON.parse(data);
                    alert(dt);
                    $scope.Next();
                    $scope.obj.M12034 = [];
                });
            }
        }
        $scope.checkvalue = function (i) {
            if ($scope.obj.VirusInfo[i].HiddenField !== '') {
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
                var bloodUnitData = T12232Service.getUnitData(unitNo);
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