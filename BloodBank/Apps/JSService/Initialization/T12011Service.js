app.service("T12011Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12011 = {
        GetGridData: GetGridData,
        Insert_T12011: Insert_T12011
};
    return dataT12011;
    function GetGridData() {
        try {
            var url = vrtlDirr +'/T12011/GetGridData';
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

    function Insert_T12011(t12011) {
        try {
            var url = vrtlDirr +'/T12011/Insert_T12011';
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