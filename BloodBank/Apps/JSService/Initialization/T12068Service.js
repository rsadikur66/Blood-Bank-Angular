app.service("T12068Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
    var dataT12068 = {
        GetAllGender: GetAllGender,
        GetQstHeadData: GetQstHeadData,
        GetFailData: GetFailData,
        InsertT12068: InsertT12068,
        UpdateT12068: UpdateT12068,
        DeleteT12068: DeleteT12068,
        InsertT12069: InsertT12069,
        EntryUser: EntryUser

};
    return dataT12068;

    //Entry User function Start
    function EntryUser() {
        try {
            var url = vrtlDirr +'/Accounts/EntryUser';
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
    //Entry User function end

    //For Gender Function Start
    function GetAllGender() {
        try {
            var url = vrtlDirr +'/T12068/GetAllGender';
            return $http({
                url: url,
                method: "POST",
                data: {}
               // data: { language: language }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    //For Gender Function End

    // For Label Function Start
    function GetQstHeadData() {
        try {
            var url = vrtlDirr +'/T12068/GetQstHeadData';
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
    //For Label Function End

    // For Fail Data Function Start
    function GetFailData() {
        try {
            var url = vrtlDirr +'/T12068/GetFailData';
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
    //For Fail Data Function End
    
 // For Insert Table T12068 Function Start
    function InsertT12068(t12068) {
        try {
            var url = vrtlDirr +'/T12068/InsertT12068';
            var params = { t12068: t12068 };
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
    //For Insert Table T12068 Function End

    // For Update Table T12068 Function Start
    function UpdateT12068(t12068) {
        try {
            var url = vrtlDirr +'/T12068/UpdateT12068';
            var params = { t12068: t12068 };
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
    //For Update Table T12068 Function End

    // For Delete Table T12068 Function Start
    function DeleteT12068(t12068) {
        try {
            var url = vrtlDirr +'/T12068/DeleteT12068';
            var params = { t12068: t12068 };
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
    //For Delete Table T12068 Function End

    // For Insert Table T12069 Function Start
    function InsertT12069(t12069) {

        try {
            var url = vrtlDirr +'/T12068/InsertT12069';
            var params = { t12069: t12069 };
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
    //For Insert Table T12069 Function End
}]);