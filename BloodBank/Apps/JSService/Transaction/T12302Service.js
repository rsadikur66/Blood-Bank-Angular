app.service("T12302Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        reqList: reqList,
        reqDet: reqDet,
        bgList: bgList,
        techList: techList,
        antTypAutoList: antTypAutoList,
        antTypFinalList: antTypFinalList,
        antiList: antiList,
        dctList: dctList,
        getbgByControl: getbgByControl,
        getbgByControl6: getbgByControl6,
        checkBg: checkBg,
        checkT_SC: checkT_SC,
        chkDoctor: chkDoctor,
        unitList: unitList,
        insert: insert,
        GetLabelText: GetLabelText,
        getUserId: getUserId,
        checkBlood: checkBlood
    };
    return dataSvc;
    function reqList(m) {
        try {
            var url = vrtlDirr + '/T12302/reqList';
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
    function reqDet(m) {
        try {
            var url = vrtlDirr + '/T12302/reqDet';
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
    function bgList(m) {
        try {
            var url = vrtlDirr + '/T12302/bgList';
            var params = { code: m };
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
    function techList(m) {
        try {
            var url = vrtlDirr + '/T12302/techList';
            var params = { code: m };
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
    function antTypAutoList(c,m) {
        try {
            var url = vrtlDirr + '/T12302/antTypAutoList';
            var params = { code: c,type:m };
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
    function antTypFinalList(c, m) {
        try {
            var url = vrtlDirr + '/T12302/antTypFinalList';
            var params = { code: c, type:m};
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
    function antiList() {
        try {
            var url = vrtlDirr + '/T12302/antiList';
            var params = {};
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
    function dctList() {
        try {
            var url = vrtlDirr + '/T12302/dctList';
            var params = {};
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
    function getbgByControl(a,b,d,c) {
        try {
            var url = vrtlDirr + '/T12302/getbgByControl';
            var params = { P_ANTI_A: a, P_ANTI_B: b, P_ANTI_D: d, P_CONTROL:c};
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
    function getbgByControl6(a, b, d, c,ac,bc) {
        try {
            var url = vrtlDirr + '/T12302/getbgByControl6';
            var params = { P_ANTI_A: a, P_ANTI_B: b, P_ANTI_D: d, P_CONTROL: c, P_ACELL: ac, P_BCELL: bc };
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
    function checkBg(pat) {
        try {
            var url = vrtlDirr + '/T12302/checkBg';
            var params = { P_PAT_NO: pat};
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
    function checkT_SC(pat) {
        try {
            var url = vrtlDirr + '/T12302/checkT_SC';
            var params = { P_PAT_NO: pat };
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
    function chkDoctor() {
        try {
            var url = vrtlDirr + '/T12302/chkDoctor';
            var params = {};
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
    function unitList(pa,ph,pc,bg,un,rq) {
        try {
            var url = vrtlDirr + '/T12302/unitList';
            var params = { P_PAT_NO: pa, P_PHENO: ph, P_REQUISITION: pc, P_ABO_CODE: bg, P_UNIT_NO: un, P_REQUEST_NO:rq};
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
    function insert(t12013, t12256) {
        try {
            var url = vrtlDirr + '/T12302/insert';
            var params = { t12013: t12013, t12256: t12256 };
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
    function getUserId() {
        try {
            var url = vrtlDirr + '/T12302/getUserId';
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
    function checkBlood(patId) {
        try {
            var url = vrtlDirr + '/T12302/checkBlood';
            return $http({
                url: url,
                method: "POST",
                data: { patId: patId}
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