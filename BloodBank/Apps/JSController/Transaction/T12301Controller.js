app.controller("T12301Controller", ["$scope", "$filter", "$http", "$window", "T12301Service", "Data",
    function ($scope, $filter, $http, $window, T12301Service, Data) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.t12012 = [];
        $scope.obj.t12012.T_REQUEST_NO = '';
        $scope.obj.t12012.T_REQ_REC_TIME = '';
        $scope.obj.t12012.T_REQ_REC_DATE = '';
        //$scope.obj.T_BLOOD_BRING = '';
        //$scope.obj.T_LAB_NO = '';
        $scope.obj.Current_T_EMP_CODE = '';

       

        document.getElementById("txtRequestNo").focus();
        $scope.btnf9_RequestList = function (e) {
            if (e.keyCode === 120) {
                e.preventDefault();
                RequestPopUp();
            }

            if (e.keyCode === 120) {
                onReqSearch_blur($scope.obj.T_EMP_CODE);
            }
        };
        $scope.btnf9_UserList = function (e) {
            if (e.keyCode === 120) {
                e.preventDefault();
                UserPopUp();
            }
        };

        $scope.EnterFuction = function (event, T_REQUEST_NO) {
            $scope.obj.T_REQUEST_NO = $scope.pad(T_REQUEST_NO, 8);
            var patInfo = T12301Service.GetPatInfo($scope.obj.T_REQUEST_NO);
            patInfo.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length == 0) {
                    alert($scope.getSingleMsg('S0194'));
                    $scope.clearField();
                    return;
                }
                else if (dt[0].T_REQ_STATUS === "1") {
                    alert($scope.getSingleMsg('S0715'));
                    $scope.clearField();
                    return;
                }
                $scope.obj.T_PAT_NO = dt[0].T_PAT_NO;
                $scope.obj.T_PAT_NAME = dt[0].T_PAT_NAME;
                $scope.obj.T_REQUEST_DATE = $filter('date')(dt[0].T_REQUEST_DATE, "dd/MM/yyyy");
                $scope.obj.T_REQUEST_DATE_ARB = moment(dt[0].T_REQUEST_DATE).format('iDD/iMM/iYYYY');
                $scope.obj.YRS = dt[0].YRS;
                $scope.obj.MOS = dt[0].MOS;
                $scope.obj.T_NATIONALITY = dt[0].T_NATIONALITY;
                $scope.obj.T_GENDER = dt[0].T_GENDER;
                $scope.obj.T_MARITIAL_STATUS = dt[0].T_MARITIAL_STATUS;
                $scope.obj.T_LOCATION_CODE = dt[0].T_LOCATION_CODE;
                $scope.obj.T_LOCATION_NAME = dt[0].T_LOCATION_NAME;
                $scope.obj.t12012.T_REQUEST_NO = $scope.obj.T_REQUEST_NO;
            });
        }
        $scope.Clear = function () {
            $scope.clearField();
        }
        $scope.Next = function () {
            $scope.EnterFuction(event, $scope.obj.T_REQUEST_NO);
        };
        $scope.EnterRequest = function (event, T_REQUEST_NO) {
            if (event.keyCode === 13) {
                $scope.EnterFuction(event, T_REQUEST_NO);
            }
        };
        $scope.PopUpRequestList = function () {
            RequestPopUp();
        };
        $scope.PopUpUserList = function () {
            UserPopUp();
        };

        function RequestPopUp() {
            $scope.SearchUnit = '';
            var RequestList = T12301Service.GetRequestNoPopUp();
            RequestList.then(function (data) {
                $scope.RequestList = JSON.parse(data);
            });

            document.getElementById("divRequestList").style.display = 'block';
        }

        function UserPopUp() {
            if ($scope.obj.T_REQUEST_NO == undefined || $scope.obj.T_REQUEST_NO === '') {
                alert($scope.getSingleMsg('S0005'));
                return;
            }
            var UserList = T12301Service.GetUserListPopUp(null);
            UserList.then(function (data) {
                $scope.UserList = JSON.parse(data);
            });
            document.getElementById("divUserList").style.display = 'block';
        }



        $scope.onRequestPopUpSelect = function (i) {
            $scope.obj.T_REQUEST_NO = $scope.RequestList[i].T_REQUEST_NO;
            $scope.EnterFuction(event, $scope.obj.T_REQUEST_NO);
            document.getElementById("divRequestList").style.display = 'none';
        };

        $scope.CloseRequestListPopup = function () {
            document.getElementById("divRequestList").style.display = 'none';
        };
        $scope.CloseUserListPopup = function () {
            document.getElementById("divUserList").style.display = 'none';
        };


        $scope.onReqSearch_blur = function(code) {
                if ($scope.obj.T_REQUEST_NO == undefined || $scope.obj.T_REQUEST_NO === '') {
                    //alert($scope.getSingleMsg('S0005'));
                    $scope.obj.T_EMP_CODE = '';
                    return;
                }
                var UserListByCode = T12301Service.GetUserListPopUpByCode(code);
            UserListByCode.then(function(data) {
                var ULByCode = JSON.parse(data);

                $scope.obj.T_USER_NAME = ULByCode[0].T_USER_NAME;
                $scope.obj.T_EMP_CODE = ULByCode[0].T_EMP_CODE;

            });

        }

        $scope.onRequestCarryBy = function (i) {

            if (!$scope.obj.T_BLOOD_BRING) {
               
                $scope.obj.Current_T_USER_NAME = '';
                $scope.obj.Current_T_EMP_CODE = '';
                $scope.obj.getCurrentDate = '';
                $scope.obj.getCurrentTime = '';
                $scope.obj.t12012.T_REQ_REC_TIME = '';
                $scope.obj.t12012.T_REQ_REC_DATE = '';
            } else {
                if ($scope.obj.Current_T_EMP_CODE == '')
                    $scope.setCurrentUser();
                $scope.obj.getCurrentDate = $scope.getCurrentDate();
                $scope.obj.getCurrentTime = $scope.getCurrentTime();
                $scope.obj.t12012.T_REQ_REC_TIME = $scope.obj.getCurrentTime;
                $scope.obj.t12012.T_REQ_REC_DATE = $scope.obj.getCurrentDate;
            }
        };

        $scope.onUserPopUpSelect = function (i) {
            $scope.obj.T_USER_NAME = $scope.UserList[i].T_USER_NAME;
            $scope.obj.T_EMP_CODE = $scope.UserList[i].T_EMP_CODE;

            document.getElementById("divUserList").style.display = 'none';

            //if ($scope.obj.Current_T_EMP_CODE == '')
            //    $scope.setCurrentUser();
            //$scope.obj.getCurrentDate = $scope.getCurrentDate();
            //$scope.obj.getCurrentTime = $scope.getCurrentTime();
            //$scope.obj.t12012.T_REQ_REC_TIME = $scope.obj.getCurrentTime;
            //$scope.obj.t12012.T_REQ_REC_DATE = $scope.obj.getCurrentDate;
            //document.getElementById("divUserList").style.display = 'none';
        };

        $scope.setCurrentUser = function () {
            var currentUserInfo = T12301Service.GetCurrentUser();
            currentUserInfo.then(function (data) {
                var dt = JSON.parse(data);
                $scope.obj.Current_T_EMP_CODE = dt[0].T_EMP_CODE;
                $scope.obj.Current_T_USER_NAME = dt[0].T_USER_NAME;
            });
        }
        $scope.CloseUserListPopup = function () {
            document.getElementById("divUserList").style.display = 'none';
        };

        ////Blood Group Function End
        $scope.Save = function () {
            var t12012 = $scope.obj.t12012;
            if ($scope.obj.t12012.T_REQUEST_NO != '') {
                if ($scope.obj.t12012.T_REQ_REC_DATE != '') {
                    $scope.obj.t12012.T_REQ_REC_DATE = $scope.dateParse($scope.obj.getCurrentDate, "/");
                } else {
                    $scope.obj.t12012.T_REQ_REC_DATE = '';
                }
                if ($scope.obj.T_EMP_CODE === '' || $scope.obj.T_EMP_CODE == undefined) {
                    alert($scope.getSingleMsg('S0005'));
                    return;
                }
                var update = T12301Service.updateT12012($scope.obj.t12012.T_REQUEST_NO,
                    $scope.obj.T_BLOOD_BRING,
                    $scope.obj.T_LAB_NO,
                    $scope.obj.t12012.T_REQ_REC_DATE,
                    $scope.obj.t12012.T_REQ_REC_TIME);
                update.then(function (data) {
                    var dt = JSON.parse(data);
                    if (dt == 'Data save successfully') {
                        alert($scope.getSingleMsg('N0024'));
                    } else {
                        alert(dt);
                    }
                    $scope.clearField();
                    $scope.obj.t12012 = [];
                });
            } else {
                alert($scope.getSingleMsg('S0005'));
                return;
            }
        }

        $scope.getCurrentDate = function () {
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1; //January is 0!
            var yyyy = today.getFullYear();

            if (dd < 10) {
                dd = '0' + dd;
            }

            if (mm < 10) {
                mm = '0' + mm;
            }

            today = dd + '/' + mm + '/' + yyyy;
            return today;
        }

        $scope.getCurrentTime = function () {
            var date = new Date();
            var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
            var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
            var gettime = hours + ':' + minutes;
            return gettime;
        }

        $scope.clearField = function () {
            $scope.obj.t12012.T_REQUEST_NO = '';
            $scope.obj.t12012.T_REQ_REC_TIME = '';
            $scope.obj.t12012.T_REQ_REC_DATE = '';
            $scope.obj.T_PAT_NO = '';
            $scope.obj.T_PAT_NAME = '';
            $scope.obj.T_REQUEST_DATE = '';
            $scope.obj.T_REQUEST_DATE_ARB = '';
            $scope.obj.YRS = '';
            $scope.obj.MOS = '';
            $scope.obj.T_NATIONALITY = '';
            $scope.obj.T_GENDER = '';
            $scope.obj.T_MARITIAL_STATUS = '';
            $scope.obj.T_LOCATION_CODE = '';
            $scope.obj.T_LOCATION_NAME = '';
            $scope.obj.T_EMP_CODE = '';
            $scope.obj.T_USER_NAME = '';
            $scope.obj.Current_T_EMP_CODE = '';
            $scope.obj.Current_T_USER_NAME = '';
            $scope.obj.getCurrentDate = '';
            $scope.obj.getCurrentTime = '';
            $scope.obj.T_REQUEST_NO = '';
            $scope.obj.T_BLOOD_BRING = '';
            $scope.obj.T_LAB_NO = '';
        }
        $scope.Enter = function () {
            if (document.getElementById("btnEnterQuery").className === "Button Cancel") {
                document.getElementById("btnEnterQuery").className = "Button Enter";
                document.getElementById("btnSave").disabled = false;
                document.getElementById("btnDelete").disabled = false;
                document.getElementById("btnNext").disabled = false;
                return;
            }
            document.getElementById("btnEnterQuery").className = "Button Cancel";
            document.getElementById("btnSave").disabled = true;
            document.getElementById("btnDelete").disabled = true;
            document.getElementById("btnNext").disabled = true;
            document.getElementById("txtRequestNo").focus();
        }
        $scope.Execute = function (T_REQUEST_NO) {
            if (T_REQUEST_NO == undefined || T_REQUEST_NO === '') {
                alert($scope.getSingleMsg('S0005'));
                $scope.Enter();
                return;
            }
            $scope.EnterFuction(event, T_REQUEST_NO);
            $scope.Enter();
        }

    }]);