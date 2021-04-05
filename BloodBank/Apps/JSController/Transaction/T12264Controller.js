app.controller("T12264Controller", ["$scope", "T12264Service", "$filter", "$http", "$window", "Data",
  function ($scope, T12264Service, $filter, $http, $window, Data) {
    $scope.obj = {};
    $scope.obj = Data;
    $scope.obj.t12264 = {};
    document.getElementById("1stDiv").style.display = 'none';

    $scope.GetReqData = function () {
      $scope.obj.t12264.T_REQ_NO = $scope.obj.t12264.T_REQ_NO.padStart(7, '0');
      var gridData = T12264Service.GetDataWithReqNo($scope.obj.t12264.T_REQ_NO);
      gridData.then(function (data) {
        var testData = JSON.parse(data);
        if (testData.length > 0) {

          $scope.obj.t12264.T_REQ_DATE = testData[0].T_BLOOD_REQDATE;
          $scope.obj.t12264.T_BLOOD_REQTIME = testData[0].T_BLOOD_REQTIME;
          $scope.obj.t12264.T_BLOOD_GRP_REQ = testData[0].T_BLOOD_GRP_REQ;
          $scope.obj.t12264.T_PRODUCT_CODE = testData[0].T_PRODUCT_CODE;
          $scope.obj.t12264.T_NUM_UNIT = testData[0].T_NUM_UNIT;
          $scope.obj.IssuedBloodList = [];
          for (var i = 0; i < testData.length; i++) {
            $scope.obj.e = {};
            $scope.obj.e.unitNo = testData[i].T_UNIT_NO;
            $scope.obj.e.ProductCode = testData[i].T_PRODUCT_CODE;
            $scope.obj.e.BloodGroup = testData[i].T_BLOOD_GRP;
            $scope.obj.e.IssueDate = $filter('date')(testData[i].T_BB_ISSUED_DATE, "dd/MM/yyyy");
            $scope.obj.e.IssueTime = testData[i].T_BB_ISSUED_TIME;
            $scope.obj.e.ExpiryDate = $filter('date')(testData[i].T_BLOOD_EXPIRY_DATE, "dd/MM/yyyy");;
            $scope.obj.e.ReceivedCheck = testData[i].T_HOSP_RECEIVED_FLAG;
            //$scope.obj.e.ReceivedBy = testData[i].T_HOSP_RECEIVED_BY;
            $scope.obj.e.ReceivedDate = testData[i].T_HOSP_RECEIVED_DATE;
            $scope.obj.e.ReceivedTime = testData[i].T_HOSP_RECEIVED_TIME;
            $scope.obj.e.T_EMP_CODE = testData[i].T_EMP_CODE;
              $scope.obj.e.T_USER_NAME = testData[i].T_USER_NAME;
              $scope.obj.e.T_SITE_CODE = testData[i].T_SITE_CODE;
            $scope.obj.IssuedBloodList.push($scope.obj.e);
          }
          document.getElementById("1stDiv").style.display = 'block';
        } else {
          alert("No Data Found!!!");
        }
      });
    };


    $scope.Save = function () {
      var t12264 = $scope.obj.IssuedBloodList;
      if (t12264.length > 0) {
        for (var i = 0; i < t12264.length; i++) {
          if (t12264[i].T_HOSP_RECEIVED_BY != '') {
            var INS = {};
            INS.T_UNIT_NO = t12264[i].unitNo;
            INS.T_BLOOD_REQNO = $scope.obj.t12264.T_REQ_NO;
            INS.T_HOSP_RECEIVED_FLAG = t12264[i].ReceivedCheck==true?"1":"0";
              INS.T_HOSP_RECEIVED_BY = t12264[i].ReceivedByCode;
            INS.T_HOSP_RECEIVED_DATE = t12264[i].ReceivedDate;
            INS.T_HOSP_RECEIVED_TIME = t12264[i].ReceivedTime;
              INS.T_REQUEST_STATUS = "4";
              INS.T_SITE_CODE = t12264[i].T_SITE_CODE;
            //INS.T_ACTIVE = t12263[i].HiddenField;
            updateT12067 = T12264Service.T12264updateT12067andT12065(INS);
            //updateT12065 = T12264Service.T12264updateT12065();
              updateT12067.then(function (data) {                 
                  $scope.obj.e = {};
                  $scope.obj.t12264 = {};
                  $scope.obj.IssuedBloodList = [];
              });
          }
        }
      } else {
        alert('Please Receive First');
        }
        alert("Received Successfully.");
    };

    $scope.Next = function () {
      alert('next working');
    };

    $scope.Clear = function () {
      alert('clear working');
    };

    $scope.flagCheck = function (index) {
      var ReceivedCheckBox = document.getElementById("txtReceiveFlag" + index).checked;
      if (ReceivedCheckBox == true) {
        $scope.obj.IssuedBloodList[index].ReceivedDate = $filter('date')(new Date(), "dd/MM/yyyy");
        $scope.obj.IssuedBloodList[index].ReceivedTime = $filter('date')(new Date(), "HH:mm");
        $scope.obj.IssuedBloodList[index].ReceivedByCode = $scope.obj.e.T_EMP_CODE;
        $scope.obj.IssuedBloodList[index].ReceivedBy = $scope.obj.e.T_USER_NAME;
      } else {
        $scope.obj.BloodIssueList[index].IssueDate = '';
        $scope.obj.BloodIssueList[index].IssueTime = '';
        $scope.obj.BloodIssueList[index].IssuedBy_Code = '';
        $scope.obj.BloodIssueList[index].IssuedBy_Name = '';
      }
    }

  }]);