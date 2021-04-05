
app.service("R12260Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        getDate: getDate,
        showReport: showReport,
        getTimeData: getTimeData,
        getInfoData: getInfoData
    };
    return dataSvc;
    function getDate(f, t) {
        try {
            var url = vrtlDirr + '/R12260/getDate';
            var params = { f: f, t: t };
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
    function showReport(f, t) {
        try {
            var url = vrtlDirr + '/R12260/showReport';
            var params = { f: f, t: t };
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
    function getTimeData(f, t) {
        try {
            var url = vrtlDirr + '/R12260/getTimeData';
            var params = { f: f, t: t };
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
    function getInfoData() {
        try {
            var url = vrtlDirr + '/R12260/getInfoData';
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