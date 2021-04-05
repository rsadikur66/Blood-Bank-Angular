app.service("T12337Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12337 = {
        GetZoneList: GetZoneList,
        GetBankTypeList: GetBankTypeList,
        GetSiteList: GetSiteList,
        GetGridListData: GetGridListData,
        insertToT12337: insertToT12337,
        UpdateToT12337: UpdateToT12337
    //GetHospitalListByBankType: GetHospitalListByBankType
};
    return dataT12337;


    function GetZoneList() {
        try {
            var url = vrtlDirr +'/T12337/GetZoneList';
            var params = { };
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
    function GetBankTypeList() {
        try {
            var url = vrtlDirr +'/T12337/GetBankTypeList';
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
    function GetGridListData() {
        try {
            var url = vrtlDirr +'/T12337/GetGridListData';
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

    function GetSiteList() {
        try {
            var url = vrtlDirr +'/T12337/GetSiteList';
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
    
   

    function insertToT12337(t12337) {
        try {
            var url = vrtlDirr +'/T12337/insertToT12337';
            var params = { t12337: t12337};
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

    function UpdateToT12337(t12337) {
        try {
            var url = vrtlDirr +'/T12337/UpdateToT12337';
            var params = { t12337: t12337 };
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