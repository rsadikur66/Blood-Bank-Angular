
app.controller("Q12025Controller", ["$scope", "Q12025Service", "uiGridConstants", "DTOptionsBuilder", "DTColumnBuilder", "Data", "$window","$filter",
       
    function (scope, Q12025Service, uiGridConstants, DTOptionsBuilder, DTColumnBuilder, Data, $window, $filter) {
            scope.obj = {};
            scope.obj = Data;
            scope.obj.T12025 = {};
        //-------------------Popup start-----------------------------
        function siteData() {
            var site = Q12025Service.getSiteData();
            site.then(function(sit) {
                var jsonData = JSON.parse(sit);
                scope.obj.SiteList = jsonData;
            });
        }
        function bloodGroup() {
            var blood = Q12025Service.getBloodGroupData();
            blood.then(function (bl) {
                var jsonData = JSON.parse(bl);
                scope.obj.BloodList = jsonData;
            });
        }
        function product() {
            var pro = Q12025Service.getProductData();
            pro.then(function (pr) {
                var jsonData = JSON.parse(pr);
                scope.obj.ProductList = jsonData;
            });
        }
        scope.ClosePopup = function (popup) {
            document.getElementById(popup).style.display = "none";
        }
        scope.ShowSitePopup = function (popup) {
            siteData();
            document.getElementById(popup).style.display = "block";
        }
        
        scope.ShowBloodGrouoPopUp = function (popup) {
            bloodGroup();
            document.getElementById(popup).style.display = "block";
        }
        scope.ShowProductPopup = function (popup) {
            product();
            document.getElementById(popup).style.display = "block";
        }
        scope.key_press = function (event, value) {
            if (event.keyCode ===120) {
                if (value === 'Site') {
                    siteData();
                    document.getElementById('SitePopUp').style.display = "block";
                }
                else if (value === 'BloodGrouo') {
                    bloodGroup();
                    document.getElementById('BloodGrouoPopUp').style.display = "block";
                }
                else if (value === 'Product') {
                    product();
                    document.getElementById('ProductPopUp').style.display = "block";
                }
            }
            
        }

        scope.setClickedRow = function(ind,data,popup) {
            if (popup === 'ProductPopUp') {
                scope.obj.T12025.T_PRODUCT_CODE = data.T_PRODUCT_CODE;
                scope.obj.T12025.PRODUCT_NAME = data.PRODUCT_NAME;

                document.getElementById(popup).style.display = "none";
            }
            else if (popup === 'BloodGrouoPopUp') {
                scope.obj.T12025.BLD_CODE = data.BLD_CODE;
                scope.obj.T12025.T_BLOOD_NAME = data.T_BLOOD_NAME;

                document.getElementById(popup).style.display = "none";
            }
            else if (popup === 'SitePopUp') {
                scope.obj.T12025.T_SITE_CODE = data.T_SITE_CODE;
                scope.obj.T12025.SITE_NAME = data.SITE_NAME;

                document.getElementById(popup).style.display = "none";
            }
        }
        //-------------------Popup End-----------------------------
        scope.Next_Click = function () {
            getAllData();
        }

        function getAllData() {
            if (scope.obj.T12025.DonationTimeFrom !== undefined) {
                var donTiFrom = scope.dateParse(scope.obj.T12025.DonationTimeFrom, "/");
            }
            if (scope.obj.T12025.DonationTimeTo !== undefined) {
                var donTiTo = scope.dateParse(scope.obj.T12025.DonationTimeTo, "/");
            }
            var siteCode = scope.obj.T12025.T_SITE_CODE;
            var bloodGrp = scope.obj.T12025.BLD_CODE;
            var product = scope.obj.T12025.T_PRODUCT_CODE;

            var stock = Q12025Service.getStocktData(donTiFrom, donTiTo, siteCode, bloodGrp, product);
            stock.then(function (st) {
                var jsonData = JSON.parse(st);
                scope.obj.StockList = jsonData;
            });
        }
        scope.Clear_Click = function() {
            scope.obj.T12025 = {};
            getAllData();
        }
        scope.DonTimFrom_Click = function() {
            scope.obj.T12025.DonationTimeTo = $filter('date')(new Date(), "dd/MM/yyyy");
            
        }
        scope.Print_Click = function () {
            var siteCode = '';
            var bloodGrp = '';
            var product = '';
            var donTiFrom = '';
            var donTiTo = '';
            if (scope.obj.T12025.DonationTimeFrom !== undefined) {
                 donTiFrom = scope.dateParse(scope.obj.T12025.DonationTimeFrom, "/");
            }
            if (scope.obj.T12025.DonationTimeTo !== undefined) {
                donTiTo = scope.dateParse(scope.obj.T12025.DonationTimeTo, "/");
            }
             siteCode = scope.obj.T12025.T_SITE_CODE;
             bloodGrp = scope.obj.T12025.BLD_CODE;
            product = scope.obj.T12025.T_PRODUCT_CODE;
            if (siteCode === undefined) { siteCode = ''; }
            if (bloodGrp === undefined) { bloodGrp = '';}
            if (product === undefined) { product = '';}
            if (donTiFrom === undefined) { donTiFrom = '';}
            if (donTiTo === undefined) { donTiTo = '';}

            $window.open("../R12025/GetReport?donTiFrom=" + donTiFrom + "&&donTiTo=" + donTiTo + "&&siteCode=" + siteCode + "&&bloodGrp=" + bloodGrp + "&&product=" + product , "popup", "width=1200,height=600,left=50,top=50");
        }
    }]);
