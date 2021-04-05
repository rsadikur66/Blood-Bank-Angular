app.service("T12264Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
  var dataT12264 = {
    GetDataWithReqNo: GetDataWithReqNo,
    T12264updateT12067andT12065: T12264updateT12067andT12065
  };
  return dataT12264;


  function GetDataWithReqNo(requestNo) {
    try {
      var url = vrtlDirr + '/T12264/GetDataWithRequestNo';
      return $http({
        url: url,
        method: "POST",
        data: { T_REQ_NO: requestNo }
      }).then(function (results) {
        return results.data;
      }).catch(function (ex) {
        throw ex;
      });
    } catch (ex) {
      throw ex;
    }
  }

  function T12264updateT12067andT12065(t12264) {
        try {
          var url = vrtlDirr + '/T12264/T12264updateT12067andT12065';
            var params = { t12264: t12264 };
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