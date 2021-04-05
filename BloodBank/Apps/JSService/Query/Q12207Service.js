app.service("Q12207Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {

        dataQ12207 = {
            getGridData: getGridData            
        };

        return dataQ12207;

        function getGridData() {
            try {
                var url = vrtlDirr + '/Q12207/GetGridData';
              var params = { };
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