app.controller("Q12017Controller", ["$scope", "Data", "$window", "$filter","Q12017Service",
    function ($scope, Data, $window, $filter, Q12017Service) {
        clear();
        document.getElementById('GridTable').style.display = "none";
        $scope.getData = function (e, p) {
            if (e.keyCode === 9 || e.keyCode === 13) {
                if (p!=null) {
                    var a = $scope.pad(p, 8);
                    $scope.obj.T_REQUEST_NO = $scope.pad(p, 8);
                clear();
                var GetAllData = Q12017Service.GetAllData(a);
                GetAllData.then(function (data) {
                    var dt = JSON.parse(data);
                    if (dt.length > 0) {
                        document.getElementById('GridTable').style.display = "block";
                        $scope.Grid = dt;
                    } else {
                        alert($scope.getSingleMsg('N0043'));
                        clear();
                        document.getElementById('GridTable').style.display = "none";
                    }
                    });
                }
            }

        };
        
        function clear() {
            $scope.obj = {};
            $scope.obj = Data;
            $scope.Grid = {};
            document.getElementById("txtRequest").focus();
            
        }
    }
]);