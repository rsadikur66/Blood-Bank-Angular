app.service("T12087Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        GetGridData: GetGridData,
        GetGridDataChild: GetGridDataChild,
        Update_T12087: Update_T12087
    };
    return dataSvc;

    function GetGridData() {
        try {
            var url = vrtlDirr +'/T12087/GetGridData';
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

    function GetGridDataChild(viralCode) {
        try {
            var url = vrtlDirr +'/T12087/GetGridDataChild';
            var params = { viralCode: viralCode };
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

    function Update_T12087(t12087, M12087) {
        try {
            var url = vrtlDirr +'/T12087/Update_T12087';
            var params = { t12087: t12087, M12087: M12087 };
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