
app.service("Q12025Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataGet = {
        getSiteData: getSiteData,
        getBloodGroupData: getBloodGroupData,
        getProductData: getProductData,
        getStocktData: getStocktData

    };
    return dataGet;
    function getSiteData() {
        try {
            var url = vrtlDirr +'/Q12025/GetSiteData';
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
    function getBloodGroupData() {
        try {
            var url = vrtlDirr +'/Q12025/GetBloodGroupData';
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
            var url = vrtlDirr +'/Q12025/GetProductData'; 
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
    function getStocktData(donTiFrom, donTiTo, siteCode, bloodGrp, product) {
        try {
            var url = vrtlDirr +'/Q12025/GetStocktData';
            return $http({
                url: url,
                method: "POST",
                data: { donTiFrom: donTiFrom, donTiTo: donTiTo, siteCode: siteCode, bloodGrp: bloodGrp, product: product}
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

}])