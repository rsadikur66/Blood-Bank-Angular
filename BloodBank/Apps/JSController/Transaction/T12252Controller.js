
app.controller("T12252Controller",["$scope", "T12252Service", "Data", "$window", "$filter",
        function($scope, T12252Service, Data, $window, $filter) { //$location,
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.t12252 = {};
            $scope.obj.W = {};
            $scope.obj.W.selected = {};
            $scope.obj.Unit = [];
            $scope.obj.disabled = '';
            var weld = [{ WeldName: 1002011, WeldId: 1 }, { WeldName: 1002013, WeldId: 2 }];
            $scope.obj.WeldList = weld;
            addRow();

            $scope.Unit_Click = function(event,ind, unid) {
                if (event.keyCode === 13 || event.keyCode === 9) {
                $scope.newArra = [];
                $scope.newObj = {};
                $scope.existdata = '';

                if (unid !== '') {
                    var grid = T12252Service.getGridData(unid);
                    grid.then(function(data) {
                        var jsonData = JSON.parse(data);
                        if (jsonData.length>0) {
                            ExistedGrid(unid);

                    $scope.result = jsonData.filter(i => i.T_VIOROLOGY_RESULT === '1'
                        && i.T_ANTIBODY_1.toUpperCase() !== 'POS'
                        && i.T_USED_FLG === null
                        && i.T_SEQ_NO === null);
                            if ($scope.result.length > 0) {
                                ckeckGridUnit($scope.result[0].T_UNIT_NO);
                                if ($scope.existdata == '') {
                                    
                                    for (var j = 0; j < $scope.result.length; j++) {
                                        $scope.newObj1 = {};
                                        $scope.newObj1.T_UNIT_NO = $scope.result[j].T_UNIT_NO;
                                        $scope.newObj1.DONATION_DATE = $scope.result[j].DONATION_DATE;
                                        $scope.newObj1.T_SEGMENT_NO = $scope.result[j].T_SEGMENT_NO;
                                        $scope.newObj1.T_BLOOD_GROUP = $scope.result[j].T_BLOOD_GROUP;
                                        $scope.newObj1.T_BB_STOCK_ID = $scope.result[j].T_BB_STOCK_ID;
                                        $scope.newObj1.T_PRODUCT_CODE = $scope.result[j].T_PRODUCT_CODE;
                                        $scope.newObj1.CheckValue = '1';
                                        $scope.newArra.push($scope.newObj1);
                                       
                                    }
                                    $scope.obj.Unit = $scope.newArra;
                                    $scope.newArra = [];
                                    addRow();
                                } else {
                                    var d = $scope.obj.Unit.length - 1;
                                    $scope.obj.Unit[d].T_UNIT_NO = '';
                                }

                            } else {
                                $scope.V = jsonData.filter(i => i.T_ANTIBODY_1 === '0');
                                $scope.S = jsonData.filter(i => i.T_SEQ_NO !== null);
                                $scope.U = jsonData.filter(i => i.T_USED_FLG !== null);
                                $scope.I = jsonData.filter(i => i.T_ISSUE_FLAG !== null);
                                if ($scope.S.length > 0) {
                                    alert('This Unit Enter Before'); //pooled unit
                                    $scope.obj.Unit[ind].T_UNIT_NO = '';
                                    return;
                                }
                                if ($scope.U.length > 0) {
                                    alert('This Unit has been Cross match'); //Cross match
                                    $scope.obj.Unit[ind].T_UNIT_NO = '';
                                    return;
                                }
                                
                                if ($scope.V.length>0) {
                                    alert($scope.getSingleMsg('S0707'));
                                    $scope.obj.Unit[ind].T_UNIT_NO = '';
                                    return;
                                    //No Virology Result For This Unit  S0707
                                } else {
                                    alert($scope.getSingleMsg('S0706'));
                                    $scope.obj.Unit[ind].T_UNIT_NO = '';
                                }
                              
                                
                            }
                        } else {
                            alert($scope.getSingleMsg('S0709'));
                            $scope.obj.Unit[ind].T_UNIT_NO = '';
                        }

                        


                    });
                }
             }
            };

            function ExistedGrid(unid) {
                for (var j = 0; j < $scope.obj.Unit.length; j++) {
                    if ($scope.obj.Unit[j].T_UNIT_NO !== unid) {
                    $scope.newObj.T_UNIT_NO = $scope.obj.Unit[j].T_UNIT_NO;
                    $scope.newObj.DONATION_DATE = $scope.obj.Unit[j].DONATION_DATE;
                    $scope.newObj.T_SEGMENT_NO = $scope.obj.Unit[j].T_SEGMENT_NO;
                    $scope.newObj.T_BLOOD_GROUP = $scope.obj.Unit[j].T_BLOOD_GROUP;
                    $scope.newObj.CheckValue = $scope.obj.Unit[j].CheckValue;
                    $scope.newObj.T_BB_STOCK_ID = $scope.obj.Unit[j].T_BB_STOCK_ID;
                    $scope.newObj.T_PRODUCT_CODE = $scope.obj.Unit[j].T_PRODUCT_CODE;
                    $scope.newArra.push($scope.newObj);
                    
                    }
                } 
            }

            function ckeckGridUnit(unit) {
                for (var i = 0; i < $scope.obj.Unit.length; i++) {
                    if ($scope.obj.Unit[i].T_UNIT_NO === unit && $scope.obj.Unit[i].CheckValue === '1') {
                        alert('Unit already exist in grid');//This Unit Enter Before
                        $scope.existdata = '1';
                        
                    }
                }
            }

            

            //$scope.Add_Click = function(i) {
            //    ExistedGrid(unid);
            //    addRow();
            //};

            function addRow() {
                var newRow = [];
                newRow.T_UNIT_NO = '';
                $scope.obj.Unit.push(newRow);
            }

            $scope.onSave = function () {
                var welId = $scope.obj.W.selected.WeldId;
                $scope.ret = $scope.obj.Unit.filter(i => i.T_UNIT_NO !== '' && i.CheckValue==='1');
                if ($scope.ret.length>0) {
                    if (welId !== null) {
                        var save = T12252Service.SaveData($scope.ret, welId);
                        save.then(function (data) {
                            alert('save successfully');
                        });
                    } else {
                        alert('Please Select Weld ID');
                    }
                } else {
                    alert('No data add in Grid');
                }
                
                
            };

            $scope.Next_Click = function() {
                pickUpAllData();
            };
            function pickUpAllData() {
                if ($scope.obj.t12252.DateFrom !== undefined) {
                    var fdate = $scope.dateParse($scope.obj.t12252.DateFrom, "/");
                    var tdate = $scope.dateParse($scope.obj.t12252.DateTo, "/");
                }
                var Seq = $scope.obj.t12252.T_SEQ_NO;
                var gdata = T12252Service.pickUpData(fdate, tdate, Seq);
                gdata.then(function (data) {
                    var jsonData = JSON.parse(data);
                    $scope.obj.Unit = jsonData;
                   // $scope.obj.t12252.T_SEQ_NO = jsonData[0].T_SEQ_NO;
                    $scope.wel = weld.filter(i => i.WeldId == jsonData[0].T_WELD_ID);
                    //$scope.obj.W.selected = { WeldName: $scope.wel[0].WeldName, WeldId: jsonData[0].T_WELD_ID };
                    $scope.obj.t12252.welder = $scope.wel[0].WeldName;
                    $scope.obj.disabled = '1';
                });
            }
            $scope.Remove_Click = function (index) {
                if ($scope.obj.disabled != '1') {
                $scope.obj.Unit.splice(index, 1);
                }
            };
            $scope.Seq_Click = function(t) {
                if (t==='s') {
                    $scope.obj.t12252.T_SEQ_NO = '';
                    $scope.obj.Unit = [];
                    $scope.obj.t12252.welder = '';
                    addRow();
                }
                else if (t === 'd') {
                    $scope.obj.t12252.DateTo = '';
                    $scope.obj.t12252.DateFrom = '';
                    $scope.obj.Unit = [];
                    $scope.obj.t12252.welder = '';
                    addRow();
                }
            };
            $scope.setgridData = function(data) {
               
                $scope.wel = weld.filter(i => i.WeldId == data);
                $scope.obj.t12252.welder = $scope.wel[0].WeldName;
            };
            var ck = 0;
            $scope.Clear_Click = function () {

               
                    if ($scope.obj.Unit[0].T_UNIT_NO=='') {
                        ck = 1;
                    } else {
                        ck = 0;
                    }
                if (ck ===1) {
                    $scope.obj.t12252.DateTo = '';
                    $scope.obj.t12252.DateFrom = '';
                    $scope.obj.t12252.T_SEQ_NO = '';
                    $scope.obj.t12252.welder = '';
                } else {
                    $scope.obj.Unit = [];
                    addRow();
                }

            };
            $scope.NewClick = function () {
                $scope.obj.Unit = [];
                addRow();
                
               
            };
            $scope.Keydown_Click = function(e) {
                
                if (e.keyCode === 114) {
                    pickUpAllData();
                    e.preventDefault();
                }
                //e.preventDefault();
            };
            $scope.Date_Click = function (date, type) {
                var k = '';
                var s = date.split('/');
                if (s.length > 0) {
                    k = s[0] + s[1] + s[2];
                } else {
                    k = s;
                }
               
                if (type==='f') {
                    var fdate = dateFormate(k);
                    $scope.obj.t12252.DateFrom = fdate;
                    $scope.obj.t12252.DateTo=currentDate();
                } else if (type === 't') {
                    var tdate = dateFormate(k);
                    $scope.obj.t12252.DateTo = tdate;
                }
                
            };
            var getDay = '';
            var getMon = '';
            var getyea = '';
             function dateFormate (date) {
                getDay = date.substring(0, 2);
                var getlast6 = date.substring(2);
                var mon = getlast6.substring(0, 2);
                getMon =mon;
               // getMon = month(mon);
                var ye = getlast6.substring(2);
                if (ye === "") {
                    var ff = new Date();
                    getyea = ff.getFullYear();
                } else {
                    getyea = years(ye);
                }
                 var d = getDay + '/' + getMon + '/' + getyea;
                 return d;
                 // $scope.obj.t12252.DateFrom = getDay + '/' + getMon + '/' + getyea;

                 
             };
            function month(mon) {
                var m = '';
                if (mon === '01') {
                    m = 'Jan';
                }
                else if (mon === '02') {
                    m = 'Feb';
                }
                else if (mon === '03') {
                    m = 'Mar';
                }
                else if (mon === '04') {
                    m = 'Apr';
                }
                else if (mon === '05') {
                    m = 'May';
                }
                else if (mon === '06') {
                    m = 'Jun';
                }
                else if (mon === '07') {
                    m = 'Jul';
                }
                else if (mon === '08') {
                    m = 'Aug';
                }
                else if (mon === '09') {
                    m = 'Sep';
                }
                else if (mon === '10') {
                    m = 'Oct';
                }
                else if (mon === '11') {
                    m = 'Nov';
                }
                else if (mon === '12') {
                    m = 'Dec';
                } else {
                    // alert('Month is not correct ');
                    m = '00';
                }
                return m;
            }
            function years(ye) {
                var y = '';
                var yy = '';
                if (ye.length === 4) {
                    y = ye;
                } else {
                    yy = ye.substring(0, 2);
                    var dt = new Date();
                    var fy = dt.getFullYear();
                    var k = fy.toString();
                    var f = k.substring(0, 2);
                    y = f + yy;
                }
                return y;
            }
            function currentDate() {
                var today = new Date();
                var da = $filter('date')(today, "dd/MM/yyyy");
                return da;
            }
            
        }
    ]);