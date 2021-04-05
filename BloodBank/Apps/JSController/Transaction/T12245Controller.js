app.controller("T12245Controller", ["$scope", "T12245Service", "Data", "$window", "$filter",
    function ($scope, T12245Service, Data, $window, $filter) {
        var Language = JSON.parse(sessionStorage.getItem("LangName"));
        var mmm = '';
        var ddd = '';
        Clear();
        
        $scope.GetCentrifugeData = function () {
            fnCentrifugeData();
        }
        $scope.btnf9Centrifuge = function (event) {
            event.preventDefault();
            if (event.keyCode === 120) {
                fnCentrifugeData();
            }
        }
        $scope.onCentrifugeSelect = function (i) {
            $scope.obj.t12135.T_CENTRIFUGE_MACHINE_CODE = $scope.CentrifugeList[i].CODE;
            $scope.obj.T_CENTRIFUGE_MACHINE_NAME = $scope.CentrifugeList[i].NAME;
            document.getElementById("divCentrifuge").style.display = 'none';
            document.getElementById("txtProgramCode").focus();
        }
        $scope.CloseCentrifugePopup = function () {
            document.getElementById("divCentrifuge").style.display = 'none';
        }
        //Centrifuge section end
        $scope.GetProgramData = function () {
            fnProgramData();
        }
        $scope.btnf9_Program = function (event) {
            if (event.keyCode === 120) {
                fnProgramData();
            }
        }
        $scope.onProgramSelect = function (i) {
            $scope.obj.t12135.T_PROGRAM_CODE = $scope.ProgramList[i].CODE;
            $scope.obj.PROGRAM_NAME = $scope.ProgramList[i].NAME;
            $scope.obj.T_SPEED = $scope.ProgramList[i].T_SPEED;
            $scope.obj.T_TEMP = $scope.ProgramList[i].T_TEMP;
            $scope.obj.T_TIME = $scope.ProgramList[i].T_TIME;
            document.getElementById("divProgram").style.display = 'none';
            document.getElementById("txtUnit").focus();
            $scope.truefalse = false;
        }
        $scope.CloseProgramPopup = function () {
            document.getElementById("divProgram").style.display = 'none';
        }
        //Program section end
        $scope.MoveIntoDownComponent = function (index) {
            var firstCompoCheck = document.getElementById("Chk1stCompo" + index).checked;
            if (firstCompoCheck === true) {
                $scope.obj.test1 = {};
                $scope.obj.t12135.T_PROD_CODE = $scope.obj.productInfo[index].T_PRODUCT_CODE;
                $scope.obj.t12135.T_SEGMENT_NO = $scope.obj.productInfo[index].T_SEGMENT_NO;
                $scope.obj.t12135.T_DONATION_DATE = $filter('date')($scope.obj.productInfo[index].T_DONATION_DATE, "dd-MMM-yyyy");
                $scope.obj.t12135.T_PROD_EXPIRY_DATE = $filter('date')($scope.obj.productInfo[index].T_EXPIRY_DAYS, "dd-MMM-yyyy");
                $scope.obj.t12135.T_CHECK_FLAG = '1';

                var result=  T12245Service.Insert($scope.obj.t12135);
                //$scope.obj.secondPart.push($scope.obj.t12135);
                if ($scope.obj.t12135.T_UNIT_NO != '' || $scope.obj.t12135.T_SEGMENT_NO != '') {
                    T12245Service.UpdateT12135($scope.obj.t12135.T_UNIT_NO);
                }
                //SecondGridData();
                //removeRow(index);

                result.then(function(data) {
                    GridData();
                });


            }
        }
        $scope.GetDataWithEnterOrF3 = function (event) {
            $scope.blur = true;
            if (event.keyCode === 13) {
                event.preventDefault();
                gd();
                
            }
        }
        $scope.GetData = function () {
            gd();
        }
        $scope.DeleteRow = function (index) {
            if ($scope.obj.secondPart[index].Check_1 === '1') {
                var result = T12245Service.DeleteRowData($scope.obj.t12135.T_UNIT_NO, $scope.obj.secondPart[index].T_PRODUCT_CODE_1);
                result.then(function(data) {
                    GridData();
                    $scope.obj.secondPart.splice(index, 1);
                });
            }
        }
        $scope.PopUpCentrifugeEnter = function (index) {
            if (event.keyCode == 13) {
                $scope.obj.t12135.T_CENTRIFUGE_MACHINE_CODE = $scope.CentrifugeList[index].CODE;
                $scope.obj.T_CENTRIFUGE_MACHINE_NAME = $scope.CentrifugeList[index].NAME;
            }

        }
        $scope.Next = function () {
            gd();
        }
        $scope.Clear = function () {
            Clear();
        }
        $scope.eCheck = function (i) {
            if ($scope.obj.secondPart[i].Check_1 === null || $scope.obj.secondPart[i].Check_1 == '2') {
                $scope.checked = true;
                return true;
            } else {
                return false;
            }
        }

        
        function fnCentrifugeData() {
            var CentrifugeList = T12245Service.GetCentrifugeList();
            CentrifugeList.then(function (data) {
                $scope.CentrifugeList = JSON.parse(data);
                if ($scope.CentrifugeList.length > 0) {
                    document.getElementById("divCentrifuge").style.display = 'block';
                } else {
                    alert($scope.getSingleMsg('S0005'));
                    //alert('No Data is available.');
                    
                }
            });
        }
        function fnProgramData() {
            var ProgramList = T12245Service.GetProgramList();
            ProgramList.then(function (data) {
                $scope.ProgramList = JSON.parse(data);
                if ($scope.ProgramList.length > 0) {
                    document.getElementById("divProgram").style.display = 'block';
                } else {
                    alert('No Data is available.');
                    return;
                }
            });
        }
        function gd() {
            if ($scope.obj.t12135.T_UNIT_NO == '') {
                if (ddd !== '1') {
                    alert('Please input Unit number!!!');
                    document.getElementById("txtUnit").focus();
                    ddd = '1';
                }
            } else {
                if (isNaN($scope.obj.t12135.T_UNIT_NO)) {
                    alert('Please input number!!!');
                } else {
                    numberLength = $scope.obj.t12135.T_UNIT_NO.replace(/[^0-9]/g, '');
                    if (numberLength.length !== 7) {
                        alert("Unit number not valid. Please Input valid Unit number!!!");
                    } else {
                        GridData();
                        //SecondGridData();
                    }

                }

            }
            $scope.blur = false;
        }
        function Clear() {
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.t12135 = {};
            document.getElementById("1stDiv").style.display = 'none';
            document.getElementById("2ndDiv").style.display = 'none';
            $scope.truefalse = true;
            $scope.blur = true;
            $scope.selectedRow = 0;
            $scope.obj.Check_1 = {};
            $scope.obj.t12135.T_CENTRIFUGE_MACHINE_CODE = '';
            $scope.obj.t12135.T_PROGRAM_CODE = '';
            $scope.obj.t12135.T_UNIT_NO = '';
            $scope.obj.T_CENTRIFUGE_MACHINE_NAME = '';
            $scope.obj.PROGRAM_NAME = '';
            $scope.obj.T_SPEED = '';
            $scope.obj.T_TEMP = '';
            $scope.obj.T_TIME = '';
            
            $scope.obj.productInfo = [];
            $scope.obj.secondPart = [];
        }
        function removeRow(index) {
            $scope.obj.productInfo.splice(index, 1);
        }
        function GridData() {

            var GridDataList = T12245Service.GetGridDataList($scope.obj.t12135.T_UNIT_NO);
            GridDataList.then(function (data) {
               
                if (data != "") {
                    var testData = JSON.parse(data);
                    $scope.obj.productInfo = [];
                    for (var i = 0; i < testData.length; i++) {
                        $scope.obj.test = {};
                        $scope.obj.test.T_PRODUCT_CODE = testData[i].T_PRODUCT_CODE;
                        $scope.obj.test.BLOOD_PRODUCT = Language == '1' ? testData[i].T_LANG1_NAME : testData[i].T_LANG2_NAME;
                        //$scope.obj.test.T_LANG2_NAME = testData[i].T_LANG2_NAME;
                        $scope.obj.test.T_SEGMENT_NO = testData[i].SEGMENTNO;
                        var date = testData[i].T_DONATION_DATE;
                        $scope.obj.test.T_DONATION_DATE = $filter('date')(date, "dd/MM/yyyy");
                        var Exdate = testData[i].EXPIRY_DATE;
                        $scope.obj.test.T_EXPIRY_DAYS = $filter('date')(Exdate, "dd/MM/yyyy");
                        $scope.obj.productInfo.push($scope.obj.test);
                    }//for lood end
                    document.getElementById("1stDiv").style.display = 'block';
                    $scope.blur = false;
                } else {
                    if (mmm == '') {
                        alert("Unit no not found!!!");
                        document.getElementById("1stDiv").style.display = 'none';
                        document.getElementById("2ndDiv").style.display = 'none';
                        mmm = '1';
                    } else {
                        document.getElementById("1stDiv").style.display = 'none';
                        document.getElementById("2ndDiv").style.display = 'none';
                        clear();
                    }
                }
                SecondGridData();
            });//griddatalist end
        }
        function SecondGridData() {
            var SecondGridDataList = T12245Service.SecondGetGridDataList($scope.obj.t12135.T_UNIT_NO);
            SecondGridDataList.then(function (data) {
                var secondTestData = JSON.parse(data);
                $scope.obj.secondPart = [];
                for (var i = 0; i < secondTestData.length; i++) {
                    $scope.obj.test = {};
                    $scope.obj.test.T_PRODUCT_CODE_1 = secondTestData[i].T_PROD_CODE;
                    $scope.obj.test.BLOOD_PRODUCT_1 = Language == '1' ? secondTestData[i].T_LANG1_NAME : secondTestData[i].T_LANG2_NAME;
                    $scope.obj.test.T_SEGMENT_NO_1 = secondTestData[i].T_SEGMENT_NO;
                    $scope.obj.test.T_DONATION_DATE_1 = secondTestData[i].T_DONATION_DATE;
                    $scope.obj.test.T_EXPIRY_DAYS_1 = secondTestData[i].T_PROD_EXPIRY_DATE;
                    $scope.obj.test.Check_1 = secondTestData[i].T_CHECK_FLAG;
                    $scope.obj.secondPart.push($scope.obj.test);
                }
                document.getElementById("2ndDiv").style.display = 'block';
                $scope.blur = false;
            });
        }
    }]);

app.directive('arrowSelector', ['$document', function ($document) {
    return {
        //restrict: 'A',
        link: function ($scope, elem, attrs, ctrl) {
            $scope.$watch('collection.length',
                function (val) {
                    console.log(val);
                });
            var elemFocus = true;
            $document.bind('keydown', function (e) {
                if (elemFocus) {
                    if (e.keyCode == 38) {
                        if ($scope.selectedRow == 0) {
                            return;
                        }
                        $scope.selectedRow--;
                        $scope.$apply();
                        e.preventDefault();
                    }
                    if (e.keyCode == 40) {
                        console.log($scope.$eval(attrs.arrowSelector).length);
                        if ($scope.selectedRow == $scope.$eval(attrs.arrowSelector).length - 1) {
                            return;
                        }
                        $scope.selectedRow++;
                        $scope.$apply();
                        e.preventDefault();
                    }
                    if (e.keyCode == 13) {

                        $scope.$apply(function () {
                            $scope.$eval(attrs.arrowSelector);
                        });
                        e.preventDefault();
                        document.getElementById("divCentrifuge").style.display = 'none';
                    }
                }
            });
        }
    };
}]);
