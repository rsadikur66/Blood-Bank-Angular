app.controller("Q12018Controller", ["$scope", "Q12018Service", "Data", "$window", "$filter",
    function ($scope, Q12018Service, Data, $window, $filter) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.q12018 = {};
        var Language = JSON.parse(sessionStorage.getItem("LangName"));
        document.getElementById('txtUnitNo').focus();

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

        $scope.DatawithEnter = function(e) {
            if (e.keyCode === 13) {
                var unitNo = $scope.obj.T_UNIT_NO;
                firstGridLoad(unitNo);
                SecondGridLoad(unitNo);
            }
        };
        $scope.NextClick = function() {
            var unitNo = $scope.obj.T_UNIT_NO;
            firstGridLoad(unitNo);
            SecondGridLoad(unitNo);
        };
        $scope.ClearAll = function() {
            clear();
        };
        function firstGridLoad(unitNo) {
            if (unitNo !== undefined) {
                var _1stGridData = Q12018Service.GetFirstGridData(unitNo);
                _1stGridData.then(function (data) {
                    $scope.firstGridDataList = JSON.parse(data);
                    console.log($scope.firstGridDataList);
                    if ($scope.firstGridDataList.length > 0) {
                        $scope.obj.GridPart = [];
                        for (var i = 0; i < $scope.firstGridDataList.length; i++) {
                            $scope.obj.test = {};
                            $scope.obj.test.T_UNIT_NO = $scope.firstGridDataList[i].T_UNIT_NO;
                            $scope.obj.test.T_REQUEST_NO = $scope.firstGridDataList[i].T_REQUEST_NO;
                            $scope.obj.test.T_PRODUCT_ID = $scope.firstGridDataList[i].T_PRODUCT_CODE;
                            $scope.obj.test.T_PRODUCT = $scope.firstGridDataList[i].PRODUCT_DESC;
                            $scope.obj.test.T_BLOOD_GROUP_CODE = $scope.firstGridDataList[i].T_BLOOD_GROUP_CODE;
                            if ($scope.firstGridDataList[i].T_UNIT_STATUS == null) {
                                var d1 = new Date();
                                if (new Date($scope.firstGridDataList[i].T_EXPIRY_DATE) < d1.getDate()) {
                                    $scope.obj.test.T_UNIT_STATUS = 'Unit Expired';
                                } else {
                                    $scope.obj.test.T_UNIT_STATUS = 'Unit in Stock';
                                }

                            } else {
                                $scope.obj.test.T_UNIT_STATUS = $scope.firstGridDataList[i].T_UNIT_STATUS_TYPE;
                            }
                            $scope.obj.test.T_DONAT_DATE = $scope.firstGridDataList[i].T_DONATION_DATE;
                            $scope.obj.test.T_EXPIRY_DATE = $scope.firstGridDataList[i].T_EXPIRY_DATE;
                            $scope.obj.test.T_TYPE = $scope.firstGridDataList[i].T_TYPE;
                            $scope.obj.GridPart.push($scope.obj.test);
                        }//loop end
                        $scope.obj.T_HOSP_NAME = $scope.firstGridDataList[0].HOSPITAL_NAME;
                        $scope.obj.T_ISSUE_DATE = $scope.firstGridDataList[0].T_ISSUE_DATE;
                    }
                });
            } else {
                alert("Please input unit no!!!");
            }
        }
        function SecondGridLoad(unitNo) {
            if (unitNo !== undefined) {
                var _2ndGridData = Q12018Service.GetSecondGridData(unitNo);
                _2ndGridData.then(function (data) {
                    $scope.secondGridDataList = JSON.parse(data);
                    console.log($scope.secondGridDataList);
                    if ($scope.secondGridDataList.length > 0) {
                        $scope.obj.GridPart2 = [];
                        for (var i = 0; i < $scope.secondGridDataList.length; i++) {
                            $scope.obj.test = {};
                            $scope.obj.test.T_UNIT_NO = $scope.secondGridDataList[i].T_UNIT_NO;
                            $scope.obj.test.T_REQUEST_NO = $scope.secondGridDataList[i].T_REQUEST_NO;
                            $scope.obj.test.T_PRODUCT_ID = $scope.secondGridDataList[i].T_PRODUCT_CODE;
                            $scope.obj.test.T_PRODUCT = $scope.secondGridDataList[i].PRODUCT_DESC;
                            $scope.obj.test.T_BLOOD_GROUP_CODE = $scope.secondGridDataList[i].T_BLOOD_GROUP_CODE;
                            if ($scope.secondGridDataList[i].T_UNIT_STATUS == null) {
                                var d1 = new Date();
                                if (new Date($scope.secondGridDataList[i].T_EXPIRY_DATE) < d1.getDate()) {
                                    $scope.obj.test.T_UNIT_STATUS = 'Unit Expired';
                                } else {
                                    $scope.obj.test.T_UNIT_STATUS = 'Unit in Stock';
                                }
                                
                            } else {
                                $scope.obj.test.T_UNIT_STATUS = $scope.secondGridDataList[i].T_UNIT_STATUS_TYPE;
                            }
                            $scope.obj.test.T_DONAT_DATE = $scope.secondGridDataList[i].T_DONATION_DATE;
                            $scope.obj.test.T_EXPIRY_DATE = $scope.secondGridDataList[i].T_EXPIRY_DATE;
                            $scope.obj.test.T_TYPE = $scope.secondGridDataList[i].T_TYPE;
                            $scope.obj.GridPart2.push($scope.obj.test);
                        }//loop end
                        $scope.obj.T_HOSP_NAME = $scope.firstGridDataList[0].HOSPITAL_NAME;
                        $scope.obj.T_ISSUE_DATE = $scope.firstGridDataList[0].T_ISSUE_DATE;
                    }
                });
            } else {
                alert("Please input unit no!!!");
            }
        }
        function clear() {
            $scope.obj.T_UNIT_NO = '';
            $scope.obj.T_REQUEST_NO = '';
            $scope.obj.T_PRODUCT = '';
            $scope.obj.T_BLOOD_GROUP_CODE = '';
            $scope.obj.T_UNIT_STATUS = '';
            $scope.obj.T_DONAT_DATE = '';
            $scope.obj.T_EXPIRY_DATE = '';
            $scope.obj.T_TYPE = '';
        }
    }]);


