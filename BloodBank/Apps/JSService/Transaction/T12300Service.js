app.service("T12300Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        GetLabelText: GetLabelText,
        getPatDetailsData: getPatDetailsData,
        getDoctor: getDoctor,
        getABO: getABO,
        getsergeon: getsergeon,
        getProductData: getProductData,
        gethospitalData: gethospitalData,
        getCheckData: getCheckData,
        getWardData: getWardData,
        getNurseData: getNurseData,
        saveData: saveData,
        geAllData: geAllData,
        getVirusData: getVirusData
    };
    return dataSvc;

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
    function getPatDetailsData(patNo) {
        try {
            var url = vrtlDirr + '/T12300/GetPatDetailsData';
            return $http({
                url: url,
                method: "POST",
                data: { patNo: patNo }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getDoctor() {
        try {
            var url = vrtlDirr + '/T12300/GetDoctor';
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
    function getABO() {
        try {
            var url = vrtlDirr + '/T12300/GetABO';
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
    function getsergeon() {
        try {
            var url = vrtlDirr + '/T12300/Getsergeon';
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
    function getProductData() {
        try {
            var url = vrtlDirr + '/T12300/GetProductData';
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
    function gethospitalData() {
        try {
            var url = vrtlDirr + '/T12300/GethospitalData';
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
    function getCheckData() {
        try {
            var url = vrtlDirr + '/T12300/GetCheckData';
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
    function getWardData(siteCode) {
        try {
            var url = vrtlDirr + '/T12300/GetWardData';
            return $http({
                url: url,
                method: "POST",
                data: { siteCode: siteCode}
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getNurseData(siteCode) {
        try {
            var url = vrtlDirr + '/T12300/GetNurseData';
            return $http({
                url: url,
                method: "POST",
                data: { siteCode: siteCode }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function saveData(t12300) {
        try {
            var url = vrtlDirr + '/T12300/SaveData';
            return $http({
                url: url,
                method: "POST",
                data: { t12300: t12300 }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function geAllData(patNo) {
        try {
            var url = vrtlDirr + '/T12300/GeAllData';
            return $http({
                url: url,
                method: "POST",
                data: { patNo: patNo }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getVirusData() {
        try {
            var url = vrtlDirr + '/T12300/GetVirusData';
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
}]);