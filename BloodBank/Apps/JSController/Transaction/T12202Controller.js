app.controller("T12202Controller", ["$scope", "Data", "T12202Service", "$filter",
    function ($scope, Data, T12202Service, $filter) {
        clear();
        function clear() {
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.a = {};
            $scope.obj.t12071 = {};
            $scope.obj.t12022 = {};
            $scope.obj.t12022.T_PAT_NO = '';
            document.getElementById("txtPatNo").focus();
            $scope.obj.T_STATUS_CHECK = 1;
            $scope.obj.PAT_DESC = '';
            $scope.obj.GENDER = '';
            $scope.obj.MRTL_STTS = '';
            $scope.obj.NATIONALITY = '';
            $scope.obj.YRS = '';
            $scope.obj.MOS = '';
            $scope.obj.EPISODE_DATE = '';
            $scope.obj.DIFF_STTS = '';
            $scope.obj.DIFF_STTS_SIGN = '';
            $scope.obj.TOTAL_REG = '';
            $scope.obj.T_UNIT_NO = '';
            $scope.obj.T_EPISODE_NO_22 = '';
            $scope.obj.DifferedReason = '';
            $scope.obj.RejectDesc = '';
            $scope.obj.T_DONOR_ID = '';
            $scope.obj.ValArray = [{ T_REJECT_REASON: null, RejectDesc: null }, { T_REJECT_REASON: null, RejectDesc: null }, { T_REJECT_REASON: null, RejectDesc: null }, { T_REJECT_REASON: null, RejectDesc: null }, { T_REJECT_REASON: null, RejectDesc: null }, { T_REJECT_REASON: null, RejectDesc: null }];
            $scope.obj.quesList = [];
            var img = document.getElementById("btnSign").style;
            img.background = "url(../Images/buttonWhite.png)";
            img.width = "100px";
            img.height = "100px";
            img.backgroundRepeat = "no-repeat";
            img.backgroundPosition = "center";
            img.borderColor = "#FBFBFB";
            $scope.obj.tf = true;
            //$scope.obj.disble = true;
            $scope.lang = JSON.parse(sessionStorage.getItem("LangName")) == undefined ? 2 : JSON.parse(sessionStorage.getItem("LangName"));
            if ($scope.lang == 2) {
                $scope.y = "Yes";
                $scope.n = "No";
                $scope.na = "N.A";
            } else {
                $scope.y = "نعم";
                $scope.n = "لا";
                $scope.na = "ن.ع";
            }
            $scope.AList = [{ ANS_ID: 1, ANS_DESC: $scope.y }, { ANS_ID: 2, ANS_DESC: $scope.n }, { ANS_ID: null, ANS_DESC: $scope.na }];

        }
        $scope.onPatSrch_blur = function () {
            var n = $scope.obj.t12022.T_PAT_NO;
            if (n != null) {
                var a = $scope.pad(n, 8);
                $scope.obj.t12022.T_PAT_NO = a == '00000000' ? '' : a;
            }
        }

        $scope.onPatSrch_tab = function (e) {
           
            if (e.keyCode === 9 || e.keyCode === 13) {
                var p = $scope.obj.t12022.T_PAT_NO;
                var n = $scope.obj.T_DONOR_ID;
                if (p != null) {
                    var a = $scope.pad(p, 8);
                    $scope.obj.t12022.T_PAT_NO = a == '00000000' ? '' : a;

                }
                $scope.getPatDetail($scope.obj.t12022.T_PAT_NO, n);
            }
            if (e.keyCode === 114 && $scope.obj.getPatInfo.length > 0) {
                e.preventDefault();
                $scope.onNextClick();
            }
        }
        $scope.getPatDetail = function (p, n) {
            if (p != null || n != null) {
                var getPatDetail = T12202Service.getPatDetail(p, n);
                getPatDetail.then(function (data) {
                    $scope.obj.getPatInfo = JSON.parse(data);
                    if ($scope.obj.getPatInfo.length > 0) {
                        $scope.obj.T_DONOR_ID = $scope.obj.getPatInfo[0].T_DONOR_ID;
                        $scope.obj.t12022.T_PAT_NO = $scope.obj.getPatInfo[0].T_PAT_NO;
                        $scope.obj.t12022.T_EPISODE_NO = $scope.obj.getPatInfo[0].T_EPISODE_NO;
                        $scope.obj.t12022.T_REQUEST_ID = $scope.obj.getPatInfo[0].T_REQUEST_ID;
                        $scope.obj.t12022.T_SER_USE = $scope.obj.getPatInfo[0].T_RESEARCH_STTS;
                        $scope.obj.PAT_DESC = $scope.obj.getPatInfo[0].PAT_NAME;
                        $scope.obj.GENDER = $scope.obj.getPatInfo[0].GENDER;
                        $scope.obj.SEX = $scope.obj.getPatInfo[0].T_SEX;
                        $scope.obj.MRTL_STTS = $scope.obj.getPatInfo[0].MRTL_STTS;
                        $scope.obj.NATIONALITY = $scope.obj.getPatInfo[0].NATIONALITY;
                        $scope.obj.YRS = $scope.obj.getPatInfo[0].YRS;
                        $scope.obj.MOS = $scope.obj.getPatInfo[0].MOS;
                        var epdate = Date.parse($scope.obj.getPatInfo[0].EPISODE_DATE);
                        $scope.obj.EPISODE_DATE = $filter('date')(epdate, "dd-MMM-yyyy");
                        $scope.obj.DIFF_STTS = $scope.obj.getPatInfo[0].DIFF_STTS;
                        $scope.obj.DIFF_STTS_SIGN = $scope.obj.getPatInfo[0].DIFF_STTS_SIGN;
                        $scope.obj.TOTAL_REG = $scope.obj.getPatInfo[0].TOTAL_REG;

                        $scope.obj.t12022.T_MAX_DIFFERED_DAY = $scope.obj.getPatInfo[0].DIFF_DAY;
                        var dfdate = Date.parse($scope.obj.getPatInfo[0].DIFF_UPTO);
                      $scope.obj.t12022.T_MAX_DIFFERED_DATE = $scope.obj.t12022.T_MAX_DIFFERED_DAY>0?$filter('date')(dfdate, "dd-MMM-yyyy"):null;


                        var img = document.getElementById("btnSign").style;
                        $scope.obj.T_EPISODE_NO_22 = $scope.obj.getPatInfo[0].T_EPISODE_NO_22;
                        if ($scope.obj.T_EPISODE_NO_22 == null) {
                            //-------------insert 
                          
                          if ($scope.obj.DIFF_STTS == null) {
                                img.background = "url(../Images/buttonGreen.png)";
                                $scope.obj.DIFF_STTS_SIGN = "Green";
                            }
                          else if ($scope.obj.DIFF_STTS == '1') {
                                img.background = "url(../Images/buttonYellow.png)";
                                $scope.obj.DIFF_STTS_SIGN = "Yellow";

                            }
                            else if ($scope.obj.DIFF_STTS == '2') {
                                img.background = "url(../Images/ButonRed.png)";
                                $scope.obj.DIFF_STTS_SIGN = "Red";

                            }

                        }
                        else if ($scope.obj.t12022.T_EPISODE_NO == $scope.obj.T_EPISODE_NO_22) {
                            //-----------Update
                        
                            if ($scope.obj.DIFF_STTS == null) {
                                img.background = "url(../Images/buttonGreen.png)";
                                $scope.obj.DIFF_STTS_SIGN = "Green";
                            }
                            else if ($scope.obj.DIFF_STTS == '1') {
                                img.background = "url(../Images/buttonYellow.png)";
                                $scope.obj.DIFF_STTS_SIGN = "Yellow";
                            }
                            else if ($scope.obj.DIFF_STTS == '2') {
                                img.background = "url(../Images/ButonRed.png)";
                                $scope.obj.DIFF_STTS_SIGN = "Red";
                            }

                        }

                        img.width = "100px";
                        img.height = "100px";
                        img.backgroundRepeat = "no-repeat";
                        img.backgroundPosition = "center";
                        img.borderColor = "#FBFBFB";

                      $scope.onNextClick();
                    }
                    else {
                        alert('Data not found');
                        clear();
                    }
                });
            }

        }
        
        $scope.onAnsClick = function () {
            if ($scope.obj.T_UNIT_NO != null) {
                alert('Data Can not be changed!!');
                return;
            }
           
        }
        $scope.onAnsSelect = function (a, i) {
            //var pRes = $scope.obj.quesList[i].T_QNO_ANS;
            //if ($scope.obj.T_UNIT_NO != null) {

            //}
            if ($scope.obj.T_UNIT_NO == null) {
                var t71 = {};
                t71.T_DONOR_ID = $scope.obj.T_DONOR_ID;
                t71.T_DONOR_PATNO = $scope.obj.t12022.T_PAT_NO;
                t71.T_DONOR_EPISODE = $scope.obj.t12022.T_EPISODE_NO;
                t71.T_REQUEST_ID = $scope.obj.t12022.T_REQUEST_ID;

                t71.T_QNO = $scope.obj.quesList[i].T_QNO;
                t71.T_QNO_ANS = a;
                t71.T_QHEAD_NO = $scope.obj.quesList[i].T_QHEAD_NO;
                t71.T_DISP_SEQ = $scope.obj.quesList[i].T_DISP_SEQ;
                t71.T_QUES_ID = $scope.obj.quesList[i].T_QUES_ID;
                t71.T_DIFFERAL_DAY = $scope.obj.quesList[i].T_EXP_ANS != a && $scope.obj.quesList[i].T_IF_FAIL === "1" ? $scope.obj.quesList[i].T_DIFFERAL_DAY_TEMP : 0;

                var singleInsert = T12202Service.singleInsert(t71);
                singleInsert.then(function (data) {
                    $scope.obj.quesList[i].T_QUES_ID = data;
                  $scope.obj.quesList[i].T_DIFFERAL_DAY = t71.T_DIFFERAL_DAY;
                });


                var img = document.getElementById("imgDiffSign" + i);
                $scope.obj.quesList[i].T_QNO_ANS = a;
                $scope.obj.quesList[i].AnsQues = a;

                if ($scope.obj.quesList[i].T_QNO_ANS == null) {
                    img.src = "../Images/buttonWhite.png";
                    $scope.obj.quesList[i].T_DIFFERAL_DAY = $scope.obj.quesList[i].T_DIFFERAL_DAY_TEMP;
                    $scope.obj.quesList[i].sortQues = 0;
                } else {
                     if ($scope.obj.quesList[i].T_QNO_ANS == $scope.obj.quesList[i].T_EXP_ANS) {
                    img.src = "../Images/buttonGreen.png";
                    $scope.obj.quesList[i].T_DIFFERAL_DAY = 0;
                    $scope.obj.quesList[i].sortQues = 0;
                }
                else if ($scope.obj.quesList[i].T_QNO_ANS != $scope.obj.quesList[i].T_EXP_ANS) {
                    if ($scope.obj.quesList[i].T_IF_FAIL === "1") {
                        img.src = "../Images/buttonYellow.png";
                        $scope.obj.quesList[i].T_DIFFERAL_DAY = $scope.obj.quesList[i].T_DIFFERAL_DAY_TEMP;
                        $scope.obj.quesList[i].sortQues = 1;
                    }
                    else if ($scope.obj.quesList[i].T_IF_FAIL === "2") {
                        img.src = "../Images/ButonRed.png";
                        $scope.obj.quesList[i].T_DIFFERAL_DAY = 0;
                        $scope.obj.quesList[i].sortQues = 2;
                    }
                }    
                }
               
                var green = 0;
                var yellow = 0;
                var red = 0;
                var imgm = document.getElementById("btnSign").style;
                for (var j = 0; j < $scope.obj.quesList.length; j++) {
                    if ($scope.obj.quesList[j].T_QNO_ANS == null) {
                        green++;
                    } else {if ($scope.obj.quesList[j].T_QNO_ANS == $scope.obj.quesList[j].T_EXP_ANS) { green++; }
                    else if ($scope.obj.quesList[j].T_QNO_ANS != $scope.obj.quesList[j].T_EXP_ANS) {

                        if ($scope.obj.quesList[j].T_IF_FAIL == "1") {
                            yellow++;
                        } else if ($scope.obj.quesList[j].T_IF_FAIL == "2") {
                            red++;
                        }
                    }
                    }
                    
                }
                if ($scope.obj.quesList.length == green) {
                    imgm.background = "url(../Images/buttonGreen.png)";
                    $scope.obj.DIFF_STTS = null;
                    $scope.obj.DIFF_STTS_SIGN = "Green";
                    if ($scope.obj.t12022.T_REJECT_REASON == null || $scope.obj.t12022.T_REJECT_REASON == "") {
                        $scope.obj.DifferedReason = '';
                        $scope.obj.t12022.T_DIFFERED_STATUS = null;
                        $scope.obj.t12022.T_ACCEPT_STATUS = 1;

                    }

                }
                else if ($scope.obj.quesList.length != green) {
                    if (red > 0) {
                        imgm.background = "url(../Images/ButonRed.png)";
                        $scope.obj.DIFF_STTS = '2';
                        $scope.obj.DIFF_STTS_SIGN = "Red";
                        $scope.obj.DifferedReason = 'Permanent';
                        $scope.obj.t12022.T_DIFFERED_STATUS = 1;
                        $scope.obj.t12022.T_ACCEPT_STATUS = null;
                    }
                    else if (red == 0 && yellow > 0) {
                        imgm.background = "url(../Images/buttonYellow.png)";
                        $scope.obj.DIFF_STTS = '1';
                        $scope.obj.DIFF_STTS_SIGN = "Yellow";
                        $scope.obj.DifferedReason = 'Temporary';
                        $scope.obj.t12022.T_DIFFERED_STATUS = 2;
                        $scope.obj.t12022.T_ACCEPT_STATUS = null;
                    }

                }

                imgm.width = "100px";
                imgm.height = "100px";
                imgm.backgroundRepeat = "no-repeat";
                imgm.backgroundPosition = "center";
                imgm.borderColor = "#FBFBFB";
                //imgm.marginLeft = "-30px";


                $scope.obj.t12022.T_MAX_DIFFERED_DAY = Math.max.apply(Math, $scope.obj.quesList.map(function (o) { return parseInt(o.T_DIFFERAL_DAY) }));
                var ddate = new Date();
                var dday = parseInt($scope.obj.t12022.T_MAX_DIFFERED_DAY);
              $scope.obj.t12022.T_MAX_DIFFERED_DATE = $scope.obj.t12022.T_MAX_DIFFERED_DAY>0?$filter('date')(ddate.setDate(parseInt(ddate.getDate()) + dday), "dd-MMM-yyyy"):null;

                $scope.obj.t12022.REC_DIF_DAY = Math.max.apply(Math, $scope.obj.quesList.map(function (o) { return parseInt(o.T_DIFFERAL_DAY) }));
                var rdate = new Date();
                var rday = parseInt($scope.obj.t12022.REC_DIF_DAY);
              $scope.obj.t12022.T_DIFFERED_DATE = $scope.obj.t12022.REC_DIF_DAY>0?$filter('date')(rdate.setDate(parseInt(rdate.getDate()) + rday), "dd-MMM-yyyy"):null;

            } else {
                alert('Access denied');
                return;   
            }
           

        };
        $scope.onVitalSignCheck = function (p, v, i) {
            if (v != null) {
                var getValidation = T12202Service.getValidation(p, v);
                getValidation.then(function(data) {
                    var dt = JSON.parse(data);
                    if (p === '0006') {
                        if (dt[0].T_ACCEPT_STATUS == "2") {
                            alert('Invalid Temp');
                            $scope.obj.t12022.T_TEMPTURE = '';
                            document.getElementById("txtTemp").focus();
                            return;
                        }
                    }
                    $scope.obj.ValArray[i]["T_REJECT_REASON"] = dt[0].T_RES_CODE;
                    $scope.obj.ValArray[i]["RejectDesc"] = dt[0].NAME;
                    $scope.obj.t12022.T_REJECT_REASON = '';
                    $scope.obj.RejectDesc = '';
                    for (var j = 0; j < $scope.obj.ValArray.length; j++) {
                        var a = $scope.obj.ValArray[j].T_REJECT_REASON;
                        if (a != null) {
                            $scope.obj.t12022.T_REJECT_REASON += $scope.obj.ValArray[j].T_REJECT_REASON + ',';
                            $scope.obj.RejectDesc += $scope.obj.ValArray[j].RejectDesc + ',';
                        }
                    }
                    var r = $scope.obj.RejectDesc;
                    $scope.obj.RejectDesc = r.substring(0, r.length - 1);
                    var c = $scope.obj.t12022.T_REJECT_REASON;
                    $scope.obj.t12022.T_REJECT_REASON = c.substring(0, c.length - 1);
                    if (c != '') {
                        if ($scope.obj.DIFF_STTS == null) {
                            $scope.obj.DifferedReason = 'Temporary';
                            $scope.obj.t12022.T_DIFFERED_STATUS = 2;
                            $scope.obj.t12022.T_ACCEPT_STATUS = null;
                        }
                    } else {
                        if ($scope.obj.DIFF_STTS == null) {
                            $scope.obj.DifferedReason = '';
                            $scope.obj.t12022.T_DIFFERED_STATUS = null;
                            $scope.obj.t12022.T_ACCEPT_STATUS = 1;
                        } else if ($scope.obj.DIFF_STTS == 1) {
                            $scope.obj.DifferedReason = 'Temporary';
                            $scope.obj.t12022.T_DIFFERED_STATUS = 2;
                            $scope.obj.t12022.T_ACCEPT_STATUS = null;
                        } else if ($scope.obj.DIFF_STTS == 2) {
                            $scope.obj.DifferedReason = 'Permanent';
                            $scope.obj.t12022.T_DIFFERED_STATUS = 1;
                            $scope.obj.t12022.T_ACCEPT_STATUS = null;
                        }
                    }


                });
            }
        }
        $scope.onVitalSignCheckUI = function (p, v, i, e, f) {
            if (e.keyCode === 9 || e.keyCode === 13) {
                $scope.onVitalSignCheck(p, v, i);
                document.getElementById(f).focus();
            }
        }
        $scope.onRecmndDiffDaysGiven = function (e) {
            if (e.keyCode === 9 || e.keyCode === 13) {
                var r = parseInt($scope.obj.t12022.REC_DIF_DAY);
                if (r != null) {
                    var date = new Date();
                    $scope.obj.t12022.T_DIFFERED_DATE = $filter('date')(date.setDate(parseInt(date.getDate()) + r), "dd-MMM-yyyy");
                }
            }


        }
        $scope.onbtnSignClick = function () {

            if ($scope.obj.quesList.length == 0) {
                $scope.onNextClick();
            } else {
                //$scope.obj.quesList.sort(function (a, b) { return (b.sortQues - a.sortQues) });

                var s = '';
                if ($scope.obj.DIFF_STTS == null) {
                    s = 0;
                } else if ($scope.obj.DIFF_STTS == '1') {
                    s = 1;
                } else if ($scope.obj.DIFF_STTS == '2') {
                    s = 2;
                }
                //$scope.obj.quesList = $scope.obj.quesList.filter(function (ar) {
                //    return ar.sortQues == s;
                //});
                
                //$scope.obj.quesList[i].sortQues == null;
                for (var i = 0; i < $scope.obj.quesList.length; i++) {
                    if (s==0) {
                        if ($scope.obj.quesList[i].sortQues == s || $scope.obj.quesList[i].sortQues == null) {
                            document.getElementById("trQues" + i).style.display = 'table';
                            document.getElementById("trQues" + i).style.width = '100%';
                            document.getElementById("trQues" + i).style.tableLayout = 'fixed';
                        } else {
                            document.getElementById("trQues" + i).style.display = 'none';
                        }
                    } else {
                        if ($scope.obj.quesList[i].sortQues == s) {
                            document.getElementById("trQues" + i).style.display = 'table';
                            document.getElementById("trQues" + i).style.width = '100%';
                            document.getElementById("trQues" + i).style.tableLayout = 'fixed';
                        } else {
                            document.getElementById("trQues" + i).style.display = 'none';
                        }
                    }
                }
            }
        }
        $scope.onSaveClick = function () {
            var count = 0;
            for (var i = 0; i < $scope.obj.quesList.length; i++) {
                if ($scope.obj.quesList[i].T_QNO_ANS != null) {
                    count++;
                }
            }

            if ($scope.obj.quesList.length==count) {
                var t22 = $scope.obj.t12022;
                //var t71 = $scope.obj.t12071;
                if ($scope.obj.T_UNIT_NO == null) {
                    var t = $scope.obj.t12022.T_EPISODE_NO == $scope.obj.T_EPISODE_NO_22 ? 'u' : 'i';
                    var insert = T12202Service.insert(t22, t);
                    insert.then(function (data) {
                      alert(JSON.parse(data));
                      $scope.onClear();
                    });
                } else {
                    alert('Access denied');
                    return;

                } 
            } else {
                alert('Please answer all question!!!');
            }











            //$scope.obj.t12071 = [];
            //for (var i = 0; i < $scope.obj.quesList.length; i++) {
            //    $scope.obj.demo = {};
            //    if ($scope.obj.quesList[i].AnsQues != '') {
            //        $scope.obj.demo.T_QNO = $scope.obj.quesList[i].T_QNO;
            //        $scope.obj.demo.T_QNO_ANS = $scope.obj.quesList[i].T_QNO_ANS;
            //        $scope.obj.demo.T_QUES_ID = $scope.obj.quesList[i].T_QUES_ID;
            //        $scope.obj.demo.T_DIFFERAL_DAY = $scope.obj.quesList[i].T_DIFFERAL_DAY;
            //        $scope.obj.t12071.push($scope.obj.demo);
            //    }
            //}
            


        }
        $scope.onNextClick = function () {
            var p = $scope.obj.t12022.T_PAT_NO;
            var n = $scope.obj.T_DONOR_ID;
            var r = $scope.obj.t12022.T_REQUEST_ID;
            var s = $scope.obj.SEX;



            if (r != '' || r != null) {
                var getQues = T12202Service.getQues(p, n, r, s);
                getQues.then(function (dt) {
                    var qList = [];
                    var quesList = JSON.parse(dt);
                    for (var i = 0; i < quesList.length; i++) {
                        var temp = {};
                        temp.a = {};
                        temp.QUES_DESC = quesList[i].QUES_DESC;
                        temp.T_DIFFERAL_DAY_TEMP = quesList[i].T_DIFFERAL_DAY;
                        temp.T_IF_FAIL = quesList[i].T_IF_FAIL;
                        temp.T_QNO = quesList[i].T_QNO;
                        temp.T_QNO_ANS = quesList[i].T_QNO_ANS;
                        temp.T_EXP_ANS = quesList[i].T_EXP_ANS;
                        temp.T_QUES_ID = quesList[i].T_QUES_ID;
                        temp.T_QHEAD_NO = quesList[i].T_QHEAD_NO;
                        temp.T_DISP_SEQ = quesList[i].T_DISP_SEQ;
                        if ($scope.obj.getPatInfo[0].T_UNIT_NO != null) {
                            temp.disble = true;
                        } else {
                            temp.disble = false;
                        }

                        temp.AnsQues = '';
                        if (temp.T_QNO_ANS === "1") {
                            temp.a.selected = { ANS_ID: 1, ANS_DESC: $scope.y };
                        }
                        else if (temp.T_QNO_ANS === "2") {
                            temp.a.selected = { ANS_ID: 2, ANS_DESC: $scope.n };
                        }
                        else if (temp.T_QNO_ANS === null) {
                            temp.a.selected = { ANS_ID: 3, ANS_DESC: $scope.na };
                        }

                        temp.getAnsList = $scope.AList;

                        if (temp.T_QNO_ANS == null) {
                            temp.src = "../Images/buttonWhite.png";
                            temp.T_DIFFERAL_DAY = quesList[i].T_DIFFERAL_DAY;
                            temp.sortQues = null;
                        }
                        else if (temp.T_QNO_ANS == temp.T_EXP_ANS) {
                            temp.src = "../Images/buttonGreen.png";
                            temp.T_DIFFERAL_DAY = 0;
                            temp.sortQues = 0;
                        }
                        else if (temp.T_QNO_ANS != temp.T_EXP_ANS) {
                            if (temp.T_IF_FAIL === "1") {
                                temp.src = "../Images/buttonYellow.png";
                                temp.T_DIFFERAL_DAY = quesList[i].T_DIFFERAL_DAY;
                                temp.sortQues = 1;
                            }
                            else if (temp.T_IF_FAIL === "2") {
                                temp.src = "../Images/ButonRed.png";
                                temp.T_DIFFERAL_DAY = 0;
                                temp.sortQues = 2;
                            }
                        }

                        qList.push(temp);
                    }
                    $scope.obj.quesList = qList;


                    $scope.obj.T_UNIT_NO = $scope.obj.getPatInfo[0].T_UNIT_NO;
                    $scope.obj.t12022.T_VITAL_ID = $scope.obj.getPatInfo[0].T_VITAL_ID;
                    $scope.obj.t12022.T_WEIGHT = $scope.obj.getPatInfo[0].T_WEIGHT;
                    $scope.obj.t12022.T_HB = $scope.obj.getPatInfo[0].T_HB;
                    $scope.obj.t12022.T_PULS = $scope.obj.getPatInfo[0].T_PULS;
                    $scope.obj.t12022.T_TEMPTURE = $scope.obj.getPatInfo[0].T_TEMPTURE;
                    $scope.obj.t12022.T_BP_HIGH = $scope.obj.getPatInfo[0].T_BP_HIGH;
                    $scope.obj.t12022.T_BP_LOW = $scope.obj.getPatInfo[0].T_BP_LOW;
                    //$scope.obj.t12022.T_REJECT_REASON = $scope.obj.getPatInfo[0].T_REJECT_REASON;
                    //$scope.obj.RejectDesc = $scope.obj.getPatInfo[0].T_REJECT_DESC;
                    $scope.obj.t12022.T_COMMENT = $scope.obj.getPatInfo[0].T_COMMENT;
                    $scope.onVitalSignCheck('0003', $scope.obj.t12022.T_WEIGHT, 0);
                    $scope.onVitalSignCheck('0005', $scope.obj.t12022.T_HB, 1);
                    $scope.onVitalSignCheck('0004', $scope.obj.t12022.T_PULS, 2);
                    $scope.onVitalSignCheck('0001', $scope.obj.t12022.T_BP_HIGH, 4);
                    $scope.onVitalSignCheck('0002', $scope.obj.t12022.T_BP_LOW, 5);
                    $scope.obj.tf = false;
                    var img = document.getElementById("btnSign").style;
                    $scope.obj.T_EPISODE_NO_22 = $scope.obj.getPatInfo[0].T_EPISODE_NO_22;
                    if ($scope.obj.T_EPISODE_NO_22 == null) {
                        //-------------insert 
                        $scope.obj.t12022.REC_DIF_DAY = $scope.obj.getPatInfo[0].DIFF_DAY;
                        var rdfdate = Date.parse($scope.obj.getPatInfo[0].DIFF_UPTO);
                      $scope.obj.t12022.T_DIFFERED_DATE = $scope.obj.t12022.REC_DIF_DAY>0? $filter('date')(rdfdate, "dd-MMM-yyyy"):null;

                        if ($scope.obj.DIFF_STTS == null) {
                            img.background = "url(../Images/buttonGreen.png)";
                            $scope.obj.DIFF_STTS_SIGN = "Green";
                            $scope.obj.DifferedReason = '';
                            $scope.obj.t12022.T_DIFFERED_STATUS = null;
                            $scope.obj.t12022.T_ACCEPT_STATUS = 1;
                        }
                        else if ($scope.obj.DIFF_STTS == '1') {
                            img.background = "url(../Images/buttonYellow.png)";
                            $scope.obj.DIFF_STTS_SIGN = "Yellow";
                            $scope.obj.DifferedReason = 'Temporary';
                            $scope.obj.t12022.T_DIFFERED_STATUS = 2;
                            $scope.obj.t12022.T_ACCEPT_STATUS = null;
                        }
                        else if ($scope.obj.DIFF_STTS == '2') {
                            img.background = "url(../Images/ButonRed.png)";
                            $scope.obj.DIFF_STTS_SIGN = "Red";
                            $scope.obj.DifferedReason = 'Permanent';
                            $scope.obj.t12022.T_DIFFERED_STATUS = 3;
                            $scope.obj.t12022.T_ACCEPT_STATUS = null;
                        }

                    }
                    else if ($scope.obj.t12022.T_EPISODE_NO == $scope.obj.T_EPISODE_NO_22) {
                        //-----------Update
                        $scope.obj.t12022.REC_DIF_DAY = $scope.obj.getPatInfo[0].REC_DIF_DAY;
                        var urdfdate = Date.parse($scope.obj.getPatInfo[0].T_DIFFERED_DATE);
                      $scope.obj.t12022.T_DIFFERED_DATE = $scope.obj.t12022.REC_DIF_DAY>0?$filter('date')(urdfdate, "dd-MMM-yyyy"):null;

                        if ($scope.obj.DIFF_STTS == null) {
                            img.background = "url(../Images/buttonGreen.png)";
                            $scope.obj.DIFF_STTS_SIGN = "Green";
                        }
                        else if ($scope.obj.DIFF_STTS == '1') {
                            img.background = "url(../Images/buttonYellow.png)";
                            $scope.obj.DIFF_STTS_SIGN = "Yellow";
                        }
                        else if ($scope.obj.DIFF_STTS == '2') {
                            img.background = "url(../Images/ButonRed.png)";
                            $scope.obj.DIFF_STTS_SIGN = "Red";
                        }
                        $scope.obj.DifferedReason = $scope.obj.getPatInfo[0].DIFFEREDREASON;
                        $scope.obj.t12022.T_DIFFERED_STATUS = $scope.obj.getPatInfo[0].T_DIFFERED_STATUS;
                        $scope.obj.t12022.T_ACCEPT_STATUS = $scope.obj.getPatInfo[0].T_ACCEPT_STATUS;
                    }
                    $scope.obj.ValArray = [{ T_REJECT_REASON: null, RejectDesc: null }, { T_REJECT_REASON: null, RejectDesc: null }, { T_REJECT_REASON: null, RejectDesc: null }, { T_REJECT_REASON: null, RejectDesc: null }, { T_REJECT_REASON: null, RejectDesc: null }, { T_REJECT_REASON: null, RejectDesc: null }];
                    img.width = "100px";
                    img.height = "100px";
                    img.backgroundRepeat = "no-repeat";
                    img.backgroundPosition = "center";
                    img.borderColor = "#FBFBFB";

                });
            }

        }
        $scope.onClear = function () {
            clear();
        }
    }]);
app.directive('myMaxlength', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            var maxlength = Number(attrs.myMaxlength);
            function fromUser(text) {
                if (text.length > maxlength) {
                    var transformedInput = text.substring(0, maxlength);
                    ngModelCtrl.$setViewValue(transformedInput);
                    ngModelCtrl.$render();
                    return transformedInput;
                }
                return text;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    };
});
app.directive('numbersOnly', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {
                    var transformedInput = text.replace(/[^0-9]/g, '');

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