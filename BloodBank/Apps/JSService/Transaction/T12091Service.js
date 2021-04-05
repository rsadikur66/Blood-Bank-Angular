
app.service("T12091Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12091 = {
        getDeliveryManData: getDeliveryManData,
        getReqDetails: getReqDetails,
        getuserDetails: getuserDetails,
        save: save
    };
    return dataT12091;

    function getDeliveryManData() {
        try {
            var url = vrtlDirr + '/T12091/GetDeliveryManData';
            return $http({
                url: url,
                method: "POST",
                data: { }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getReqDetails(bldReq,site) {
        try {
            var url = vrtlDirr + '/T12091/GetReqDetails';
            return $http({
                url: url,
                method: "POST",
                data: { bldReq: bldReq, site: site}
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getuserDetails() {
        try {
            var url = vrtlDirr + '/T12091/GetuserDetails';
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
    function save(requestNo, time, site) {
        try {
            var url = vrtlDirr + '/T12091/Save';
            var params = {};
            return $http({
                url: url,
                method: "POST",
                data: { requestNo: requestNo, time: time, site: site }
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