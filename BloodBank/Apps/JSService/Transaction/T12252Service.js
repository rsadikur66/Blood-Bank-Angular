
app.service("T12252Service",
    [
        "$http", "vrtlDirr", function($http, vrtlDirr) {
            var dataget = {
                getGridData: getGridData,
                SaveData: SaveData,
                pickUpData: pickUpData
                //GetReasonList: GetReasonList,
                //GetSingleReason: GetSingleReason,
                //GetPatientData: GetPatientData,
                //insert: insert,
                //GetBarCode: GetBarCode,
                //GetReport: GetReport,
                //GetLabelText: GetLabelText
    
            };
            return dataget;
            function getGridData(unitId) {
                try {
                    var url = vrtlDirr + '/T12252/getGridData';
                    return $http({
                        url: url,
                        method: "POST",
                        data: { unitId: unitId}
                    }).then(function (results) {
                        return results.data;
                    }).catch(function (ex) {
                        throw ex;
                    });
                } catch (ex) {
                    throw ex;
                }
            }
            function SaveData(t23List, welId) {
                try {
                    var url = vrtlDirr + '/T12252/SaveData';
                    return $http({
                        url: url,
                        method: "POST",
                        data: { t23List: t23List, welId: welId }
                    }).then(function (results) {
                        return results.data;
                    }).catch(function (ex) {
                        throw ex;
                    });
                } catch (ex) {
                    throw ex;
                }
            }
            function pickUpData(fdate, tdate, Seq) {
                try {
                    var url = vrtlDirr + '/T12252/pickUpData';
                    return $http({
                        url: url,
                        method: "POST",
                        data: { fdate: fdate, tdate: tdate, Seq: Seq }
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