
app.controller("T12204Controller", ["$scope","$timeout", "$filter", "T12204Service", "Data", "LabelService","$window",
    function (scope, $timeout, $filter, T12204Service, Data, LabelService, $window) {
        scope.obj = {};
        scope.obj = Data;
        scope.obj.T12075 = {};
        scope.obj.T12071 = {};
        scope.obj.T12022 = {};
        scope.obj.P_REQUEST_ID = {};
        scope.obj.P_REQUEST_ID.id = '';
        document.getElementById("txtPatNo").focus();
// scope.EmpDes = {};
        scope.obj.Unit = "";
        scope.obj.PatNo = "";
        scope.obj.NationalID = "";
        scope.obj.Beg = "";
       
        scope.entity = JSON.parse(sessionStorage.getItem("LabelData"));
        var lang = sessionStorage.LangName;
        var lan = lang.split("")[1];
        //----------Tab Toggling--------------start
        if (lan==="2") {
            scope.tabs = [
                { title: 'Unit Details', url: 'tabUnitDetails.tpl.html', hin: 'Unit' },
                { title: 'Vital Sign', url: 'tabVitalSign.tpl.html', hin: 'Vital' }
                // { title: 'Bill', url: 'tabBill.tpl.html', hin: 'BILL' }
            ];
            scope.Text_Aling = 'left';
            
        } else if (lan === "1") {
            scope.tabs = [
                { title: 'تفاصيل الوحدة', url: 'tabUnitDetails.tpl.html', hin: 'Unit' },
                { title: 'علامة حيوية', url: 'tabVitalSign.tpl.html', hin: 'Vital' }
                // { title: 'Bill', url: 'tabBill.tpl.html', hin: 'BILL' }
            ];
            scope.Text_Aling = 'right';
        }
        
        var param = JSON.parse(sessionStorage.getItem("param"));
        if (param === null) {
            scope.obj.Hidenfield = 'Unit';
            scope.currentTab = 'tabUnitDetails.tpl.html';

        } else {
            scope.obj.Hidenfield = param.hin;
            scope.currentTab = param.url;
            scope.bill();

        }
        scope.onClickTab = function(tab) {

            scope.obj.Hidenfield = tab.hin;
            scope.currentTab = tab.url;
            //if (tab.hin == 'BILL') {

            //    scope.bill();
            //}

        };
        scope.isActiveTab = function(tabUrl) { return tabUrl === scope.currentTab; }
        //----------Tab Toggling--------------End
       
        //scope.lang = JSON.parse(sessionStorage.getItem("LangName")) == undefined ? 2 : JSON.parse(sessionStorage.getItem("LangName"));
        //scope.FCode = JSON.parse(sessionStorage.getItem("FCode"));
        //var labelData = LabelService.GetLabelText(scope.FCode, scope.lang);
        //labelData.then(function (data) {
        //    var newDataJSON = JSON.parse(data);
        //    scope.entity = newDataJSON;
        //});
        //var lebalData = T12204Service.getLebalData(scope.lang, scope.FCode);
        //lebalData.then(function(data) {
        //    scope.entity = JSON.parse(data);
        //});
        var ptientNo = "";
        var sms = "";
        scope.enterKey = function(event, patNo, patId) {
            if (event.keyCode === 114) {
                event.preventDefault();
                alert("F9");
            }
        }
        //scope.enterKey = function (event, patNo, patId) {
        //    if (event.keyCode === 13) {
        //        if (patNo === "" && patId === "") {
        //            return;
        //        }
        //        if (scope.obj.T12071.T_DONOR_PATNO.length > 7 || scope.obj.T12071.T_NTNLTY_ID.length > 9) {
        //            if (scope.obj.patNo === undefined) {
        //                scope.obj.patNo = '';
        //            }
        //            if (scope.obj.patNaId === undefined) {
        //                scope.obj.patNaId = '';
        //            }
        //            if (scope.obj.patNo !== patNo) {
        //                patId = '';
        //            } else if (scope.obj.patNaId !== patId) {
        //                patNo = '';
        //            }
        //            if ((patId === '' && patNo !== '') || (patId !== '' && patNo === '')) {
        //                patientInformation(patNo, patId);
        //            }
        //        } else {

        //            if (sms === "") {
        //                alert('ID is not valid !!');
        //                sms = "1";
        //            }

        //        }
        //    } else if (event.keyCode === 9) {
        //        scope.obj.T12071.T_DONOR_PATNO = formatted_string('00000000', patNo, '1');
        //        ptientNo = scope.obj.T12071.T_DONOR_PATNO;

        //        if (ptientNo.length > 7 || scope.obj.T12071.T_NTNLTY_ID.length > 9) {
        //            if (scope.obj.patNo === undefined) {
        //                scope.obj.patNo = '';
        //            }
        //            if (scope.obj.patNaId === undefined) {
        //                scope.obj.patNaId = '';
        //            }
        //            if (scope.obj.patNo !== patNo) {
        //                NatId = '';
        //            } else if (scope.obj.patNaId !== NatId) {
        //                patNo = '';
        //            }
        //            if ((NatId === '' && patNo !== '') || (NatId !== '' && patNo === '')) {
        //                patientInformation(ptientNo, NatId);
        //            }
        //        } else {
        //            if (sms === "") {
        //                alert('ID is not valid !!');
        //                sms = "1";
        //            }


        //        }
        //    }
        //};
       
        scope.Patient_Click = function (event,patNo, NatId) {
           
            //if (patNo === "" && NatId==="") {
            //    return;
            //}
            if (event.keyCode === 9) {
                scope.obj.T12071.T_DONOR_PATNO = formatted_string('00000000', patNo, '1');
                ptientNo = scope.obj.T12071.T_DONOR_PATNO;


                if (ptientNo.length > 7 || scope.obj.T12071.T_NTNLTY_ID.length > 9) {
                    if (scope.obj.patNo === undefined) {
                        scope.obj.patNo = '';
                    }
                    if (scope.obj.patNaId === undefined) {
                        scope.obj.patNaId = '';
                    }
                    if (scope.obj.patNo !== patNo) {
                        NatId = '';
                    } else if (scope.obj.patNaId !== NatId) {
                        patNo = '';
                    }
                    if ((NatId === '' && patNo !== '') || (NatId !== '' && patNo === '')) {
                        patientInformation(ptientNo, NatId);
                    }
                } else {
                    if (sms === "") {
                        alert('ID is not valid !!');
                        sms = "1";
                    }
                }
            } else if (event.keyCode === 13) {
                scope.obj.T12071.T_DONOR_PATNO = formatted_string('00000000', patNo, '1');
                ptientNo = scope.obj.T12071.T_DONOR_PATNO;


                if (ptientNo.length > 7 || scope.obj.T12071.T_NTNLTY_ID.length > 9) {
                    if (scope.obj.patNo === undefined) {
                        scope.obj.patNo = '';
                    }
                    if (scope.obj.patNaId === undefined) {
                        scope.obj.patNaId = '';
                    }
                    if (scope.obj.patNo !== patNo) {
                        NatId = '';
                    } else if (scope.obj.patNaId !== NatId) {
                        patNo = '';
                    }
                    if ((NatId === '' && patNo !== '') || (NatId !== '' && patNo === '')) {
                        patientInformation(ptientNo, NatId);
                        
                    }
                } else {
                    if (sms === "") {
                        alert('ID is not valid !!');
                        sms = "1";
                    }
                }
            } else if (event.keyCode === 114) {
               // document.getElementById("txtSegmentNo").focus();
                next();
            }
           
        }
        //----- for Lpading of patient id ---------
        function formatted_string(pad, user_str, pad_pos) {
            if (typeof user_str === 'undefined')
                return pad;
            if (pad_pos == "1") {
                return (pad + user_str).slice(-pad.length);
            }
            else {
                return (user_str + pad).substring(0, pad.length);
            }
        }

        function patientInformation(patNo, patId) {
           // var pat = patNo;
           var patDetails = T12204Service.getPatDetails(patNo, patId);
            patDetails.then(function (data) {
                var jsondata = JSON.parse(data);
                if (jsondata.length !== 0) {
                    scope.obj.T12071.T_DONOR_PATNO = jsondata[0].T_DONOR_PATNO;
                scope.obj.T12071.PAT_NAME = jsondata[0].PAT_NAME;
                scope.obj.T12071.GENDER = jsondata[0].GENDER;
                scope.obj.T12071.T_NTNLTY_ID = jsondata[0].T_NTNLTY_ID;
                scope.obj.T12071.NATIONALITY = jsondata[0].NATIONALITY;
                scope.obj.T12071.YRS = jsondata[0].YRS;
                scope.obj.T12071.MOS = jsondata[0].MOS;
                scope.obj.T12071.MAX_EPISODE = jsondata[0].MAX_EPISODE;
                scope.obj.T12071.T_DIFFERAL_DAY = jsondata[0].T_DIFFERAL_DAY;
                scope.obj.T12071.REJ_NAME = jsondata[0].REJ_NAME;
                scope.obj.T12022.T_ACCEPT_STATUS = jsondata[0].T_ACCEPT_STATUS;
                scope.obj.patNo = jsondata[0].T_DONOR_PATNO;
                scope.obj.patNaId = jsondata[0].T_NTNLTY_ID;
                scope.obj.T_BLOOD_DONATION_STATUS = jsondata[0].T_BLOOD_DONATION_STATUS;
                    scope.obj.T_REQUEST_ID = jsondata[0].T_REQUEST_ID;
               // scope.obj.T12071.DifferedUpTo = diffUpTo(jsondata[0].T_DIFFERAL_DAY);
                var diffDay = Date.parse(jsondata[0].DIFF_UPTO);
                scope.obj.T12071.DifferedUpTo = $filter('date')(diffDay, "dd-MMM-yyyy");

                    var image = T12204Service.getImages(scope.obj.T12071.T_DONOR_PATNO, jsondata[0].MAX_EPISODE);
                image.then(function (img) {
                    var jsondata = JSON.parse(img);
                    if (jsondata[0].T_STATUS === 'red') {
                        scope.obj.Images = "../Images/ButonRed.png";
                        scope.obj.T12022.T_imagStatus = "Red";
                        scope.obj.T12071.DiffStatus = "Red";
                    } else if (jsondata[0].T_STATUS === 'yellow') {
                        scope.obj.Images = "../Images/buttonYellow.png";
                        scope.obj.T12022.T_imagStatus = "Yellow";
                        scope.obj.T12071.DiffStatus = "Yellow";
                    } else {
                        scope.obj.Images = "../Images/buttonGreen.png";
                        scope.obj.T12022.T_imagStatus = "Green";
                        scope.obj.T12071.DiffStatus = "Green";
                    }
                   
                });


                    var bodyMermt = T12204Service.getbodyMermt(scope.obj.T12071.T_DONOR_PATNO, jsondata[0].MAX_EPISODE);
                bodyMermt.then(function (contain) {
                    var jsondata = JSON.parse(contain);
                    scope.obj.Body_WEIGHT = jsondata[0].T_WEIGHT;
                    scope.obj.T_HB = jsondata[0].T_HB;
                    scope.obj.T_PULS = jsondata[0].T_PULS;
                    scope.obj.T_TEMPTURE = jsondata[0].T_TEMPTURE;
                    scope.obj.T_BP_HIGH = jsondata[0].T_BP_HIGH;
                    scope.obj.T_BP_LOW = jsondata[0].T_BP_LOW;
                });
                    var question = T12204Service.getQuestion(scope.obj.T12071.T_DONOR_PATNO, jsondata[0].MAX_EPISODE);
                question.then(function (qus) {
                    var qList = [];
                    var quesList = JSON.parse(qus);
                    for (var i = 0; i < quesList.length; i++) {

                        var temp = {};
                        temp.a = {};
                        temp.QUES_DESC = quesList[i].QUES_DESC;
                        temp.T_DIFFERAL_DAY_TEMP = quesList[i].T_DIFFERAL_DAY;
                        temp.T_IF_FAIL = quesList[i].T_IF_FAIL;
                        temp.T_QNO = quesList[i].T_QNO;
                        temp.T_QNO_ANS = quesList[i].T_QNO_ANS;
                        temp.T_EXP_ANS = quesList[i].T_EXP_ANS;

                        if (temp.T_QNO_ANS === "1") {
                            temp.a.selected = { ANS_ID: 1, ANS_DESC: 'Yes' };
                            temp.getAnsList = [{ ANS_ID: 1, ANS_DESC: 'Yes' }, { ANS_ID: 2, ANS_DESC: 'No' }];
                        }
                        else if (temp.T_QNO_ANS === "2") {
                            temp.a.selected = { ANS_ID: 2, ANS_DESC: 'No' };
                            temp.getAnsList = [{ ANS_ID: 1, ANS_DESC: 'Yes' }, { ANS_ID: 2, ANS_DESC: 'No' }];
                        }

                        if (temp.T_QNO_ANS === temp.T_EXP_ANS) {
                            temp.src = "../../Images/buttonGreen.png";
                            temp.T_DIFFERAL_DAY = 0;
                        }
                        else if (temp.T_QNO_ANS !== temp.T_EXP_ANS) {
                            if (temp.T_IF_FAIL === "1") {
                                temp.src = "../../Images/buttonYellow.png";
                                temp.T_DIFFERAL_DAY = quesList[i].T_DIFFERAL_DAY;
                            }
                            else if (temp.T_IF_FAIL === "2") {
                                temp.src = "../../Images/ButonRed.png";
                                temp.T_DIFFERAL_DAY = 0;
                            }
                        }

                        qList.push(temp);


                    }
                    //$scope.obj.quesList = qList;
                    scope.obj.quesList = qList;
                    });
                    document.getElementById("txtPatNo").focus();
                } else {
                    //if (sms === "") {
                        
                    //    sms = "1";
                    //}
                    alert("Patient is not available");
                    scope.obj.T12071.PAT_NAME = "";
                    scope.obj.T12071.GENDER = "";
                    scope.obj.T12071.T_NTNLTY_ID = "";
                    scope.obj.T12071.NATIONALITY = "";
                    scope.obj.T12071.YRS = "";
                    scope.obj.T12071.MOS = "";
                    scope.obj.T12071.MAX_EPISODE = "";
                    scope.obj.T12071.T_DIFFERAL_DAY = "";
                    scope.obj.T12071.REJ_NAME = "";
                    // scope.obj.T12071.DifferedUpTo = diffUpTo(jsondata[0].T_DIFFERAL_DAY);
                    //var diffDay = Date.parse(jsondata[0].DIFF_UPTO);
                    scope.obj.T12071.DifferedUpTo = "";
                    scope.obj.Body_WEIGHT = "";
                    scope.obj.T_HB = "";
                    scope.obj.T_PULS = "";
                    scope.obj.T_TEMPTURE = "";
                    scope.obj.T_BP = "";
                    scope.obj.Images = "../../Images/Buton.png";
                    scope.obj.quesList = [];
                    scope.obj.patNo = '';
                    scope.obj.patNaId = '';
                }
             });//---
        
        }
        //------ Save start -------------
        scope.obj.saveStatus = '1';
        scope.Save_Click = function () {
            if (scope.obj.T_BLOOD_DONATION_STATUS ==='2') {
            
            if (scope.obj.saveStatus === '1') {

                if (scope.obj.T12022.T_ACCEPT_STATUS === '1') {

                    if (scope.obj.T12022.T_imagStatus === "Green") {
                        if (scope.obj.T12022.T_SEGMENT_NO === ""||scope.obj.T12022.T_SEGMENT_NO ===undefined) {
                            alert("Fill up Segment No first !!");
                            document.getElementById("txtSegmentNo").focus();
                        } else {
                        document.getElementById("verificatonPopUp").style.display = "block";
                        var unitNo = T12204Service.getUnit_SegmNo();
                        unitNo.then(function (unit) {
                            var jsondata = JSON.parse(unit);
                           // scope.obj.T12022.T_UNIT_NO = jsondata[0].T_UNIT_NO;
                            scope.obj.unitNohidden = jsondata[0].T_UNIT_NO;
                            scope.obj.T12022.T_SEQ_NO = jsondata[0].T_SEQ_NO;

                        });

                        var bldStoreId = T12204Service.getMaxBidStoreId();
                        bldStoreId.then(function (bld) {
                            var jsondata = JSON.parse(bld);
                            scope.obj.T12022.T_BLD_STORE_ID = jsondata[0].T_BLD_STORE_ID;
                        });
                      }


                    } else {
                        alert("Patient is unable for blood donation !!!!");
                    }

                } else {
                    if (scope.obj.T12022.T_imagStatus === "Yellow") {
                        alert("You are temporarily defer");
                    } else if (scope.obj.T12022.T_imagStatus === "Red") {
                        alert("You are permanently defer");
                    } else {
                        var smsWeight = "";
                        var smsHb = "";
                        var smsPuls = "";
                        var smsTemp = "";
                        var smsBpH = "";
                        var smsBlLo = "";
                        var bodyWeight = scope.obj.Body_WEIGHT;
                        if (bodyWeight >= 50 && bodyWeight <= 300) { } else {
                            smsWeight = "# Your weight is not perfect for Blood donation,";
                        }
                        var hb = scope.obj.T_HB;
                        if (hb >= 12.5 && hb <= 18) { } else {
                            smsHb = "# Your Hemoglobin is not perfect for Blood donation,";
                        }
                        var puls = scope.obj.T_PULS;
                        if (puls >= 50 && puls <= 100) { } else {
                            smsPuls = "# Your puls is not perfect for Blood donation,";
                        }
                        var temp = scope.obj.T_TEMPTURE;
                        if (temp >= 36 && temp <= 40) { } else {
                            smsTemp = "# Your temperature is not perfect for Blood donation,";
                        }
                        var bpHigh = scope.obj.T_BP_HIGH;
                        if (bpHigh >= 100 && bpHigh <= 180) { } else {
                            smsBpH = "# Your blood pressure is so heigh,";
                        }
                        var bpLow = scope.obj.T_BP_LOW;
                        if (bpLow >= 60 && bpLow <= 100) { } else {
                            smsBlLo = "# Your blood pressure is so low,";
                        }
                        if (smsWeight === "" && smsHb === "" && smsPuls === "" && smsTemp === "" && smsBpH === "" && smsBlLo === "") {
                            alert("You are temporarily defer");
                        } else {
                            alert(smsWeight + "\n" + smsHb + "\n" + smsPuls + "\n" + smsTemp + "\n" + smsBpH + "\n" + smsBlLo);
                        }
                    }
                    
                   
                    // alert("1,Patient has vital sign problems \n heart Problems \n Leg problems");
                }

               
            } else if (scope.obj.saveStatus === '2') {

                scope.obj.T12022.T_DONOR_PATNO = scope.obj.T12071.T_DONOR_PATNO;
                scope.obj.T12022.MAX_EPISODE = scope.obj.T12071.MAX_EPISODE;
                scope.obj.T12022.T_BLOOD_DONATION_STATUS = '3';
                if (scope.obj.T12022.T_LOT_EXPIRY !== undefined && scope.obj.T12022.T_LOT_EXPIRY !== '' && scope.obj.T12022.T_LOT_EXPIRY !== null) {
                    scope.obj.T12022.T_LOT_EXPIRY = scope.dateParse(scope.obj.T12022.T_LOT_EXPIRY, "/");
                    scope.obj.T12022.T_ACD_EXPIRY = scope.dateParse(scope.obj.T12022.T_ACD_EXPIRY, "/");
                    // var lotExDate = $filter('date')(scope.obj.T12022.T_LOT_EXPIRY, "dd/MMM/yyyy");
                    //scope.obj.T12022.T_LOT_EXPIRY = lotExDate;
                    // var acdExDate = $filter('date')(scope.obj.T12022.T_ACD_EXPIRY, "dd/MMM/yyyy");
                    //scope.obj.T12022.T_ACD_EXPIRY = acdExDate;
                }
                if (scope.obj.T12022.Phebotomy === null || scope.obj.T12022.Phebotomy === '' || scope.obj.T12022.T_BAG_WEIGHT === null || scope.obj.T12022.T_BAG_WEIGHT === '') {
                    alert('Please fill up all information  ');
                    return;
                }
                var update = T12204Service.update(scope.obj.T12022);
                update.then(function (up) {
                    alert(up);
                    scope.obj.saveStatus = '1';
                    scope.obj.T12022 = {};
                    scope.obj.T12071 = {};
                    scope.obj.T_BED_NAME_LANG2 = '';
                    scope.obj.T_LANG_NAME = '';
                    scope.obj.quesList = '';
                    scope.obj.T_BP_HIGH = '';
                    scope.obj.T_BP_LOW = '';
                    scope.obj.T_TEMPTURE = '';
                    scope.obj.T_PULS = '';
                    scope.obj.T_HB = '';
                    scope.obj.Body_WEIGHT = '';
                    scope.obj.Images = "../../Images/Buton.png";
                    scope.obj.patNo = '';
                    scope.obj.patNaId = '';
                });
            } else if (scope.obj.saveStatus === '0') {
                alert("You are not able to Save data because Unit No is not generate newly");
            }
          } else {
                alert('First you complete Donor Screening');

                scope.obj.saveStatus = '1';
                scope.obj.T12022 = {};
                scope.obj.T12071 = {};
                scope.obj.T_BED_NAME_LANG2 = '';
                scope.obj.T_LANG_NAME = '';
                scope.obj.quesList = '';
                scope.obj.T_BP_HIGH = '';
                scope.obj.T_BP_LOW = '';
                scope.obj.T_TEMPTURE = '';
                scope.obj.T_PULS = '';
                scope.obj.T_HB = '';
                scope.obj.Body_WEIGHT = '';
                scope.obj.Images = "../../Images/Buton.png";
                scope.obj.patNo = '';
                scope.obj.patNaId = '';
            }
           
           
        }
        scope.Ok_Click = function() {
            var pinno = T12204Service.getpin();
            pinno.then(function(vepin) {
                var jsondata = JSON.parse(vepin);
                if (jsondata[0].T_PIN === parseInt(scope.obj.T12022.T_PIN) && scope.obj.T12022.T_SEGMENT_NO !== undefined) {
                    scope.obj.T12022.T_DONOR_PATNO = scope.obj.T12071.T_DONOR_PATNO;
                    scope.obj.T12022.MAX_EPISODE = scope.obj.T12071.MAX_EPISODE;
                    scope.obj.T12022.T_UNIT_NO = scope.obj.unitNohidden;
                    scope.obj.T12022.T_BLOOD_DONATION_STATUS = '3';
                    scope.obj.T12022.T_REQUEST_ID = scope.obj.T_REQUEST_ID;
                    //-------- for Bar code start -----------
                    var date = new Date();
                    var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
                    var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
                    var patid = scope.obj.T12071.T_DONOR_PATNO;
                    var epsort = scope.obj.T12071.MAX_EPISODE;
                   // var unino=scope.obj.T12022.T_UNIT_NO;
                    var unino=scope.obj.unitNohidden;
                    var seno = scope.obj.T12022.T_SEQ_NO;
                    var hou_min = hours + ':' + minutes;
                    var filterDate = $filter('date')(date, "dd/MM/yyyy");
                    scope.obj.T12022.T_HOUR_MIN = hou_min;
                    scope.obj.T12022.T_DATE = filterDate;
                    scope.obj.T12022.T_BAG_BARCODE = unino;
                    //-------- for Bar code end -----------
                    var save = T12204Service.SaveData(scope.obj.T12022);
                    save.then(function (savData) {
                        if (savData == '"Save Successfully"') {
                            scope.obj.saveStatus = '2';
                            scope.obj.T12022.T_UNIT_NO = scope.obj.unitNohidden;
                            //var input = [];
                            //var total = 10;
                            //for (var i = 0; i < total; i++) {
                            //    input.push(i);
                            //    $window.open("../Report12204/GetReport?patid=" + patid + "&&epsort=" + epsort, "popup", "width=600,height=600,left=100,top=50");
                            //}

                            $window.open("../Report12204/GetReport?patid=" + patid + "&&epsort=" + epsort, "popup", "width=600,height=600,left=100,top=50");
                        }
                        document.getElementById("verificatonPopUp").style.display = "none";
                    });

                    //var dd = scope.obj.T12022;
                   // var ddrr = scope.obj.T12071;
                } else {
                    alert("Pin number is not valid and Segment is null !!!");
                }
            });


        }

        //------ Save end -------------

        scope.Next_Click = function() {
            next();
           
        };
        function next() {
            var patNo = scope.obj.T12071.T_DONOR_PATNO;
            var epsort = scope.obj.T12071.MAX_EPISODE;

            var show = T12204Service.showDataFromT12022(patNo, epsort);
            show.then(function (sw) {
                var jsondata = JSON.parse(sw);
                if (jsondata.length !== 0) {
                   // scope.obj.T12022 = [];
                    scope.obj.T12022.T_UNIT_NO = jsondata[0].T_UNIT_NO;
                    scope.obj.T12022.T_SEGMENT_NO = jsondata[0].T_SEGMENT_NO;
                    
                    scope.obj.T12022.ChkGenlApp = jsondata[0].T_GENERAL_APP_CHECK_YN;
                    scope.obj.T12022.ChkbxDHQ = jsondata[0].T_DHQ_CHECK_YN;
                    scope.obj.T12022.ChkbxLetArm = jsondata[0].T_LEFT_ARM_CHECK_YN;
                    scope.obj.T12022.ChkbxRightArm = jsondata[0].T_RIGHT_ARM_CHECK_YN;
                    scope.obj.T12022.ChkbxBag = jsondata[0].T_BAG_CHECK_YN;
                    scope.obj.T12022.ChkAPheresis = jsondata[0].T_APHERESIS;
                    scope.obj.T12022.ChkPLT = jsondata[0].T_PLT;
                    scope.obj.T12022.ChkRBCS = jsondata[0].T_RBCS;
                    scope.obj.T12022.ChkPlasma = jsondata[0].T_PLSMA;
                    scope.obj.T12022.DonationStartTime = jsondata[0].T_DONATION_START_TIME;
                    scope.obj.T12022.DonationEndTime = jsondata[0].T_DONATION_END_TIME;

                    scope.obj.T12022.T_BED_CODE = jsondata[0].T_BED_NO;
                    scope.obj.T_BED_NAME_LANG2 = jsondata[0].T_BED_NAME_LANG2;
                    scope.obj.T12022.T_COMMENTS = jsondata[0].T_COMMENTS;
                    scope.obj.T12022.T_BAG_WEIGHT = jsondata[0].T_BAG_WEIGHT;
                    scope.obj.T12022.CancelReason = jsondata[0].T_CANCEL_REASON;
                    scope.obj.T12022.UINT_ACCEPT_STATUS = jsondata[0].UNIT_ACCEPT_STATUS;
                    scope.obj.T12022.T_ACTION = jsondata[0].T_UNIT_ACCEPT_STATUS;
                    scope.obj.T12022.DISCARD_REASON_CODE = jsondata[0].DISCARD_REASON_CODE;
                    scope.obj.T_LANG_NAME = jsondata[0].DISCAD_NAME;
                    scope.obj.T12022.Marks = jsondata[0].T_REMARKS;

                    scope.obj.T12022.T_TACD_USED = jsondata[0].T_TACD_USED;
                    scope.obj.T12022.T_ER_TIME = jsondata[0].T_ER_TIME;
                    scope.obj.T12022.T_LR_TIME = jsondata[0].T_LR_TIME;
                    scope.obj.T12022.T_POST_PLT = jsondata[0].T_POST_PLT;
                    scope.obj.T12022.T_POST_HCT = jsondata[0].T_POST_HCT;
                    scope.obj.T12022.T_AACD_DONOR = jsondata[0].T_AACD_DONOR;
                    scope.obj.T12022.T_BLOOD_PROCESSED = jsondata[0].T_BLOOD_PROCESSED;
                    scope.obj.T12022.T_TSAL_USED = jsondata[0].T_TSAL_USED;
                    scope.obj.T12022.T_KIT_LOT = jsondata[0].T_KIT_LOT;
                    if (jsondata[0].T_LOT_EXPIRY !== "") {
                        scope.obj.T12022.T_LOT_EXPIRY = $filter('date')(jsondata[0].T_LOT_EXPIRY, "dd/MM/yyyy");
                        scope.obj.T12022.T_ACD_EXPIRY = $filter('date')(jsondata[0].T_ACD_EXPIRY, "dd/MM/yyyy");
                    }
                    scope.obj.T12022.T_ACD_LOT = jsondata[0].T_ACD_LOT;
                    scope.obj.T12022.T_PLT_M_V = jsondata[0].T_PLT_M_V;
                    scope.obj.T12022.T_YLD_PLT = jsondata[0].T_YLD_PLT;
                    scope.obj.T12022.T_ACD_PLT_V = jsondata[0].T_ACD_PLT_V;
                    scope.obj.T12022.T_PLSMA_M_V = jsondata[0].T_PLSMA_M_V;
                    scope.obj.T12022.T_ACD_V_PLASMA = jsondata[0].T_ACD_V_PLASMA;
                    scope.obj.T12022.T_RBCS_M_V = jsondata[0].T_RBCS_M_V;
                    scope.obj.T12022.T_ACD_V_RBC = jsondata[0].T_ACD_V_RBC;
                    scope.obj.T12022.T_HTC_RBC = jsondata[0].T_HTC_RBC;
                    scope.obj.T12022.T_COMPLETE = jsondata[0].T_COMPLETE;
                    scope.obj.T12022.Phebotomy = jsondata[0].T_PHLEBOTOMY;
                    if (jsondata[0].T_DONATION_COMPLETION_STATUS !== null) {
                        readOnly();
                    }
                    scope.obj.completeIdForBagUsed = jsondata[0].T_DONATION_COMPLETION_STATUS;

                    if (jsondata[0].T_GENERAL_APP_CHECK_YN === '1') {
                        $timeout(function () {
                                angular.element('#trigerGeneral').triggerHandler('click');
                                angular.element('#trigerBagUsed').triggerHandler('click');
                            },
                            0);
                        scope.obj.T12022.T_DONATION_COMPLETION_STATUS = jsondata[0].T_DONATION_COMPLETION_STATUS;
                        scope.obj.T12022.T_BAG_USED_CODE = jsondata[0].T_BAG_USED_CODE;

                    } else {
                        $timeout(function () {
                                angular.element('#trigerGeneral').triggerHandler('click');
                                angular.element('#trigerBagUsed').triggerHandler('click');
                            },
                            0);
                        scope.obj.T12022.T_DONATION_COMPLETION_STATUS = jsondata[0].T_DONATION_COMPLETION_STATUS;
                        scope.obj.T12022.T_BAG_USED_CODE = jsondata[0].T_BAG_USED_CODE;
                    }
                    var dd = jsondata[0].T_APHERESIS;
                    if (dd === '1') {
                        $timeout(function () {
                                angular.element('#trigerApheresis').triggerHandler('click');
                            },
                            0);
                    }

                    scope.obj.saveStatus = '2';
                } else {
                    document.getElementById("txtSegmentNo").focus();
                }

            });
        }
        scope.TrigerApheresis = function() {
            //completeStatus('2');
            completeStatus('1');
          
        }
        scope.TrigerGeneral = function () {
            completeStatus('1');
        }
        scope.TrigerBagUsed = function () {
            var ddlBedUsed = T12204Service.getBedUsedData(scope.obj.completeIdForBagUsed);
            ddlBedUsed.then(function (data) {
                var jsonData = JSON.parse(data);
                if (jsonData.lenght !== 0) {
                    scope.BedUsedList = jsonData;
                } else {
                    scope.BedUsedList = "";
                }

            });
        }
        scope.BagWeight_Click = function (event, weight) {
           
            if (event.keyCode===13) {
                var bagWeight = T12204Service.getReson_AcStatus(weight);
                bagWeight.then(function (data) {
                    var jsondata = JSON.parse(data);
                    scope.obj.T12022.CancelReason = jsondata[0].T_LANG2_NAME;
                    scope.obj.T12022.UINT_ACCEPT_STATUS = jsondata[0].UINT_ACCEPT_STATUS;
                    scope.obj.T12022.T_ACTION = jsondata[0].T_ACTION;
                    //scope.obj.T12022.T_WEIGHT_CODE = jsondata[0].T_WEIGHT_CODE;
                }); 
            } else if (event.keyCode === 9) {
                var bagWeight = T12204Service.getReson_AcStatus(weight);
                bagWeight.then(function (data) {
                    var jsondata = JSON.parse(data);
                    scope.obj.T12022.CancelReason = jsondata[0].T_LANG2_NAME;
                    scope.obj.T12022.UINT_ACCEPT_STATUS = jsondata[0].UINT_ACCEPT_STATUS;
                    scope.obj.T12022.T_ACTION = jsondata[0].T_ACTION;
                    //scope.obj.T12022.T_WEIGHT_CODE = jsondata[0].T_WEIGHT_CODE;
                }); 
            }
         
            
        }
        //-------- For bed popup start --------
        scope.Bed_Click = function (id) {
          
            if (scope.obj.T_BLOOD_DONATION_STATUS !== '3') {
                var bed = T12204Service.getBed();
                bed.then(function (data) {
                    var jsondata = JSON.parse(data);
                    scope.obj.BedList = jsondata;
                });
                document.getElementById(id).style.display = "block";
            }
            
        }
        scope.GetDataOnKeyPrass = function (event,forbed) {
            if (event.keyCode === 9) {
                if (forbed === 'Bed') {
                    bedData();
                } else if (forbed === 'Discurt') {
                    discutdReason();
                }
            } else if (event.keyCode === 120) {
                if (forbed === 'Discurt') {
                   
                    if (scope.obj.T_BLOOD_DONATION_STATUS !== '3') {
                        var discurtReason = T12204Service.getDiscurtReason();
                        discurtReason.then(function (data) {
                            var jsondata = JSON.parse(data);
                            scope.obj.ReasonList = jsondata;
                        });
                        document.getElementById('DiscurtReasonPopUp').style.display = "block";
                    }
                    
                } else if (forbed === 'Bed'){
                   
                    if (scope.obj.T_BLOOD_DONATION_STATUS !== '3') {
                        var bed = T12204Service.getBed();
                        bed.then(function (data) {
                            var jsondata = JSON.parse(data);
                            scope.obj.BedList = jsondata;
                        });
                        document.getElementById('BedPopUp').style.display = "block";
                    } 
                }
                
            } else if (event.keyCode === 13) {
                if (forbed === 'Bed') {
                    bedData();
                } else if (forbed === 'Discurt') {
                    discutdReason();
                }
            }
          
        }
        function bedData() {
            var bedno = scope.obj.T12022.T_BED_CODE;
            var besd = formatted_string('00', bedno, '1');
            var bed = T12204Service.getBed();
            bed.then(function (data) {
                var jsondata = JSON.parse(data);
                for (var i = 0; i < jsondata.length; i++) {
                    if (jsondata[i].T_BED_CODE === besd) {
                        scope.obj.T12022.T_BED_CODE = jsondata[i].T_BED_CODE;
                        scope.obj.T_BED_NAME_LANG2 = jsondata[i].T_BED_NAME_LANG2;
                    }
                }

            });
        }

        function discutdReason(parameters) {
            var dis = scope.obj.T12022.DISCARD_REASON_CODE;
            var discurtReason = T12204Service.getDiscurtReason();
            discurtReason.then(function (data) {
                var jsondata = JSON.parse(data);
                for (var i = 0; i < jsondata.length; i++) {
                    if (jsondata[i].T_RJ_RSN_CODE === dis) {
                        scope.obj.T12022.DISCARD_REASON_CODE = jsondata[i].T_RJ_RSN_CODE;
                        scope.obj.T_LANG_NAME = jsondata[i].T_LANG_NAME;
                        
                    }
                }
            });
        }
        scope.ClosePatientPopup = function(id) {
            document.getElementById(id).style.display = "none";
        }
        //-------- For bed popup end --------

        //-------- For Discurt reason popup start --------
        scope.DiscurtReason_Click = function (id) {
          
            if (scope.obj.T_BLOOD_DONATION_STATUS !== '3') {
                var discurtReason = T12204Service.getDiscurtReason();
                discurtReason.then(function (data) {
                    var jsondata = JSON.parse(data);
                    scope.obj.ReasonList = jsondata;
                });

                document.getElementById(id).style.display = "block";
            }
            
        }
        scope.CloseDisReasonPopup = function(id) {
            document.getElementById(id).style.display = "none";

        }
        scope.setClickReasonRow = function (index, data, id) {
            scope.selectedRow = index;
            scope.obj.T12022.DISCARD_REASON_CODE = data.T_RJ_RSN_CODE;
            scope.obj.T_LANG_NAME = data.T_LANG_NAME;
              scope.Search = "";
            document.getElementById(id).style.display = "none";
        }
        //-------- For Discurt reason popup end --------

        //------------------verification popup start ---------
        scope.CloseVerificationPopup = function(id) {
            document.getElementById(id).style.display = "none";
        }
        //------------------verification popup end ---------
        //------------------------ Apheresis popup start -----------------------------
        scope.Apheresis_Click = function(id) {
            document.getElementById(id).style.display = "block";
        }
        scope.CloseApheresisPopup = function(id) {
            document.getElementById(id).style.display = "none";
           // completeStatus('2');
            completeStatus('1');
            scope.obj.T12022.T_DONATION_COMPLETION_STATUS = '';
        }

        //-------------------------Apheresis popup end -----------------------------
        function readOnly() {
            document.getElementById("txtSegmentNo").readOnly = true;
            document.getElementById("txtPhebotomy").readOnly = true;
            document.getElementById("txtBedNo").readOnly = true;
            document.getElementById("txtBadWeight").readOnly = true;
            document.getElementById("txtMarks").readOnly = true;
            document.getElementById("txtReasonMNo").readOnly = true;

            scope.ChkBoxAPheresis = 'Diable';
           // scope.ChkBoxGeneralApp = 'Diable';
            
        }

        //---------For check box start ----------
        scope.ChkBoxDHQ = 'Diable';
        scope.ChkBoxLetArm = 'Diable';
        scope.ChkBoxRightArm = 'Diable';
        scope.ChkBoxBag = 'Diable';
        scope.ChkBoxPLT = 'Diable';
        scope.ChkBoxRBCS = 'Diable';
        scope.ChkBoxPlasma = 'Diable';

        

        scope.obj.T12022.ChkGenlApp = '';
        scope.obj.T12022.ChkbxDHQ = '';
        scope.obj.T12022.ChkbxLetArm = '';
        scope.obj.T12022.ChkbxRightArm = '';
        scope.obj.T12022.ChkbxBag = '';

        scope.obj.T12022.ChkAPheresis = '';
        scope.obj.T12022.ChkPLT = '';
        scope.obj.T12022.ChkRBCS = '';
        scope.obj.T12022.ChkPlasma = '';

        document.getElementById("txtPlatelet").readOnly = true;
        document.getElementById("txtYieldPropduct").readOnly = true;
        document.getElementById("txtVolumeACDPlatelet").readOnly = true;
        document.getElementById("txtPlasmaVolume").readOnly = true;
        document.getElementById("txtVolumeACDPlasma").readOnly = true;
        document.getElementById("txtRBCVolume").readOnly = true;
        document.getElementById("txtVolumeACDbrc").readOnly = true;
        document.getElementById("txtHCTOfBRC").readOnly = true;
       

        scope.chkGeneralApp_Click = function () {
           var ck= document.getElementById("chkGeneralApp").checked ;
            if (ck===true) {
                scope.ChkBoxDHQ = 'Enable';
                scope.ChkBoxLetArm = 'Enable';
                scope.ChkBoxRightArm = 'Enable';
                scope.ChkBoxBag = 'Enable';


                document.getElementById("chkPLT").checked = false;
                document.getElementById("chkRBCS").checked = false;
                document.getElementById("chkPlasma").checked = false;
                document.getElementById("chkAPheresis").checked = false;
                scope.ChkBoxPLT = 'Diable';
                scope.ChkBoxRBCS = 'Diable';
                scope.ChkBoxPlasma = 'Diable';

              //  scope.ChkBoxAPheresis = 'Diable';
                scope.obj.T12022.Phebotomy = '';
                scope.obj.T12022.T_COMMENTS = '';
                completeStatus('1');
            } else {
               
                document.getElementById("chkDHQ").checked = false;
                document.getElementById("chkLetArm").checked = false;
                document.getElementById("chkRightArm").checked = false;
                document.getElementById("chkBag").checked = false;
                scope.ChkBoxDHQ = 'Diable';
                scope.ChkBoxLetArm = 'Diable';
                scope.ChkBoxRightArm = 'Diable';
                scope.ChkBoxBag = 'Diable';
               // scope.ChkBoxAPheresis = 'Enable';
            }
        }
        scope.chkAPheresis_Click = function() {
            var ckk = document.getElementById("chkAPheresis").checked;
            if (ckk === true) {
                scope.ChkBoxPLT = 'Enable';
                scope.ChkBoxRBCS = 'Enable';
                scope.ChkBoxPlasma = 'Enable';

                //scope.ChkBoxGeneralApp = 'Diable';
                document.getElementById("chkDHQ").checked = false;
                document.getElementById("chkLetArm").checked = false;
                document.getElementById("chkRightArm").checked = false;
                document.getElementById("chkBag").checked = false;
                document.getElementById("chkGeneralApp").checked = false;

                scope.ChkBoxDHQ = 'Diable';
                scope.ChkBoxLetArm = 'Diable';
                scope.ChkBoxRightArm = 'Diable';
                scope.ChkBoxBag = 'Diable';
              // completeStatus('2');
                scope.CompleteStatusList = {};
                completeStatus('1');
                scope.obj.T12022.Phebotomy = '';
                scope.obj.T12022.T_COMMENTS = '';
            } else {
                document.getElementById("chkPLT").checked = false;
                document.getElementById("chkRBCS").checked = false;
                document.getElementById("chkPlasma").checked = false;
               
                scope.ChkBoxPLT = 'Diable';
                scope.ChkBoxRBCS = 'Diable';
                scope.ChkBoxPlasma = 'Diable';

               // scope.ChkBoxGeneralApp = 'Enable';
            }
        }
        scope.chkPLT_Click = function () {
            var plt = document.getElementById("chkPLT").checked;
            if (plt===true) {
                document.getElementById("txtPlatelet").readOnly = false;
                document.getElementById("txtYieldPropduct").readOnly = false;
                document.getElementById("txtVolumeACDPlatelet").readOnly = false;
            } else {
                document.getElementById("txtPlatelet").readOnly = true;
                document.getElementById("txtYieldPropduct").readOnly = true;
                document.getElementById("txtVolumeACDPlatelet").readOnly = true;
            }
           
        }
        scope.chkPlasma_Click = function () {
            var plasma = document.getElementById("chkPlasma").checked;
            if (plasma===true) {
                document.getElementById("txtPlasmaVolume").readOnly = false;
                document.getElementById("txtVolumeACDPlasma").readOnly = false;
            } else {
                document.getElementById("txtPlasmaVolume").readOnly = true;
                document.getElementById("txtVolumeACDPlasma").readOnly = true;
            }
            
        }
       
        scope.chkRBCS_Click = function () {
           
            var RBCS = document.getElementById("chkRBCS").checked;
            if (RBCS === true) {
                document.getElementById("txtRBCVolume").readOnly = false;
                document.getElementById("txtVolumeACDbrc").readOnly = false;
                document.getElementById("txtHCTOfBRC").readOnly = false;
            } else {
                document.getElementById("txtRBCVolume").readOnly = true;
                document.getElementById("txtVolumeACDbrc").readOnly = true;
                document.getElementById("txtHCTOfBRC").readOnly = true;
            }
            
        }
        //---------For check box end ----------

        //==== for Dropdown statr=====

        function completeStatus(d) {
            var ddlCompleteStatus = T12204Service.getCompStatusData(d);
            ddlCompleteStatus.then(function (data) {
                scope.CompleteStatusList = JSON.parse(data);
            });
        }
        var ddlCompleteStatus = T12204Service.getCompStatusData('1');
        ddlCompleteStatus.then(function (data) {
            scope.CompleteStatusList = JSON.parse(data);
        });
        var ddlBedUsed = T12204Service.getBedUsedData('0');
        ddlBedUsed.then(function (data) {
            var jsonData = JSON.parse(data);
            scope.BedUsedList = jsonData;
        });
        scope.getBedUsedData = function (id) {
            var ckk = document.getElementById("chkAPheresis").checked;
            if (id === '1' && ckk ===true) {
                var plt = document.getElementById("chkPLT").checked;
                if (plt === true) {
                    document.getElementById("txtPlatelet").readOnly = false;
                    document.getElementById("txtYieldPropduct").readOnly = false;
                    document.getElementById("txtVolumeACDPlatelet").readOnly = false;
                } else {
                    document.getElementById("txtPlatelet").readOnly = true;
                    document.getElementById("txtYieldPropduct").readOnly = true;
                    document.getElementById("txtVolumeACDPlatelet").readOnly = true;
                }
                
                var plasma = document.getElementById("chkPlasma").checked;
                if (plasma === true) {
                    document.getElementById("txtPlasmaVolume").readOnly = false;
                    document.getElementById("txtVolumeACDPlasma").readOnly = false;
                } else {
                    document.getElementById("txtPlasmaVolume").readOnly = true;
                    document.getElementById("txtVolumeACDPlasma").readOnly = true;
                }
                var RBCS = document.getElementById("chkRBCS").checked;
                if (RBCS === true) {
                    document.getElementById("txtRBCVolume").readOnly = false;
                    document.getElementById("txtVolumeACDbrc").readOnly = false;
                    document.getElementById("txtHCTOfBRC").readOnly = false;
                } else {
                    document.getElementById("txtRBCVolume").readOnly = true;
                    document.getElementById("txtVolumeACDbrc").readOnly = true;
                    document.getElementById("txtHCTOfBRC").readOnly = true;
                }

                document.getElementById('ApheresisPopUp').style.display = "block";

            } else {
                var ddlBedUsed = T12204Service.getBedUsedData(id);
                ddlBedUsed.then(function (data) {
                    var jsonData = JSON.parse(data);
                    if (jsonData.lenght !== 0) {
                        scope.obj.T12022.T_BAG_USED_CODE = jsonData[0].T_BAG_USED_CODE;
                        //scope.BedUsedList = jsonData;
                    } else {
                        scope.BedUsedList = "";
                    }

                });
            }
            
        }

        
        //==== for Dropdown end=====

        // ---------- for pad start --------
        var forFocus = '';
        scope.Focus = function(pam) {
            forFocus = pam;
        }
        scope.obj.T12075.T_UNIT_NO = '';
        scope.obj.T12071.T_DONOR_PATNO = '';
        scope.obj.T12022.T_BAG_WEIGHT = '';
        scope.obj.T12071.T_NTNLTY_ID = '';
        scope.addNumber = function (num) {
            //obj.Hidenfield
             if (forFocus === 'PatNo') {
                scope.obj.T12071.T_DONOR_PATNO += num;
                document.getElementById('txtPatNo').focus();
             } else if (forFocus === 'natID') {
                 scope.obj.T12071.T_NTNLTY_ID += num;
                 document.getElementById('txtNationalID').focus();
             }
             else if (forFocus === 'bag') {
                 
                 scope.obj.T12022.T_BAG_WEIGHT += num;
                 document.getElementById('txtBadWeight').focus();

                 var bagWeight = T12204Service.getReson_AcStatus(scope.obj.T12022.T_BAG_WEIGHT);
                 bagWeight.then(function (data) {
                     var jsondata = JSON.parse(data);
                     scope.obj.T12022.CancelReason = jsondata[0].T_LANG2_NAME;
                     scope.obj.T12022.UINT_ACCEPT_STATUS = jsondata[0].UINT_ACCEPT_STATUS;
                     scope.obj.T12022.T_ACTION = jsondata[0].T_ACTION;
                     //scope.obj.T12022.T_WEIGHT_CODE = jsondata[0].T_WEIGHT_CODE;
                 });
            }
        };

        scope.FocusFalse = function() {
            scope.Unit = false;
            scope.PatNo = false;
            scope.NaID = false;
            scope.BaWet = false;
          //  scope.PatNo = false;

        }

        scope.BackNumber = function () {

            if (forFocus === 'PatNo') {

                var pnum = scope.obj.T12071.T_DONOR_PATNO.length;
                scope.obj.T12071.T_DONOR_PATNO = scope.obj.T12071.T_DONOR_PATNO.substring(0, pnum - 1);
                document.getElementById('txtPatNo').focus();
            }
            else if (forFocus === 'bag') {

                var pnum = scope.obj.T12022.T_BAG_WEIGHT.length;
                scope.obj.T12022.T_BAG_WEIGHT = scope.obj.T12022.T_BAG_WEIGHT.substring(0, pnum - 1);
                document.getElementById('txtBadWeight').focus();
            }
            else if (forFocus === 'natID') {

                var pnum = scope.obj.T12071.T_NTNLTY_ID.length;
                scope.obj.T12071.T_NTNLTY_ID = scope.obj.T12071.T_NTNLTY_ID.substring(0, pnum - 1);
                document.getElementById('txtNationalID').focus();
            }

        }
        scope.Cancel = function () {
            if (forFocus === 'unit') {
                scope.obj.T12022.T_UNIT_NO = '';
                document.getElementById('txtUnit').focus();
            } else if (forFocus === 'PatNo'){
                scope.obj.T12022.T_DONOR_PATNO = '';
                document.getElementById('txtPatNo').focus();
            }
            else if (forFocus === 'bag') {
                scope.obj.T12022.T_WEIGHT = '';
                document.getElementById('txtBadWeight').focus();
            }
        }
        scope.Enter = function() {
            if (forFocus === 'PatNo' || forFocus === 'natID') {
                var patNo = scope.obj.T12071.T_DONOR_PATNO;
                if (patNo!=="") {
                    ptientNo = formatted_string('00000000', patNo, '1');
                } else {
                    ptientNo = "";
                }
             
                var natId = scope.obj.T12071.T_NTNLTY_ID;
                patientInformation(ptientNo, natId);
            }
            else if (forFocus === 'bag') {
                var weight= scope.obj.T12022.T_WEIGHT;
                var bagWeight = T12204Service.getReson_AcStatus(weight);
                bagWeight.then(function (data) {
                    var jsondata = JSON.parse(data);
                    scope.obj.T_LANG2_NAME = jsondata[0].T_LANG2_NAME;
                    scope.obj.UINT_ACCEPT_STATUS = jsondata[0].UINT_ACCEPT_STATUS;
                });
            }
        }
        //------- for pad end --------
        //=============== for time, start ============================
        var startMin = 0;
        var startHou = 0;
        var endMin = 0;
        var endHou = 0;
        scope.StartTime_Click = function () {
          var crm= confirm("Are you sure to donate Blood?");
            //var currentMinute = new Date().getMinutes();
            //   startMin = currentMinute;
            //var currenHours = new Date().getHours();
            //   startHou = currenHours;
            //scope.obj.T12022.DonationStartTime = currenHours + ':' + currentMinute;
            if (crm===true) {
            var date = new Date();
            var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
                startHou = hours;
            var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
              startMin = minutes;
           // var seconds = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
            scope.obj.T12022.DonationStartTime = hours + ":" + minutes;
           // alert(time);
            }
        }
        scope.EndTime_Click = function() {
            if (startMin === 0 && startHou===0) {
                alert("First you click start Button ");
            } else {
            var date = new Date();
            var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
                endHou = hours;
            var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
                endMin = minutes;
           // var seconds = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
            scope.obj.T12022.DonationEndTime = hours + ":" + minutes;

            var gethours = endHou - startHou;
            var getminute = endMin - startMin;
            var conhour = gethours < 1 ? 0 : 60;
           // scope.obj.T12022.Phebotomy = gethours + ':' + getminute;
            scope.obj.T12022.Phebotomy = conhour + getminute;
            document.getElementById("txtBedNo").focus();

            var ckkGeneral = document.getElementById("chkGeneralApp").checked;
            var ckkApheresis = document.getElementById("chkAPheresis").checked;
            if (ckkGeneral===true) {

                var comment = T12204Service.getComment(scope.obj.T12022.Phebotomy);
                comment.then(function(com) {
                    var jsondata = JSON.parse(com);
                    scope.obj.T12022.T_COMMENTS = jsondata[0].T_COMMENTS;
                });
            } else if (ckkApheresis===true){
                var comts = T12204Service.getComntT12328(scope.obj.T12022.Phebotomy);
                comts.then(function (com) {
                    var jsondata = JSON.parse(com);
                    scope.obj.T12022.T_COMMENTS = jsondata[0].T_COMMENTS;
                });
            }
          }

        }

        scope.Phebotomy_Click = function () {
            if (scope.obj.T12071.T_DONOR_PATNO !=="") {
                var ckkGeneral = document.getElementById("chkGeneralApp").checked;
                var ckkApheresis = document.getElementById("chkAPheresis").checked;
                if (ckkGeneral === true) {

                    var comment = T12204Service.getComment(scope.obj.T12022.Phebotomy);
                    comment.then(function (com) {
                        var jsondata = JSON.parse(com);
                        scope.obj.T12022.T_COMMENTS = jsondata[0].T_COMMENTS;
                    });
                } else if (ckkApheresis === true) {
                    var comts = T12204Service.getComntT12328(scope.obj.T12022.Phebotomy);
                    comts.then(function (com) {
                        var jsondata = JSON.parse(com);
                        scope.obj.T12022.T_COMMENTS = jsondata[0].T_COMMENTS;
                    });
                } else {
                    var comment = T12204Service.getComment(scope.obj.T12022.Phebotomy);
                    comment.then(function (com) {
                        var jsondata = JSON.parse(com);
                        scope.obj.T12022.T_COMMENTS = jsondata[0].T_COMMENTS;
                    });
                }
            } else {
                alert("Please fill up Patient No");
                scope.obj.T12022.Phebotomy = '';
            }
        }
        //=============== for time, end ============================
        scope.Segment_Click = function() {
            if (scope.obj.T12071.T_DONOR_PATNO !== "") {
                //scope.obj.T12022.T_SEGMENT_NO =
            } else {
                alert("Please fill up Patient No");
                scope.obj.T12022.T_SEGMENT_NO = '';
            }
        }
        //-------------------
        
        //======== For Report start ========================
        scope.Print_Click = function () {
         
            var patid = scope.obj.T12071.T_DONOR_PATNO;
            var epsort = scope.obj.T12071.MAX_EPISODE;

            if (scope.obj.T12022.T_UNIT_NO !== undefined && scope.obj.T12022.T_SEGMENT_NO !== undefined) {
                $window.open("../Report12204/GetReport?patid=" + patid + "&&epsort=" + epsort, "popup", "width=600,height=600,left=100,top=50");
               
                //scope.obj.T12022 = {};
                //scope.obj.T12071 = {};
                //scope.obj.T_BED_NAME_LANG2 = '';
                //scope.obj.T_LANG_NAME = '';
                //scope.obj.quesList = '';
                //scope.obj.T_BP_HIGH = '';
                //scope.obj.T_BP_LOW = '';
                //scope.obj.T_TEMPTURE = '';
                //scope.obj.T_PULS = '';
                //scope.obj.T_HB = '';
                //scope.obj.Body_WEIGHT = '';
                //scope.obj.patNo = '';
                //scope.obj.patNaId = '';
                //scope.obj.T12071.T_NTNLTY_ID = '';
                //scope.obj.T12071.T_DONOR_PATNO = '';
                //scope.obj.Images = "../../Images/Buton.png";
            } else {
                alert("Unit or segment is not generated !!!!");
            }
           
        }

        //======== For Report end ========================
        scope.setClickedRow = function (index, data, id) {

            scope.selectedRow = index;
            scope.obj.T12022.T_BED_CODE = data.T_BED_CODE;
            scope.obj.T_BED_NAME_LANG2 = data.T_BED_NAME_LANG2;
            scope.Search = "";
            document.getElementById(id).style.display = "none";
        }
        scope.$watch('selectedRow', function () {
            console.log('Do Some processing'); //runs the block whenever selectedRow is changed. 
        });
      

        }]);

app.filter('propsFilter', function () {
    return function (items, props) {
        var out = [];

        if (angular.isArray(items)) {
            var keys = Object.keys(props);

            items.forEach(function (item) {
                var itemMatches = false;

                for (var i = 0; i < keys.length; i++) {
                    var prop = keys[i];
                    var text = props[prop].toLowerCase();
                    if (item[prop].toString().toLowerCase().indexOf(text) !== -1) {
                        itemMatches = true;
                        break;
                    }
                }

                if (itemMatches) {
                    out.push(item);
                }
            });
        } else {
            // Let the output be the input untouched
            out = items;
        }

        return out;
    };
});