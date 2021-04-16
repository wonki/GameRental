(function () {
    "use strict";
    angular.module('gameRentalApp').controller('SearchController', SearchController);

    function SearchController($scope, $http, $window) {
       
        var self = this;
        
        self.searchText = '';
        self.currentPage = 1;
        self.totalPages = 100;
        self.itemCount = 10;
        self.totalItems = 150;
        self.gamesList = [];
        self.selectedGameIds = [];
        self.showPagination = false;
        self.apiRoute = "/api/search/";
        

        self.initialize = function () {
            self.message = 'Woo hoo';
            self.fetchGames();
            self.getCart();
        };

        self.getGamesList = function () {
            return self.gamesList;
        };

        self.fetchGames = function () {
            self.showPagination = false;
            var criteria = { "searchText": self.searchText, "page": self.currentPage };
            var action = "searchgames";
            var url = $window.appGlobals.rootUrl + self.apiRoute + action;
            
            var data = {};
            if (criteria != null) {
                
                data = JSON.stringify(criteria);
            }
            return $http.post(url, data).then(self.parseResponse, self.errorResponse);
         
        };
        
        self.nextPage = function () {
            self.currentPage++;
            self.fetchGames();
        };

        self.previousPage = function () {
            if (self.currentPage > 1) {
                self.currentPage--;
            }
            self.fetchGames();
        };
        self.searchByName = function () {
            self.currentPage = 1;
            self.fetchGames();
        };
        self.addToCart = function (gameId) {
            //check if game is already added to cart
            if (self.selectedGameIds.indexOf(gameId) !== -1) {
                alert("Game already added to cart!");
                
            } else {
                self.selectedGameIds.push(gameId);
                self.saveCart();
            }

        };
        self.getCartCount = function () {
            return self.selectedGameIds.length;
        };
        self.checkout = function () {
            var controller = "/Checkout";
            
            $window.location.href = $window.appGlobals.rootUrl + controller;
        };

        self.saveCart = function () {
            var action = "saveToCart";
            var url = $window.appGlobals.rootUrl + self.apiRoute + action;                      
            var cartData = { "gameIds": self.selectedGameIds };
            var data = JSON.stringify(cartData);
            
            return $http.post(url, data).then(self.parseCartResponse, self.errorResponse);

        };

        self.getCart = function () {
            var action = "getCart";
            var url = $window.appGlobals.rootUrl + self.apiRoute + action;                      
            
            return $http.get(url).then(self.parseCartResponse, self.errorResponse);

        };

        self.parseResponse = function (response) {
            var listData = response.data;
            self.itemCount = listData.count;
            self.currentPage = listData.page;
            self.totalPages = listData.pages;
            self.totalItems = listData.total;
            self.gamesList = listData.items;
            if (self.gamesList.length > 0) {
                self.showPagination = true;
            }
        };

        self.parseCartResponse = function (response) {
            var listData = response.data;
            if (listData.gameIds != null && listData.gameIds.length > 0) {
                self.selectedGameIds = listData.gameIds;
            }
            else {
                self.selectedGameIds = [];
            }
        };

        self.errorResponse = function (response) {
            console.log("data: " + response.data + " status: " + response.status + " header: " + response.header);
        };

        self.initialize();
    }

})();