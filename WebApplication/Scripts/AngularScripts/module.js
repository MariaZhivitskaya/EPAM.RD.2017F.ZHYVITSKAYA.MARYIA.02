//angular.module('albumsApp', ['ngRoute']).controller('IndexController',
//[
//    '$scope', 'dataCenter', '$http', function($scope, dataCenter, $http) {
//        $rootScope.CurrentUser = "fjfjfj";

//        $scope.Albums = dataCenter.GetAll();

//        $scope.SelectedAlbum = $scope.Albums[0];

//        $scope.RemoveImg = function(index) {
//            dataCenter.RemoveImage($scope.SelectedAlbum, index);
//        }

//        $scope.Description;

//        $scope.GetDescription = function() {
//            $http.get('Home/GetDescription')
//                .then(function(response) {
//                    $scope.Description = response.data;
//                });
//        }
//    }
//]);
var module = angular.module('albumsApp', ['ngRoute']);

module.controller('LoginController',
[
    '$scope', '$rootScope', 'dataCenter', '$http', function ($scope, $rootScope, dataCenter, $http) {
        $scope.user = {};

        $scope.login = function () {
            dataCenter.SendLoginData($scope.user).then(function (response) {
                if (response.data === "False") {
                    $("#alertModal").modal('show');
                    $scope.response = "Sorry, an error occured...";
                }
                else {
                    window.location.href = "/Angular/Index";
                }
            });
        }

        $scope.alertmsg = function () {
            $("#alertModal").modal('hide');
        };

        $scope.logoff = function () {
            dataCenter.LogOff().then(function (response) {
                window.location.href = "/Angular/Login";
            });
        };
    }
]);

module.controller('RegisterController',
[
    '$scope', '$rootScope', 'dataCenter', '$http', function ($scope, $rootScope, dataCenter, $http) {
        $scope.user = {};
        $scope.confirmPwd = null;

        $scope.register = function () {
            if ($scope.user.password !== $scope.confirmPwd) {
                $("#alertModal").modal('show');
                $scope.response = "Passwords don't match!";
            } else {
                dataCenter.SendRegisterData($rootScope.user).then(function (response) {
                    if (response.data === "False") {
                        $("#alertModal").modal('show');
                        $scope.response = "Sorry, an error occured...";
                    } else {
                        window.location.href = "/Angular/Index";
                    }
                });
            }

            $scope.alertmsg = function () {
                $("#alertModal").modal('hide');
            };
        }
    }
]);

module.controller('ViewAllController',
[
    '$scope', '$rootScope', 'dataCenter', '$http', function ($scope, $rootScope, dataCenter, $http) {
        $scope.albums = [];
        $scope.selectedAlbum = $scope.albums[0];
        $scope.imgs = [];

        dataCenter.GetAllAlbums().then(function (response) {
            $scope.albums = response.data;
            $scope.selectedAlbum = $scope.albums[0];
            if ($scope.albums.length !== 0) {
                $scope.imgs = $scope.changedValue();
            }
        });

        $scope.changedValue = function () {
            dataCenter.GetImgs($scope.selectedAlbum).then(function (response) {
                $scope.imgs = response.data;
            });
        }

        $scope.correctDate = function (badDate) {
            return $filter('date')(badDate, "dd/MM/yyyy");
        }
    }
]);

module.controller('IndexController',
[
    '$scope', '$rootScope', 'dataCenter', '$http', function ($scope, $rootScope, dataCenter, $http) {
        $scope.description = null;
        $scope.hideBth = true;
        $scope.userRole = null;

        dataCenter.GetSiteDescription().then(function (response) {
            $scope.description = response.data;
        });

        dataCenter.GetUserRole().then(function (response) {
            $scope.userRole = response.data;
            if ($scope.userRole === 1) {
                $scope.hideBth = false;
            }
        });

        $scope.updateText = function () {
            dataCenter.SendSiteDescription($scope.description);

            $("#alertModal").modal('show');
            $scope.response = "Site description successfully updated!";

            $scope.alertmsg = function () {
                $("#alertModal").modal('hide');
            };
        };
    }
]);

module.controller('AddAlbumController',
[
    '$scope', '$rootScope', 'dataCenter', '$http', function ($scope, $rootScope, dataCenter, $http) {
        $scope.albumName = null;

        $scope.addAlbum = function () {
            if ($scope.albumName === "") {
                $("#alertModal").modal('show');
                $scope.response = "Please, add an album name!";
            } else {
                dataCenter.AddAlbum($scope.albumName).then(function (response) {
                    if (response.data === "False") {
                        $("#alertModal").modal('show');
                        $scope.response = "Sorry, an error occured...";
                    } else {
                        $("#alertModal").modal('show');
                        $scope.response = "Success!";
                        window.location.href = "/Angular/ViewAll";
                    }
                });
            }

            $scope.alertmsg = function () {
                $("#alertModal").modal('hide');
            };
        }
    }
]);

module.controller('AddImageController',
[
    '$scope', '$rootScope', 'dataCenter', '$http', function ($scope, $rootScope, dataCenter, $http) {
        $scope.albums = [];
        $scope.selectedAlbum = $scope.albums[0];
        $scope.name = null;
        $scope.description = null;

        dataCenter.GetAllAlbums().then(function (response) {
            $scope.albums = response.data;
            $scope.selectedAlbum = $scope.albums[0];
        });

        $scope.addImage = function () {
            if ($scope.name === "") {
                $("#alertModal").modal('show');
                $scope.response = "Please, add a name!";
            } else {
                var reader = new FileReader();
                var imgFileInput = document.getElementById('file');
                var imgFile = imgFileInput.files[0];
                reader.readAsDataURL(imgFile);

                reader.onload = function (e) {
                    $scope.$apply(function () {
                        var data = reader.result;
                        if (imgFile.type !== "") {
                            dataCenter.AddImage(data, imgFile.type, $scope.selectedAlbum, $scope.name,
                                $scope.description).then(function (response) {
                                    if (response.data === "False") {
                                        $("#alertModal").modal('show');
                                        $scope.response = "Sorry, an error occured...";
                                    } else {
                                        $("#alertModal").modal('show');
                                        $scope.response = "Success!";
                                        window.location.href = "/Angular/ViewAll";
                                    }
                                });
                        } else {
                            var fileFormat = "image/" + imgFile.name.substr(imgFile.name.lastIndexOf('.') + 1);
                            dataCenter.AddImage(data, fileFormat, $scope.selectedAlbum, $scope.name,
                                $scope.description).then(function (response) {
                                    if (response.data === "False") {
                                        $("#alertModal").modal('show');
                                        $scope.response = "Sorry, an error occured...";
                                    } else {
                                        $("#alertModal").modal('show');
                                        $scope.response = "Success!";
                                        window.location.href = "/Angular/ViewAll";
                                    }
                                });
                        }
                    });
                };

                $scope.alertmsg = function () {
                    $("#alertModal").modal('hide');
                };
            }
        }
    }
]);

module.filter('jsonDate', ['$filter', function ($filter) {
    return function (input, format) {
        return (input)
               ? $filter('date')(parseInt(input.substr(6)), format)
               : '';
    };
}]);

module.service('dataCenter', [
    '$http', function ($http) {
        return {

            SendLoginData: function (user) {
                var response = $http({
                    method: "post",
                    url: 'http://localhost:64850/Account/Login?email=' + user.email + '&password=' + user.password
                });
                return response;
            },

            LogOff: function () {
                var response = $http({
                    url: 'http://localhost:64850/Account/Logoff'
                });
                return response;
            },

            SendRegisterData: function (user) {
                var response = $http({
                    method: "post",
                    url: 'http://localhost:64850/Account/Register?email=' + user.email + '&password=' + user.password
                });
                return response;
            },

            GetAllAlbums: function () {
                var response = $http({
                    method: "get",
                    url: 'http://localhost:64850/ViewAll/GetAlbums'
                });
                return response;
            },

            AddAlbum: function (albumName) {
                var response = $http({
                    method: "post",
                    url: 'http://localhost:64850/Add/AddAlbum?albumName=' + albumName
                });
                return response;
            },

            AddImage: function (image, extension, selectedAlbum, name, description) {
                var response = $http({
                    method: "post",
                    url: 'http://localhost:64850/Add/AddImage',
                    async: false,
                    data: {
                        image: image,
                        extension: extension,
                        selectedAlbum: selectedAlbum,
                        name: name,
                        description: description
                    }
                });
                return response;
            },

            GetImgs: function (selectedAlbum) {
                var response = $http({
                    method: "get",
                    url: 'http://localhost:64850/ViewAll/GetImgs?selectedAlbum=' + selectedAlbum
                });
                return response;
            },

            GetSiteDescription: function () {
                var response = $http({
                    method: "get",
                    url: 'http://localhost:64850/Index/GetDescription'
                });
                return response;
            },

            GetUserRole: function () {
                var response = $http({
                    method: "get",
                    url: 'http://localhost:64850/Index/GetRole'
                });
                return response;
            },

            SendSiteDescription: function (text) {
                $http({
                    method: "post",
                    url: 'http://localhost:64850/Index/SetText?text=' + text
                });
            }
        }
    }
]);

module.config(['$locationProvider', '$routeProvider',
    function ($locationProvider, $routeProvider) {
        $routeProvider
            .when('/Angular/Index', {
                templateUrl: "Views/Angular/Index.html",
                controller: "IndexController"
            })
            .when('/Angular/Login', {
                templateUrl: "Views/Angular/Login.html",
                controller: "LoginController"
            })
            .when('/Angular/Register', {
                templateUrl: "Views/Angular/Register.html",
                controller: "RegisterController"
            })
             .when('/Angular/AddAlbum', {
                 templateUrl: "Views/Angular/AddAlbum.html",
                 controller: "AddAlbumController"
             })
            .when('/Angular/AddImage', {
                templateUrl: "Views/Angular/AddImage.html",
                controller: "AddImageController"
            })
            .when('/Angular/ViewAll', {
                templateUrl: "Views/Angular/ViewAll.html",
                controller: "ViewAllController"
            });

        //.when('/', {
        //    templateUrl: "Views/Angular/ViewAll.html",
        //    controller: "IndexController"
        //})
        //.otherwise({
        //    redirectTo: '/Angular/ViewAll'
        //});
        $locationProvider.html5Mode(true);
    }
]);
//.directive('myUser', [
//    function() {
//        return {
//            restrict: 'E',
//            replace:
//                true,
//            templateUrl:
//                '/Views/Angular/ViewAll.html',
//            scope :{ user: '=' },
//        }
//    }
//]);