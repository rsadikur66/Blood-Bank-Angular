
app.service("T12215Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12215 = {
        //GetVirusList: GetVirusList,
        test: test
    };
    return dataT12215;
    function test() {
        try {
            var url = vrtlDirr + '/T12215/test';
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