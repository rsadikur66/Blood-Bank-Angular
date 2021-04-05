app.controller("Q12200Controller", ["$scope", "Q12200Service", "Data", "$window", "$filter",
    function ($scope, Q12200Service, Data, $window, $filter) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.Stop = '1';
        $scope.obj.Timer = 'TIMER RUNNING';
        getDate();
        LoadGridData();
        var months = ["", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        $scope.obj.countNotExamined = 0;
        $scope.obj.countNotDonated = 0;
        $scope.obj.countExamined = 0;
        $scope.obj.countDonated = 0;
        $scope.obj.countRegistered = 0;
        $scope.PrevDate = function (count) {
            var originalDate = count;
            var convertOriginalDate = originalDate.toString().split("/");
            var d = convertOriginalDate[0];
            var m = convertOriginalDate[1];
            var y = convertOriginalDate[2];
            var convertedOriginalDate = m + "/" + d + "/" + y;

            var actualDate = new Date(convertedOriginalDate);
            var newDate = new Date(actualDate.getFullYear(), actualDate.getMonth(), actualDate.getDate() - 1);
            var converdate = newDate.toString().split(" ");
            var dayName = converdate[0];
            var month = converdate[1];
            var dayNumber = converdate[2];
            var year = converdate[3];
            var newdte = dayNumber + "/" + pad(months.indexOf(month)) + "/" + year//dayName+","+month+","+dayNumber+","+year;
            $scope.obj.TODAY_DATE = newdte;
        }
        $scope.NextDate = function (count) {
            var originalDate = $scope.obj.TODAY_DATE;
            var convertOriginalDate = originalDate.toString().split("/");
            var d = convertOriginalDate[0];
            var m = convertOriginalDate[1];
            var y = convertOriginalDate[2];
            var convertedOriginalDate = m + "/" + d + "/" + y;

            var actualDate = new Date(convertedOriginalDate);
            var newDate = new Date(actualDate.getFullYear(), actualDate.getMonth(), actualDate.getDate() + 1);
            var converdate = newDate.toString().split(" ");
            var dayName = converdate[0];
            var month = converdate[1];
            var dayNumber = converdate[2];
            var year = converdate[3];
            var newdte = dayNumber + "/" + pad(months.indexOf(month)) + "/" + year;//dayName+","+month+","+dayNumber+","+year;
            $scope.obj.TODAY_DATE = newdte.toString();
        };
        $scope.nextClick = function () {
            LoadGridData();
        }//end
        $scope.refreshPage = function () {
           // window.location.reload();
            getDate();
            LoadGridData();
            $scope.obj.Stop = '1';
            $scope.obj.Timer = 'TIMER RUNNING';
        };

        function LoadGridData() {
            var gridData = Q12200Service.getGridData($scope.obj.TODAY_DATE);
            gridData.then(function (data) {
                $scope.gridDataList = JSON.parse(data);

                if ($scope.gridDataList.length > 0) {
                    $scope.obj.GridPart = [];
                    var j = 1;
                    var f = 1;
                    var m = 1;
                    var a = 1;
                    for (var i = 0; i < $scope.gridDataList.length; i++) {
                        $scope.obj.test = {};
                        $scope.obj.test.T_DONOR_NO = $scope.gridDataList[i].T_PAT_NO;
                        $scope.obj.test.T_DONOR_NAME = $scope.gridDataList[i].PAT_NAME;
                        $scope.obj.test.T_DAKHILA_NAME = '';
                        $scope.obj.test.T_DAKHILA_TIME = '';
                        $scope.obj.test.EXAMINATION_DESC = $scope.gridDataList[i].EXAMINATION_DESC;
                        if ($scope.gridDataList[i].EXAMINATION_DESC == 'NOT YET') {
                            var notexamined = j++;
                        } else {
                            var examined = a++;
                        }
                        $scope.obj.test.EXAM_TIME = $scope.gridDataList[i].EXAM_TIME;
                        $scope.obj.test.T_DONATION_ROOM = $scope.gridDataList[i].DONATION_DESC;
                        if ($scope.gridDataList[i].DONATION_DESC == 'NOT YET') {
                            var notdonated = f++;
                        } else if ($scope.gridDataList[i].DONATION_DESC == 'BLOOD TAKEN') {
                            var donated = m++;
                        }
                        $scope.obj.test.T_DONATION_ROOM_TIME = $scope.gridDataList[i].DONAT_TIME;
                        $scope.obj.GridPart.push($scope.obj.test);
                        console.log($scope.obj.countNotExamined);
                    }
                    $scope.obj.countNotExamined = notexamined;
                    $scope.obj.countNotDonated = notdonated;
                    $scope.obj.countDonated = donated;
                    $scope.obj.countExamined = examined;
                    $scope.obj.countRegistered = $scope.gridDataList.length;
                } else {
                    partGridView();
                }

            });

        }
           
        setInterval(function () {
            if ($scope.obj.Stop === '1') {
                LoadGridData();
            }
        }, 10000);
           
      

        $scope.stopInterval = function() {
            $scope.obj.Stop = '2';
            $scope.obj.Timer = 'TIMER STOP';
        };

        function partGridView() {
            $scope.obj.GridPart = [];
            for (var i = 0; i < 20; i++) {
                $scope.obj.test = {};
                $scope.obj.test.T_DONOR_NO = '';
                $scope.obj.test.T_DONOR_NAME = '';
                $scope.obj.test.T_DAKHILA_NAME = '';
                $scope.obj.test.T_DAKHILA_TIME = '';
                $scope.obj.test.T_CHECKING = '';
                $scope.obj.test.T_CHECKING_TIME = '';
                $scope.obj.test.T_DONATION_ROOM = '';
                $scope.obj.test.T_DONATION_ROOM_TIME = '';
                $scope.obj.GridPart.push($scope.obj.test);
            }
        }
        function getDate() {
            var datetoday = new Date();
            var dateonly = datetoday.getDate();
            var monthonly = datetoday.getMonth() + 1;
            var yearonly = datetoday.getFullYear();
            var getFullDate = dateonly + "/" + monthonly + "/" + yearonly;
            $scope.obj.TODAY_DATE = '';
            $scope.obj.TODAY_DATE = getFullDate;
        }//end

        $scope.enterDate = function (event,dateEnter) {
            if (event.keyCode == 13) {
                //alert('working;');
                LoadGridData();
            }
        }
        $scope.TAT_Print = function () {
            var datefrom = $scope.obj.TODAY_DATE;
            $window.open("../Q12200/TAT_Report_R12219?dateFrom=" + datefrom, "popup", "width=600,height=600,left=100,top=50");
        };
        $scope.UNIT_Print = function () {
            var datefrom = $scope.obj.TODAY_DATE;
            $window.open("../Q12200/UNIT_Report_R12219?entryDate=" + datefrom, "popup", "width=600,height=600,left=100,top=50");
        };

        $scope.Graph_Print = function () {
            var datefrom = $scope.obj.TODAY_DATE;
            $window.open("../Q12200/GRAPH_Report_R12219?entryDate=" + datefrom, "popup", "width=600,height=600,left=100,top=50");
        };

        function pad(n)
        {
            return (n < 10 ? '0' + n : n);
        }
    }
]);