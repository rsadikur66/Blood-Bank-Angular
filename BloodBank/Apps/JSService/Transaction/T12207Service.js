app.service("T12207Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        GetRefHospital: GetRefHospital,
        GetBlood: GetBlood,
        GetProduct: GetProduct,
        Insert_T12207: Insert_T12207,
        getGridDataForTransfusion: getGridDataForTransfusion,
        bloodReceiveFromTransfusion: bloodReceiveFromTransfusion
    };
    return dataSvc;

    function GetRefHospital() {
        try {
            var url = vrtlDirr + '/T12207/GetRefHospital';
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

    function GetBlood() {
        try {
            var url = vrtlDirr + '/T12207/GetBlood';
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

    function GetProduct() {
        try {
            var url = vrtlDirr + '/T12207/GetProduct';
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
    function getGridDataForTransfusion() {
        try {
            var url = vrtlDirr + '/T12207/getGridDataForTransfusion';
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

    function Insert_T12207(t12207) {
        try {
            var url = vrtlDirr + '/T12207/Insert_T12207';
            var params = { t12207: t12207 };
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
    function bloodReceiveFromTransfusion(del,blNo) {
        try {
            var url = vrtlDirr + '/T12207/BloodReceiveFromTransfusion';
            var params = { del: del, blNo: blNo };
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