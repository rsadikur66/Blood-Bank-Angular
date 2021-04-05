app.service("T12204Service", ["$http", "vrtlDirr", function ($http, vrtlDirr) {
            var dataSvc = {
                getLebalData: getLebalData,
                getCompStatusData: getCompStatusData,
                getBedUsedData: getBedUsedData,
                getPatDetails: getPatDetails,
                getReson_AcStatus: getReson_AcStatus,
                getBed: getBed,
                getDiscurtReason: getDiscurtReason,
                getbodyMermt: getbodyMermt,
                getQuestion: getQuestion,
                getImages: getImages,
                getUnit_SegmNo: getUnit_SegmNo,
                getpin: getpin,
                SaveData: SaveData,
                getMaxBidStoreId: getMaxBidStoreId,
                getReport: getReport,
                getComment: getComment,
                update: update,
                getComntT12328: getComntT12328,
                showDataFromT12022: showDataFromT12022
               // LabelData: LabelData
            };
            return dataSvc;
    function getLebalData(formcode, language) {
        try {
            var url = vrtlDirr + '/Account/GetLabelText';
            return $http({
                url: url,
                method: "POST",
                data: { formcode: formcode, language: language }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getCompStatusData(d) {
            try {
                var url = vrtlDirr + '/T12204/GatCompStatusData';
                return $http({
                    url: url,
                    method: "POST",
                   // data: {}
                    data: { d: d}
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
    }
    function getBedUsedData(id) {
            try {
                var url = vrtlDirr + '/T12204/GetBedUsedData';
                return $http({
                    url: url,
                    method: "POST",
                  //  data: {}
                    data: { id: id }
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
    }
    function getPatDetails(patNo,patId) {
            try {
                var url = vrtlDirr + '/T12204/GetPatDetails';
                return $http({
                    url: url,
                    method: "POST",
                    //data: {}
                    data: { patNo: patNo, patId: patId }
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
    }
    function getReson_AcStatus(bagWet) {
            try {
                var url = vrtlDirr + '/T12204/GetReson_AcStatus';
                return $http({
                    url: url,
                    method: "POST",
                    //data: {}
                    data: { bagWet: bagWet }
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
    }
    function getBed() {
            try {
                var url = vrtlDirr + '/T12204/GetBed';
                return $http({
                    url: url,
                    method: "POST",
                    data: {}
                   // data: { bagWet: bagWet }
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
    }
    function getDiscurtReason() {
            try {
                var url = vrtlDirr + '/T12204/GetDiscurtReason';
                return $http({
                    url: url,
                    method: "POST",
                    data : {}
                    //data: { formcode: formcode, language: language }
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
    }
    function getbodyMermt(pat,epst) {
            try {
                var url = vrtlDirr + '/T12204/GetbodyMermt';
                return $http({
                    url: url,
                    method: "POST",
                   // data: {}
                    data: { pat: pat, epst: epst }
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
    }
    function getQuestion(pat, epst) {
            try {
                var url = vrtlDirr + '/T12204/GetQuestion';
                return $http({
                    url: url,
                    method: "POST",
                    // data: {}
                    data: { pat: pat, epst: epst }
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
        }
    function getImages(pat, epst) {
            try {
                var url = vrtlDirr + '/T12204/GetImages';
                return $http({
                    url: url,
                    method: "POST",
                    // data: {}
                    data: { pat: pat, epst: epst }
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
        }
    function getUnit_SegmNo() {
            try {
                var url = vrtlDirr + '/T12204/getUnit_SegmNo';
                return $http({
                    url: url,
                    method: "POST",
                     data: {}
                   // data: { pat: pat, epst: epst }
                }).then(function (results) {
                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
    }
    function getpin() {
        try {
            var url = vrtlDirr + '/T12204/Getpin';
            return $http({
                url: url,
                method: "POST",
                data: {}
               // data: { pNo: pNo, eNo: eNo }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function SaveData(t12022) {
        try {
            var url = vrtlDirr + '/T12204/SaveData';
            return $http({
                url: url,
                method: "POST",
                // data: {}
                data: { t12022: t12022 }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getMaxBidStoreId() {
        try {
            var url = vrtlDirr + '/T12204/GetMaxBidStoreId';
            return $http({
                url: url,
                method: "POST",
                 data: {}
               // data: { t12022: t12022 }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getReport(pat,ept) {
        try {
            var url = vrtlDirr + '/Report12204/GetReport';
            return $http({
                url: url,
                method: "POST",
                //data: {}
                data: { pat: pat, ept: ept}
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getComment(phel) {
        try {
            var url = vrtlDirr + '/T12204/GetComment';
            return $http({
                url: url,
                method: "POST",
                //data: {}
                data: { phel: phel }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function update(t12022) {
        try {
            var url = vrtlDirr + '/T12204/Update';
            return $http({
                url: url,
                method: "POST",
                //data: {}
                data: { t12022: t12022 }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function getComntT12328(ple) {
        try {
            var url = vrtlDirr + '/T12204/GetComntT12328';
            return $http({
                url: url,
                method: "POST",
                //data: {}
                data: { ple: ple }
            }).then(function (results) {
                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
    function showDataFromT12022(patNo, epsort) {
        try {
            var url = vrtlDirr + '/T12204/showDataFromT12022';
            return $http({
                url: url,
                method: "POST",
                //data: {}
                data: { patNo:patNo, epsort:epsort }
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