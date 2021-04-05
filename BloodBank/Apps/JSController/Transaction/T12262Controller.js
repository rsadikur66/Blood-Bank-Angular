app.controller("T12262Controller", ["$scope", "$filter", "T12262Service", "Data", "$interval", function ($scope, $filter, T12262Service, Data, $interval) {
    $scope.obj = {};
    $scope.obj = Data;
    $scope.obj.t12262 = {};
    loadRequestGrid();
    $scope.obj.ChkReceive = 'Disable';
    $scope.SiteCode_dblClick = function () {
        var dataBySiteCode = T12262Service.getDataBySiteCode();
        dataBySiteCode.then(function (data) {
            $scope.SiteList = JSON.parse(data);
            if ($scope.SiteList.length > 0) {
                document.getElementById("divSite").style.display = 'block';
            } else {
                document.getElementById("divSite").style.display = 'none';
            }
        });
    };
    $interval(function () {
        loadRequestGrid();
    }, 5000);
    function loadRequestGrid() {
        var dataRequest = T12262Service.getRequestDetail();
        dataRequest.then(function (data) {
            $scope.obj.RequestList = JSON.parse(data);
        });
    }
    $scope.BloodRequestReceive = function (i, tempObj) {
        debugger;
        $scope.obj.t12262 = {};
        $scope.obj.t12262.T_Received_FLAG = '1';
        $scope.obj.t12262.T_BLOOD_REQNO = tempObj.T_BLOOD_REQNO;
        $scope.obj.t12262.T_RECEIVE_TIME = $filter('date')(new Date(), "HHmm");
        $scope.obj.t12262.T_SITE_CODE = tempObj.T_SITE_CODE;
        $scope.Save();
    };
    $scope.onSiteRowSelect = function (ind, data) {
        $scope.obj.t12262.T_BANK_CODE = $scope.SiteList[ind].T_BANK_CODE;
        $scope.obj.t12262.T_NAME = $scope.SiteList[ind].T_LANG2_NAME;//+ ' ' + $scope.SiteList[ind].T_LANG1_NAME;
        document.getElementById("divSite").style.display = 'none';
    };
    $scope.RequestNo_dblClick = function () {
        $scope.UnitNewlist = [];
        var requestNoData = T12262Service.getDataRequestNo($scope.obj.t12262.T_BANK_CODE);
        requestNoData.then(function (data) {
            //$scope.BloodReqList = JSON.parse(data);
            $scope.datalist = JSON.parse(data);
            if ($scope.datalist.length > 0) {
                for (var i = 0; i < $scope.datalist.length; i++) {
                    $scope.newObj = {};
                    $scope.newObj.T_BLOOD_REQNO = $scope.datalist[i].T_BLOOD_REQNO; //T_BLOOD_REQTIME
                    $scope.newObj.T_BLOOD_REQTIME = $scope.datalist[i].T_BLOOD_REQTIME;
                    $scope.newObj.T_SITE_CODE = $scope.datalist[i].T_SITE_CODE;
                    $scope.newObj.T_BLOOD_REQDATE = $filter('date')($scope.datalist[i].T_BLOOD_REQDATE, 'dd-MMM-yyyy');
                    $scope.UnitNewlist.push($scope.newObj);
                }
                $scope.BloodReqList = $scope.UnitNewlist;
                $scope.UnitNewlist = [];
                document.getElementById("divRequest").style.display = 'block';
            } else {
                document.getElementById("divRequest").style.display = 'none';
            }


        });
    };
    $scope.onRequestSelect = function (ind, data) {
        $scope.selectedRow = ind;
        $scope.obj.t12262.T_BLOOD_REQNO = data.T_BLOOD_REQNO;
        $scope.obj.t12262.T_BLOOD_REQDATE = data.T_BLOOD_REQDATE;
        $scope.obj.t12262.T_BLOOD_REQTIME = data.T_BLOOD_REQTIME;
        $scope.obj.t12262.T_SITE_CODE = data.T_SITE_CODE;
        document.getElementById("divRequest").style.display = 'none';
    };
    $scope.Next = function () {
        var requestDetails = T12262Service.getRequestDetails($scope.obj.t12262.T_BLOOD_REQNO, $scope.obj.t12262.T_SITE_CODE);
        requestDetails.then(function (data) {
            $scope.Details = JSON.parse(data);
            if ($scope.Details.length > 0) {
                $scope.obj.t12262.T_REF_HOSP = $scope.Details[0].T_REF_HOSP;
                $scope.obj.t12262.T_REFERRAL_NAME = $scope.Details[0].T_REFERRAL_NAME;
                $scope.obj.t12262.T_BLOOD_GRP = $scope.Details[0].T_BLOOD_GRP;
                $scope.obj.t12262.BLD_NAME = $scope.Details[0].BLD_NAME;
                $scope.obj.t12262.T_PRODUCT_CODE = $scope.Details[0].T_PRODUCT_CODE;
                $scope.obj.t12262.T_PRODUCT_NAME = $scope.Details[0].T_PRODUCT_NAME;
                $scope.obj.t12262.T_NUM_UNIT = $scope.Details[0].T_NUM_UNIT;
                $scope.obj.t12262.T_PRODUCT_NAME = $scope.Details[0].T_PRODUCT_NAME;
                $scope.obj.t12262.T_SITE_CODE = $scope.Details[0].T_SITE_CODE;
                $scope.obj.ChkReceive = 'Enable';
            } else {
                $scope.obj.ChkReceive = 'Disable';
            }
        });
    };
    $scope.Receive_Flag = function () {
        var id = $scope.obj.t12262.T_Received_FLAG;
        if ($scope.obj.t12262.T_Received_FLAG == '1') {
            var userDetails = T12262Service.getuserDetails();
            userDetails.then(function (data) {
                $scope.Details = JSON.parse(data);
                $scope.obj.t12262.T_EMP_CODE = $scope.Details[0].T_EMP_CODE;
                $scope.obj.t12262.T_USER_NAME = $scope.Details[0].T_USER_NAME;
                $scope.obj.t12262.T_RECEIVE_DATE = $filter('date')(new Date(), "dd/MM/yyyy");
                $scope.obj.t12262.T_RECEIVE_TIME = $filter('date')(new Date(), "HHmm");
            });
        } else {
            $scope.obj.t12262.T_EMP_CODE = '';
            $scope.obj.t12262.T_USER_NAME = '';
            $scope.obj.t12262.T_RECEIVE_DATE = '';
            $scope.obj.t12262.T_RECEIVE_TIME = '';
        }
        //  function Date() {
        // var date = new Date();
        // $scope.ddMMyyyy = $filter('date')(new Date(), 'dd-MM-yyyy');
        // $scope.ddMMMMyyyy = $filter('date')(new Date(), 'dd, MMMM yyyy');
        // $scope.HHmmss = $filter('date')(new Date(), 'HH:mm:ss');
        // $scope.hhmmsstt = $filter('date')(new Date(), 'hh:mm:ss a');
        // };
    };
    $scope.Save = function () {
        if ($scope.obj.t12262.T_Received_FLAG == '1') {
            var save = T12262Service.save($scope.obj.t12262.T_BLOOD_REQNO, $scope.obj.t12262.T_RECEIVE_TIME, $scope.obj.t12262.T_SITE_CODE);
            save.then(function (data) {
                var dt = JSON.parse(data);
                $scope.obj.t12262 = {};
                $scope.obj.ChkReceive = 'Disable';
                alert($scope.getSingleMsg(dt));
                loadRequestGrid();
            });
        } else {
            alert('Check Receive');
        }
    };
    $scope.ClosePopup = function (id) {
        document.getElementById(id).style.display = 'none';
    };
}
]);