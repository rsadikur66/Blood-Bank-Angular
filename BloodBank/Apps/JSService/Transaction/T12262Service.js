
app.service("T12262Service",
    [
        "$http", "vrtlDirr", function($http, vrtlDirr) {
            var dataSvc = {
              getDataBySiteCode: getDataBySiteCode,
              getDataRequestNo: getDataRequestNo,
              getRequestDetails: getRequestDetails,
                getRequestDetail: getRequestDetail,
              getuserDetails: getuserDetails,
              save: save
    
            };
            return dataSvc;
        function getDataBySiteCode() {
                try {
                  var url = vrtlDirr + '/T12262/GetDataBySiteCode';
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
        function getDataRequestNo(siteCode) {
                try {
                  var url = vrtlDirr + '/T12262/GetDataRequestNo';
                    var params = {};
                  return $http({
                    url: url,
                    method: "POST",
                    data: {siteCode: siteCode}
                    }).then(function (results) {
                        return results.data;
                    }).catch(function (ex) {
                        throw ex;
                    });
                } catch (ex) {
                    throw ex;
                }
        }
        function getRequestDetails(requestNo,steCode) {
                try {
                  var url = vrtlDirr + '/T12262/GetRequestDetails';
                    var params = {};
                    return $http({
                        url: url,
                        method: "POST",
                        data: { requestNo: requestNo, siteCode: steCode }
                    }).then(function (results) {
                        return results.data;
                    }).catch(function (ex) {
                        throw ex;
                    });
                } catch (ex) {
                    throw ex;
                }
            }
            function getRequestDetail() {
                try {
                  var url = vrtlDirr + '/T12262/GetRequestDetail';
                    var params = {};
                    return $http({
                        url: url,
                        method: "POST",
                        data: {  }
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
                  var url = vrtlDirr + '/T12262/GetuserDetails';
                    var params = {};
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
        function save(requestNo,time,site) {
                try {
                  var url = vrtlDirr + '/T12262/Save';
                    var params = {};
                    return $http({
                        url: url,
                        method: "POST",
                        data: { requestNo: requestNo, time: time, site: site}
                    }).then(function (results) {
                        return results.data;
                    }).catch(function (ex) {
                        throw ex;
                    });
                } catch (ex) {
                    throw ex;
                }
            }
        }
    ]);