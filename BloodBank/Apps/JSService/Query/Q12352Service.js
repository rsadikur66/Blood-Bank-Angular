app.service("Q12352Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        GetChartData: GetChartData
    };
    return dataSvc;
    function GetChartData(productCode) {
        try {
            var url = vrtlDirr + '/Q12352/GetChartData';
            return $http({
                url: url,
                method: "POST",
                data: { productCode: productCode}
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