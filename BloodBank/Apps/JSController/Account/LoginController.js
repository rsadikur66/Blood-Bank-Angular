app.controller("LoginController", ["$scope", "LoginService","$location","vrtlDirr",
    function ($scope, LoginService, $location, vrtlDirr) { //$location,
        $scope.obj = {};
        $scope.vrtlDirr=vrtlDirr;
        $scope.KeyPressed = {};
        $scope.lang = '2';
        label($scope.lang);
        $scope.userName = 'nam';
        
        //Label Data Function Start

        function label(e) {
            var labelData = LoginService.GetLabelText('MM1212', e);
            labelData.then(function (data) {
                $scope.entity = JSON.parse(data);
                sessionStorage.setItem("LangName", JSON.stringify(e));
            });
        }
        function login(l,p) {
            var loginData = LoginService.CheckLogin(l, p);
            loginData.then(function (data) {
                var newDataJSON = JSON.parse(data);
                if (newDataJSON[0].T_ROLE_CODE == '0044') {
                    var lo = LoginService.logT92(newDataJSON[0].T_EMP_CODE);
                    lo.then(function (d) {

                    })
                }
                if (newDataJSON.length === 0) {
                    var msg = $scope.lang === '2' ? "Invalid Id or Password" : "معرف غير صالح أو كلمة مرور";
                    alert(msg);
                    document.getElementById("lblUserName").focus();

                } else {
                    var a = $location.absUrl().split('/')[2].split('?')[0];
                    window.location.href ="http://"+a+$scope.vrtlDirr+"/Menu/Index";
                }

            });
        }

      
        $scope.language = function (l) {
            $scope.lang = l;
            label($scope.lang);
            document.getElementById("lblUserName").focus();
        }
        $scope.KeyPressed = function (e,l, p) {
            if (e.which === 13) {
                $scope.userName = 'pass';
                login(l, p);
            }
        };

        $scope.login = function (l,p) {           
            try {
                login(l, p);
            } catch (e) {
                $scope.setError($scope.controllerName, 'login', e.message);
            }
        }
        

        $scope.enterKey = function (event) {
            if (event.keyCode === 13) {
                $scope.userName = 'pass';
                document.getElementById("lblPassword").focus();
            }
        };

        $scope.focus = function() {
            document.getElementById("lblUserName").focus();
        }





        //Number Pad function Start
        $scope.obj.T_LOGIN_NAME = "";
        $scope.obj.T_PWD = "";
      
       
        $scope.Name = function(p) {
            $scope.userName = p;
        }
        $scope.Pass = function () {
            $scope.userName = 'Password';
        }
        //Number add function start
        $scope.addNumber = function (num) {

            if ($scope.userName === 'nam') {
                $scope.obj.T_LOGIN_NAME += num;
                document.getElementById("lblUserName").focus();
            }
            else if ($scope.userName === 'pass') {
                $scope.obj.T_PWD += num;
                //$scope.obj.T_PWD.focus = true;
                document.getElementById("lblPassword").focus();
            }
        };
        //Number add function end
        //AC button function start 
        $scope.Cancel = function(ac) {
            $scope.obj.T_LOGIN_NAME = "";
            $scope.obj.T_PWD = "";
        };
        //AC button function end 

        //Back Button function start
        $scope.BackNumber = function () {
            if ($scope.userName === 'nam') {
                var tnum = $scope.obj.T_LOGIN_NAME.length;
                $scope.obj.T_LOGIN_NAME = $scope.obj.T_LOGIN_NAME.substring(0, tnum - 1);
            }
            else if ($scope.userName === 'pass') {
                var pnum = $scope.obj.T_PWD.length;
                $scope.obj.T_PWD = $scope.obj.T_PWD.substring(0, pnum - 1);
            }
        };
        //Back Button function end
       
        //Enter button  function start
        $scope.Enter = function (l, p) {
           
            if ($scope.userName === 'pass') {
                login(l, p);
            } else {
                document.getElementById("lblPassword").focus();
                $scope.userName = 'pass';
            }
        }

        //Enter button function end

        //Logout Button Function start
        $scope.logout = function() {
            $scope.obj.T_LOGIN_NAME = "";
            $scope.obj.T_PWD = "";
            document.getElementById("lblUserName").focus();
        }
        //Logout Button Function end

        // Number pad Function end
        $scope.setError = function (controller, action, message) {
            LoginService.setClientErrorLog(controller, action, message);
        }
    }]);