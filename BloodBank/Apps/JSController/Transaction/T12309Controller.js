
app.controller("T12309Controller",["$scope", "T12309Service", "Data", "$window", "$filter",
        function ($scope, T12309Service, Data, $window, $filter) {
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.T12309 = {};
            $scope.ShowUnitPopup = function () {
                var unit = T12309Service.getUnitData();
                unit.then(function (data) {
                    var jsonData = JSON.parse(data);
                    $scope.obj.Unitlist = jsonData;
                });
                document.getElementById("UnitPopUp").style.display = "block";
            };

            $scope.ClosePatientPopup = function(popup) {
                document.getElementById(popup).style.display = "none";
            };
            $scope.setClickedRow = function (ind, data) {

                var unitNo = data.T_UNIT_NO;
                var prodCode = data.T_PRODUCT_CODE;

                var prdDetails = T12309Service.getProductDetails(unitNo, prodCode);
                prdDetails.then(function (data) {
                    var jsonData = JSON.parse(data);
                    if (jsonData.length>0) {
                        $scope.obj.T12309.T_AUTO_ISSUE_DET_ID = jsonData[0].T_AUTO_ISSUE_DET_ID;
                        $scope.obj.T12309.T_EXPIRY_DATE = jsonData[0].T_EXPIRY_DATE;
                        $scope.obj.T12309.T_ISSUE_DATE = jsonData[0].T_ISSUE_DATE;
                        $scope.obj.T12309.T_ISSUE_TIME = jsonData[0].T_ISSUE_TIME;
                        $scope.obj.T12309.T_SITE_CODE = jsonData[0].T_SITE_CODE;
                        $scope.obj.T12309.T_AUTO_ISSUE_ID = jsonData[0].T_AUTO_ISSUE_ID;
                        $scope.obj.T12309.T_UNIT_STATUS = jsonData[0].T_UNIT_STATUS;
                        $scope.obj.T12309.T_UNIT_NO = jsonData[0].T_UNIT_NO;
                        $scope.obj.T12309.T_PRODUCT_CODE = jsonData[0].T_PRODUCT_CODE;
                        $scope.obj.T12309.PRODUCT_NAME = jsonData[0].PRODUCT_NAME;

                        $scope.obj.T12309.T_REQUEST_NO = jsonData[0].T_REQUEST_NO;
                        var reDate = $filter('date')(jsonData[0].T_REQUEST_DATE, 'dd/MM/yyyy');
                        $scope.obj.T12309.T_REQUEST_DATE = reDate;
                        $scope.obj.T12309.REQUEST_HIJ = getArb(reDate);
                        $scope.obj.T12309.T_BIRTH_DATE = jsonData[0].T_BIRTH_DATE;
                        $scope.obj.T12309.T_BIRTH_PLACE = jsonData[0].T_BIRTH_PLACE;
                        $scope.obj.T12309.T_MRTL_STATUS = jsonData[0].T_MRTL_STATUS;
                        $scope.obj.T12309.T_GENDER = jsonData[0].T_GENDER;
                        $scope.obj.T12309.T_NTNLTY_CODE = jsonData[0].T_NTNLTY_CODE;
                        $scope.obj.T12309.GENDER  =jsonData[0]. GENDER;
                        $scope.obj.T12309.MARL_STATUS_NAME = jsonData[0].MARL_STATUS_NAME;
                        $scope.obj.T12309.NATIONALITY = jsonData[0].NATIONALITY;
                        $scope.obj.T12309.LOCATION_NAME = jsonData[0].LOCATION_NAME;
                        $scope.obj.T12309.T_LOCATION_CODE = jsonData[0].T_LOCATION_CODE;
                        $scope.obj.T12309.T_PAT_NO = jsonData[0].T_PAT_NO;
                        $scope.obj.T12309.PAT_NAME = jsonData[0].PAT_NAME;
                        $scope.obj.T12309.YEAR = jsonData[0].YEAR;
                        $scope.obj.T12309.MONTH = jsonData[0].MONTH;
                        $scope.obj.T12309.DAY = jsonData[0].DAY;

                    //$scope.ProdDetailsList = jsonData;
                    document.getElementById("UnitPopUp").style.display = "none";

                    } else {
                        document.getElementById("UnitPopUp").style.display = "none";
                        alert('Please check the unit status! You can not cancel the unit after release');
                    }
                        
                });
                //$scope.obj.T12300.T_REQUEST_DATE = $filter('date')(new Date(), 'dd-MMM-yyyy');
                //$scope.obj.T12300.REQUEST_HIJ_DATE = getArb(dat);

                //$scope.obj.T1209.T_UNIT_NO = data.T_UNIT_NO;
                //$scope.obj.T1209.T_PRODUCT_CODE = data.T_PRODUCT_CODE;
                
            };
            function getArb(d) {
                var k = $scope.dateParse(d, "/");
                var n = Date.parse(k);
                return moment(n).format('iDD/iMM/iYYYY');
            }

            $scope.Save_Click = function() {
                var save = T12309Service.saveData($scope.obj.T12309);
                save.then(function(sa) {
                    alert(sa);
                    $scope.obj.T12309 = {};
                });
            }

            $scope.setDateTime = function() {
                var today = new Date();
                var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
                var dd = String(today.getDate()).padStart(2, '0');
                var mm = String(months[today.getMonth()]).substr(0, 3); //January is 0!
                var yyyy = today.getFullYear();
                var time = String(today.getHours() + ':' + today.getMinutes());

                today = mm + '-' + dd + '-' + yyyy;
                $scope.obj.T12309.Can_Date = dd + '-' + mm + '-' + yyyy;
                $scope.obj.T12309.Time = time;
                $scope.obj.T12309.Can_Date_Hij = moment(today).format('iYYYY/iMM/iDD');
                $scope.obj.T12309.Cancel_By_Id = JSON.parse(sessionStorage.getItem("EmpCode"));
                $scope.obj.T12309.Cancel_By_Name = JSON.parse(sessionStorage.getItem("UserName"));
            }

        }
    ]);