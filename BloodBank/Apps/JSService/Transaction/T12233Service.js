app.service("T12233Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12233 = {
        GetGridData: GetGridData,
        GetVerifyData: GetVerifyData,
        GetUnitData: GetUnitData,
        Insert_T13016: Insert_T13016,
        getUnitData: getUnitData

    };
    return dataT12233;

    function GetGridData(unitno) {
        try {
            var url = vrtlDirr +  '/T12233/GetGridData';
            return $http({
                url: url,
                method: "POST",
                data: { unitno: unitno }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function GetVerifyData() {
        try {
            var url = vrtlDirr +  '/T12233/GetVerifyData';
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

    function GetUnitData() {
        try {
            var url = vrtlDirr +  '/T12233/GetUnitData';
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

    function Insert_T13016(t12233) {
        try {
            var url = vrtlDirr +  '/T12233/Insert_T13016';
            var params = { t12233: t12233 };
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