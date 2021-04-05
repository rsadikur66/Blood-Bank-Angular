app.controller("T12213Controller", ["$scope", "T12214Service", "$filter", "$http", "$window", "Data",
    function ($scope, T12214Service, $filter, $http, $window, Data) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.t03001 = {};
        $scope.obj.T74046 = {};
        $scope.obj.t03001.T_PAT_NO = '';
        $scope.obj.t03001.T_NTNLTY_ID = '';
        $scope.obj.t03001.T_FIRST_LANG2_NAME = '';
        $scope.obj.t03001.T_FIRST_LANG1_NAME = '';
        $scope.obj.t03001.T_FATHER_LANG1_NAME = '';
        $scope.obj.t03001.T_FATHER_LANG2_NAME = '';
        $scope.obj.t03001.T_FAMILY_LANG1_NAME = '';
        $scope.obj.t03001.T_FAMILY_LANG2_NAME = '';
        $scope.obj.t03001.T_GFATHER_LANG1_NAME = '';
        $scope.obj.t03001.T_GFATHER_LANG2_NAME = '';
        $scope.obj.t03001.T_MOTHER_LANG1_NAME = '';
        $scope.obj.t03001.T_MOTHER_LANG2_NAME = '';
        $scope.obj.t03001.T_TITLE_CODE = '';
        $scope.obj.t03001.T_PAT_TITLE = '';
        $scope.obj.t03001.T_SEX_CODE = '';
        $scope.obj.t03001.T_GENDER = '';
        $scope.obj.t03001.T_NTNLTY_CODE = '';
        $scope.obj.t03001.T_RLGN_CODE = '';
        $scope.obj.t03001.T_MRTL_STATUS_CODE = '';
        $scope.obj.t03001.T_MRTL_STATUS = '';
        $scope.obj.t03001.T_ER_RLTN_CODE = '';
        //$scope.obj.T74046.T_BIRTH_DATE = '';
        $scope.obj.t03001.T_BIRTH_DATE = '';
        $scope.obj.t03001.T_ADDRESS1 = '';
        $scope.obj.t03001.T_ADDRESS2 = '';
        $scope.obj.t03001.T_MOBILE_NO = '';
        $scope.obj.t03001.POBox = '';
        $scope.obj.t03001.PostalCode = '';
        $scope.obj.t03001.Resi = '';
        $scope.obj.t03001.Office = '';
        $scope.obj.t03001.ERContact = '';
        $scope.obj.t03001.ERMobileNo = '';
        $scope.obj.t03001.RegisterBy = '';
        $scope.obj.t03001.ModifiedBy = '';
        $scope.obj.t03001.T_ENTRY_DATE = '';
        $scope.obj.t03001.T_ENTRY_DATEARB = '';
        $scope.obj.t03001.T_UPD_DATE = '';
        $scope.obj.t03001.T_BIRTH_DATEARB = '';
        $scope.obj.t03001.T_UPD_DATEARB = '';
        $scope.obj.t03001.YRS = '';
        $scope.obj.t03001.MOS = '';
        $scope.obj.G = {};
        $scope.obj.R = {};
        $scope.obj.RG = {};
        $scope.obj.M = {};
        $scope.obj.N = {};
        $scope.obj.T = {};
        $scope.obj.RT = {};
        $scope.obj.ER = {};

        document.getElementById("txtNationalId").focus();
        // Name Translate
        $scope.nationalIdCheck = function() {
            $scope.obj.t03001.T_NTNLTY_ID != "" ? $scope.enabledTextBox() : $scope.disabledTextBox();
        };
        $scope.DonorIdCheck = function() {
            $scope.obj.t03001.T_PAT_NO != "" ? $scope.enabledTextBox() : $scope.disabledTextBox();
        };

        $scope.ExecuteButton = function(T_PAT_NO, T_NTNLTY_ID) {
            if (T_PAT_NO !== '' || T_NTNLTY_ID !== '') {
                $scope.obj.t03001.T_NTNLTY_ID = T_NTNLTY_ID;
                $scope.obj.t03001.T_PAT_NO = T_PAT_NO;
                if ($scope.obj.t03001.T_NTNLTY_ID !== '') {
                    $scope.nationalIdCheck();
                }
                if ($scope.obj.t03001.T_PAT_NO !== '') {
                    $scope.DonorIdCheck();
                }
                $scope.clearAllField();
                $scope.Execute(T_PAT_NO, T_NTNLTY_ID);
            }
        };

        $scope.EnterNatinality = function (event, nationlityCode) {
            if (event.keyCode === 13) {
                $scope.clearAllFieldWithoutNId();
                $scope.disabledTextBox();
                if (nationlityCode != '') {
                    if (nationlityCode.length < '10') {
                        $scope.obj.t03001.T_NTNLTY_ID = '';
                        alert($scope.getSingleMsg('S0095'));
                    } else {
                        var nidorIqamanocheck = $scope.checkisValidNIdorIqamaNo(nationlityCode);
                        if (nidorIqamanocheck === true) {
                            var nationlityCode = T12214Service.checkNationlityCode(nationlityCode);
                            $scope.nationalIdCheck();
                            nationlityCode.then(function (data) {
                                var newDataJSON = JSON.parse(data);
                                if (newDataJSON[0] != undefined) {
                                    $scope.clearAllField();
                                    $scope.Execute('', newDataJSON[0].T_NTNLTY_ID);
                                } else {
                                    $scope.GenderValidationTrue();
                                    //$scope.$broadcast('ddlTitleId');
                                    document.getElementById("txtFirstName2").focus();
                                }
                            });
                        } else {
                            $scope.obj.t03001.T_NTNLTY_ID = '';
                            alert($scope.getSingleMsg('S0095'));
                        }
                    }
                }
            }
        };

        $scope.checkMobileNoFocus = function(event) {
            if ($scope.obj.t03001.T_MOBILE_NO == undefined || $scope.obj.t03001.T_MOBILE_NO == '') {
                document.getElementById("txtMobileNo").focus();
            } else {
                var mobileNo = $scope.obj.t03001.T_MOBILE_NO;
                if (mobileNo == undefined) {
                    alert('S0015 : Please Enter Mobile no');
                    document.getElementById("txtMobileNo").focus();
                    return;
                }
                if (mobileNo !== undefined) {
                    var mobileNoLength = mobileNo.length;
                    if (mobileNo == "") {
                        alert('S0015 : Please Enter Mobile no');
                        document.getElementById("txtMobileNo").focus();
                        return;
                    }

                    if (mobileNoLength != 10) {
                        $scope.obj.t03001.T_MOBILE_NO = '';
                        alert('S0016 : Mobile Number should be 10 digits');
                        document.getElementById("txtMobileNo").focus();
                        return;
                    }
                    var mobileFirst2Char = mobileNo.substring(0, 2);
                    if (mobileFirst2Char !== '05') {
                        document.getElementById("txtMobileNo").focus();
                        alert('S0016 : Mobile Number should start with 05');
                        $scope.obj.t03001.T_MOBILE_NO = '';
                        return;
                    }
                    if (mobileFirst2Char === '05' && mobileNoLength === 10) {
                        document.getElementById("txtRes").focus();
                        return;
                    }

                }
                document.getElementById("txtRes").focus();
            }

        };

        $scope.EnterControl = function (event, controlkeyName) {
            if (event.keyCode === 13) {
                if (controlkeyName === "txtFirstName2") {
                    if ($scope.obj.t03001.T_FIRST_LANG1_NAME != '') {
                        $scope.getFirstNameArb($scope.obj.t03001.T_FIRST_LANG1_NAME);
                        if ($scope.obj.t03001.T_FIRST_LANG1_NAME != undefined)

                            if ($scope.obj.t03001.T_PAT_NO === "")
                                document.getElementById("txtFatherName").focus();
                    }
                }
                if (controlkeyName === "txtFirstName") {
                    if ($scope.obj.t03001.T_FIRST_LANG2_NAME != '') {
                        //$scope.getFirstNameArb($scope.obj.t03001.T_FIRST_LANG2_NAME);
                        //$scope.checkIslamReligionfromName($scope.obj.t03001.T_FIRST_LANG2_NAME);
                        if ($scope.obj.t03001.T_FIRST_LANG1_NAME != '') {
                            if ($scope.obj.t03001.T_FIRST_LANG1_NAME != undefined)
                                if ($scope.obj.t03001.T_PAT_NO === "")
                                document.getElementById("txtFatherName2").focus();
                        }
                    }
                }

                if (controlkeyName === "txtFatherName2") {
                    if ($scope.obj.t03001.T_FATHER_LANG1_NAME != '') {
                        $scope.getFatherNameArb($scope.obj.t03001.T_FATHER_LANG1_NAME);
                        if ($scope.obj.t03001.T_FATHER_LANG1_NAME != undefined)
                            if ($scope.obj.t03001.T_PAT_NO === "")
                            document.getElementById("txtGrandFatherName").focus();
                    }
                }
                if (controlkeyName === "txtFatherName") {
                    if ($scope.obj.t03001.T_FATHER_LANG2_NAME != '') {
                        //$scope.getFirstNameArb($scope.obj.t03001.T_FIRST_LANG2_NAME);
                        //$scope.checkIslamReligionfromName($scope.obj.t03001.T_FIRST_LANG2_NAME);
                        if ($scope.obj.t03001.T_FATHER_LANG1_NAME != '') {
                            if ($scope.obj.t03001.T_FATHER_LANG1_NAME != undefined)
                                if ($scope.obj.t03001.T_PAT_NO === "")
                                document.getElementById("txtGrandFatherName2").focus();
                        }
                    }
                }
                if (controlkeyName === "txtGrandFatherName2") {
                    $scope.getGrandFatherNameArb($scope.obj.t03001.T_GFATHER_LANG1_NAME);
                    document.getElementById("txtGrandFatherName").focus();
                }
                if (controlkeyName === "txtGrandFatherName") {
                    document.getElementById("txtLastName2").focus();
                }

                if (controlkeyName === "txtLastName2") {
                    $scope.getFamilyNameArb($scope.obj.t03001.T_FAMILY_LANG1_NAME);
                    //$scope.getFamilyNameArb($scope.obj.t03001.T_FAMILY_LANG2_NAME);
                    // $scope.checkIslamReligionfromName($scope.obj.t03001.T_FAMILY_LANG2_NAME);
                    document.getElementById("txtLastName").focus();
                }
                if (controlkeyName === "txtLastName") {
                    document.getElementById("txtBirthDateEng").focus();
                }

                if (controlkeyName === "txtBirthDateEng") {
                    if ($scope.obj.T74046.T_BIRTH_DATE != undefined || $scope.obj.T74046.T_BIRTH_DATE !== "") {
                        $scope.obj.T74046.T_BIRTH_DATE = $scope.DatewrOnHand($scope.obj.T74046.T_BIRTH_DATE);
                        $scope.onBirthDateSelect();
                        $scope.getAge();
                        if ($scope.obj.T74046.T_BIRTH_DATE == undefined || $scope.obj.T74046.T_BIRTH_DATE == '') {
                            document.getElementById("txtYear").focus();
                        } else {
                            document.getElementById("txtMotherNo").focus();
                        }
                    } else {
                        document.getElementById("txtYear").focus();
                    }
                }
                if (controlkeyName === "txtYear") {
                    var years = $scope.obj.t03001.YRS.toString();
                    if (years == "NaN") {
                        $scope.obj.t03001.YRS = "";
                    }
                    if (years !== "NaN") {
                        if (years !== "") {
                            $scope.obj.t03001.MOS = "0";
                            $scope.obj.T74046.T_BIRTH_DATE = $scope.getBirthDate($scope.obj.t03001.YRS, $scope.obj.t03001.MOS);
                            $scope.obj.t03001.T_BIRTH_DATEARB = $scope.getBirthDateArb($scope.obj.T74046.T_BIRTH_DATE);
                            document.getElementById("txtMon").focus();
                        }
                    } else {
                        document.getElementById("txtYear").focus();
                    }

                }
                if (controlkeyName === "txtMon") {
                    $scope.obj.T74046.T_BIRTH_DATE = $scope.getBirthDate($scope.obj.t03001.YRS, $scope.obj.t03001.MOS);
                    $scope.obj.t03001.T_BIRTH_DATEARB = $scope.getBirthDateArb($scope.obj.T74046.T_BIRTH_DATE);
                    if ($scope.obj.t03001.MOS == '' || $scope.obj.t03001.MOS == undefined) {
                        $scope.obj.t03001.MOS = '0';
                    }
                    document.getElementById("txtMotherNo").focus();
                }
                if (controlkeyName === "txtMotherNo") {
                    document.getElementById("txtMotherNo2").focus();
                }
                if (controlkeyName === "txtMotherNo2") {
                    document.getElementById("txtMotherName2").focus();
                }

                if (controlkeyName === "txtMotherName2") {
                    $scope.getMotherNameArb($scope.obj.t03001.T_MOTHER_LANG1_NAME);
                    document.getElementById("txtMotherName").focus();
                }

                if (controlkeyName === "txtMotherName") {
                    document.getElementById("txtFamHead").focus();
                }

                if (controlkeyName === "txtFamHead") {
                    document.getElementById("txtNationalIdNo").focus();
                }
                if (controlkeyName === "txtAddress") {
                    document.getElementById('txtMobileNo').focus();
                }
                if (controlkeyName === "txtMobileNo") {
                    var mobileNo = $scope.obj.t03001.T_MOBILE_NO;
                    if (mobileNo == undefined) {
                        alert('S0015 : Please Enter Mobile no');
                        document.getElementById("txtMobileNo").focus();
                        return;
                    }
                    if (mobileNo !== undefined) {
                        var mobileNoLength = mobileNo.length;
                        if (mobileNo == "") {
                            alert('S0015 : Please Enter Mobile no');
                            document.getElementById("txtMobileNo").focus();
                            return;
                        }

                        if (mobileNoLength != 10) {
                            $scope.obj.t03001.T_MOBILE_NO = '';
                            alert('S0016 : Mobile Number should be 10 digits');
                            document.getElementById("txtMobileNo").focus();
                            return;
                        }
                        var mobileFirst2Char = mobileNo.substring(0, 2);
                        if (mobileFirst2Char !== '05') {
                            document.getElementById("txtMobileNo").focus();
                            alert('S0016 : Mobile Number should start with 05');
                            $scope.obj.t03001.T_MOBILE_NO = '';
                            return;
                        }
                        if (mobileFirst2Char === '05' && mobileNoLength === 10) {
                            document.getElementById("txtRes").focus();
                            return;
                        }

                    }
                }
                if (controlkeyName === "txtRes") {
                    document.getElementById("txtEmail").focus();
                }
                if (controlkeyName === "txtEmail") {
                    document.getElementById("txtPoBox").focus();
                }
                if (controlkeyName === "txtPoBox") {
                    document.getElementById("txtPosterCode").focus();
                }
                if (controlkeyName === "txtPosterCode") {
                    document.getElementById("txtOffice").focus();
                }
                if (controlkeyName === "txtOffice") {
                    document.getElementById("txtContact").focus();
                }
                if (controlkeyName === "txtNationalIdNo") {
                    $scope.$broadcast('ddlRelationId');
                }
                if (controlkeyName === "txtRelationName") {
                    $scope.$broadcast('ddlGenderId');
                }
                if (controlkeyName === "txtContact") {
                    $scope.$broadcast('ddlERRelationId');
                }
                if (controlkeyName === "ddlTitleId") {
                    $scope.$broadcast('txtFirstName');
                }

            }
        };

        $scope.focusControl = function (event, controlkeyName) {

            if ($scope.obj.t03001.T_PAT_TITLE == "") {

                if (controlkeyName == 'txtFirstName') {
                    $scope.getFocus();
                    //checkIslamReligionfromName($scope.obj.t03001.T_FATHER_LANG2_NAME);
                }
                if (controlkeyName == 'txtFirstName2') {
                    $scope.getFocus();
                    //checkIslamReligionfromName($scope.obj.t03001.T_FIRST_LANG2_NAME);
                }

                if (controlkeyName == 'txtFatherName') {
                    $scope.getFocus();
                }
                if (controlkeyName == 'txtFatherName2') {
                    $scope.getFocus();
                }
                if (controlkeyName == 'ddlGenderId') {
                    if ($scope.obj.t03001.T_SEX_CODE == '' || $scope.obj.t03001.T_SEX_CODE == undefined) {
                        $scope.$broadcast('ddlGenderId');
                    }
                }

                if (controlkeyName == 'txtMobileNo') {
                    if ($scope.obj.t03001.T_MOBILE_NO == '') {
                        document.getElementById("txtMobileNo").focus();
                    } else {
                        document.getElementById("txtRes").focus();
                    }
                }
            }
        };
        $scope.CheckyearFocus = function (event, controlkeyName) {
            if ($scope.obj.t03001.YRS == '') {
                document.getElementById("txtYear").focus();
                return;
            };
        }

        $scope.CheckGender = function() {
            if ($scope.obj.t03001.T_SEX_CODE == '' || $scope.obj.t03001.T_SEX_CODE == undefined) {
                alert('S0015:Invalid Value. Please select Gender');
                $scope.$broadcast('ddlGenderId');
                return;
            }
        };
        $scope.clearDropdown = function() {
            $scope.obj.G.selected = '';
            $scope.obj.T.selected = '';
            $scope.obj.N.selected = '';
            $scope.obj.M.selected = '';
            $scope.obj.ER.selected = '';
            $scope.obj.RT.selected = '';
            $scope.obj.RG.selected = '';
        };
        $scope.getFocus = function() {
            if ($scope.obj.t03001.T_NTNLTY_ID == '') {
                document.getElementById("txtNationalId").focus();
                return;
            };

            if ($scope.obj.t03001.T_FIRST_LANG1_NAME == '') {
                document.getElementById("txtFirstName2").focus();
                return;
            };
            if ($scope.obj.t03001.T_FIRST_LANG2_NAME == '') {
                document.getElementById("txtFirstName").focus();
                return;
            };

            if ($scope.obj.t03001.T_FATHER_LANG1_NAME == '') {
                document.getElementById("txtFatherName2").focus();
                return;
            };
            if ($scope.obj.t03001.T_FATHER_LANG2_NAME == '') {
                document.getElementById("txtFatherName").focus();
                return;
            };

            if ($scope.obj.t03001.T_MOBILE_NO != '') {
                document.getElementById("txtMobileNo").focus();
                return;
            };
            if ($scope.obj.t03001.T_FATHER_LANG2_NAME != '') {
                document.getElementById("txtGrandFatherName2").focus();
                return;
            };
        };

        $scope.checkisValidNIdorIqamaNo = function(id) {
            if (id === '0000000000') return false;
            var num, x, y, z, sum = 0;
            for (var i = 0; i < 9; i++) {
                num = id.substr(i, 1);
                if ((i + 1) % 2 === 1) {
                    x = num * 2;
                    if (x > 9) x = parseInt(x.toString().substr(0, 1)) + parseInt(x.toString().substr(1, 1));
                } else x = num;
                sum += parseInt(x);
            }
            if (sum > 9) y = parseInt(sum.toString().substr(1, 1));
            else y = parseInt(sum.toString().substr(0, 1));
            if (y !== 0) z = 10 - y;
            else z = 0;
            if (z.toString() === id.substr(9, 1)) return true;
            else return false;
        };
        $scope.getFirstNameArb = function(arabicName) {
            $scope.obj.t03001.T_FIRST_LANG2_NAME = '';
            $scope.obj.t03001.T_FIRST_LANG1_NAME = arabicName;
            var NameArb = T12214Service.getEnglishName($scope.obj.t03001.T_FIRST_LANG1_NAME);
            NameArb.then(function(data) {
                var newDataJSON = JSON.parse(data);
                if (newDataJSON[0].T_NAME != undefined) {
                    $scope.obj.t03001.T_FIRST_LANG2_NAME = newDataJSON[0].T_NAME;
                    document.getElementById("txtFatherName2").focus();
                }
            });
            if ($scope.T_NAME_ARB == undefined) {
                if ($scope.obj.t03001.T_FIRST_LANG2_NAME != "") {
                    document.getElementById("txtFatherName").focus();
                    return;
                }
                document.getElementById("txtFirstName").focus();
            }
        };
        $scope.getFatherNameArb = function(arabicName) {
            $scope.obj.t03001.T_FATHER_LANG2_NAME = '';
            $scope.obj.t03001.T_FATHER_LANG1_NAME = arabicName;
            var NameArb = T12214Service.getEnglishName($scope.obj.t03001.T_FATHER_LANG1_NAME);
            NameArb.then(function(data) {
                var newDataJSON = JSON.parse(data);
                if (newDataJSON[0].T_NAME != undefined) {
                    $scope.obj.t03001.T_FATHER_LANG2_NAME = newDataJSON[0].T_NAME;
                    document.getElementById("txtGrandFatherName2").focus();
                    return;
                }
            });
            if ($scope.T_NAME_ARB == undefined) {
                document.getElementById("txtFatherName").focus();
            }
        };
        $scope.getGrandFatherNameArb = function(arabicName) {
            $scope.obj.t03001.T_GFATHER_LANG2_NAME = '';
            $scope.obj.t03001.T_GFATHER_LANG1_NAME = arabicName;
            var NameArb = T12214Service.getEnglishName(arabicName);
            NameArb.then(function(data) {
                var newDataJSON = JSON.parse(data);
                if (newDataJSON[0].T_NAME != undefined) {
                    $scope.obj.t03001.T_GFATHER_LANG2_NAME = newDataJSON[0].T_NAME;
                    document.getElementById("txtLastName2").focus();
                }
            });
            if ($scope.T_NAME_ARB == undefined) {
                document.getElementById("txtGrandFatherName").focus();
            }
        };
        $scope.getFamilyNameArb = function(arabicName) {
            $scope.obj.t03001.T_FAMILY_LANG2_NAME = '';
            $scope.obj.t03001.T_FAMILY_LANG1_NAME = arabicName;
            var NameArb = T12214Service.getEnglishName($scope.obj.t03001.T_FAMILY_LANG1_NAME);
            NameArb.then(function(data) {
                var newDataJSON = JSON.parse(data);
                if (newDataJSON[0].T_NAME != undefined) {
                    $scope.obj.t03001.T_FAMILY_LANG2_NAME = newDataJSON[0].T_NAME;
                    document.getElementById("txtBirthDateEng").focus();
                }
            });
            if ($scope.T_NAME_ARB == undefined) {
                document.getElementById("txtLastName").focus();
            }
        };
        $scope.getMotherNameArb = function(arabicName) {
            $scope.obj.t03001.T_MOTHER_LANG2_NAME = '';
            $scope.obj.t03001.T_MOTHER_LANG1_NAME = arabicName;
            var NameArb = T12214Service.getEnglishName($scope.obj.t03001.T_MOTHER_LANG1_NAME);
            NameArb.then(function(data) {
                var newDataJSON = JSON.parse(data);
                if (newDataJSON[0].T_NAME != undefined) {
                    $scope.obj.t03001.T_MOTHER_LANG2_NAME = newDataJSON[0].T_NAME;
                    document.getElementById("txtFamHead").focus();
                }
            });
            if ($scope.T_NAME_ARB == undefined) {
                document.getElementById("txtMotherName2").focus();
            }
        };

        ////Get Title List
        var getTitleList = T12214Service.getTitleList();
        getTitleList.then(function (data) {
            $scope.getTitle = JSON.parse(data);
        });

        $scope.getTitleList = function(ddlTitleId) {
            var titleData = T12214Service.getTitleList();
            titleData.then(function(data) {
                var newDataJSON = JSON.parse(data);
                $scope.titleList = newDataJSON;
            });
            if ($scope.obj.t03001.T_NTNLTY_ID == '' || $scope.obj.t03001.T_NTNLTY_ID == undefined) {
                $scope.dropDownCheckForNIdCode();
                return;
            }
            $scope.ddlfocusLost('txtFirstName2');
        };


        ////Get Relation List
        var getRelationData = T12214Service.getRelationList();
        getRelationData.then(function (data) {
            $scope.getRelation = JSON.parse(data);
        });
        $scope.getRelationList = function() {
            var titleData = T12214Service.getRelationList();
            titleData.then(function(data) {
                var newDataJSON = JSON.parse(data);
                $scope.relationList = newDataJSON;
            });
            if ($scope.obj.t03001.T_NTNLTY_ID == '' || $scope.obj.t03001.T_NTNLTY_ID == undefined) {
                $scope.dropDownCheckForNIdCode();
                return;
            }
            $scope.ddlfocusLost('txtRelationName');
        };

        ////Get Maritial Status List
        var getMaritialStatusList = T12214Service.getMrtlStatusList();
        getMaritialStatusList.then(function (data) {
            $scope.MaritialStatus = JSON.parse(data);
        });
        $scope.getMrtlStatusList = function(mstatus) {
            var titleData = T12214Service.getMrtlStatusList();
            titleData.then(function(data) {
                var newDataJSON = JSON.parse(data);
                $scope.MaritialStatusList = newDataJSON;
            });
            if ($scope.obj.t03001.T_NTNLTY_ID == '' || $scope.obj.t03001.T_NTNLTY_ID == undefined) {
                $scope.dropDownCheckForNIdCode();
                return;
            }
            if (mstatus === 'mstatus') {
                if ($scope.obj.t03001.T_MRTL_STATUS_CODE == '' || $scope.obj.t03001.T_MRTL_STATUS == undefined) {
                    $scope.obj.M.selected = '';
                    alert('S0015:Invalid Value. Please select Maritial Satus');
                    $scope.$broadcast('ddlMaritialStatusId');
                    return;
                }
            }
            if ($scope.obj.t03001.T_SEX_CODE == '' || $scope.obj.t03001.T_SEX_CODE == undefined) {
                alert('S0015:Invalid Value. Please select Gender');
                $scope.obj.M.selected = '';
                $scope.$broadcast('ddlGenderId');
                return;
            }
            if ($scope.obj.t03001.T_NTNLTY_CODE == '' || $scope.obj.t03001.T_NTNLTY_CODE == undefined) {
                alert('S0015:Invalid Value. Please select Nationality');
                $scope.obj.M.selected = '';
                $scope.$broadcast('ddlNationalityId');
                return;
            }
            if ($scope.obj.t03001.T_RLGN_CODE == '' || $scope.obj.t03001.T_RLGN_CODE == undefined) {
                $scope.obj.M.selected = '';
                alert('S0015:Invalid Value. Please select Religion');
                $scope.$broadcast('ddlReligionId');
                return;
            }
            $scope.ddlfocusLost('txtAddress');
        };

        ////Get Gender List
        var getGenderList = T12214Service.getGenderList();
        getGenderList.then(function (data) {
            $scope.getGender = JSON.parse(data);
        });
        $scope.getGenderList = function(gender) {
            var titleData = T12214Service.getGenderList();
            titleData.then(function(data) {
                var newDataJSON = JSON.parse(data);
                $scope.genderList = newDataJSON;
            });
            if ($scope.obj.t03001.T_NTNLTY_ID == '' || $scope.obj.t03001.T_NTNLTY_ID == undefined) {
                $scope.dropDownCheckForNIdCode();
                return;
            }
            if (gender === 'gender') {
                if ($scope.obj.t03001.T_SEX_CODE == '' || $scope.obj.t03001.T_SEX_CODE == undefined) {
                    $scope.obj.G.selected = '';
                    $scope.obj.T.selected = '';
                    $scope.obj.M.selected = '';
                    $scope.obj.N.selected = '';
                    $scope.obj.ER.selected = '';
                    alert('S0015:Invalid Value. Please select Gender');
                    $scope.$broadcast('ddlGenderId');
                    $scope.GenderValidationTrue();
                    return;
                }
                if ($scope.obj.t03001.T_SEX_CODE == '1') {
                    $scope.obj.T.selected = { T_TITLE_NAME: 'MR.', T_TITLE_CODE: '4' };
                }
                if ($scope.obj.t03001.T_SEX_CODE == '2') {
                    $scope.obj.T.selected = { T_TITLE_NAME: 'MRS.', T_TITLE_CODE: '5' };
                }
                if ($scope.obj.t03001.T_SEX_CODE == '3') {
                    $scope.obj.T.selected = { T_TITLE_NAME: 'MISS', T_TITLE_CODE: '8' };
                }
                $scope.GenderValidationFalse();
                if (gender == 'gender') {
                    $scope.$broadcast('ddlNationalityId');
                }
            }
        };

        ////Get Nationality List
        var getNationalityList = T12214Service.getNationalityList();
        getNationalityList.then(function (data) {
            $scope.getNationality = JSON.parse(data);
        });
        $scope.getNationalityList = function(ddlNationalityId) {
            var titleData = T12214Service.getNationalityList();
            titleData.then(function(data) {
                var newDataJSON = JSON.parse(data);
                $scope.nationalityList = newDataJSON;
            });
            if ($scope.obj.t03001.T_NTNLTY_ID == '' || $scope.obj.t03001.T_NTNLTY_ID == undefined) {
                $scope.dropDownCheckForNIdCode();
                return;
            }

            if (ddlNationalityId === 'nationality') {
                if ($scope.obj.t03001.T_SEX_CODE == '' || $scope.obj.t03001.T_SEX_CODE == undefined) {
                    $scope.obj.N.selected = '';
                    alert('S0015:Invalid Value. Please select Gender');
                    $scope.$broadcast('ddlGenderId');
                    return;
                }
                if ($scope.obj.t03001.T_NTNLTY_CODE == '' || $scope.obj.t03001.T_NTNLTY_CODE == undefined) {
                    $scope.obj.N.selected = '';
                    alert('S0015:Invalid Value. Please select Nationality');
                    $scope.$broadcast('ddlNationalityId');
                    return;
                }
                var checkNIDCode = $scope.obj.t03001.T_NTNLTY_ID.charAt(0);
                if (checkNIDCode !== '1' && $scope.obj.t03001.T_NTNLTY_CODE == "01") {
                    $scope.obj.N.selected = '';
                    alert($scope.getSingleMsg('S0332'));
                    return;
                }
                $scope.$broadcast('ddlReligionId');
            }
        };
        ////Get Religion List
        var getReligionList = T12214Service.getReligionList();
        getReligionList.then(function (data) {
            $scope.getReligion = JSON.parse(data);
        });
        $scope.getReligionList = function(ddlReligionId) {
            var titleData = T12214Service.getReligionList();
            titleData.then(function(data) {
                var newDataJSON = JSON.parse(data);
                $scope.religionList = newDataJSON;
            });
            if ($scope.obj.t03001.T_NTNLTY_ID == '' || $scope.obj.t03001.T_NTNLTY_ID == undefined) {
                $scope.dropDownCheckForNIdCode();
                return;
            }
            if ($scope.obj.t03001.T_RLGN_CODE == '' || $scope.obj.t03001.T_RLGN_CODE == undefined) {
                $scope.obj.RG.selected = '';
                alert('S0015:Invalid Value. Please select Religion');
                $scope.$broadcast('ddlReligionId');
                return;
            }
            if ($scope.obj.t03001.T_SEX_CODE == '' || $scope.obj.t03001.T_SEX_CODE == undefined) {
                alert('S0015:Invalid Value. Please select Gender');
                $scope.obj.RG.selected = '';
                $scope.$broadcast('ddlGenderId');
                return;
            }
            if ($scope.obj.t03001.T_NTNLTY_CODE == '' || $scope.obj.t03001.T_NTNLTY_CODE == undefined) {
                alert('S0015:Invalid Value. Please select Nationality');
                $scope.obj.RG.selected = '';
                $scope.$broadcast('ddlNationalityId');
                return;
            }
            if (ddlReligionId === 'religion') {
                $scope.$broadcast('ddlMaritialStatusId');
            }

        };

        ////Get ERRelation List
        var getERRelationList = T12214Service.getERRelationList();
        getERRelationList.then(function (data) {
            $scope.getERRelation = JSON.parse(data);
        });
        $scope.getERRelationList = function() {
            var titleData = T12214Service.getERRelationList();
            titleData.then(function(data) {
                var newDataJSON = JSON.parse(data);
                $scope.ERRelationList = newDataJSON;
            });
            if ($scope.obj.t03001.T_NTNLTY_ID == '' || $scope.obj.t03001.T_NTNLTY_ID == undefined) {
                $scope.dropDownCheckForNIdCode();
                return;
            }
            if ($scope.obj.t03001.T_SEX_CODE == '' || $scope.obj.t03001.T_SEX_CODE == undefined) {
                $scope.obj.ER.selected = '';
                alert('S0015:Invalid Value. Please select Gender');
                $scope.$broadcast('ddlGenderId');
                return;
            }
            $scope.ddlfocusLost('txtERMobileNo');
        };

        ////Get Patient information
        $scope.Execute = function(T_PAT_NO, T_NTNLTY_ID) {
            $scope.obj.t03001.T_PAT_NO = T_PAT_NO;
            $scope.obj.t03001.T_NTNLTY_ID = T_NTNLTY_ID;
            var patdata = T12214Service.getExistingPatData($scope.obj.t03001.T_PAT_NO, $scope.obj.t03001.T_NTNLTY_ID);
            patdata.then(function(data) {
                var newDataJSON = JSON.parse(data);
                if (newDataJSON[0] == undefined) {
                    sessionStorage.setItem("FFlag", null);
                    alert("No data found");
                    return;
                }
                var lang = $scope.lang;
                $scope.obj.t03001.T_NTNLTY_ID = newDataJSON[0].T_NTNLTY_ID;
                $scope.obj.t03001.T_PAT_NO = newDataJSON[0].T_PAT_NO;
                $scope.obj.t03001.T_FIRST_LANG2_NAME = newDataJSON[0].T_FIRST_LANG2_NAME;
                $scope.obj.t03001.T_FIRST_LANG1_NAME = newDataJSON[0].T_FIRST_LANG1_NAME;
                $scope.obj.t03001.T_FATHER_LANG1_NAME = newDataJSON[0].T_FATHER_LANG1_NAME;
                $scope.obj.t03001.T_FATHER_LANG2_NAME = newDataJSON[0].T_FATHER_LANG2_NAME;
                $scope.obj.t03001.T_FAMILY_LANG1_NAME = newDataJSON[0].T_FAMILY_LANG1_NAME;
                $scope.obj.t03001.T_FAMILY_LANG2_NAME = newDataJSON[0].T_FAMILY_LANG2_NAME;
                $scope.obj.t03001.T_GFATHER_LANG1_NAME = newDataJSON[0].T_GFATHER_LANG1_NAME;
                $scope.obj.t03001.T_GFATHER_LANG2_NAME = newDataJSON[0].T_GFATHER_LANG2_NAME;
                $scope.obj.t03001.T_MOTHER_LANG1_NAME = newDataJSON[0].T_MOTHER_LANG1_NAME;
                $scope.obj.t03001.T_MOTHER_LANG2_NAME = newDataJSON[0].T_MOTHER_LANG2_NAME;
                $scope.obj.t03001.T_PAT_TITLE = newDataJSON[0].T_PAT_TITLE;
                $scope.obj.t03001.T_SEX_CODE = newDataJSON[0].T_GENDER;
                $scope.obj.t03001.T_NTNLTY_CODE = newDataJSON[0].T_NTNLTY_CODE;
                $scope.obj.t03001.T_RLGN_CODE = newDataJSON[0].T_RLGN_CODE;
                $scope.obj.t03001.T_MRTL_STATUS_CODE = newDataJSON[0].T_MRTL_STATUS_CODE;
                $scope.obj.t03001.T_RLTN_CODE = newDataJSON[0].T_RLTN_CODE;
                $scope.obj.t03001.RegisterBy = newDataJSON[0].T_ENTRY_USER_NAME;
                var a = Date.parse(newDataJSON[0].T_ENTRY_DATE);
                var i = $filter('date')(a, "dd-MMM-yyyy");
                $scope.obj.t03001.T_ENTRY_DATEARB = moment(i).format('iYYYY/iMM/iDD');
                $scope.obj.t03001.ModifiedBy = newDataJSON[0].T_UPDATE_USER_NAME;
                $scope.obj.t03001.T_UPD_DATE = newDataJSON[0].T_UPD_DATE;
                if ($scope.obj.t03001.T_UPD_DATE != null) {
                    var c = Date.parse(newDataJSON[0].T_UPD_DATE);
                    var u = $filter('date')(c, "dd-MMM-yyyy");
                    $scope.obj.t03001.T_UPD_DATEARB = moment(u).format('iYYYY/iMM/iDD');
                } else {
                    $scope.obj.t03001.T_UPD_DATE = '';
                }
                $scope.obj.t03001.YRS = newDataJSON[0].YRS;
                $scope.obj.t03001.MOS = newDataJSON[0].MOS;

                var mydate = Date.parse(newDataJSON[0].T_BIRTH_DATE);
                if (mydate != undefined) {

                    $scope.obj.T74046.T_BIRTH_DATE = $filter('date')(mydate, "dd/MM/yyyy");
                    $scope.obj.t03001.T_BIRTH_DATEARB = moment(mydate).format('iDD/iMM/iYYYY');
                } else {
                    $scope.obj.T74046.T_BIRTH_DATE = '';
                }
                if (newDataJSON[0].T_ENTRY_DATE != null) {
                    var myEntryDate = Date.parse(newDataJSON[0].T_ENTRY_DATE);
                    $scope.obj.t03001.T_ENTRY_DATE = $filter('date')(myEntryDate, "dd/MM/yyyy");
                } else {
                    newDataJSON[0].T_ENTRY_DATE = '';
                }
                if (newDataJSON[0].T_UPD_DATE != null) {
                    var myUpdateDate = Date.parse(newDataJSON[0].T_UPD_DATE);
                    $scope.obj.t03001.T_UPD_DATE = $filter('date')(myUpdateDate, "dd/MM/yyyy");
                } else {
                    newDataJSON[0].T_UPD_DATE = '';
                }


                if (lang != '1') {
                    $scope.obj.t03001.T_ADDRESS1 = newDataJSON[0].T_ADDRESS1;
                } else {
                    $scope.obj.t03001.T_ADDRESS2 = newDataJSON[0].T_ADDRESS2;
                }
                $scope.obj.t03001.T_MOBILE_NO = newDataJSON[0].T_MOBILE_NO;


                //DropdownList
                $scope.obj.G.selected = { T_GENDER: newDataJSON[0].T_GENDER_NAME, T_SEX_CODE: newDataJSON[0].T_GENDER };
                $scope.obj.t03001.T_GENDER = newDataJSON[0].T_GENDER;
                $scope.obj.T.selected = {
                    T_TITLE_NAME: newDataJSON[0].T_PAT_TITLE_NAME,
                    T_TITLE_CODE: newDataJSON[0].T_PAT_TITLE
                };
                $scope.obj.t03001.T_TITLE_CODE = newDataJSON[0].T_PAT_TITLE;
                $scope.obj.N.selected = {
                    T_NTNLTY: newDataJSON[0].T_NTNLTY_NAME,
                    T_NTNLTY_CODE: newDataJSON[0].T_NTNLTY_CODE
                };
                $scope.obj.RG.selected = {
                    T_RLGN_NAME: newDataJSON[0].T_RLGN_NAME,
                    T_RLGN_CODE: newDataJSON[0].T_RLGN_CODE
                };
                $scope.obj.M.selected = {
                    T_MRTL_STATUS: newDataJSON[0].T_MRTL_STATUS_NAME,
                    T_MRTL_STATUS_CODE: newDataJSON[0].T_MRTL_STATUS
                };
                $scope.obj.t03001.T_MRTL_STATUS = newDataJSON[0].T_MRTL_STATUS;
                $scope.obj.ER.selected = {
                    T_ERRLTN_NAME: newDataJSON[0].T_ERRLTN_NAME,
                    T_ER_RLTN_CODE: newDataJSON[0].T_ER_RLTN_CODE
                };
                $scope.obj.t03001.T_ER_RLTN_CODE = newDataJSON[0].T_ER_RLTN_CODE;
                $scope.obj.RT.selected = {
                    T_RLTN_NAME: newDataJSON[0].T_RLTN_NAME,
                    T_RLTN_CODE: newDataJSON[0].T_RLTN_CODE
                };
                $scope.obj.t03001.T_RLGN_CODE = newDataJSON[0].T_RLGN_CODE;
                document.getElementById("btnEnterQuery").className = "Button Enter";
                document.getElementById("txtDonarId").readOnly = true;
                sessionStorage.setItem("PatNo", JSON.stringify($scope.obj.t03001.T_PAT_NO));
                sessionStorage.setItem("FFlag", JSON.stringify("T12201"));
            });
        };
        $scope.onBirthDateSelect = function() {
            $scope.clculte = true;
        };
        $scope.clculte = false;


        $scope.getAge = function () {
            if ($scope.clculte === true) {
                var k = $scope.dateParse($scope.obj.T74046.T_BIRTH_DATE, "/");
                var n = Date.parse(k);
                $scope.obj.t03001.YRS = $scope.calculateAge(n);
                $scope.obj.t03001.MOS = $scope.calculateMonth(n);

                $scope.obj.t03001.T_BIRTH_DATEARB = moment(n).format('iDD/iMM/iYYYY');
                if ($scope.obj.t03001.T_BIRTH_DATEARB == "Invalid date") {
                    $scope.obj.t03001.T_BIRTH_DATEARB = '';
                }
            }
            $scope.clculte = false;
        };
        $scope.Save_Click = function () {
            if ($scope.obj.T74046.T_BIRTH_DATE != undefined) {
                $scope.obj.t03001.T_BIRTH_DATE = $scope.dateParse($scope.obj.T74046.T_BIRTH_DATE, "/");
            } else {
                $scope.obj.t03001.T_BIRTH_DATE = '';
            }

            $scope.obj.t03001.T_GENDER = $scope.obj.t03001.T_SEX_CODE;
            $scope.obj.t03001.T_PAT_TITLE = $scope.obj.t03001.T_TITLE_CODE;
            $scope.obj.t03001.T_MRTL_STATUS = $scope.obj.t03001.T_MRTL_STATUS_CODE;
            var t03001 = $scope.obj.t03001;
            var insert = T12214Service.insert(t03001);
            insert.then(function (data) {
                var dt = JSON.parse(data);
                alert(dt);
                if (dt == "N0040 : Data Saved Successfully") {
                    $scope.get_pat();
                }
                if (dt == "N0040 : تم حفظ المعلومات بنجاح") {
                    $scope.get_pat();
                }
            });

        };
        $scope.get_pat = function () {
            var lastPatNo = T12214Service.getPatNo();
            lastPatNo.then(function (data) {
                var patNo = JSON.parse(data);
                $scope.obj.t03001.T_PAT_NO = patNo;
                sessionStorage.setItem("FFlag", JSON.stringify("T12201"));
            });
        };
        $scope.Enter = function () {
            $scope.clearAllField();
            if (document.getElementById("btnEnterQuery").className === "Button Cancel") {
                document.getElementById("btnEnterQuery").className = "Button Enter";
                document.getElementById("txtDonarId").readOnly = true;
                document.getElementById("btnSave").disabled = false;
                document.getElementById("btnDelete").disabled = false;
                return;
            }
            document.getElementById("btnEnterQuery").className = "Button Cancel";
            document.getElementById("txtNationalId").readOnly = false;
            document.getElementById("txtDonarId").readOnly = false;
            document.getElementById("btnSave").disabled = true;
            document.getElementById("btnDelete").disabled = true;
            document.getElementById("txtDonarId").focus();
        };
        $scope.Clear = function () {
            $scope.clearAllField();
            var img = document.getElementById("btnSign").style;
            img.background = "url(../../Images/buttonWhite.png)";
            img.width = "100px";
            img.backgroundRepeat = "no-repeat";
            img.backgroundPosition = "center";
            img.borderColor = "#FBFBFB";
            img.marginLeft = "-30px";

            document.getElementById("btnEnterQuery").className = "Button Enter";
            document.getElementById("txtNationalId").readOnly = true;
            document.getElementById("txtDonarId").readOnly = true;
        };

        $scope.btnClear_Click = function() {
            $scope.clearAllField();
            $scope.disabledTextBox();
            document.getElementById("txtNationalId").readOnly = false;
            document.getElementById("txtNationalId").focus();
        };

        $scope.clearAllField = function() {
            $scope.obj.G.selected = '';
            $scope.obj.T.selected = '';
            $scope.obj.N.selected = '';
            $scope.obj.M.selected = '';
            $scope.obj.ER.selected = '';
            $scope.obj.RT.selected = '';
            $scope.obj.RG.selected = '';
            $scope.obj.t03001.T_PAT_NO = '';
            $scope.obj.t03001.T_NTNLTY_ID = '';
            $scope.obj.t03001.T_FIRST_LANG2_NAME = '';
            $scope.obj.t03001.T_FIRST_LANG1_NAME = '';
            $scope.obj.t03001.T_FATHER_LANG1_NAME = '';
            $scope.obj.t03001.T_FATHER_LANG2_NAME = '';
            $scope.obj.t03001.T_FAMILY_LANG1_NAME = '';
            $scope.obj.t03001.T_FAMILY_LANG2_NAME = '';
            $scope.obj.t03001.T_GFATHER_LANG1_NAME = '';
            $scope.obj.t03001.T_GFATHER_LANG2_NAME = '';
            $scope.obj.t03001.T_MOTHER_LANG1_NAME = '';
            $scope.obj.t03001.T_MOTHER_LANG2_NAME = '';
            $scope.obj.t03001.T_TITLE_CODE = '';
            $scope.obj.t03001.T_PAT_TITLE = '';
            $scope.obj.t03001.T_SEX_CODE = '';
            $scope.obj.t03001.T_GENDER = '';
            $scope.obj.t03001.T_NTNLTY_CODE = '';
            $scope.obj.t03001.T_RLGN_CODE = '';
            $scope.obj.t03001.T_MRTL_STATUS_CODE = '';
            $scope.obj.t03001.T_MRTL_STATUS = '';
            $scope.obj.t03001.T_ER_RLTN_CODE = '';
            $scope.obj.t03001.T_BIRTH_DATE = '';
            $scope.obj.t03001.T_ADDRESS1 = '';
            $scope.obj.t03001.T_ADDRESS2 = '';
            $scope.obj.t03001.T_MOBILE_NO = '';
            $scope.obj.t03001.POBox = '';
            $scope.obj.t03001.PostalCode = '';
            $scope.obj.t03001.Resi = '';
            $scope.obj.t03001.Office = '';
            $scope.obj.t03001.ERContact = '';
            $scope.obj.t03001.ERMobileNo = '';
            $scope.obj.t03001.RegisterBy = '';
            $scope.obj.t03001.ModifiedBy = '';
            $scope.obj.t03001.T_ENTRY_DATE = '';
            $scope.obj.t03001.T_ENTRY_DATEARB = '';
            $scope.obj.t03001.T_UPD_DATE = '';
            $scope.obj.t03001.T_BIRTH_DATEARB = '';
            $scope.obj.t03001.T_UPD_DATEARB = '';
            $scope.obj.t03001.YRS = '';
            $scope.obj.t03001.MOS = '';
            $scope.obj.T74046.T_BIRTH_DATE = '';
        };
        $scope.clearAllFieldWithoutNId = function () {
            $scope.obj.G.selected = '';
            $scope.obj.T.selected = '';
            $scope.obj.N.selected = '';
            $scope.obj.M.selected = '';
            $scope.obj.ER.selected = '';
            $scope.obj.RT.selected = '';
            $scope.obj.RG.selected = '';
            $scope.obj.t03001.T_PAT_NO = '';
            $scope.obj.t03001.T_FIRST_LANG2_NAME = '';
            $scope.obj.t03001.T_FIRST_LANG1_NAME = '';
            $scope.obj.t03001.T_FATHER_LANG1_NAME = '';
            $scope.obj.t03001.T_FATHER_LANG2_NAME = '';
            $scope.obj.t03001.T_FAMILY_LANG1_NAME = '';
            $scope.obj.t03001.T_FAMILY_LANG2_NAME = '';
            $scope.obj.t03001.T_GFATHER_LANG1_NAME = '';
            $scope.obj.t03001.T_GFATHER_LANG2_NAME = '';
            $scope.obj.t03001.T_MOTHER_LANG1_NAME = '';
            $scope.obj.t03001.T_MOTHER_LANG2_NAME = '';
            $scope.obj.t03001.T_TITLE_CODE = '';
            $scope.obj.t03001.T_PAT_TITLE = '';
            $scope.obj.t03001.T_SEX_CODE = '';
            $scope.obj.t03001.T_GENDER = '';
            $scope.obj.t03001.T_NTNLTY_CODE = '';
            $scope.obj.t03001.T_RLGN_CODE = '';
            $scope.obj.t03001.T_MRTL_STATUS_CODE = '';
            $scope.obj.t03001.T_MRTL_STATUS = '';
            $scope.obj.t03001.T_ER_RLTN_CODE = '';
            $scope.obj.t03001.T_BIRTH_DATE = '';
            $scope.obj.t03001.T_ADDRESS1 = '';
            $scope.obj.t03001.T_ADDRESS2 = '';
            $scope.obj.t03001.T_MOBILE_NO = '';
            $scope.obj.t03001.POBox = '';
            $scope.obj.t03001.PostalCode = '';
            $scope.obj.t03001.Resi = '';
            $scope.obj.t03001.Office = '';
            $scope.obj.t03001.ERContact = '';
            $scope.obj.t03001.ERMobileNo = '';
            $scope.obj.t03001.RegisterBy = '';
            $scope.obj.t03001.ModifiedBy = '';
            $scope.obj.t03001.T_ENTRY_DATE = '';
            $scope.obj.t03001.T_ENTRY_DATEARB = '';
            $scope.obj.t03001.T_UPD_DATE = '';
            $scope.obj.t03001.T_BIRTH_DATEARB = '';
            $scope.obj.t03001.T_UPD_DATEARB = '';
            $scope.obj.t03001.YRS = '';
            $scope.obj.t03001.MOS = '';
            $scope.obj.T74046.T_BIRTH_DATE = '';
        };
        function pad(n, pl, pc) {
            var padChar = typeof pc != 'undefined' ? pc : '0';
            var pad = new Array(1 + pl).join(padChar);
            return (pad + n).slice(-pad.length);
        }

        $scope.LPad = function (n, pl, pc) {
            var a = pad(n, pl, pc);
            $scope.obj.t03001.T_PAT_NO = a == '00000000' ? '' : a;
        };

        $scope.disabledTextBox = function() {
            document.getElementById("txtFirstName").readOnly = true;
            document.getElementById("txtFirstName2").readOnly = true;
            document.getElementById("txtFatherName").readOnly = true;
            document.getElementById("txtFatherName2").readOnly = true;
            document.getElementById("txtGrandFatherName").readOnly = true;
            document.getElementById("txtGrandFatherName2").readOnly = true;
            document.getElementById("txtLastName").readOnly = true;
            document.getElementById("txtLastName2").readOnly = true;
            document.getElementById("txtBirthDateEng").readOnly = true;
            document.getElementById("txtYear").readOnly = true;
            document.getElementById("txtMon").readOnly = true;
            document.getElementById("txtMotherNo").readOnly = true;
            document.getElementById("txtMotherNo2").readOnly = true;
            document.getElementById("txtMotherName").readOnly = true;
            document.getElementById("txtMotherName2").readOnly = true;
            document.getElementById("txtFamHead").readOnly = true;
            document.getElementById("txtNationalIdNo").readOnly = true;
            document.getElementById("txtRelationName").readOnly = true;
            document.getElementById("txtAddress").readOnly = true;
            document.getElementById("txtMobileNo").readOnly = true;
            document.getElementById("txtRes").readOnly = true;
            document.getElementById("txtEmail").readOnly = true;
            document.getElementById("txtPoBox").readOnly = true;
            document.getElementById("txtPosterCode").readOnly = true;
            document.getElementById("txtOffice").readOnly = true;
            document.getElementById("txtContact").readOnly = true;
            document.getElementById("txtERMobileNo").readOnly = true;
            document.getElementById("txtNationalId").focus();
        };
        $scope.enabledTextBox = function() {
            document.getElementById("txtFirstName").readOnly = false;
            document.getElementById("txtFirstName2").readOnly = false;
            document.getElementById("txtFatherName").readOnly = false;
            document.getElementById("txtFatherName2").readOnly = false;
            document.getElementById("txtGrandFatherName").readOnly = false;
            document.getElementById("txtGrandFatherName2").readOnly = false;
            document.getElementById("txtLastName").readOnly = false;
            document.getElementById("txtLastName2").readOnly = false;
            document.getElementById("txtBirthDateEng").readOnly = false;
            document.getElementById("txtYear").readOnly = false;
            document.getElementById("txtMon").readOnly = false;
            document.getElementById("txtMotherNo").readOnly = false;
            document.getElementById("txtMotherNo2").readOnly = false;
            document.getElementById("txtMotherName").readOnly = false;
            document.getElementById("txtMotherName2").readOnly = false;
            document.getElementById("txtFamHead").readOnly = false;
            document.getElementById("txtNationalIdNo").readOnly = false;
            document.getElementById("txtRelationName").readOnly = false;
            document.getElementById("txtAddress").readOnly = false;
            document.getElementById("txtMobileNo").readOnly = false;
            document.getElementById("txtRes").readOnly = false;
            document.getElementById("txtEmail").readOnly = false;
            document.getElementById("txtPoBox").readOnly = false;
            document.getElementById("txtPosterCode").readOnly = false;
            document.getElementById("txtOffice").readOnly = false;
            document.getElementById("txtContact").readOnly = false;
            document.getElementById("txtERMobileNo").readOnly = false;
        };
        $scope.dropDownCheckForNIdCode = function () {
            if ($scope.obj.t03001.T_NTNLTY_ID === '') {
                alert($scope.getSingleMsg('S0095'));
                $scope.ddlfocusLost('txtNationalId');
                $scope.clearAllField();
                return;
            }
        }
        $scope.obj.t03001.T_RLGN_CODE = '';
        $scope.checkIslamReligionfromName = function(name) {
            checkIslamReligionfromName(name);
        };
        function checkIslamReligionfromName(name) {
            var nameList = ["MOHAMMED", "MOHAMMAD", "MOHAMMED", "MOHAMMAD", "MOHMED", "MOHMAD", "MOHD", "AHMED", "AHMAD"];
            if (name !== null) {
                for (var i = 0; i < nameList.length; i++) {
                    if (nameList[i] === name.toUpperCase()) {
                        $scope.obj.RG.selected = { T_RLGN_NAME: 'Islam', T_RLGN_CODE: '1' };
                    }
                }
            }
        }

        $scope.GenderValidationTrue = function() {
            document.getElementById("txtAddress").readOnly = true;
            document.getElementById("txtMobileNo").readOnly = true;
            document.getElementById("txtRes").readOnly = true;
            document.getElementById("txtEmail").readOnly = true;
            document.getElementById("txtPoBox").readOnly = true;
            document.getElementById("txtPosterCode").readOnly = true;
            document.getElementById("txtOffice").readOnly = true;
            document.getElementById("txtContact").readOnly = true;
            document.getElementById("txtERMobileNo").readOnly = true;
            document.getElementById("ddlNationalityId").disabled = true;
            document.getElementById("ddlReligionId").disabled = true;
            document.getElementById("ddlMaritialStatusId").disabled = true;
            document.getElementById("ddlERRelationId").disabled = true;
        };
        $scope.GenderValidationFalse = function() {
            document.getElementById("txtAddress").readOnly = false;
            document.getElementById("txtMobileNo").readOnly = false;
            document.getElementById("txtRes").readOnly = false;
            document.getElementById("txtEmail").readOnly = false;
            document.getElementById("txtPoBox").readOnly = false;
            document.getElementById("txtPosterCode").readOnly = false;
            document.getElementById("txtOffice").readOnly = false;
            document.getElementById("txtContact").readOnly = false;
            document.getElementById("txtERMobileNo").readOnly = false;
            document.getElementById("ddlNationalityId").disabled = false;
            document.getElementById("ddlReligionId").disabled = false;
            document.getElementById("ddlMaritialStatusId").disabled = false;
            document.getElementById("ddlERRelationId").disabled = false;
        };

    }]);

app.directive('arabiconly', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {
                    var transformedInput = text.replace(/[^\u0600-\u06FF]/g, '');

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