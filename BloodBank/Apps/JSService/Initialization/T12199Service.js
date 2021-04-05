app.service("T12199Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12199 = {
        method: method
    };
    return dataT12199;


    function method() {
        try {
            var url = vrtlDirr +'/T12199/method';
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