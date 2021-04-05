app.service("T12033Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        GetGridData: GetGridData,
        Insert_T12033: Insert_T12033
};
    return dataSvc;


    function GetGridData() {
        try {
            var url = vrtlDirr +'/T12033/GetGridData';
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

    function Insert_T12033(t12033) {
        try {
            var url = vrtlDirr +'/T12033/Insert_T12033';
            var params = { t12033: t12033 };
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