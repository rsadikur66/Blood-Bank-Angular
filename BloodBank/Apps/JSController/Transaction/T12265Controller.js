app.controller("T12265Controller", ["$scope", "T12265Service", "$filter", "$http", "$window", "Data","$interval",
    function ($scope, T12265Service, $filter, $http, $window, Data, $interval) {
        //page initialize start
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.t12265 = {};
        $scope.obj.DeliveryRequestList = [];
        $scope.obj.t12265.T_REQ_ACCEPT_FLG = 'Disable';
        $scope.obj.checkBusy = 'Disable';
        $scope.obj.t12265.T_REQ_CANCEL_FLG = 'Disable';
        document.getElementById('googleMapDiv').style.display = 'none';
        document.getElementById('btnRcv').style.display = 'none';
       // $scope.status = 'Accept';
        $scope.obj.t12265.Count = 0;
        RequestNo();
        // Refresh or reload page.
        function refresh() {
            window.location.reload();
        }
        //page initialize end
        //handoverfromCenter();
        autoSetRequestData();
        function autoSetRequestData() {
            if ($scope.obj.t12265.Count > 0) {
                alert($scope.status);
            }
        }
        //For Request List Popup start
        $scope.countprocess = 0;
       $interval(function ()
        {
           RequestNo();
           $scope.countprocess++;
       }, 5000);

       function RequestNo () {
            var requestListPopUpData = T12265Service.GetRequestListData();
            requestListPopUpData.then(function (data) {
                var RequestListJsonData = JSON.parse(data);
                $scope.obj.t12265.Count = RequestListJsonData.length;
                if ($scope.obj.t12265.Count > 0) {                    
                    $scope.obj.RequestListOfData = RequestListJsonData;
                    $scope.obj.T_REQUEST_STATUS = RequestListJsonData[0].T_REQUEST_STATUS;                    
                    if ($scope.countprocess == '1') {
                        if (RequestListJsonData[0].T_REQ_ACCEPT_FLG == '1') {
                            $scope.onRequestListSelect(0, RequestListJsonData[0]);
                        }
                    }
                    // document.getElementById('divRequestListPopUp').style.display = 'block';
                } else {
                   // alert('No Data Found.')
                }
            })
        }
      
        $scope.ShowRequest_Click = function () {
            if ($scope.obj.t12265.Count> 0) {
                document.getElementById('divRequestListPopUp').style.display = 'block';
            }           
        }
        $scope.CloseRequestListPopup = function () {
            document.getElementById('divRequestListPopUp').style.display = 'none';
        }
        $scope.onRequestListSelect = function (ind, b) {
            $scope.obj.t12265.T_REQ_ID = $scope.obj.RequestListOfData[ind].T_REQ_ID;
            $scope.obj.t12265.T_NUM_UNIT = $scope.obj.RequestListOfData[ind].T_NUM_UNIT;
            $scope.obj.t12265.T_BLOOD_REQ_NO = $scope.obj.RequestListOfData[ind].BLOOD_REQ_NO;
            $scope.obj.t12265.T_REF_HOSPITAL = $scope.obj.RequestListOfData[ind].T_REF_HOSPITAL;
            $scope.obj.t12265.T_SITE_HOSPITAL = $scope.obj.RequestListOfData[ind].T_SITE_HOSPITAL;
            $scope.obj.t12265.T_ESTIMATED_DELIVERY_TIME = $scope.obj.RequestListOfData[ind].T_ESTIMATED_DELIVERY_TIME;
            $scope.obj.t12265.T_ESTIMATED_DELIVERY_DIST = $scope.obj.RequestListOfData[ind].T_ESTIMATED_DELIVERY_DIST;
            $scope.obj.t12265.T_REQ_ACCEPT_FLG = '';
            $scope.obj.checkBusy = '';
            $scope.obj.t12265.T_REQ_CANCEL_FLG = '';
            if (b.T_REQ_ACCEPT_FLG == '1') {
                $scope.status = 'Arrive';
                document.getElementById('btnRcv').style.display = 'block';
                $scope.handoverfromCenterFlag = "Accepted";
                document.getElementById('lblHandOverFromCenter').style.backgroundColor = '#728C00';
                document.getElementById("btnRcv").style.background = '#E8ADAA';
                $scope.obj.t12265.T_REQ_ACCEPT_FLG = 'Disable';
            }
            if (b.T_BLOOD_RCVD_FLG == '1') {
                $scope.status = 'Drop';
                $scope.handoverfromCenterFlag = "Arrived";
                document.getElementById('lblHandOverFromCenter').style.backgroundColor = 'red';
                document.getElementById("btnRcv").style.background = '#fea';
            }
            if (b.T_BLOOD_DROP_FLG == '1') {
                $scope.status = 'Dropped';
                document.getElementById("btnRcv").style.background = '#7BCCB5';
            } if (b.T_REQ_ACCEPT_FLG == null) {
                $scope.status = 'Incoming';
                document.getElementById('btnRcv').style.display = 'block';
                $scope.handoverfromCenterFlag = "Request incoming";
                document.getElementById('lblHandOverFromCenter').style.backgroundColor = '#a21217';
                document.getElementById("btnRcv").style.background = '#85a9c7';
                $scope.mySwitch = true;
            }
            LocationDeliveryMan();            
            document.getElementById('divRequestListPopUp').style.display = 'none';
        }
        //For Request List Popup start

        //For Save Data start
        $scope.Save = function () {
            if ($scope.obj.t12265.T_REQ_ACCEPT_FLG === '1') {
                updateT91 = T12265Service.updateT12091($scope.obj.t12265.T_REQ_ACCEPT_FLG, $scope.obj.t12265.T_REQ_ID);
                updateT91.then(function (data) {
                    var testData = JSON.parse(data);
                    alert(testData == "1" ? "Request Accepted" : "Data not updated!!!");
                    clear();                    
                    window.location.reload();
                    $scope.handoverfromCenterFlag = "Request Accept From Hospital.";                    
                })
            }
        }
        //For Save Data end

        //Flags checkboxe's start
        $scope.RequestAccept_Flag = function () {
            $scope.obj.checkBusy = '';
            $scope.obj.t12265.T_REQ_CANCEL_FLG = '';            
        }
        $scope.RequestCancel_Flag = function () {            
            $scope.obj.t12265.T_REQ_ACCEPT_FLG = '';
            searchNearDeliveryMan();            
        }

        //DMLL = DELIVER MAN LOCATION LATITUDE
        //DMLLO = DELIVERY MAN LOCATION LONGITUDE
        function LocationDeliveryMan() {
            var CenterandDeliveryManLocation = T12265Service.getLocationDeliveryMan($scope.obj.t12265.T_BLOOD_REQ_NO);
            CenterandDeliveryManLocation.then(function (data) {
                $scope.obj.location = JSON.parse(data);
                if ($scope.obj.location.length > 0) {
                    $scope.obj.DMLL = $scope.obj.location[0].DMLL;
                    $scope.obj.DMLLO = $scope.obj.location[0].DMLLO;
                    $scope.obj.T_CEN_LAT = $scope.obj.location[0].CML;
                    $scope.obj.T_CEN_LONG = $scope.obj.location[0].CMLO;
                    $scope.obj.SITE_CODE = $scope.obj.location[0].SITECODE;
                }
                myMap();
                document.getElementById('googleMapDiv').style.display = 'block';
            })
        }

        function FindAllDeliveryManLocation() {
            var CenterandDeliveryManLocation = T12265Service.getAllDeliveryManLocation($scope.obj.t12265.T_BLOOD_REQ_NO);
            CenterandDeliveryManLocation.then(function (data) {
                $scope.obj.location = JSON.parse(data);
                if ($scope.obj.location.length > 0) {
                    //$scope.obj.DMLL = $scope.obj.location[0].DMLL;
                    //$scope.obj.DMLLO = $scope.obj.location[0].DMLLO;
                    $scope.obj.CENTER_LAT = $scope.obj.location[0].LAT;
                    $scope.obj.CENTER_LON = $scope.obj.location[0].LON;
                }                
                if ($scope.obj.location.length > 1) {
                    nearestDeliveryManOnMap();
                } else {
                    insertIntoT91();
                }
            })
        }
        //for map start

        function myMap() {
            var myLatlng = new google.maps.LatLng($scope.obj.DMLL, $scope.obj.DMLLO);
            var mapProp = {
                center: myLatlng,
                zoom: 6,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("DeliveryManGoogleMap"), mapProp);

            dakota = { lat: $scope.obj.DMLL, lng: $scope.obj.DMLLO };
            frick = { lat: $scope.obj.T_CEN_LAT, lng: $scope.obj.T_CEN_LONG };

            mk1 = new google.maps.Marker({ position: dakota, map: map, icon: "../Images/Amb_MarkerG.png" });
            mk2 = new google.maps.Marker({ position: frick, map: map, icon: "../Images/Hospital.jpg" });

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
                        }
                    }
                });
        };
        //================== for delivery man map end ============================
        //}}        
        //for map end
        var map;
        function nearestDeliveryManOnMap() {
            var myLatlng = new google.maps.LatLng($scope.obj.CENTER_LAT, $scope.obj.CENTER_LON);
            var mapOptions = {
                center: myLatlng,
                zoom: 6,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById("DeliveryManGoogleMap"), mapOptions);
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
                    icon: "../Images/Amb_MarkerG.png"
                });
                marker.content = '<div class="infoWindowContent">' + info.desc + '</div>';
                google.maps.event.addListener(marker, 'click', function () {
                    infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.code);
                    infoWindow.open($scope.map, marker);
                });
                $scope.markers.push(marker);
            }
            for (i = 0; i < $scope.obj.location.length; i++) {
                createMarker($scope.obj.location[i]);

            }
            //for distance 
            $scope.obj.List = [];
            for (i = 1; i < $scope.obj.location.length; i++) {
                var center = { lat: $scope.obj.CENTER_LAT, lng: $scope.obj.CENTER_LON }; //$scope.obj.CENTER_LAT, $scope.obj.CENTER_LON
                var dist = { lat: $scope.obj.location[i].LAT, lng: $scope.obj.location[i].LON };
                $scope.obj.center = new google.maps.Marker({ position: center, map: map });
                $scope.obj.distination = new google.maps.Marker({ position: dist, map: map, icon: "../Images/Amb_MarkerG.png" });
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
           // if ($scope.obj.List.length > 1) {
                $scope.obj.result = $scope.obj.List.reduce(function (res, obj) {
                    return (obj.dis < res.dis) ? obj : res;
                });
           // }           
            if ($scope.obj.result != null) {
                $scope.obj.DEL_CODE = $scope.obj.result.DEL_CODE;
                var cntlat = $scope.obj.CENTER_LAT;
                var centlong = $scope.obj.CENTER_LON;
                var desLat = $scope.obj.result.LAT;
                var desLon = $scope.obj.result.LON;
                bind(cntlat, centlong, desLat, desLon)
            }
            insertIntoT91();
        }

        function bind(centerlat, centerlong, desLat, desLong) {
            const center = { lat: centerlat, lng: centerlong };
            // const options = { zoom: 6, scaleControl: true, center: center };          

            dakota = { lat: centerlat, lng: centerlong };
            frick = { lat: desLat, lng: desLong };

            mk1 = new google.maps.Marker({ position: dakota, map: map, icon: "../Images/Hospital.jpg" });
            mk2 = new google.maps.Marker({ position: frick, map: map });

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
                            $scope.obj.T_ESTIMATED_DELIVERY_TIME = directionsData.duration.text;
                            $scope.obj.T_ESTIMATED_DELIVERY_DIST = directionsData.distance.text;                            
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
        //For Clear start
        $scope.Clear = function () {
            clear();
        }
        function clear() {
            $scope.obj.t12265 = {};
            $scope.obj.t12265.T_REQ_ACCEPT_FLG = '';
            $scope.obj.checkBusy = '';
            $scope.obj.t12265.T_REQ_CANCEL_FLG = '';
            document.getElementById('googleMapDiv').style.display = 'none';
        }
        //For Clear end
        function searchNearDeliveryMan() {
            FindAllDeliveryManLocation();
            //insertIntoT91();
        }
        function insertIntoT91() {
            var canReason = 'Test';
            debugger;
            if ($scope.obj.DEL_CODE != undefined && $scope.obj.DEL_CODE != '') {
                insertT91 = T12265Service.insertT91($scope.obj.t12265.T_REQ_ID, $scope.obj.t12265.T_BLOOD_REQ_NO, $scope.obj.DEL_CODE, $scope.obj.T_ESTIMATED_DELIVERY_DIST, $scope.obj.T_ESTIMATED_DELIVERY_TIME, $scope.obj.SITE_CODE, canReason);
                insertT91.then(function(data) {
                    var testData = JSON.parse(data);
                    alert(testData == "1" ? "Cancelled and new assign" : "Data not updated!!!");
                    clear();
                });
            } else {
                updateT65Unassigned = T12265Service.updT65unassign($scope.obj.t12265.T_REQ_ID,$scope.obj.t12265.T_BLOOD_REQ_NO, $scope.obj.SITE_CODE,);
                updateT65Unassigned.then(function (data) {
                    var testData = JSON.parse(data);
                    alert(testData == "1" ? "All delivery services are busy" : "Data not updated!!!");
                    clear();
                })
            }
            
        }

        function showElement() {
            $('#lblHandOverFromCenter').delay(1000).fadeIn('slow');
            // $timeout(hideElement, 1000);
            hideElement();
        }

        function hideElement() {
            $('#lblHandOverFromCenter').delay(1000).fadeOut('slow');
            //$timeout(showElement, 1000);
            showElement();
        }
        $scope.clickReceived = function (val) {
            if ($scope.status == "Arrive") {
                //var status = $scope.handoverfromCenterFlag == "Ready to drop blood to the transfusion Hospital" ? '2' : '1'
               // if ($scope.obj.T_REQUEST_STATUS == '4') {
                updateT91ForReceived = T12265Service.updateT12091ForReceived($scope.obj.t12265.T_REQ_ID);
                    updateT91ForReceived.then(function (data) {
                        var testData = JSON.parse(data);
                        alert(testData == "1" ? "Arrived to Center Hospital" : "Data not updated!!!");
                        $scope.handoverfromCenterFlag = "Ready to drop blood";
                        document.getElementById('lblHandOverFromCenter').style.backgroundColor = 'red';
                        $scope.status = "Drop";
                        document.getElementById("btnRcv").style.background = '#fea';
                    })
                //} else {
                //    alert("Go to Hospital frist, then receive");
                //}
            } else if ($scope.status == "Drop") {
                 if ($scope.obj.T_REQUEST_STATUS == '4') {
                     updateT91ForDrop = T12265Service.updateT91T92ForDrop($scope.obj.t12265.T_REQ_ID);
                updateT91ForDrop.then(function (data) {
                    var testData = JSON.parse(data);
                    alert(testData == "1" ? "Blood drop to the Transfusion Hospital" : "Data not updated!!!");
                    $scope.handoverfromCenterFlag = "Blood Deliverd to the hospital";
                    document.getElementById('lblHandOverFromCenter').style.backgroundColor = '#848b79';
                    $scope.status = "Delivered"
                    document.getElementById("btnRcv").style.background = '#7BCCB5';
                    refresh();
                })
            } else {
                    alert("You receive blood from hospital");
                }
            }
        }
    }]);




