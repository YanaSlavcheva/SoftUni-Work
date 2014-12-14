var app = app || {};

(function () {
    var baseUrl = 'https://api.parse.com/1/'
    var ajaxRequester = app.ajaxRequester.get();
    var data = app.data.get(baseUrl, ajaxRequester);
    var controller = app.controller.get(data);
    controller.attachEventHandlers();

    app.router = Sammy(function () {
        var selector = '#wrapper';
        this.get('#/', function (){
            controller.loadHome(selector);
        });

        this.get('#/login', function () {
            controller.loadLogin(selector);
        });

        this.get('#/homeUser', function () {
            controller.loadHomeUser(selector);
        });

        this.get('#/register', function () {
            controller.loadRegister(selector);
        });

        this.get('#/products', function () {
            // this.redirect('#/login');
            controller.loadProducts(selector);
        });

        this.get('#/addProduct', function () {
            controller.loadAddProduct(selector);
        });

        this.get('#/editProduct', function () {
            controller.loadEditProduct(selector);
        });
    });

    app.router.run('#/');
}())