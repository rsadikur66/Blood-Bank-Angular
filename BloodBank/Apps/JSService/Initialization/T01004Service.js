app.service("T01004Service", ["$http", "vrtlDirr", function ($http,vrtlDirr) {
    var dataT01004 = {
        GetGridData: GetGridData,
        insertData: insertData
    };
    return dataT01004;

   
    function GetGridData() {
        try {
            var url = vrtlDirr +'/T01004/GetGridData';
            return $http({
                url: url,
                method: "GET",
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


    function insertData(tm01004) {
        try {
            var url = vrtlDirr + '/T01004/insertData';
            return $http({
                url: url,
                method: "POST",
                data: { tm01004: tm01004 }
            }).then(function(results) {
                return results.data;
            }).catch(function(ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        } 
    }
}]);