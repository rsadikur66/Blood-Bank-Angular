app.service("T12202Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        getPatDetail: getPatDetail,
        getQues: getQues,
        getValidation: getValidation,
        insert: insert,
        getUnitData: getUnitData,
        singleInsert: singleInsert
    };
    return dataSvc;
    function getPatDetail(p,n) {
        try {
            var url = vrtlDirr + '/T12202/getPatDetail';
            var params = {P_PAT_NO:p,P_NTNLTY_ID:n};
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
    function getQues(p,n,r,s) {
        try {
            var url = vrtlDirr + '/T12202/getQues';
            var params = { P_PAT_NO: p, P_NTNLTY_ID: n, P_REQUEST_ID: r,P_SEX:s};
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
    function getUnitData(untNo) {
        try {
            var url = vrtlDirr + '/T12202/GetUnitData';
            var params = { unitNo: untNo };
            return $http({ url: url, method: "POST", data: params }).then(function (results) { return results.data; }).catch(function (ex) { throw ex; });
        } catch (ex) { throw ex; }
    }
    function getValidation(p,v) {
        try {
            var url = vrtlDirr + '/T12202/getValidation';
            var params = { P_VITAL_CODE:p,Value:v};
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
    function insert(t22,t) {
        try {
            var url = vrtlDirr + '/T12202/insert';
            var params = { t12022: t22 ,t:t};
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
    function singleInsert(t71) {
        try {
            var url = vrtlDirr + '/T12202/singleInsert';
            var params = { t71: t71};
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