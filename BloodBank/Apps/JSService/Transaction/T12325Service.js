
app.service("T12325Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        getVirus: getVirus,
        getResulDes: getResulDes,
        checkUnitNo: checkUnitNo,
        saveData: saveData,
        getUnitNo: getUnitNo,
        gerVirusResult: gerVirusResult,
        getAllData: getAllData,
        getUnitData: getUnitData
    };
    return dataSvc;
    function getVirus() {
        try {
            var url = vrtlDirr + '/T12325/GetVirus';
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
    function getResulDes(value) {
        try {
            var url = vrtlDirr + '/T12325/GetResulDes';
            return $http({
                url: url,
                method: "POST",
                data: { value: value }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function checkUnitNo(unit) {
        try {
            var url = vrtlDirr + '/T12325/CheckUnitNo';
            return $http({
                url: url,
                method: "POST",
                data: { unit: unit }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function saveData(un, vairusList) {
        try {
            var url = vrtlDirr + '/T12325/SaveData';
            return $http({
                url: url,
                method: "POST",
                data: { un: un, vairusList: vairusList }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function getUnitNo() {
        try {
            var url = vrtlDirr + '/T12325/GetUnitNo';
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
    function gerVirusResult() {
        try {
            var url = vrtlDirr + '/T12325/GerVirusResult';
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
    function getAllData(unitNo) {
        try {
            var url = vrtlDirr + '/T12325/GetAllData';
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

    function getUnitData(untNo) {
        try {
            var url = vrtlDirr + '/T12202/GetUnitData';
            var params = { unitNo: untNo };
            return $http({ url: url, method: "POST", data: params }).then(function (results) { return results.data; }).catch(function (ex) { throw ex; });
        } catch (ex) { throw ex; }
    }
}
]);