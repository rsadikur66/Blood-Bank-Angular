app.controller("T12263Controller", ["$scope", "T12263Service", "$filter", "$http", "$window", "Data", "T12091Service", "$interval",
    function ($scope, T12263Service, $filter, $http, $window, Data, T12091Service, $interval) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.t12263 = {};
        $scope.obj.BloodBankList = [];
        $scope.obj.C = {};
        $scope.obj.E = {};
        $scope.obj.D = {};
        $scope.obj.empCode = '';
        $scope.obj.userName = '';
        SiteListPopUp();
        $scope.hO = '0';
        //document.getElementById("dvMap").style.display = 'none';

        //$scope.GetSiteList = function () {
        //    SiteListPopUp();
        //    document.getElementById("divSitePopUp").style.display = 'block';
        //    clear();
        //}
        $interval(function () {
            SiteListPopUp();
        }, 5000);
        $scope.PopUpOnf9 = function (event) {
            if (event.keyCode === 120) {
                SiteListPopUp();
            }
        }
        $scope.onSiteListSelect = function (i, B) {
            clear();
            $scope.selectedRow = i;
            if (B.T_BB_ISSUED_TIME == null) {
                $scope.obj.T_SITE_CODE = B.CODE;
                $scope.obj.T_SITE_NAME = B.NAME;
                $scope.obj.T_SITE_LAT = B.TRANS_LAT;
                $scope.obj.T_SITE_LONG = B.TRANS_LNG;
                $scope.obj.T_BILL_SOFT_CODE = B.T_BILL_SOFT_CODE;
                $scope.obj.T_REQ_DATE = $filter('date')(B.T_BLOOD_REQDATE, "dd/MM/yyyy");
                $scope.obj.T_REQ_TIME = B.T_BLOOD_REQTIME;
                $scope.obj.T_REQUEST_NO = B.T_REQNO;
                $scope.obj.T_UNIT_COUNT = B.T_NUM_UNIT;
                $scope.obj.T_REQ_PROD_CODE = B.T_PRODUCT_CODE;
                $scope.obj.T_REQ_BLD_GRP = B.T_BLOOD_GRP;
                $scope.CenterLat = B.CNTR_LAT;
                $scope.CenterLong = B.CNTR_LNG;
                deliveryManLocation();
               // next_data();
                // mapCoordinate($scope.CenterLat, $scope.CenterLong, $scope.obj.T_SITE_LAT, $scope.obj.T_SITE_LONG);
                // document.getElementById("divSitePopUp").style.display = 'none';
            } else {
                if ($scope.hO =='0') {
                    alert('It has been Issued');
                }
            }
        }
        $scope.CloseSiteListPopup = function () {
            document.getElementById("divSitePopUp").style.display = 'none';
        }
        //$scope.GetRequestList = function () {
        //    RequestListPopUp();
        //}
        $scope.CloseRequestListPopup = function () {
            document.getElementById("divRequestNoPopUp").style.display = 'none';
        }
        $scope.onRequestListSelect = function (i, D) {
            $scope.obj.T_REQUEST_NO = D.CODE;
            $scope.obj.T_UNIT_COUNT = $scope.obj.RequestList[i].T_NUM_UNIT;
            $scope.obj.T_REQ_BLD_GRP = $scope.obj.RequestList[i].T_BLOOD_GRP;
            $scope.obj.T_REQ_DATE = $filter('date')($scope.obj.RequestList[i].T_BLOOD_REQDATE, "dd/MM/yyyy");
            $scope.obj.T_REQ_TIME = $scope.obj.RequestList[i].T_BLOOD_REQTIME;
            $scope.obj.T_REQ_PROD_CODE = $scope.obj.RequestList[i].T_PRODUCT_CODE;
            //$scope.obj.T_SITE_NAME = B.NAME;

            document.getElementById("divRequestNoPopUp").style.display = 'none';
        }

        //Buttons
        $scope.Save = function () {

            var t12263 = $scope.obj.BloodIssueList;
            if (t12263.length > 0) {
                var insert;
                var count = 0;
                for (var j = 0; j < t12263.length; j++) {

                    if (t12263[j].IssueYN == true) {
                        count++;
                    }
                }
                if (count > $scope.obj.T_UNIT_COUNT) {

                    swal("Can not Issue unit more than requested no of unit");
                } else {
                    $scope.obj.insertArray = [];
                    for (var i = 0; i < t12263.length; i++) {
                        if (t12263[i].IssuedBy_Code != '') {
                            var INS = {};
                            debugger;

                            INS.T_BLOOD_GRP = t12263[i].BloodGroup;
                            INS.T_PRODUCT_CODE = t12263[i].ProductCode;
                            INS.T_BLOOD_REQNO = $scope.obj.T_REQUEST_NO;
                            INS.T_UNIT_NO = t12263[i].UnitNo;
                            INS.T_BB_ISSUED_BY = t12263[i].IssuedBy_Code;
                            INS.T_BB_ISSUED_DATE = t12263[i].IssueDate;
                            INS.T_BB_ISSUED_TIME = t12263[i].IssueTime;
                            INS.T_BLOOD_EXPIRY_DATE = t12263[i].ExpiryDate;
                            INS.T_SITE_CODE = $scope.obj.T_SITE_CODE;
                            INS.T_COURIER_CODE = $scope.obj.T_COURIER_CODE;
                            INS.T_TRACKING_NO = $scope.obj.T_TRACK_NO;
                            INS.T_ESTIMATED_DELIVERY_TIME = $scope.obj.T_EST_TIME;
                            //INS.T_ESTIMATION_TYPE = $scope.obj.E.selected.T_EST_NAME;
                            //INS.T_DELIVERY_MAN = $scope.obj.T_EMP_CODE;
                            INS.T_DELIVERY_MAN = $scope.obj.DEL_CODE;
                            INS.ESTIMATE_DISTANCE = $scope.obj.ESTIMATE_DISTANCE
                            INS.ESTIMATE_TIME = $scope.obj.ESTIMATE_TIME
                            INS.T_ENTRY_TIME = $filter('date')(new Date(), "HHmm")
                            $scope.obj.insertArray.push(INS);
                            //INS.T_ACTIVE = t12263[i].HiddenField;  


                        }
                    }//for part
                    if ($scope.obj.insertArray.length > 0) {
                        if ($scope.obj.DEL_CODE != undefined && $scope.obj.DEL_CODE != '') {
                            insert = T12263Service.T12263insert($scope.obj.insertArray);
                            insert.then(function (data) {
                                clear();
                                initMap();
                                alert(data);
                            });
                        } else {
                            alert("Delivery man is not available");
                        }

                    }


                }//else part
            }
        }
        $scope.Handover_Flag = function (ind, D) {
            var d = confirm('Are you sure to Handover');
            if (d) {
                $scope.hO = '1';
                    $scope.obj.T_HANDOVER_TIME = $filter('date')(new Date(), "HHmm");
                    var save = T12091Service.save(D.T_REQNO, $scope.obj.T_HANDOVER_TIME, D.CODE);
                    save.then(function (data) {
                        var dt = JSON.parse(data);
                        SiteListPopUp();
                        alert($scope.getSingleMsg(dt));

                    });
                
            }
           
            
        }
        $scope.Next =  function () {
            var checkCrossmatch = T12263Service.checkCrossMatch($scope.obj.T_REQUEST_NO, $scope.obj.T_REQ_BLD_GRP, $scope.obj.T_REQ_PROD_CODE);
            checkCrossmatch.then(function (data) {
                var cmData = JSON.parse(data);
                if (cmData.length > 0) {
                    swal('You cant add unit into crossmatched request', '', 'error');
                } else {
                    var gridData = T12263Service.getGridData($scope.obj.T_REQ_BLD_GRP, $scope.obj.T_REQ_PROD_CODE);
                    gridData.then(function (data) {
                        var testData = JSON.parse(data);
                        if (testData.length > 0) {
                            $scope.obj.BloodIssueList = [];
                            for (var i = 0; i < testData.length; i++) {
                                $scope.obj.e = {};
                                $scope.obj.e.UnitNo = testData[i].T_UNIT_NO;
                                $scope.obj.e.ProductCode = testData[i].T_PRODUCT_CODE;
                                $scope.obj.e.BloodGroup = testData[i].T_ABO_CODE;
                                //$scope.obj.e.IssueDate = testData[i].T_UNIT_NO;
                                //$scope.obj.e.IssueTime = testData[i].T_UNIT_NO;
                                $scope.obj.e.IssuedBy_Code = '';
                                $scope.obj.e.IssuedBy_Name = '';
                                $scope.obj.e.empCode = testData[i].T_EMP_CODE;
                                $scope.obj.e.userName = testData[i].T_USER_NAME;
                                //$scope.obj.e.IssuedBy_Name = testData[i].T_UNIT_NO;
                                $scope.obj.e.ExpiryDate = $filter('date')(testData[i].T_EXPIRY_DATE, "dd/MM/yyyy");;
                                $scope.obj.e.T_ACTIVE = '';
                                $scope.obj.e.T_COURIER_CODE = $scope.obj.T_COURIER_CODE;
                                $scope.obj.e.T_TRACK_NO = $scope.obj.T_TRACK_NO;
                                $scope.obj.e.T_EST_TIME = $scope.obj.T_EST_TIME;
                                $scope.obj.e.T_EMP_CODE = $scope.obj.T_EMP_CODE;
                                $scope.obj.BloodIssueList.push($scope.obj.e);
                            } //for lood end
                        } else {
                            swal("This Product not in stock", "", "error");
                        }
                    });
                }
            });

        }//Finish Next Function

        $scope.IssuedCheckboxClicked = function (index) {
            var IssueCheckBox = document.getElementById("IssueChkYN" + index).checked;
            if (IssueCheckBox == true) {
                $scope.obj.BloodIssueList[index].IssueDate = $filter('date')(new Date(), "dd/MM/yyyy");
                $scope.obj.BloodIssueList[index].IssueTime = $filter('date')(new Date(), "HHmm");
                $scope.obj.BloodIssueList[index].IssuedBy_Code = $scope.obj.e.empCode;
                $scope.obj.BloodIssueList[index].IssuedBy_Name = $scope.obj.e.userName;
            } else {
                $scope.obj.BloodIssueList[index].IssueDate = '';
                $scope.obj.BloodIssueList[index].IssueTime = '';
                $scope.obj.BloodIssueList[index].IssuedBy_Code = '';
                $scope.obj.BloodIssueList[index].IssuedBy_Name = '';
            }
        }

        //All Functions are below--
        function gridLine() {
            for (var j = 0; j < 1; j++) {
                $scope.obj.d = {};
                $scope.obj.d.T_BANK_CODE = '';

                $scope.obj.d.T_LANG2_NAME = '';
                $scope.obj.d.T_LANG1_NAME = '';
                $scope.obj.d.T_BANK_ACTIVE = '';
                $scope.obj.d.HiddenField = '';
                $scope.obj.BloodBankList.push($scope.obj.d);
                //$scope.obj.BloodBankList = $scope.obj.Test;
            }
        }
        var c = 0;
        function SiteListPopUp() {
            var ListofSiteList = T12263Service.GetSiteList();
            ListofSiteList.then(function (data) {
                $scope.obj.SiteList = JSON.parse(data);
                $scope.obj.CenterLat = $scope.obj.SiteList[0].CNTR_LAT;
                $scope.obj.CenterLong = $scope.obj.SiteList[0].CNTR_LNG;
                if (c == 0) { initMap(); c = 1;}
                
            });
        }
        function RequestListPopUp() {
            if ($scope.obj.T_SITE_CODE != null && $scope.obj.T_SITE_CODE != undefined) {
                var ListofRequest = T12263Service.GetRequestList($scope.obj.T_SITE_CODE);
                ListofRequest.then(function (data) {
                    var jsonData = JSON.parse(data);
                    if (jsonData.length > 0) {
                        $scope.obj.RequestList = JSON.parse(data);
                        document.getElementById("divRequestNoPopUp").style.display = 'block';
                    }
                });

            } else {
                alert("Please select site");
            }

        }
        function formatted_string(pad, user_str, pad_pos) {
            if (typeof user_str === 'undefined')
                return pad;
            if (pad_pos == "1") {
                return (pad + user_str).slice(-pad.length);
            }
            else {
                return (user_str + pad).substring(0, pad.length);
            }
        }
        function clear() {
            $scope.obj.T_SITE_NAME = '';
            $scope.obj.T_SITE_CODE = '';
            $scope.obj.T_UNIT_COUNT = '';
            $scope.obj.T_REQ_BLD_GRP = '';
            $scope.obj.T_REQ_DATE = '';
            $scope.obj.T_REQ_TIME = '';
            $scope.obj.T_REQ_PROD_CODE = '';
            $scope.obj.T_REQUEST_NO = '';
            $scope.obj.C.selected = '';
            $scope.obj.E.selected = '';
            $scope.obj.D.selected = '';
            $scope.obj.T_TRACK_NO = '';
            $scope.obj.T_EST_TIME = '';

            $scope.obj.BloodIssueList = [];
        }
        var courierService = T12263Service.getCourierServiceData();
        courierService.then(function (data) {
            $scope.obj.CourierDataList = JSON.parse(data);
        })
        var deliveryBy = T12263Service.getdeliveryByData();
        deliveryBy.then(function (data) {
            $scope.obj.DeliveryDataList = JSON.parse(data);
        })
        $scope.obj.EstmitDataList = [{ T_EST_VALUE: "Hour", T_EST_NAME: "Hour" }, { T_EST_VALUE: "Day", T_EST_NAME: "Day" }];
        //================== for Map start============================
        function haversine_distance(mk1, mk2) {
            var R = 3958.8; // Radius of the Earth in miles
            var rlat1 = mk1.position.lat() * (Math.PI / 180); // Convert degrees to radians
            var rlat2 = mk2.position.lat() * (Math.PI / 180); // Convert degrees to radians
            var difflat = rlat2 - rlat1; // Radian difference (latitudes)
            var difflon = (mk2.position.lng() - mk1.position.lng()) * (Math.PI / 180); // Radian difference (longitudes)

            var d = 2 * R * Math.asin(Math.sqrt(Math.sin(difflat / 2) * Math.sin(difflat / 2) + Math.cos(rlat1) * Math.cos(rlat2) * Math.sin(difflon / 2) * Math.sin(difflon / 2)));
            return d;
        }
        var map;
        var mk1;
        var mk2;
        var dakota;
        var frick;
        // initMap();
        function mapCoordinate(centerlat, centerlong, desLat, desLong) {
            const center = { lat: centerlat, lng: centerlong };
            const options = { zoom: 6, scaleControl: true, center: center };
            map = new google.maps.Map(
                document.getElementById('dvMap'), options);

            dakota = { lat: centerlat, lng: centerlong };
            frick = { lat: desLat, lng: desLong };

            mk1 = new google.maps.Marker({ position: dakota, map: map, icon: "../Images/Amb_MarkerR.png" });
            mk2 = new google.maps.Marker({ position: frick, map: map, icon: "../Images/Amb_MarkerR.png" });

            // var distance = haversine_distance(mk1, mk2);            

            let directionsService = new google.maps.DirectionsService();
            let directionsRenderer = new google.maps.DirectionsRenderer();
            directionsRenderer.setMap(map); // Existing map object displays directions
            // Create route from existing points used for markers
            const route = {
                origin: dakota,
                destination: frick,
                travelMode: 'DRIVING'
            }

            directionsService.route(route,
                function (response, status) { // anonymous function to capture directions
                    if (status !== 'OK') {
                        window.alert('Directions request failed due to ' + status);
                        return;
                    } else {
                        directionsRenderer.setDirections(response); // Add route to the map
                        var directionsData = response.routes[0].legs[0]; // Get data about the mapped route
                        if (!directionsData) {
                            window.alert('Directions request failed');
                            return;
                        }
                        else {
                            $scope.obj.dis = directionsData.distance.text + " (" + directionsData.duration.text + ").";
                            return;
                            // document.getElementById('msg').innerHTML += " Driving distance is " + directionsData.distance.text + " (" + directionsData.duration.text + ").";
                        }
                    }
                });
        }


        function initMap() {
            // The map, centered on Central Park  "lat": '23.7541774',
            //        "lng": '90.39335650000001',
            const center = { lat: $scope.obj.CenterLat, lng: $scope.obj.CenterLong };
            const options = { zoom: 6, scaleControl: true, center: center };
            map = new google.maps.Map(
                document.getElementById('dvDeliveryMap'), options);
            // Locations of landmarks
            // const dakota = { lat: 23.7541774, lng: 90.39335650000001 };
            //const frick = { lat: 24.7541774, lng: 91.39335650000001 };
            dakota = { lat: $scope.obj.CenterLat, lng: $scope.obj.CenterLong };
            frick = { lat: $scope.obj.CenterLat, lng: $scope.obj.CenterLong };
            // The markers for The Dakota and The Frick Collection
            //  mk1 = new google.maps.Marker({ position: dakota, map: map, icon: "../Images/Amb_MarkerR.png" });
            //  mk2 = new google.maps.Marker({ position: frick, map: map, icon: "../Images/Amb_MarkerR.png"});
        }


        function distancecount() {
            // Draw a line showing the straight distance between the markers
            // var line = new google.maps.Polyline({ path: [dakota, frick], map: map });
            // Calculate and display the distance between markers
            var distance = haversine_distance(mk1, mk2);
            //  $scope.obj.dis = distance.toFixed(2);
            // document.getElementById('msg').innerHTML = "Distance between markers: " + distance.toFixed(2) + " mi.";

            let directionsService = new google.maps.DirectionsService();
            let directionsRenderer = new google.maps.DirectionsRenderer();
            directionsRenderer.setMap(map); // Existing map object displays directions
            // Create route from existing points used for markers
            const route = {
                origin: dakota,
                destination: frick,
                travelMode: 'DRIVING'
            }
        }

        function directionMapping() {
            directionsService.route(route,
                function (response, status) { // anonymous function to capture directions
                    if (status !== 'OK') {
                        window.alert('Directions request failed due to ' + status);
                        return;
                    } else {
                        directionsRenderer.setDirections(response); // Add route to the map
                        var directionsData = response.routes[0].legs[0]; // Get data about the mapped route
                        if (!directionsData) {
                            window.alert('Directions request failed');
                            return;
                        }
                        else {
                            $scope.obj.dis = directionsData.distance.text + " (" + directionsData.duration.text + ").";
                            return;
                            // document.getElementById('msg').innerHTML += " Driving distance is " + directionsData.distance.text + " (" + directionsData.duration.text + ").";
                        }
                    }
                });
        }


        //================== for Map end ============================
        //================== for delivery man map start ============================
        // @TODO refactor
        // TODO make filters work together
        function deliveryManLocation() {
            var deliveryMan = T12263Service.getDeliveryManLocation();
            deliveryMan.then(function (data) {
                $scope.obj.location = JSON.parse(data);
                if ($scope.obj.location.length > 0) {
                    $scope.obj.CENTER_LAT = $scope.obj.location[0].LAT;
                    $scope.obj.CENTER_LON = $scope.obj.location[0].LON;
                }
                initialise();
            })
        }

        var map;
        function initialise() {
            var myLatlng = new google.maps.LatLng($scope.obj.CENTER_LAT, $scope.obj.CENTER_LON);
            var mapOptions = {
                center: myLatlng,
                zoom: 6,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById("dvDeliveryMap"), mapOptions);
            // Geo Location /
            navigator.geolocation.getCurrentPosition(function (pos) {
                map.setCenter(new google.maps.LatLng(pos.coords.latitude, pos.coords.longitude));
                var myLocation = new google.maps.Marker({
                    position: new google.maps.LatLng(pos.coords.latitude, pos.coords.longitude),
                    map: map,
                    animation: google.maps.Animation.DROP,
                    title: "My Location"
                    //code: "My Code"
                });
            });
            $scope.map = map;
            // Additional Markers //
            $scope.markers = [];
            var infoWindow = new google.maps.InfoWindow();
            var createMarker = function (info) {
                var marker = new google.maps.Marker({
                    position: new google.maps.LatLng(info.LAT, info.LON),
                    map: $scope.map,
                    animation: google.maps.Animation.DROP,
                    //title: info.city,
                    title: info.NAME,
                    code: info.CODE,
                    // icon: " "                      
                    icon: "../Images/Amb_MarkerG.png" 
                });
                marker.content = '<div class="infoWindowContent">' + info.desc + '</div>';
                google.maps.event.addListener(marker, 'click', function () {
                    infoWindow.setContent('<h4>' + marker.title + '</h4>' + marker.code);
                    infoWindow.open($scope.map, marker);
                });
                $scope.markers.push(marker);
            }
            
                for (i = 1; i < $scope.obj.location.length; i++) {
                    createMarker($scope.obj.location[i]);

                }
         
            
            //for distance 
            $scope.obj.List = [];
            for (i = 1; i < $scope.obj.location.length; i++) {
                var center = { lat: $scope.obj.CENTER_LAT, lng: $scope.obj.CENTER_LON }; //$scope.obj.CENTER_LAT, $scope.obj.CENTER_LON
                var dist = { lat: $scope.obj.location[i].LAT, lng: $scope.obj.location[i].LON };
                $scope.obj.center = new google.maps.Marker({ position: center, map: map, icon: " " });
                $scope.obj.distination = new google.maps.Marker({ position: dist, map: map, icon: " " });//, icon: "../Images/Amb_MarkerG.png"
                var r = Calculet_distance($scope.obj.center, $scope.obj.distination)
                if (r != null) {
                    $scope.obj.newList = {};
                    $scope.obj.newList.LAT = $scope.obj.location[i].LAT,
                        $scope.obj.newList.LON = $scope.obj.location[i].LON,
                        $scope.obj.newList.DEL_CODE = $scope.obj.location[i].CODE,
                        $scope.obj.newList.dis = r
                    $scope.obj.List.push($scope.obj.newList);
                }
            }
            $scope.obj.result = $scope.obj.List.reduce(function (res, obj) {
                return (obj.dis < res.dis) ? obj : res;
            });
            if ($scope.obj.result != null) {
                $scope.obj.DEL_CODE = $scope.obj.result.DEL_CODE;
                var cntlat = $scope.obj.CENTER_LAT;
                var centlong = $scope.obj.CENTER_LON;
                var desLat = $scope.obj.result.LAT;
                var desLon = $scope.obj.result.LON;
                bind(cntlat, centlong, desLat, desLon);

            }
        };

        function bind(centerlat, centerlong, desLat, desLong) {
            const center = { lat: centerlat, lng: centerlong };
            // const options = { zoom: 6, scaleControl: true, center: center };          

            dakota = { lat: centerlat, lng: centerlong };
            frick = { lat: desLat, lng: desLong };

            mk1 = new google.maps.Marker({ position: dakota, map: map, icon: "../Images/Hospital.jpg" });
            mk2 = new google.maps.Marker({ position: frick, map: map, icon: "../Images/Amb_MarkerG.png" });

            // var distance = haversine_distance(mk1, mk2);

            let directionsService = new google.maps.DirectionsService();
            let directionsRenderer = new google.maps.DirectionsRenderer();
            directionsRenderer.setMap(map); // Existing map object displays directions
            // Create route from existing points used for markers
            const route = {
                origin: dakota,
                destination: frick,
                travelMode: 'DRIVING'
            }

            directionsService.route(route,
                function (response, status) { // anonymous function to capture directions
                    if (status !== 'OK') {
                        window.alert('Directions request failed due to ' + status);
                        return;
                    } else {
                        directionsRenderer.setDirections(response); // Add route to the map
                        var directionsData = response.routes[0].legs[0]; // Get data about the mapped route
                        if (!directionsData) {
                            window.alert('Directions request failed');
                            return;
                        }
                        else {
                            $scope.obj.ESTIMATE_DISTANCE = directionsData.distance.text;
                            $scope.obj.ESTIMATE_TIME = directionsData.duration.text;
                            $scope.obj.dis = directionsData.distance.text + " (" + directionsData.duration.text + ").";
                            return;
                        }
                    }
                });
        }
        //=========================
        function Calculet_distance(mk1, mk2) {
            var R = 3958.8; // Radius of the Earth in miles
            var rlat1 = mk1.position.lat() * (Math.PI / 180); // Convert degrees to radians
            var rlat2 = mk2.position.lat() * (Math.PI / 180); // Convert degrees to radians
            var difflat = rlat2 - rlat1; // Radian difference (latitudes)
            var difflon = (mk2.position.lng() - mk1.position.lng()) * (Math.PI / 180); // Radian difference (longitudes)

            var d = 2 * R * Math.asin(Math.sqrt(Math.sin(difflat / 2) * Math.sin(difflat / 2) + Math.cos(rlat1) * Math.cos(rlat2) * Math.sin(difflon / 2) * Math.sin(difflon / 2)));
            return d;
        }


        //================== for delivery man map end ============================
    }]);