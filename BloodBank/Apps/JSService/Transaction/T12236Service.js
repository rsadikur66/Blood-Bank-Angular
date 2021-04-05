app.service("T12236Service", ["$http", "vrtlDirr" ,function ($http, vrtlDirr) {
    var dataT12236 = {
        GetLabelText: GetLabelText,
        GetBloodGroupList: GetBloodGroupList,
        GetUnitNo: GetUnitNo,
        updateT12019: updateT12019,
        CheckABOCode: CheckABOCode,
        getUnitData: getUnitData
    };
    return dataT12236;

    //For Label Function Start
    function GetLabelText(formcode, language) {
        try {
            var url = vrtlDirr + '/Account/GetLabelText';
            return $http({
                url: url,
                method: "POST",
                data: { formcode: formcode, language: language }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function GetBloodGroupList() {
        try {
            var url = vrtlDirr + '/T12236/GetBloodGroupList';
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

    function GetUnitNo(T_UNIT_FROM, T_UNIT_TO) {
        try {
            var url = vrtlDirr + '/T12236/GetUnitNo';
            return $http({
                url: url,
                method: "POST",
                data: { T_UNIT_FROM: T_UNIT_FROM, T_UNIT_TO: T_UNIT_TO}
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function CheckABOCode(T_ABO_CODE, T_UNIT_NO) {
        try {
            var url = vrtlDirr + '/T12236/CheckABOCode';
            return $http({
                url: url,
                method: "POST",
                data: { T_ABO_CODE: T_ABO_CODE, T_UNIT_NO: T_UNIT_NO }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function updateT12019(t12019) {
        try {
            var url = vrtlDirr + '/T12236/updateT12019';
            var params = { t12019: t12019 };
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