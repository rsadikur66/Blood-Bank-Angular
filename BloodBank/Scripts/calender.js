app.directive("ngDatepicker", ["$document", function (a) {
    var b = function (d, c) {
        d.format = c.format || "YYYY-MM-DD";
        d.viewFormat = c.viewFormat || "Do MMMM YYYY";
        d.locale = c.locale || "en";
        d.firstWeekDaySunday = d.$eval(c.firstWeekDaySunday) || false;
        d.placeholder = c.placeholder || "";
    };
    return {
        restrict: "EA",
        require: "?ngModel",
        scope: {},
        link: function (g, e, d, j) {
            b(g, d);
            g.calendarOpened = false;
            g.days = [];
            g.dayNames = [];
            g.viewValue = null;
            g.dateValue = null;
            moment.locale(g.locale);
            var c = moment();
            var f = function (l) {
                var k = l.endOf("month").date(),
                    q = l.month(),
                    p = l.year(),
                    r = 1;
                var o = g.firstWeekDaySunday === true ? l.set("date", 2).day() : l.set("date", 1).day();
                if (o !== 1) {
                    r -= o - 1;
                }
                g.dateValue = l.format("MMMM YYYY");
                g.days = [];
                for (var m = r; m <= k; m += 1) {
                    if (m > 0) {
                        g.days.push({
                            day: m,
                            month: q + 1,
                            year: p,
                            enabled: true
                        });
                    } else {
                        g.days.push({
                            day: null,
                            month: null,
                            year: null,
                            enabled: false
                        });
                    }
                }
            };
            var h = function () {
                var k = g.firstWeekDaySunday === true ? moment("2015-06-07") : moment("2015-06-01");
                for (var l = 0; l < 7; l += 1) {
                    g.dayNames.push(k.format("ddd"));
                    k.add("1", "d");
                }
            };
            h();
            g.showCalendar = function () {
                g.calendarOpened = true;
                f(c);

            };
            g.closeCalendar = function () {
                g.calendarOpened = false;
            };
            g.prevYear = function () {
                c.subtract(1, "Y");
                f(c);

            };
            g.prevMonth = function () {
                c.subtract(1, "M");
                f(c);

            };
            g.nextMonth = function () {
                c.add(1, "M");
                f(c);
            };
            g.nextYear = function () {
                c.add(1, "Y");
                f(c);

            };
            g.selectDate = function (m, k) {
                m.preventDefault();
                var l = moment(k.day + "." + k.month + "." + k.year, "DD.MM.YYYY");
                j.$setViewValue(l.format(g.format));
                g.viewValue = l.format(g.viewFormat);
                g.closeCalendar();

            };
            var i = ["ng-datepicker", "ng-datepicker-input"];
            if (d.id !== undefined) {
                i.push(d.id);
            }
            a.on("click", function (m) {
                if (!g.calendarOpened) {
                    return;
                }
                var l = 0,
                    k;
                if (!m.target) {
                    return;
                }
                for (k = m.target; k; k = k.parentNode) {
                    var o = k.id;
                    var n = k.className;
                    if (o !== undefined) {
                        for (l = 0; l < i.length; l += 1) {
                            if (o.indexOf(i[l]) > -1 || n.indexOf(i[l]) > -1) {
                                return;
                            }
                        }
                    }
                }
                g.closeCalendar();
                g.$apply();
            });
            j.$render = function () {
                var k = j.$viewValue;
                if (k !== undefined) {
                    g.viewValue = moment(k).format(d.viewFormat);
                    g.dateValue = k;
                }
            }
        },
        template: '<div><input type="text" ng-focus="showCalendar()" ng-value="viewValue" class="ng-datepicker-input" placeholder="{{ placeholder }}"></div><div class="ng-datepicker" ng-show="calendarOpened">  <div class="controls">    <div class="left">      <i class="fa fa-backward prev-year-btn" ng-click="prevYear()"></i>      <i class="fa fa-angle-left prev-month-btn" ng-click="prevMonth()"></i>    </div>    <span class="date" ng-bind="dateValue"></span>    <div class="right">      <i class="fa fa-angle-right next-month-btn" ng-click="nextMonth()"></i>      <i class="fa fa-forward next-year-btn" ng-click="nextYear()"></i>    </div>  </div>  <div class="day-names">    <span ng-repeat="dn in dayNames">      <span>{{ dn }}</span>    </span>  </div>  <div class="calendar">    <span ng-repeat="d in days">      <span class="day" ng-click="selectDate($event, d)" ng-class="{disabled: !d.enabled}">{{ d.day }}</span>    </span>  </div></div>'
    }
}]);