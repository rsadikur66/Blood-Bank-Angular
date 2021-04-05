app.service("T12235Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12235 = {
        //EntryUser: EntryUser,
        GetUnitData: GetUnitData,
        GetAntibodyData: GetAntibodyData,
        GetBloodData: GetBloodData,
        GetDuData: GetDuData,
        GetVerifidData: GetVerifidData,
        GetGridData: GetGridData,
        InsertT12220: InsertT12220,
        getUnitData: getUnitData
    };
    return dataT12235;
    
    //For Blood Group Dropdown Data
    function GetUnitData() {
        try {
            var url = vrtlDirr +  '/T12235/GetUnitData';
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

    //For Blood Data Function Start
    function GetBloodData() {
        try {
            var url = vrtlDirr + '/T12235/GetBloodData';
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
   
    //For Antibody Data Function Start
    function GetAntibodyData() {
        try {
            var url = vrtlDirr + '/T12235/GetAntibodyData';
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

    //For Du Function Start
    function GetDuData() {
        try {
            var url = vrtlDirr + '/T12235/GetDuData';
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

    //For Verifide Data Function Start
    function GetVerifidData() {
        try {
            var url = vrtlDirr + '/T12235/GetVerifidData';
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

    // For Grid Function Start
    function GetGridData(unitFrom, unitTo) {
        try {
            var url = vrtlDirr + '/T12235/GetGridData';
            return $http({
                url: url,
                method: "POST",
                data: { unitFrom: unitFrom, unitTo: unitTo}
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    // For Insert  Function Start
    function InsertT12220(t12235) {
        try {
            var url = vrtlDirr + '/T12235/InsertT12220';
            var params = { t12235: t12235 };
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
    function getUnitData(untNo) {
        try {
            var url = vrtlDirr + '/T12202/GetUnitData';
            var params = { unitNo: untNo };
            return $http({ url: url, method: "POST", data: params }).then(function (results) { return results.data; }).catch(function (ex) { throw ex; });
        } catch (ex) { throw ex; }
    }
    
}]);