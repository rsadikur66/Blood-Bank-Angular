app.service("T12338Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12338 = {
        GetCentralBankList: GetCentralBankList,
        GetTransfusionsList: GetTransfusionsList,
        insertToT12338: insertToT12338
    };
    return dataT12338;


    function GetCentralBankList() {
        try {
            var url = vrtlDirr + '/T12338/GetCentralBankList';
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
    function GetTransfusionsList(bankCode) {
        try {
            var url = vrtlDirr + '/T12338/GetTransfusionsList';
            var params = { bankCode: bankCode };
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
    function insertToT12338(t12338) {
        try {
            var url = vrtlDirr + '/T12338/InsertToT12338';
            var params = { t12338: t12338 };
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
}]);