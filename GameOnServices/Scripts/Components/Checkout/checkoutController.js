(function () {
    "use strict";
    angular.module('gameRentalApp').controller('CheckoutController', CheckoutController);

    function CheckoutController($scope, $http, $window) {       
        var self = this;      
        self.checkoutGamesList = [];
        self.totalRent = 0;
        self.apiRoute = "/api/checkout/";
        
        self.initialize = function () {
            self.message = 'Checkout';              
            self.getCartDetails();
        };

        self.getCartDetails = function () {            
            var action = "GetCartDetails";
            var url = $window.appGlobals.rootUrl + self.apiRoute + action;

            return $http.get(url).then(self.parseCartDetailsResponse, self.errorResponse);

        };

        self.getCheckoutGamesList = function () {            
            return self.checkoutGamesList;
        };

        self.makePayment = function () {
            var action = "makeAPayment";
            var url = $window.appGlobals.rootUrl + self.apiRoute + action;
            
            return $http.post(url).then(self.parsePaymentResponse, self.errorResponse);
        };

        self.removeMovie = function (gameId) {
            var action = "Remove";
            var url = $window.appGlobals.rootUrl + self.apiRoute + action + "/" + gameId;

            return $http.get(url).then(self.parseCartDetailsResponse, self.errorResponse);
        };

        self.parseCartDetailsResponse = function (response) {
            var listData = response.data;
            self.checkoutGamesList = listData.items;
            self.totalRent = 0;
            if (listData.items == null || listData.items.length == 0) {
                self.redirect();
            } else {
                for (var itemIndx = 0; itemIndx < listData.items.length; itemIndx++) {
                    self.totalRent += listData.items[itemIndx].rent;
                }
            }        
           
        };     

        self.parsePaymentResponse = function (response) {
            self.checkoutGamesList = [];
            self.totalRent = 0;      
            alert("Payment Successfull! Redirecting to search...")
            self.redirect();
        };            

        self.errorResponse = function (response) {
            console.log("message: " + response.data.message + "exceptionMessage: " + response.data.exceptionMessage + " status: " + response.status + " header: " + response.header);
        };
        self.redirect = function () {

            $window.location.href = $window.appGlobals.rootUrl + "/search";
        };

      
        self.initialize();
    }

})();