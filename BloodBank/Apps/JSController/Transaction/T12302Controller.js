app.controller("T12302Controller", ["$scope", "Data", "T12302Service", "$filter", "$window",
    function ($scope, Data, T12302Service, $filter,$window) {
        
        clear();
       
        function clear() {
            $scope.obj = {};
            $scope.obj = Data;

            $scope.obj.T_ABO_CODE = '';
            $scope.obj.T_TYPE = '';
            $scope.obj.ddlCells = false;
            $scope.obj.ddlAnti = false;
            $scope.jso = { T_ANTI_LEVEL: 'Select' };
            $scope.obj.AntA = false;
            $scope.obj.AntB = false;
            $scope.obj.SC = false;
            clearupper();
        }
        function clearupper() {
            //$scope.obj = {};
            //$scope.obj = Data;
            $scope.obj.T_AUTO_ISSUE_ID = '';
            $scope.obj.T_REQUEST_NO = '';
            $scope.obj.T_LAB_NO = '';
            $scope.obj.T_REQUEST_DATE = '';
            $scope.obj.T_REQUEST_DATE_H = '';
            $scope.obj.T_PAT_NO = '';
            $scope.obj.PAT_NAME = '';
            $scope.obj.YRS = '';
            $scope.obj.MOS = '';
            $scope.obj.T_SEX = '';
            $scope.obj.GENDER = '';
            $scope.obj.T_NTNLTY_CODE = '';
            $scope.obj.NATIONALITY = '';
            $scope.obj.T_MRTL_STATUS = '';
            $scope.obj.MRTL_STTS = '';
            $scope.obj.T_LOCATION_CODE = '';
            $scope.obj.LOC_DESC = '';
            $scope.obj.T_REQUISITION = '';
            $scope.obj.REQ_DESC = '';
            $scope.obj.T_UNITNO = '';
            $scope.obj.T_ABO_CODE = '';
            $scope.obj.ABO_DESC = '';
            $scope.obj.T_REQ_STATUS = '';

            $scope.obj.aa = {};
            $scope.obj.bc = {};
            $scope.obj.ac = {};
            $scope.obj.ab = {};
            $scope.obj.ad = {};
            $scope.obj.c = {};
            $scope.obj.s1 = {};
            $scope.obj.s2 = {};
            $scope.obj.s3 = {};
            $scope.obj.dc = {};
            $scope.obj.act = {};
            $scope.obj.aa.selected = $scope.jso;
            $scope.obj.bc.selected = $scope.jso;
            $scope.obj.ac.selected = $scope.jso;
            $scope.obj.ab.selected = $scope.jso;
            $scope.obj.ad.selected = $scope.jso;
            $scope.obj.c.selected = $scope.jso;
            $scope.obj.s1.selected = $scope.jso;
            $scope.obj.s2.selected = $scope.jso;
            $scope.obj.s3.selected = $scope.jso;
            $scope.obj.dc.selected = $scope.jso;
            $scope.obj.act.selected = $scope.jso;
            $scope.obj.T_PHENO = '';
            $scope.obj.T_ABO_CODE_Pop = '';
            $scope.obj.obj.T_ABO_DESC_Pop = '';
            $scope.obj.T_INTERPRETATION= '';
            $scope.obj.T_TS_START_TIME = '';
            $scope.obj.T_TS_END_TIME = '';
            $scope.obj.T_TECH_CODE = '';
            $scope.obj.T_USER_NAME = '';
            $scope.obj.T_REMARKS = '';
            $scope.obj.T_BG_ND = '';
            $scope.obj.T_BG_N = '';
            $scope.obj.T_ENTRY_DATE = '';
            $scope.obj.T_ENTRY_USER = '';
            $scope.obj.ENTRY_DESC = '';
            $scope.obj.T_TYPE_AUTO ='';
            $scope.obj.T_TYPE_ALLO ='';
            $scope.obj.T_NON_SPEC = '';
            $scope.obj.AUTO_ANTI =false;
            $scope.obj.ALLO_ANTI = false;
            $scope.obj.NON_SPEC = false;
            $scope.obj.T_ANTI_TYPE_AUTO = '';
            $scope.obj.T_ANTI_TYPE_AUTODESC = '';
            $scope.obj.T_AUTO_OTHERS = '';
            $scope.obj.T_ANTI_TYPE_ALLO = '';
            $scope.obj.T_ANTI_TYPE_ALLODESC = '';
            $scope.obj.T_ALLO_OTHERS = '';
            $scope.obj.T_ANTI_FINAL = '';
            $scope.obj.T_ANTI_FINALDESC = '';
            $scope.obj.T_ANTI_FINAL1 = '';
            $scope.obj.T_ANTI_FINAL1DESC = '';
            $scope.obj.T_ANTI_FINAL2 = '';
            $scope.obj.T_ANTI_FINAL2DESC = '';
            $scope.obj.T_NONS_OTHERS = '';
            $scope.obj.T_PHENO = '';
            $scope.obj.T_D = '';
            $scope.obj.T_CC = '';
            $scope.obj.T_CS = '';
            $scope.obj.T_EC = '';
            $scope.obj.T_ES = '';
            $scope.obj.T_KC = '';
            $scope.obj.T_KS = '';
            $scope.obj.T_JKA = '';
            $scope.obj.T_JKB = '';
            $scope.obj.T_FYA = '';
            $scope.obj.T_FYB = '';
            $scope.obj.T_M = '';
            $scope.obj.T_N = '';
            $scope.obj.T_SC = '';
            $scope.obj.T_SS = '';
            $scope.obj.T_LEA = '';
            $scope.obj.T_LEB = '';
            $scope.obj.T_USER_CODE = '';
            $scope.obj.T_USER_DESC = '';
            $scope.obj.CrossList = [];
            $scope.obj.phenoArray = [];
            for (var j = 0; j < 17; j++) {
                var t = {};
                t.name = null;
                $scope.obj.phenoArray.push(t);
            }
            document.getElementById("txtRequest").focus();

            $scope.obj.wd = true;
            $scope.obj.popbg = true;
            $scope.obj.CrossList = [];
            $scope.obj.tblCrossMatch = false;

            //-------------------DropDown---------------
            var antiList = T12302Service.antiList();
            antiList.then(function (data) {
                $scope.obj.antiList = JSON.parse(data);
            });
            var dctList = T12302Service.dctList();
            dctList.then(function (data) {
                $scope.obj.dctList = JSON.parse(data);
            });

        }

        //----------Tab Toggling--------------start
        $scope.lang = JSON.parse(sessionStorage.getItem("LangName")) == undefined ? 2 : JSON.parse(sessionStorage.getItem("LangName"));
        $scope.FloatE = { "float": 'left', "margin-right": '-3px' }
        $scope.FloatA = { "float": 'right', "margin-left": '-3px' }
        $scope.aR = { "text-align": 'right' }
        $scope.aL = { "text-align": 'left' }
        $scope.obj.Hidenfield = 'tes';
        $scope.currentTab = 'tabTesting.tpl.html';
        $scope.tabs = [
            { title: $scope.getLabel('lblTesting'), url: 'tabTesting.tpl.html', hin: 'tes' },
            { title: $scope.getLabel('lblAntiIdenPheno'), url: 'tabAntiIdenPheno.tpl.html', hin: 'ant' },
            { title: $scope.getLabel('lblCrossMatch'), url: 'tabCrossMatch.tpl.html', hin: 'crs' }
        ];

        $scope.onClickTab = function (tab) {
            $scope.obj.Hidenfield = tab.hin;
            $scope.currentTab = tab.url;
        }
        $scope.isActiveTab = function (tabUrl) { return tabUrl === $scope.currentTab; }


        //-------------------Popups-----------------
        $scope.openReqModal = function () {
            var reqList = T12302Service.reqList(null);
            reqList.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    $scope.obj.reqList = dt;
                    $scope.obj.reqList_1 = dt;
                    document.getElementById("divReq").style.display = "inline-block";
                } else {
                    alert('No Data Found.');
                    document.getElementById("divReq").style.display = "none";
                }
            });
        }
        $scope.CloseReqPopup = function () {
            document.getElementById("divReq").style.display = "none";
        }
        $scope.onReqSelect = function (i) {
            if ($scope.obj.reqList_1[i].T_REQ_STATUS == null) {
                alert('The Request is not received yet');
                clearupper();
            }
            else if ($scope.obj.reqList_1[i].T_REQ_STATUS > 2) {
                alert('The Request is released');
                clearupper();
            }
            else if ($scope.obj.reqList_1[i].T_FORM_NAME == 'T12316') {
                alert('This Request Is Uncrossmatched');
                clearupper();
            }
            else {

                var reqDet = T12302Service.reqDet($scope.obj.reqList_1[i].T_REQUEST_NO);
                reqDet.then(function (data) {
                    $scope.obj.reqList_1 = JSON.parse(data);
                    i = 0;
                    $scope.obj.T_AUTO_ISSUE_ID = $scope.obj.reqList_1[i].T_AUTO_ISSUE_ID;
                    $scope.obj.T_REQUEST_NO = $scope.obj.reqList_1[i].T_REQUEST_NO;
                    $scope.obj.T_LAB_NO = $scope.obj.reqList_1[i].T_LAB_NO;
                    $scope.obj.T_REQUEST_DATE = $filter('date')($scope.obj.reqList_1[i].T_REQUEST_DATE, "dd-MMM-yyyy");
                    $scope.obj.T_REQUEST_DATE_H = $scope.getBirthDateArb($filter('date')($scope.obj.reqList_1[i].T_REQUEST_DATE, "dd/MM/yyyy"));
                    $scope.obj.T_PAT_NO = $scope.obj.reqList_1[i].T_PAT_NO;
                    $scope.obj.PAT_NAME = $scope.obj.reqList_1[i].PAT_NAME;
                    $scope.obj.YRS = $scope.obj.reqList_1[i].YRS;
                    $scope.obj.MOS = $scope.obj.reqList_1[i].MOS;
                    $scope.obj.T_SEX = $scope.obj.reqList_1[i].T_SEX;
                    $scope.obj.GENDER = $scope.obj.reqList_1[i].GENDER;
                    $scope.obj.T_NTNLTY_CODE = $scope.obj.reqList_1[i].T_NTNLTY_CODE;
                    $scope.obj.NATIONALITY = $scope.obj.reqList_1[i].NATIONALITY;
                    $scope.obj.T_MRTL_STATUS = $scope.obj.reqList_1[i].T_MRTL_STATUS;
                    $scope.obj.MRTL_STTS = $scope.obj.reqList_1[i].MRTL_STTS;
                    $scope.obj.T_LOCATION_CODE = $scope.obj.reqList_1[i].T_LOCATION_CODE;
                    $scope.obj.LOC_DESC = $scope.obj.reqList_1[i].LOC_DESC;
                    $scope.obj.T_REQUISITION = $scope.obj.reqList_1[i].T_REQUISITION;
                    $scope.obj.REQ_DESC = $scope.obj.reqList_1[i].REQ_DESC;
                    $scope.obj.T_UNITNO = $scope.obj.reqList_1[i].T_UNITNO;
                    $scope.obj.T_ABO_CODE = $scope.obj.reqList_1[i].T_ABO_CODE;
                    $scope.obj.ABO_DESC = $scope.obj.reqList_1[i].ABO_DESC;
                    $scope.obj.T_REQ_STATUS = $scope.obj.reqList_1[i].T_REQ_STATUS;
                    $scope.obj.OLD_BLOOD_GROUP = $scope.obj.reqList_1[i].OLD_BLOOD_GROUP;
                    $scope.obj.wd = false;
                    $scope.obj.CrossList = [];
                    for (var j = 0; j < $scope.obj.T_UNITNO; j++) {
                        var t = {};
                        t.dctList = $scope.obj.dctList;
                        t.ComList = [{ "CODE": '1', "NAME": "Compatible" }, { "CODE": '2', "NAME": "Incompatible" }, { "CODE": '3', "NAME": "Least Incompatible" }, { "CODE": '1', "NAME": "Not Indicated" }];
                        t.tis = {}; t.tis.selected = {};
                        t.t37 = {}; t.t37.selected = {};
                        t.ahg = {}; t.ahg.selected = {};
                        t.tccc = {}; t.tccc.selected = {};
                        t.gAhg = {}; t.gAhg.selected = {};
                        t.cList = {}; t.cList.selected = {};
                        $scope.obj.CrossList.push(t);
                    }
                    $scope.obj.tblCrossMatch = true;
                    if ($scope.obj.reqList_1[i].T_ANTI_A !== null) {
                        $scope.obj.AntA = true;
                    } else {
                        $scope.obj.AntA = false;
                    }
                    if ($scope.obj.reqList_1[i].T_SC_I !== null) {
                        $scope.obj.SC = true;
                    } else {
                        $scope.obj.SC = false;
                    }
                    if ($scope.obj.reqList_1[i].T_DCT) {
                        $scope.obj.DCT = true;
                    } else {
                        $scope.obj.DCT = false;
                    }
                    if ($scope.obj.reqList_1[i].T_AUTO_CONTROL) {
                        $scope.obj.AC = true;
                    } else {
                        $scope.obj.AC = false;
                    }
                    if ($scope.obj.reqList_1[i].T_INTERPRETATION) {
                        $scope.obj.anibidet = true;
                    } else {
                        $scope.obj.anibidet = false;
                    }
                    if ($scope.obj.reqList_1[i].T_REMARKS) {
                        $scope.obj.rmk = true;
                    } else {
                        $scope.obj.rmk = false;
                    }
                    $scope.obj.aa.selected = { T_ANTI_CODE: $scope.obj.reqList_1[i].T_ANTI_A, T_ANTI_LEVEL: $scope.obj.reqList_1[i].T_ANTI_A_DESC };
                    $scope.obj.ab.selected = { T_ANTI_CODE: $scope.obj.reqList_1[i].T_ANTI_B, T_ANTI_LEVEL: $scope.obj.reqList_1[i].T_ANTI_B_DESC };
                    $scope.obj.ad.selected = { T_ANTI_CODE: $scope.obj.reqList_1[i].T_ANTI_D, T_ANTI_LEVEL: $scope.obj.reqList_1[i].T_ANTI_D_DESC };
                    $scope.obj.c.selected = { T_ANTI_CODE: $scope.obj.reqList_1[i].T_CONTROL, T_ANTI_LEVEL: $scope.obj.reqList_1[i].T_CONTROL_DESC };
                    $scope.obj.ac.selected = { T_ANTI_CODE: $scope.obj.reqList_1[i].T_CELLS_A, T_ANTI_LEVEL: $scope.obj.reqList_1[i].T_CELLS_A_DESC };
                    $scope.obj.bc.selected = { T_ANTI_CODE: $scope.obj.reqList_1[i].T_CELLS_B, T_ANTI_LEVEL: $scope.obj.reqList_1[i].T_CELLS_B_DESC };
                    $scope.obj.T_ABO_CODE_Pop = $scope.obj.reqList_1[i].T_BLOOD_GROUP;
                    $scope.obj.T_ABO_DESC_Pop = $scope.obj.reqList_1[i].T_BLOOD_GROUP_DESC;
                    $scope.obj.s1.selected = { T_ANTI_CODE: $scope.obj.reqList_1[i].T_SC_I, T_ANTI_LEVEL: $scope.obj.reqList_1[i].T_SC_I_DESC };
                    $scope.obj.s2.selected = { T_ANTI_CODE: $scope.obj.reqList_1[i].T_SC_II, T_ANTI_LEVEL: $scope.obj.reqList_1[i].T_SC_II_DESC };
                    $scope.obj.s3.selected = { T_ANTI_CODE: $scope.obj.reqList_1[i].T_SC_III, T_ANTI_LEVEL: $scope.obj.reqList_1[i].T_SC_III_DESC };
                    $scope.obj.dc.selected = { T_CODE: $scope.obj.reqList_1[i].T_DCT, NAME: $scope.obj.reqList_1[i].T_DCT_DESC };
                    $scope.obj.act.selected = { T_ANTI_CODE: $scope.obj.reqList_1[i].T_AUTO_CONTROL, T_ANTI_LEVEL: $scope.obj.reqList_1[i].T_AUTO_CONTROL_DESC };
                    $scope.obj.T_INTERPRETATION = $scope.obj.reqList_1[i].T_INTERPRETATION;
                    $scope.obj.T_TS_START_TIME = $scope.obj.reqList_1[i].T_TS_START_TIME;
                    $scope.obj.T_TS_END_TIME = $scope.obj.reqList_1[i].T_TS_END_TIME;
                    $scope.obj.T_TECH_CODE = $scope.obj.reqList_1[i].T_TECH_CODE;
                    $scope.obj.T_USER_NAME = $scope.obj.reqList_1[i].T_TECH_CODE_DESC;
                    $scope.obj.T_REMARKS = $scope.obj.reqList_1[i].T_REMARKS;
                    $scope.obj.T_BG_ND = $scope.obj.reqList_1[i].T_BG_ND;
                    $scope.obj.T_BG_N = $scope.obj.reqList_1[i].T_BG_N;
                    //$scope.obj.T_ENTRY_DATE = $scope.obj.reqList_1[i].T56T_ENTRY_DATE;
                    //$scope.obj.T_ENTRY_USER = $scope.obj.reqList_1[i].T56T_ENTRY_USER;
                    //$scope.obj.ENTRY_DESC = $scope.obj.reqList_1[i].T56T_ENTRY_USER_NAME;
                    $scope.obj.T_ENTRY_DATE = $filter('date')($scope.obj.reqList_1[i].T13T_ENTRY_DAT, "dd-MMM-yyyy");
                    $scope.obj.T_ENTRY_USER = $scope.obj.reqList_1[i].T13T_ENTRY_USER;
                    $scope.obj.ENTRY_DESC = $scope.obj.reqList_1[i].T13T_ENTRY_USER_NAME;
                    $scope.obj.T_TYPE_AUTO = $scope.obj.reqList_1[i].T_AUTO_ANTI;
                    $scope.obj.T_TYPE_ALLO = $scope.obj.reqList_1[i].T_ALLO_ANTI == 2 ? 1 : 2;
                    $scope.obj.T_NON_SPEC = $scope.obj.reqList_1[i].T_NON_SPEC;
                    $scope.obj.AUTO_ANTI = $scope.obj.T_TYPE_AUTO == '1' ? true : false;
                    $scope.obj.ALLO_ANTI = $scope.obj.T_TYPE_ALLO == '2' ? true : false;
                    $scope.obj.NON_SPEC = $scope.obj.T_NON_SPEC == '1' ? true : false;
                    $scope.obj.T_ANTI_TYPE_AUTO = $scope.obj.reqList_1[i].T_ANTI_TYPE_AUTO;
                    $scope.obj.T_ANTI_TYPE_AUTODESC = $scope.obj.reqList_1[i].T_ANTI_TYPE_AUTO_DESC;
                    $scope.obj.T_AUTO_OTHERS = $scope.obj.reqList_1[i].T_AUTO_OTHERS;
                    $scope.obj.T_ANTI_TYPE_ALLO = $scope.obj.reqList_1[i].T_ANTI_TYPE_ALLO;
                    $scope.obj.T_ANTI_TYPE_ALLODESC = $scope.obj.reqList_1[i].T_ANTI_TYPE_ALLO_DESC;
                    $scope.obj.T_ALLO_OTHERS = $scope.obj.reqList_1[i].T_ALLO_OTHERS;
                    $scope.obj.T_ANTI_FINAL = $scope.obj.reqList_1[i].T_ANTI_FINAL;
                    $scope.obj.T_ANTI_FINALDESC = $scope.obj.reqList_1[i].T_ANTI_FINAL_DESC;
                    $scope.obj.T_ANTI_FINAL1 = $scope.obj.reqList_1[i].T_ANTI_FINAL1;
                    $scope.obj.T_ANTI_FINAL1DESC = $scope.obj.reqList_1[i].T_ANTI_FINAL1_DESC;
                    $scope.obj.T_ANTI_FINAL2 = $scope.obj.reqList_1[i].T_ANTI_FINAL2;
                    $scope.obj.T_ANTI_FINAL2DESC = $scope.obj.reqList_1[i].T_ANTI_FINAL2_DESC;
                    $scope.obj.T_NONS_OTHERS = $scope.obj.reqList_1[i].T_NONS_OTHERS;
                    $scope.obj.T_PHENO = $scope.obj.reqList_1[i].T_PHENO;
                    $scope.obj.T_D = $scope.obj.reqList_1[i].T_D;
                    $scope.obj.T_CC = $scope.obj.reqList_1[i].T_CC;
                    $scope.obj.T_CS = $scope.obj.reqList_1[i].T_CS;
                    $scope.obj.T_EC = $scope.obj.reqList_1[i].T_EC;
                    $scope.obj.T_ES = $scope.obj.reqList_1[i].T_ES;
                    $scope.obj.T_KC = $scope.obj.reqList_1[i].T_KC;
                    $scope.obj.T_KS = $scope.obj.reqList_1[i].T_KS;
                    $scope.obj.T_JKA = $scope.obj.reqList_1[i].T_JKA;
                    $scope.obj.T_JKB = $scope.obj.reqList_1[i].T_JKB;
                    $scope.obj.T_FYA = $scope.obj.reqList_1[i].T_FYA;
                    $scope.obj.T_FYB = $scope.obj.reqList_1[i].T_FYB;
                    $scope.obj.T_M = $scope.obj.reqList_1[i].T_M;
                    $scope.obj.T_N = $scope.obj.reqList_1[i].T_N;
                    $scope.obj.T_SC = $scope.obj.reqList_1[i].T_SC;
                    $scope.obj.T_SS = $scope.obj.reqList_1[i].T_SS;
                    $scope.obj.T_LEA = $scope.obj.reqList_1[i].T_LEA;
                    $scope.obj.T_LEB = $scope.obj.reqList_1[i].T_LEB;
                    //$scope.obj.T_USER_CODE = $scope.obj.reqList_1[i].T_ISSUED_BY;
                    //$scope.obj.T_USER_DESC = $scope.obj.reqList_1[i].T_ISSUED_BY_NAME;
                    $scope.obj.T_USER_CODE = $scope.obj.reqList_1[i].T56T_ENTRY_USER;
                    $scope.obj.T_USER_DESC = $scope.obj.reqList_1[i].T56T_ENTRY_USER_NAME;
                    
                    for (var k = 0; k < $scope.obj.reqList_1.length; k++) {
                        $scope.obj.CrossList[k].tis = {};$scope.obj.CrossList[k].tis.selected = {};
                        $scope.obj.CrossList[k].t37 = {}; $scope.obj.CrossList[k].t37.selected = {};
                        $scope.obj.CrossList[k].ahg = {}; $scope.obj.CrossList[k].ahg.selected = {};
                        $scope.obj.CrossList[k].tccc = {}; $scope.obj.CrossList[k].tccc.selected = {};
                        $scope.obj.CrossList[k].gAhg = {}; $scope.obj.CrossList[k].gAhg.selected = {};
                        $scope.obj.CrossList[k].cList = {}; $scope.obj.CrossList[k].cList.selected = {};


                        $scope.obj.CrossList[k].T_BB_STOCK_ID = $scope.obj.reqList_1[k].T_BB_STOCK_ID;
                        $scope.obj.CrossList[k].T_UNIT_NO = $scope.obj.reqList_1[k].T_UNIT_NO;
                        $scope.obj.CrossList[k].T_BLOOD_GROUP = $scope.obj.reqList_1[k].T_BLOOD_GROUP_CODE;
                        $scope.obj.CrossList[k].T_PROD_CODE = $scope.obj.reqList_1[k].T_PRODUCT_CODE;
                        $scope.obj.CrossList[k].T_EXPIRY_DATE = $filter('date')($scope.obj.reqList_1[k].T_EXPIRY_DATE, "dd-MMM-yyyy");
                        $scope.obj.CrossList[k].T_AUTO_ISSUE_DET_ID = $scope.obj.reqList_1[k].T_AUTO_ISSUE_DET_ID;
                        $scope.obj.CrossList[k].tis.selected = { T_CODE: $scope.obj.reqList_1[k].T_IS, NAME: $scope.obj.reqList_1[k].T_IS_DESC };
                        $scope.obj.CrossList[k].t37.selected = { T_CODE: $scope.obj.reqList_1[k].T_C, NAME: $scope.obj.reqList_1[k].T_C_DESC };
                        $scope.obj.CrossList[k].ahg.selected = { T_CODE: $scope.obj.reqList_1[k].T_AHG, NAME: $scope.obj.reqList_1[k].T_AHG_DESC };
                        $scope.obj.CrossList[k].tccc.selected = { T_CODE: $scope.obj.reqList_1[k].T_CCC, NAME: $scope.obj.reqList_1[k].T_CCC_DESC };
                        $scope.obj.CrossList[k].gAhg.selected = { T_CODE: $scope.obj.reqList_1[k].T_GEL_AHG, NAME: $scope.obj.reqList_1[k].T_GEL_AHG_DESC };
                        $scope.obj.CrossList[k].cList.selected = { CODE: $scope.obj.reqList_1[k].T_COMPATIBLE, NAME: $scope.obj.reqList_1[k].T_COMPATIBLE_DESC };
                    }
                    if ($scope.obj.reqList_1[i].T_ANTI_A == '' || $scope.obj.reqList_1[i].T_ANTI_A == null) {
                        document.getElementById('chkreverse').focus();
                    }

                });


            }
            $scope.CloseReqPopup();
        }
        $scope.onReqSearch_blur = function () {
            var n = $scope.obj.T_REQUEST_NO;
            if (n != null) {
                var a = $scope.pad(n, 8);
                $scope.obj.T_REQUEST_NO = a == '00000000' ? '' : a;
            }

        }
        $scope.Clear_Click = function() {
            clear();
        }
        $scope.Next_Click = function() {
            var reqList = T12302Service.reqList($scope.obj.T_REQUEST_NO);
            reqList.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    $scope.obj.reqList_1 = dt;
                    $scope.onReqSelect(0);
                } else {
                    alert('No Data Found.');
                    clearupper();
                }
            });
        }
        $scope.onReqSearch_tab = function (e) {
            if (e.keyCode === 9 || e.keyCode === 13) {
                var p = $scope.obj.T_REQUEST_NO;
                if (p != null) {
                    var a = $scope.pad(p, 8);
                    $scope.obj.T_REQUEST_NO = a == '00000000' ? '' : a;
                    var reqList = T12302Service.reqList($scope.obj.T_REQUEST_NO);
                    reqList.then(function (data) {
                        var dt = JSON.parse(data);
                        if (dt.length > 0) {
                            $scope.obj.reqList_1 = dt;
                            $scope.onReqSelect(0);
                        } else {
                            alert('No Data Found.');
                            clearupper();
                        }
                    });
                }
            }
            else if (e.keyCode == 114) {
                e.preventDefault();
                if (document.getElementById("divBloodGroup").style.display == "inline-block") {
                    document.getElementById("divBloodGroup").style.display = "none";
                } else {
                    $scope.openReqModal();
                }
            }
        }

        $scope.openBGModal = function () {
            if ($scope.obj.popbg == false) {
                var bgList = T12302Service.bgList(null);
                bgList.then(function (data) {
                    var dt = JSON.parse(data);
                    if (dt.length > 0) {
                        $scope.obj.bgList = dt;
                        document.getElementById("divBloodGroup").style.display = "inline-block";
                    } else {
                        document.getElementById("divBloodGroup").style.display = "none";
                    }
                });
            }

        }
        $scope.ClosebgPopup = function () {
            document.getElementById("divBloodGroup").style.display = "none";
        }
        $scope.onbgSelect = function (i) {
            if ($scope.obj.popbg == false) {
                $scope.obj.T_ABO_CODE_Pop = $scope.obj.bgList[i].T_ABO_CODE;
                $scope.obj.T_ABO_DESC_Pop = $scope.obj.bgList[i].T_ABO_DESC;
            }
            document.getElementById("divBloodGroup").style.display = "none";
        }
        $scope.onbgSearch = function (e, m) {
            if ($scope.obj.popbg == false) {

                if ((e.keyCode == 13 || e.keyCode == 9) && m != '') {
                    var bgList = T12302Service.bgList(m);
                    bgList.then(function (data) {
                        var dt = JSON.parse(data);
                        if (dt.length > 0) {
                            $scope.obj.T_ABO_CODE_Pop = dt[0].T_ABO_CODE;
                            $scope.obj.T_ABO_DESC_Pop = dt[0].T_ABO_DESC;
                        } else {
                            $scope.obj.T_ABO_CODE_Pop = '';
                            $scope.obj.T_ABO_DESC_Pop = '';
                        }
                    });
                }
                else if (e.keyCode == 114) {
                    e.preventDefault();
                    if (document.getElementById("divBloodGroup").style.display == "inline-block") {
                        document.getElementById("divBloodGroup").style.display = "none";
                    } else {
                        $scope.openBGModal();
                    }
                }
            } else {
                $scope.obj.T_ABO_CODE_Pop = '';
                $scope.obj.T_ABO_DESC_Pop = '';
            }
        }

        $scope.openTechModal = function () {
            var techList = T12302Service.techList(null);
            techList.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    $scope.obj.techList = dt;
                    document.getElementById("divTech").style.display = "inline-block";
                } else {
                    document.getElementById("divTech").style.display = "none";
                }
            });
        }
        $scope.CloseTechPopup = function () {
            document.getElementById("divTech").style.display = "none";
        }
        $scope.onTechSelect = function (i) {
            $scope.obj.T_TECH_CODE = $scope.obj.techList[i].T_EMP_CODE;
            $scope.obj.T_USER_NAME = $scope.obj.techList[i].T_USER_NAME;
            document.getElementById("divTech").style.display = "none";
        }
        $scope.onTechSearch = function (e, m) {

            if ((e.keyCode == 13 || e.keyCode == 9) && m != '') {
                var techList = T12302Service.techList(m);
                techList.then(function (data) {
                    var dt = JSON.parse(data);
                    if (dt.length > 0) {
                        $scope.obj.T_TECH_CODE = dt[0].T_EMP_CODE;
                        $scope.obj.T_USER_NAME = dt[0].T_USER_NAME;
                    } else {
                        $scope.obj.T_TECH_CODE = '';
                        $scope.obj.T_USER_NAME = '';
                    }
                });
            }
            else if (e.keyCode == 114) {
                e.preventDefault();
                if (document.getElementById("divTech").style.display == "inline-block") {
                    document.getElementById("divTech").style.display = "none";
                } else {
                    $scope.openTechModal();
                }

            }
        }

        $scope.openAntTypAutoModal = function (t) {
            var k = '';
            if (t == $scope.obj.T_TYPE_AUTO) { k = t; $scope.obj.T_AUTO_OTHERS = ''; }
            else if (t == $scope.obj.T_TYPE_ALLO) { k = t; $scope.obj.T_ALLO_OTHERS = ''; }
            if (k != '') {
                $scope.obj.TYPE = k;
                var antTypAutoList = T12302Service.antTypAutoList(k, null);
                antTypAutoList.then(function (data) {
                    var dt = JSON.parse(data);
                    if (dt.length > 0) {
                        $scope.obj.antTypAutoList = dt;
                        document.getElementById("divantTypAuto").style.display = "inline-block";
                    } else {
                        document.getElementById("divantTypAuto").style.display = "none";
                    }
                });
            }
        }
        $scope.CloseAntTypAutoPopup = function () {
            document.getElementById("divantTypAuto").style.display = "none";
        }
        $scope.onAntTypAutoSelect = function (i) {
            if ($scope.obj.T_TYPE_AUTO == $scope.obj.TYPE) {
                $scope.obj.T_ANTI_TYPE_AUTO = $scope.obj.antTypAutoList[i].T_ANTI_TYPE;
                $scope.obj.T_ANTI_TYPE_AUTODESC = $scope.obj.antTypAutoList[i].T_ANTI_TYPE_DESC;
                if ($scope.obj.T_ANTI_TYPE_AUTO != 4) {
                    var chkDoctor = T12302Service.chkDoctor();
                    chkDoctor.then(function (data) {
                        var dt = JSON.parse(data);
                        if (dt > 0) {
                            document.getElementById("txtAutoOthers").readOnly = false;
                        } else {
                            document.getElementById("txtAutoOthers").readOnly = true;
                        }

                    });
                } else {
                    document.getElementById("txtAutoOthers").readOnly = true;
                }
                $scope.obj.T_AUTO_OTHERS = '';
            }
            else if ($scope.obj.T_TYPE_ALLO == $scope.obj.TYPE) {
                $scope.obj.T_ANTI_TYPE_ALLO = $scope.obj.antTypAutoList[i].T_ANTI_TYPE;
                $scope.obj.T_ANTI_TYPE_ALLODESC = $scope.obj.antTypAutoList[i].T_ANTI_TYPE_DESC;

                if ($scope.obj.T_ANTI_TYPE_ALLO != '3') {
                    $scope.obj.T_ANTI_FINAL = '';
                    $scope.obj.T_ANTI_FINALDESC = '';
                    $scope.obj.T_ANTI_FINAL1 = '';
                    $scope.obj.T_ANTI_FINAL1DESC = '';
                    $scope.obj.T_ANTI_FINAL2 = '';
                    $scope.obj.T_ANTI_FINAL2DESC = '';
                }
                if ($scope.obj.T_ANTI_TYPE_ALLO != 4) {
                    var chkDoctor = T12302Service.chkDoctor();
                    chkDoctor.then(function (data) {
                        var dt = JSON.parse(data);
                        if (dt > 0) {
                            document.getElementById("txtAlloOthers").readOnly = false;
                        } else {
                            document.getElementById("txtAlloOthers").readOnly = true;
                        }

                    });
                } else {
                    document.getElementById("txtAlloOthers").readOnly = true;
                }
                $scope.obj.T_ALLO_OTHERS = '';

            }

            document.getElementById("divantTypAuto").style.display = "none";
        }
        $scope.onAntTypAutoSearch = function (e, t) {
            var k = '';
            var code = '';
            if (t == $scope.obj.T_TYPE_AUTO) { k = t; code = $scope.obj.T_ANTI_TYPE_AUTO; $scope.obj.T_AUTO_OTHERS = ''; }
            else if (t == $scope.obj.T_TYPE_ALLO) { k = t; code = $scope.obj.T_ANTI_TYPE_ALLO; $scope.obj.T_ALLO_OTHERS = ''; }
            if (k != '') {
                $scope.obj.TYPE = k;
                if ((e.keyCode == 13 || e.keyCode == 9) && code != '') {
                    var antTypAutoList = T12302Service.antTypAutoList($scope.obj.TYPE, code);
                    antTypAutoList.then(function (data) {
                        var dt = JSON.parse(data);
                        if ($scope.obj.TYPE == '1') {
                            if (dt.length > 0) {
                                $scope.obj.T_ANTI_TYPE_AUTO = dt[0].T_ANTI_TYPE;
                                $scope.obj.T_ANTI_TYPE_AUTODESC = dt[0].T_ANTI_TYPE_DESC;
                                if ($scope.obj.T_ANTI_TYPE_AUTO != 4) {
                                    var chkDoctor = T12302Service.chkDoctor();
                                    chkDoctor.then(function (data) {
                                        var dt = JSON.parse(data);
                                        if (dt > 0) {
                                            document.getElementById("txtAutoOthers").readOnly = false;
                                        } else {
                                            document.getElementById("txtAutoOthers").readOnly = true;
                                        }

                                    });
                                } else {
                                    document.getElementById("txtAutoOthers").readOnly = true;
                                }
                                $scope.obj.T_AUTO_OTHERS = '';
                            }
                            else {
                                $scope.obj.T_ANTI_TYPE_AUTO = '';
                                $scope.obj.T_ANTI_TYPE_AUTODESC = '';
                            }

                        }


                        else if ($scope.obj.TYPE == '2') {
                            if (dt.length > 0) {
                                $scope.obj.T_ANTI_TYPE_ALLO = dt[0].T_ANTI_TYPE;
                                $scope.obj.T_ANTI_TYPE_ALLODESC = dt[0].T_ANTI_TYPE_DESC;
                                if ($scope.obj.T_ANTI_TYPE_ALLO != '3') {
                                    $scope.obj.T_ANTI_FINAL = '';
                                    $scope.obj.T_ANTI_FINALDESC = '';
                                    $scope.obj.T_ANTI_FINAL1 = '';
                                    $scope.obj.T_ANTI_FINAL1DESC = '';
                                    $scope.obj.T_ANTI_FINAL2 = '';
                                    $scope.obj.T_ANTI_FINAL2DESC = '';
                                }
                                if ($scope.obj.T_ANTI_TYPE_ALLO != 4) {
                                    var chkDoctor = T12302Service.chkDoctor();
                                    chkDoctor.then(function (data) {
                                        var dt = JSON.parse(data);
                                        if (dt > 0) {
                                            document.getElementById("txtAlloOthers").readOnly = false;
                                        } else {
                                            document.getElementById("txtAlloOthers").readOnly = true;
                                        }

                                    });
                                } else {
                                    document.getElementById("txtAlloOthers").readOnly = true;
                                }
                                $scope.obj.T_ALLO_OTHERS = '';

                            }
                            else {
                                $scope.obj.T_ANTI_TYPE_ALLO = '';
                                $scope.obj.T_ANTI_TYPE_ALLODESC = '';
                            }

                        }


                    });
                }
                else if (e.keyCode == 114) {
                    e.preventDefault();
                    if (document.getElementById("divantTypAuto").style.display == "inline-block") {
                        document.getElementById("divantTypAuto").style.display = "none";
                    } else {
                        $scope.openAntTypAutoModal($scope.obj.TYPE, null);
                    }

                }
            }

        }

        $scope.openAntTypFinalModal = function (t) {
            $scope.obj.FINAL_TYPE = t;
            var k = $scope.obj.T_ANTI_TYPE_ALLO;
            if (t != '' && k == 3) {
                var antTypFinalList = T12302Service.antTypFinalList(k, null);
                antTypFinalList.then(function (data) {
                    var dt = JSON.parse(data);
                    if (dt.length > 0) {
                        $scope.obj.antTypFinalList = dt;
                        document.getElementById("divantTypFinal").style.display = "inline-block";
                    } else {
                        document.getElementById("divantTypFinal").style.display = "none";
                    }
                });
            }

        }
        $scope.CloseAntTypFinalPopup = function () {
            document.getElementById("divantTypFinal").style.display = "none";
        }
        $scope.onAntTypFinalSelect = function (i) {
            var code = $scope.obj.antTypFinalList[i].T_ANTI_TYPECODE;
            var desc = $scope.obj.antTypFinalList[i].T_ANTI_TYPEDESC;
            if ($scope.obj.FINAL_TYPE == '0') {
                $scope.obj.T_ANTI_FINAL = code;
                $scope.obj.T_ANTI_FINALDESC = desc;
            }
            else if ($scope.obj.FINAL_TYPE == '1') {
                $scope.obj.T_ANTI_FINAL1 = code;
                $scope.obj.T_ANTI_FINAL1DESC = desc;
            }
            else if ($scope.obj.FINAL_TYPE == '2') {
                $scope.obj.T_ANTI_FINAL2 = code;
                $scope.obj.T_ANTI_FINAL2DESC = desc;
            }
            document.getElementById("divantTypFinal").style.display = "none";
        }
        $scope.onAntTypFinalSearch = function (e, t) {
            var code = '';
            var k = $scope.obj.T_ANTI_TYPE_ALLO;
            if (t == '0') {
                code = $scope.obj.T_ANTI_FINAL;
            }
            else if (t == '1') {
                code = $scope.obj.T_ANTI_FINAL1;
            }
            else if (t == '2') {
                code = $scope.obj.T_ANTI_FINAL2;
            }
            if (k == '3') {
                if ((e.keyCode == 13 || e.keyCode == 9) && code != '') {
                    var antTypFinalList = T12302Service.antTypFinalList(k, code);
                    antTypFinalList.then(function (data) {
                        var dt = JSON.parse(data);
                        var c = dt.length ? dt[0].T_ANTI_TYPECODE : '';
                        var d = dt.length ? dt[0].T_ANTI_TYPEDESC : '';;
                        if (t == '0') {
                            $scope.obj.T_ANTI_FINAL = dt.length > 0 ? c : '';
                            $scope.obj.T_ANTI_FINALDESC = dt.length > 0 ? d : '';
                        }
                        else if (t == '1') {
                            $scope.obj.T_ANTI_FINAL1 = dt.length > 0 ? c : '';
                            $scope.obj.T_ANTI_FINAL1DESC = dt.length > 0 ? d : '';
                        }
                        else if (t == '2') {
                            $scope.obj.T_ANTI_FINAL2 = dt.length > 0 ? c : '';
                            $scope.obj.T_ANTI_FINAL2DESC = dt.length > 0 ? d : '';
                        }
                    });
                }
                else if (e.keyCode == 114) {
                    e.preventDefault();
                    if (document.getElementById("divantTypFinal").style.display == "inline-block") {
                        document.getElementById("divantTypFinal").style.display = "none";
                    } else {
                        $scope.openAntTypFinalModal(t, null);
                    }

                }
            }
        }

        $scope.openUnitModal = function (i,unit) {
            $scope.obj.in = i;
            var pa = $scope.obj.T_PAT_NO;
            var ph = $scope.obj.T_PHENO;
            var pc = $scope.obj.T_REQUISITION;
            //var bg = $scope.obj.T_ABO_CODE;
            var bg = $scope.obj.T_ABO_CODE_Pop;
            var un = unit;
            var rq = $scope.obj.T_REQUEST_NO;

            var unitList = T12302Service.unitList(pa, ph, pc, bg, un, rq);
            unitList.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    $scope.obj.unitList = dt;
                    document.getElementById("divUnit").style.display = "inline-block";
                } else {
                    alert('No Data Found.');
                    document.getElementById("divUnit").style.display = "none";
                }
            });
        }
        $scope.CloseUnitPopup = function () {
            document.getElementById("divUnit").style.display = "none";
        }
        $scope.onUnitSelect = function (i) {
            var a = $scope.obj.in;
            $scope.obj.CrossList[a].T_BB_STOCK_ID = $scope.obj.unitList[i].T_BB_STOCK_ID;
            $scope.obj.CrossList[a].T_UNIT_NO = $scope.obj.unitList[i].UNIT_NO;
            $scope.obj.CrossList[a].T_BLOOD_GROUP = $scope.obj.unitList[i].T_ABO_NO_CODE;
            $scope.obj.CrossList[a].T_PROD_CODE = $scope.obj.unitList[i].T_PRODUCT_CODE;
            $scope.obj.CrossList[a].T_EXPIRY_DATE = $filter('date')($scope.obj.unitList[i].T_EXPIRY_DATE, "dd-MMM-yyyy");
            $scope.CloseUnitPopup();


        }
        $scope.onUnitSearch_blur = function () {
            var n = $scope.obj.T_REQUEST_NO;
            if (n != null) {
                var a = $scope.pad(n, 8);
                $scope.obj.T_REQUEST_NO = a == '00000000' ? '' : a;
            }

        }
        $scope.onUnitSearch_tab = function (e) {
            if (e.keyCode === 9 || e.keyCode === 13) {
                var p = $scope.obj.T_REQUEST_NO;
                if (p != null) {
                    var a = $scope.pad(p, 8);
                    $scope.obj.T_REQUEST_NO = a == '00000000' ? '' : a;
                    var reqList = T12302Service.reqList($scope.obj.T_REQUEST_NO);
                    reqList.then(function (data) {
                        var dt = JSON.parse(data);
                        if (dt.length > 0) {
                            $scope.obj.reqList_1 = dt;
                            $scope.onReqSelect(0);
                        } else {
                            alert('No Data Found.');
                            clearupper();
                        }
                    });
                }
            }
            else if (e.keyCode == 114) {
                e.preventDefault();
                if (document.getElementById("divBloodGroup").style.display == "inline-block") {
                    document.getElementById("divBloodGroup").style.display = "none";
                } else {
                    $scope.openReqModal();
                }
            }
        }

        //-------------------New unit search-------------------
        $scope.selectSingleUnit = function (e,i, unit) {
            $scope.obj.in = i;
            var pa = $scope.obj.T_PAT_NO;
            var ph = $scope.obj.T_PHENO;
            var pc = $scope.obj.T_REQUISITION;
            //var bg = $scope.obj.T_ABO_CODE;
            var bg = $scope.obj.T_ABO_CODE_Pop;
            var un = unit;
            var rq = $scope.obj.T_REQUEST_NO;
            if (e.keyCode === 9 || e.keyCode === 13) {
           
            var unitList = T12302Service.unitList(pa, ph, pc, bg, un, rq);
            unitList.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    $scope.obj.unitList = dt;
                    $scope.onUnitSelect(0);
                    //document.getElementById("divUnit").style.display = "inline-block";
                } else {
                    alert('No Data Found.');
                    var a = $scope.obj.in;
                    //document.getElementById("divUnit").style.display = "none";
                    $scope.obj.CrossList[a].T_BB_STOCK_ID = null;
                    $scope.obj.CrossList[a].T_UNIT_NO = null;
                    $scope.obj.CrossList[a].T_BLOOD_GROUP = null;
                    $scope.obj.CrossList[a].T_PROD_CODE = null;
                    $scope.obj.CrossList[a].T_EXPIRY_DATE = null;
                }
                });
            }
        }




        //------------------Chekboxes----------------

        $scope.onRTNIChange = function () {
            if ($scope.obj.T_BG_ND === '1') {
                $scope.obj.ddlCells = true;
                $scope.obj.ddlAnti = false;
                $scope.obj.T_BG_N = '';
                $scope.obj.ac.selected = $scope.jso;
                $scope.obj.bc.selected = $scope.jso;
            } else {
                $scope.obj.ddlCells = false;
                $scope.obj.ddlAnti = $scope.obj.T_BG_N === '1';

                ////-------------------New-------------------------
                //$scope.obj.T_ABO_CODE_Pop = '';
                //$scope.obj.T_ABO_DESC_Pop = '';
            }
            $scope.obj.ddlCells = $scope.obj.T_BG_ND === '1';


          

        }
        $scope.onBGNDChange = function () {
            if ($scope.obj.T_BG_N === '1') {
                $scope.obj.ddlAnti = true;
                $scope.obj.ddlCells = true;
                $scope.obj.T_BG_ND = '';
                $scope.obj.ac.selected = $scope.jso;
                $scope.obj.bc.selected = $scope.jso;
                $scope.obj.aa.selected = $scope.jso;
                $scope.obj.ab.selected = $scope.jso;
                $scope.obj.ad.selected = $scope.jso;
                $scope.obj.c.selected = $scope.jso;
                //-------------------New-------------------------
                $scope.obj.T_ABO_CODE_Pop = '';
                $scope.obj.T_ABO_DESC_Pop = '';
            } else {
                $scope.obj.ddlAnti = false;
                $scope.obj.ddlCells = $scope.obj.T_BG_ND === '1';

            }
        }

        $scope.onAutoChange = function (t) {
            $scope.obj.T_TYPE_AUTO = t === true ? '1' : '';
            //$scope.obj.T_TYPE_ALLO = '';
            $scope.obj.T_ANTI_TYPE_AUTO = '';
            $scope.obj.T_ANTI_TYPE_AUTODESC = '';
            $scope.obj.T_AUTO_OTHERS = '';
        }
        $scope.onAlloChange = function (t) {
            $scope.obj.T_TYPE_ALLO = t === true ? '2' : '';
            //$scope.obj.T_TYPE_AUTO =  '';
            $scope.obj.T_ANTI_TYPE_ALLO = '';
            $scope.obj.T_ANTI_TYPE_ALLODESC = '';
            $scope.obj.T_ANTI_FINAL = '';
            $scope.obj.T_ANTI_FINALDESC = '';
            $scope.obj.T_ANTI_FINAL1 = '';
            $scope.obj.T_ANTI_FINAL1DESC = '';
            $scope.obj.T_ANTI_FINAL2 = '';
            $scope.obj.T_ANTI_FINAL2DESC = '';
            document.getElementById("txtAlloOthers").readOnly = true;
            $scope.obj.T_ALLO_OTHERS = '';
        }
        $scope.onNonSpecChange = function (t) {
            $scope.obj.T_NON_SPEC = t === true ? '1' : '';
            document.getElementById("txtComments").readOnly = !t;
            $scope.obj.T_NONS_OTHERS = '';
        }
        $scope.onPhenoTypeChange = function (e, i, p) {
            var id = 'lbl' + e.target.id.substr(3);
            $scope.obj.phenoArray[i].name = p == '1' ? $scope.getLabel(id) : null;
            $scope.T_PHENO = '';
            for (var k = 0; k < $scope.obj.phenoArray.length; k++) {
                if ($scope.obj.phenoArray[k].name != null) {
                    $scope.T_PHENO += $scope.obj.phenoArray[k].name + ',';
                }
            }
            var r = $scope.T_PHENO;
            $scope.obj.T_PHENO = r.substring(0, r.length - 1);
        }

        $scope.onControlSelect = function (a, b, d, c, e, ac, bc,id,pat) {
           
            if (e == '1') {
                if ((a != '' && a != undefined) && (b != '' && b != undefined) && (d != '' && d != undefined) && (c != '' && c != undefined)) {
                    var getbgByControl = T12302Service.getbgByControl(a, b, d, c);
                    getbgByControl.then(function (data) {
                        var dt = JSON.parse(data);
                        if (dt.length > 0) {
                            var checkBg = T12302Service.checkBg(pat);
                            checkBg.then(function(dt_bg) {
                                var d_bg = JSON.parse(dt_bg);
                                if (d_bg.length > 0) {
                                    if (d_bg[0].T_BLOOD_GROUP == dt[0].T_BLOOD_GROUP_CODE) {
                                        $scope.obj.T_ABO_CODE_Pop = dt[0].T_BLOOD_GROUP_CODE;
                                        $scope.obj.T_ABO_DESC_Pop = dt[0].T_BLOOD_GROUP_DESC;
                                        $scope.obj.popbg = true;
                                    } else {
                                        alert('Different Bloodgroup not accepted.Previous Crossmatch Request No ' + d_bg[0].T_REQUEST_NO + 'And Blood Group is ' + d_bg[0].BG_DESC);
                                        $scope.obj.T_ABO_CODE_Pop = '';
                                        $scope.obj.T_ABO_DESC_Pop = '';
                                        $scope.obj.popbg = false;
                                    }
                                } else {
                                    $scope.obj.T_ABO_CODE_Pop = dt[0].T_BLOOD_GROUP_CODE;
                                    $scope.obj.T_ABO_DESC_Pop = dt[0].T_BLOOD_GROUP_DESC;
                                    $scope.obj.popbg = true;
                                }
                                
                            });

                       
                           
                        } else {
                            alert($scope.getSingleMsg('S0005'));
                            $scope.obj.T_ABO_CODE_Pop = '';
                            $scope.obj.T_ABO_DESC_Pop = '';
                            $scope.obj.popbg = false;

                        }
                    });
                } else {
                    $scope.obj.popbg = true;
                }
            } else {
                if ((a != '' && a != undefined) && (b != '' && b != undefined) && (d != '' && d != undefined) && (c != '' && c != undefined) && (ac != '' && ac != undefined) && (bc != '' && bc != undefined)) {
                    var getbgByControl6 = T12302Service.getbgByControl6(a, b, d, c,ac,bc);
                    getbgByControl6.then(function (data) {
                        var dt = JSON.parse(data);
                        if (dt.length > 0) {
                            //$scope.obj.T_ABO_CODE_Pop = dt[0].T_BLOOD_GROUP_CODE;
                            //$scope.obj.T_ABO_DESC_Pop = dt[0].T_BLOOD_GROUP_DESC;
                            //$scope.obj.popbg = true;
                            var checkBg = T12302Service.checkBg(pat);
                            checkBg.then(function (dt_bg) {
                                var d_bg = JSON.parse(dt_bg);
                                if (d_bg.length > 0) {
                                    if (d_bg[0].T_BLOOD_GROUP == dt[0].T_BLOOD_GROUP_CODE) {
                                        $scope.obj.T_ABO_CODE_Pop = dt[0].T_BLOOD_GROUP_CODE;
                                        $scope.obj.T_ABO_DESC_Pop = dt[0].T_BLOOD_GROUP_DESC;
                                        $scope.obj.popbg = true;
                                    } else {
                                        alert('Different Bloodgroup not accepted.Previous Crossmatch Request No ' + d_bg[0].T_REQUEST_NO + 'And Blood Group is ' + d_bg[0].BG_DESC);
                                        $scope.obj.T_ABO_CODE_Pop = '';
                                        $scope.obj.T_ABO_DESC_Pop = '';
                                        $scope.obj.popbg = false;
                                    }
                                } else {
                                    $scope.obj.T_ABO_CODE_Pop = dt[0].T_BLOOD_GROUP_CODE;
                                    $scope.obj.T_ABO_DESC_Pop = dt[0].T_BLOOD_GROUP_DESC;
                                    $scope.obj.popbg = true;
                                }

                            });
                        } else {
                            alert($scope.getSingleMsg('S0005'));
                            $scope.obj.T_ABO_CODE_Pop = '';
                            $scope.obj.T_ABO_DESC_Pop = '';
                            $scope.obj.popbg = false;

                        }
                    });
                } else {
                    $scope.obj.popbg = true;
                }
            }
            //--------------------New Method--------------------
            $scope.$broadcast(id);
           


        }
        $scope.onSetTime = function (e) {
            var a = ('0' + new Date().getHours()).slice(-2) + ":" + ('0' + new Date().getMinutes()).slice(-2);
            e == 1 ? $scope.obj.T_TS_START_TIME = a : $scope.obj.T_TS_END_TIME = a;
        }

        function chkbg() {
            var bgCode = '';
            var ac = $scope.obj.ac.selected.T_ANTI_CODE;
            var bc = $scope.obj.bc.selected.T_ANTI_CODE;
            var aa = $scope.obj.aa.selected.T_ANTI_CODE;
            var ab = $scope.obj.ab.selected.T_ANTI_CODE;
            var ad = $scope.obj.ad.selected.T_ANTI_CODE;
            var c = $scope.obj.c.selected.T_ANTI_CODE;
            if (chkValue(aa, 1) && chkValue(ab, 2) && chkValue(ad, 1) && chkValue(c, 2) && chkValue(ac, 2) && chkValue(bc, 1)) {
                bgCode = 'AGP';
            }
            else if (chkValue(aa, 2) && chkValue(ab, 1) && chkValue(ad, 1) && chkValue(c, 2) && chkValue(ac, 1) && chkValue(bc, 2)) {
                bgCode = 'BGP';
            }
            else if (chkValue(aa, 2) && chkValue(ab, 2) && chkValue(ad, 1) && chkValue(c, 2) && chkValue(ac, 1) && chkValue(bc, 1)) {
                bgCode = 'OGP';
            }
            else if (chkValue(aa, 1) && chkValue(ab, 1) && chkValue(ad, 1) && chkValue(c, 2) && chkValue(ac, 2) && chkValue(bc, 2)) {
                bgCode = 'ABP';
            }
            else if (chkValue(aa, 1) && chkValue(ab, 2) && chkValue(ad, 2) && chkValue(c, 2) && chkValue(ac, 2) && chkValue(bc, 1)) {
                bgCode = 'AGN';
            }
            else if (chkValue(aa, 2) && chkValue(ab, 1) && chkValue(ad, 2) && chkValue(c, 2) && chkValue(ac, 1) && chkValue(bc, 2)) {
                bgCode = 'BGN';
            }
            else if (chkValue(aa, 1) && chkValue(ab, 1) && chkValue(ad, 2) && chkValue(c, 2) && chkValue(ac, 2) && chkValue(bc, 2)) {
                bgCode = 'ABN';
            }
            else if (chkValue(aa, 2) && chkValue(ab, 2) && chkValue(ad, 2) && chkValue(c, 2) && chkValue(ac, 1) && chkValue(bc, 1)) {
                bgCode = 'OGN';
            } else {
                alert('Please Properly set blood components');
                return;
            }


        }
        function chkValue(v, t) {
            var res = t == 1 ? (v > 0 && v < 5) : (v > 4 && v < 9);
            return res;

        }
        $scope.userId= function () {
            var usid = T12302Service.getUserId();
            usid.then(function (u) {
                var jsonData = JSON.parse(u);
                $scope.obj.T_TECH_CODE = jsonData[0].T_EMP_CODE;
                $scope.obj.T_USER_NAME = jsonData[0].T_USER_NAME;
            });
        }
        $scope.curdat = function() {
            var today = new Date();
            //var dd = String(today.getDate()).padStart(2, '0');
           // var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
           // var yyyy = today.getFullYear();
           // today = dd + '/' + mm + '/' + yyyy;

            var dat = $filter('date')(today, "dd-MMM-yyyy");
            return dat;

            
        }
        $scope.save = function () {
            var bloodGroup = '';
            $scope.onSetTime(1);
            if ($scope.obj.T_REQUEST_NO != '' && $scope.obj.T_ABO_CODE_Pop != '' && $scope.obj.T_REQUEST_NO != null && $scope.obj.T_ABO_CODE_Pop != null) {

                var chkBlood = T12302Service.checkBlood($scope.obj.T_PAT_NO);
                chkBlood.then(function(cb) {
                    var bl = JSON.parse(cb);
                    if (bl > 0) {
                        bloodGroup = bl[0].T_BLOOD_GROUP;
                    } else {
                        bloodGroup = '1';
                    }
                    if (bloodGroup === $scope.obj.T_ABO_CODE_Pop || bloodGroup === '1') {
                       // if ($scope.obj.T_TECH_CODE == undefined || $scope.obj.T_TECH_CODE == null) {
                            var usid = T12302Service.getUserId();
                            usid.then(function (u) {
                                var jsonData = JSON.parse(u);
                                if ($scope.obj.T_TECH_CODE == undefined || $scope.obj.T_TECH_CODE == null) {
                                    $scope.obj.T_TECH_CODE = jsonData[0].T_EMP_CODE;
                                    $scope.obj.T_USER_NAME = jsonData[0].T_USER_NAME;
                                    $scope.obj.T_ENTRY_USER = jsonData[0].T_EMP_CODE;
                                    $scope.obj.T_ENTRY_DATE = $scope.curdat();
                                } else {
                                    $scope.obj.T_ENTRY_USER = jsonData[0].T_EMP_CODE;
                                    $scope.obj.T_ENTRY_DATE = $scope.curdat();
                                }
                                $scope.save_1();
                            });
                        //} else {
                        //    $scope.save_1();
                        //}
                    }
                });
                

            } else {
                alert('Request No or BloodGroup cannot be null');
            }



           
            
            //$scope.userId();
           
        }
        $scope.chSC = 0;
        $scope.alert = 'Please';
        $scope.save_1 = function () {

            var t12013 = {};
            var t12256 = [];
            t12013.T_AUTO_ISSUE_ID = $scope.obj.T_AUTO_ISSUE_ID;
            t12013.T_REQUEST_NO = $scope.obj.T_REQUEST_NO;
            t12013.T_PAT_NO = $scope.obj.T_PAT_NO;
            t12013.T_PRODUCT_CODE = $scope.obj.T_REQUISITION;
            t12013.T_UNITS_ISSUED = $scope.obj.T_UNITNO;
            t12013.T_ANTI_A = $scope.obj.aa.selected.T_ANTI_CODE;
            t12013.T_ANTI_B = $scope.obj.ab.selected.T_ANTI_CODE;
            t12013.T_ANTI_D = $scope.obj.ad.selected.T_ANTI_CODE;
            t12013.T_CONTROL = $scope.obj.c.selected.T_ANTI_CODE;
            t12013.T_CELLS_A = $scope.obj.ac.selected.T_ANTI_CODE;
            t12013.T_CELLS_B = $scope.obj.bc.selected.T_ANTI_CODE;
            t12013.T_BLOOD_GROUP = $scope.obj.T_ABO_CODE_Pop;
            t12013.T_SC_I = $scope.obj.s1.selected.T_ANTI_CODE;
            t12013.T_SC_II = $scope.obj.s2.selected.T_ANTI_CODE;
            t12013.T_SC_III = $scope.obj.s3.selected.T_ANTI_CODE;
            t12013.T_DCT = $scope.obj.dc.selected.T_CODE;
            t12013.T_AUTO_CONTROL = $scope.obj.act.selected.T_ANTI_CODE;
            t12013.T_INTERPRETATION = $scope.obj.T_INTERPRETATION;
            t12013.T_TS_START_TIME = $scope.obj.T_TS_START_TIME;
            t12013.T_TS_END_TIME = $scope.obj.T_TS_END_TIME;
            t12013.T_TECH_CODE = $scope.obj.T_TECH_CODE;
            t12013.T_REMARKS = $scope.obj.T_REMARKS;
            t12013.T_BG_ND = $scope.obj.T_BG_ND;
            t12013.T_BG_N = $scope.obj.T_BG_N;

            t12013.T_AUTO_ANTI = $scope.obj.T_TYPE_AUTO;
            t12013.T_ALLO_ANTI = $scope.obj.T_TYPE_ALLO==2?1:2;
            t12013.T_NON_SPEC = $scope.obj.T_NON_SPEC;
            t12013.T_ANTI_TYPE_AUTO = $scope.obj.T_ANTI_TYPE_AUTO;
            t12013.T_AUTO_OTHERS = $scope.obj.T_AUTO_OTHERS;
            t12013.T_ANTI_TYPE_ALLO = $scope.obj.T_ANTI_TYPE_ALLO;
            t12013.T_ALLO_OTHERS = $scope.obj.T_ALLO_OTHERS;
            t12013.T_ANTI_FINAL = $scope.obj.T_ANTI_FINAL;
            t12013.T_ANTI_FINAL1 = $scope.obj.T_ANTI_FINAL1;
            t12013.T_ANTI_FINAL2 = $scope.obj.T_ANTI_FINAL2;
            t12013.T_NONS_OTHERS = $scope.obj.T_NONS_OTHERS;
            t12013.T_PHENO = $scope.obj.T_PHENO;
            t12013.T_D = $scope.obj.T_D;
            t12013.T_CC = $scope.obj.T_CC;
            t12013.T_CS = $scope.obj.T_CS;
            t12013.T_EC = $scope.obj.T_EC;
            t12013.T_ES = $scope.obj.T_ES;
            t12013.T_KC = $scope.obj.T_KC;
            t12013.T_KS = $scope.obj.T_KS;
            t12013.T_JKA = $scope.obj.T_JKA;
            t12013.T_JKB = $scope.obj.T_JKB;
            t12013.T_FYA = $scope.obj.T_FYA;
            t12013.T_FYB = $scope.obj.T_FYB;
            t12013.T_M = $scope.obj.T_M;
            t12013.T_N = $scope.obj.T_N;
            t12013.T_SC = $scope.obj.T_SC;
            t12013.T_SS = $scope.obj.T_SS;
            t12013.T_LEA = $scope.obj.T_LEA;
            t12013.T_LEB = $scope.obj.T_LEB;

            for (var i = 0; i < $scope.obj.CrossList.length; i++) {
                var t = {};
                if ($scope.obj.CrossList[i].T_BB_STOCK_ID != undefined) {
                    t.T_AUTO_ISSUE_DET_ID = $scope.obj.CrossList[i].T_AUTO_ISSUE_DET_ID;
                    t.T_BB_STOCK_ID = $scope.obj.CrossList[i].T_BB_STOCK_ID;
                    t.T_IS = $scope.obj.CrossList[i].tis.selected.T_CODE;
                    t.T_C = $scope.obj.CrossList[i].t37.selected.T_CODE;
                    t.T_AHG = $scope.obj.CrossList[i].ahg.selected.T_CODE;
                    t.T_CCC = $scope.obj.CrossList[i].tccc.selected.T_CODE;
                    t.T_GEL_AHG = $scope.obj.CrossList[i].gAhg.selected.T_CODE;
                    t.T_COMPATIBLE = $scope.obj.CrossList[i].cList.selected.CODE;
                    t12256.push(t);
                }
            }
            var checkT_SC = T12302Service.checkT_SC(t12013.T_PAT_NO);
            checkT_SC.then(function(data) {
                var dt = JSON.parse(data);
                if (dt.length>0) {
                    if (t12013.T_AUTO_ISSUE_ID == null || t12013.T_AUTO_ISSUE_ID == '') {
                        if (t12013.T_REQUEST_NO != '' && t12013.T_BLOOD_GROUP != '' && t12013.T_REQUEST_NO != null && t12013.T_BLOOD_GROUP != null) {
                            var insert = T12302Service.insert(t12013, t12256);
                            insert.then(function (data) {
                                var dt = JSON.parse(data);
                                if (dt.length > 0) {
                                    alert(dt);
                                    //clear();
                                    $scope.onReqSelect(0);
                                }
                            });
                        } else {
                            alert('Request No or BloodGroup cannot be null');
                        }


                    }
                    else {
                        var update = T12302Service.insert(t12013, t12256);
                        update.then(function (data) {
                            var dt = JSON.parse(data);
                            if (dt.length > 0) {
                                alert(dt);
                                //clear();
                                $scope.onReqSelect(0);
                            }
                        });
                    }
                } else {
                    if (t12013.T_SC_I == '' || t12013.T_SC_I == null) {
                        $scope.chSC = 1;
                        $scope.alert = $scope.alert + ' ' + ' select SC_I,';
                       // alert('Please select SC_I');
                       // return;
                    }
                   // else
                        if (t12013.T_SC_II == '' || t12013.T_SC_II == null) {
                            $scope.chSC = $scope.chSC+1;
                            $scope.alert = $scope.alert+ ' '+ ' select SC_II,';
                        //alert('Please select SC_II');
                       // return;
                    }
                       // else
                            if (t12013.T_SC_III == '' || t12013.T_SC_III == null) {
                                $scope.chSC = $scope.chSC+1;
                                $scope.alert = $scope.alert + ' ' + ' select SC_III';
                       // alert('Please select SC_III');
                       // return;
                            }
                    if ($scope.chSC !== 3 && $scope.chSC !== 0) {
                        alert($scope.alert);
                        $scope.chSC = 0;
                        $scope.alert = 'Please';
                        return;
                    } 
                    else {
                       
                        if ($scope.chSC === 0) {
                            t12013.T_ENTRY_USER = $scope.obj.T_ENTRY_USER;
                            t12013.T_ENTRY_DATE = $scope.obj.T_ENTRY_DATE;
                        }
                        
                        if (t12013.T_AUTO_ISSUE_ID == null || t12013.T_AUTO_ISSUE_ID == '') {
                            if (t12013.T_REQUEST_NO != '' && t12013.T_BLOOD_GROUP != '' && t12013.T_REQUEST_NO != null && t12013.T_BLOOD_GROUP != null) {
                                var insert = T12302Service.insert(t12013, t12256);
                                insert.then(function (data) {
                                    var dt = JSON.parse(data);
                                    if (dt.length > 0) {
                                        alert(dt);
                                        //clear();
                                        $scope.onReqSelect(0);
                                    }
                                });
                            } else {
                                alert('Request No or BloodGroup cannot be null');
                            }


                        }
                        else {

                            var update = T12302Service.insert(t12013, t12256);
                            update.then(function (data) {
                                var dt = JSON.parse(data);
                                if (dt.length > 0) {
                                    alert(dt);
                                    //clear();
                                    $scope.onReqSelect(0);
                                }
                            });
                           

                        }

                        $scope.chSC = 0;
                        $scope.alert = 'Please';
                    }
                   
                   
                    //------
                }
                
            });
            


        }
       
        $scope.xMatchHistoryReport = function () {
            var patno = $scope.obj.T_PAT_NO.trim();
            if (patno == null || patno == '') {
                alert('Please select Request no');
                
            } else {
                $window.open("../R12302/getReportxmatch?patno=" + patno + "", "popup", "width=600,height=600,left=100,top=50");
            }
          
        }
        $scope.bloodGroupReport = function () {
            var patno = $scope.obj.T_PAT_NO.trim();
            if (patno == null || patno == '') {
                alert('Please select Request no');

            } else {
                $window.open("../R12302/getReportbloodGroup?from=&&to=&&prod=", "popup", "width=600,height=600,left=100,top=50");
            }
        }
        $scope.PatientTypeReport = function () {
            var patno = $scope.obj.T_PAT_NO.trim();
            if (patno == null || patno == '') {
                alert('Please select Request no');

            } else {
               // $window.location = $scope.vrDir + "/Query/Q12012?pat="+patno;
                sessionStorage.setItem("FCode", JSON.stringify("Q12012"));
                var name = $scope.lang === '1' ? "العاشر تاريخ المباراة" : "X Match History";
                sessionStorage.setItem("FName", JSON.stringify(name));
                sessionStorage.setItem("FReqCode", JSON.stringify("T12302"));
                var labelData = T12302Service.GetLabelText("Q12012", $scope.lang);
                labelData.then(function (data) {
                    $scope.entity = JSON.parse(data);
                    sessionStorage.setItem("LabelData", JSON.stringify($scope.entity));
                    
                    var hostAddress = $window.location.host;
                    var url = "http://" + hostAddress + $scope.vrDir + "/Query/Q12012?pat=" + patno;
                    $window.location.href = url;
                }); 
            }
        }
        $scope.R12012_Report = function () {
            var reqno = $scope.obj.T_REQUEST_NO.trim();
            if (reqno == null || reqno == '') {
                alert('Please select Request no');

            } else {
                $window.open("../R12302/getR12012_Report?reqno=" + reqno + "", "popup", "width=600,height=600,left=100,top=50");
            }
        };
        $scope.R12036A_Report = function() {
            var patno = $scope.obj.T_REQUEST_NO.trim();
            if (patno == null || patno == '') {
                alert('Please select Request no');

            } else {
                $window.open("../R12302/getR12036A_Report?patno=" + patno + "", "popup", "width=600,height=600,left=100,top=50");
            }
        };
        $scope.R12065_Report = function() {
            var patno = $scope.obj.T_PAT_NO.trim();
            if (patno == null || patno == '') {
                alert('Please select Request no');

            } else {
                $window.open("../R12302/getR12065_Report?patno=" + patno + "", "popup", "width=600,height=600,left=100,top=50");
            }
        }
    }
]);