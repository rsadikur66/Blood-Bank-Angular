app.service("T12250Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12250 = {
        CheckDonor: CheckDonor,
        GetReasonList: GetReasonList,
        GetSingleReason: GetSingleReason,
        GetPatientData: GetPatientData,
        insert: insert,
        GetBarCode: GetBarCode,
        GetReport: GetReport,
        GetLabelText: GetLabelText
    };
    return dataT12250;
    //For Label Function Start


    function CheckDonor(p, n) {
        try {
            var url = vrtlDirr + '/T12250/CheckDonor';
            return $http({
                url: url,
                method: "POST",
                data: { P_PAT_NO: p, P_NTNLTY_ID: n }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    // For Patient Data Function Start
    function GetPatientData(searchValue) {
        try {
            var url = vrtlDirr + '/T12250/GetPatientData';
            return $http({
                url: url,
                method: "POST",
                data: { searchValue: searchValue }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    //For Patient Data  Function End

    function GetReasonList(e) {
        try {
            var url = vrtlDirr + '/T12250/GetReasonList';
            return $http({
                url: url,
                method: "POST",
                data: { age: e }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function GetSingleReason(e, f) {
        try {
            var url = vrtlDirr + '/T12250/GetSingleReason';
            return $http({
                url: url,
                method: "POST",
                data: { age: e, reasonCode: f }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function insert(e) {
        try {
            var url = vrtlDirr + '/T12250/insert';
            return $http({
                url: url,
                method: "POST",
                data: { t12017: e }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function GetBarCode(patno, patname, nationalid, episodeno, arrivaldate, gender, year, nationality) {
        try {
            var url = vrtlDirr + '/T12250/GetBarCode';
            return $http({
                url: url,
                method: "POST",
                data: { patNo: patno, patName: patname, nationalId: nationalid, episodeNo: episodeno, arrivalDate: arrivaldate, Gender: gender, Age: year, Nationality: nationality }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function GetReport(patno, patname) {
        try {
            var url = vrtlDirr + '/T12250Report/GetReport';
            return $http({
                url: url,
                method: "POST",
                data: { patNo: patno, patName: patname }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
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
}]);