app.service("Q12018Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataQ12018 = {
        GetFirstGridData: GetFirstGridData,
        GetSecondGridData: GetSecondGridData
    };
    return dataQ12018;
    function GetFirstGridData(unitNo) {
        try {
            var url = vrtlDirr + '/Q12018/GetFirstGridData';
            return $http({
                url: url,
                method: "POST",
                data: { unitNo: unitNo }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function GetSecondGridData(unitNo) {
        try {
            var url = vrtlDirr + '/Q12018/GetSecondGridData';
            return $http({
                url: url,
                method: "POST",
                data: { unitNo: unitNo }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function Insert_T12011(t12011) {
        try {
            var url = vrtlDirr + '/T12011/Insert_T12011';
            var params = { t12011: t12011 };
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