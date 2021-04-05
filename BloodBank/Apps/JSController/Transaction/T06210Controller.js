app.controller("T06210Controller", ["$scope", "T06210Service", "Data", "$window", "$filter",
    function ($scope, T06210Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.currentTab = 'tabRequisition.tpl.html';
        $scope.lang = JSON.parse(sessionStorage.getItem("LangName")) == undefined ? 2 : JSON.parse(sessionStorage.getItem("LangName"));
        $scope.FloatE = { "float": 'left', "margin-right": '-3px' }
        $scope.FloatA = { "float": 'right', "margin-left": '-3px' }
        $scope.aR = { "text-align": 'right' }
        $scope.aL = { "text-align": 'left' }
        $scope.requisition = ["First", "Second", "Third"];
        $scope.priority = ["Top", "Medium", "Less"];
        $scope.tabs = [
            { title: 'Tab-1', url: 'tabRequisition.tpl.html', hin: 'Req' },
            { title: 'Tab-2', url: 'tabDetail.tpl.html', hin: 'Det' }
        ];
      
        $scope.onClickTab = function (tab) {

            $scope.obj.Hidenfield = tab.hin;
            $scope.currentTab = tab.url;
            //readOnlyUnderValue();
        }
        $scope.isActiveTab = function(tabUrl) {
            return tabUrl === $scope.currentTab;
        }
        //----------Tab Toggling--------------End
       
    }]);