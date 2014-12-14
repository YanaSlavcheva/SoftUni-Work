var app = app || {};

app.data = (function () {
    function Data (baseUrl, ajaxRequester) {
        this.users = new Users(baseUrl, ajaxRequester);
        this.products = new Products(baseUrl, ajaxRequester);
    }

    var cradentials = (function () {
        var headers = {
            'X-Parse-Application-Id': 'rRVFJ6m3OVeaMoknAfYTDNKyxu550RFwCeXVIEce',
            'X-Parse-REST-API-Key': '2pQl8awXdbEh6cy3PeArzODsdQmy7oMqcAyOSDA2',
            'X-Parse-Session-Token': getSessionToken()
        }

        function getSessionToken() {
            localStorage.getItem('sessionToken');
        }

        function setSessionToken(sessionToken) {
            localStorage.setItem('sessionToken', sessionToken);
        }

        function getUsername(sessionToken) {
            localStorage.getItem('username');
        }

        function setUsername(username) {
            localStorage.setItem('username', username);
        }

        function setObjectId(objectId) {
            localStorage.setItem('objectId', objectId);
        }

        function getObjectId(sessionToken) {
            localStorage.getItem('objectId');
        }

        function getHeaders() {
            return headers;
        }

        return {
            getSessionToken: getSessionToken,
            setSessionToken: setSessionToken,
            getUsername: getUsername,
            setUsername: setUsername,
            getHeaders: getHeaders,
            setObjectId: setObjectId,
            getObjectId: getObjectId
        }
    }());

    var Users = (function (argument) {
        function Users(baseUrl, ajaxRequester) {
            this._serviceUrl = baseUrl;
            this._ajaxRequester = ajaxRequester;
            this._headers = cradentials.getHeaders();
        }

        Users.prototype.login = function (username, password) {
            var url = this._serviceUrl + 'login?username=' + username + '&password=' + password;
            return this._ajaxRequester.get(url, this._headers)
                .then(function (data) {
                    cradentials.setSessionToken(data.sessionToken);
                    cradentials.setUsername(data.username);
                    cradentials.setObjectId(data.objectId);
                    return data;
                },
                function (error) {
                    printError(error);
                })
        };

        Users.prototype.register = function (username, password) {
            var user =  {
                username: username,
                password: password
            };
            var url = this._serviceUrl + 'users';
            return this._ajaxRequester.post(url, user, this._headers)
                .then(function (data) {
                    cradentials.setSessionToken(data.sessionToken);
                    return data;
                },
                function (error) {
                    printError(error);
                })
        };
        
        Users.prototype.getUserId = function () {
            
        }

        return Users;
    }());

    var Products = (function (argument) {
        function Products(baseUrl, ajaxRequester) {
            this._serviceUrl = baseUrl + 'classes/Product';
            this._ajaxRequester = ajaxRequester;
            this._headers = cradentials.getHeaders();
        }

        Products.prototype.getAll = function () {
            return this._ajaxRequester.get(this._serviceUrl, this._headers);
        }

        Products.prototype.getById = function (objectId) {
            console.log('I am in get by id!');
            return this._ajaxRequester.get(this._serviceUrl + '/' + objectId, this._headers);
        }

        Products.prototype.add = function (product) {
            return this._ajaxRequester.post(this._serviceUrl, product, this._headers);
        }

        Products.prototype.edit = function (product, objectId) {
            var url = this._serviceUrl + '/' + objectId;
            return this._ajaxRequester.put(url, product, this._headers);
        }

        Products.prototype.delete = function (objectId) {
            var url = this._serviceUrl + '/' + objectId;
            return this._ajaxRequester.delete(url, this._headers);
        }

        return Products;
    }());

    var printError = function (errorMsg) {
        noty({
                text: errorMsg,
                type: 'error',
                layout: 'topCenter',
                timeout: 5000}
        );
    }

    return {
        get: function (baseUrl, ajaxRequester) {
            return new Data(baseUrl, ajaxRequester);
        }
    }
}());