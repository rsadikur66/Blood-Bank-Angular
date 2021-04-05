
app.service("T12266Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12266 = {
        getDeliveryManData: getDeliveryManData,
        getReqDetails: getReqDetails,
        getuserDetails: getuserDetails,
        save: save
    };
    return dataT12266;

    function getDeliveryManData() {
        try {
            var url = vrtlDirr + '/T12266/GetDeliveryManData';
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
    function getReqDetails(bldReq, site) {
        try {
            var url = vrtlDirr + '/T12266/GetReqDetails';
            return $http({
                url: url,
                method: "POST",
                data: { bldReq: bldReq, site: site }
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
            var url = vrtlDirr + '/T12266/GetuserDetails';
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
    function save(delCode,requestNo, time, site) {
        try {
            var url = vrtlDirr + '/T12266/Save';
            var params = {};
            return $http({
                url: url,
                method: "POST",
                data: { delCode: delCode, requestNo: requestNo, time: time, site: site }
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