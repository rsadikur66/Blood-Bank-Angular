app.controller("T12337Controller", ["$scope", "T12337Service", "$filter", "$http", "$window", "Data",
    function ($scope, T12337Service, $filter, $http, $window, Data) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.t12337 = {};
        $scope.obj.Type = {};
        $scope.obj.Type.selected = {};
        $scope.obj.HospitalList = [];
        var indexForSetData = 0;
        var ddlText = '';
        console.log(ddlText);
        //page load
        gridLine();
        //blank row start
        //$scope.obj.Test = [];
        //$scope.obj.NewListv = {};
        //$scope.obj.Test.push($scope.obj.NewListv);
        //$scope.obj.HospitalList = $scope.obj.Test;
        //blank row end

        //var ListOfBankType = T12337Service.GetBankTypeList();
        //ListOfBankType.then(function (data) {
        //    $scope.BankTypeList = JSON.parse(data);
        //});

        $scope.modelidchange = function() {
            $scope.id = $scope.obj.BankTypeList;
            ddlText = $scope.id == '1' ? 'Central' : $scope.id == '2' ? 'Sub' : $scope.id == '3' ? 'Transfusion' : '';
            console.log(ddlText);
        }
        $scope.GetZoneList = function () {
            var ListOfZone = T12337Service.GetZoneList();
            ListOfZone.then(function (data) {
                $scope.ZoneList = JSON.parse(data);
            });
            document.getElementById("divZone").style.display = 'block';
        }

        $scope.GetSiteList = function (index) {
            var ListOfSite = T12337Service.GetSiteList();
            ListOfSite.then(function (data) {
                $scope.obj.SiteList = JSON.parse(data);
            });
            document.getElementById("SitePopUp").style.display = 'block';
          indexForSetData = index;
        }

        $scope.CloseSiteListPopup = function() {
            document.getElementById("SitePopUp").style.display = 'none';
        }
        $scope.setClickedRowSet = function (j, b) {
            $scope.ddlObj = ddlText;
            $scope.dataCount = '2';
            for (var i = 0; i < $scope.obj.HospitalList.length; i++) {
                if ($scope.obj.HospitalList[i].BankCode == b.CODE && $scope.obj.HospitalList[i].BankType1 == $scope.ddlObj) {
                    alert('This Site is already Exist.');
                    $scope.dataCount = '1';
                }
                //else {
                //    $scope.obj.HospitalList[indexForSetData].BankCode = b.CODE;
                //    $scope.obj.HospitalList[indexForSetData].BankNameEng = b.NAME;
                //    $scope.obj.HospitalList[indexForSetData].BankNameArb = b.NAME;
                //    document.getElementById("SitePopUp").style.display = 'none';
                //    $scope.obj.HospitalList[indexForSetData].BankType1 = $scope.obj.T_HOSP_CODE == '1' ? 'Central' : $scope.obj.T_HOSP_CODE == '2' ? 'Sub' : $scope.obj.T_HOSP_CODE == '3' ? 'Transfusion' : '';
                //}
            }
            if ($scope.dataCount != '1' && $scope.dataCount == '2') {
                $scope.obj.HospitalList[indexForSetData].BankCode = b.CODE;
                $scope.obj.HospitalList[indexForSetData].BankNameEng = b.NAME;
                $scope.obj.HospitalList[indexForSetData].BankNameArb = b.NAME;
                document.getElementById("SitePopUp").style.display = 'none';
                $scope.obj.HospitalList[indexForSetData].BankType1 = $scope.obj.T_HOSP_CODE == '1' ? 'Central' : $scope.obj.T_HOSP_CODE == '2' ? 'Sub' : $scope.obj.T_HOSP_CODE == '3' ? 'Transfusion' : '';
            }
            document.getElementById("SitePopUp").style.display = 'none';
        }
        $scope.onZoneSelect = function (i) {
            $scope.obj.T_REGION_CODE = $scope.ZoneList[i].CODE;
            $scope.obj.T_REGION_NAME = $scope.ZoneList[i].NAME;
            document.getElementById("divZone").style.display = 'none';
        }
        $scope.CloseZonePopup = function () {
            document.getElementById("divZone").style.display = 'none';
        }

        $scope.Next = function () {
            if ($scope.obj.T_REGION_CODE != undefined && $scope.obj.T_HOSP_CODE != undefined) {
                getGridData();
            } else {
                alert("You must input Bank Code and Bank Type!!!");
            }
        }

        $scope.Save = function () {
            var t12337 = $scope.obj.HospitalList;
            if (t12337.length > 0) {
                var insert;
                for (var i = 0; i < t12337.length; i++) {
                    if ($scope.obj.HospitalList[i].HiddenField != undefined && $scope.obj.HospitalList[i].HiddenField != '') {
                        var INS = {};
                        INS.BankCode = t12337[i].BankCode;
                        INS.BankNameEng = t12337[i].BankNameEng;
                        INS.BankNameArb = t12337[i].BankNameArb;
                        INS.BankType1 = $scope.obj.T_HOSP_CODE;
                        INS.Reorder = t12337[i].Reorder;
                        INS.Expiry = t12337[i].Expiry;
                        INS.BankTelephn = t12337[i].BankTelephn;
                        INS.BankManager = t12337[i].BankManager;
                        INS.MobileNo = t12337[i].MobileNo;
                        INS.T_ACTIVE = t12337[i].HiddenField;
                        INS.T_ZONE_CODE = $scope.obj.T_REGION_CODE;
                        insert = T12337Service.insertToT12337(INS);
                    } 
                        //else if ($scope.obj.HospitalList[i].HiddenField != undefined && $scope.obj.HospitalList[i].HiddenField != '') {
                    //    var UPD = {};
                    //    UPD.BankCode = t12337[i].BankCode;
                    //    UPD.BankNameEng = t12337[i].BankNameEng;
                    //    UPD.BankNameArb = t12337[i].BankNameArb;
                    //    UPD.BankType1 = t12337[i].BankType1;
                    //    UPD.Reorder = t12337[i].Reorder;
                    //    UPD.Expiry = t12337[i].Expiry;
                    //    UPD.BankTelephn = t12337[i].BankTelephn;
                    //    UPD.BankManager = t12337[i].BankManager;
                    //    UPD.MobileNo = t12337[i].MobileNo;
                    //    UPD.T_ACTIVE = t12337[i].HiddenField;
                    //    UPD.T_ZONE_CODE = $scope.obj.T_REGION_CODE;
                    //    insert = T12337Service.UpdateToT12337(UPD);
                    //}
                }//for
                insert.then(function (data) {
                    alert(data);
                });
            }
            //getGridData();
        }//funcitonSave


        $scope.ActiveCheckboxClicked = function (index) {
            var firstCompoCheck = document.getElementById("BBActive" + index).checked;
            //alert(firstCompoCheck);
            if (firstCompoCheck == true) {
                $scope.obj.HospitalList[index].HiddenField = '1';
            } else {
                $scope.obj.HospitalList[index].HiddenField = '2';
            }
            gridLine();
        }


        //$scope.checkvalue = function (i) {
        //    if ($scope.obj.HospitalList[i].HiddenField !== '') {
        //        return true;
        //    } else {
        //        return false;
        //    }
        //}

        $scope.PopUpOnf9 = function () {
            if (event.keyCode === 120) {
                var ListOfZone = T12337Service.GetZoneList();
                ListOfZone.then(function (data) {
                    $scope.ZoneList = JSON.parse(data);
                });
                document.getElementById("divZone").style.display = 'block'; 
            }
        }

        function getGridData() {
            var ListOfHospital = T12337Service.GetGridListData();
            ListOfHospital.then(function (data) {
                var hospitalListdata = JSON.parse(data);
                $scope.obj.HospitalList = [];
                for (var i = 0; i < hospitalListdata.length; i++) {
                    if ($scope.obj.BankTypeList == hospitalListdata[i].T_BANK_TYPE) {
                        $scope.obj.test = {};
                        $scope.obj.test.BankCode = hospitalListdata[i].T_SITE_CODE;
                        $scope.obj.test.BankNameEng = hospitalListdata[i].T_LANG2_NAME;
                        $scope.obj.test.BankNameArb = hospitalListdata[i].T_LANG1_NAME;
                        $scope.obj.test.BankType1 = hospitalListdata[i].T_BANK_TYPE == '1'
                            ? 'Central'
                            : hospitalListdata[i].T_BANK_TYPE == '2'
                            ? 'Sub'
                            : hospitalListdata[i].T_BANK_TYPE == '3'
                            ? 'Transfusion' : '';
                        $scope.obj.test.Reorder = hospitalListdata[i].T_REORDER_NO;
                        $scope.obj.test.Expiry = hospitalListdata[i].T_EXPIRE_DATE_NO;
                        $scope.obj.test.BankTelephn = hospitalListdata[i].T_BANK_TEL;
                        $scope.obj.test.BankManager = hospitalListdata[i].T_BANK_MGR;
                        $scope.obj.test.MobileNo = hospitalListdata[i].T_MGR_MOBILE_NO;
                        //$scope.obj.test.T_ACTIVE = hospitalListdata[i].T_ACTIVE;
                        if (hospitalListdata[i].T_BANK_ACTIVE === '1') {
                            $scope.obj.test.T_ACTIVE = true;
                            $scope.obj.test.HiddenField = hospitalListdata[i].T_BANK_ACTIVE;

                        } else {
                            $scope.obj.test.VIROLOGY_CHECK = false;
                            $scope.obj.test.HiddenField = hospitalListdata[i].T_BANK_ACTIVE;
                        }
                        $scope.obj.HospitalList.push($scope.obj.test);
                    }
                }
                gridLine();
            });
            
        }


        function gridLine() {
                for (var j = 0; j < 1; j++) {
                    $scope.obj.d = {};
                    $scope.obj.d.BankCode = '';

                    $scope.obj.d.BankNameEng = '';
                    $scope.obj.d.BankNameArb = '';
                    $scope.obj.d.BankType1 = '';
                    $scope.obj.d.Reorder = '';
                    $scope.obj.d.Expiry = '';
                    $scope.obj.d.BankTelephn = '';
                    $scope.obj.d.BankManager = '';
                    $scope.obj.d.MobileNo = '';
                   
                    $scope.obj.HospitalList.push($scope.obj.d);
                    //$scope.obj.HospitalList = $scope.obj.Test;


                }
            }
        
    }]);