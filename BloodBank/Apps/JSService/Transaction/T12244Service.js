app.service("T12244Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        getPatNo: getPatNo,
        getQuestions: getQuestions,
        getConsent: getConsent,
        insert: insert,
        singleInsert: singleInsert,
        testPrint: testPrint
};
    return dataSvc;
    function getPatNo(e) {
        try {
            var url = vrtlDirr + '/T12244/getPatNo';
            var params = { P_PAT_NO:e};
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
    function getQuestions(e,f,p) {
        try {
            var url = vrtlDirr + '/T12244/getQuestions';
            var params = { type: e, P_SEX: f, P_PAT_NO:p};
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
    function getConsent(e) {
        try {
            var url = vrtlDirr + '/T12244/getConsent';
            var params = { type: e };
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
    function insert(t17) {
        try {
            var url = vrtlDirr + '/T12244/insert';
            var params = { t12017:t17 };
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
            var url = vrtlDirr + '/T12244/singleInsert';
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
    function testPrint() {
        try {
            var url = vrtlDirr + '/T12244/testPrint';
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
    
    
}]);