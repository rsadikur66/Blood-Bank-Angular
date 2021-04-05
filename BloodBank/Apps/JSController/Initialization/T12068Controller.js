app.controller("T12068Controller", ["$scope", "$filter", "$http", "$window", "T12068Service", "uiGridConstants", "DTOptionsBuilder", "DTColumnBuilder", "Data",
    function ($scope, $filter, $http, $window, T12068Service, uiGridConstants, DTOptionsBuilder, DTColumnBuilder, Data) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        //$scope.obj.T_ACTIVE = ;
        $scope.obj.QHead = {};
        $scope.obj.Gender = {};
        $scope.obj.Fail = {};
        $scope.addQhed = {};
        $scope.obj.t12068 = {};
        $scope.obj.t12068.T_QNO = '';
        $scope.obj.t12068.T_QHEAD_NO = '';
        $scope.obj.t12068.T_LANG2_NAME = '';
        $scope.obj.t12068.T_LANG1_NAME = '';
        $scope.obj.t12068.T_QUS_WEIGHT = '';
        $scope.obj.t12068.T_DISP_SEQ = '';
        $scope.obj.t12068.T_DIFFERAL_DAY = '';
        $scope.obj.t12068.T_SEX = '';
        $scope.obj.t12068.T_IF_FAIL = '';
        $scope.obj.t12068.T_EXP_ANS = '';
        $scope.obj.t12068.T_ACTIVE = '1';
        $scope.obj.QHead.selected = {};
        $scope.obj.Gender.selected = {};
        $scope.obj.Fail.selected = {};

       
        //For Entry User Start
        var EntryUser = T12068Service.EntryUser();
        EntryUser.then(function (data) {
            $scope.obj.T_ENTRY_USER = data;
            $scope.obj.T_ENTRY_DATE = $filter('date')(new Date(), 'dd-MMM-yyyy');
        });
        //For Entry User end

        //Gender List Function Start
        var getGenderList = T12068Service.GetAllGender();
        getGenderList.then(function (data) {
            var jsonData = JSON.parse(data);
            $scope.getGender = jsonData;
        });

        //Gender List Function End

        //Question Head Data List Function Start
        
        var QustHeadList = T12068Service.GetQstHeadData();
        QustHeadList.then(function (data) {
            $scope.getQHead = JSON.parse(data);
        });

        //Question Head Data List Function End

        //Fail Data List Function Start

        var faildataList = T12068Service.GetFailData();
        faildataList.then(function (data) {
            $scope.getFail = JSON.parse(data);
        });

        //Fail Data List Function End

        //For Save T12068 Table Function Start 
        $scope.Save_Click = function () {
            var QuestionNo = $scope.obj.t12068.T_QNO;
            var Expans = $scope.obj.t12068.T_EXP_ANS;
            var t12068 = $scope.obj.t12068;
            if (QuestionNo === '') {
                if (Expans==='') {
                    alert('Please Check Answer Status');
                    return;
                }
                var insert = T12068Service.InsertT12068(t12068);
                insert.then(function (data) {
                    if (data === "OK") {
                        alert($scope.getSingleMsg('N0040'));
                        $window.location = "/Initialization/T12068";
                        $scope.Clear();
                    }
                    else {
                        alert($scope.getSingleMsg('N0071'));
                        //alert("Data not Saved");
                    }
                });
            } else {
                var update = T12068Service.UpdateT12068(t12068);
                update.then(function (data) {
                    if (data === "OK") {
                        alert($scope.getSingleMsg('N0041'));
                        $window.location = "/Initialization/T12068";
                    }
                    else {
                        alert($scope.getSingleMsg('N0072'));
                        //alert("Data not Update.");
                    }
                });
                
            }
        }
        //For Save T12068 Table Function End

        //For Delete T12068  Function End
        $scope.Delete_Click = function () {
            if ($scope.obj.t12068.T_QNO !== '') {
                var t12068 = $scope.obj.t12068;
                    var delet = T12068Service.DeleteT12068(t12068);
                    delet.then(function(data) {
                        if (data === "OK") {
                            alert($scope.getSingleMsg('N0042'));
                            $window.location = "/Initialization/T12068";
                        } else {
                            alert($scope.getSingleMsg('N0073'));
                            //alert("Data not Delete.");
                        }
                    });
            }
            else {
                alert($scope.getSingleMsg('N0074'));
                //alert('Please select data.');
                return false;
            }
        };
        //For Delete T12068  Function End 

        //For Clear Function End
        $scope.Clear = function () {
            $scope.obj.t12068.T_QNO = '';
            $scope.obj.t12068.T_LANG2_NAME= '';
            $scope.obj.t12068.T_LANG1_NAME = '';
            $scope.obj.t12068.T_QUS_WEIGHT = '';
            $scope.obj.t12068.T_DISP_SEQ = '';
            $scope.obj.t12068.T_DIFFERAL_DAY = '';
            $scope.obj.t12068.T_EXP_ANS = false;
            $scope.obj.t12068.T_ACTIVE = false;
            $scope.obj.QHead.selected = '';
            $scope.obj.Gender.selected = '';
            $scope.obj.Fail.selected = '';
        };
        //For Clear Function End


        //Modal Save Function Start
        $scope.openDialog = function (id, QHead) {
            document.getElementById(id).style.display = "block";
            $scope.addQhed.T_QHEAD_NO = QHead.T_QHEAD_NO;
            $scope.addQhed.T_LANG2_NAME = QHead.T_LANG2_NAME;
            $scope.addQhed.T_LANG1_NAME = QHead.T_LANG1_NAME;
        }
        $scope.closeDialog = function (id) {
            document.getElementById(id).style.display = "none";
            $scope.addQhed = {};
            $scope.obj.QHead = {};
        }
        $scope.addQstHeadType = function () {
            if ($scope.addQhed.T_QHEAD_NO != null) {
                    var saveQheadType = T12068Service.InsertT12069($scope.addQhed);
                    saveQheadType.then(function (data) {
                        alert($scope.getSingleMsg('N0040'));
                        var QheadTypeData = T12068Service.GetQstHeadData();
                        QheadTypeData.then(function (data) {
                            $scope.getQHead = data;
                            $scope.addQhed = {};
                        });
                    });
            } else {
                alert($scope.getSingleMsg('N0075'));
                //alert('Question Head No is Required.');
                angular.element('#txtQheadNumber').focus();
            }
        }
        //Modal Save Function End

        //For Grid Function Start
        $scope.someClickHandler = someClickHandler;
        $scope.dtColumns = [
            //here We will add .withOption('name','column_name') for send column name to the server 
            DTColumnBuilder.newColumn("T_QNO", $scope.getLabel("lblhdrQuestionNo")).withOption('name', 'T_QNO').withOption('width', '12%'),
            DTColumnBuilder.newColumn("T_LANG2_NAME", $scope.getLabel("lblhdrQuestion")).withOption('name', 'T_LANG2_NAME').withOption('width', '30%'),
            DTColumnBuilder.newColumn("T_LANG1_NAME", "Question").withOption('name', 'T_LANG1_NAME').notVisible(),
            DTColumnBuilder.newColumn("T_QHEAD_NO", "Qst Head No").withOption('name', 'T_QHEAD_NO').notVisible(),
            DTColumnBuilder.newColumn("T_QHEAD", $scope.getLabel("lblhdrQstHead")).withOption('name', 'T_QHEAD').withOption('width', '30%'),
            DTColumnBuilder.newColumn("T_QUS_YES_COLOR", "Color Type").withOption('name', 'T_QUS_YES_COLOR').notVisible(),
            DTColumnBuilder.newColumn("T_EXP_ANS", $scope.getLabel("lblhdrExpAnswer")).withOption('name"', 'T_EXP_ANS').withOption('width', '12%'),
            DTColumnBuilder.newColumn("T_QUS_WEIGHT", "Qust Weight").withOption('"name', 'T_QUS_WEIGHT').notVisible(),
            DTColumnBuilder.newColumn("T_DISP_SEQ", "Display SEQ").withOption('name', 'T_DISP_SEQ').notVisible(),
            DTColumnBuilder.newColumn("T_DIFFERAL_DAY", "Differal Day").withOption('name', 'T_DIFFERAL_DAY').notVisible(),
            DTColumnBuilder.newColumn("T_QUS_NO_COLOR", "Color").withOption('name', 'T_QUS_NO_COLOR').notVisible(),
            DTColumnBuilder.newColumn("T_SEX", "Gender").withOption('name', 'T_SEX').notVisible(),
            DTColumnBuilder.newColumn("T_GENDER", $scope.getLabel("lblhdrGender")).withOption('name', 'T_GENDER').withOption('width', '5%'),
            DTColumnBuilder.newColumn("T_ACTION", "Action").withOption('name', 'T_ACTION').notVisible(),
            DTColumnBuilder.newColumn("T_IF_FAIL", $scope.getLabel("lblhdrFailStatus")).withOption('name', 'T_IF_FAIL').withOption('width', '11%'),
            DTColumnBuilder.newColumn("T_ACTIVE", "Active").withOption('name', 'T_ACTIVE').notVisible()
        ];

        $scope.dtOptions = DTOptionsBuilder.newOptions().withOption('ajax',
                {
                    dataSrc: "data",
                    url: "/T12068/GetGridData",
                    type: "POST"
                })
            .withOption('rowCallback', rowCallback)
            .withOption('processing', true) //for show progress bar
            .withOption('serverSide', true) // for server side processing
            .withPaginationType(
                'full_numbers') // for get full pagination options // first / last / prev / next and page numbers
            .withDisplayLength(10) // Page size
            .withOption('aaSorting', [0, 'asc']);// for default sorting column // here 0 means first column

        function someClickHandler(info) {
            $scope.obj.t12068.T_QNO = info.T_QNO;
            $scope.obj.QHead.selected = { T_QHEAD: info.T_QHEAD, T_QHEAD_NO: info.T_QHEAD_NO}
            $scope.obj.t12068.T_LANG2_NAME = info.T_LANG2_NAME;
            $scope.obj.t12068.T_LANG1_NAME = info.T_LANG1_NAME;
            $scope.obj.t12068.T_QUS_YES_COLOR = info.T_QUS_YES_COLOR;
            
            $scope.obj.t12068.T_QUS_WEIGHT = info.T_QUS_WEIGHT;
            $scope.obj.t12068.T_DISP_SEQ = info.T_DISP_SEQ;
            $scope.obj.t12068.T_DIFFERAL_DAY = info.T_DIFFERAL_DAY;
            $scope.obj.t12068.T_QUS_NO_COLOR = info.T_QUS_NO_COLOR;
            $scope.obj.Gender.selected = { T_SEX_CODE: info.T_SEX, T_SEX: info.T_GENDER };
            $scope.obj.t12068.T_ACTION = info.T_ACTION;
            $scope.obj.Fail.selected = { T_IF_FAIL: info.T_IF_FAIL };
            if (info.T_IF_FAIL == 'YELLOW') {
                $scope.obj.Fail.selected.T_CODE = '1';
            } else {
                $scope.obj.Fail.selected.T_CODE = '2';
            }
            if (info.T_EXP_ANS == 'YES') {
                document.getElementById("chkAnswerYes").checked = true;
                document.getElementById("chkAnswerNo").checked = false;
            } else {
                document.getElementById("chkAnswerYes").checked = false;
                document.getElementById("chkAnswerNo").checked = true;
            }
            if (info.T_ACTIVE == '1') {
                document.getElementById("chkActive").checked = true;
            } else {
                document.getElementById("chkActive").checked = false;
                
            }

            $scope.obj.t12068.check.active = info.T_ACTIVE;

           // $scope.obj.G.selected = { T_GENDER: newDataJSON[0].T_GENDER_NAME, T_SEX_CODE: newDataJSON[0].T_GENDER };
        }
        function rowCallback(nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            // Unbind first in order to avoid any duplicate handler (see https://github.com/l-lin/angular-datatables/issues/87)
            $('td', nRow).unbind('click');
            $('td', nRow).bind('click', function () {
                $scope.$apply(function () {
                    $scope.someClickHandler(aData);
                });
            });
            return nRow;
        }
        //For Grid Function End 

       //For RadioButton Check Function start
        $scope.chkActiv = function() {
            var CheckActive = document.getElementById("chkActive").checked;
            if (CheckActive===true) {
                $scope.obj.t12068.T_ACTIVE = '1';
            } else {
                $scope.obj.t12068.T_ACTIVE = '2';
                
            }
        }
        //For RadioButton Check Function End
    }]);
