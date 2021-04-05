
app.controller("T12091Controller",
    ["$scope", "$filter", "T12091Service", "Data",
        function ($scope, $filter, T12091Service, Data) {
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.t12091 = {};
            $scope.obj.ChkHandover = 'Disable';
            $scope.DeliveryMan_dblClick = function () {
                var deliveryman = T12091Service.getDeliveryManData();
                deliveryman.then(function (data) {
                    $scope.obj.DeliveryManData = JSON.parse(data);
                    if ($scope.obj.DeliveryManData.length > 0) {
                        document.getElementById("divDeliveryMan").style.display = 'block';
                    } else {
                        document.getElementById("divDeliveryMan").style.display = 'none';
                    }
                })

                
            }
            $scope.DeliveryManRowSelect = function (ind, data) {
                $scope.obj.t12091.T_DELIVERY_CODE = $scope.obj.DeliveryManData[ind].CODE;
                $scope.obj.t12091.T_DELIVERY_NAME = $scope.obj.DeliveryManData[ind].NAME;
                $scope.obj.t12091.T_BLOOD_REQ_NO = $scope.obj.DeliveryManData[ind].T_BLOOD_REQ_NO;
                $scope.obj.t12091.T_SITE_CODE = $scope.obj.DeliveryManData[ind].T_SITE_CODE;
                $scope.obj.t12091.T_RCVD_DATE = $filter('date')(new Date(), "dd/MM/yyyy");
                $scope.obj.t12091.T_RCVD_TIME = $filter('date')(new Date(), "HHmm");
                document.getElementById("divDeliveryMan").style.display = 'none';
            }
            $scope.Next = function () {
                var reqDetails = T12091Service.getReqDetails($scope.obj.t12091.T_BLOOD_REQ_NO, $scope.obj.t12091.T_SITE_CODE);
                reqDetails.then(function (data) {
                    $scope.Details = JSON.parse(data);
                    if ($scope.Details.length > 0) {
                        $scope.obj.t12091.T_REF_HOSP = $scope.Details[0].T_REF_HOSP;
                        $scope.obj.t12091.T_REFERRAL_NAME = $scope.Details[0].T_REFERRAL_NAME;
                        $scope.obj.t12091.T_BLOOD_GRP = $scope.Details[0].T_BLOOD_GRP;
                        $scope.obj.t12091.BLD_NAME = $scope.Details[0].BLD_NAME;
                        $scope.obj.t12091.T_PRODUCT_CODE = $scope.Details[0].T_PRODUCT_CODE;
                        $scope.obj.t12091.T_PRODUCT_NAME = $scope.Details[0].T_PRODUCT_NAME;
                        $scope.obj.t12091.T_NUM_UNIT = $scope.Details[0].T_NUM_UNIT;
                        $scope.obj.t12091.T_PRODUCT_NAME = $scope.Details[0].T_PRODUCT_NAME;
                        $scope.obj.t12091.T_SITE_CODE = $scope.Details[0].T_SITE_CODE;
                        $scope.obj.ChkHandover = 'Enable';
                    } else {
                        $scope.obj.ChkHandover = 'Disable';
                    }

                });
            }

            $scope.Handover_Flag = function () {
                var id = $scope.obj.t12091.T_Handover_FLAG;
                if ($scope.obj.t12091.T_Handover_FLAG == '1') {
                    var userDetails = T12091Service.getuserDetails();
                    userDetails.then(function (data) {
                        $scope.Details = JSON.parse(data);
                        $scope.obj.t12091.T_EMP_CODE = $scope.Details[0].T_EMP_CODE;
                        $scope.obj.t12091.T_USER_NAME = $scope.Details[0].T_USER_NAME;
                        $scope.obj.t12091.T_HANDOVER_DATE = $filter('date')(new Date(), "dd/MM/yyyy");
                        $scope.obj.t12091.T_HANDOVER_TIME = $filter('date')(new Date(), "HHmm");


                    });
                } else {
                    $scope.obj.t12091.T_EMP_CODE = '';
                    $scope.obj.t12091.T_USER_NAME = '';
                    $scope.obj.t12091.T_HANDOVER_DATE = '';
                    $scope.obj.t12091.T_HANDOVER_TIME = '';
                }
            };
            $scope.Save = function () {
                if ($scope.obj.t12091.T_Handover_FLAG == '1') {
                    var save = T12091Service.save($scope.obj.t12091.T_BLOOD_REQ_NO, $scope.obj.t12091.T_HANDOVER_TIME, $scope.obj.t12091.T_SITE_CODE);
                    save.then(function (data) {
                        var dt = JSON.parse(data);
                        $scope.obj.t12091 = {};
                        $scope.obj.ChkHandover = 'Disable';
                        alert($scope.getSingleMsg(dt));

                    });
                } else {
                    alert('Check Receive');
                }

            };


            $scope.ClosePopup = function (id) {
                document.getElementById(id).style.display = 'none';
            };
    }]);
