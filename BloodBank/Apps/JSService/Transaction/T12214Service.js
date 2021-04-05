app.service("T12214Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12214 = {
        GetLabelText: GetLabelText,
        getTitleList: getTitleList,
        getRelationList: getRelationList,
        getERRelationList: getERRelationList,
        getNationalityList: getNationalityList,
        getReligionList: getReligionList,
        getGenderList: getGenderList,
        getMrtlStatusList: getMrtlStatusList,
        getArabicName: getArabicName,
        getEnglishName: getEnglishName,
        getExistingPatData: getExistingPatData,
        insert: insert,
        checkNationlityCode: checkNationlityCode,
        getPatNo: getPatNo
    };
    return dataT12214;
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

    function getTitleList() {
        try {
            var url = vrtlDirr + '/T12214/GetTitle';
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
    function getRelationList() {
        try {
            var url = vrtlDirr + '/T12214/GetAllRelation';
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
    function checkNationlityCode(T_NTNLTY_ID) {
        try {
            var url = vrtlDirr + '/T12214/CheckNationalityCode';
            return $http({
                url: url,
                method: "POST",
                data: { T_NTNLTY_ID: T_NTNLTY_ID }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getERRelationList() {
        try {
            var url = vrtlDirr + '/T12214/GetAllERRelation';
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
    function getNationalityList() {
        try {
            var url = vrtlDirr + '/T12214/GetAllNationality';
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
    function getReligionList() {
        try {
            var url = vrtlDirr + '/T12214/GetAllReligion';
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
    function getGenderList() {
        try {
            var url = vrtlDirr + '/T12214/GetAllGender';
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
    function getMrtlStatusList() {
        try {
            var url = vrtlDirr + '/T12214/GetAllMrtlStatus';
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

    function getArabicName(englishName) {
        try {
            var url = vrtlDirr + '/T12214/GetArabicName';
            return $http({
                url: url,
                method: "POST",
                data: { englishName: englishName }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getEnglishName(arabicName) {
        try {
            var url = vrtlDirr + '/T12214/getEnglishName';
            return $http({
                url: url,
                method: "POST",
                data: { arabicName: arabicName }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }


    function getExistingPatData(pat, nat, fisName, fathName, graName, famName, gendr, natnl, regn, mrists, year) {
        try {
            var url = vrtlDirr + '/T12214/GetExistingPat';
            return $http({
                url: url,
                method: "POST",
                data: {
                    pat: pat, nat: nat, fisName: fisName, fathName: fathName, graName: graName,
                    famName: famName, gendr: gendr, natnl: natnl, regn: regn, mrists: mrists, year: year
                }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function insert(t03001) {
        try {
            var url = vrtlDirr + '/T12214/insert';
            var params = { t03001: t03001 };
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

    function getPatNo() {
        try {
            var url = vrtlDirr + '/T12214/GetPatNo';
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