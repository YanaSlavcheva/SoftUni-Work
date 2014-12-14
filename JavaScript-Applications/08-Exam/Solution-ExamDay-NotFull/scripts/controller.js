var app = app || {};

app.controller = (function () {
    function BaseController(data) {
        this._data = data;
    }

    BaseController.prototype.loadHome = function (selector) {
        $(selector).load('./templates/home.html');
    }

    BaseController.prototype.loadLogin = function (selector) {
        $(selector).load('./templates/login.html');
    }

    BaseController.prototype.loadHomeUser = function (selector) {
        $.get('./templates/homeUser.html', function (template) {

            var username = {
                'username': localStorage.username
            };
            console.log(username);
            var output = Mustache.render(template, username);
            $(selector).html(output);
        })
    }

    BaseController.prototype.loadRegister = function (selector) {
        $(selector).load('./templates/register.html');
    }

    BaseController.prototype.loadProducts = function (selector) {
        this._data.products.getAll()
            .then(function (data) {
                $.get('templates/products.html', function (template) {
                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                })
            })
    }

    BaseController.prototype.loadAddProduct = function (selector) {
        $(selector).load('./templates/addProduct.html');
    }

    BaseController.prototype.loadEditProduct = function (selector) {
//        $(selector).load('./templates/editProduct.html');

        var objectId = $('.product').data('id');
//        var objectId = $(this).data('id');
        this._data.products.getById(objectId)
            .then(function (data) {
                $.get('templates/editProduct.html', function (template) {
                    var output = Mustache.render(template, data);
                    $(selector).html(output);
                })
            })
    }

    BaseController.prototype.attachEventHandlers = function () {
        var selector = '#wrapper';
        attachLoginHandler.call(this, selector);
        attachRegisterHandler.call(this, selector);
        attachAddProductHandler.call(this, selector);
        attachEditProductHandler.call(this, selector);
        attachDeleteProductHandler.call(this, selector);
        attachLogoutHandler.call(this, selector);
    }

    var attachLoginHandler = function (selector) {
        var _this = this;
        $(selector).on('click', '#login-button', function () {
            var username = $('#username').val();
            var password = $('#password').val();
            _this._data.users.login(username, password)
                .then(function (data) {
                    window.history.replaceState('Products', 'Products', '#/homeUser');
                    location.reload();
                },
                function (error) {
                    printError(error);
                });
        });
    }

    var attachRegisterHandler = function (selector) {
        var _this = this;
        $(selector).on('click', '#register-button', function () {
            var username = $('#username').val();
            var password = $('#password').val();
            var confirmPassword = $('#confirm-password').val();
            if(password == confirmPassword) {
                _this._data.users.register(username, password)
                    .then(function (data) {
                        var msg = 'Congratulations, ' + username + ', you registered successfully!';
                        alert(msg);
                        window.history.replaceState('Products', 'Products', '#/login');
                        location.reload();
                    },
                    function (error) {
                        printError(error);
                    });
            } else {
                printError('Password does not match!');
                $('#password').val('');
                $('#confirm-password').val('');
            }
        });
    }

    var attachAddProductHandler = function (selector) {
        var _this = this;
        $(selector).on('click', '#add-product-button', function (ev) {
            var name = $('#name').val();
            var category = $('#category').val();
            var price = $('#price').val();
            var userObjectId = localStorage.objectId;

            //set ACL when creating the user so just the user may edit his products
            //It didn't quite work so it is back to everyone can edit and delete everything
//            var ACL = {};
//            var jsonKey = '' + userObjectId;
//            ACL[jsonKey] = {"write":true,"read":true};
//            ACL['*'] = {"read":true};
//            console.log(typeof ACL);
//            console.log(ACL);

            var product = {
                name: name,
                category: category,
                price: price//,
//                ACL:ACL
            }
            _this._data.products.add(product)
                .then(function (data) {
                    console.log('I am in products add success!');
                    _this._data.products.getById(data.objectId)
                        .then(function (product) {
                            printMessage('You added the product "' + product.name + '" successfully!');
                            $('#name').val('');
                            $('#category').val('');
                            $('#price').val('');
                        }, function (error) {
                            console.log(error);
                        });
                }, function (error) {
                    printError(error);
                });
        });

        function getProduct(objectId) {
            _this._data.products.getById(objectId)
                .then(function (product) {
                    console.log('I am in get by id success!');
                    console.log(product);
                }, function (error) {
                    console.log(error);
                });
        }
    }

    var attachEditProductHandler = function (selector) {
        var _this = this;
        $(selector).on('click', '#edit-product-button', function (ev) {
            var objectId = $(this).parent().data('id');
            var name = $('#name').val();
            var category = $('#category').val();
            var price = $('#price').val();
            var product = {
                name: name,
                category: category,
                price: price
            }
            _this._data.products.edit(product, objectId)
                        .then(function (product) {
                            printMessage('You edited the product "' + name + '" successfully!');
                            $('#name').val('');
                            $('#category').val('');
                            $('#price').val('');
                        }, function (error) {
                                printError('Cannot edit the product - no permission!');
                        });
        });

        function getProduct(objectId) {
            _this._data.products.getById(objectId)
                .then(function (product) {
                    console.log('I am in get by id success!');
                    console.log(product);
                }, function (error) {
                    console.log(error);
                });
        }
    }

    var attachDeleteProductHandler = function (selector) {
        var _this = this;
        $(selector).on('click', '.delete-button', function (ev) {
            var deleteConfirmed = confirm('Do you want to delete this product?');
            if (deleteConfirmed) {
                var objectId = $(this).data('id');
                _this._data.products.delete(objectId)
                    .then(function (data) {
                        $(ev.target).parent().parent().parent().remove();
                        printMessage('Product deleted successfully!');
                    },
                    function (error) {
                        printError('Cannot delete products of others!!!');
                    })
            };
        })
    }

    var attachLogoutHandler = function (selector) {
        var _this = this;
        $(selector).on('click', '#logout', function () {
            localStorage.clear();
            alert('Thank You for being with us, come again later!');
            window.history.replaceState('Products', 'Products', '#/login');
            location.reload();
        });
    }

    var printMessage = function (msg) {
        noty({
                text: msg,
                type: 'info',
                layout: 'topCenter',
                timeout: 5000}
        );
    }

    var printError = function (errorMsg) {
        noty({
                text: errorMsg,
                type: 'error',
                layout: 'topCenter',
                timeout: 5000}
        );
    }

    return {
        get: function (data) {
            return new BaseController(data);
        }
    }
}())