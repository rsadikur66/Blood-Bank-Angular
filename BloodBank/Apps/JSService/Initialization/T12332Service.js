app.service("T12332Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12332 = {
        GetGridData: GetGridData,
        Insert_T12332: Insert_T12332
    };
    return dataT12332;

    function GetGridData(unittype, english, local, bag) {
        try {
            var url = vrtlDirr +'/T12332/GetGridData';
            var params = { unittype: unittype, english: english,local:local,bag:bag };
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

    function Insert_T12332(t12073) {
        try {
            var url = vrtlDirr +'/T12332/Insert_T12332';
            var params = { t12073: t12073};
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