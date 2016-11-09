// moduler
var personApp = angular.module('personApp', []);

personApp.controller('personController', function ($scope) {
    $scope.firstName = "Pablo";
    $scope.lastName = "Tôndolo";
});