app.controller("Q12207Controller", ["$scope", "Q12207Service", "Data", "$window", "$filter",
    function ($scope, Q12207Service, Data, $window, $filter) {
        $scope.vrb = 0;
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.Stop = '1';
        $scope.obj.Timer = 'TIMER RUNNING';
        $scope.obj.countRequested;
        $scope.obj.countRequestRecived;
        $scope.obj.countIssued;
        $scope.obj.countOutReceived = 0;
        $scope.obj.countDonated = 0;
        $scope.obj.countDelAccept = 0;
        $scope.obj.countDelArrived = 0;
        $scope.obj.countDropped = 0;
        $scope.obj.countHandovered = 0;

        setInterval(function () {
            if ($scope.obj.Stop === '1') {
                LoadGridData(0);
            }
        }, 60000);

        $scope.stopInterval = function () {
            $scope.obj.Stop = '2';
            $scope.obj.Timer = 'TIMER STOP';
        };
        CurrentDate();
        LoadGridData(0);
        $scope.refreshPage = function () {            
            CurrentDate();
            LoadGridData(0);
            $scope.obj.Stop = '1';
            $scope.obj.Timer = 'TIMER RUNNING';
        };
        $scope.DateChange = function () {
            $scope.obj.GridPart = [];
        }
        $scope.nextClick = function () {
            LoadGridData(1);
        }//end
        function CurrentDate() {
            var d = new Date();
            var date = d.getDate();
            var month = d.getMonth() + 1;
            var year = d.getFullYear();
            var fullCurrentDate = date + '/' + month + '/' + year;
            $scope.obj.Date_To = fullCurrentDate;
            $scope.obj.Date_From = fullCurrentDate;
        };

        function LoadGridData(mode) {
            var gridData = Q12207Service.getGridData();
            gridData.then(function (data) {
                $scope.obj.GridPart = JSON.parse(data);
                $scope.obj.request = $scope.obj.GridPart.filter(function (p) { return (p.T_STATUS == "New Request"); })
                $scope.obj.countRequested = $scope.obj.request.length;
                $scope.obj.reRec = $scope.obj.GridPart.filter(function (p) { return (p.T_STATUS == "Request Received"); });
                $scope.obj.countRequestRecived = $scope.obj.reRec.length;
                $scope.obj.Issued = $scope.obj.GridPart.filter(function (p) { return (p.T_STATUS == "Issued"); });
                $scope.obj.countIssued = $scope.obj.Issued.length;                
                $scope.obj.delAccept = $scope.obj.GridPart.filter(function (p) { return (p.T_STATUS == "Delivery Accept"); });
                $scope.obj.countDelAccept = $scope.obj.delAccept.length;
                $scope.obj.arrived = $scope.obj.GridPart.filter(function (p) { return (p.T_STATUS == "Arrived"); });
                $scope.obj.countDelArrived = $scope.obj.arrived.length;
                $scope.obj.Handovered = $scope.obj.GridPart.filter(function (p) { return (p.T_STATUS == "Handovered"); });
                $scope.obj.countHandovered = $scope.obj.Handovered.length;
                $scope.obj.dropped = $scope.obj.GridPart.filter(function (p) { return (p.T_STATUS == "Dropped"); });
                $scope.obj.countDropped = $scope.obj.dropped.length;
                $scope.obj.outRcd = $scope.obj.GridPart.filter(function (p) { return (p.T_STATUS == "Out Received"); });
                $scope.obj.countOutReceived = $scope.obj.outRcd.length;
                
              //  $scope.gridDataList = JSON.parse(data);
                //if ($scope.gridDataList.length > 0) {
                //    $scope.obj.GridPart = [];
                //    console.log($scope.gridDataList);
                //    $scope.obj.countRequested = $scope.gridDataList.length;
                //    $scope.obj.ReceivedRequests = {};
                //    $scope.obj.Received = [];
                //    $scope.obj.IssuedRequests = {};
                //    $scope.obj.Issued = [];
                //    $scope.obj.OutReceived = [];
                //    $scope.obj.OutRcvRequest = {};
                //    for (var i = 0; i < $scope.gridDataList.length; i++) {
                //        if ($scope.gridDataList[i].T_REQUEST_STATUS == '2') {
                //            $scope.obj.ReceivedRequests.T_BLOOD_REQNO = $scope.gridDataList[i].T_BLOOD_REQNO;
                //            $scope.obj.Received.push($scope.obj.ReceivedRequests);
                //            $scope.obj.countRequestRecived = $scope.obj.Received.length;
                //        }
                //        if ($scope.gridDataList[i].T_REQUEST_STATUS == '3') {
                //            $scope.obj.IssuedRequests.T_BLOOD_REQNO = $scope.gridDataList[i].T_BLOOD_REQNO;
                //            $scope.obj.Issued.push($scope.obj.IssuedRequests);
                //            $scope.obj.countIssued = $scope.obj.Issued.length;
                //        }
                //        if ($scope.gridDataList[i].T_REQUEST_STATUS == '5') {
                //            $scope.obj.OutRcvRequest.T_BLOOD_REQNO = $scope.gridDataList[i].T_BLOOD_REQNO;
                //            $scope.obj.OutReceived.push($scope.obj.OutRcvRequest);
                //            $scope.obj.countOutReceived = $scope.obj.OutReceived.length;
                //        }
                //        $scope.obj.test = {};
                //        $scope.obj.test.T_BLOOD_REQNO = $scope.gridDataList[i].T_BLOOD_REQNO;
                //        $scope.obj.test.T_BLOOD_REQDATE = $filter('date')($scope.gridDataList[i].T_BLOOD_REQDATE, "dd/MM/yyyy");
                //        $scope.obj.test.T_BLOOD_REQTIME = $scope.gridDataList[i].T_BLOOD_REQTIME;
                //        $scope.obj.test.TRANS_HOSP = $scope.gridDataList[i].TRANS_HOSP;
                //        $scope.obj.test.CENT_HOSP = $scope.gridDataList[i].CENT_HOSP;
                //        $scope.obj.test.TRANS_HOSP_NAME = $scope.gridDataList[i].TRANS_HOSP_NAME;
                //        $scope.obj.test.CENTR_HOSP_NAME = $scope.gridDataList[i].CENTR_HOSP_NAME;
                //        $scope.obj.test.REQ_RCV_DATE = $scope.gridDataList[i].REQ_RCV_DATE;
                //        $scope.obj.test.REQ_RCV_TIME = $scope.gridDataList[i].REQ_RCV_TIME;
                //        $scope.obj.test.REQ_RCV_FLAG = $scope.gridDataList[i].REQ_RCV_FLAG;
                //        $scope.obj.test.T_BB_ISSUED_DATE = $scope.gridDataList[i].T_BB_ISSUED_DATE;
                //        $scope.obj.test.T_BB_ISSUED_TIME = $scope.gridDataList[i].T_BB_ISSUED_TIME;
                //        $scope.obj.test.OUT_RCV_DATE = $scope.gridDataList[i].OUT_RCV_DATE;
                //        $scope.obj.test.OUT_RCV_TIME = $scope.gridDataList[i].OUT_RCV_TIME;
                //        $scope.obj.test.T_REQUEST_STATUS = $scope.gridDataList[i].T_REQUEST_STATUS;
                //        if ($scope.gridDataList[i].T_REQUEST_STATUS == '1') {
                //            $scope.obj.test.T_REQUEST_STATUS_NAME = 'Request incoming';
                //        } else if ($scope.gridDataList[i].T_REQUEST_STATUS == '2') {
                //            $scope.obj.test.T_REQUEST_STATUS_NAME = 'Request Received';
                //        } else if ($scope.gridDataList[i].T_REQUEST_STATUS == '3') {
                //            $scope.obj.test.T_REQUEST_STATUS_NAME = 'Issued';
                //        } else if ($scope.gridDataList[i].T_REQUEST_STATUS == '5') {
                //            $scope.obj.test.T_REQUEST_STATUS_NAME = 'Out Received';
                //        }
                //        $scope.obj.GridPart.push($scope.obj.test);
                //    }
                //} else {
                //    if (mode == 1) {
                //        alert('No Data Found!!!');
                //        $scope.obj.GridPart = [];
                //    }
                //}
            });
        }
    }
]);