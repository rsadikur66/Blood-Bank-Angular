app.service("T12132Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12132 = {
        GetGridData: GetGridData,
        getAllFormCodeData: getAllFormCodeData,
        saveData: saveData,
        method: method
    };
    return dataT12132;


    function GetGridData(controlname, local, english) {
        try {
            var url = vrtlDirr + '/T12132/GetGridData';
            var params = { };
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

    function getAllFormCodeData() {
        try {
            var url = vrtlDirr + '/T12132/GetAllFormCodeData';
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

    function saveData(t12132) {
        try {
            var url = vrtlDirr + '/T12132/SaveData';
            return $http({
                url: url,
                method: "POST",
                data: { t12132: t12132 }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }


    function method() {
        try {
            var url = vrtlDirr +'/T12132/method';
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