app.service("T12003Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12003 = {
        GetHospitalListData: GetHospitalListData,
        GetProductWithUnitNo: GetProductWithUnitNo,
        GetProductListData: GetProductListData
        //GetUnitData: GetUnitData,
        //Insert_T13016: Insert_T13016
    };
    return dataT12003;

    function GetHospitalListData() {
        try {
            var url = vrtlDirr + '/T12003/GetHospitalListData';
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

    function GetProductWithUnitNo(unitNo) {
        try {
            var url = vrtlDirr + '/T12003/GetProductWithUnitNo';
            return $http({
                url: url,
                method: "POST",
                data: { unitNo: unitNo}
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });

        } catch (ex) {
            throw ex;
        }
    }

    function GetUnitData() {
        try {
            var url = vrtlDirr + '/T12233/GetUnitData';
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

    function Insert_T13016(t12233) {
        try {
            var url = vrtlDirr + '/T12233/Insert_T13016';
            var params = { t12233: t12233 };
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

    function GetProductListData(unitNo) {
        try {
            var url = vrtlDirr + '/T12003/GetProductListData';
            var params = { unitNo: unitNo};
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