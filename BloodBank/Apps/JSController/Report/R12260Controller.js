
app.controller("R12260Controller", ["$scope", "Data", "R12260Service", "$window","$location",
    function ($scope, Data, R12260Service, $window, $location) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.R12260 = {};
       
        $scope.obj.onPrint = function() {
            var fromDate =  $scope.obj.R12260.FromDate;
            var toDate =  $scope.obj.R12260.Todate;
            $scope.obj.FDate = fromDate;
            $scope.obj.TDate = toDate;
            //-------- For Hospital information start -----
            var info = R12260Service.getInfoData();
            info.then(function(inf) {
                var jsonData = JSON.parse(inf);
                $scope.obj.T_COUNTRY_LANG1_NAME = jsonData[0].T_COUNTRY_LANG1_NAME;
                $scope.obj.T_COUNTRY_LANG2_NAME = jsonData[0].T_COUNTRY_LANG2_NAME;
                $scope.obj.T_MIN_LANG1_NAME = jsonData[0].T_MIN_LANG1_NAME;
                $scope.obj.T_MIN_LANG2_NAME = jsonData[0].T_MIN_LANG2_NAME;
                $scope.obj.T_SITE_LANG1_NAME = jsonData[0].T_SITE_LANG1_NAME;
                $scope.obj.T_SITE_LANG2_NAME = jsonData[0].T_SITE_LANG2_NAME;
                gridata();
            });
            //-------- For Hospital information end  -----
        };
        function gridata() {
            var fromDate = $scope.obj.R12260.FromDate;
            var toDate = $scope.obj.R12260.Todate;
            var date = R12260Service.getDate(fromDate, toDate);
            date.then(function (data) {
                $scope.obj.jsnData = JSON.parse(data);
                $scope.obj.DateList = $scope.obj.jsnData;
               // var k = totalUnit($scope.obj.jsnData);
                if ($scope.obj.jsnData.length > 0) {
                    var rep = R12260Service.showReport(fromDate, toDate);
                    rep.then(function (d) {
                        $scope.obj.DataList = JSON.parse(d);
                        $scope.obj.T_USER_NAME = $scope.obj.DataList[0].T_USER_NAME;
                        if ($scope.obj.DataList.length > 0) {
                            var time = R12260Service.getTimeData(fromDate, toDate);
                            time.then(function (t) {
                                $scope.obj.TimeList = JSON.parse(t);
                                $scope.$watch('obj.check', function (newValue, oldValue, scope) {
                                    if ($scope.obj.check !== undefined) {
                                        PDF();
                                    }
                                }, true);
                            });
                        }
                        //$scope.obj.count = document.getElementById("dataTable").rows.length;
                    });
                }

               

            });
        }
        function PDF() {
            var innerContents = document.getElementById('formConfirmation').innerHTML;
            var popupWinindow = window.open('', '_blank', 'width=700,height=900,scrollbars=no,menubar=no,toolbar=no,location=no,status=no,titlebar=no');
            popupWinindow.document.open();
            popupWinindow.document.write('<html><head><link rel="stylesheet" type="text/css" href="style.css" /></head><body onload="window.print()">' + innerContents + '</html>');
            popupWinindow.document.close();
        };
        $scope.print_2 = function() {
            var fromDate = '01/09/18'; // $scope.obj.R12260.FromDate;
            var toDate = '22/09/19'; // $scope.obj.R12260.Todate;

            // $window.open("../R12260/getReport?fromDate=" + fromDate + "&&toDate=" + toDate, "popup", "width=600,height=600,left=100,top=50");
        };

        function totalUnit(dataList) {
            var total = 0;
            for (var i = 0; i < dataList.length; i++) {
                total = total + dataList[i].T_COUNT;
            }
            alert(total);
            return total;
        }
        //var table = document.createElement('table');
        //for (var i = 1; i < 4; i++) {
        //    var tr = document.createElement('tr');

        //    var td1 = document.createElement('td');
        //    var td2 = document.createElement('td');

        //    var text1 = document.createTextNode('Text1');
        //    var text2 = document.createTextNode('Text2');

        //    td1.appendChild(text1);
        //    td2.appendChild(text2);
        //    tr.appendChild(td1);
        //    tr.appendChild(td2);

        //    table.appendChild(tr);
        //}
        //document.body.appendChild(table);

    }]);