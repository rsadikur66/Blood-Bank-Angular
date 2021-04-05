
app.service("Q12263Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        getGridData: getGridData
    };
    return dataSvc;
    function getGridData() {
        try {
            var url = vrtlDirr + '/Q12263/GetGridData';
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
    //function getGridData() {
    //    try {
    //        var url = vrtlDirr + '/Q12263/GetGridAllData';
    //        return $http({
    //            url: url,
    //            method: "POST",
    //            data: {}
    //        }).then(function (results) {
    //            return results.data;
    //        }).catch(function (ex) {
    //            throw ex;
    //        });
    //    } catch (ex) {
    //        throw ex;
    //    }
    //}

}]);
