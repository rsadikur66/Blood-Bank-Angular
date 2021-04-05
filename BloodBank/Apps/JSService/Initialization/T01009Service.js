app.service("T01009Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        GetAllUserData: GetAllUserData
    };
    return dataSvc;

 


    function GetAllUserData() {
        try {
            var url = vrtlDirr +'/T01009/GetAllUserData';
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