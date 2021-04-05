app.service("Q12017Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = { GetAllData: GetAllData};
        return dataSvc;

    function GetAllData(e) {
        try {
            var url = vrtlDirr + '/Q12017/GetAllData';
            var params = { REQUEST_NO:e};
            return $http({
                url: url,
                method: 'POST',
                data: params
            }).then(function (results) {
                return results.data;
            }).catch(function (e) {
                throw e;
            });
        } catch (e) {
            throw e;
        }
    }



}
]);