app.service("R12016Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        getUnit: getUnit,
        getPRCode: getPRCode
};
    return dataSvc;
    function getUnit() {
        try {
            var url = vrtlDirr +'/R12016/getUnit';
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
    function getPRCode(f,t) {
        try {
            var url = vrtlDirr +'/R12016/getPRCode';
            var params = { from: f, to: t};
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