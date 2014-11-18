var c = document.getElementById("myCanvas");
var ctx = c.getContext("2d");

Object.prototype.extends = function (parent){
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
}

var Shape = (function(){
    function Shape(x, y, color){
        if(this.constructor === Shape) {
            throw ("You cannot create object from function Shape");
        }
        this.setX(x);
        this.setY(y);
        this.setColor(color);
    }

    Shape.prototype.getX = function(){
        return this._x;
    }

    Shape.prototype.setX = function(x){
        // TODO: get validation
        this._x = x;
    }

    Shape.prototype.getY = function(){
        return this._y;
    }

    Shape.prototype.setY = function(y){
        // TODO: get validation
        this._y = y;
    }

    Shape.prototype.getColor = function(){
        // TODO: get validation
        return this._color;
    }

    Shape.prototype.setColor = function(color){
        this._color = color;
    }

    Shape.prototype.draw = function(){
        //
        ctx.strokeStyle = this.getColor();
        ctx.stroke();
    }

    Shape.prototype.toString = function(){
        return this.constructor.name + ", X: " + this.getX() +
            ", Y: " + this.getY() +
            ", Color: " + this.getColor();
    }

    return Shape;
}());

var Circle = (function(){
    Circle.extends(Shape);

    function Circle(x, y, color, radius){
        Shape.call(this, x, y, color);
        this.setRadius(radius);
    }

    Circle.prototype.getRadius = function(){
        return this._radius;
    }

    Circle.prototype.setRadius = function(radius){
        // TODO: get validation
        this._radius = radius;
    }

    Circle.prototype.draw = function(){
        ctx.arc(this.getX(), this.getY(), this.getRadius(), 0, 2 * Math.PI);
        Shape.prototype.draw.call(this);
    }

    Circle.prototype.toString = function(){
        return Shape.prototype.toString.call(this) +
           ", Radius: " + this.getRadius();
    }

    return Circle;
}());

var Rectangle = (function(){
    Rectangle.extends(Shape);

    function Rectangle(x, y, color, width, height){
        Shape.call(this, x, y, color, width, height);
        this.setWidth(width);
        this.setHeight(height);
    }

    Rectangle.prototype.getWidth = function(){
        return this._width;
    }

    Rectangle.prototype.setWidth = function(width){
        // TODO: get validation
        this._width = width;
    }

    Rectangle.prototype.getHeight = function(){
        return this._height;
    }

    Rectangle.prototype.setHeight = function(height){
        // TODO: get validation
        this._height = height;
    }

    Rectangle.prototype.draw = function(){
        ctx.rect(this.getX(), this.getY(), this.getWidth(), this.getHeight());
        Shape.prototype.draw.call(this);
    }

    Rectangle.prototype.toString = function(){
        return Shape.prototype.toString.call(this) +
            ", Width: " + this.getWidth() +
            ", Height: " + this.getHeight();
    }

    return Rectangle;
}());

var myCircle = new Circle(200, 200, "blue", 50);
console.log(myCircle.toString());
myCircle.draw();

debugger;

var myRect = new Rectangle(10, 10, "red", 300, 200);
console.log(myRect.toString());
myRect.draw();