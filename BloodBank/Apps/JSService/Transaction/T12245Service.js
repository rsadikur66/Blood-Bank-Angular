app.service("T12245Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12245 = {
        GetCentrifugeList: GetCentrifugeList,
        GetProgramList: GetProgramList,
        GetGridDataList: GetGridDataList,
        Insert: Insert,
        SecondGetGridDataList: SecondGetGridDataList,
        DeleteRowData: DeleteRowData,
        UpdateT12135: UpdateT12135,
        GetMessagesList: GetMessagesList
        
        //GetBarCode: GetBarCode
    };
    return dataT12245;
    //For Label Function Start

    function GetCentrifugeList() {
        try {
            var url = vrtlDirr + '/T12245/GetCentrifugeList';
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

    function GetProgramList() {
        try {
            var url = vrtlDirr + '/T12245/GetProgramList';
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

    function GetGridDataList(UnitNo) {
        try {
            var url = vrtlDirr + '/T12245/GetGridDataList';
            return $http({
                url: url,
                method: "POST",
                data: { UnitNo: UnitNo}
            }).then(function(results) {
                return results.data;
            }).catch(function(ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        } 
    }

   
    function Insert(T12135) {
        try {
            var url = vrtlDirr + '/T12245/Insert';
            var params = { T12135: T12135};
            return $http({
                url: url,
                method: "POST",
                data: params
            }).then(function (results) {
                return results.statusText;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function DeleteRowData(unitNo,productCode) {
        try {
            var url = vrtlDirr + '/T12245/DeleteRowData';
            var params = { T_UNIT_NO: unitNo, T_PRODUCT_CODE: productCode };
            return $http({
                url: url,
                method: "POST",
                data: params
            }).then(function (results) {
                return results.statusText;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    
    function SecondGetGridDataList(UnitNo) {
        try {
            var url = vrtlDirr + '/T12245/SecondGetGridDataList';
            return $http({
                url: url,
                method: "POST",
                data: { UnitNo: UnitNo }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function UpdateT12135(UnitNo) {
        try {
            var url = vrtlDirr + '/T12245/UpdateT12135';
            var params = { UnitNo: UnitNo };
            return $http({
                url: url,
                method: "POST",
                data: params
            }).then(function (results) {
                return results.statusText;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }

    function GetMessagesList() {
        try {
            var url = vrtlDirr + '/T12245/GetMessagesList';
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
}]);