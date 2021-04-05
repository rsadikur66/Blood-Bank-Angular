app.service("T06210Service", ["$http", "vrtlDirr", function ($http,vrtlDirr) {
    var dataT06210 = {
      
    };
    return dataT06210;


    function GridResultVirology(UnitNoFrom, UnitNoTo) {
        try {
            var url = vrtlDirr + '/T12241/GridResultVirology';
            return $http({
                url: url,
                method: "POST",
                data: { UnitNoFrom: UnitNoFrom, UnitNoTo: UnitNoTo }
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

}]);