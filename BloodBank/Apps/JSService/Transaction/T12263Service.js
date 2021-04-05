app.service("T12263Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12263 = {
        GetSiteList: GetSiteList,
        GetRequestList: GetRequestList,
        getGridData: getGridData,
        checkCrossMatch: checkCrossMatch,
        T12263insert: T12263insert,
        getCourierServiceData: getCourierServiceData,
        getdeliveryByData: getdeliveryByData,
        getDeliveryManLocation: getDeliveryManLocation
        //GetRequestedData: GetRequestedData,
    };
    return dataT12263;


    function GetSiteList() {
        try {
            var url = vrtlDirr + '/T12263/GetSiteList';
            var params = {};
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
    function GetRequestList(siteCode) {
        try {
            var url = vrtlDirr + '/T12263/GetRequestList';
            var params = { siteCode: siteCode };
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
    function GetRequestedData(requestNo) {
        try {
            var url = vrtlDirr + '/T12263/GetRequestedData';
            var params = { requestNo: requestNo };
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
    function getGridData(bldGrp, proCode) {
        try {
            var url = vrtlDirr + '/T12263/GetGridData';
            var params = { bldGrp: bldGrp, proCode: proCode };
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
    function checkCrossMatch(reqNo, bldGrp, proCode) {
        try {
            var url = vrtlDirr + '/T12263/CrossmatchCheck';
            var params = { reqNo: reqNo, bldGrp: bldGrp, proCode: proCode };
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

    function T12263insert(t12263) {
        try {
            var url = vrtlDirr + '/T12263/T12263insert';
            var params = { t12263: t12263 };
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

    function getCourierServiceData() {
        try {
            var url = vrtlDirr + '/T12263/GetCourierServiceData';
            var params = {};
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
    function getdeliveryByData() {
        try {
            var url = vrtlDirr + '/T12263/GetdeliveryByData';
            var params = {};
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
    function getDeliveryManLocation() {
        try {
            var url = vrtlDirr + '/T12263/GetDeliveryManLocation';
            var params = {};
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