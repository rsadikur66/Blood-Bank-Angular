app.controller("Q12352Controller", ["$scope", "Data", "Q12352Service",
    function ($scope, Data, Q12352Service) {
        var chartDataPRBC = Q12352Service.GetChartData('PRBC');
        chartDataPRBC.then(function (data) {
            $scope.PRBCDATA = JSON.parse(data);
            $scope.ChartLabels = [];
            $scope.prbcBldQty = [];
            for (var i = 0; i < $scope.PRBCDATA.length; i++) {
                $scope.ChartLabels.push($scope.PRBCDATA[i].BLOOD_GROUP);
                $scope.prbcBldQty.push($scope.PRBCDATA[i].V_CNT);
            }
            chartPRBC();
        });
        var chartDataPLT = Q12352Service.GetChartData('PLT');
        chartDataPLT.then(function (data) {
            $scope.PLTDATA = JSON.parse(data);
            $scope.labels2 = [];
            $scope.pltBldQty = [];
            for (var i = 0; i < $scope.PLTDATA.length; i++) {
                $scope.labels2.push($scope.PLTDATA[i].BLOOD_GROUP);
                $scope.pltBldQty.push($scope.PLTDATA[i].V_CNT);
            }
            chartPLT();
        });
        var chartDataFFP = Q12352Service.GetChartData('FFP');
        chartDataFFP.then(function (data) {
            $scope.FFPDATA = JSON.parse(data);
            $scope.labels3 = [];
            $scope.ffpBldQty = [];
            for (var i = 0; i < $scope.FFPDATA.length; i++) {
                $scope.labels3.push($scope.FFPDATA[i].BLOOD_GROUP);
                $scope.ffpBldQty.push($scope.FFPDATA[i].V_CNT);
            }
            chartFFP();
        });
        function chartPRBC() {
            $scope.abpVal1 = []; $scope.bgpVal1 = []; $scope.agpVal1 = []; $scope.ogpVal1 = []; $scope.bgnVal1 = []; $scope.ognVal1 = []; $scope.abnVal1 = [];
            for (var i = 0; i < $scope.PRBCDATA.length; i++) {
                if ($scope.PRBCDATA[i].BLOOD_GROUP == 'ABP') {
                    $scope.abpVal1.push($scope.PRBCDATA[i].V_CNT);
                } else if ($scope.PRBCDATA[i].BLOOD_GROUP == 'BGP') {
                    $scope.bgpVal1.push($scope.PRBCDATA[i].V_CNT);
                } else if ($scope.PRBCDATA[i].BLOOD_GROUP == 'AGP') {
                    $scope.agpVal1.push($scope.PRBCDATA[i].V_CNT);
                } else if ($scope.PRBCDATA[i].BLOOD_GROUP == 'OGP') {
                    $scope.ogpVal1.push($scope.PRBCDATA[i].V_CNT);
                } else if ($scope.PRBCDATA[i].BLOOD_GROUP == 'BGN') {
                    $scope.bgnVal1.push($scope.PRBCDATA[i].V_CNT);
                } else if ($scope.PRBCDATA[i].BLOOD_GROUP == 'OGN') {
                    $scope.ognVal1.push($scope.PRBCDATA[i].V_CNT);
                } else if ($scope.PRBCDATA[i].BLOOD_GROUP == 'ABN') {
                    $scope.abnVal1.push($scope.PRBCDATA[i].V_CNT);
                }
            }
            var ctx = document.getElementById('myChartPRBC').getContext('2d');
            ctx.canvas.parentNode.style.height = '180px';
            ctx.canvas.parentNode.style.width = '528px';
            
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    datasets: [
                        {
                            label: 'ABP',
                            data: $scope.abpVal1,
                            fill: true,
                            backgroundColor: 'rgba(255, 199, 162, 0.2)',
                            borderColor: ['rgba(255, 152, 162, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'BGP',
                            data: $scope.bgpVal1,
                            fill: true,
                            backgroundColor: 'rgba(255, 99, 132, 0.2)',
                            borderColor: ['rgba(255, 99, 132, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'AGP',
                            data: $scope.agpVal1,
                            fill: true,
                            backgroundColor: 'rgba(54, 162, 235, 0.2)',
                            borderColor: ['rgba(54, 162, 235, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'OGP',
                            data: $scope.ogpVal1,
                            fill: true,
                            backgroundColor: 'rgba(255, 206, 86, 0.2)',
                            borderColor: ['rgba(255, 206, 86, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'BGN',
                            data: $scope.bgnVal1,
                            fill: true,
                            backgroundColor: 'rgba(75, 192, 192, 0.2)',
                            borderColor: ['rgba(75, 192, 192, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'OGN',
                            data: $scope.ognVal1,
                            fill: true,
                            backgroundColor: 'rgba(153, 102, 255, 0.2)',
                            borderColor: ['rgba(153, 102, 255, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'ABN',
                            data: $scope.abnVal1,
                            fill: true,
                            backgroundColor: 'rgba(255, 159, 64, 0.2)',
                            borderColor: ['rgba(255, 159, 64, 1)'],
                            borderWidth: 1
                        }
                    ]
                },
                options: {
                    events: ['null'],
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    },
                    legend: {
                        position: 'right'
                    },
                    title: {
                        display: true,
                        text: 'PRBC',
                        padding: 25
                    },
                    animation: {
                        duration: 1,
                        onComplete: function () {
                            var chartInstance = this.chart,
                                ctx = chartInstance.ctx;
                            ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
                            ctx.textAlign = 'center';
                            ctx.textBaseline = 'bottom';
                            this.data.datasets.forEach(function (dataset, i) {
                                var meta = chartInstance.controller.getDatasetMeta(i);
                                meta.data.forEach(function (bar, index) {
                                    
                                    var data = dataset.data[index];
                                    ctx.fillText(data, bar._model.x, bar._model.y - 5);
                                    ctx.fillText(dataset.label, bar._model.x, 260);
                                });
                            });
                        }
                    }
                }
            });
        }
        function chartPLT() {
            $scope.abpVal = []; $scope.bgpVal = []; $scope.agpVal = []; $scope.ogpVal = []; $scope.bgnVal = []; $scope.ognVal = []; $scope.abnVal = [];
            for (var i = 0; i < $scope.PLTDATA.length; i++) {
                if ($scope.PLTDATA[i].BLOOD_GROUP == 'ABP') {
                    $scope.abpVal.push($scope.PLTDATA[i].V_CNT);
                } else if ($scope.PLTDATA[i].BLOOD_GROUP == 'BGP') {
                    $scope.bgpVal.push($scope.PLTDATA[i].V_CNT);
                } else if ($scope.PLTDATA[i].BLOOD_GROUP == 'AGP') {
                    $scope.agpVal.push($scope.PLTDATA[i].V_CNT);
                } else if ($scope.PLTDATA[i].BLOOD_GROUP == 'OGP') {
                    $scope.ogpVal.push($scope.PLTDATA[i].V_CNT);
                } else if ($scope.PLTDATA[i].BLOOD_GROUP == 'BGN') {
                    $scope.bgnVal.push($scope.PLTDATA[i].V_CNT);
                } else if ($scope.PLTDATA[i].BLOOD_GROUP == 'OGN') {
                    $scope.ognVal.push($scope.PLTDATA[i].V_CNT);
                } else if ($scope.PLTDATA[i].BLOOD_GROUP == 'ABN') {
                    $scope.abnVal.push($scope.PLTDATA[i].V_CNT);
                }
            }
            var ctx1 = document.getElementById('myChartPLT').getContext('2d');
            ctx1.canvas.parentNode.style.height = '180px';
            ctx1.canvas.parentNode.style.width = '528px';
            var myChart1 = new Chart(ctx1, {
                type: 'bar',
                data: {
                    datasets: [
                        {
                            label: 'ABP',
                            data: $scope.abpVal,
                            fill: true,
                            backgroundColor: 'rgba(255, 199, 162, 0.2)',
                            borderColor: ['rgba(255, 152, 162, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'BGP',
                            data: $scope.bgpVal,
                            fill: true,
                            backgroundColor: 'rgba(255, 99, 132, 0.2)',
                            borderColor: ['rgba(255, 99, 132, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'AGP',
                            data: $scope.agpVal,
                            fill: true,
                            backgroundColor: 'rgba(54, 162, 235, 0.2)',
                            borderColor: ['rgba(54, 162, 235, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'OGP',
                            data: $scope.ogpVal,
                            fill: true,
                            backgroundColor: 'rgba(255, 206, 86, 0.2)',
                            borderColor: ['rgba(255, 206, 86, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'BGN',
                            data: $scope.bgnVal,
                            fill: true,
                            backgroundColor: 'rgba(75, 192, 192, 0.2)',
                            borderColor: ['rgba(75, 192, 192, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'OGN',
                            data: $scope.ognVal,
                            fill: true,
                            backgroundColor: 'rgba(153, 102, 255, 0.2)',
                            borderColor: ['rgba(153, 102, 255, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'ABN',
                            data: $scope.abnVal,
                            fill: true,
                            backgroundColor: 'rgba(255, 159, 64, 0.2)',
                            borderColor: ['rgba(255, 159, 64, 1)'],
                            borderWidth: 1
                        }
                    ]
                },
                options: {
                    events: ['null'],
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    },
                    legend: {
                        position:'right'
                    },
                    title: {
                        display: true,
                        text: 'PLT',
                        padding: 25
                    },
                    animation: {
                        duration: 1,
                        onComplete: function () {
                            var chartInstance = this.chart,
                                ctx = chartInstance.ctx;
                            ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
                            ctx.textAlign = 'center';
                            ctx.textBaseline = 'bottom';
                            this.data.datasets.forEach(function (dataset, i) {
                                var meta = chartInstance.controller.getDatasetMeta(i);
                                meta.data.forEach(function (bar, index) {
                                    
                                    var data = dataset.data[index];
                                    ctx.fillText(data, bar._model.x, bar._model.y - 5);
                                    ctx.fillText(dataset.label, bar._model.x, 260);
                                });
                            });
                        }
                    }
                }
            });
        }
        function chartFFP() {
            $scope.abpVal2 = []; $scope.bgpVal2 = []; $scope.agpVal2 = []; $scope.ogpVal2 = []; $scope.bgnVal2 = []; $scope.ognVal2 = []; $scope.abnVal2 = [];
            for (var i = 0; i < $scope.FFPDATA.length; i++) {
                if ($scope.FFPDATA[i].BLOOD_GROUP == 'ABP') {
                    $scope.abpVal2.push($scope.FFPDATA[i].V_CNT);
                } else if ($scope.FFPDATA[i].BLOOD_GROUP == 'BGP') {
                    $scope.bgpVal2.push($scope.FFPDATA[i].V_CNT);
                } else if ($scope.FFPDATA[i].BLOOD_GROUP == 'AGP') {
                    $scope.agpVal2.push($scope.FFPDATA[i].V_CNT);
                } else if ($scope.FFPDATA[i].BLOOD_GROUP == 'OGP') {
                    $scope.ogpVal2.push($scope.FFPDATA[i].V_CNT);
                } else if ($scope.FFPDATA[i].BLOOD_GROUP == 'BGN') {
                    $scope.bgnVal2.push($scope.FFPDATA[i].V_CNT);
                } else if ($scope.FFPDATA[i].BLOOD_GROUP == 'OGN') {
                    $scope.ognVal2.push($scope.FFPDATA[i].V_CNT);
                } else if ($scope.FFPDATA[i].BLOOD_GROUP == 'ABN') {
                    $scope.abnVal2.push($scope.FFPDATA[i].V_CNT);
                }
            }
            var ctx2 = document.getElementById('myChartFFP').getContext('2d');
            ctx2.canvas.parentNode.style.height = '180px';
            ctx2.canvas.parentNode.style.width = '528px';
            var myChart2 = new Chart(ctx2, {
                type: 'bar',
                data: {
                    datasets: [
                        {
                            label: 'ABP',
                            data: $scope.abpVal2,
                            fill: true,
                            backgroundColor: 'rgba(255, 199, 162, 0.2)',
                            borderColor: ['rgba(255, 152, 162, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'BGP',
                            data: $scope.bgpVal2,
                            fill: true,
                            backgroundColor: 'rgba(255, 99, 132, 0.2)',
                            borderColor: ['rgba(255, 99, 132, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'AGP',
                            data: $scope.agpVal2,
                            fill: true,
                            backgroundColor: 'rgba(54, 162, 235, 0.2)',
                            borderColor: ['rgba(54, 162, 235, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'OGP',
                            data: $scope.ogpVal2,
                            fill: true,
                            backgroundColor: 'rgba(255, 206, 86, 0.2)',
                            borderColor: ['rgba(255, 206, 86, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'BGN',
                            data: $scope.bgnVal2,
                            fill: true,
                            backgroundColor: 'rgba(75, 192, 192, 0.2)',
                            borderColor: ['rgba(75, 192, 192, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'OGN',
                            data: $scope.ognVal2,
                            fill: true,
                            backgroundColor: 'rgba(153, 102, 255, 0.2)',
                            borderColor: ['rgba(153, 102, 255, 1)'],
                            borderWidth: 1
                        },
                        {
                            label: 'ABN',
                            data: $scope.abnVal2,
                            fill: true,
                            backgroundColor: 'rgba(255, 159, 64, 0.2)',
                            borderColor: ['rgba(255, 159, 64, 1)'],
                            borderWidth: 1
                        }
                    ]
                },
                options: {
                    events: ['null'],
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    },
                    legend: {
                        position: 'right'
                    },
                    title: {
                        display: true,
                        text: 'FFP',
                        padding: 25
                    },
                    animation: {
                        duration: 1,
                        onComplete: function () {
                            var chartInstance = this.chart,
                                ctx = chartInstance.ctx;
                            ctx.font = Chart.helpers.fontString(Chart.defaults.global.defaultFontSize, Chart.defaults.global.defaultFontStyle, Chart.defaults.global.defaultFontFamily);
                            ctx.textAlign = 'center';
                            ctx.textBaseline = 'bottom';
                            this.data.datasets.forEach(function (dataset, i) {
                                var meta = chartInstance.controller.getDatasetMeta(i);
                                meta.data.forEach(function (bar, index) {
                                    
                                    var data = dataset.data[index];
                                    ctx.fillText(data, bar._model.x, bar._model.y - 5);
                                    ctx.fillText(dataset.label, bar._model.x, 260);
                                });
                            });
                        }
                    }
                }
            });
        }
    }]);