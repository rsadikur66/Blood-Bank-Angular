app.controller("Q12012Controller", ["$scope", "Data", "Q12012Service", "$filter","$location","$window",
    function ($scope, Data, Q12012Service, $filter, $location,$window) {
        
        $scope.obj = {};
        $scope.obj = Data;
        //$scope.Newobj.aa = {};
        //$scope.Newobj.ab = {};
        //$scope.Newobj.ad = {};
        //$scope.Newobj.actrl = {};
        //$scope.Newobj.acell = {};
        //$scope.Newobj.bcell = {};
        //$scope.Newobj.scI = {};
        //$scope.Newobj.scII = {};
        //$scope.Newobj.scIII = {};
        //$scope.Newobj.acl = {};
        //$scope.Newobj.dc = {};

        //$scope.obj.aa.selected = {};
        $scope.obj.T_PAT_NO = '';
        $scope.obj.wd = true;
        


        var antiAllList = Q12012Service.antiAllList();
        antiAllList.then(function (data) {
            $scope.antiAllList = JSON.parse(data);
        });

        var dctList = Q12012Service.dctList();
        dctList.then(function (data) {
            $scope.dctList = JSON.parse(data);
        });

        $scope.NewArray = [];
        $scope.onReqSelect = function (data)
        {

            $scope.obj.T_PAT_NO = $scope.obj.xMatchList_1[0].T_PAT_NO;
            $scope.obj.PAT_NAME = $scope.obj.xMatchList_1[0].PAT_NAME;
            $scope.obj.YRS = $scope.obj.xMatchList_1[0].YRS;
            $scope.obj.MOS = $scope.obj.xMatchList_1[0].MOS;
            $scope.obj.GENDER = $scope.obj.xMatchList_1[0].GENDER;
            $scope.obj.NATIONALITY = $scope.obj.xMatchList_1[0].NATIONALITY;
            $scope.obj.MRTL_STTS = $scope.obj.xMatchList_1[0].MRTL_STTS;


            for (var i = 0; i < $scope.obj.xMatchList_1.length; i++)
            {
                $scope.Newobj = {}; $scope.Newobj.aa = {}; $scope.Newobj.ab = {}; $scope.Newobj.ad = {};
                $scope.Newobj.actrl = {}; $scope.Newobj.acell = {}; $scope.Newobj.bcell = {};$scope.Newobj.scI = {};
                $scope.Newobj.scII = {};$scope.Newobj.scIII = {};$scope.Newobj.acl = {};$scope.Newobj.dc = {};
                $scope.Newobj.aa.selected = {
                    T_ANTI_CODE: $scope.obj.xMatchList_1[i].T_ANTI_A,
                    T_ANTI_LEVEL: $scope.obj.xMatchList_1[i].T_ANTI_A_DESC
                };
                $scope.Newobj.ab.selected = {
                    T_ANTI_CODE: $scope.obj.xMatchList_1[i].T_ANTI_B,
                    T_ANTI_LEVEL: $scope.obj.xMatchList_1[i].T_ANTI_B_DESC
                };
                $scope.Newobj.ad.selected = {
                    T_ANTI_CODE: $scope.obj.xMatchList_1[i].T_ANTI_D,
                    T_ANTI_LEVEL: $scope.obj.xMatchList_1[i].T_ANTI_D_DESC
                };
                $scope.Newobj.actrl.selected = {
                    T_ANTI_CODE: $scope.obj.xMatchList_1[i].T_CONTROL,
                    T_ANTI_LEVEL: $scope.obj.xMatchList_1[i].T_CONTROL_DESC
                };
                $scope.Newobj.acell.selected = {
                    T_ANTI_CODE: $scope.obj.xMatchList_1[i].T_CELLS_A,
                    T_ANTI_LEVEL: $scope.obj.xMatchList_1[i].T_CELLS_A_DESC
                };
                $scope.Newobj.bcell.selected = {
                    T_ANTI_CODE: $scope.obj.xMatchList_1[i].T_CELLS_B,
                    T_ANTI_LEVEL: $scope.obj.xMatchList_1[i].T_CELLS_B_DESC
                };
                $scope.Newobj.T_BLOOD_GROUP = $scope.obj.xMatchList_1[i].T_BLOOD_GROUP;
                $scope.Newobj.T_BLOOD_GROUP_DESC = $scope.obj.xMatchList_1[i].T_BLOOD_GROUP_DESC;
                $scope.Newobj.scI.selected = {
                    T_ANTI_CODE: $scope.obj.xMatchList_1[i].T_ANTI_D,
                    T_ANTI_LEVEL: $scope.obj.xMatchList_1[i].T_ANTI_D_DESC
                };
                $scope.Newobj.scII.selected = {
                    T_ANTI_CODE: $scope.obj.xMatchList_1[i].T_CONTROL,
                    T_ANTI_LEVEL: $scope.obj.xMatchList_1[i].T_CONTROL_DESC
                };
                $scope.Newobj.scIII.selected = {
                    T_ANTI_CODE: $scope.obj.xMatchList_1[i].T_CELLS_A,
                    T_ANTI_LEVEL: $scope.obj.xMatchList_1[i].T_CELLS_A_DESC
                };
                $scope.Newobj.acl.selected = {
                    T_ANTI_CODE: $scope.obj.xMatchList_1[i].T_CELLS_B,
                    T_ANTI_LEVEL: $scope.obj.xMatchList_1[i].T_CELLS_B_DESC
                    };
               
                $scope.Newobj.dc.selected = {
                    T_CODE: $scope.obj.xMatchList_1[i].T_DCT,
                    NAME: $scope.obj.xMatchList_1[i].T_DCT_DESC
                };
                $scope.Newobj.ANTIBODY_IDENTIFICATION = $scope.obj.xMatchList_1[i].ANTIBODY_IDENTIFICATION;
                $scope.Newobj.TECH_NAME = $scope.obj.xMatchList_1[i].TECH_NAME;
                $scope.Newobj.T_ENTRY_DATE = $scope.obj.xMatchList_1[i].T_ENTRY_DATE;
                $scope.Newobj.T_TS_START_TIME = $scope.obj.xMatchList_1[i].T_TS_START_TIME;
                $scope.NewArray.push($scope.Newobj);

            } 

            $scope.ListOfDat = $scope.NewArray;
            $scope.NewArray = [];
        }

        //$scope.onPatSearch_Blur = function() {
        //    var n = $scope.obj.T_PAT_NO;
        //    if (n !== null) {
        //        var a = $scope.pad(n, 8);
        //        $scope.obj.T_PAT_NO = a == '00000000' ? '' : a;
        //    }
        //}

        $scope.onPatSearch_tab = function(e) {
            if (e.keyCode === 9 || e.keyCode === 13) {
                var n = $scope.obj.T_PAT_NO;
                if (n !== null) {
                    var a = $scope.pad(n, 8);
                    $scope.obj.T_PAT_NO = a == '00000000' ? '' : a;
                    var xMatchList = Q12012Service.xMatchList($scope.obj.T_PAT_NO);
                    xMatchList.then(function(data) {
                        var dt = JSON.parse(data);
                        if (dt.length > 0) {
                            $scope.obj.xMatchList_1 = dt;
                            $scope.onReqSelect(0);
                        } else {
                            alert("No Data Found");
                        }
                    });
                }
            }
        }

        $window.onload = function () {
            var a = $location.absUrl().split('=')[1];
            
            if (!a) {}
            else {
                sessionStorage.setItem("FFlag", JSON.stringify("T12302"));
                var xMatchList = Q12012Service.xMatchList(a);
                xMatchList.then(function(data) {
                    var dt = JSON.parse(data);
                    if (dt.length > 0) {
                        $scope.obj.xMatchList_1 = dt;
                        $scope.onReqSelect(0);
                    } else {
                        alert("No Data Found");
                    }
                });
            }
        }

    }]);