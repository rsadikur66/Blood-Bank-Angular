app.controller("T01009Controller", ["$scope", "$filter", "T01009Service", "Data",
    function ($scope, $filter, T01009Service, Data) {
        initializationData();
        $scope.New = function() {
             initializationData();
        }
        $scope.Clear = function() {
             initializationData();
        }

        function initializationData() {
            $scope.selectedRow = 0;
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.HospitalList = [];
            gridLine();
        }
        function gridLine() {
            for (var j = 0; j < 1; j++) {
                $scope.obj.d = {};
                $scope.obj.d.T_EMP_CODE = '';

                $scope.obj.d.T_LOGIN_NAME = '';
                $scope.obj.d.T_PWD = '';
                $scope.obj.d.T_USER_NAME = '';
                $scope.obj.d.T_X_DEPT_CODE = '';
                $scope.obj.d.T_X_DEPT_NAME = '';
                $scope.obj.d.T_ROLE_CODE = '';
                $scope.obj.d.ROLE_NAME = '';
                $scope.obj.d.T_USER_LANG = '';
                $scope.obj.d.T_MACH_RESTR = '';
                $scope.obj.d.T_PH_EXT = '';
                $scope.obj.d.T_MOBILE_NO = '';
                $scope.obj.d.T_NTNLTY_ID = '';
                $scope.obj.d.T_SITE_CODE = '';
                $scope.obj.d.T_HOSPITAL_CODE = '';
                $scope.obj.d.T_ACTIVE_FLAG = '';
                $scope.obj.HospitalList.push($scope.obj.d);
                //$scope.obj.BloodBankList = $scope.obj.Test;
            }
        }//end gridLine


        $scope.EnterQuery = function() {
            var getAllGridData = T01009Service.GetAllUserData();
            getAllGridData.then(function(data) {
                $scope.obj.HospitalList = JSON.parse(data);
                //console.log(d);
            });
        }
        

        $scope.obj.Save = function() {
            
        }
        $scope.ddd = function(index) {
            var aaaa = document.getElementById("row" + index).value;
            alert(aaaa);
        }

        $scope.EmpPopUp = function() {
            document.getElementById("divEmployee").style.display = 'block';
        }
        $scope.DeptPopUP = function() {
            document.getElementById("divDepartment").style.display = 'block';
        }

        $scope.ClosePopup = function(id) {
            document.getElementById(id).style.display = 'none';
        }
        
    }]);