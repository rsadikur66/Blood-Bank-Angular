app.controller("T12201Controller", ["$scope", "T12201Service", "Data", "$window", "$filter",
    function ($scope, T12201Service, Data, $window, $filter) {
        $scope.obj = {};
        
        $scope.obj = Data;
        $scope.obj.t12017 = {};
        $scope.pati = false;
        $scope.complete = {};
        document.getElementById("txtDonorNo").focus();
        $scope.FCode = JSON.parse(sessionStorage.getItem("FCode"));
        $scope.FName = JSON.parse(sessionStorage.getItem("FName"));
        
        $scope.obj.t12017.T_PAT_NO = JSON.parse(sessionStorage.getItem("PatNo"));
        if ($scope.obj.t12017.T_PAT_NO !== null) { LoadwithPreviousData(); }

        $scope.lang = JSON.parse(sessionStorage.getItem("LangName")) == undefined ? 2 : JSON.parse(sessionStorage.getItem("LangName"));

        //-------------------------------------Page Starts---------------------
        $scope.RegPage = function () {
            if ($scope.lang === "2") {
                sessionStorage.setItem("FCode", JSON.stringify("T12214"));
                var name = $scope.lang === '1' ? "تسجيل المانحين" : "Donor Registration";
                sessionStorage.setItem("FName", JSON.stringify(name));
                sessionStorage.setItem("FReqCode", JSON.stringify("T12201"));
                var labelData = T12201Service.GetLabelText("T12214", $scope.lang);
                labelData.then(function (data) {
                    $scope.entity = JSON.parse(data);
                    sessionStorage.setItem("LabelData", JSON.stringify($scope.entity));

                    var hostAddress = $window.location.host;
                    var url = "http://" + hostAddress + $scope.vrDir + "/Transaction/T12214";
                    $window.location.href = url;
                }); 
            } else {
                sessionStorage.setItem("FCode", JSON.stringify("T12213"));
                var nameArb = $scope.lang === '1' ? "تسجيل المانحين" : "Donor Registration";
                sessionStorage.setItem("FName", JSON.stringify(nameArb));
                sessionStorage.setItem("FReqCode", JSON.stringify("T12201"));
                var labelData2 = T12201Service.GetLabelText("T12213", $scope.lang);
                labelData2.then(function (data) {
                    $scope.entity = JSON.parse(data);
                    sessionStorage.setItem("LabelData", JSON.stringify($scope.entity));

                    var hostAddress = $window.location.host;
                    var url = "http://" + hostAddress + $scope.vrDir + "/Transaction/T12213";
                    $window.location.href = url;
                }); 
            }


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
                        var a = $scope.pad(n, 8);
                        $scope.obj.b = a == '00000000' ? '' : a;
                        var singlePat = T12201Service.GetPatientData($scope.obj.b);
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
                    var patData = T12201Service.GetPatientData(p);
                    patData.then(function (data) {
                        if (data.length !== 0) {
                           // document.getElementById('txtpatient').focus();
                            $scope.obj.patList = data;
                            $scope.SearTable = true;
                            $scope.t = undefined;
                           
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
        window.onclick = function() {
            $scope.SearTable = false;
            $scope.AutoSearchTexBox = false;
            if ($scope.t === undefined) {
                $scope.obj.t12017.T_REF_PAT_NO = '';
                $scope.obj.t12017.T_OTHER_PAT_NAME = '';
            } 
             
            $scope.$apply();
        }

        

        $scope.SelectSearchcc_Click = function (slobj) {
            $scope.obj.t12017.T_OTHER_PAT_NAME = slobj.T_OTHER_PAT_NAME;
            $scope.obj.t12017.T_REF_PAT_NO = slobj.T_REF_PAT_NO;
            $scope.SearTable = false;
            $scope.AutoSearchTexBox = false;
            $scope.t = '1';
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
                var reasonList = T12201Service.GetReasonList(ag);
                reasonList.then(function(data) {
                    $scope.reasonList = JSON.parse(data);
                    if ($scope.reasonList.length > 0) {
                        document.getElementById("divReason").style.display = 'block';
                    } else {
                        alert('No Data is available for this aged patient');
                    }
                });
            } else {
                alert($scope.getSingleMsg('N0012'));
                //alert('Please select Patient');
                return;
            }
        }
        $scope.obj.chk = true;
        $scope.getReasonbyCode = function (event, e) {
            if (event.keyCode === 9 || event.keyCode === 13) {
                if (e != null) {
                    var a = parseInt($scope.obj.Year);
                    var m = parseInt($scope.obj.Month)/12;
                    var ag = a + m;
                    var p = $scope.obj.t12017.T_PAT_NO;
                    if (p != null) {
                        var reasonList = T12201Service.GetSingleReason(ag, e);
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
                        alert($scope.getSingleMsg('N0012'));
                        //alert('Please select Patient');
                        return;
                    }
                } else {
                    alert($scope.getSingleMsg('N0063'));
                    //alert('No Code Has been Given');
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

            if ($scope.obj.DEATH_STTS === '1') { alert('Patient is Death'); return;}

            if ($scope.obj.DIFF_STTS === '2') {
                if ($scope.obj.T_VIOROLOGY_RESULT === '2') {
                    alert('Viorology problem');
                } else {
                    alert('This Donor has rejected Permanently for Questionarize problems');
                }
            } else if ($scope.obj.DIFF_STTS === '1') {
                var todate = $filter('date')(new Date(), "dd-MMM-yyyy");
                if (todate === $scope.obj.LastArrDate) {
                    if ($scope.obj.T_REJECT_REASON === null) {
                        if ($scope.obj.T_BLOOD_DONATION_STATUS == null) {
                            alert('This Donor Already Arrived,Go for Questionary; Last Arrival Date: ' + $scope.obj.LastArrDate +'');
                        } else if ($scope.obj.T_BLOOD_DONATION_STATUS === '1'){
                            alert('This Donor Already Arrived and Questionary Completed,Go for Vital Sign; Last Arrival Date: ' + $scope.obj.LastArrDate+'');
                        }
                        else if ($scope.obj.T_BLOOD_DONATION_STATUS === '2') {
                            alert("This Donor Already Arrived and Vital Sign Completed,Go for Donation Process; Last Arrival Date: "+ $scope.obj.LastArrDate+"");
                        }
                        else if ($scope.obj.T_BLOOD_DONATION_STATUS === '3') {
                            alert("This Donor Already Arrived and Donation Completed; Last  Arrival Date:" + $scope.obj.LastArrDate +"");
                        }
                    } else {
                        alert("This Donor Already Arrived and Patient has vital sign problem");
                       // alert($scope.obj.T_REJECT_REASON);
                    }
                    
                } else {
                   // alert("Saveable");
                    save();
                }
                return;
            } else if ($scope.obj.DIFF_STTS === '0') {

                var todateGreen = $filter('date')(new Date(), "dd-MMM-yyyy");
                if (todateGreen === $scope.obj.LastArrDate) {

                if ($scope.obj.T_BLOOD_DONATION_STATUS == null) {
                    alert('This Donor Already Arrived,Go for Questionary; Last Arrival Date: ' + $scope.obj.LastArrDate + '');
                } else if ($scope.obj.T_BLOOD_DONATION_STATUS === '1') {
                    alert('This Donor Already Arrived and Questionary Completed,Go for Vital Sign; Last Arrival Date: ' + $scope.obj.LastArrDate + '');
                }
                else if ($scope.obj.T_BLOOD_DONATION_STATUS === '2') {
                    alert("This Donor Already Arrived and Vital Sign Completed,Go for Donation Process; Last Arrival Date: " + $scope.obj.LastArrDate + "");
                }
                else if ($scope.obj.T_BLOOD_DONATION_STATUS === '3') {
                    alert("This Donor Already Arrived and Donation Completed; Last  Arrival Date:" + $scope.obj.LastArrDate +"");
                }
                
              }
                else {
                
                    var apheresis = T12201Service.chekApheresis($scope.obj.t12017.T_PAT_NO, $scope.obj.LastEpisode);
                    apheresis.then(function (data) {
                        var jsonData = JSON.parse(data);
                        var date = $filter('date')(jsonData[0].T_DONATION_DATE, "dd-MMM-yyyy");
                        if (jsonData[0].NEXT_DAYS === 0) {
                            save();
                        } else if (jsonData[0].NEXT_DAYS > 0) {
                            var afterDays = jsonData[0].NEXT_DAYS;
                            alert('Apheresis Donation ' + jsonData[0].PLT_PLA_RBC + '. This Patient is not eligible, come after ' + afterDays + ' Days, your last Donation date is  ' + date + '');
                        } else {
                            if (jsonData[0].COUNT_DATE >= 57) {
                                save();
                            } else {
                                var nextdate = $filter('date')(jsonData[0].NEXT_DATE, "dd-MMM-yyyy");
                                var con = 57 - jsonData[0].COUNT_DATE;
                                alert('This Patient is not eligible,Next Donation Date ' + nextdate + ', come after ' + con + ' Days, your last Donation date is  ' + date + '');
                                // alert('This Patient is not eligible, come after ' + con + ' Days your last Donation date is  ' + date +'');
                            }
                        }

                    });
                }



               
               
            } else {
                //alert("Saveable");
                 save();
            }

           


        }
        function save() {
            var la = $scope.obj.LastArrDate;
            var ca = $scope.obj.T_ARRIVAL_DATE;
            var u = $scope.obj.UnitNo;
            var e = $scope.obj.LastEpisode;
            var dt = $filter('date')(new Date($scope.obj.T_HAMLA_DATE), "dd-MMM-yyyy");


            if ($scope.obj.T_HAMLA_STTS == "1" && ca == dt) { alert('Donor Already Arrived for Hamla. Arrival Date : ' + dt); return; }
            if (la == ca) { alert('This Donor Already Arrived,Go for Questionary; Arrival Date: ' + $scope.obj.LastArrDate +''); return; }
            //if (u == null && e > 0) { alert('Previous Episode not completed yet'); return; }

            var insert = T12201Service.insert($scope.obj.t12017);
            $scope.loader(true);
            insert.then(function (data) {
                $scope.loader(false);
                alert(data);
                pdfPrint();
                $scope.Clear();
                document.getElementById("txtDonorNo").focus();
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
            //T12201Service.GetReport($scope.obj.t12017.T_PAT_NO, $scope.obj.PatName);

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
            $scope.loader(true);
            var p = $scope.obj.t12017.T_PAT_NO;
            var n = $scope.obj.t12017.T_DONOR_NTNLTY_ID;
            if (p !== '' || n !== '') {
                $scope.req = T12201Service.CheckDonor(p, n);
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
                        var reasonList = T12201Service.GetSingleReason(ag, null);
                        reasonList.then(function (data) {
                            $scope.loader(false);
                            if (JSON.parse(data).length == 0) {
                                alert('Donor Cancelled due to invalid age');
                                return;
                            } else {

                                var lastArrival = $filter('date')(Date.parse(newDataJSON[0].T_ARRIVAL_DATE), "dd-MMM-yyyy");
                                var today = $filter('date')(new Date(), "dd-MMM-yyyy");
                                if (lastArrival === today) {
                                    alert('This Donor Already Arrived,Go for Questionary');
                                    document.getElementById("txtDonorNo").focus();
                                    $scope.Clear();
                                    return;
                                }

                                $scope.obj.t12017.T_PAT_NO = newDataJSON[0].T_PAT_NO;
                                $scope.obj.PatName = newDataJSON[0].PAT_NAME;
                                $scope.obj.Year = newDataJSON[0].YRS;
                                $scope.obj.Month = newDataJSON[0].MOS;
                                $scope.obj.T_HAMLA_STTS = newDataJSON[0].T_HAMLA_STTS;
                                $scope.obj.T_HAMLA_DATE = newDataJSON[0].T_HAMLA_DATE;

                                $scope.obj.t12017.T_DONOR_NTNLTY_ID = newDataJSON[0].T_NTNLTY_ID;
                                $scope.obj.Nationality = newDataJSON[0].NATIONALITY;
                                $scope.obj.Gender = newDataJSON[0].GENDER;
                                $scope.obj.MaritalStatus = newDataJSON[0].MRTL_STTS;
                                $scope.obj.LastEpisode = newDataJSON[0].LAST_EPISODE;
                                $scope.obj.UnitNo = newDataJSON[0].T_UNIT_NO;
                                //-------- 
                                $scope.obj.T_REJECT_REASON = newDataJSON[0].T_REJECT_REASON;
                                $scope.obj.T_VIOROLOGY_RESULT = newDataJSON[0].T_VIOROLOGY_RESULT;
                                $scope.obj.DIFF_STTS = newDataJSON[0].DIFF_STTS;
                                $scope.obj.DEATH_STTS = newDataJSON[0].DEATH_STTS;
                                $scope.obj.T_BLOOD_DONATION_STATUS = newDataJSON[0].T_BLOOD_DONATION_STATUS;

                                if (newDataJSON[0].T_ARRIVAL_DATE != null) {
                                    var ardate = Date.parse(newDataJSON[0].T_ARRIVAL_DATE);
                                    $scope.obj.LastArrDate = $filter('date')(ardate, "dd-MMM-yyyy");
                                } else {
                                    $scope.obj.LastArrDate = '';
                                }

                                $scope.obj.LastArrTime = newDataJSON[0].T_ARRIVAL_TIME;
                                if (newDataJSON[0].DIFF_UPTO != null) {
                                    var ddate = Date.parse(newDataJSON[0].DIFF_UPTO);
                                    $scope.obj.DifferedDateUpto = $filter('date')(ddate, "dd-MMM-yyyy");
                                } else {
                                    $scope.obj.DifferedDateUpto = '';
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
        
        $scope.onPatSrch_tab = function (e) {
           // $scope.obj.t12017.T_DONOR_NTNLTY_ID = '';
            if (e.keyCode === 120) {
                $scope.RegPage();
            } else if (e.keyCode === 9 || e.keyCode === 13){
                var n = $scope.obj.t12017.T_PAT_NO;
                $scope.obj.t12017.T_DONOR_NTNLTY_ID = '';
                if (n != null) {
                    var a = $scope.pad(n,8);
                    $scope.obj.t12017.T_PAT_NO = a == '00000000' ? '' : a;
                    if (e.keyCode === 9 || e.keyCode === 13) { LoadwithPreviousData(); }

                }
            }


        }
        $scope.onPatSrch_blur = function () {

           
            var n = $scope.obj.t12017.T_PAT_NO;
            $scope.obj.t12017.T_DONOR_NTNLTY_ID = '';
            if (n != null) {
                var a = $scope.pad(n, 8);
                $scope.obj.t12017.T_PAT_NO = a == '00000000' ? '' : a;
                LoadwithPreviousData();
            }

        }

    }]);