function playground(){
	var _this = this.playground;
	
	console.log(arguments.length);

	for (var i = 0; i < arguments.length; i++) {
		console.log(arguments[i]);
	};

	for (var i = 0; i < arguments.length; i++) {
		console.log(typeof arguments[i]);
	};

	console.log(_this);
};

playground("swing", "boy", 1, {});

playground.call(null, 1, 2, 3);
playground.apply(null, [1, 2, 3]);