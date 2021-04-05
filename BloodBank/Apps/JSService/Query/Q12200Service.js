app.service("Q12200Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {

    dataQ12200 = {
        getGridData: getGridData,
        xMatchList: xMatchList,
        dctList: dctList
    };

    return dataQ12200;

    function getGridData(dateParam) {
        try {
            var url = vrtlDirr + '/Q12200/GetGridData';
            var params = { dateParam: dateParam};
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