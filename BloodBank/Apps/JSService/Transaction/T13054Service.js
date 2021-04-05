app.service("T13054Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT13054 = {
        test: test,
        getModelData: getModelData
    };
    return dataT13054;
    function test() {
        try {
            var url = vrtlDirr + '/T13054/test';
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
    function getModelData() {
        try {
            var url = vrtlDirr + '/T13054/GetModelData';
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