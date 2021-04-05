app.service("LoginService", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataLogin = {
        GetLabelText: GetLabelText,
        CheckLogin: CheckLogin,
        setClientErrorLog: setClientErrorLog,
        logT92: logT92
    };
    return dataLogin;

    function GetLabelText(formcode, language) {
        try {
            var url = vrtlDirr + '/Account/GetLabelText';
            return $http({
                url: url,
                method: "POST",
                data: { formcode: formcode, language: language }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function CheckLogin(loginName, password) {
        try {
            var url = vrtlDirr + '/Account/CheckLogin';
            return $http({
                url: url,
                method: "POST",
                data: { loginName: loginName, password: password }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function setClientErrorLog(controller, action, message) {
        try {
            var url = vrtlDirr + '/Account/setClientErrorLog';
            var params = { controller: controller, action: action, message: message };
            return $http({
                url: url,
                method: "POST",
                data: params
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function logT92(userId) {
        try {
            var url = vrtlDirr + '/Account/logT92';
            return $http({
                url: url,
                method: "POST",
                data: { userId: userId }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
}]);




