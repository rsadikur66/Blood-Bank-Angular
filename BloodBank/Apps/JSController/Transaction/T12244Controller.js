app.filter('startFrom', function () {
    return function (input, start) {
        start = +start;
        return input.slice(start);
    }
});
app.controller("T12244Controller", ["$scope", "Data", "T12244Service","$filter", "$window",
    function ($scope, Data, T12244Service, $filter,$window) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12017 = {};
        $scope.obj.T12071 = {};
        $scope.obj.T_PAT_NO = '';
        $scope.obj.T_RESEARCH_STTS = 0;
        document.getElementById("txtDonorId").focus();
        document.getElementById("divQuesList").style.display = "none";
       

        $scope.lang = JSON.parse(sessionStorage.getItem("LangName")) == undefined ? 2 : JSON.parse(sessionStorage.getItem("LangName"));
        $scope.stl = $scope.lang == 1 ? $scope.ala : $scope.ale;
        //getQues('00000002', 1, 2);
        $scope.trStyleOn = { "backgroundColor": '#AF0000', "color": "#ffffff" }
        $scope.trStyleOff = { "backgroundColor": '#ffffff', "color": "#000000" }
        $scope.imgStyle = { "backgroundColor": '#ffffff', "color": "#000000" }
        $scope.selectedRow = 0;

        //-------------For Pagination--------------Start-------
        $scope.obj.currentPage = 0;
        $scope.obj.pageSize = 12;
        $scope.obj.quesList = [];
        $scope.obj.q = '';
        $scope.obj.getData = function () { return $filter('filter')($scope.obj.quesList, $scope.obj.q); }
        $scope.obj.numberOfPages = function () { return Math.ceil($scope.obj.getData().length / $scope.obj.pageSize); }
        //-------------For Pagination--------------End-------
        $scope.onPatSrch_blur = function () {
            var n = $scope.obj.T12071.T_DONOR_PATNO;
            if (n != null) {
                var a = $scope.pad(n, 8);
                $scope.obj.T12071.T_DONOR_PATNO = a == '00000000' ? '' : a;
            }

        }

        $scope.onPatSrch_tab = function (e) {
            if (e.keyCode === 9 || e.keyCode === 13) {
                var p = $scope.obj.T12071.T_DONOR_PATNO;
                if (p != null) {
                    var a = $scope.pad(p, 8);
                    $scope.obj.T12071.T_DONOR_PATNO = a == '00000000' ? '' : a;
                    $scope.getPatNo($scope.obj.T12071.T_DONOR_PATNO);
                }
            }
            



        }
        $scope.getPatNo = function (e) {
            if (e != null) {
                var getPatNo = T12244Service.getPatNo(e);
                getPatNo.then(function (data) {
                    $scope.getPatInfo = JSON.parse(data);
                    if ($scope.getPatInfo.length > 0) {
                        $scope.T_DONOR_NAME_ENG = $scope.getPatInfo[0].NAME_ENG;
                        $scope.T_DONOR_NAME_ARB = $scope.getPatInfo[0].NAME_ARB;

                        $scope.obj.T12071.T_DONOR_ID = $scope.getPatInfo[0].T_NTNLTY_ID;
                        $scope.obj.T12071.T_DONOR_EPISODE = $scope.getPatInfo[0].MAX_EPISODE;
                        $scope.obj.T12071.T_REQUEST_ID = $scope.getPatInfo[0].T_REQUEST_ID;
                        $scope.obj.T12017.T_REQUEST_ID = $scope.getPatInfo[0].T_REQUEST_ID;
                        $scope.obj.T12017.T_BLOOD_DONATION_STATUS = $scope.getPatInfo[0].T_BLOOD_DONATION_STATUS;
                        $scope.T_GENDER = $scope.getPatInfo[0].T_GENDER;
                        $scope.T_DONOR_NAME1 = $scope.getPatInfo[0].NAME_ARB;
                        $scope.T_DONOR_NAME2 = $scope.getPatInfo[0].NAME_ENG;
                        $scope.obj.T12017.T_PAT_NO = $scope.obj.T12071.T_DONOR_PATNO;
                        $scope.obj.T12017.T_EPISODE_NO = $scope.obj.T12071.T_DONOR_EPISODE;
                        $scope.obj.T12017.T_DONOR_NTNLTY_ID = $scope.obj.T12071.T_DONOR_ID;
                        document.getElementById("btnStartQuest").focus();
                        
                        //document.getElementById("divQuesStart").style.display = "none";
                        //document.getElementById("divQuesList").style.display = "inline-block";
                    }
                    else {
                        alert('Data not found');
                        //alert($scope.getSingleMsg('S0023'));
                        $scope.T_DONOR_NAME_ENG = '';
                        $scope.T_DONOR_NAME_ARB = '';
                        $scope.obj.T12071.T_DONOR_ID = null;
                        $scope.obj.T12071.T_DONOR_PATNO = null;
                        $scope.obj.T12071.T_DONOR_EPISODE = null;
                        $scope.obj.T12017.T_DONOR_EPISODE = null;
                        $scope.obj.T12071.T_REQUEST_ID=null;
                        $scope.T_GENDER = null;
                        $scope.T_DONOR_NAME = null;

                        //document.getElementById("divQuesList").style.display = "none";
                        //document.getElementById("divQuesStart").style.display = "inline-block";

                    }
                });
            }

        }
        $scope.getQuesClick = function (e, t, f) {
            getQues(e, t, f);

        }
        $scope.getQuesEnter = function (e, t, f, ev) {
            if (ev.keyCode===13) {
                getQues(e, t, f);
            }
            
        }
        $scope.getQues = function (e, t, f) {
            getQues(e, t, f);

        }
       
        $scope.onQuesSelect = function(i) {
            $scope.QUES_HEADER1 = angular.element($("#txtQHeadDesc1" + i)).scope().obj.QUES_HEADER1;
            $scope.QUES_HEADER2 = angular.element($("#txtQHeadDesc2" + i)).scope().obj.QUES_HEADER2;
            //document.getElementById("trQues" + i).style.backgroundColor = '#AF0000';
            //document.getElementById("trQues" + i).style.color = '#ffffff';
            $scope.changeColor(i);

        }
        $scope.onImgclick = function (i, t) {
            var stts = isNaN(parseInt($scope.obj.T12017.T_BLOOD_DONATION_STATUS)) ? 0 : parseInt($scope.obj.T12017.T_BLOOD_DONATION_STATUS);
            if (stts>1) {
                alert('This Question can not be updated!!');
                return;
            }
            var scope = angular.element($("#txtQnoAns" + i)).scope();

           if (t === 's') {
                if (scope.obj.T_QNO_ANS==='1') {
                    scope.obj.T_QNO_ANS = null; 
                } else {
                    scope.obj.T_QNO_ANS = '1'; 
                }
            }
            else if (t === 'f') {
                if (scope.obj.T_QNO_ANS === '2') {
                    scope.obj.T_QNO_ANS = null;
            } else {
                    scope.obj.T_QNO_ANS = '2';
            }
            }
            
            $scope.QUES_HEADER1 = angular.element($("#txtQHeadDesc1" + i)).scope().obj.QUES_HEADER1;
            $scope.QUES_HEADER2 = angular.element($("#txtQHeadDesc2" + i)).scope().obj.QUES_HEADER2;


            //----------------------------------Save ---------------------------------------
            var QnoAns = angular.element($("#txtQnoAns" + i)).scope().obj.T_QNO_ANS;
            var Qno = angular.element($("#txtQno" + i)).scope().obj.T_QNO;
            var QHead = angular.element($("#txtQHead" + i)).scope().obj.T_QHEAD_NO;
            var QDisplay = angular.element($("#txtDispSeq" + i)).scope().obj.T_DISP_SEQ;
            var QId = angular.element($("#txtQuesId" + i)).scope().obj.T_QUES_ID;
            var QExpAns = angular.element($("#txtExpAns" + i)).scope().obj.T_EXP_ANS;
            var QIfFail = angular.element($("#txtIfFail" + i)).scope().obj.T_IF_FAIL;
            var QDiffDay = angular.element($("#txtDeffDay" + i)).scope().obj.T_DIFFERAL_DAY;

            $scope.obj.T12071.T_QNO_ANS = QnoAns;
            $scope.obj.T12071.T_QNO = Qno;
            $scope.obj.T12071.T_QHEAD_NO = QHead;
            $scope.obj.T12071.T_DISP_SEQ = QDisplay;
            $scope.obj.T12071.T_QUES_ID = QId;
            if (QnoAns == QExpAns) { $scope.obj.T12071.T_DIFFERAL_DAY = 0; }
            else if (QnoAns != QExpAns) {
                if (QIfFail == "1") { $scope.obj.T12071.T_DIFFERAL_DAY = QDiffDay; }
                else if (QIfFail == "2") { $scope.obj.T12071.T_DIFFERAL_DAY = 0; }
            }
            var t71 = $scope.obj.T12071;
            var singleInsert = T12244Service.singleInsert(t71);
            $scope.loader(true);
            singleInsert.then(function(data) {
                var dt = JSON.parse(data);
                //var dt = JSON.parse(data).split("+");
                //var dt = d[0];
                //var scope = angular.element($("#txtQuesId" + i));
                //scope.obj.T_QUES_ID = dt[1];

            $scope.loader(false);
                if (dt == 'N0040' || dt == 'N0041') {
                    if (t === 's') {
                        if (scope.obj.T_QNO_ANS === '1') {
                document.getElementById("btnSuccess" + i).style.background = "url(../Images/checksuccess.png)";
                document.getElementById("btnFail" + i).style.background = "url(../Images/checkcross_fade.png)";
                        } else {
                document.getElementById("btnSuccess" + i).style.background = "url(../Images/checksuccess_fade.png)";
                document.getElementById("btnFail" + i).style.background = "url(../Images/checkcross_fade.png)";
                        }
                    }
                    else if (t === 'f') {
                        if (scope.obj.T_QNO_ANS === '2') {
                document.getElementById("btnFail" + i).style.background = "url(../Images/checkcross.png)";
                document.getElementById("btnSuccess" + i).style.background = "url(../Images/checksuccess_fade.png)";
          
                           
                        } else {
                document.getElementById("btnSuccess" + i).style.background = "url(../Images/checksuccess_fade.png)";
                document.getElementById("btnFail" + i).style.background = "url(../Images/checkcross_fade.png)";
                          
                        }
                    } 
                
                } else {
                    alert($scope.getSingleMsg(dt));
                    if (t === 's') {
                        if (scope.obj.T_QNO_ANS === '1') {
                            document.getElementById("btnSuccess" + i).style.background = "url(../Images/checksuccess_fade.png)";
                            document.getElementById("btnFail" + i).style.background = "url(../Images/checkcross_fade.png)";
                            scope.obj.T_QNO_ANS = null;
                        } else {
                            document.getElementById("btnSuccess" + i).style.background = "url(../Images/checksuccess.png)";
                            document.getElementById("btnFail" + i).style.background = "url(../Images/checkcross_fade.png)";
                            scope.obj.T_QNO_ANS = '1';
                        }

                    }
                    else if (t === 'f') {
                        if (scope.obj.T_QNO_ANS === '2') {
                            document.getElementById("btnSuccess" + i).style.background = "url(../Images/checksuccess_fade.png)";
                            document.getElementById("btnFail" + i).style.background = "url(../Images/checkcross_fade.png)";
                            scope.obj.T_QNO_ANS = null;
                        } else {
                            document.getElementById("btnFail" + i).style.background = "url(../Images/checkcross.png)";
                            document.getElementById("btnSuccess" + i).style.background = "url(../Images/checksuccess_fade.png)";
                            scope.obj.T_QNO_ANS = '2';
                        }
                    }  
                }
                document.getElementById("btnSuccess" + i).style.backgroundSize = "30px";
                document.getElementById("btnSuccess" + i).style.backgroundRepeat = "no-repeat";
                document.getElementById("btnSuccess" + i).style.backgroundPosition = "center";
                document.getElementById("btnSuccess" + i).style.width = "30px";
                document.getElementById("btnSuccess" + i).style.borderColor = "#FBFBFB";

                document.getElementById("btnFail" + i).style.backgroundSize = "30px";
                document.getElementById("btnFail" + i).style.backgroundRepeat = "no-repeat";
                document.getElementById("btnFail" + i).style.backgroundPosition = "center";
                document.getElementById("btnFail" + i).style.width = "30px";
                document.getElementById("btnFail" + i).style.borderColor = "#FBFBFB";
                var count = 0;
                for (var j = 0; j < $scope.obj.quesList.length; j++) {
                    if ($scope.obj.quesList[j].T_QNO_ANS != null && $scope.obj.quesList[j].R != null) {
                        count++;
                    }

                }
                var total = $scope.obj.quesList.filter(function (item) { return (item.R != null); }).length;
                $scope.obj.T_COUNTER = count + "/" + total;








                //var start = $scope.obj.currentPage * $scope.obj.pageSize;
                //var tEnd = ($scope.obj.currentPage + 1) * $scope.obj.pageSize;
                //var end = $scope.obj.quesList.length < tEnd ? $scope.obj.quesList.length : tEnd;
                var quesCount = 0;
                var ansCount = 0;
                var k = 0;
                for (k = 0; k < 12; k++) {
                    document.getElementById("trQues" + k).style.backgroundColor = "#ffffff";
                    document.getElementById("trQues" + k).style.color = "#000000";
                    //document.getElementById("tdQuesS" + k).style.backgroundColor = "#ffffff";
                    //document.getElementById("tdQuesF" + k).style.backgroundColor = "#ffffff";
                    document.getElementById("btnSuccess" + k).style.backgroundColor = "#ffffff";
                    document.getElementById("btnFail" + k).style.backgroundColor = "#ffffff";


                    document.getElementById("btnSuccess" + k).style.backgroundSize = "30px";
                    document.getElementById("btnSuccess" + k).style.backgroundRepeat = "no-repeat";
                    document.getElementById("btnSuccess" + k).style.backgroundPosition = "center";
                    document.getElementById("btnSuccess" + k).style.width = "30px";
                    document.getElementById("btnSuccess" + k).style.borderColor = "#FBFBFB";

                    document.getElementById("btnFail" + k).style.backgroundSize = "30px";
                    document.getElementById("btnFail" + k).style.backgroundRepeat = "no-repeat";
                    document.getElementById("btnFail" + k).style.backgroundPosition = "center";
                    document.getElementById("btnFail" + k).style.width = "30px";
                    document.getElementById("btnFail" + k).style.borderColor = "#FBFBFB";

                    //var qAns = angular.element($("#txtQnoAns" + k)).scope().obj.T_QNO_ANS;
                    var r = angular.element($("#txtSL" + k)).scope().obj.R;
                    var qAns = angular.element($("#txtQnoAns" + k)).scope().obj.T_QNO_ANS;
                    if (r != null) { quesCount++; }
                    if (r != null && qAns != null) {
                        ansCount++;
                    }


                }
                //document.getElementById("trQues" + i).style.backgroundColor = "#AF0000";
                //document.getElementById("trQues" + i).style.color = "#ffffff";
                //document.getElementById("btnFail" + i).style.backgroundColor = "#ffffff";
                //document.getElementById("btnSuccess" + i).style.backgroundColor = "#ffffff";
                ////document.getElementById("tdQuesS" + z).style.backgroundColor = "#AF0000";
                ////document.getElementById("tdQuesF" + z).style.backgroundColor = "#AF0000";

                //document.getElementById("btnSuccess" + i).style.backgroundSize = "30px";
                //document.getElementById("btnSuccess" + i).style.backgroundRepeat = "no-repeat";
                //document.getElementById("btnSuccess" + i).style.backgroundPosition = "center";
                //document.getElementById("btnSuccess" + i).style.width = "30px";
                //document.getElementById("btnSuccess" + i).style.borderColor = "#FBFBFB";

                //document.getElementById("btnFail" + i).style.backgroundSize = "30px";
                //document.getElementById("btnFail" + i).style.backgroundRepeat = "no-repeat";
                //document.getElementById("btnFail" + i).style.backgroundPosition = "center";
                //document.getElementById("btnFail" + i).style.width = "30px";
                //document.getElementById("btnFail" + i).style.borderColor = "#FBFBFB";

                var z = parseInt(i + 1);
                if (quesCount > z) {
                   document.getElementById("trQues" + z).style.backgroundColor = "#AF0000";
                    document.getElementById("trQues" + z).style.color = "#ffffff"; 
                    document.getElementById("btnFail" + z).style.backgroundColor = "#ffffff";
                    document.getElementById("btnSuccess" + z).style.backgroundColor = "#ffffff";
                    //document.getElementById("tdQuesS" + z).style.backgroundColor = "#AF0000";
                    //document.getElementById("tdQuesF" + z).style.backgroundColor = "#AF0000";

                    document.getElementById("btnSuccess" + z).style.backgroundSize = "30px";
                    document.getElementById("btnSuccess" + z).style.backgroundRepeat = "no-repeat";
                    document.getElementById("btnSuccess" + z).style.backgroundPosition = "center";
                    document.getElementById("btnSuccess" + z).style.width = "30px";
                    document.getElementById("btnSuccess" + z).style.borderColor = "#FBFBFB";

                    document.getElementById("btnFail" + z).style.backgroundSize = "30px";
                    document.getElementById("btnFail" + z).style.backgroundRepeat = "no-repeat";
                    document.getElementById("btnFail" + z).style.backgroundPosition = "center";
                    document.getElementById("btnFail" + z).style.width = "30px";
                    document.getElementById("btnFail" + z).style.borderColor = "#FBFBFB";
                } else if (z == quesCount) {
                    if (ansCount.length!= quesCount) {
                        document.getElementById("trQues" + 0).style.backgroundColor = "#AF0000";
                        document.getElementById("trQues" + 0).style.color = "#ffffff";
                        document.getElementById("btnFail" + 0).style.backgroundColor = "#ffffff";
                        document.getElementById("btnSuccess" + 0).style.backgroundColor = "#ffffff";
                        //document.getElementById("tdQuesS" + z).style.backgroundColor = "#AF0000";
                        //document.getElementById("tdQuesF" + z).style.backgroundColor = "#AF0000";

                        document.getElementById("btnSuccess" + 0).style.backgroundSize = "30px";
                        document.getElementById("btnSuccess" + 0).style.backgroundRepeat = "no-repeat";
                        document.getElementById("btnSuccess" + 0).style.backgroundPosition = "center";
                        document.getElementById("btnSuccess" + 0).style.width = "30px";
                        document.getElementById("btnSuccess" + 0).style.borderColor = "#FBFBFB";

                        document.getElementById("btnFail" + 0).style.backgroundSize = "30px";
                        document.getElementById("btnFail" + 0).style.backgroundRepeat = "no-repeat";
                        document.getElementById("btnFail" + 0).style.backgroundPosition = "center";
                        document.getElementById("btnFail" + 0).style.width = "30px";
                        document.getElementById("btnFail" + 0).style.borderColor = "#FBFBFB";

                    } else {
                        NextClick(1,null);
                    }

                }

                if (ansCount === quesCount) {
                    NextClick(1,null);
                }

            });
            //----------------------------------Save ---------------------------------------


        }
        $scope.onsttsSet = function (i, e) {

            if (e === "1") {
                //document.getElementById("trQues" + i).style.backgroundColor = "#6AA6FD";
                //document.getElementById("trQues" + i).style.color = "#000000";
            } else if (e === "2") {
                //document.getElementById("trQues" + i).style.backgroundColor = "#4C4848";
                //document.getElementById("trQues" + i).style.color = "#ffffff";
            }
        }
        $scope.onNextClick = function () {
            NextClick(null,null);
        }
        $scope.onBackClick = function () {
            $scope.obj.currentPage = $scope.obj.currentPage - 1;
        }
        $scope.onbtnTermsClick = function () {
                if ($scope.obj.T_RESEARCH_STTS === 0){$scope.obj.T12017.T_RESEARCH_STTS="";}
            else if ($scope.obj.T_RESEARCH_STTS === 1) { $scope.obj.T12017.T_RESEARCH_STTS = 1; }
            $scope.obj.T12017.T_BLOOD_DONATION_STATUS = 1;
            $scope.obj.T12017.T_PAT_NO = $scope.obj.T12071.T_DONOR_PATNO;
            $scope.obj.T12017.T_EPISODE_NO = $scope.obj.T12071.T_DONOR_EPISODE;
            $scope.obj.T12017.T_DONOR_NTNLTY_ID = $scope.obj.T12071.T_DONOR_ID;


            //$scope.obj.t12071 = [];
            //for (var i = 0; i < $scope.obj.quesList.length; i++) {
            //    $scope.obj.demo = {};
            //    if ($scope.obj.quesList[i].T_QNO_ANS != null && $scope.obj.quesList[i].R != null) {
            //        $scope.obj.demo.T_DONOR_ID = $scope.obj.T12071.T_DONOR_ID;
            //        $scope.obj.demo.T_DONOR_PATNO = $scope.obj.T12071.T_DONOR_PATNO;
            //        $scope.obj.demo.T_DONOR_EPISODE = $scope.obj.T12071.T_DONOR_EPISODE;

            //        $scope.obj.demo.T_QNO_ANS = $scope.obj.quesList[i].T_QNO_ANS;
            //        $scope.obj.demo.T_QNO = $scope.obj.quesList[i].T_QNO;
            //        $scope.obj.demo.T_QHEAD_NO = $scope.obj.quesList[i].T_QHEAD_NO;
            //        $scope.obj.demo.T_DISP_SEQ = $scope.obj.quesList[i].T_DISP_SEQ;
            //        if ($scope.obj.quesList[i].T_QNO_ANS == $scope.obj.quesList[i].T_EXP_ANS) {
            //            $scope.obj.demo.T_DIFFERAL_DAY = 0;
            //        }
            //        if ($scope.obj.quesList[i].T_QNO_ANS != $scope.obj.quesList[i].T_EXP_ANS) {
            //            if ($scope.obj.quesList[i].T_IF_FAIL == "1") {
            //                $scope.obj.demo.T_DIFFERAL_DAY = $scope.obj.quesList[i].T_DIFFERAL_DAY;
            //            }
            //            else if ($scope.obj.quesList[i].T_IF_FAIL == "2") {
            //                $scope.obj.demo.T_DIFFERAL_DAY = 0;
            //            }
            //        }
                    
            //        $scope.obj.t12071.push($scope.obj.demo);
            //    }
            //}


            var t17 = $scope.obj.T12017;
            //var t71 = $scope.obj.t12071;

            //var insert = T12244Service.insert(t17, t71);
            
            var insert = T12244Service.insert(t17);
            $scope.loader(true);
            insert.then(function (data) {
                var dt=JSON.parse(data);
                if (dt ==="N0041") {
                    $scope.loader(false);
                    //alert("Data Saved Successfully");
                    alert($scope.getSingleMsg(dt));
                    $scope.T_DONOR_NAME_ENG = '';
                    $scope.T_DONOR_NAME_ARB = '';
                    $scope.obj.T12071.T_DONOR_ID = null;
                    $scope.obj.T12071.T_DONOR_PATNO = null;
                    $scope.T_GENDER = null;
                    $scope.QUES_HEADER1 = '';
                    $scope.QUES_HEADER2= '';
                    $scope.obj.quesList = null;
                    document.getElementById("divConfirm").style.display = "none";
                    //document.getElementById("tblQues").style.display = "none";
                    //document.getElementById("txtHeader").style.display = "none";
                    document.getElementById("divQuesList").style.display = "none";
                    document.getElementById("divQuesStart").style.display = "inline-block";
                    document.getElementById("txtDonorId").focus();
                    document.getElementById("btnBack").style.display = "inline-block";
                }
                else  {
                    $scope.loader(false);
                    //alert("Data not Saved");
                    alert($scope.getSingleMsg(dt));
                    document.getElementById("divConfirm").style.display = "none";
                    document.getElementById("btnBack").style.display = "none";
                    getQues($scope.obj.T12071.T_DONOR_ID, 2, $scope.T_GENDER);

                }

            });

        }
        
        //$scope.testPrint = function() {
        //    var testPrint = T12244Service.testPrint();
        //    testPrint.then(function (data) {
        //        var a = JSON.parse(data);
        //        var image = new Image();
        //        image.src = 'data:image/png;base64,'+a;
        //        document.getElementById("imgTemp").src = image.src;

        //        //var printContents = document.getElementById('printableArea').innerHTML;
        //        //var originalContents = document.body.innerHTML;
        //        //document.body.innerHTML = printContents;
        //        //window.print();
        //        //document.body.innerHTML = originalContents;

        //        ClientSidePrint('printableArea');

        //    });
        //}
        //function ClientSidePrint(idDiv) {
        //    var w = 600;
        //    var h = 400;
        //    var l = (window.screen.availWidth - w) / 2;
        //    var t = (window.screen.availHeight - h) / 2;

        //    var sOption = "toolbar=no,location=no,directories=no,menubar=no,scrollbars=yes,width=" + w + ",height=" + h + ",left=" + l + ",top=" + t;
        //    // Get the HTML content of the div
        //    var sDivText = window.document.getElementById(idDiv).innerHTML;
        //    // Open a new window
        //    var objWindow = window.open("", "Print", sOption);
        //    // Write the div element to the window
        //    objWindow.document.write(sDivText);
        //    objWindow.document.close();
        //    // Print the window            
        //    objWindow.print();
        //    // Close the window
        //    objWindow.close();
        //} 
        function getQues(e, t, f) {
            //$scope.la = t;
            $scope.prImg = t == 1 ? 'ques_Next':'ques_Back';
            $scope.nImg = t == 1 ?  'ques_Back':'ques_Next';
            if (e != null) {
                document.getElementById("btnE").style.display = "inline-block";
                document.getElementById("btnA").style.display = "inline-block";
                document.getElementById("tblQues").style.display = "inline-block";
                document.getElementById("txtHeader1").style.display = "inline-block";
                document.getElementById("txtHeader2").style.display = "inline-block";
                $scope.obj.T_LANG_TYPE = t;
                $scope.lang = t;
                var getQuesList = T12244Service.getQuestions($scope.lang, $scope.T_GENDER, $scope.obj.T12071.T_DONOR_PATNO);
                getQuesList.then(function (data) {
                    var dt = JSON.parse(data);
                    if (dt.length > 0) {
                       //--------------------------------------------------
                        var c = [];
                        var output = [],
                            keys = [];
                        angular.forEach(dt,
                            function (item) {
                                var key = item["HEADER_NO"];
                                if (keys.indexOf(key) === -1 || key === 'N/A') {
                                    keys.push(key);
                                    output.push(item);
                                }
                            });
                        for (var i = 0; i < output.length; i++) {
                            var t = dt.filter(function (item) { return (item.HEADER_NO == output[i].HEADER_NO); });
                            c = c.concat(t);
                            var tl = 12 - t.length % 12;
                            if (tl < 12) {
                                for (var j = 0; j < tl; j++) {
                                    var temp = {};
                                    temp.HEADER_NO = 0;
                                    temp.QUES_DESC1 = '';
                                    temp.QUES_DESC2 = '';
                                    temp.QUES_HEADER1 = 0;
                                    temp.QUES_HEADER2 = 0;
                                    //temp.R = c.length + 1;
                                    temp.R = null;
                                    temp.TOTAL_QUES = null;
                                    temp.T_DIFFERAL_DAY = null;
                                    temp.T_DISP_SEQ = null;
                                    temp.T_EXP_ANS = null;
                                    temp.T_IF_FAIL = null;
                                    temp.T_QHEAD_NO = null;
                                    temp.T_QNO = null;
                                    temp.T_QNO_ANS = 1010;
                                    c.push(temp);
                                }
                            }
                        }
                        $scope.obj.quesList = c;
                        //--------------------------------------------------
                        $scope.obj.currentPage = 0;
                        $scope.obj.pageSize = $scope.obj.quesList[0].TOTAL_QUES;
                        $scope.obj.T_COUNTER = '';
                        document.getElementById("divQuesList").style.display = "inline-block";
                        document.getElementById("divQuesStart").style.display = "none";
                        document.getElementById("btnBack").style.display = "none";
                        document.getElementById("txtHeader" + $scope.lang).focus();
                        var count = 0;
                        for (var v = 0; v < $scope.obj.quesList.length; v++) {
                            if ($scope.obj.quesList[v].T_QNO_ANS != null && $scope.obj.quesList[v].R != null) {
                                count++;
                            }

                        }
                        var total = $scope.obj.quesList.filter(function (item) { return (item.R != null); }).length;
                        $scope.obj.T_COUNTER = count + "/" + total;
                        //$scope.QUES_HEADER = angular.element($("#txtQHeadDesc0")).scope().obj.QUES_HEADER;
                       
                    }
                    else {
                        alert('Data not found');
                        document.getElementById("divQuesList").style.display = "none";
                        document.getElementById("divQuesStart").style.display = "inline-block";
                        document.getElementById("btnBack").style.display = "inline-block";
                    }

                });







                
            }
           // $scope.QUES_HEADER = '';
        }
        $scope.hideButton = function (i, obj) {
            if (obj.R != null && obj.T_QNO_ANS != 1010) {
                if (obj.T_QNO_ANS == '1') {
                    document.getElementById("btnSuccess" + i).style.background = "url(../Images/checksuccess.png)";
                    document.getElementById("btnFail" + i).style.background = "url(../Images/checkcross_fade.png)";
                    document.getElementById("btnFail" + i).style.backgroundColor = "#ffffff";
                    document.getElementById("btnSuccess" + i).style.backgroundColor = "#ffffff";
                    document.getElementById("btnFail" + i).style.backgroundSize = "30px";
                    document.getElementById("btnFail" + i).style.backgroundRepeat = "no-repeat";
                    document.getElementById("btnFail" + i).style.backgroundPosition = "center";
                    document.getElementById("btnFail" + i).style.width = "30px";
                    document.getElementById("btnSuccess" + i).style.backgroundSize = "30px";
                    document.getElementById("btnSuccess" + i).style.backgroundRepeat = "no-repeat";
                    document.getElementById("btnSuccess" + i).style.backgroundPosition = "center";
                    document.getElementById("btnSuccess" + i).style.width = "30px";
                   
                } else if (obj.T_QNO_ANS == '2') {
                    document.getElementById("btnFail" + i).style.background = "url(../Images/checkcross.png)";
                    document.getElementById("btnSuccess" + i).style.background =
                        "url(../Images/checksuccess_fade.png)";
                    document.getElementById("btnFail" + i).style.backgroundColor = "#ffffff";
                    document.getElementById("btnSuccess" + i).style.backgroundColor = "#ffffff";
                    document.getElementById("btnFail" + i).style.backgroundSize = "30px";
                    document.getElementById("btnFail" + i).style.backgroundRepeat = "no-repeat";
                    document.getElementById("btnFail" + i).style.backgroundPosition = "center";
                    document.getElementById("btnFail" + i).style.width = "30px";
                    document.getElementById("btnSuccess" + i).style.backgroundSize = "30px";
                    document.getElementById("btnSuccess" + i).style.backgroundRepeat = "no-repeat";
                    document.getElementById("btnSuccess" + i).style.backgroundPosition = "center";
                    document.getElementById("btnSuccess" + i).style.width = "30px";
                }
                
                $scope.QUES_HEADER1 = angular.element($("#txtQHeadDesc1" + i)).scope().obj.QUES_HEADER1;
                $scope.QUES_HEADER2 = angular.element($("#txtQHeadDesc2" + i)).scope().obj.QUES_HEADER2;
                //document.getElementById(t + i).style.borderColor = "#ffffff";
            }
            document.getElementById("btnSuccess" + i).disabled = obj.R === null ? true : false;
            document.getElementById("btnFail" + i).disabled = obj.R === null ? true : false;
            document.getElementById("btnSuccess" + i).style.cursor = obj.R === null ? 'not-allowed' : 'pointer';
            document.getElementById("btnFail" + i).style.cursor = obj.R === null ? 'not-allowed' : 'pointer';
            document.getElementById("btnSuccess" + i).style.visibility = obj.R === null ? 'hidden' : 'visible';
            document.getElementById("btnFail" + i).style.visibility = obj.R === null ? 'hidden' : 'visible';


        }
        
        function NextClick(p,v) {
            //var getConsent = T12244Service.getConsent($scope.obj.T_LANG_TYPE);
            //        getConsent.then(function(data) {
            //            if (JSON.parse(data).length > 0) {
            //                $scope.T_CONSENT = JSON.parse(data)[0].CNSNT_DESC;
            //                document.getElementById("divConfirm").style.display = "inline-block";
            //            }
            //        });
            var t = 0;

            var start = $scope.obj.currentPage * $scope.obj.pageSize;
            var tEnd = ($scope.obj.currentPage + 1) * $scope.obj.pageSize;
            var end = $scope.obj.quesList.length < tEnd ? $scope.obj.quesList.length : tEnd;
            for (var i = start; i < end; i++) {
                if ($scope.obj.quesList[i].T_QNO_ANS != null) {
                    t++;
                }
            }

            if (t == parseInt(end - start)||v==1) {
                var c = $scope.obj.currentPage + 1;
                var tp = $scope.obj.numberOfPages();
                if (c == tp) {
                    var getConsent = T12244Service.getConsent($scope.obj.T_LANG_TYPE);
                    getConsent.then(function(data) {
                        if (JSON.parse(data).length > 0) {
                            $scope.T_CONSENT = JSON.parse(data)[0].CNSNT_DESC;
                            if (v==null) {
                                document.getElementById("divConfirm").style.display = "inline-block";
                            }
                           
                        }
                    });
                } else {
                    $scope.obj.currentPage = $scope.obj.currentPage + 1;
                    var arrLength = parseInt($scope.obj.currentPage) * 12;
                    $scope.QUES_HEADER1 = $scope.obj.quesList[arrLength].QUES_HEADER1;
                    $scope.QUES_HEADER2 = $scope.obj.quesList[arrLength].QUES_HEADER2;

                }


            } else {
                if (p!=1) {
                    alert('You have to give all answer of the above stated questions');
                }
                
            }




        }
        $scope.getLang = function(e) {
            $scope.lang = e;
            $scope.designChange(e);
            $scope.prImg = e == 1 ? 'ques_Next' : 'ques_Back';
            $scope.nImg = e == 1 ? 'ques_Back' : 'ques_Next';
            $scope.stl = e == 1 ? $scope.ala : $scope.ale;
        }
        $scope.sortDataByHeader = function(e) {
            if (e.keyCode==40) {
                NextClick(null, 1);

            }
            else if (e.keyCode == 38) {
                if (document.getElementById("divConfirm").style.display == "inline-block") {
                    document.getElementById("divConfirm").style.display = "none";
                } else {
                    if ($scope.obj.currentPage != 0) {
                        $scope.obj.currentPage = $scope.obj.currentPage - 1;
                    }        
                }
               
               
                
            }
            $scope.selectedRow = 0;
        }
        $scope.changeColor = function(i) {
           

                var k;
                for (k = 0; k < 12; k++) {
                    document.getElementById("trQues" + k).style.backgroundColor = "#ffffff";
                    document.getElementById("trQues" + k).style.color = "#000000";
                    //document.getElementById("tdQuesS" + k).style.backgroundColor = "#ffffff";
                    //document.getElementById("tdQuesF" + k).style.backgroundColor = "#ffffff";
                    document.getElementById("btnSuccess" + k).style.backgroundColor = "#ffffff";
                    document.getElementById("btnFail" + k).style.backgroundColor = "#ffffff";


                    document.getElementById("btnSuccess" + k).style.backgroundSize = "30px";
                    document.getElementById("btnSuccess" + k).style.backgroundRepeat = "no-repeat";
                    document.getElementById("btnSuccess" + k).style.backgroundPosition = "center";
                    document.getElementById("btnSuccess" + k).style.width = "30px";
                    document.getElementById("btnSuccess" + k).style.borderColor = "#FBFBFB";

                    document.getElementById("btnFail" + k).style.backgroundSize = "30px";
                    document.getElementById("btnFail" + k).style.backgroundRepeat = "no-repeat";
                    document.getElementById("btnFail" + k).style.backgroundPosition = "center";
                    document.getElementById("btnFail" + k).style.width = "30px";
                    document.getElementById("btnFail" + k).style.borderColor = "#FBFBFB";

                    //var qAns = angular.element($("#txtQnoAns" + k)).scope().obj.T_QNO_ANS;
                    //var r = angular.element($("#txtSL" + k)).scope().obj.R;
                    //var qAns = angular.element($("#txtQnoAns" + k)).scope().obj.T_QNO_ANS;
                    //if (r != null) { quesCount++; }
                    //if (r != null && qAns != null) {
                    //    ansCount++;
                    //}


                }
                document.getElementById("trQues" + i).style.backgroundColor = "#AF0000";
                document.getElementById("trQues" + i).style.color = "#ffffff";
                document.getElementById("btnFail" + i).style.backgroundColor = "#ffffff";
                document.getElementById("btnSuccess" + i).style.backgroundColor = "#ffffff";
                //document.getElementById("tdQuesS" + z).style.backgroundColor = "#AF0000";
                //document.getElementById("tdQuesF" + z).style.backgroundColor = "#AF0000";

                document.getElementById("btnSuccess" + i).style.backgroundSize = "30px";
                document.getElementById("btnSuccess" + i).style.backgroundRepeat = "no-repeat";
                document.getElementById("btnSuccess" + i).style.backgroundPosition = "center";
                document.getElementById("btnSuccess" + i).style.width = "30px";
                document.getElementById("btnSuccess" + i).style.borderColor = "#FBFBFB";

                document.getElementById("btnFail" + i).style.backgroundSize = "30px";
                document.getElementById("btnFail" + i).style.backgroundRepeat = "no-repeat";
                document.getElementById("btnFail" + i).style.backgroundPosition = "center";
                document.getElementById("btnFail" + i).style.width = "30px";
                document.getElementById("btnFail" + i).style.borderColor = "#FBFBFB";
           
        }
        $scope.onNevigate = function(i) {
            $scope.changeColor(i);
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
app.directive('arrowSelector', ['$document', function ($document) {
    return {
        restrict: 'A',
        link: function ($scope, elem, attrs, ctrl) {
            var elemFocus = true;
            $document.bind('keydown', function (e) {
                if (elemFocus) {
                    if (e.keyCode == 38) {
                        if ($scope.selectedRow == 0 || $("#txtHeader1").is(':focus') || $("#txtHeader2").is(':focus') ) {
                            return;
                        }
                        $scope.selectedRow--;
                        $scope.$apply(function (){
                            $scope.$eval(attrs.arrowSelector);
                        });
                        e.preventDefault();

                    }
                    if (e.keyCode == 40) {
                        if ($scope.selectedRow == 11 || $("#txtHeader1").is(':focus') || $("#txtHeader2").is(':focus')) {
                            return;
                        }
                        $scope.selectedRow++;
                        $scope.$apply(function () {
                            $scope.$eval(attrs.arrowSelector);
                        });
                        e.preventDefault();
                    }
                   

                }
            });
        }
    };
}]);
