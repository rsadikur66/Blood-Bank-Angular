app.service("T12301Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12301 = {
        GetPatInfo: GetPatInfo,
        GetRequestNoPopUp: GetRequestNoPopUp,
        GetUserListPopUp: GetUserListPopUp,
        GetUserListPopUpByCode: GetUserListPopUpByCode,
        GetCurrentUser: GetCurrentUser,
        updateT12012: updateT12012
    }
    return dataT12301;

    //For Label Function Start
    function GetPatInfo(T_REQUEST_NO) {
        try {
            var url = vrtlDirr + '/T12301/GetPatInfo';
            return $http({
                url: url,
                method: "POST",
                data: { T_REQUEST_NO: T_REQUEST_NO }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function GetRequestNoPopUp() {
        try {
            var url = vrtlDirr + '/T12301/GetRequestNoPopUp';
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
    function GetUserListPopUp() {
        try {
            var url = vrtlDirr + '/T12301/GetUserList';
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

    function GetUserListPopUpByCode(T_EMP_CODE) {
        try {
            var url = vrtlDirr + '/T12301/GetUserList';
            var params = { T_EMP_CODE: T_EMP_CODE };
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

    

    function GetCurrentUser() {
        try {
            var url = vrtlDirr + '/T12301/GetCurrentUser';
            
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

    function updateT12012(T_REQUEST_NO, T_BLOOD_BRING, T_LAB_NO,T_REQ_REC_DATE, T_REQ_REC_TIME) {
        try {
            var url = vrtlDirr + '/T12301/updateT12012';
            var params = { T_REQUEST_NO: T_REQUEST_NO, T_BLOOD_BRING: T_BLOOD_BRING, T_LAB_NO: T_LAB_NO, T_REQ_REC_DATE: T_REQ_REC_DATE, T_REQ_REC_TIME: T_REQ_REC_TIME };
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

}]);