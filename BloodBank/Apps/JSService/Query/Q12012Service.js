app.service("Q12012Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {

    dataQ12012 = {
        antiAllList: antiAllList,
        xMatchList: xMatchList,
        dctList: dctList
    };

    return dataQ12012;

    function antiAllList() {
        try {
            var url = vrtlDirr + '/T12302/antiList';
            var params = {};
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

        function dctList() {
            try {
                var url = vrtlDirr + '/T12302/dctList';
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

    function xMatchList(m) {
        try {
            var url = vrtlDirr + '/Q12012/getAllXMatchData';
            var params = { req: m };
            return $http({
                url: url,
                method: 'POST',
                data: params
            }).then(function(results) {
                return results.data;
            }).catch(function(e) {
                throw e;
            });
        } catch (e) {
            throw e;
        } 
    }

    

}
]);