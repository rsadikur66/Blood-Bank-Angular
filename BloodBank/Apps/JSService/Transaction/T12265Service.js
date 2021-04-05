app.service("T12265Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12265 = {
        GetRequestListData: GetRequestListData,
        updateT12091: updateT12091,
        getLocationDeliveryMan: getLocationDeliveryMan,
        getAllDeliveryManLocation: getAllDeliveryManLocation,
        insertT91: insertT91,
        GetHandOverDataFromCenter: GetHandOverDataFromCenter,
        updateT12091ForReceived: updateT12091ForReceived,
        updateT91T92ForDrop: updateT91T92ForDrop,
        updT65unassign: updT65unassign,
        UpdateActiveStatus: UpdateActiveStatus
    };
    return dataT12265;


    function GetRequestListData() {
        try {
            var url = vrtlDirr + '/T12265/GetRequestListData';
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
    function GetHandOverDataFromCenter() {
        try {
            var url = vrtlDirr + '/T12265/GetHandOverDataFromCenter';
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
    function getLocationDeliveryMan(bldReqNo) {
        try {
            var url = vrtlDirr + '/T12265/GetLocationDeliveryMan';
            return $http({
                url: url,
                method: "POST",
                data: { bldReqNo: bldReqNo }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getAllDeliveryManLocation(bldReqNo) {
        try {
            var url = vrtlDirr + '/T12265/GetAllDeliveryManLocation';
            return $http({
                url: url,
                method: "POST",
                data: { bldReqNo: bldReqNo }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }


    function updateT12091(acpt, reqId) {
        try {
            var url = vrtlDirr + '/T12265/updateT12091';
            var params = { acpt: acpt, reqId: reqId };
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
    function updateT12091ForReceived( reqNo) {
        try {
            var url = vrtlDirr + '/T12265/updateT12091ForReceived';
            var params = { reqNo: reqNo};
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
    function updateT91T92ForDrop( reqNo) {
        try {
            var url = vrtlDirr + '/T12265/updateT91T92ForDrop';
            var params = { reqNo: reqNo};
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

    function insertT91(reqId,reqNo, devMan, estDelDis, estDelTime,siteCode,canReason) {
        try {
            var url = vrtlDirr + '/T12265/insertT91';
            var params = { reqId: reqId, reqNo: reqNo, devMan: devMan, estDelDis: estDelDis, estDelTime: estDelTime, siteCode: siteCode, canReason: canReason};
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
    function updT65unassign(reqId,reqNo,siteCode) {
        try {
            var url = vrtlDirr + '/T12265/updT65unassign';
            var params = { reqId: reqId, reqNo: reqNo, siteCode: siteCode };
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
    function UpdateActiveStatus() {
        try {
            var url = vrtlDirr + '/T12265/UpdateActiveStatus';
            var params = { };
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