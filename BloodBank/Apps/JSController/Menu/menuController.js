app.controller("menuController",
    [
        "$scope", "$window", "menuService", "$location", "LoginService", "$filter", "$timeout", "vrtlDirr",
        function ($scope, $window, menuService, $location, LoginService,  $filter, $timeout, vrtlDirr) {
            
            $scope.backPage = function(e) {
                if (e.which == 35) {
                    $scope.Back();
                }
                
            }
            $scope.pageSize = 10;
            $scope.currentPage = 1;

            $scope.PagiIndex = function (e, c) {
                return e + (c - 1) * $scope.pageSize;
            }
            
            $scope.vrDir = vrtlDirr;
            function columnize(input, cols) {
                var arr = [];
                for (i = 0; i < input.length; i++) {
                    var colIdx = i % cols;
                    arr[colIdx] = arr[colIdx] || [];
                    arr[colIdx].push(input[i]);
                }
                return arr;
            }

            function switch_style(cssTitle) {
                var i, linkTag;
                for (i = 0, linkTag = document.getElementsByTagName("link"); i < linkTag.length; i++) {
                    if ((linkTag[i].rel.indexOf("stylesheet") !== -1) && linkTag[i].title) {
                        linkTag[i].disabled = true;
                        if (linkTag[i].title === cssTitle) {
                            linkTag[i].disabled = false;
                        }
                    }
                }
            }
            var chk_session = JSON.parse(sessionStorage.getItem("msg"));
            if (chk_session == null) {
                var msg = menuService.GetAllUserMsg();
                msg.then(function (data) {
                    sessionStorage.setItem("msg", JSON.stringify(JSON.parse(data)));
                });
            }

            var connectionString = menuService.getServerName();
            connectionString.then(function (data) {
                var dt = data.slice(62, 65);
                $scope.servername = dt.toUpperCase();
                console.log(dt.toUpperCase());
            });
            

            function User() {
                var userName = menuService.UserName();
                userName.then(function (data) {
                    $scope.UserName = JSON.parse(data);
                    sessionStorage.setItem("UserName", JSON.stringify($scope.UserName));
                });
            }
            function EmpCode() {
                var empCode = menuService.EmpCode();
                empCode.then(function (data) {
                    $scope.EmpCode = JSON.parse(data);
                    sessionStorage.setItem("EmpCode", JSON.stringify($scope.EmpCode));
                });
            }

            $scope.Menu = function (e) {
                //languageData();
                EmpCode();
                User();
                //var loginUserData = sessionStorage.getItem("T_LOGIN_NAME");
                var lang = JSON.parse(sessionStorage.getItem("LangName"));
                if (lang === null || lang == '2') {
                    lang = '2';
                    var Setup = menuService.menudata(lang, e);
                    Setup.then(function (data) {

                        var dt = JSON.parse(data);
                        $scope.labelOption1 = "Transaction";
                        $scope.labelOption2 = "Report";
                        $scope.labelOption3 = "Initialization";
                        $scope.labelOption4 = "Back";
                        $scope.labelOption5 = "Logout";
                        $scope.labelOption6 = "Query";
                        $scope.title1 = "National Electronic";
                        $scope.title2 = "Blood Bank";
                        $scope.FCode = "Menu";
                        $scope.FName = "Menu Information";
                        if (e === 1) {
                            $scope.Labelmsg = "Transaction";
                            $scope.labelLink = "Transaction";
                            $scope.menus = columnize(dt, 50);
                            countRequest();
                        } else if (e === 2) {
                            $scope.Labelmsg = "Initialization";
                            $scope.labelLink = "Initialization";
                            $scope.menus = columnize(dt, 14);
                        } else if (e === 3) {
                            $scope.Labelmsg = "Report";
                            $scope.labelLink = "Report";
                            $scope.menus = columnize(dt, 14);
                        }
                        else if (e === 4) {
                            $scope.Labelmsg = "Query";
                            $scope.labelLink = "Query";
                            $scope.menus = columnize(dt, 14);
                        }
                    });
                } else {
                    //var lang = JSON.parse(sessionStorage.getItem("LangName"));
                    var Setup = menuService.menudata(lang, e);
                    Setup.then(function (data) {
                        var dt = JSON.parse(data);
                        $scope.labelOption1 = "عملية تجارية";
                        $scope.labelOption2 = "أبلغ عن";
                        $scope.labelOption3 = "التهيئة";
                        $scope.labelOption4 = "الى الخلف";
                        $scope.labelOption5 = "الخروج";
                        $scope.labelOption6 = "سؤال";
                        $scope.title1 = "الوطنية الالكترونية";
                        $scope.title2 = "بنك الدم";
                        $scope.FCode = "قائمة طعام";
                        $scope.FName = "معلومات القائمة";
                        if (e === 1) {
                            $scope.Labelmsg = "عملية تجارية";
                            $scope.labelLink = "Transaction";
                            $scope.menus = columnize(dt, 55);
                        } else if (e === 2) {
                            $scope.Labelmsg = "التهيئة";
                            $scope.labelLink = "Initialization";
                            $scope.menus = columnize(dt, 14);
                        } else if (e === 3) {
                            $scope.Labelmsg = "أبلغ عن";
                            $scope.labelLink = "Report";
                            $scope.menus = columnize(dt, 14);
                        }
                        else if (e === 4) {
                            $scope.Labelmsg = "سؤال";
                            $scope.labelLink = "Query";
                            $scope.menus = columnize(dt, 14);
                        }
                    });
                }
               
            };
            
            var url = JSON.parse(sessionStorage.getItem("url"));
            $scope.BackURL = url === null ? "Transaction" : url;
            $scope.BackInit = function (e) {
                if (e === "Transaction") {
                    return $scope.Menu(1);
                } else if (e === "Initialization") {
                    return $scope.Menu(2);
                } else if (e === "Report") {
                    return $scope.Menu(3);
                } else if (e === "Query") {
                    return $scope.Menu(4);
                } else {
                    return $scope.Menu(1);
                }
            }
            $scope.test = function () {
                var user = JSON.parse(sessionStorage.getItem("UserName"));
                $scope.UserName = user;
                var lang = JSON.parse(sessionStorage.getItem("LangName"));
                if (lang === null || lang == '2') {
                    lang = '2';
                    $scope.HeadTitle1 = "National Electronic";
                    $scope.HeadTitle2 = "BLOOD BANK";

                } else {
                    $scope.HeadTitle1 = "الوطنية الالكترونية";
                    $scope.HeadTitle2 = "بنك الدم";
                }
                $scope.lang = lang;
                if ($scope.lang == '2') {
                    switch_style('eng');
                    $scope.topbarbg = 'topbarbg';
                    $scope.topbarseparator = 'topbarseparator';
                    $scope.leftpanelbg = 'leftpanelbg';
                    $scope.pageleftpanelbg = 'pageleftpanelbg';
                }
                else if ($scope.lang == '1') {
                    switch_style('arb');
                    $scope.topbarbg = 'topbarbgarb';
                    $scope.topbarseparator = 'topbarseparatorarb';
                    $scope.leftpanelbg = 'leftpanelbgarb';
                    $scope.pageleftpanelbg = 'pageleftpanelbgarb';
                }
            }
            $scope.Logout = function () {
                var a = $location.absUrl().split('/')[2].split('?')[0];
                var logout = menuService.UserLogout();
                logout.then(function (data) {
                    sessionStorage.clear();
                    $window.location = "http://" + a + $scope.vrDir;
                });
            };
            $scope.Back = function () {
                var i = 0;
                if ($scope.vrDir != '') {
                    i = 5;
                } else {
                    i = 4;
                }
                var a = $location.absUrl().split('/')[i].split('?')[0];
                $scope.FFlag = JSON.parse(sessionStorage.getItem("FFlag"));
                $scope.reqPage = JSON.parse(sessionStorage.getItem("FReqCode"));
                if ($scope.FFlag == null || $scope.reqPage == null) {
                    var url = $location.absUrl().split('/')[i - 1];
                    sessionStorage.setItem("url", JSON.stringify(url));
                    $window.location = $scope.vrDir + "/Menu/Index";
                } else {
                    $scope.lang = JSON.parse(sessionStorage.getItem("LangName")) == undefined
                        ? 2
                        : JSON.parse(sessionStorage.getItem("LangName"));
                    var name;
                    if ($scope.lang == "2") {
                        if (a === "T12214") {

                            if ($scope.reqPage === "T12201") {
                                sessionStorage.setItem("FCode", JSON.stringify("T12201"));
                                name = $scope.lang === '1' ? "طلب المانح" : "Donor Request";
                                sessionStorage.setItem("FName", JSON.stringify(name));
                            } else if ($scope.reqPage === "T12250") {
                                sessionStorage.setItem("FCode", JSON.stringify("T12250"));
                                name = $scope.lang === '1' ? "تسجيل الحملا" : "Hamla Registration";
                                sessionStorage.setItem("FName", JSON.stringify(name));
                            }
                            var labelData = menuService.GetLabelText($scope.reqPage, $scope.lang);
                            labelData.then(function (data) {
                                $scope.entity = JSON.parse(data);
                                sessionStorage.setItem("LabelData", JSON.stringify($scope.entity));
                                sessionStorage.setItem("FFlag", null);
                                var PatNo = JSON.parse(sessionStorage.getItem("PatNo"));
                                sessionStorage.setItem("PatNo", JSON.stringify(PatNo));
                                $window.location = $scope.vrDir + "/Transaction/" + $scope.reqPage;
                            });
                        }
                        else if (a === "T12300") {
                            sessionStorage.setItem("FCode", JSON.stringify("T12300"));
                            name = $scope.lang === '1' ? "طلب الدم للمريض" : " Blood Request for Patient";
                            sessionStorage.setItem("FName", JSON.stringify(name));

                            var labelData = menuService.GetLabelText($scope.reqPage, $scope.lang);
                            labelData.then(function (data) {
                                $scope.entity = JSON.parse(data);
                                sessionStorage.setItem("LabelData", JSON.stringify($scope.entity));
                                sessionStorage.setItem("FFlag", null);
                                var PatNo = JSON.parse(sessionStorage.getItem("PatNo"));
                                sessionStorage.setItem("PatNo", JSON.stringify(PatNo));
                                $window.location = $scope.vrDir + "/Transaction/" + $scope.reqPage;
                            });
                        }
                        else if (a === "Q12012") {
                            sessionStorage.setItem("FCode", JSON.stringify("T12302"));
                            name = $scope.lang === '1' ? "اكتب وشاشة ومباراة متطابقة" : " Type & Screen and Crossmatch";
                            sessionStorage.setItem("FName", JSON.stringify(name));

                            var labelData = menuService.GetLabelText($scope.reqPage, $scope.lang);
                            labelData.then(function (data) {
                                $scope.entity = JSON.parse(data);
                                sessionStorage.setItem("LabelData", JSON.stringify($scope.entity));
                                sessionStorage.setItem("FFlag", null);
                                var PatNo = JSON.parse(sessionStorage.getItem("PatNo"));
                                sessionStorage.setItem("PatNo", JSON.stringify(PatNo));
                                $window.location = $scope.vrDir + "/Transaction/" + $scope.reqPage;
                            });
                        }
                    } else {
                        if (a === "T12213") {

                            if ($scope.reqPage === "T12201") {
                                sessionStorage.setItem("FCode", JSON.stringify("T12201"));
                                name = $scope.lang === '1' ? "طلب المانح" : "Donor Request";
                                sessionStorage.setItem("FName", JSON.stringify(name));
                            } else if ($scope.reqPage === "T12250") {
                                sessionStorage.setItem("FCode", JSON.stringify("T12250"));
                                name = $scope.lang === '1' ? "تسجيل الحملا" : "Hamla Registration";
                                sessionStorage.setItem("FName", JSON.stringify(name));
                            }
                            var labelData2 = menuService.GetLabelText($scope.reqPage, $scope.lang);
                            labelData2.then(function (data) {
                                $scope.entity = JSON.parse(data);
                                sessionStorage.setItem("LabelData", JSON.stringify($scope.entity));
                                sessionStorage.setItem("FFlag", null);
                                var PatNo = JSON.parse(sessionStorage.getItem("PatNo"));
                                sessionStorage.setItem("PatNo", JSON.stringify(PatNo));
                                $window.location = $scope.vrDir + "/Transaction/" + $scope.reqPage;
                            });
                        }
                        else if (a === "T12300") {
                            sessionStorage.setItem("FCode", JSON.stringify("T12300"));
                            name = $scope.lang === '1' ? "طلب الدم للمريض" : " Blood Request for Patient";
                            sessionStorage.setItem("FName", JSON.stringify(name));

                            var labelData3 = menuService.GetLabelText($scope.reqPage, $scope.lang);
                            labelData3.then(function (data) {
                                $scope.entity = JSON.parse(data);
                                sessionStorage.setItem("LabelData", JSON.stringify($scope.entity));
                                sessionStorage.setItem("FFlag", null);
                                var PatNo = JSON.parse(sessionStorage.getItem("PatNo"));
                                sessionStorage.setItem("PatNo", JSON.stringify(PatNo));
                                $window.location = $scope.vrDir + "/Transaction/" + $scope.reqPage;
                            });
                        }
                        else if (a === "Q12012") {
                            sessionStorage.setItem("FCode", JSON.stringify("T12302"));
                            name = $scope.lang === '1' ? "اكتب وشاشة ومباراة متطابقة" : " Type & Screen and Crossmatch";
                            sessionStorage.setItem("FName", JSON.stringify(name));

                            var labelData3 = menuService.GetLabelText($scope.reqPage, $scope.lang);
                            labelData3.then(function (data) {
                                $scope.entity = JSON.parse(data);
                                sessionStorage.setItem("LabelData", JSON.stringify($scope.entity));
                                sessionStorage.setItem("FFlag", null);
                                var PatNo = JSON.parse(sessionStorage.getItem("PatNo"));
                                sessionStorage.setItem("PatNo", JSON.stringify(PatNo));
                                $window.location = $scope.vrDir + "/Transaction/" + $scope.reqPage;
                            });
                        }
                    }
                }
            }
            //countRequest();
            setInterval(function () {
                countRequest();
            }, 10000);
          function countRequest() {
                var RequestToDeliveryMan = menuService.GetRequestListData();
                RequestToDeliveryMan.then(function (data) {
                    $scope.ReqCount = JSON.parse(data);
                    if ($scope.ReqCount.length > 0) {
                        $scope.ddd = $scope.menus[0];
                        if ($scope.ddd[0].LINK_LABEL == "Blood Request Delivery") {
                            $scope.rr = $scope.ReqCount.length;
                        }
                    }
                });
            }
          $scope.whatClassIsIt = function (someValue) {
              if (someValue != '' && someValue != undefined)
                  return "ClassA"
          }
            $scope.FormName = function (data, labelLink) {
                
                sessionStorage.setItem("FCode", JSON.stringify(data.T_LINK_TEXT));
                sessionStorage.setItem("FName", JSON.stringify(data.LINK_LABEL));
                //Label Data-------------------------------------
                $scope.lang = JSON.parse(sessionStorage.getItem("LangName")) == undefined
                    ? 2
                    : JSON.parse(sessionStorage.getItem("LangName"));
                $scope.labelData = menuService.GetLabelText(data.T_LINK_TEXT, $scope.lang);
                $scope.labelData.then(function (dt) {
                    $scope.entity = JSON.parse(dt);
                    sessionStorage.setItem("LabelData", JSON.stringify($scope.entity));
                    sessionStorage.setItem("FFlag", null);
                    sessionStorage.setItem("PatNo", null);
                    
                    var msg = menuService.updateForm(data.T_LINK_TEXT);
                    msg.then(function (dt) {
                        chkForm = JSON.parse(dt) == 'OK' ? false : true;
                        $window.location = $scope.vrDir + "/" + labelLink + "/" + data.T_LINK_TEXT;
                    }).catch(function (ex) {
                        $window.location = $scope.vrDir + "/" + labelLink + "/" + data.T_LINK_TEXT;
                    });

                });

            }
            //---------------------------For Page Load Functions--------------------------------
            $scope.FCode = JSON.parse(sessionStorage.getItem("FCode"));
            $scope.FName = JSON.parse(sessionStorage.getItem("FName"));
            $scope.EmpCode = JSON.parse(sessionStorage.getItem("EmpCode"));
            var nationalId = JSON.parse(sessionStorage.getItem("NationalId"));

            $scope.getSingleMsg = function (e) {
                var obj = $filter('filter')(JSON.parse(sessionStorage.getItem("msg")), { T_MSG_CODE: e }, true)[0];
                return obj.MSG;
            }

            $scope.getLabel = function (e) {
                var obj = $filter('filter')(JSON.parse(sessionStorage.getItem("LabelData")),
                    { T_CONTROL_NAME: e },
                    true)[0];
                return obj.T_CONTROL_TEXT;
            }
            $scope.dateParse = function (p, sl) {
                var dateParts = p.split(sl);
                var dateObject = new Date(dateParts[2], dateParts[1] - 1, dateParts[0]);
                var result = $filter('date')(dateObject, "dd/MMM/yyyy");
                return result;

            }
            $scope.calculateAge = function calculateAge(birthday) {
                var a = new Date(birthday);
                var ageDifMs = Date.now() - a.getTime();
                var ageDate = new Date(ageDifMs); // miliseconds from epoch
                return Math.abs(ageDate.getUTCFullYear() - 1970);
            }
            $scope.calculateMonth = function calculateMonth(birthday) {
                var a = new Date(birthday);
                var b = new Date(Date.now());
                var months;
                months = ((b.getFullYear() - a.getFullYear()) * 12) % 12;
                months -= a.getMonth() + 1;
                months += b.getMonth() + 1;
                return months <= 0 ? 0 : months;
            }
            $scope.pad = function pad(n, pl, pc) {
                var padChar = typeof pc != 'undefined' ? pc : '0';
                var lpad = new Array(1 + pl).join(padChar);
                return (lpad + n).slice(-lpad.length);
            }
            $scope.nglabel = function (p) {
                $scope.$broadcast(p);
            }
            $scope.loader = function (p) {
                $scope.loading = p === undefined ? false : p;
                return $scope.loading;
            }
            $scope.la = JSON.parse(sessionStorage.getItem("LangName"));
            changeAlignment($scope.la);
            function changeAlignment(l) {

                if (l == 2) {
                    $('.alnR').css({ "text-align": "right" });
                    $('.alnL').css({ "text-align": "left" });
                }
                else if (l == 1) {
                    $('.alnR').css({ "text-align": "left" });
                    $('.alnL').css({ "text-align": "right" });
                }
            }
            $scope.ale = { "text-align": "left" }
            $scope.ala = { "text-align": "right" }
            $scope.changeAlignment = function (la) {
                changeAlignment(la);
            }

            //---------------------FOR GET DATE FROM YEAR AND MONTH-----CODED BY ROMAN-------------------------------------
            $scope.getBirthDate = function (y, m) {
                y = y == null ? 0 : y;
                m = m == null ? 0 : m;
                //var birthyear = (new Date()).getFullYear() - y;
                //m = m == '' ? '12' : m;
                var birthDate = moment().subtract(y, 'years').subtract(m, 'months');
                var result = $filter('date')(new Date(birthDate), "dd/MM/yyyy");
                //var a = birthDate.format("DD/MM/YYYY");
                //var birthMonth = new Date(birthyear, m, 0).getDate();
                return result;
            }
            //GET ENGLISH DATE TO ARABIC DATE
            $scope.getBirthDateArb = function (d) {
                var k = $scope.dateParse(d, "/");
                var n = Date.parse(k);
                return moment(n).format('iDD/iMM/iYYYY');
            }
            //Date Right with hand
            $scope.DatewrOnHand = function (d) {
                if (d.length === 4) {
                    var birthdate = d.substring(0, 1);
                    //birthdate = birthdate > 31 ? 31 : birthdate;
                    var birthmonth = d.substring(1, 2);
                    var birthyear = d.substring(2, 4);
                    var currentyear = new Date().getFullYear().toString().substr(-2);
                    if (currentyear < birthyear) {
                        d = '0' + birthdate + '/' + '0' + birthmonth + '/' + '19' + birthyear;
                    } else {
                        d = '0' + birthdate + '/' + '0' + birthmonth + '/' + '20' + birthyear;
                    }

                }
                if (d === 5) {
                    var birthdate = d.substring(0, 1);
                    var birthmonth = d.substring(1, 3);
                    var birthyear = d.substring(3, 5);
                    var currentyear = new Date().getFullYear().toString().substr(-2);
                    if (currentyear < birthyear) {
                        d = '0' + birthdate + '/' + birthmonth + '/' + '19' + birthyear;
                    } else {
                        d = '0' + birthdate + '/' + birthmonth + '/' + '20' + birthyear;
                    }

                }
                if (d.length === 6) {
                    var birthdate = d.substring(0, 2);
                    var birthmonth = d.substring(2, 4);
                    var birthyear = d.substring(4, 6);
                    var currentyear = new Date().getFullYear().toString().substr(-2);
                    if (currentyear < birthyear) {
                        d = birthdate + '/' + birthmonth + '/' + '19' + birthyear;
                    } else {
                        d = birthdate + '/' + birthmonth + '/' + '20' + birthyear;
                    }
                }
                if (d.length === 8) {
                    var birthdate = d.substring(0, 2);
                    var birthmonth = d.substring(2, 4);
                    var birthyear = d.substring(4, 8);
                    var currentyear = new Date().getFullYear().toString().substr(-2);
                    if (currentyear < birthyear) {
                        d = birthdate + '/' + birthmonth + '/' + '19' + birthyear;
                    } else {
                        d = birthdate + '/' + birthmonth + '/' + '20' + birthyear;
                    }
                }
                return d;
            }

            $scope.ddlfocusLost = function (e) {
                $timeout(function () {
                    $(':focus').blur();
                    document.getElementById(e).focus();
                });
            }
            $scope.designChange = function (l) {
                var user = JSON.parse(sessionStorage.getItem("UserName"));
                $scope.UserName = user;
                var lang = l;
                if (lang === null || lang == '2') {
                    lang = '2';
                    $scope.HeadTitle1 = "National Electronic";
                    $scope.HeadTitle2 = "BLOOD BANK";

                } else {
                    $scope.HeadTitle1 = "الوطنية الالكترونية";
                    $scope.HeadTitle2 = "بنك الدم";
                }
                $scope.lang = lang;
                if ($scope.lang == '2') {
                    switch_style('eng');
                    $scope.topbarbg = 'topbarbg';
                    $scope.topbarseparator = 'topbarseparator';
                    $scope.leftpanelbg = 'leftpanelbg';
                    $scope.pageleftpanelbg = 'pageleftpanelbg';
                }
                else if ($scope.lang == '1') {
                    switch_style('arb');
                    $scope.topbarbg = 'topbarbgarb';
                    $scope.topbarseparator = 'topbarseparatorarb';
                    $scope.leftpanelbg = 'leftpanelbgarb';
                    $scope.pageleftpanelbg = 'pageleftpanelbgarb';
                }
            }
            //-----------------set user form---------
            $scope.chkForm = true;
            function updateForm(form) {
                if ($scope.chkForm) {
                    var a = $location.$$absUrl;
                    var fc = a.search('3987') < 0 ? a.split('/')[5] : a.split('/')[4];
                    var formCode = fc == undefined || fc == '' ? a.search('3987') < 0 ? a.split('/')[4] : a.split('/')[3] : fc;
                    var param = form != null ? form : formCode;
                    var msg = menuService.updateForm(param);
                    msg.then(function (data) {
                        $scope.chkForm = JSON.parse(data) == 'OK' ? false : true;
                        return true;
                    }).catch(function (ex) {
                        return true;
                    });
                }


            }
           

            $(window).focus(function () {
                updateForm(null);
            });
            $(document).on('visibilitychange', function () {

                if (document.visibilityState == 'hidden') {
                    // page is hidden
                } else {
                    // page is visible
                    updateForm(null);
                }
            });
            $(document).on('click', function () {
                if ($scope.chkForm) {
                    updateForm(null);
                    $scope.chkForm = false;
                }

            });
            
            $scope.setError = function (controller, action, message) {
                MenuService.setClientErrorLog(controller, action, message);
            }

            
        }
    ]);

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

app.directive('textOnly', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {
                    var transformedInput = text.replace(/[^aA-zZ]/g, '');

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
app.directive('restrictInput', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attr, ctrl) {
            ctrl.$parsers.push(function (viewValue) {
                var options = scope.$eval(attr.restrictInput);
                if (!options.regex && options.type) {
                    switch (options.type) {
                        case 'digitsOnly': options.regex = '^[0-9]*$'; break;
                        case 'arabicOnly': options.regex = '^[\u0621-\u064A ]+$'; break;
                        case 'lettersOnly': options.regex = '^[a-zA-Z]*$'; break;
                        case 'lowercaseLettersOnly': options.regex = '^[a-z]*$'; break;
                        case 'uppercaseLettersOnly': options.regex = '^[A-Z]*$'; break;
                        case 'lettersAndDigitsOnly': options.regex = '^[a-zA-Z0-9]*$'; break;
                        case 'validPhoneCharsOnly': options.regex = '^[0-9 ()/-]*$'; break;
                        default: options.regex = '';
                    }
                }
                var reg = new RegExp(options.regex);
                if (reg.test(viewValue)) { //if valid view value, return it
                    return viewValue;
                } else { //if not valid view value, use the model value (or empty string if that's also invalid)
                    var overrideValue = (reg.test(ctrl.$modelValue) ? ctrl.$modelValue : '');
                    element.val(overrideValue);
                    return overrideValue;
                }
            });
        }
    };
});
