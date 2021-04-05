app.service("R12006Service",["$http", "vrtlDirr", function($http,vrtlDirr) {
    var dataR12006 = {
        GetTechList: GetTechList,
        GetReasonList: GetReasonList,
        getCollector: getCollector,
        getCollection: getCollection,
        getCountTime: getCountTime,
        getInfoData: getInfoData,
        GetR12215Summery: GetR12215Summery
    };
    return dataR12006;
    function GetTechList() {
        try {
            var url = vrtlDirr + '/R12006/GetTechList';
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
            var url = vrtlDirr + '/R12006/GetReasonList';
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

    function getCollector(fdate) {
        try {
            var url = vrtlDirr + '/R12006/getCollector';
            return $http({
                url: url,
                method: "POST",
                data: { fdate: fdate}
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getCollection(fdate) {
        try {
            var url = vrtlDirr + '/R12006/getCollection';
            return $http({
                url: url,
                method: "POST",
                data: { fdate: fdate }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getCountTime(fdate) {
        try {
            var url = vrtlDirr + '/R12006/getCountTime';
            return $http({
                url: url,
                method: "POST",
                data: { fdate: fdate }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getInfoData() {
        try {
            var url = vrtlDirr + '/R12006/getInfoData';
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
    function GetR12215Summery(date) {
        try {
            var url = vrtlDirr + '/R12006/GetR12215Summery';
            return $http({
                url: url,
                method: "POST",
                data: { date: date}
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