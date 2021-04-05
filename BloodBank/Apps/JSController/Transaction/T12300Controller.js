app.controller("T12300Controller", ["$scope", "Data", "T12300Service", "$filter", "$window",
    function($scope, Data, T12300Service, $filter, $window) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12300 = {};
        $scope.obj.h = {};
        $scope.obj.a = {};
        $scope.obj.p = {};
        $scope.obj.V = {};
        $scope.checked = ''; // $scope.checked is used for controlling ng-blur 
       // document.getElementById('chkBlur').checked=true;
       // document.getElementById('txtPatNo').focus();


        $scope.obj.T12300.T_PREV_TRANSFUSION_YN = '';
        $scope.obj.T12300.T_PREV_PREGNANCIES_YN = '';
        $scope.obj.T12300.T_POST_TRANSF_REACTION_YN = '';
        $scope.obj.T12300.T_TRANSFUSION_NONE = '';
        $scope.obj.T12300.T_X_MATCH_WITH_BLOOD = '';
        $scope.obj.T12300.T_X_MATCH_WITHOUT_BLOOD = '';
        $scope.obj.T12300.T_IMMEDIATE_SPIN_X = '';
      
        //----------Tab Toggling--------------start
        $scope.lang = JSON.parse(sessionStorage.getItem("LangName"))== undefined ? 2 : JSON.parse(sessionStorage.getItem("LangName"));
        $scope.FloatE = { "float": 'left', "margin-right":'-3px' }
        $scope.FloatA = { "float": 'right', "margin-left": '-3px' }
        $scope.aR = {"text-align":'right'}
        $scope.aL = {"text-align":'left'}
        $scope.obj.Hidenfield = 'Req';
        $scope.currentTab = 'tabRequisition.tpl.html';
        $scope.tabs = [
            { title: $scope.getLabel('lblRequisition'), url: 'tabRequisition.tpl.html', hin: 'Req' },
            { title: $scope.getLabel('lblDetail'), url: 'tabDetail.tpl.html', hin: 'Det' },
            { title: $scope.getLabel('lblEmergency'), url: 'tabEmergency.tpl.html', hin: 'Eme' }
        ];
        
        $scope.onClickTab = function (tab) {

            $scope.obj.Hidenfield = tab.hin;
            $scope.currentTab = tab.url;
            readOnlyUnderValue();
        }
        $scope.isActiveTab = function (tabUrl) { return tabUrl === $scope.currentTab; }
        //----------Tab Toggling--------------End
        $scope.obj.T12300.T_PAT_NO = JSON.parse(sessionStorage.getItem("PatNo"));
        if ($scope.obj.T12300.T_PAT_NO !== null) { getPatientDetails() }

        $scope.GetPatient_Registation = function() {
            var name = $scope.lang === '1' ? "تسجيل المانحين" : "Donor Registration";
            sessionStorage.setItem("FName", JSON.stringify(name));
            sessionStorage.setItem("FReqCode", JSON.stringify("T12300"));

            var labelData = T12300Service.GetLabelText("Q03001", $scope.lang);
            labelData.then(function (data) {
                $scope.entity = JSON.parse(data);
                sessionStorage.setItem("LabelData", JSON.stringify($scope.entity));

                var hostAddress = $window.location.host;
                var url = "http://" + hostAddress + $scope.vrDir + "/Query/Q03001";
               // var url = "http://" + hostAddress + "/Transaction/T12214";
                $window.location.href = url;
            });


            //var hostAddress = $window.location.host;
            //    var url = "http://" + hostAddress + "/Transaction/T12214";
            //    $window.location.href = url;

        }
      
        $scope.GetPatient_Click = function (event, patNo) {
            $scope.previusPat = $scope.obj.T12300.T_PAT_NO;
            if (event.keyCode === 13) {
                $scope.obj.T12300.T_PAT_NO = formatted_string('00000000', patNo, '1');
                getPatientDetails();
                $scope.checked = '1';// $scope.checked is used for controlling ng-blur 

                $scope.$watch('myVar', function () {
                    if ($scope.myVar === "NoData") {
                        alert('Data not found ');
                       // $scope.checked = '';
                        $scope.myVar = "ok"; 
                    }

                });
            }
            else if (event.keyCode === 9) {
                $scope.obj.T12300.T_PAT_NO = formatted_string('00000000', patNo, '1');
                getPatientDetails();
                $scope.checked = '1';// $scope.checked is used for controlling ng-blur 

                //$scope.$watch('myVar', function () {
                //    if ($scope.myVar === "NoData") {
                //        alert('Data not found ');
                //        // $scope.checked = '';
                //    }

                //});
            }
            //else if (event.keyCode === 114) {
            //    next();
            //}
            else if (patNo.length === 1) {
                $scope.checked = '';
                $scope.myVar = "ok";
            }
        }
       
        $scope.GetPatient_blur = function () {
           
                var patNo = $scope.obj.T12300.T_PAT_NO;
                $scope.obj.T12300.T_PAT_NO = formatted_string('00000000', patNo, '1');
               getPatientDetails();
            
            $scope.$watch('myVar', function () {
                if ($scope.myVar ==="NoData") {
                    alert('Data not found ');
                    $scope.checked = '1';
                    $scope.myVar = "ok";
                }
               
            });
        }
        $scope.KeyDown_Click = function (event, name) {
         
            if (name ==='patName') {
                if (event.keyCode === 114) {
                    event.preventDefault();
                    next();
                }
            }
        }
        
       // var b = "";
        function getPatientDetails() {
           
            var patData = T12300Service.getPatDetailsData($scope.obj.T12300.T_PAT_NO);
            patData.then(function(data) {
                var jsonData = JSON.parse(data);
                if (jsonData.length >0) {
                $scope.obj.T12300.T_PAT_NO = jsonData[0].T_PAT_NO;
                $scope.obj.T12300.PAT_NAME = jsonData[0].PAT_NAME;
                $scope.obj.T12300.YRS = jsonData[0].YRS;
                $scope.obj.T12300.MOS = jsonData[0].MOS;
                $scope.obj.T12300.GENDER = jsonData[0].GENDER;
                $scope.obj.T12300.NATIONALITY = jsonData[0].NATIONALITY;

                    $scope.RQID_12 = jsonData[0].RQID_12;
                    $scope.T_REQUEST_DATE = jsonData[0].T_REQUEST_DATE;
                    $scope.T_REQUEST_TIME = jsonData[0].T_REQUEST_TIME; 
                    $scope.T_REQUISITION = jsonData[0].T_REQUISITION; 
                    if (jsonData[0].PAT_12 !== null) {
                        alert('Previous Request details ' + '\n' + 'Request No : ' + $scope.RQID_12 +
                            '\n' + 'Product : ' + $scope.T_REQUISITION +
                            '\n' + 'Request Date : ' + $scope.T_REQUEST_DATE +
                            '\n' + 'Request Time : ' + $scope.T_REQUEST_TIME);
                       
                       // alert('Really need to alert some ' + toUnicodeVariant('underlined', 'bold', 'underline') + ' text');
                    }
                   
                    $scope.checked = '';// $scope.checked is used for controlling ng-blur 
                    // for requisition
                   
                    $scope.myVar = "DataAvailable";
                    document.getElementById("txtPatName").focus();
                } else {
                   
                   // if ($scope.checked === '1') {
                       // alert("Data not found ");
                   // }
                    $scope.obj.T12300 = {};
                  //  $scope.checked = '';                   
                    $scope.myVar= "NoData";
                  
                }
               
            });
           // return b;
        }

        function getArb(d) {
            var k = $scope.date(d, "/");
            var n = Date.parse(k);
            return moment(n).format('iDD/iMM/iYYYY');
        }
        $scope.date = function (p, sl) {
            var dateParts = p.split(sl);
            var dateObject = new Date(dateParts[2], dateParts[1] - 1, dateParts[0]);
            var result = $filter('date')(dateObject, "dd/MMM/yyyy");
            return result;

        }
        //-------- Doctor Popup  start -----------
        $scope.ShowDoctorPopup = function (popup) {
            doctorData();
            document.getElementById(popup).style.display = "block";
        }

        function doctorData() {
            var doctor = T12300Service.getDoctor();
            doctor.then(function (doc) {
                var jsondata = JSON.parse(doc);
                $scope.obj.DoctorList = jsondata;
            });
        }
        $scope.ClosePatientPopup = function(popupId) {
            document.getElementById(popupId).style.display = "none";
        }
        $scope.setClickedRow = function (index, data) {
            $scope.selectedRow = index;
            $scope.obj.T12300.T_DOC_CODE = data.T_DOC_CODE;
            if ($scope.lang === '1') {
                $scope.obj.T12300.DOCTOR_NAME_ENG = data.DOCTOR_NAME_ARB;
            } else {
                $scope.obj.T12300.DOCTOR_NAME_ENG = data.DOCTOR_NAME_ENG;
            }
            document.getElementById('DoctorPopUp').style.display = "none";
           
        }
        //-------- Doctor Popup  end -----------
        //-------- Consultant Popup  start -----------
        $scope.setClickedRowConsultant = function (index, data) {
            $scope.selectedRow = index;
            $scope.obj.T12300.T_CONSULTANT_CODE = data.T_DOC_CODE;
            if ($scope.lang === '1') {
                $scope.obj.T12300.CONSULTANT_NAME_ENG = data.DOCTOR_NAME_ARB;
            } else {
                $scope.obj.T12300.CONSULTANT_NAME_ENG = data.DOCTOR_NAME_ENG;
            }
            document.getElementById('ConsultantPopUp').style.display = "none";

        }
        //-------- Consultant Popup  end -----------
        //-------- ABO Popup  start -----------
        $scope.ShowABOPopup = function(popup) {
            aboData();
            document.getElementById(popup).style.display = "block";
        }
        $scope.setClickedRowABO = function (index, data,popup) {
            $scope.selectedRow = index;
            $scope.obj.T12300.T_ABO_CODE = data.T_ABO_CODE;
            $scope.obj.T12300.LANG_NAME = data.LANG_NAME;
            
            document.getElementById(popup).style.display = "none";
        }
        function aboData() {
            var abo = T12300Service.getABO();
            abo.then(function (abo) {
                var jsondata = JSON.parse(abo);
                $scope.obj.ABOList = jsondata;
            });
        }
        //-------- ABO Popup  end -----------
        //-------- Mother Popup  start -----------
        $scope.setClickedRowMother = function (index, data, popup) {
            $scope.selectedRow = index;
            $scope.obj.T12300.T_MTHR_BG_CODE = data.T_ABO_CODE;
            $scope.obj.T12300.T_MOTHER_BG_LANG_NAME = data.LANG_NAME;

            document.getElementById(popup).style.display = "none";
        }
        //-------- Mother Popup  end -----------
        //-------- Nurse Popup  start -----------

        $scope.ShowNursePopup = function (siteCode, popup, nursOrverified) {

            if (siteCode !== undefined) {
                $scope.NursOrVerified = nursOrverified;
                if (popup === 'NursePopup') {
                    nurseData(siteCode);
                    document.getElementById('NursePopup').style.display = "block";
                } else {
                    nurseData(siteCode);
                    document.getElementById('VerifiedPopup').style.display = "block";
                    
                }
            } else {
                $scope.obj.Hidenfield = 'Req';
                $scope.currentTab = 'tabRequisition.tpl.html'; //tab.url;
                $scope.customStyle = { "color": "red" };
              //  $scope.$broadcast('ddlTitleId');
                $scope.isFocus = '1';
            }
            //$scope.NursOrVerified = nursOrverified;
            //nurseData(siteCode);
           
            //document.getElementById(popup).style.display = "block";
        }
        function nurseData(siteCode) {
            var nurse = T12300Service.getNurseData(siteCode);
            nurse.then(function (ser) {
                var jsondata = JSON.parse(ser);
                $scope.obj.NurseList = jsondata;
            });
        }
        $scope.setClickedRowNurse = function (index, data, popup) {

            if ($scope.NursOrVerified ==='nurse') {
                $scope.obj.T12300.T_NURSE_CODE = data.T_RESOURCE_CODE;
                $scope.obj.T12300.NAME_NURSE = data.NAME_NURSE;
                $scope.obj.T12300.NURSE_DATE = $filter('date')(new Date(), 'dd-MMM-yyyy');
                $scope.obj.T12300.NURSE_TIME = time();
                document.getElementById(popup).style.display = "none";
            } else if ($scope.NursOrVerified === 'verified') {

                $scope.obj.T12300.T_VERIFIED_BY = data.T_RESOURCE_CODE;
                $scope.obj.T12300.VERIFIED_NAME= data.NAME_NURSE;
                $scope.obj.T12300.T_VERIFY_DATE = $filter('date')(new Date(), 'dd-MMM-yyyy');
                $scope.obj.T12300.T_VERIFY_TIME = time();
                document.getElementById(popup).style.display = "none";
            }
            
        }

        function time () {
            var date = new Date();
            var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
            var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
            var gettime = hours + ':' + minutes;
            return gettime;

        }
        //-------- Nurse Popup  end -----------
        //-------- Surgeon Popup  start -----------
        $scope.ShowSurgeonPopup = function (popup) {
            surgeonvalue();
            document.getElementById(popup).style.display = "block";
        }

        function surgeonvalue() {
            var sergeon = T12300Service.getsergeon();
            sergeon.then(function (ser) {
                var jsondata = JSON.parse(ser);
                $scope.obj.SurgeonList = jsondata;
            });
        }
        $scope.setClickedRowSurgeon = function (index, data, popup) {
            $scope.selectedRow = index;
            $scope.obj.T12300.T_SURGEON_CODE = data.T_DOC_CODE;
            if ($scope.lang === '1') {
                $scope.obj.T12300.SURGEON_NAME = data.DOCTOR_NAME_ARB;
            } else {
                $scope.obj.T12300.SURGEON_NAME = data.DOCTOR_NAME_ENG;
            }
            $scope.obj.T12300.T_SURGEON_TIME = time();
            $scope.obj.T12300.T_SURGEON_DATE = $filter('date')(new Date(), 'dd-MMM-yyyy');
            document.getElementById(popup).style.display = "none";
        }
        //-------- Surgeon Popup  end -----------
        //-------- Ward Popup  start -----------
        $scope.ShowlocationPopup = function (popup) {
            if ($scope.obj.T12300.T_HOSP_CODE!==undefined) {
                document.getElementById(popup).style.display = "block";
            } else {
                $scope.$broadcast('ddlTitleId');
                $scope.customStyle = { "color": "red" };
            }
           
           
        }
        $scope.setClickedRowWard = function (index, data, popup) {
            $scope.obj.T12300.T_LOCATION_CODE = data.T_LOC_CODE;
            $scope.obj.T12300.T_WARD_NAME = data.T_WARD_NAME;

            document.getElementById(popup).style.display = "none";
            
        }
        //-------- Ward Popup  end -----------
        $scope.key_press = function (event, value) {
            if (event.keyCode===120) {
                if (value === 'ward') {

                    if ($scope.obj.T12300.T_HOSP_CODE !== undefined) {
                        document.getElementById('LocationPopup').style.display = "block";
                    } else {
                        $scope.$broadcast('ddlTitleId');
                        $scope.customStyle = { "color": "red" };
                    }
                  
                } else if (value === 'doctor') {
                    doctorData();
                    document.getElementById('DoctorPopUp').style.display = "block";
                }
                else if (value === 'consultan') {
                    doctorData();
                    document.getElementById('DoctorPopUp').style.display = "block";
                }
                else if (value === 'ABO') {
                    aboData();
                    document.getElementById('ABOPopup').style.display = "block";
                }
                else if (value === 'MotherPopup') {
                    aboData();
                    document.getElementById('MotherPopup').style.display = "block";
                }
                else if (value === 'SurgeonPopup') {
                    surgeonvalue();
                    document.getElementById('SurgeonPopup').style.display = "block";
                }
                //else if (value === 'MotherPopup') {
                //    aboData();
                //    document.getElementById('MotherPopup').style.display = "block";
                //}
            }
        }
        $scope.key_press_Nurse = function (event, popup, nursOrverified, siteCode) {
            if (event.keyCode===120) {
                if (siteCode !== undefined) {
                    $scope.NursOrVerified = nursOrverified;
                    if (popup === 'NursePopup') {
                        nurseData(siteCode);
                        document.getElementById('NursePopup').style.display = "block";
                    } else {
                        nurseData(siteCode);
                        document.getElementById('VerifiedPopup').style.display = "block";

                    }
                } else {
                    $scope.obj.Hidenfield = 'Req';
                    $scope.currentTab = 'tabRequisition.tpl.html'; //tab.url; ddlHospital
                    $scope.customStyle = { "color": "red" };
                    // document.getElementById('ddlHospital').focus();
                    $scope.hospital = true;
                }
            }
           
           
        }
        //---------------Dropdown start--------------------------
        var product = T12300Service.getProductData();
        product.then(function(pro) {
            var jsonData = JSON.parse(pro);
            $scope.obj.ProductList = jsonData;
        });
        $scope.isReadOnlyFibringen = true;
        $scope.isReadOnlyCoag = true;
        $scope.isReadOnlyAppt = true;
        $scope.isReadOnlyThrom = true;
        $scope.isReadOnlyAnemia = true;
        $scope.Product_Select = function(product) {
           
            if (product === 'CRYO') {
                $scope.isReadOnlyFibringen = false;

                $scope.isReadOnlyCoag = true;
                $scope.isReadOnlyAppt = true;
                $scope.isReadOnlyThrom = false;
                $scope.isReadOnlyAnemia = false;
            } else if (product ==='FFP') {
                $scope.isReadOnlyCoag = false;
                $scope.isReadOnlyAppt = false;

                $scope.isReadOnlyThrom = false;
                $scope.isReadOnlyAnemia = false;
                $scope.isReadOnlyFibringen = true;
            }
            else if (product === 'PLT') {
                $scope.isReadOnlyThrom = false;

                $scope.isReadOnlyFibringen = true;
                $scope.isReadOnlyCoag = true;
                $scope.isReadOnlyAppt = true;
                $scope.isReadOnlyAnemia = false;
            }
            else if (product === 'PRBC') {
                $scope.isReadOnlyAnemia = false;

                $scope.isReadOnlyFibringen = true;
                $scope.isReadOnlyCoag = true;
                $scope.isReadOnlyAppt = true;
                $scope.isReadOnlyThrom = false;
            }
        }
        var hospital = T12300Service.gethospitalData();
        hospital.then(function (pro) {
            var jsonData = JSON.parse(pro);
            $scope.obj.hospitalList = jsonData;
        });
        var check = T12300Service.getCheckData();
        check.then(function (data) {
            var jsonData = JSON.parse(data);
            $scope.obj.checkList = jsonData;
        });
        var virus = T12300Service.getVirusData();
        virus.then(function (vir) {
            var jsonData = JSON.parse(vir);
            $scope.obj.VirusList = jsonData;
        });
       
        $scope.Check_Select = function() {
            //var date = new Date();
            //var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
            //var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
            //$scope.obj.T12300.T_CHK_TIME24 = hours + ' : ' + minutes;
            $scope.obj.T12300.T_CHECK_BOX_TIME = time();
            $scope.obj.T12300.T_CHECK_BOX_DATE = $filter('date')(new Date(), 'dd-MMM-yyyy');
        }
        $scope.Hospital_Select = function(siteCode) {
            var ward = T12300Service.getWardData(siteCode);
            ward.then(function (data) {
                var jsonData = JSON.parse(data);
                $scope.obj.WardList = jsonData;

                Date_Time();
                //var dat = $filter('date')(new Date(), 'dd/MM/yyyy');
                //$scope.obj.T12300.T_REQUEST_DATE = $filter('date')(new Date(), 'dd-MMM-yyyy');
                //$scope.obj.T12300.REQUEST_HIJ_DATE = getArb(dat);
                //var date = new Date();
                //var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
                //var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
                //$scope.obj.T12300.T_REQUEST_TIME = hours + ':' + minutes;
                $scope.customStyle = { "color": "" };
            });
        }
        //---------------Dropdown end--------------------------
        $scope.Save_Click = function () {
            if ($scope.obj.T12300.T_PAT_NO === '') {alert('You must have to enter patient no');return;}
            if ($scope.obj.T12300.T_UNITNO === '') {alert('You must have to enter Unit no');return;}
            if ($scope.obj.T12300.T_REQUISITION !== undefined) {
                if ($scope.obj.T12300.T_REQUISITION === 'CRYO') { if ($scope.obj.T12300.T_COAGULOPATHY_FIB === undefined) { alert('Please enter the value for Fibrinogen'); return; } }
                if ($scope.obj.T12300.T_REQUISITION === 'PRBC') { if ($scope.obj.T12300.T_ANEMIA_HB === undefined) { alert('Please enter the value for Anemia Hb'); return; } }
                if ($scope.obj.T12300.T_REQUISITION === 'FFP') { if ($scope.obj.T12300.T_COAGULOPATHY_PT === undefined || $scope.obj.T12300.T_COAGULOPATHY_APPT === undefined) { alert('Please enter the value for Coagulopathy PPT and aPPT'); return; } }
                if ($scope.obj.T12300.T_REQUISITION === 'PLT') { if ($scope.obj.T12300.T_THROMBOCYTOPENIA === undefined) { alert('Please enter the value for Thrombocytopenia'); return; } }
            } else {
                alert('Please select Product');
                return;
            }
            if ($scope.obj.T12300.T_PREV_TRANSFUSION_YN === '' && $scope.obj.T12300.T_PREV_PREGNANCIES_YN === ''
                && $scope.obj.T12300.T_POST_TRANSF_REACTION_YN === '' && $scope.obj.T12300.T_TRANSFUSION_NONE === '') {
                alert('Please enter transfusion history'); return;
            }
            //if ($scope.obj.T12300.T_X_MATCH_WITH_BLOOD === '' || $scope.obj.T12300.T_X_MATCH_WITHOUT_BLOOD === ''
            //    || $scope.obj.T12300.T_IMMEDIATE_SPIN_X === '' || $scope.obj.T12300.T_SURGEON_CODE === undefined) {
            //    alert('Please Enter Emergency Physician Name'); return;
            //}

            var ward = T12300Service.saveData($scope.obj.T12300);
            ward.then(function (data) {
                var a = data.split('+');
                var msg = a[0];
                var m = msg.split('"');
                var mm = m[1];
                var re = a[1];
                var r = re.split('"');
                $scope.obj.T12300.T_REQUEST_NO = r[0];
                alert(mm);
            });
        }
        $scope.onExecute = function() {
            next();
        };
        $scope.Next_Click = function() {
            Date_Time();
        };
        
        function Date_Time()
        {
            var dat = $filter('date')(new Date(), 'dd/MM/yyyy');
            $scope.obj.T12300.T_REQUEST_DATE = $filter('date')(new Date(), 'dd-MMM-yyyy');
            $scope.obj.T12300.REQUEST_HIJ_DATE = getArb(dat);
            var date = new Date();
            var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
            var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
            $scope.obj.T12300.T_REQUEST_TIME = hours + ':' + minutes;
        }
        function next() {
            var alltData = T12300Service.geAllData($scope.obj.T12300.T_PAT_NO);
            alltData.then(function (data) {
                var jsonData = JSON.parse(data);
                if (jsonData.length > 0) {
                    //----------------------Requisition-----------------------------------
                    $scope.obj.T12300.T_REQUEST_NO = jsonData[0].T_REQUEST_NO;
                    $scope.obj.T12300.T_REQUEST_TIME = jsonData[0].T_REQUEST_TIME;
                    $scope.obj.T12300.T_REQUEST_DATE = $filter('date')(jsonData[0].T_REQUEST_DATE, 'dd-MMM-yyyy');
                    var datH = $filter('date')(jsonData[0].T_REQUEST_DATE, 'dd/MM/yyyy');
                    $scope.obj.T12300.REQUEST_HIJ_DATE = getArb(datH);

                    $scope.obj.T12300.T_LOCATION_CODE = jsonData[0].T_LOCATION_CODE;
                    $scope.obj.T12300.T_WARD_NAME = jsonData[0].T_LOCATION_NAME;
                    $scope.obj.T12300.T_DOC_CODE = jsonData[0].T_DOC_CODE;
                    $scope.obj.T12300.T_CONSULTANT_CODE = jsonData[0].T_CONSULTANT_CODE;
                    if ($scope.lang === '1') {
                        $scope.obj.T12300.DOCTOR_NAME_ENG = jsonData[0].DOCTOR_NAME_ARB;
                        $scope.obj.T12300.CONSULTANT_NAME_ENG = jsonData[0].CONSULTANT_NAME_ARB;
                    } else {
                        $scope.obj.T12300.DOCTOR_NAME_ENG = jsonData[0].DOCTOR_NAME_ENG;
                        $scope.obj.T12300.CONSULTANT_NAME_ENG = jsonData[0].CONSULTANT_NAME_ENG;
                    }
                    $scope.obj.T12300.T_UNITNO = jsonData[0].T_UNITNO;
                    $scope.obj.T12300.T_CLINICAL_DIAGNOSIS = jsonData[0].T_CLINICAL_DIAGNOSIS;
                    $scope.obj.T12300.T_CHECK_BOX_DATE = $filter('date')(jsonData[0].T_CHECK_BOX_DATE, 'dd-MMM-yyyy');//jsonData[0].T_CHECK_BOX_DATE;
                    $scope.obj.T12300.T_CHECK_BOX_TIME = jsonData[0].T_CHECK_BOX_TIME;
                    $scope.obj.T12300.T_SPI_IRRADIATED = jsonData[0].T_SPI_IRRADIATED;
                    $scope.obj.T12300.T_SPI_LEUKOCYTE = jsonData[0].T_SPI_LEUKOCYTE;
                    $scope.obj.T12300.T_SPI_VOL = jsonData[0].T_SPI_VOL;
                    $scope.obj.T12300.T_SPI_VOL_ML = jsonData[0].T_SPI_VOL_ML;
                    $scope.obj.T12300.T_ABO_CODE = jsonData[0].T_ABO_CODE;
                    $scope.obj.T12300.LANG_NAME = jsonData[0].T_ABO_NAME;
                    $scope.obj.T12300.T_MTHR_BG_CODE = jsonData[0].T_MTHR_BG_CODE;
                    $scope.obj.T12300.T_MOTHER_BG_LANG_NAME = jsonData[0].T_MTR_BG;

                    $scope.obj.h.selected = { T_HOSPITAL_NAME: jsonData[0].T_HOSPITAL_NAME };
                    $scope.obj.h.selected.T_SITE_CODE = jsonData[0].T_HOSP_CODE;

                    $scope.obj.a.selected = { T_CHECK_NAME: jsonData[0].T_CHECK_NAME };
                    $scope.obj.a.selected.T_PRTY_CODE = jsonData[0].T_CHECK_BOX;

                    $scope.obj.p.selected = { T_LANG2_NAME: jsonData[0].T_PRODUCT_NAME };
                    $scope.obj.p.selected.T_PRODUCT_CODE = jsonData[0].T_REQUISITION;


                    //----------------------Details-----------------------------------
                    $scope.obj.T12300.T_ANEMIA_HB = jsonData[0].T_ANEMIA_HB;
                    $scope.obj.T12300.T_COAGULOPATHY_PT = jsonData[0].T_COAGULOPATHY_PT;
                    $scope.obj.T12300.T_OTHERS = jsonData[0].T_OTHERS;
                    $scope.obj.T12300.T_COAGULOPATHY_APPT = jsonData[0].T_COAGULOPATHY_APPT;
                    $scope.obj.T12300.T_THROMBOCYTOPENIA = jsonData[0].T_THROMBOCYTOPENIA;
                    $scope.obj.T12300.T_COAGULOPATHY_FIB = jsonData[0].T_COAGULOPATHY_FIB;
                    $scope.obj.T12300.T_PREV_TRANSFUSION_YN = jsonData[0].T_PREV_TRANSFUSION_YN;
                    $scope.obj.T12300.T_PREV_PREGNANCIES_YN = jsonData[0].T_PREV_PREGNANCIES_YN;
                    $scope.obj.T12300.T_POST_TRANSF_REACTION_YN = jsonData[0].T_POST_TRANSF_REACTION_YN;
                    $scope.obj.T12300.T_TRANSFUSION_NONE = jsonData[0].T_TRANSFUSION_NONE;
                    $scope.obj.T12300.T_PREV_UN_EXPECTED_ANTIBODY = jsonData[0].T_PREV_UN_EXPECTED_ANTIBODY;
                    $scope.obj.T12300.T_NURSE_CODE = jsonData[0].T_NURSE_CODE;
                    $scope.obj.T12300.NAME_NURSE = jsonData[0].T_NURSE_NAME;
                    $scope.obj.T12300.T_VERIFIED_BY = jsonData[0].T_VERIFIED_BY;
                    $scope.obj.T12300.VERIFIED_NAME = jsonData[0].T_VERIFIED_NAME;
                    $scope.obj.T12300.T_VERIFY_DATE = $filter('date')(jsonData[0].T_VERIFY_DATE, 'dd-MMM-yyyy');//jsonData[0].T_VERIFY_DATE;
                    $scope.obj.T12300.T_VERIFY_TIME = jsonData[0].T_VERIFY_TIME;
                    //----------------------Emargency-----------------------------------
                    $scope.obj.T12300.T_X_MATCH_WITH_BLOOD = jsonData[0].T_X_MATCH_WITH_BLOOD;
                    $scope.obj.T12300.T_X_MATCH_WITHOUT_BLOOD = jsonData[0].T_X_MATCH_WITHOUT_BLOOD;
                    $scope.obj.T12300.T_IMMEDIATE_SPIN_X = jsonData[0].T_IMMEDIATE_SPIN_X;
                    $scope.obj.T12300.T_SURGEON_CODE = jsonData[0].T_SURGEON_CODE;
                    $scope.obj.T12300.SURGEON_NAME = jsonData[0].T_SURGEON_NAME_ARB;
                    $scope.obj.T12300.T_BLEEP_NO = jsonData[0].T_BLEEP_NO;
                    $scope.obj.T12300.T_SURGEON_DATE = $filter('date')(jsonData[0].T_SURGEON_DATE, 'dd-MMM-yyyy');//jsonData[0].T_SURGEON_DATE;
                    $scope.obj.T12300.T_SURGEON_TIME = jsonData[0].T_SURGEON_TIME;

                    $scope.obj.V.selected = { T_VIRUS_NAME: jsonData[0].T_VIRUS_NAME };
                    $scope.obj.V.selected.T_VIRUS_CODE = jsonData[0].T_WITHOUT;
                    //------------------------------------------------------------------
                   
                    

                } else {
                    alert("No Data found");
                }

            });
        }
        function readOnlyUnderValue() {
            if ($scope.obj.T12300.T_REQUISITION === 'CRYO') {

                $scope.isReadOnlyFibringen = false;

                $scope.isReadOnlyCoag = true;
                $scope.isReadOnlyAppt = true;
                $scope.isReadOnlyThrom = false;
                $scope.isReadOnlyAnemia = false;
            } else if ($scope.obj.T12300.T_REQUISITION === 'FFP') {
                $scope.isReadOnlyCoag = false;
                $scope.isReadOnlyAppt = false;

                $scope.isReadOnlyThrom = false;
                $scope.isReadOnlyAnemia = false;
                $scope.isReadOnlyFibringen = false;
            }
            else if ($scope.obj.T12300.T_REQUISITION === 'PLT') {
                $scope.isReadOnlyThrom = false;

                $scope.isReadOnlyFibringen = false;
                $scope.isReadOnlyCoag = true;
                $scope.isReadOnlyAppt = true;
                $scope.isReadOnlyAnemia = false;
            }
            else if ($scope.obj.T12300.T_REQUISITION === 'PRBC') {
                $scope.isReadOnlyAnemia = false;

                $scope.isReadOnlyFibringen = false;
                $scope.isReadOnlyCoag = true;
                $scope.isReadOnlyAppt = true;
                $scope.isReadOnlyThrom = false;
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

        var getlast2 = '';
        var getfirst2 = '';
        
        $scope.Time_Click = function (time, chk) {

            getfirst2 = time.substr(0, 2);
            if (getfirst2.length===1) {
                getfirst2 = formatted_string('00', getfirst2, '1');
            }
             getlast2 = time.substring(2);
            if (getlast2.length !==2) {
                getlast2 = formatted_string('00', getlast2, '1');
            }
            if (chk ==='chkBox') {
                $scope.obj.T12300.T_CHECK_BOX_TIME = getfirst2 + ':' + getlast2;
            } else if (chk === 'reqst') {
                $scope.obj.T12300.T_REQUEST_TIME = getfirst2 + ':' + getlast2;
            }
           
        }
        $scope.New_Click = function () {
            $scope.obj.T12300.T_REQUEST_NO = ''; 
            $scope.obj.h.selected = '';
            $scope.obj.a.selected = '';
            $scope.obj.p.selected = '';
            $scope.obj.V.selected = '';
            $scope.obj.T12300.T_REQUEST_DATE = '';
            $scope.obj.T12300.REQUEST_HIJ_DATE = '';
            $scope.obj.T12300.T_REQUEST_TIME = '';
            $scope.obj.T12300.T_LOCATION_CODE = '';
            $scope.obj.T12300.T_WARD_NAME = '';
            $scope.obj.T12300.T_CHECK_BOX_DATE = '';
            $scope.obj.T12300.T_CHECK_BOX_TIME = '';
            $scope.obj.T12300.T_UNITNO = '';
            $scope.obj.T12300.T_SPI_IRRADIATED = '';
            $scope.obj.T12300.T_SPI_LEUKOCYTE = '';
            $scope.obj.T12300.T_SPI_VOL = '';
            $scope.obj.T12300.T_SPI_VOL_ML = '';
            $scope.obj.T12300.T_DOC_CODE = '';
            $scope.obj.T12300.DOCTOR_NAME_ENG = '';
            $scope.obj.T12300.T_CONSULTANT_CODE = '';
            $scope.obj.T12300.CONSULTANT_NAME_ENG = '';
            $scope.obj.T12300.T_CLINICAL_DIAGNOSIS = '';
            $scope.obj.T12300.T_ABO_CODE = '';
            $scope.obj.T12300.T_MTHR_BG_CODE = '';
            $scope.obj.T12300.T_MOTHER_BG_LANG_NAME = '';
            $scope.obj.T12300.LANG_NAME = '';
            //Details
            $scope.obj.T12300.T_ANEMIA_HB = '';
            $scope.obj.T12300.T_THROMBOCYTOPENIA = '';
            $scope.obj.T12300.T_COAGULOPATHY_PT = '';
            $scope.obj.T12300.T_COAGULOPATHY_APPT = '';
            $scope.obj.T12300.T_COAGULOPATHY_FIB = '';
            $scope.obj.T12300.T_OTHERS = '';
            $scope.obj.T12300.T_PREV_TRANSFUSION_YN = '';
            $scope.obj.T12300.T_PREV_PREGNANCIES_YN = '';
            $scope.obj.T12300.T_PREV_UN_EXPECTED_ANTIBODY = '';
            $scope.obj.T12300.T_POST_TRANSF_REACTION_YN = '';
            $scope.obj.T12300.T_TRANSFUSION_NONE = '';
            $scope.obj.T12300.T_NURSE_CODE = '';
            $scope.obj.T12300.NAME_NURSE = '';
            $scope.obj.T12300.NURSE_DATE = '';
            $scope.obj.T12300.NURSE_TIME = '';
            $scope.obj.T12300.T_VERIFIED_BY = '';
            $scope.obj.T12300.VERIFIED_NAME = '';
            $scope.obj.T12300.T_VERIFY_DATE = '';
            $scope.obj.T12300.T_VERIFY_TIME = '';
           
            //Emargency
            $scope.obj.T12300.T_X_MATCH_WITH_BLOOD = '';
            $scope.obj.T12300.T_X_MATCH_WITHOUT_BLOOD = '';
            $scope.obj.T12300.T_IMMEDIATE_SPIN_X = '';
            $scope.obj.T12300.T_SURGEON_CODE = ''; 
            $scope.obj.T12300.SURGEON_NAME = ''; 
            $scope.obj.T12300.T_BLEEP_NO = ''; 
            $scope.obj.T12300.T_SURGEON_DATE = ''; 
            $scope.obj.T12300.T_SURGEON_TIME = ''; 
           
        }
        $scope.Clear_Click = function() {
            $scope.obj.T12300 = {};
            $scope.obj.h.selected = '';
            $scope.obj.a.selected = '';
            $scope.obj.p.selected = '';
            $scope.obj.V.selected = '';
        }
        var getDay = '';
        var getMon = '';
        var getyea = '';

        $scope.Date_Click = function(date) {
            getDay = date.substring(0, 2);
            var getlast6 = date.substring(2);
            var mon = getlast6.substring(0, 2);
            getMon = month(mon);
            var ye = getlast6.substring(2);
            if (ye === "") {
                var ff = new Date();
                getyea = ff.getFullYear();
            } else {
                getyea = years(ye);
            }
            $scope.obj.T12300.T_CHECK_BOX_DATE = getDay + '-' + getMon + '-' + getyea;

            //var ff = new Date();
            //var year = ff.getFullYear();
            //var bb = ff.getMonth();
            //var day = ff.getDay();
        };
        function month(mon) {
            var m = '';
            if (mon==='01') {
                m = 'Jan';
            }
           else if (mon === '02') {
                m = 'Feb';
            }
            else if (mon === '03') {
                m = 'Mar';
            }
            else if (mon === '04') {
                m = 'Apr';
            }
            else if (mon === '05') {
                m = 'May';
            }
            else if (mon === '06') {
                m = 'Jun';
            }
            else if (mon === '07') {
                m = 'Jul';
            }
            else if (mon === '08') {
                m = 'Aug';
            }
            else if (mon === '09') {
                m = 'Sep';
            }
            else if (mon === '10') {
                m = 'Oct';
            }
            else if (mon === '11') {
                m = 'Nov';
            }
            else if (mon === '12') {
                m = 'Dec';
            } else {
               // alert('Month is not correct ');
                m = '00';
            }
            return m;
        }
        function years(ye) {
            var y = '';
            var yy = '';
            if (ye.length === 4) {
                y = ye;
            } else {
                 yy = ye.substring(0, 2);
                var dt = new Date();
                var fy = dt.getFullYear();
                var k = fy.toString();
              var f = k.substring(0, 2);
                y = f+yy;
            }
            return y;
        }
    }
]);