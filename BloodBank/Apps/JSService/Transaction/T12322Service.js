app.service("T12322Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var data = {
        GetProductList: GetProductList
        , GetReasonList: GetReasonList
        , GetSingleUnit: GetSingleUnit
        , saveList: saveList
    };
    return data;
    function GetProductList() {
        try {
            var url = vrtlDirr + '/T12322/GetProductList';
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
    function GetReasonList() {
        try {
            var url = vrtlDirr + '/T12322/GetReasonList';
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
    function GetSingleUnit(unit) {
        try {
            var url = vrtlDirr + '/T12322/GetSingleUnit';
            return $http({
                url: url,
                method: "POST",
                data: {unit:unit}
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    } function saveList(sObj) {
        try {
            var url = vrtlDirr + '/T12322/saveList';
            return $http({
                url: url,
                method: "POST",
                data: { t23List: sObj}
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