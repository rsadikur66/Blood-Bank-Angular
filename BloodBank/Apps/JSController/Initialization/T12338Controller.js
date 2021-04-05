app.controller("T12338Controller", ["$scope", "T12338Service", "$filter", "$http", "$window", "Data",
    function ($scope, T12338Service, $filter, $http, $window, Data) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.t12338 = {};
        $scope.obj.BloodBankList = [];
        $scope.GetCentralBankList = function () {
            CentralBankListPopup();
        }
        $scope.PopUpOnf9 = function () {
            if (event.keyCode === 120) {
                CentralBankListPopup();
            }
        }
        function CentralBankListPopup() {
            var ListofCentralBank = T12338Service.GetCentralBankList();
            ListofCentralBank.then(function (data) {
                $scope.CentralBankList = JSON.parse(data);
            });
            document.getElementById("divCentralBankList").style.display = 'block';
        }
        $scope.onCentralBankSelect = function (i) {
            $scope.obj.T_CENTRAL_BANK_CODE = $scope.CentralBankList[i].CODE;
            $scope.obj.T_CENTRAL_BANK_NAME = $scope.CentralBankList[i].NAME;
            $scope.obj.BloodBankList = [];
            document.getElementById("divCentralBankList").style.display = 'none';
        }
        $scope.CloseCentralBankPopup = function () {
            document.getElementById("divCentralBankList").style.display = 'none';
        }
        $scope.Next = function () {
            if ($scope.obj.T_CENTRAL_BANK_CODE !== undefined) {
                getGridData();
            } else {
                alert("Must Select Central Bank.");
            }
        }//Finish Next Function
        $scope.Save = function () {
            if ($scope.obj.T_CENTRAL_BANK_CODE !== undefined) {
                var t12338 = $scope.obj.BloodBankList;
                if (t12338.length > 0) {
                    var insert;
                    for (var i = 0; i < t12338.length; i++) {
                        if ($scope.obj.BloodBankList[i].HiddenField != undefined && $scope.obj.BloodBankList[i].HiddenField != '') {
                            var INS = {};
                            INS.T_BANK_CODE = t12338[i].T_BANK_CODE;
                            INS.T_LANG2_NAME = t12338[i].T_LANG2_NAME;
                            INS.T_LANG1_NAME = t12338[i].T_LANG1_NAME;
                            INS.T_BANK_ACTIVE = t12338[i].HiddenField;
                            INS.T_CENTRAL_BANK_CODE = $scope.obj.T_CENTRAL_BANK_CODE;
                            insert = T12338Service.insertToT12338(INS);
                        }
                    }//for
                    insert.then(function (data) {
                        getGridData();
                        alert(data);

                    });

                }
            } else {
                alert("Must Select Central Bank.");
            }

        }//funcitonSave

        $scope.ActiveCheckboxClicked = function (index) {
            var firstCompoCheck = document.getElementById("BBActive" + index).checked;
            //alert(firstCompoCheck);
            if (firstCompoCheck == true) {
                $scope.obj.BloodBankList[index].HiddenField = '1';
            } else {
                $scope.obj.BloodBankList[index].HiddenField = '2';
            }
        }
        function getGridData() {
            var ListOfTransfusionBank = T12338Service.GetTransfusionsList($scope.obj.T_CENTRAL_BANK_CODE);
            ListOfTransfusionBank.then(function (data) {
                var BloodBankListData = JSON.parse(data);
                $scope.obj.BloodBankList = [];
                for (var i = 0; i < BloodBankListData.length; i++) {
                    $scope.obj.test = {};
                    $scope.obj.test.T_BANK_CODE = BloodBankListData[i].T_BANK_CODE;
                    $scope.obj.test.T_LANG2_NAME = BloodBankListData[i].T_LANG2_NAME;
                    $scope.obj.test.T_LANG1_NAME = BloodBankListData[i].T_LANG1_NAME;
                    $scope.obj.test.T_BANK_ACTIVE = BloodBankListData[i].T_BANK_ACTIVE;
                    if (BloodBankListData[i].T_BANK_ACTIVE === '1') {
                        $scope.obj.test.T_BANK_ACTIVE = true;
                        $scope.obj.test.HiddenField = BloodBankListData[i].T_BANK_ACTIVE;

                    } else {
                        $scope.obj.test.T_BANK_ACTIVE = false;
                        $scope.obj.test.HiddenField = BloodBankListData[i].T_BANK_ACTIVE;
                    }
                    $scope.obj.BloodBankList.push($scope.obj.test);
                }
                //gridLine();
            });
        }//end getGridData

        function gridLine() {
            for (var j = 0; j < 1; j++) {
                $scope.obj.d = {};
                $scope.obj.d.T_BANK_CODE = '';

                $scope.obj.d.T_LANG2_NAME = '';
                $scope.obj.d.T_LANG1_NAME = '';
                $scope.obj.d.T_BANK_ACTIVE = '';
                $scope.obj.d.HiddenField = '';
                $scope.obj.BloodBankList.push($scope.obj.d);
                //$scope.obj.BloodBankList = $scope.obj.Test;
            }
        }//end gridLine
    }]);