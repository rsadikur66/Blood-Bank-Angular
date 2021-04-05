app.service("T12246Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12246 = {
        GetBloodData: GetBloodData,
        GetProductData: GetProductData,
        GetGridData: GetGridData,
        Insert_T12211: Insert_T12211
    };
    return dataT12246;

    //For Blood Data Function Start
    function GetBloodData() {
        try {
            var url = vrtlDirr +'/T12246/GetBloodData';
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

    //For Product Data Function Start
    function GetProductData() {
        try {
            var url = vrtlDirr +'/T12246/GetProductData';
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

    function GetGridData(productCode, bloodGroup) {
        try {
            var url = vrtlDirr +'/T12246/GetGridData';
            var params = { productCode: productCode, bloodGroup: bloodGroup };
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

    function Insert_T12211(t12246,p,b) {
        try {
            var url = vrtlDirr +'/T12246/Insert_T12211';
            var params = { t12246: t12246,p:p,b:b };
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