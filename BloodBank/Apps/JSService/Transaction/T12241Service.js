app.service("T12241Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12241 = {
        GridResultVirology: GridResultVirology,
        DocEmpCode: DocEmpCode,
        updateVirologyResults: updateVirologyResults,
        GetUnitPopUpData: GetUnitPopUpData,
        InsertT12223: InsertT12223,
        getUnitData: getUnitData
};
    return dataT12241;


    function GridResultVirology(UnitNoFrom,UnitNoTo) {
            try {
                var url = vrtlDirr + '/T12241/GridResultVirology';
                return $http({
                    url: url,
                    method: "POST",
                    data: { UnitNoFrom: UnitNoFrom, UnitNoTo: UnitNoTo}
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
    }

    function DocEmpCode() {
        try {
            var url = vrtlDirr + '/T12241/DocEmpCode';
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

    function updateVirologyResults(unitNo) {
        try {
            var url = vrtlDirr + '/T12241/updateVirologyResults';
            return $http({
                url: url,
                method: "POST",
                data: {unitNo : unitNo}
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function GetUnitPopUpData() {
        try {
            var url = vrtlDirr + '/T12241/GetUnitPopUpData';
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

    function InsertT12223(unitNo) {
        try {
            var url = vrtlDirr + '/T12241/InsertT12223';
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
}]);