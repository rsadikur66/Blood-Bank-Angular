app.service("T12232Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12232 = {
        GetVirusList: GetVirusList,
        GetDonationDate: GetDonationDate,
        ValidateUnitNo: ValidateUnitNo,
        GetAllData: GetAllData,
        CheckDoctorUser: CheckDoctorUser,
        updateT12034: updateT12034,
        CheckT12022: CheckT12022,
        CheckT12075: CheckT12075,
        CheckT12019: CheckT12019,
        CheckT12075_T_VIROLOGY_RESULT: CheckT12075_T_VIROLOGY_RESULT,
        CheckT12075_T_UNIT_DISCARD: CheckT12075_T_UNIT_DISCARD,
        CheckT12034_T_POS1_VERIFY: CheckT12034_T_POS1_VERIFY,
        getUnitData: getUnitData
    };
    return dataT12232;
    //For Label Function Start

    function GetVirusList() {
        try {
            var url = vrtlDirr + '/T12232/GetVirusList';
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

    function GetDonationDate(unitNo) {
        try {
            var url = vrtlDirr + '/T12232/GetDonationDate';
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

    function ValidateUnitNo(UnitNo) {
        try {
            var url = vrtlDirr + '/T12232/ValidateUnitNo';
            return $http({
                url: url,
                method: "POST",
                data: { UnitNo: UnitNo }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function GetAllData(T_UNIT_NO) {
        try {
            var url = vrtlDirr + '/T12232/GetAllData';
            return $http({
                url: url,
                method: "POST",
                data: { T_UNIT_NO: T_UNIT_NO }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function CheckDoctorUser() {
        try {
            var url = vrtlDirr + '/T12232/CheckDoctorUser';
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

    function updateT12034(M12034) {
        try {
            var url = vrtlDirr + '/T12232/updateT12034';
            var params = { M12034: M12034 };
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

    function CheckT12022(T_UNIT_NO) {
        try {
            var url = vrtlDirr + '/T12232/CheckT12022';
            return $http({
                url: url,
                method: "POST",
                data: { T_UNIT_NO: T_UNIT_NO }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function CheckT12075(T_UNIT_NO) {
        try {
            var url = vrtlDirr + '/T12232/CheckT12075';
            return $http({
                url: url,
                method: "POST",
                data: { T_UNIT_NO: T_UNIT_NO }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function CheckT12019(T_UNIT_NO) {
        try {
            var url = vrtlDirr + '/T12232/CheckT12019';
            return $http({
                url: url,
                method: "POST",
                data: { T_UNIT_NO: T_UNIT_NO }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function CheckT12075_T_VIROLOGY_RESULT(T_UNIT_NO) {
        try {
            var url = vrtlDirr + '/T12232/CheckT12075_T_VIROLOGY_RESULT';
            return $http({
                url: url,
                method: "POST",
                data: { T_UNIT_NO: T_UNIT_NO }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function CheckT12075_T_UNIT_DISCARD(T_UNIT_NO) {
        try {
            var url = vrtlDirr + '/T12232/CheckT12075_T_UNIT_DISCARD';
            return $http({
                url: url,
                method: "POST",
                data: { T_UNIT_NO: T_UNIT_NO }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function CheckT12034_T_POS1_VERIFY(T_UNIT_NO, T_VIRUS_CODE) {
        try {
            var url = vrtlDirr + '/T12232/CheckT12034_T_POS1_VERIFY';
            return $http({
                url: url,
                method: "POST",
                data: { T_UNIT_NO: T_UNIT_NO, T_VIRUS_CODE: T_VIRUS_CODE }
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