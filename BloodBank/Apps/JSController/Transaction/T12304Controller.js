app.controller("T12304Controller", ["$scope", "T12304Service", "Data", "$window", "$filter",
    function ($scope, T12304Service, Data, $window, $filter) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.t12304 = {};
        var Language = JSON.parse(sessionStorage.getItem("LangName"));
        document.getElementById('txtRequest').focus();

        $scope.onReqestSearch_Tab = function (e) {
            if (e.keyCode === 9 || e.keyCode === 13) {
                var p = $scope.obj.T_REQUEST_NO;
                if (p !== null) {
                    var a = $scope.pad(p, 8);
                    $scope.obj.T_REQUEST_NO = a == '00000000' ? '' : a;
                    requestNoData($scope.obj.T_REQUEST_NO);
                    SecondGridData();
                    //sessionStorage.setItem('req', JSON.stringify($scope.obj.T_REQUEST_NO));

                }
            }
        };

        var secondTestData = [];

        function SecondGridData() {
            var SecondGridDataList = T12304Service.SecondGetGridDataList($scope.obj.T_REQUEST_NO);
            SecondGridDataList.then(function (data) {
                secondTestData = JSON.parse(data);
                $scope.obj.secondPart = [];
                for (var i = 0; i < secondTestData.length; i++) {
                    if (secondTestData[i].T_BLOOD_GROUP_CODE !== null) {
                        $scope.obj.test = {};
                        $scope.obj.test.T_UNIT_NO = secondTestData[i].T_UNIT_NO;
                        $scope.obj.test.T_BLOOD_GROUP_CODE = secondTestData[i].T_BLOOD_GROUP_CODE;
                        $scope.obj.test.T_PRODUCT_CODE = secondTestData[i].T_PRODUCT_CODE;
                        $scope.obj.test.T_EXPIRY_DATE = secondTestData[i].T_EXPIRY_DATE;
                        $scope.obj.test.T_AUTO_ISSUE_ID = secondTestData[i].T_AUTO_ISSUE_ID;
                        $scope.obj.test.T_AUTO_ISSUE_DET_ID = secondTestData[i].T_AUTO_ISSUE_DET_ID;
                        $scope.obj.test.T_BLOOD_ISSUED_BY = secondTestData[i].T_BLOOD_ISSUED_BY;
                        $scope.obj.test.T_BLOOD_RECEIVED_BY = secondTestData[i].T_RECEIVED_BY;

                        var ISSUED_BY_NAME = T12304Service.GetIssuedbyName(secondTestData[i].T_BLOOD_ISSUED_BY);
                        ISSUED_BY_NAME.then(function (datax) {
                            $scope.nameIssuedby = JSON.parse(datax);
                        });
                        $scope.obj.test.T_BLOOD_ISSUED_BY_DESC = $scope.nameIssuedby;
                        $scope.obj.test.T_ISSUE_FLAG = secondTestData[i].T_ISSUE_FLAG;
                        $scope.obj.test.T_VISUAL_INSPECTION = secondTestData[i].T_VIS_INSP;
                        if (secondTestData[i].T_ISSUE_FLAG === '1') {
                            $scope.obj.test.T_ISSUE_FLAG = "1";
                            $scope.obj.test.hiddenField1 = '1';
                            $scope.obj.test.hiddenField2 = '1';
                            $scope.obj.test.T_ISSUE_DATE = secondTestData[i].T_ISSUE_DATE;
                            $scope.obj.test.T_ISSUE_TIME = secondTestData[i].T_ISSUE_TIME;
                            $scope.obj.test.T_BLOOD_ISSUED_BY_DESC = secondTestData[i].T_ISSUED_BY_NAME;
                            $scope.obj.test.T_BLOOD_ISSUED_BY = secondTestData[i].T_ISSUED_BY;
                        } else {
                            $scope.obj.test.T_ISSUE_FLAG = "2";
                            $scope.obj.test.hiddenField1 = '';
                            $scope.obj.test.hiddenField2 = '';
                        }
                        $scope.obj.secondPart.push($scope.obj.test);
                    } else {
                        alert("No data found!!!");
                        clear();
                    }

                }
                //document.getElementById("2ndDiv").style.display = 'block';
                //$scope.blur = false;


            });
        }

        $scope.disable = function (i) {
            if ($scope.obj.secondPart[i].hiddenField1 === '1' && $scope.obj.secondPart[i].hiddenField2 === '1') {
                return true;
            } else {
                return false;
            }
        };
        $scope.checkVI = function () {
            for (var i = 0; i < $scope.obj.secondPart.length; i++) {
                if ($scope.obj.T_TAG_BARCODE == $scope.obj.secondPart[i].T_UNIT_NO) {
                    //$scope.obj.T_LABEL_BARCODE = $scope.obj.secondPart[i].T_UNIT_NO;
                    document.getElementById('VisualInspection' + i).checked = true;
                    $scope.obj.secondPart[i].T_VISUAL_INSPECTION = '1';
                    $scope.obj.secondPart[i].T_BLOOD_ISSUED_BY_DESC = JSON.parse(sessionStorage.getItem("UserName"));
                    $scope.obj.secondPart[i].T_BLOOD_ISSUED_BY = JSON.parse(sessionStorage.getItem("EmpCode"));

                }
            }
        };

        $scope.checkIssuYNOnBlur = function () {
            for (var i = 0; i < $scope.obj.secondPart.length; i++) {
                if ($scope.obj.T_LABEL_BARCODE == $scope.obj.secondPart[i].T_UNIT_NO) {
                    //$scope.obj.T_LABEL_BARCODE = $scope.obj.secondPart[i].T_UNIT_NO;
                    document.getElementById('chekIssuedYN' + i).checked = true;
                    $scope.obj.secondPart[i].T_ISSUE_FLAG = '1';
                    $scope.obj.secondPart[i].T_ISSUE_DATE = $filter('date')(new Date(), "dd-MMM-yy");
                    $scope.obj.secondPart[i].T_ISSUE_TIME = ('0' + new Date().getHours()).slice(-2) + ":" + ('0' + new Date().getMinutes()).slice(-2);
                }
            }
        };

        $scope.clickIssue = function (index) {
            //if (document.getElementById('VisualInspection' + index).checked === true) {
            if (document.getElementById('chekIssuedYN' + index).checked === true) {
                $scope.obj.secondPart[index].T_ISSUE_DATE = $filter('date')(new Date(), "dd-MMM-yy");
                $scope.obj.secondPart[index].T_ISSUE_TIME = ('0' + new Date().getHours()).slice(-2) + ":" + ('0' + new Date().getMinutes()).slice(-2);
                $scope.obj.secondPart[index].hiddenField1 = '2';
            } else {
                $scope.obj.secondPart[index].T_ISSUE_DATE = '';
                $scope.obj.secondPart[index].T_ISSUE_TIME = '';
                $scope.obj.secondPart[index].hiddenField1 = '';
            }
            //}
            //else {
            //    alert('Must check Vis inspection before issue!!!!');
            //}
        };

        $scope.checkViClick = function (i) {
            if (document.getElementById('VisualInspection' + i).checked === true) {
                $scope.obj.secondPart[i].T_BLOOD_ISSUED_BY = JSON.parse(sessionStorage.getItem("EmpCode"));
                $scope.obj.secondPart[i].T_BLOOD_ISSUED_BY_DESC = JSON.parse(sessionStorage.getItem("UserName"));
                $scope.obj.secondPart[i].hiddenField2 = '2';
            }
            else {
                $scope.obj.secondPart[i].T_BLOOD_ISSUED_BY = '';
                $scope.obj.secondPart[i].T_BLOOD_ISSUED_BY_DESC = '';
                $scope.obj.secondPart[i].hiddenField2 = '';
            }
        };

        $scope.Save = function () {
            //new code
            var status = '';
            $scope.obj.T12304List = [];
            for (var i = 0; i < $scope.obj.secondPart.length; i++) {
                //if ($scope.obj.secondPart[i].hiddenField1 == '2' && $scope.obj.secondPart[i].T_BLOOD_ISSUED_BY !== undefined) {
                if ($scope.obj.secondPart[i].hiddenField1 == '2' && $scope.obj.secondPart[i].hiddenField2 == '2') {
                    $scope.obj.T12304List.push($scope.obj.secondPart[i]);
                    console.log($scope.obj.T12304List);
                }
            }
            if ($scope.obj.T12304List.length > 0) {
                status = 'successfull';

            }
            if (status == 'successfull') {
                var insert = T12304Service.insertT12304($scope.obj.T12304List);

                insert.then(function (msg) {
                    alert(msg);
                    SecondGridData();
                });
                //SecondGridData();
                //alert('data updated successfully!!!!');

            } else {
                //alert('Issue Y/N and Vis Insp checkbox must be checked..!!!');
                alert($scope.getSingleMsg('S0716'));
                SecondGridData();
            }
        };

        $scope.T12304_print = function () {
            $window.open("../T12304/getR12046_Report?reqno=" + $scope.obj.T_REQUEST_NO, "popup", "width=600,height=600,left=100,top=50");
        }

        $scope.ReqNoList = function () {
            ReqNoListPopUp();
            document.getElementById("divReqNoPopUp").style.display = 'block';
        };
        $scope.CloseReqNoListPopup = function () {
            document.getElementById("divReqNoPopUp").style.display = 'none';
        };


        function ReqNoListPopUp() {
            var ListofReqNo = T12304Service.GetReqNoList();
            ListofReqNo.then(function (data) {
                $scope.obj.ReqNoList = JSON.parse(data);
            });
            document.getElementById("divReqNoPopUp").style.display = 'block';
        }

        $scope.onSiteListSelect = function (i, e) {
            $scope.obj.T_REQUEST_NO = e.T_REQUEST_NO;
            requestNoData(e.T_REQUEST_NO);
            SecondGridData();
            document.getElementById("divReqNoPopUp").style.display = 'none';
        };


        function requestNoData(reqno) {
            var reqList = T12304Service.reqList(reqno);
            reqList.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    //$scope.obj.reqList_1 = dt;
                    //$scope.onReqSelect(0);
                    $scope.obj.T_REQUEST_DATE = dt[0].T_REQUEST_DATE;
                    $scope.obj.T_REQUEST_DATE_H = moment(dt[0].T_REQUEST_DATE).format('iDD/iMM/iYYYY');
                    $scope.obj.T_PAT_NO = dt[0].T_PAT_NO;
                    $scope.obj.PAT_NAME = dt[0].PAT_NAME;
                    $scope.obj.PAT_NAME = dt[0].PAT_NAME;
                    $scope.obj.YRS = dt[0].YRS;
                    $scope.obj.MOS = dt[0].MOS;
                    $scope.obj.GENDER = dt[0].GENDER;
                    $scope.obj.NATIONALITY = dt[0].NATIONALITY;
                    $scope.obj.MRTL_STTS = dt[0].MRTL_STTS;
                    $scope.obj.T_LOCATION_CODE = dt[0].T_LOCATION_CODE;
                    $scope.obj.LOC_DESC = dt[0].LOC_DESC;
                    //SecondGridData();
                } else {
                    alert('No Data Found.');
                    clear();
                }
            });
        }
        $scope.Clear = function () {
            clear();
        }
        function clear() {
            $scope.obj.T_REQUEST_NO = '';
            $scope.obj.T_REQUEST_DATE = '';
            $scope.obj.T_REQUEST_DATE_H = '';
            $scope.obj.T_PAT_NO = '';
            $scope.obj.PAT_NAME = '';
            $scope.obj.PAT_NAME = '';
            $scope.obj.YRS = '';
            $scope.obj.MOS = '';
            $scope.obj.GENDER = '';
            $scope.obj.NATIONALITY = '';
            $scope.obj.MRTL_STTS = '';
            $scope.obj.T_LOCATION_CODE = '';
            $scope.obj.LOC_DESC = '';
            $scope.obj.secondPart = [];
        }
    }]);


