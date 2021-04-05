app.service("menuService", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataService = {
        menudata: MenuData,
        UserLogout: UserLogout,
        LangName: LangName,
        UserName: UserName,
        GetLabelText: GetLabelText,
        GetAllUserMsg: GetAllUserMsg,
        EmpCode: EmpCode,
        GetRequestListData: GetRequestListData,
        getServerName: getServerName
        , updateForm: updateForm
        , setClientErrorLog: setClientErrorLog
    };
    return dataService;
    function MenuData(lang, e) {
        try {
            var url = vrtlDirr +"/Menu/GetMenuData";
            var params = { lang: lang, T_LINK_SEPERATION : e };
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
    function LangName() {
        try {
            var url = vrtlDirr +'LangName';
            var params = {};
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

    function EmpCode() {
        try {
            var url = vrtlDirr + 'EmpCode';
            var params = {};
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
    function UserName() {
        try {
            var url = vrtlDirr +'/Menu/UserName';
            var params = {};
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

    function UserLogout() {
        try {
            var url = vrtlDirr +'/Menu/UserLogout';
            var params = {};
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
    function GetLabelText(formcode, language) {
        try {
            var url =  vrtlDirr +'/Account/GetLabelText';
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
    function GetAllUserMsg() {
        try {
            var url = vrtlDirr +'/Menu/GetAllUserMsg';
            return $http({
                url: url,
                method: "POST",
                data: {}
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getServerName() {
        try {
            var url = vrtlDirr + '/Menu/getServerName';
            return $http({
                url: url,
                method: "POST",
                data: {}
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function updateForm(form) {
        try {
            var url = vrtlDirr + '/Menu/updateForm';
            var params = { form: form };
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
    function setClientErrorLog(controller, action, message) {
        try {
            var url = vrtlDirr + '/Account/setClientErrorLog';
            var params = { controller: controller, action: action, message: message, source: '' };
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

    function GetRequestListData() {
        try {
            var url = vrtlDirr + '/T12265/GetRequestListData';
            return $http({
                url: url,
                method: "POST",
                data: {}
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