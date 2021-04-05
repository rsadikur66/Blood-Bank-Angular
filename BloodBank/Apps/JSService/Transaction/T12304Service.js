app.service("T12304Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        reqList: reqList,
        SecondGetGridDataList: SecondGetGridDataList,
        insertT12304: insertT12304,
        GetIssuedbyName: GetIssuedbyName,
        GetReqNoList: GetReqNoList
        
    };
    return dataSvc;
    function reqList(m) {
        try {
            var url = vrtlDirr + '/T12304/reqList';
            var params = { req: m };
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
    function SecondGetGridDataList(reqNo) {
        try {
            var url = vrtlDirr + '/T12304/secondGrid';
            var params = { reqNo: reqNo };
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

    function GetIssuedbyName(empCode) {
        try {
            var url = vrtlDirr + '/T12304/GetIssuedbyName';
            var params = { empCode: empCode };
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

    function GetReqNoList() {
        try {
            var url = vrtlDirr + '/T12304/GetReqNoList';
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


    function insertT12304(t12304) {
        try {
            var url = vrtlDirr + '/T12304/insertT12304';
            var params = { t12304: t12304 };
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