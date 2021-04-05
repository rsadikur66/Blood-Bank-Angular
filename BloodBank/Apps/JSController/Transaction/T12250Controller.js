app.controller("T12250Controller", ["$scope", "T12250Service", "Data", "$window", "$filter",
    function ($scope, T12250Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.t12017 = {};
        $scope.pati = false;
        document.getElementById("txtDonorNo").focus();
        $scope.FCode = JSON.parse(sessionStorage.getItem("FCode"));
        $scope.FName = JSON.parse(sessionStorage.getItem("FName"));

        $scope.obj.t12017.T_PAT_NO = JSON.parse(sessionStorage.getItem("PatNo"));
        if ($scope.obj.t12017.T_PAT_NO !== null) { LoadwithPreviousData(); }

        $scope.lang = JSON.parse(sessionStorage.getItem("LangName")) == undefined ? 2 : JSON.parse(sessionStorage.getItem("LangName"));

        //-------------------------------------Page Starts---------------------
        $scope.RegPage = function () {
            sessionStorage.setItem("FCode", JSON.stringify("T12214"));
            var name = $scope.lang === '1' ? "تسجيل الحملا" : "Hamla Registration";
            sessionStorage.setItem("FName", JSON.stringify(name));
            sessionStorage.setItem("FReqCode", JSON.stringify("T12250"));
            var labelData = T12250Service.GetLabelText("T12214", $scope.lang);
            labelData.then(function (data) {
                $scope.entity = JSON.parse(data);
                sessionStorage.setItem("LabelData", JSON.stringify($scope.entity));

                var hostAddress = $window.location.host;
                var url = "http://" + hostAddress + $scope.vrDir + "/Transaction/T12214";
                $window.location.href = url;
            });


        }

        $scope.NextClick = function () {
            document.getElementById('txtReasonCode').focus();

        }

        $scope.NewClick = function () {
            $scope.Clear();
        }

        //-------------- For Autosearch start--------------

        $scope.complete = function (e, p) {
            if ($scope.obj.t12017.T_REF_PAT_NO != '') {
                if (e.keyCode === 9) {
                    var n = p;
                    if (n != null) {
                        var a = pad(n, 8);
                        $scope.obj.b = a == '00000000' ? '' : a;
                        var singlePat = T12250Service.GetPatientData($scope.obj.b);
                        singlePat.then(function (data) {
                            $scope.obj.singlePat = data;
                            if ($scope.obj.singlePat.length > 0) {
                                $scope.obj.t12017.T_OTHER_PAT_NAME = $scope.obj.singlePat[0].T_OTHER_PAT_NAME;
                                $scope.obj.t12017.T_REF_PAT_NO = $scope.obj.singlePat[0].T_REF_PAT_NO;

                            } else {
                                $scope.obj.t12017.T_OTHER_PAT_NAME = '';
                                $scope.obj.t12017.T_REF_PAT_NO = '';
                                document.getElementById('txtpatient').focus();

                            }
                            $scope.SearTable = false;
                            return;
                        });
                    }
                } else if (e.keyCode === 13) {
                    var patData = T12250Service.GetPatientData(p);
                    patData.then(function (data) {
                        if (data.length !== 0) {
                            $scope.obj.patList = data;
                            $scope.SearTable = true;
                            return;
                        } else {
                            $scope.SearTable = false;
                            $scope.obj.t12017.T_OTHER_PAT_NAME = '';
                            $scope.obj.t12017.T_REF_PAT_NO = '';
                            document.getElementById('txtpatient').focus();
                            return;
                        }


                    });
                }

            }


        }

        $scope.SelectSearchcc_Click = function (slobj) {
            $scope.obj.t12017.T_OTHER_PAT_NAME = slobj.T_OTHER_PAT_NAME;
            $scope.obj.t12017.T_REF_PAT_NO = slobj.T_REF_PAT_NO;
            $scope.SearTable = false;
            $scope.AutoSearchTexBox = false;
            //$scope.obj.chk_auto = true;
        }
        $scope.onSearch = function () {
            $scope.Clear();
            document.getElementById("btnEnterQuery").className = "Button Cancel";
            document.getElementById("txtNationalId").readOnly = false;
            document.getElementById("txtDonorNo").focus();
            return;
        }

        $scope.onExecute = function () {
            LoadwithPreviousData();
        }
        $scope.Clear = function () {
            $scope.obj.t12017.T_PAT_NO = '';
            $scope.obj.t12017.T_DONOR_NTNLTY_ID = '';


            $scope.obj.PatName = '';
            $scope.obj.Year = '';
            $scope.obj.Month = '';
            $scope.obj.Nationality = '';
            $scope.obj.Gender = '';
            $scope.obj.MaritalStatus = '';
            $scope.obj.LastEpisode = '';
            $scope.obj.LastArrDate = '';
            $scope.obj.LastArrTime = '';
            $scope.obj.DifferedDateUpto = '';
            $scope.obj.T_ARRIVAL_DATE = '';
            $scope.obj.ArrivalDateHijri = '';
            $scope.obj.t12017.T_DOTN_RSN_CODE = '';
            $scope.obj.ReasonDesc = '';
            $scope.obj.t12017.T_OTHER_PAT_NAME = '';
            $scope.obj.t12017.T_REF_PAT_NO = '';

            var img = document.getElementById("btnSign").style;
            img.background = "url(../Images/buttonWhite.png)";
            img.width = "75px";
            img.height = "75px";
            img.backgroundRepeat = "round";
            img.borderColor = "#FBFBFB";

            document.getElementById("btnEnterQuery").className = "Button Enter";
            document.getElementById("txtNationalId").readOnly = true;
            sessionStorage.setItem("PatNo", null);
        }
        $scope.getReasonList = function () {
            $scope.obj.chk = false;
            var a = parseInt($scope.obj.Year);
            var m = parseInt($scope.obj.Month) / 12;
            var ag = a + m;
            var p = $scope.obj.t12017.T_PAT_NO;
            if (p != null) {
                var reasonList = T12250Service.GetReasonList(ag);
                reasonList.then(function (data) {
                    $scope.reasonList = JSON.parse(data);
                    if ($scope.reasonList.length > 0) {
                        document.getElementById("divReason").style.display = 'block';
                    } else { alert('No Data is available for this aged patient'); }
                });
            } else { alert('Please select Patient'); return; }
        }
        $scope.obj.chk = true;
        $scope.getReasonbyCode = function (event, e) {
            if (event.keyCode === 9 || event.keyCode === 13) {
                if (e != null) {
                    var a = parseInt($scope.obj.Year);
                    var m = parseInt($scope.obj.Month) / 12;
                    var ag = a + m;
                    var p = $scope.obj.t12017.T_PAT_NO;
                    if (p != null) {
                        var reasonList = T12250Service.GetSingleReason(ag, e);
                        reasonList.then(function (data) {
                            $scope.reasonList = JSON.parse(data);
                            if ($scope.reasonList.length > 0) {
                                $scope.obj.t12017.T_DOTN_RSN_CODE = $scope.reasonList[0].CODE;
                                $scope.obj.ReasonDesc = $scope.reasonList[0].NAME;
                                $scope.obj.T_ARRIVAL_DATE = $filter('date')(new Date(), "dd-MMM-yyyy");
                                $scope.obj.ArrivalDateHijri = moment().format('iYYYY/iMM/iDD');
                                document.getElementById("divReason").style.display = 'none';
                                $scope.pati = $scope.obj.t12017.T_DOTN_RSN_CODE === '05' ? true : false;
                            } else {
                                $scope.obj.t12017.T_DOTN_RSN_CODE = '';
                                $scope.obj.ReasonDesc = '';
                                $scope.obj.T_ARRIVAL_DATE = '';
                                $scope.obj.ArrivalDateHijri = '';
                                $scope.pati = $scope.obj.t12017.T_DOTN_RSN_CODE === '05' ? true : false;
                                alert('No Data is available');
                            }
                            $scope.obj.t12017.T_OTHER_PAT_NAME = '';
                            $scope.obj.t12017.T_REF_PAT_NO = '';
                        });
                    } else {
                        $scope.obj.t12017.T_DOTN_RSN_CODE = '';
                        alert('Please select Patient');
                        return;
                    }
                } else {
                    alert('No Code Has been Given');
                }
            }
            else if (event.keyCode === 120) {
                $scope.getReasonList();
            }
        }
        $scope.onReasonSelect = function (i) {
            $scope.obj.t12017.T_DOTN_RSN_CODE = $scope.reasonList[i].CODE;
            $scope.obj.ReasonDesc = $scope.reasonList[i].NAME;
            $scope.obj.T_ARRIVAL_DATE = $filter('date')(new Date(), "dd-MMM-yyyy");
            $scope.obj.ArrivalDateHijri = moment().format('iYYYY/iMM/iDD');
            document.getElementById("divReason").style.display = 'none';
            $scope.pati = $scope.obj.t12017.T_DOTN_RSN_CODE === '05' ? true : false;
            $scope.obj.chk = true;

            $scope.obj.t12017.T_OTHER_PAT_NAME = '';
            $scope.obj.t12017.T_REF_PAT_NO = '';
        }
        $scope.CloseReasonPopup = function () {
            document.getElementById("divReason").style.display = 'none';
            $scope.obj.chk = true;
        }

        $scope.onSave = function () {
            var la = $scope.obj.LastArrDate;
            var ca = $scope.obj.T_ARRIVAL_DATE;
            var u = $scope.obj.UnitNo;
            var e = $scope.obj.LastEpisode;
            if (la == ca) { alert('Patient can not donate twice a day'); return; }
            //if (u == null && e > 0) { alert('Previous Episode not completed yet'); return; }

            var insert = T12250Service.insert($scope.obj.t12017);
            $scope.loader(true);
            insert.then(function (data) {
                $scope.loader(false);
                alert(data);
                pdfPrint();
                $scope.Clear();
            });


        }

        $scope.onPrint = function () {
            var patNo = $scope.obj.t12017.T_PAT_NO;
            var patName = $scope.obj.PatName;
            var nationalityId = $scope.obj.t12017.T_DONOR_NTNLTY_ID;
            var lastepisode = $scope.obj.LastEpisode;
            var arrivaldate = $scope.obj.T_ARRIVAL_DATE;
            var gender = $scope.obj.Gender;
            var year = $scope.obj.Year;
            var nationality = $scope.obj.Nationality;
            $window.open("../R12201Report/GetReport?patNo=" + patNo + "&&patName=" + patName + "&&nationalityId=" + nationalityId + "&&lastepisode=" + lastepisode + "&&arrivaldate=" + arrivaldate + "&&gender=" + gender + "&&year=" + year + "&&nationality=" + nationality, "popup", "width=600,height=600,left=100,top=50");
        }



        function pdfPrint() {
            //T12250Service.GetReport($scope.obj.t12017.T_PAT_NO, $scope.obj.PatName);

            var patNo = $scope.obj.t12017.T_PAT_NO;
            var patName = $scope.obj.PatName;
            var nationalityId = $scope.obj.t12017.T_DONOR_NTNLTY_ID;
            var lastepisode = $scope.obj.LastEpisode;
            var arrivaldate = $scope.obj.T_ARRIVAL_DATE;
            var gender = $scope.obj.Gender;
            var year = $scope.obj.Year;
            var nationality = $scope.obj.Nationality;
            $window.open("../R12201Report/GetReport?patNo=" + patNo + "&&patName=" + patName + "&&nationalityId=" + nationalityId + "&&lastepisode=" + lastepisode + "&&arrivaldate=" + arrivaldate + "&&gender=" + gender + "&&year=" + year + "&&nationality=" + nationality, "popup", "width=600,height=600,left=100,top=50");
        }
        function LoadwithPreviousData() {
            var p = $scope.obj.t12017.T_PAT_NO;
            var n = $scope.obj.t12017.T_DONOR_NTNLTY_ID;
            if (p !== '' || n !== '') {
                $scope.req = T12250Service.CheckDonor(p, n);
                $scope.req.then(function (data) {
                    var newDataJSON = JSON.parse(data);
                    if (newDataJSON.length > 0) {
                        if (newDataJSON[0].T_NTNLTY_ID == null) {
                            alert('Nationality cannot be null');
                            return;
                        }
                        var a = parseInt(newDataJSON[0].YRS);
                        var m = parseInt(newDataJSON[0].MOS) / 12;
                        var ag = a + m;
                        var reasonList = T12250Service.GetSingleReason(ag, '02');
                        reasonList.then(function (data) {
                            if (JSON.parse(data).length == 0) {
                                alert('Donor Cancelled due to invalid age');
                                return;
                            } else {
                                $scope.obj.t12017.T_DOTN_RSN_CODE = JSON.parse(data)[0].CODE;
                                $scope.obj.ReasonDesc = JSON.parse(data)[0].NAME;
                                $scope.obj.T_ARRIVAL_DATE = $filter('date')(new Date(), "dd-MMM-yyyy");
                                $scope.obj.ArrivalDateHijri = moment().format('iYYYY/iMM/iDD');
                                document.getElementById("divReason").style.display = 'none';
                                $scope.pati = $scope.obj.t12017.T_DOTN_RSN_CODE === '05' ? true : false;

                                $scope.obj.t12017.T_PAT_NO = newDataJSON[0].T_PAT_NO;
                                $scope.obj.PatName = newDataJSON[0].PAT_NAME;
                                $scope.obj.Year = newDataJSON[0].YRS;
                                $scope.obj.Month = newDataJSON[0].MOS;

                                $scope.obj.t12017.T_DONOR_NTNLTY_ID = newDataJSON[0].T_NTNLTY_ID;
                                $scope.obj.Nationality = newDataJSON[0].NATIONALITY;
                                $scope.obj.Gender = newDataJSON[0].GENDER;
                                $scope.obj.t12017.T_SEX = newDataJSON[0].T_SEX;
                                $scope.obj.MaritalStatus = newDataJSON[0].MRTL_STTS;
                                $scope.obj.LastEpisode = newDataJSON[0].LAST_EPISODE;
                                $scope.obj.UnitNo = newDataJSON[0].T_UNIT_NO;
                                if (newDataJSON[0].T_ARRIVAL_DATE != null) {
                                    var ardate = Date.parse(newDataJSON[0].T_ARRIVAL_DATE);
                                    $scope.obj.LastArrDate = $filter('date')(ardate, "dd-MMM-yyyy");
                                }

                                $scope.obj.LastArrTime = newDataJSON[0].T_ARRIVAL_TIME;
                                if (newDataJSON[0].DIFF_UPTO != null) {
                                    var ddate = Date.parse(newDataJSON[0].DIFF_UPTO);
                                    $scope.obj.DifferedDateUpto = $filter('date')(ddate, "dd-MMM-yyyy");
                                }
                                var img = document.getElementById("btnSign").style;
                                if (newDataJSON[0].DIFF_STTS == null) {
                                    img.background = "url(../Images/buttonWhite.png)";
                                    $scope.obj.DIFF_STTS_SIGN = "Green";
                                }
                                else if (newDataJSON[0].DIFF_STTS === '0') {
                                    img.background = "url(../Images/buttonGreen.png)";
                                }
                                else if (newDataJSON[0].DIFF_STTS === '1') {
                                    img.background = "url(../Images/buttonYellow.png)";
                                }
                                else if (newDataJSON[0].DIFF_STTS === '2') {
                                    img.background = "url(../Images/ButonRed.png)";
                                }
                                img.width = "75px";
                                img.height = "75px";
                                img.backgroundRepeat = "round";
                                img.borderColor = "#FBFBFB";

                                document.getElementById("btnEnterQuery").className = "Button Enter";
                                document.getElementById("txtNationalId").readOnly = true;
                                //document.getElementById("txtDonorNo").readOnly = true;
                                //document.getElementById("txtReasonCode").focus();
                            }
                        });
                    }
                    else {
                        alert('No Data Found');
                        $scope.Clear();
                        document.getElementById("txtDonorNo").focus();
                        return;
                    }

                });
            } else {
                alert('Please Select Patient No or National Id');
                $scope.Clear();
                return;
            }

        }
        function pad(n, pl, pc) {
            var padChar = typeof pc != 'undefined' ? pc : '0';
            var pad = new Array(1 + pl).join(padChar);
            return (pad + n).slice(-pad.length);
        }
        $scope.onPatSrch_tab = function (e) {
            $scope.obj.t12017.T_DONOR_NTNLTY_ID = '';
            if (e.keyCode === 120) {
                $scope.RegPage();
            } else {
                var n = $scope.obj.t12017.T_PAT_NO;
                if (n != null) {
                    var a = pad(n, 8);
                    $scope.obj.t12017.T_PAT_NO = a == '00000000' ? '' : a;
                    if (e.keyCode === 9 || e.keyCode === 13) { LoadwithPreviousData(); }

                }
            }


        }
        $scope.onPatSrch_blur = function () {
            var n = $scope.obj.t12017.T_PAT_NO;
            if (n != null) {
                var a = pad(n, 8);
                $scope.obj.t12017.T_PAT_NO = a == '00000000' ? '' : a;
            }

        }

    }]);