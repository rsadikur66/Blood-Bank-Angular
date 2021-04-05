
app.service("T12309Service",["$http", "vrtlDirr", function($http, vrtlDirr) {
            var dataSvc = {
                // LabelData: LabelData
                getUnitData: getUnitData,
                getProductDetails: getProductDetails,
                saveData: saveData
            };
    return dataSvc;
    function getUnitData() {
            try {
                var url = vrtlDirr + '/T12309/GetUnitData';
                return $http({
                    url: url,
                    method: "Post",
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
    function getProductDetails(unitNo, prodCode) {
            try {
                var url = vrtlDirr + '/T12309/GetProductDetails';
                return $http({
                    url: url,
                    method: "Post",
                    data: { unitNo: unitNo, prodCode: prodCode}
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
    }
    function saveData(t12309) {
            try {
                var url = vrtlDirr + '/T12309/SaveData';
                return $http({
                    url: url,
                    method: "Post",
                    data: { t12309: t12309}
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
        }
        }
    ]);