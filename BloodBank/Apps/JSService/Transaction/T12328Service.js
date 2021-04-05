app.service("T12328Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12328 = {
        getBagType: getBagType,
        getUnitList: getUnitList,
        validateWeight: validateWeight,
        getReciever: getReciever,
        insert: insert,
        getUnitData: getUnitData
    };
    return dataT12328;
    function getBagType() {
        try {
            var url = vrtlDirr + '/T12328/getBagType';
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
    function getUnitList(u,f,t) {
        try {
            var url = vrtlDirr + '/T12328/getUnitList';
            var params = {T_UNIT_NO:u,DATEFROM:f,DATETO:t};
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
    function validateWeight(w,b) {
        try {
            var url = vrtlDirr + '/T12328/validateWeight';
            var params = { T_UNIT_WEIGHT: w, T_BAG_TYPE:b};
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
    function getReciever() {
        try {
            var url = vrtlDirr + '/T12328/getReciever';
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
    function insert(e) {
        try {
            var url = vrtlDirr + '/T12328/insert';
            var params = { modelList:e};
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
}]);