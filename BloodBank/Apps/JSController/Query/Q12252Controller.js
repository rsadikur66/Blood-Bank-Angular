app.controller("Q12252Controller", ["$scope", "Data", "Q12252Service",
    function ($scope, Data, Q12252Service) {
        $scope.obj = {};
        $scope.obj = Data;
        document.getElementById("txtUnit").focus();
        clearUpper();
        clearDown();
        document.getElementById('DetailDataDiv').style.display = "none";
        $scope.getData = function (e, p) {
            if (e.keyCode === 9 || e.keyCode === 13) {
                clearDown();
                var GetDataByUnitNo = Q12252Service.GetDataByUnitNo(p);
                GetDataByUnitNo.then(function (data) {
                    var dt = JSON.parse(data);
                    if (dt.length > 0) {
                        var P_DONOR_ID = dt[0].DONORID;
                        $scope.v12051 = dt[0];
                        loadFirstGrid(P_DONOR_ID);
                        loadSecondGrid(P_DONOR_ID);
                        document.getElementById('DetailDataDiv').style.display = "block";
                    } else {
                        alert($scope.getSingleMsg('N0043'));
                        clearUpper();
                        clearDown();
                        document.getElementById('DetailDataDiv').style.display = "none";
                    }
                });
            }
            
        };

        function loadFirstGrid(e) {
            var GetDataByDonor1 = Q12252Service.GetDataByDonor1(e);
            GetDataByDonor1.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    $scope.FirstGrid = dt;
                } else {
                    $scope.FirstGrid = {};
                }
            });
        };

        function loadSecondGrid(e) {
            var GetDataByDonor2 = Q12252Service.GetDataByDonor2(e);
            GetDataByDonor2.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    $scope.SesondGrid = dt;
                } else {
                    $scope.SesondGrid = {};
                }
            }); 
        };
        $scope.obj.Clear = function() {
            clearUpper();
            clearDown();
        }
        function clearUpper() {
            $scope.v12051 = {};
        }
        function clearDown() {
            $scope.FirstGrid = {};
            $scope.SesondGrid = {};
        }

    }
]);