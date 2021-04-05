
app.service("T12281Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataGet= {
        getAllData: getAllData,
        getAllUnitData: getAllUnitData,
        saveData: saveData
    };
    return dataGet;


    function getAllData() {
        try {
            var url = vrtlDirr +'/T12281/GetAllData';
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
    function getAllUnitData() {
        try {
            var url = vrtlDirr +'/T12281/GetAllUnitData';
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
    function saveData(t12281) {
        try {
            var url = vrtlDirr +'/T12281/SaveData';
            return $http({
                url: url,
                method: "POST",
                data: { t12281: t12281}
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