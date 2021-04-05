app.controller("T12366Controller", ["$scope", "T12366Service", "Data", "$window", "$filter",
    function ($scope, T12366Service, Data, $window, $filter) {
        $scope.obj = {};
        $scope.obj = Data;

        $scope.obj.T12322 = [];
        $scope.obj.ProductList = [];
        $scope.obj.ReasonList = [];
        $scope.obj.p = {};
        $scope.obj.p.selected = {};
        $scope.obj.r = {};
        $scope.obj.r.selected = {};

        getProductList();
        getReasonList();

        $scope.onAddRow = function () {
            var x = {};
            x.p = {};
            x.p.selected = {};
            x.r = {};
            x.r.selected = {};
            x.T_UNIT_NO = null;
            x.T_DONATION_DATE = null;
            x.T_DONATION_DATE1 = null;
            x.ProductList = $scope.obj.ProductList;
            x.ReasonList = $scope.obj.ReasonList;
            x.p.selected = { T_PRODUCT_CODE: 'Select', T_EXPIRY_DAYS: '0' };
            x.r.selected = { CODE: '0', NAME: 'Select' };
            x.T_SELECTED = '';
            x.chk = 0;
            $scope.obj.T12322.push(x);
        }
        $scope.remvoveRow = function (i) {
            $scope.obj.T12322.splice(i, 1);
        }
        $scope.onProductSelect = function (i, dt) {
            $scope.obj.T12322[i].T_DONATION_DATE = addDays(dt.T_DONATION_DATE1, dt.p.selected.T_EXPIRY_DAYS);
        }
        function addDays(date, days) {
            var result = new Date(date);
            result.setDate(result.getDate() + days);
            return result;
        }
        $scope.onReasonSelect = function (i, dt) {
            var a = dt.r.selected.CODE;
            if (dt.p.selected.T_PRODUCT_CODE == 'APROD' && (a != '03' || a != '04' || a != '05')) {
                alert('Select The Propper Reason');
            }
        }
        $scope.onUnitSearch_tab = function (e, i, u) {

            if (e.keyCode === 9 || e.keyCode === 13) {
                $scope.obj.T12322[i].chk = 1;
                GetSingleUnit(u, i);
            }
        }
        $scope.onUnitSearch_blur = function (i, u) {
            $scope.obj.T12322[i].chk = 1;
            GetSingleUnit(u, i);
        }
        function getProductList() {
            var pdList = T12366Service.GetProductList();
            pdList.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    $scope.obj.T12322 = [];
                    $scope.obj.ProductList = JSON.parse(data);

                } else {
                }

            });
        }
        function getReasonList() {
            var rsList = T12366Service.GetReasonList();
            rsList.then(function (data) {
                var dt = JSON.parse(data);
                if (dt.length > 0) {
                    $scope.obj.ReasonList = JSON.parse(data);
                } else {
                }

            });
        }
        function GetSingleUnit(u, i) {
            if ($scope.obj.T12322[i].chk == 1) {
                if (u != null || u != '') {
                    var data = T12366Service.GetSingleUnit(u);
                    data.then(function (data) {
                        var dt = JSON.parse(data);
                        if (dt.length > 0) {
                            if (dt[0].T22T_UNIT_NO != null) {
                                $scope.obj.T12322[i].T_UNIT_NO1 = dt[0].T22T_UNIT_NO;
                                $scope.obj.T12322[i].T_DONATION_DATE = dt[0].T_DONATION_DATE;
                                $scope.obj.T12322[i].T_DONATION_DATE1 = dt[0].T_DONATION_DATE;
                                $scope.obj.T12322[i].p.selected = { T_PRODUCT_CODE: dt[0].T_PROD_CODE, T_EXPIRY_DAYS: dt[0].T_EXPIRY_DAYS };
                                $scope.obj.T12322[i].r.selected = { CODE: dt[0].T_REASON, NAME: dt[0].REASONNAME };
                                $scope.obj.T12322[i].T_SELECTED = '1';
                                $scope.obj.T12322[i].chk = 0;
                                console.log($scope.obj.T12322[i]);

                            } else {
                                if (dt[0].T23T_UNIT_NO == null) {
                                    alert('No Unit Available');
                                    $scope.obj.T12322[i].T_UNIT_NO = '';
                                    $scope.obj.T12322[i].T_UNIT_NO1 = '';
                                    $scope.obj.T12322[i].T_DONATION_DATE = '';
                                    $scope.obj.T12322[i].T_DONATION_DATE1 = '';
                                    $scope.obj.T12322[i].p.selected = { T_PRODUCT_CODE: 'Select', T_EXPIRY_DAYS: '0' };
                                    $scope.obj.T12322[i].r.selected = { CODE: '0', NAME: 'Select' };
                                    $scope.obj.T12322[i].T_SELECTED = '';
                                    $scope.obj.T12322[i].chk = 0;
                                }
                            }

                        } else {
                            alert('No Unit Available');
                            $scope.obj.T12322[i].T_UNIT_NO = '';
                            $scope.obj.T12322[i].T_UNIT_NO1 = '';
                            $scope.obj.T12322[i].T_DONATION_DATE = '';
                            $scope.obj.T12322[i].T_DONATION_DATE1 = '';
                            $scope.obj.T12322[i].p.selected = { T_PRODUCT_CODE: 'Select', T_EXPIRY_DAYS: '0' };
                            $scope.obj.T12322[i].r.selected = { CODE: '0', NAME: 'Select' };
                            $scope.obj.T12322[i].T_SELECTED = '';
                            $scope.obj.T12322[i].chk = 0;
                        }

                    });
                }
            }
            $scope.obj.onSave = function () {

                var t122 = $scope.obj.T12322.filter(function (item) { return (item.T_UNIT_NO != null && item.T_UNIT_NO != ''); });
                if (t122.length > 0) {
                    var sObj = [];
                    for (var i = 0; i < t122.length; i++) {
                        var y = {};
                        y.T_UNIT_NO = t122[i].T_UNIT_NO;
                        y.T_PRODUCT_CODE = t122[i].p.selected.T_PRODUCT_CODE;
                        y.T_REASON_CODE = t122[i].r.selected.CODE;
                        y.T_SELECTED = t122[i].T_SELECTED;
                        y.T_REMARKS = t122[i].T_REMARKS;
                        y.DONATION_DATE = $filter('date')(t122[i].T_DONATION_DATE1, "dd-MMM-yyyy");
                        y.T_EXPIRY_DATE = $filter('date')(addDays(t122[i].T_DONATION_DATE1, t122[i].p.selected.T_EXPIRY_DAYS), "dd-MMM-yyyy");
                        sObj.push(y);
                    }
                    var prodChk = sObj.filter(function (item) { return (item.T_PRODUCT_CODE == null || item.T_PRODUCT_CODE == ''); });
                    var rsnChk = sObj.filter(function (item) { return (item.T_REASON_CODE == null || item.T_REASON_CODE == '' && item.T_REASON_CODE != '0'); });
                    if (prodChk.length > 0) {
                        alert('Enter Product');
                        return;
                    } else if (rsnChk.length > 0) {
                        alert('Enter Reason For Discard');
                        return;
                    }
                    else {
                        var saveList = T12366Service.saveList(sObj);
                        saveList.then(function (data) {
                            var dt = JSON.parse(data);
                            alert(dt);

                        });
                    }
                }
            }
        }

    }]);