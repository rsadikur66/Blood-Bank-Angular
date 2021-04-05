
app.controller("Q03001Controller", ["$scope", "Q03001Service", "uiGridConstants", "DTOptionsBuilder", "DTColumnBuilder", "Data", "$window","menuService",
    function (scope, Q03001Service, uiGridConstants, DTOptionsBuilder, DTColumnBuilder, Data, $window, menuService) {
        scope.obj = {};
        scope.obj = Data;
      //  scope.lang = JSON.parse(sessionStorage.getItem("LangName")) == undefined ? 2 : JSON.parse(sessionStorage.getItem("LangName"));
        scope.someClickHandler = someClickHandler;
      
            scope.dtColumns = [
                //here We will add .withOption('name','column_name') for send column name to the server 
                DTColumnBuilder.newColumn("RowNumber", scope.getLabel("lblhdrQueryRowNum")).withOption('name', 'RowNumber'),//$scope.getLabel("lblhdrQstHead")
                DTColumnBuilder.newColumn("T_PAT_NO", scope.getLabel("lblhdrQueryPatNo")).withOption('name', 'T_PAT_NO'),
                DTColumnBuilder.newColumn("PAT_NAME", scope.getLabel("lblhdrQueryPatName")).withOption('name', 'PAT_NAME'),
                DTColumnBuilder.newColumn("RLGN", scope.getLabel("lblhdrQueryReligion")).withOption('name', 'RLGN'),
                DTColumnBuilder.newColumn("GENDER", scope.getLabel("lblhdrQueryGender")).withOption('name', 'GENDER'),
                DTColumnBuilder.newColumn("T_NTNLTY_ID", scope.getLabel("lblhdrQueryNTNLTYID")).withOption('name', 'T_NTNLTY_ID'),
                DTColumnBuilder.newColumn("NTNLTY", scope.getLabel("lblhdrQueryNationality")).withOption('name', 'NTNLTY'),
                DTColumnBuilder.newColumn("YRS", scope.getLabel("lblhdrQueryYears")).withOption('name', 'YRS'),
                DTColumnBuilder.newColumn("MOS", scope.getLabel("lblhdrQueryMOS")).withOption('name', 'MOS'),
                DTColumnBuilder.newColumn("MRTL_STATUS", scope.getLabel("lblhdrQueryMarritial")).withOption('name', 'MRTL_STATUS')
            ];
            

       

        scope.dtOptions = DTOptionsBuilder.newOptions().withOption('ajax',
                {
                    dataSrc: "data",
                    url: scope.vrDir+"/Q03001/GetGridviewData",
                    type: "POST"
                })
            .withOption('rowCallback', rowCallback)
            .withOption('processing', true) //for show progress bar
            .withOption('serverSide', true) // for server side processing
            .withPaginationType(
                'full_numbers') // for get full pagination options // first / last / prev / next and page numbers
            .withDisplayLength(10) // Page size
            .withOption('aaSorting', [0, 'asc']); // for default sorting column // here 0 means first column
       
        function someClickHandler(info) {
            scope.reqPage = JSON.parse(sessionStorage.getItem("FReqCode"));
            var purl = JSON.parse(sessionStorage.getItem("t04201"));
           // window.location.href = purl + "?Pat_ID=" + info.T_PAT_NO;
            //----------------------------------
          //  var PatNo = JSON.parse(sessionStorage.getItem("PatNo"));
           // sessionStorage.setItem("PatNo", JSON.stringify(info.T_PAT_NO));
           // window.location.href = "/Transaction/T12300";
           // $window.location = "/Transaction/" + $scope.reqPage;
            //var hostAddress = $window.location.host;
            //var url = "http://" + hostAddress + "/Transaction/T12300";
            //$window.location.href = url;
            //------------------------------------

            sessionStorage.setItem("FCode", JSON.stringify("T12300"));
            name = scope.lang === '1' ? "طلب الدم للمريض" : " Blood Request for Patient";
            sessionStorage.setItem("FName", JSON.stringify(name));

            var labelData = menuService.GetLabelText(scope.reqPage, scope.lang);
            labelData.then(function (data) {
                scope.entity = JSON.parse(data);
                sessionStorage.setItem("LabelData", JSON.stringify(scope.entity));
                sessionStorage.setItem("FFlag", null);
                var PatNo = JSON.parse(sessionStorage.getItem("PatNo"));
                sessionStorage.setItem("PatNo", JSON.stringify(info.T_PAT_NO));
                $window.location = scope.vrDir +"/Transaction/" + scope.reqPage;

                //var hostAddress = $window.location.host;
                //var url = "http://" + hostAddress + "/Transaction/T12300";
                //$window.location.href = url;
            });
        }
        function rowCallback(nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            // Unbind first in order to avoid any duplicate handler (see https://github.com/l-lin/angular-datatables/issues/87)
            $('td', nRow).unbind('click');
            $('td', nRow).bind('click', function () {

                scope.$apply(function () {
                    scope.someClickHandler(aData);
                });
            });
            return nRow;
        }


    }])