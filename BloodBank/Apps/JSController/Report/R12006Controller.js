app.controller("R12006Controller", ["$scope", "R12006Service", "Data", "$window", "$filter",
    function ($scope, R12006Service, Data, $window, $filter) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.q12018 = {};
        var Language = JSON.parse(sessionStorage.getItem("LangName"));
        document.getElementById('txtPatId').focus();

        gridLoad();

        function gridLoad() {
            $scope.obj.GridPart = [];
            for (var i = 0; i < 5; i++) {
                $scope.obj.test = {};
                $scope.obj.test.T_UNIT_NO = '';
                $scope.obj.test.T_REQUEST_NO = '';
                $scope.obj.test.T_PRODUCT = '';
                $scope.obj.test.T_BLOOD_GROUP_CODE = '';
                $scope.obj.test.T_UNIT_STATUS = '';
                $scope.obj.test.T_DONAT_DATE = '';
                $scope.obj.test.T_EXPIRY_DATE = '';
                $scope.obj.test.T_TYPE = '';
                $scope.obj.GridPart.push($scope.obj.test);
            }
        }

        $scope.ClearAll = function () {
            clear();
        };

        function clear() {
            $scope.obj.T_PAT_NO = '';
            $scope.obj.Date_From = '';
            $scope.obj.Date_To = '';
            $scope.obj.TECH_PIN = '';
            $scope.obj.TECH_USER = '';
            $scope.obj.TIME_FROM = '';
            $scope.obj.TIME_TO_HRS = '';
            $scope.obj.T_UNIT_FROM = '';
            $scope.obj.T_UNIT_TO_HRS = '';
            $scope.obj.Date_From_H = '';
            $scope.obj.Date_To_H = '';
        }

        $scope.T12304_print = function () {
            $window.open("../R12006/getR12006_Report?patNo=" + $scope.obj.T_PAT_NO, "popup", "width=600,height=600,left=100,top=50");
            clear();
            document.getElementById('txtPatId').focus();
        }

        $scope.R12215_print = function () {
            debugger;
            $scope.obj.TO_DATE = $scope.obj.Date_From;
            $scope.obj.TO_DATE_HIJ = $scope.obj.Date_From_H;
            //-------- For Hospital information start -----
            var info = R12006Service.getInfoData();
            info.then(function(inf) {
                var jsonData = JSON.parse(inf);
                $scope.obj.T_COUNTRY_LANG1_NAME = jsonData[0].T_COUNTRY_LANG1_NAME;
                $scope.obj.T_COUNTRY_LANG2_NAME = jsonData[0].T_COUNTRY_LANG2_NAME;
                $scope.obj.T_MIN_LANG1_NAME = jsonData[0].T_MIN_LANG1_NAME;
                $scope.obj.T_MIN_LANG2_NAME = jsonData[0].T_MIN_LANG2_NAME;
                $scope.obj.T_SITE_LANG1_NAME = jsonData[0].T_SITE_LANG1_NAME;
                $scope.obj.T_SITE_LANG2_NAME = jsonData[0].T_SITE_LANG2_NAME;
            });
            //-------- For Hospital information end  -----
            //-------- For summary information start  -----
            var sumInfo = R12006Service.GetR12215Summery($scope.obj.Date_From);
            sumInfo.then(function(sinf) {
                var jsonData = JSON.parse(sinf);
                $scope.obj.REGISTERED = jsonData[0].REGISTERED;
                $scope.obj.EXAMINED = jsonData[0].EXAMINED;
                $scope.obj.NOT_EXAMINED = jsonData[0].REGISTERED - jsonData[0].EXAMINED;
                $scope.obj.DONATED = jsonData[0].DONATED;
                $scope.obj.REJECTED = jsonData[0].REJECTED;
                $scope.obj.CANCELLED = jsonData[0].CANCELLED;
                gridData();
            });
            //-------- For summary information end  -----


            
            // $window.open("../R12006/GetR12215Report?entryDate=" + $scope.obj.Date_From, "popup", "width=600,height=600,left=100,top=50");
            // clear();
        };

        function gridData() {
            var clt = R12006Service.getCollector($scope.obj.Date_From);
            clt.then(function (co) {
                
                $scope.obj.collectorList = JSON.parse(co);
                //$scope.obj.TOTAL =obj.T_DAY
                    totalUnit(JSON.parse(co));
                if ($scope.obj.collectorList.length > 0) {
                    var cltion = R12006Service.getCollection($scope.obj.Date_From);
                    cltion.then(function (dc) {
                        $scope.obj.DcollectionList = JSON.parse(dc);
                        if ($scope.obj.DcollectionList.length > 0) {
                            var time = R12006Service.getCountTime($scope.obj.Date_From);
                            time.then(function (t) {
                                $scope.obj.timelist = JSON.parse(t);
                                // if ($scope.obj.timelist.length > 0) {
                                $scope.$watch('obj.check',
                                    function (newValue, oldValue, scope) {
                                        if ($scope.obj.check !== undefined) {
                                            PDF();
                                        }
                                    },
                                    true);

                                // }

                            });
                        }
                    });
                }
            });
        }
        function PDF() {
            var innerContents = document.getElementById('formConfirmation').innerHTML;
            var popupWinindow = window.open('', '_blank', 'width=600,height=700,scrollbars=no,menubar=no,toolbar=no,location=no,status=no,titlebar=no');
            popupWinindow.document.open();
            popupWinindow.document.write('<html><head><link rel="stylesheet" type="text/css" href="style.css" /></head><body onload="window.print()">' + innerContents + '</html>');
            popupWinindow.document.close(); 
        };
        $scope.FromDateHizri = function () {
            HizriDateFrom();
        }
        function HizriDateFrom() {
            
            var b = moment($scope.obj.Date_From,"DD/MM/YYYY");
            var c = $filter('date')(b, "dd-MMM-yyyy");
            $scope.obj.Date_From_H = moment(c).format('iYYYY/iMM/iDD');
        }
        $scope.ToDateHizri = function () {
            HizriDateTo();
        }
        function HizriDateTo() {
            var e = moment($scope.obj.Date_To, "DD/MM/YYYY");
            var f = $filter('date')(e, "dd-MMM-yyyy");
            $scope.obj.Date_To_H = moment(f).format('iYYYY/iMM/iDD');

        }
        function totalUnit(dataList) {
            var total = 0;
            $scope.obj.T_DAY = dataList[0].T_DAY;
            for (var i = 0; i < dataList.length; i++) {
                total = total + dataList[i].T_COUNT;
            }
            $scope.obj.TOTAL = total;
            //return total;
        }
        //$scope.Date_Write_From = function (date) {
        //    if (date.match(/^\d{2}([/])\d{2}\1\d{4}$/)) {
        //        day = date.substring(0, 2);
        //        mnth = date.substring(3, 5);
        //        newmonth = month(mnth);
        //        finMonth = newmonth.substring(0, 3);
        //        year = date.substring(6);
        //        console.log(day + '-' + finMonth + '-' + year);
        //        finalDate = day + '-' + finMonth + '-' + year;
        //        $scope.obj.Date_From = finalDate;
        //    } 
        //};

        $scope.Date_Write_From = function (date) {
            //if (date == !undefined) {
                if (date.includes("/")) {
                    if (date.match(/^\d{2}([./-])\d{2}\1\d{4}$/)) {
                        getDay = date.substring(0, 2);
                        var getlast6 = date.substring(2);
                        var mon = getlast6.substring(1, 3);
                        getMon = mon;
                        var ye = getlast6.substring(4);
                        if (ye === "") {
                            var ff = new Date();
                            getyea = ff.getFullYear();
                        } else {
                            getyea = years(ye);
                        }
                        $scope.obj.Date_From = getDay + '/' + getMon + '/' + getyea;
                        HizriDateFrom();
                        var theCaldender = document.getElementById('datepicker1');
                        theCaldender.lastElementChild.classList.remove('_720kb-datepicker-open');
                    } else {
                        getDay = date.substring(0, 1);
                        var day1 = getDay.padStart(2, '0');

                        var getlast6 = date.substring(2);
                        var mon = getlast6.substring(0, 1);
                        var motn = mon.padStart(2, '0');
                        getMon = motn;

                        var ye = getlast6.substring(2);
                        if (ye === "") {
                            var ff = new Date();
                            var getyea = ff.getFullYear();
                        } else {
                            getyea = years(ye);
                        }
                        $scope.obj.Date_From = day1 + '/' + getMon + '/' + getyea;
                        HizriDateFrom();
                        var theCaldender = document.getElementById('datepicker1');
                        theCaldender.lastElementChild.classList.remove('_720kb-datepicker-open');

                        ///////

                    }
                } else if (date.match(/[a-z]/i)) {
                    getDay = date.substring(0, 2);
                    var getlast6 = date.substring(2);
                    var mon = getlast6.match(/[a-z]+|[^a-z]+/i);
                    getMon = month(mon);
                    var ye = getlast6.match(/[0-9]+(?:\.[0-9]+|)/g)[0];
                    if (ye === "") {
                        var ff = new Date();
                        getyea = ff.getFullYear();
                    } else {
                        getyea = years(ye);
                    }
                    $scope.obj.Date_From = getDay + '/' + getMon + '/' + getyea;
                    HizriDateFrom();
                    var theCaldender = document.getElementById('datepicker1');
                    theCaldender.lastElementChild.classList.remove('_720kb-datepicker-open');
                } else {
                    getDay = date.substring(0, 2);
                    var getlast6 = date.substring(2);
                    var mon = getlast6.substring(0, 2);
                    getMon = mon;
                    var ye = getlast6.substring(2);
                    if (ye === "") {
                        var ff = new Date();
                        getyea = ff.getFullYear();
                    } else {
                        getyea = years(ye);
                    }
                    $scope.obj.Date_From = getDay + '/' + getMon + '/' + getyea;
                    HizriDateFrom();
                    var theCaldender = document.getElementById('datepicker1');
                    theCaldender.lastElementChild.classList.remove('_720kb-datepicker-open');
                    //var ff = new Date();
                    //var year = ff.getFullYear();
                    //var bb = ff.getMonth();
                    //var day = ff.getDay();
                }
            //} 


        };

        $scope.Date_Click_To = function (date) {
            if (date.includes("/")) {
                getDay = date.substring(0, 2);
                var getlast6 = date.substring(2);
                var mon = getlast6.substring(1, 3);
                getMon = mon;
                var ye = getlast6.substring(4);
                if (ye === "") {
                    var ff = new Date();
                    getyea = ff.getFullYear();
                } else {
                    getyea = years(ye);
                }
                $scope.obj.Date_To = getDay + '/' + getMon + '/' + getyea;
                HizriDateTo();
                var theCaldender = document.getElementById('datepicker2');
                theCaldender.lastElementChild.classList.remove('_720kb-datepicker-open');
            }
            else if (date.match(/[a-z]/i)) {
                getDay = date.substring(0, 2);
                var getlast6 = date.substring(2);
                var mon = getlast6.match(/[a-z]+|[^a-z]+/i);
                getMon = month(mon);
                var ye = getlast6.match(/[0-9]+(?:\.[0-9]+|)/g)[0];
                if (ye === "") {
                    var ff = new Date();
                    getyea = ff.getFullYear();
                } else {
                    getyea = years(ye);
                }
                $scope.obj.Date_To = getDay + '/' + getMon + '/' + getyea;
                HizriDateTo();
                var theCaldender = document.getElementById('datepicker2');
                theCaldender.lastElementChild.classList.remove('_720kb-datepicker-open');
            }
            else {
                getDay = date.substring(0, 2);
                var getlast6 = date.substring(2);
                var mon = getlast6.substring(0, 2);
                getMon = mon;
                var ye = getlast6.substring(2);
                if (ye === "") {
                    var ff = new Date();
                    getyea = ff.getFullYear();
                } else {
                    getyea = years(ye);
                }
                $scope.obj.Date_To = getDay + '/' + getMon + '/' + getyea;
                HizriDateTo();
                var theCaldenders = document.getElementById('datepicker2');
                theCaldenders.lastElementChild.classList.remove('_720kb-datepicker-open');
                ////var ff = new Date();
                //var year = ff.getFullYear();
                //var bb = ff.getMonth();
                //var day = ff.getDay();
            }

        };

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
                y = f + yy;
            }
            return y;
        }


        function month(mon) {
            var m = '';
            if (mon == '01') {
                m = 'January';
            }
            else if (mon == '02') {
                m = 'February';
            }
            else if (mon == '03') {
                m = 'March';
            }
            else if (mon == '04') {
                m = 'April';
            }
            else if (mon == '05') {
                m = 'May';
            }
            else if (mon == '06') {
                m = 'June';
            }
            else if (mon == '07') {
                m = 'July';
            }
            else if (mon == '08') {
                m = 'August';
            }
            else if (mon == '09') {
                m = 'September';
            }
            else if (mon == '10') {
                m = 'October';
            }
            else if (mon == '11') {
                m = 'November';
            }
            else if (mon == '12') {
                m = 'December';
            } else {
                // alert('Month is not correct ');
                m = '00';
            }
            return m;
        }


        $scope.showTechPopup = function () {
            fnTechList();
            document.getElementById('divTech').style.display = 'Block';
        }
        $scope.CloseDivTechPopup = function () {
            document.getElementById('divTech').style.display = 'none';
        }

        function fnTechList() {
            var tech = R12006Service.GetTechList();
            tech.then(function (data) {
                $scope.TechList = JSON.parse(data);
            });
        }

        $scope.onUserSelect = function ($index, obj) {
            $scope.obj.TECH_PIN = obj.T_PIN;
            $scope.obj.TECH_USER = obj.T_USER_NAME;
            document.getElementById('divTech').style.display = 'none';
        };
        var reason = R12006Service.GetReasonList();
        reason.then(function (data) {
            $scope.obj.reasonlist = JSON.parse(data);
        });
        $scope.obj.nationalityList = [
            { "T_NATIONALITY_ID": "1", "T_LANG2_NAME": "Saudi" },
            { "T_NATIONALITY_ID": "2", "T_LANG2_NAME": "Non-Saudi" }
        ];


        //$scope.changeDate= function(i) {
        //    alert(i);
        //}
    }]);


