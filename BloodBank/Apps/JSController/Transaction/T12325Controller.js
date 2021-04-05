
app.controller("T12325Controller",
    [
        "$scope", "$timeout", "$filter", "T12325Service", "Data", "$window",
        function(scope, $timeout, $filter, T12325Service, Data, $window) {
            scope.obj = {};
            scope.obj = Data;


            scope.obj.Test = [];
            scope.NewListv = {};
            scope.obj.Test.push(scope.NewListv);
            scope.obj.VirusList = scope.obj.Test;
            scope.obj.T12325 = {};

            scope.CreatRow_Click = function(event) {
                if (event.keyCode === 114) {
                    event.preventDefault();
                    virusList();
                } else {
                    document.getElementById('txtDonationDate').focus();
                    //virusList();
                }

                //scope.NewListv = {};
                //scope.obj.Test.push(scope.NewListv);
                //scope.obj.TestList = scope.obj.Test;
                //scope.obj.Test = [];
            }
            scope.CheckUnitNo_Click = function(event, unit) {
                if (event.keyCode === 9) {
                    pickUpunitData(unit);
                }
                if (event.keyCode === 13) {
                    pickUpunitData(unit);
                }
                if (event.keyCode === 120) {
                    unitData();
                }

            }

            function pickUpunitData(unit) {
                var ckUnitNo = T12325Service.checkUnitNo(unit);
                ckUnitNo.then(function (data) {
                    var jsonData = JSON.parse(data);
                    if (jsonData.length > 0) {
                        if (jsonData[0].T_UNIT_NO === unit) {
                            scope.obj.T12325.T_UNIT_NO = jsonData[0].T_UNIT_NO;
                            scope.obj.T12325.T_DONATION_DATE = $filter('date')(jsonData[0].T_DONATION_DATE, 'dd-MMM-yyyy');
                            virusList();
                            // document.getElementById('txtDonationDate').focus();
                        } else {
                            alert('Unit No is not valid !!');
                            document.getElementById('txtUnitNo').focus();
                        }
                    } else {
                        alert('Unit No is not valid !!');
                        document.getElementById('txtUnitNo').focus();
                    }

                });
            }
            scope.Save_Click = function () {

                for (var i = 0; i < scope.obj.VirusList.length; i++) {
                    var d = i;
                    if (scope.obj.VirusList[i].CheckValue !== '1' || scope.obj.VirusList[i].T_RESULT_CODE === undefined || scope.obj.VirusList[i].T_RESULT_CODE === '') {
                        alert('All Result Should Be Entered; Check Row No ' + parseInt(d+1) + '');
                        return;
                    }
                }

                var un = scope.obj.T12325.T_UNIT_NO;
                var save = T12325Service.saveData(un, scope.obj.VirusList);
                save.then(function (data) {
                    alert(data);
                });
            }
            scope.NewResult = [];
            scope.Next_Click = function() {
                var showdata = T12325Service.getAllData(scope.obj.T12325.T_UNIT_NO);
                showdata.then(function(data) {
                    var jsonData = JSON.parse(data);
                    if (jsonData.length !== 0) {
                    scope.obj.T12325.T_DONATION_DATE = $filter('date')(jsonData[0].T_DONATION_DATE, 'dd-MMM-yyyy');
                    for (var i = 0; i < jsonData.length; i++) {
                        scope.rslObj = {};
                        scope.rslObj.T_VIRUS_CODE = jsonData[i].T_VIRUS_CODE;
                        scope.rslObj.VIRUS_NAME = jsonData[i].VIRUS_NAME;
                        scope.rslObj.T_RESULT_CODE = jsonData[i].T_VIRUS_RESULT;
                        if (jsonData[i].T_VIRUS_RESULT ==='M562') {
                            scope.rslObj.RESULT_NAME = 'Negative';
                        } else if (jsonData[i].T_VIRUS_RESULT === 'M563') {
                            scope.rslObj.RESULT_NAME = 'Reactive';
                        } else {
                            scope.rslObj.RESULT_NAME = '';
                        }
                      
                        scope.rslObj.BY_USER = jsonData[i].T_USER_NAME;
                        scope.rslObj.CheckValue = jsonData[i].T_TEST_VERIFY;
                        scope.rslObj.VERYFY_USER = jsonData[i].T_USER_NAME;
                        scope.rslObj.VERYFY_DATE = $filter('date')(jsonData[i].T_ENTRY_DATE, 'dd-MMM-yyyy'); 
                        scope.NewResult.push(scope.rslObj);
                    }
                    scope.obj.VirusList = scope.NewResult;
                    scope.NewResult = [];
                    } else {
                        scope.obj.T12325.T_UNIT_NO = '';
                        alert('Data Not found ');
                        scope.obj.Test = [];
                        scope.NewListv = {};
                        scope.obj.Test.push(scope.NewListv);
                        scope.obj.VirusList = scope.obj.Test;
                    }

                });
            }
            function virusList () {
                var virus = T12325Service.getVirus();
                virus.then(function (vi) {
                    var jsonData = JSON.parse(vi);
                    scope.obj.VirusList = jsonData;
                });
            }

            scope.UnitNewlist = [];
            scope.ShowUnitPopup = function () {
                unitData();
            }
            scope.setClickedRow_UnitNo = function(ind,data) {
                scope.obj.T12325.T_UNIT_NO = data.T_UNIT_NO;
                scope.obj.T12325.T_DONATION_DATE = data.T_DONATION_DATE;
                document.getElementById('UnitPopUp').style.display = "none";
                scope.Search = '';
                //virusList();
            }
            scope.ind = "";
            scope.ShowResultPopup = function (index, virusCode) {
                if (virusCode === "07" || virusCode === "09") {
                    scope.ind = index;
                    var result = T12325Service.gerVirusResult();
                    result.then(function (res) {
                        var jsonData = JSON.parse(res);
                        scope.obj.VirusResultList = jsonData;
                    });
                    document.getElementById('ResultPopUp').style.display = "block";
                }
               
            }
            scope.GetData_Click = function () {
                if (scope.obj.T12325.T_UNIT_NO === '' || scope.obj.T12325.T_UNIT_NO === undefined) {
                    alert('Fill up Unit No');
                    document.getElementById('txtUnitNo').focus();
                } else {
                    pickUpunitData(scope.obj.T12325.T_UNIT_NO);

                    virusList();
                }
              
            }
            //scope.ShowUnitPopup_keypress = function (event) {

            //    if (event.keyCode === 120) {
            //        unitData();
            //    }
                
            //}

            function unitData() {
                var unit = T12325Service.getUnitNo();
                unit.then(function (unitno) {
                    var jsonData = JSON.parse(unitno);
                    for (var i = 0; i < jsonData.length; i++) {
                        scope.newObj = {};
                        scope.newObj.T_UNIT_NO = jsonData[i].T_UNIT_NO;
                        scope.newObj.T_DONATION_DATE = $filter('date')(jsonData[i].T_DONATION_DATE, 'dd-MMM-yyyy');
                        scope.UnitNewlist.push(scope.newObj);

                    }
                    scope.obj.UnitList = scope.UnitNewlist;
                    scope.UnitNewlist = [];
                });

                document.getElementById('UnitPopUp').style.display = "block";
            }

            var indexNo = '';
            scope.GetVirus_Click = function(ind, popup) {
                indexNo = ind;
                document.getElementById(popup).style.display = "block";
            }
            scope.ClosePatientPopup = function(popup) {
                document.getElementById(popup).style.display = "none";
            }

            scope.NewList = [];
            scope.setClickedRow = function(index, data, popup) {
                scope.selectedRow = index;
                var lenth = scope.obj.TestList.length;
                for (var i = 0; i < scope.obj.TestList.length; i++) {
                    if (scope.obj.TestList[i].T_VIRUS_CODE === data.T_VIRUS_CODE) {
                        alert("Virus is already exist !!");
                        document.getElementById(popup).style.display = "none";
                        scope.NewList = [];
                        return;
                    } else {
                        scope.NewObject = {};
                        if (i === indexNo) {
                            scope.NewObject.T_VIRUS_CODE = data.T_VIRUS_CODE;
                            scope.NewObject.VIRUS_NAME = data.VIRUS_NAME;
                            scope.NewObject.RESULT_NAME = scope.obj.TestList[i].RESULT_NAME;
                            scope.NewObject.T_RESULT_CODE = scope.obj.TestList[i].T_RESULT_CODE;
                            scope.NewList.push(scope.NewObject);
                        } else {
                            scope.NewObject.T_VIRUS_CODE = scope.obj.TestList[i].T_VIRUS_CODE;
                            scope.NewObject.VIRUS_NAME = scope.obj.TestList[i].VIRUS_NAME;
                            scope.NewObject.RESULT_NAME = scope.obj.TestList[i].RESULT_NAME;
                            scope.NewObject.T_RESULT_CODE = scope.obj.TestList[i].T_RESULT_CODE;
                            scope.NewList.push(scope.NewObject);
                        }
                        if (i + 1 === lenth) {
                            if (indexNo + 1 === lenth) {
                                scope.NewList.push('');
                                //scope.isDisabled = true;
                               // angular.element(document.getElementById('btnCancel')).disabled = true;
                                //document.getElementById('btnCancel' + indexNo)[0].disabled = true;
                            }
                        }
                    }
                }
                scope.obj.TestList = scope.NewList;
                scope.NewList = [];
                document.getElementById(popup).style.display = "none";
                // string user = HttpContext.Current.Session["T_ENTRY_USER"].ToString();
                //scope.obj.VirusList = [];
            }
            scope.setClickedVirusResultRow = function (index, data) {
                scope.selectedRow = index;
                scope.obj.VirusList[scope.ind].T_RESULT_CODE=  data.T_RESULT_CODE;
                scope.obj.VirusList[scope.ind].RESULT_NAME = data.T_LANG_NAME;
                document.getElementById('ResultPopUp').style.display = "none";
            }




            scope.NewList = [];
            scope.SetResult_Click = function (event, ind, value,virCode) {
                if (event.keyCode === 9) {
                    if (virCode === '07' || virCode === '09') {
                        setData(ind, value);
                    } 
                } else if (event.keyCode === 13) {
                    if (virCode === '07' || virCode === '09') {
                        setData(ind, value);
                    }
                }
            }
            function setData(ind, value) {
                var result = T12325Service.getResulDes(value);
                result.then(function (re) {
                    var jsonData = JSON.parse(re);
                    if (jsonData.length > 0) {

                    for (var i = 0; i < scope.obj.VirusList.length; i++) {
                        scope.NewObject = {};
                        if (i === ind) {
                            scope.NewObject.T_VIRUS_CODE = scope.obj.VirusList[i].T_VIRUS_CODE;
                            scope.NewObject.VIRUS_NAME = scope.obj.VirusList[i].VIRUS_NAME;
                            if (jsonData.length > 0) {
                                scope.NewObject.RESULT_NAME = jsonData[0].RESULT_NAME;
                                scope.NewObject.T_RESULT_CODE = jsonData[0].T_RESULT_CODE;
                            } else {
                                scope.NewObject.RESULT_NAME = scope.obj.VirusList[i].RESULT_NAME;
                                scope.NewObject.T_RESULT_CODE = scope.obj.VirusList[i].T_RESULT_CODE;
                            }
                            scope.NewObject.BY_USER = scope.obj.VirusList[i].BY_USER;
                            scope.NewObject.CheckValue = scope.obj.VirusList[i].CheckValue;
                            scope.NewObject.VERYFY_USER = scope.obj.VirusList[i].VERYFY_USER;
                            scope.NewObject.VERYFY_DATE = scope.obj.VirusList[i].VERYFY_DATE;
                            scope.NewList.push(scope.NewObject);
                        } else {
                            scope.NewObject.T_VIRUS_CODE = scope.obj.VirusList[i].T_VIRUS_CODE;
                            scope.NewObject.VIRUS_NAME = scope.obj.VirusList[i].VIRUS_NAME;
                            scope.NewObject.RESULT_NAME = scope.obj.VirusList[i].RESULT_NAME;
                            scope.NewObject.T_RESULT_CODE = scope.obj.VirusList[i].T_RESULT_CODE;
                            scope.NewObject.BY_USER = scope.obj.VirusList[i].BY_USER;
                            scope.NewObject.CheckValue = scope.obj.VirusList[i].CheckValue;
                            scope.NewObject.VERYFY_USER = scope.obj.VirusList[i].VERYFY_USER;
                            scope.NewObject.VERYFY_DATE = scope.obj.VirusList[i].VERYFY_DATE;
                            scope.NewList.push(scope.NewObject);
                        }
                        }
                        scope.obj.VirusList = scope.NewList;
                        scope.NewList = [];

                  } else {
                        alert('Result is not correct');
                        scope.obj.VirusList[ind].RESULT_NAME = '';
                        scope.obj.VirusList[ind].T_RESULT_CODE = '';
                    }

                   
                    //scope.obj.VirusList = jsonData;
                });
            }

            scope.SecondList = [];
            scope.chekBox_Click = function(ind) {
                for (var i = 0; i < scope.obj.VirusList.length; i++) {
                    var chk = scope.obj.VirusList[i].CheckValue;
                    scope.NewObject = {};
                    if (chk==='1') {
                        if (i === ind) {
                            scope.NewObject.T_VIRUS_CODE = scope.obj.VirusList[i].T_VIRUS_CODE;
                            scope.NewObject.VIRUS_NAME = scope.obj.VirusList[i].VIRUS_NAME;
                            scope.NewObject.RESULT_NAME = scope.obj.VirusList[i].RESULT_NAME;
                            scope.NewObject.T_RESULT_CODE = scope.obj.VirusList[i].T_RESULT_CODE;
                            scope.NewObject.BY_USER = scope.obj.VirusList[i].BY_USER;
                            scope.NewObject.CheckValue = '1';
                            scope.NewObject.VERYFY_USER = scope.obj.VirusList[i].BY_USER;
                            scope.NewObject.VERYFY_DATE = $filter('date')(new Date(), 'dd-MMM-yyyy');
                            //document.getElementById('chekValue'+ind).checked = true;
                            scope.SecondList.push(scope.NewObject);
                        } else {
                            scope.NewObject.T_VIRUS_CODE = scope.obj.VirusList[i].T_VIRUS_CODE;
                            scope.NewObject.VIRUS_NAME = scope.obj.VirusList[i].VIRUS_NAME;
                            scope.NewObject.RESULT_NAME = scope.obj.VirusList[i].RESULT_NAME;
                            scope.NewObject.T_RESULT_CODE = scope.obj.VirusList[i].T_RESULT_CODE;
                            scope.NewObject.BY_USER = scope.obj.VirusList[i].BY_USER;
                            scope.NewObject.CheckValue = scope.obj.VirusList[i].CheckValue;
                            scope.NewObject.VERYFY_USER = scope.obj.VirusList[i].VERYFY_USER;
                            scope.NewObject.VERYFY_DATE = scope.obj.VirusList[i].VERYFY_DATE;
                            //document.getElementById('chekValue' + ind).checked = false;
                            scope.SecondList.push(scope.NewObject);
                        }  
                    } else {
                        if (i === ind) {
                            scope.NewObject.T_VIRUS_CODE = scope.obj.VirusList[i].T_VIRUS_CODE;
                            scope.NewObject.VIRUS_NAME = scope.obj.VirusList[i].VIRUS_NAME;
                            scope.NewObject.RESULT_NAME = scope.obj.VirusList[i].RESULT_NAME;
                            scope.NewObject.T_RESULT_CODE = scope.obj.VirusList[i].T_RESULT_CODE;
                            scope.NewObject.BY_USER = scope.obj.VirusList[i].BY_USER;
                            scope.NewObject.CheckValue = '';
                            scope.NewObject.VERYFY_USER = '';
                            scope.NewObject.VERYFY_DATE = '';
                            //document.getElementById('chekValue'+ind).checked = true;
                            scope.SecondList.push(scope.NewObject);
                        } else {
                            scope.NewObject.T_VIRUS_CODE = scope.obj.VirusList[i].T_VIRUS_CODE;
                            scope.NewObject.VIRUS_NAME = scope.obj.VirusList[i].VIRUS_NAME;
                            scope.NewObject.RESULT_NAME = scope.obj.VirusList[i].RESULT_NAME;
                            scope.NewObject.T_RESULT_CODE = scope.obj.VirusList[i].T_RESULT_CODE;
                            scope.NewObject.BY_USER = scope.obj.VirusList[i].BY_USER;
                            scope.NewObject.CheckValue = scope.obj.VirusList[i].CheckValue;
                            scope.NewObject.VERYFY_USER = scope.obj.VirusList[i].VERYFY_USER;
                            scope.NewObject.VERYFY_DATE = scope.obj.VirusList[i].VERYFY_DATE;
                            //document.getElementById('chekValue' + ind).checked = false;
                            scope.SecondList.push(scope.NewObject);
                        }  
                    }
                   
                }
                scope.obj.VirusList = scope.SecondList;
                scope.SecondList = [];

            }
            scope.VerifyAll_Click = function() {
                for (var i = 0; i < scope.obj.VirusList.length; i++) {
                    scope.NewObject = {};
                    if (scope.obj.VirusList[i].T_RESULT_CODE !==undefined) {
                    scope.NewObject.T_VIRUS_CODE = scope.obj.VirusList[i].T_VIRUS_CODE;
                    scope.NewObject.VIRUS_NAME = scope.obj.VirusList[i].VIRUS_NAME;
                    scope.NewObject.RESULT_NAME = scope.obj.VirusList[i].RESULT_NAME;
                    scope.NewObject.T_RESULT_CODE = scope.obj.VirusList[i].T_RESULT_CODE;
                    scope.NewObject.BY_USER = scope.obj.VirusList[i].BY_USER;
                    scope.NewObject.CheckValue = '1';
                    scope.NewObject.VERYFY_USER = scope.obj.VirusList[i].BY_USER;
                    scope.NewObject.VERYFY_DATE = $filter('date')(new Date(), 'dd-MMM-yyyy');
                    //document.getElementById('chekValue'+ind).checked = true;
                    scope.SecondList.push(scope.NewObject);
                    } else {
                        scope.NewObject.T_VIRUS_CODE = scope.obj.VirusList[i].T_VIRUS_CODE;
                        scope.NewObject.VIRUS_NAME = scope.obj.VirusList[i].VIRUS_NAME;
                        scope.NewObject.RESULT_NAME = scope.obj.VirusList[i].RESULT_NAME;
                        scope.NewObject.T_RESULT_CODE = scope.obj.VirusList[i].T_RESULT_CODE;
                        scope.NewObject.BY_USER = scope.obj.VirusList[i].BY_USER;
                        scope.NewObject.CheckValue = '';
                       // scope.NewObject.VERYFY_USER = scope.obj.VirusList[i].BY_USER;
                      //  scope.NewObject.VERYFY_DATE = $filter('date')(new Date(), 'dd-MMM-yyyy');
                        //document.getElementById('chekValue'+ind).checked = true;
                        scope.SecondList.push(scope.NewObject);
                    }
                }
                scope.obj.VirusList = scope.SecondList;
                scope.SecondList = [];

                //for saving start 
                for (var i = 0; i < scope.obj.VirusList.length; i++) {
                    var d = i;
                    if (scope.obj.VirusList[i].CheckValue !== '1' || scope.obj.VirusList[i].T_RESULT_CODE === undefined || scope.obj.VirusList[i].T_RESULT_CODE === '') {
                        alert('All Result Should Be Entered; Check Row No ' + parseInt(d + 1) + '');
                        return;
                    }
                }

                var un = scope.obj.T12325.T_UNIT_NO;
                var save = T12325Service.saveData(un, scope.obj.VirusList);
                save.then(function (data) {
                    alert(data);
                });
                //for saving end 





            }
            scope.Remove_Click = function(index) {
                scope.obj.VirusList.splice(index, 1);
                //var len = scope.obj.VirusList.length;
                //if (len != index+1) {
                //    scope.obj.VirusList.splice(index, 1);

                //}
            };
            scope.Clear = function() {
                scope.obj.T12325.T_UNIT_NO = '';
                scope.obj.T12325.T_DONATION_DATE = '';
               // scope.obj.VirusList = [];
                scope.obj.Test = [];
                scope.NewListv = {};
                scope.obj.Test.push(scope.NewListv);
                scope.obj.VirusList = scope.obj.Test;
            };

            scope.UnitValidate = function (unitNumber) {
                CheckUnit(unitNumber);
            }
            function CheckUnit(unitNo) {
                if (unitNo !== "") {
                    if (unitNo.substr(0, 1) !== '=') {
                        scope.obj.T12325.T_UNIT_NO = '';
                        alert('Wrong Unit No');
                        return;
                    }
                    var bloodUnitData = T12325Service.getUnitData(unitNo);
                    bloodUnitData.then(function (data) {
                        var bloodUnit = JSON.parse(data);
                        if (bloodUnit === null) {
                            alert('Wrong Unit No');
                            return;
                        }
                    });
                   scope.obj.T12325.T_UNIT_NO = unitNo.substr(1, 13);
                }//first if end

            }//function end
        }
    ]);
app.filter('startFrom', function () {
    return function (input, start) {
        start = +start; //parse to int
        return input.slice(start);
    }
});