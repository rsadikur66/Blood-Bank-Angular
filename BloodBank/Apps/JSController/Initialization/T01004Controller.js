app.controller("T01004Controller", ["$scope", "$filter", "$http", "$window", "T01004Service", "Data",
    function ($scope, $filter, $http, $window, T01004Service, Data) { //$location,
        initializationData();
        GetGridData();
        $scope.New = function() { initializationData(); };

        $scope.Clear = function() { initializationData(); };

        function initializationData() {
            $scope.selectedRow = 0;
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.T_UNIT_TYPE = '';
            $scope.obj.T_LANG2_NAME = '';
            $scope.obj.T_LANG1_NAME = '';
            $scope.obj.T_NO_OF_BAG = '';
            $scope.obj.T01004 = {};
            //document.getElementById("txtNumberOfBag").focus();
        }

        $scope.Next = function () { GetGridData(); }

        $scope.EnterControl = function (event) {
            if (event.keyCode === 13) {
                NextData();
            }
            else if (event.keyCode === 114) {
                event.preventDefault();
                NextData();
            }
        };

        function GetGridData() {
            var gridData = T01004Service.GetGridData();
            gridData.then(function (data) {
                $scope.obj.msgList = JSON.parse(data);
            });
        }

        $scope.onRowSelect = function(data) {
            $scope.obj.T01004.T_MSG_CODE = data.T_MSG_CODE;
            $scope.obj.T01004.T_LANG2_MSG = data.T_LANG2_MSG;
            $scope.obj.T01004.T_LANG1_MSG = data.T_LANG1_MSG;
        };
        $scope.clear = function() {
            initializationData();
        };
        $scope.insert = function() {
            var insert = T01004Service.insertData($scope.obj.T01004);
            insert.then(function(data) {
                var msg = JSON.parse(data);
                alert(msg);
                GetGridData();
                initializationData();
            });
        };

    }]);

//angular
//    .module('myApp', [])
    app.directive('capitalize', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, modelCtrl) {
                var capitalize = function (inputValue) {
                    if (inputValue == undefined) inputValue = '';
                    var capitalized = inputValue.toUpperCase();
                    if (capitalized !== inputValue) {
                        // see where the cursor is before the update so that we can set it back
                        var selection = element[0].selectionStart;
                        modelCtrl.$setViewValue(capitalized);
                        modelCtrl.$render();
                        // set back the cursor after rendering
                        element[0].selectionStart = selection;
                        element[0].selectionEnd = selection;
                    }
                    return capitalized;
                }
                modelCtrl.$parsers.push(capitalize);
                capitalize(scope[attrs.ngModel]); // capitalize initial value
            }
        };
    });