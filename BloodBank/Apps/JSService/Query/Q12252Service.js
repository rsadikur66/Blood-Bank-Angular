app.service("Q12252Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataSvc = {
        GetDataByUnitNo: GetDataByUnitNo,
        GetDataByDonor1: GetDataByDonor1,
        GetDataByDonor2: GetDataByDonor2
    };
        return dataSvc;

    function GetDataByUnitNo(e) {
        try {
            var url = vrtlDirr + '/Q12252/GetDataByUnitNo';
            var params = { P_UNIT_NO:e};
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
    function GetDataByDonor1(e) {
            try {
                var url = vrtlDirr + '/Q12252/GetDataByDonor1';
                var params = { P_DONOR_ID:e};
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
    function GetDataByDonor2(e) {
            try {
                var url = vrtlDirr + '/Q12252/GetDataByDonor2';
                var params = { P_DONOR_ID:e};
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