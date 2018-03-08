let expect = require('chai').expect;

let createCalculator = require("../07.AddSubtract.js");




describe('Add/Subtract Tests',function(){
    let calc;
    beforeEach(function () {
        calc = createCalculator();
    });
    it("should return 0 for get;", function () {
        let value = calc.get();
        expect(value).to.be.equal(0);
    });

    it("should return 5 for get;", function () {
        calc.add(5);
        let value = calc.get();
        expect(value).to.be.equal(5);
    });
    it("should return 4 for get;", function () {
        calc.add(5);
        calc.add(-1);
        let value = calc.get();
        expect(value).to.be.equal(4);
    });
    it("should return -5 for get;", function () {
        calc.add(-4);
        calc.add(-1);
        let value = calc.get();
        expect(value).to.be.equal(-5);
    });
    it("should return -10 for get;", function () {
        calc.add(-4);
        calc.subtract(6);
        let value = calc.get();
        expect(value).to.be.equal(-10);
    });
    it("should return 0 for get;", function () {
        calc.add(6);
        calc.subtract(6);
        let value = calc.get();
        expect(value).to.be.equal(0);
    });
    it("should return -12 for get;", function () {
        calc.subtract(6);
        calc.subtract(6);
        let value = calc.get();
        expect(value).to.be.equal(-12);
    });
    it("should return -1 for get;", function () {
        calc.add(3.50);
        calc.subtract(4.50);
        let value = calc.get();
        expect(value).to.be.equal(-1);
    });
    it("should return -1 for get;", function () {
        calc.add('1');
        calc.subtract('2');
        let value = calc.get();
        expect(value).to.be.equal(-1);
    });

    it("should return undefined for add;", function () {
        expect(calc.add('ddd')).to.be.equal(undefined);
    });
    it("should return NaN for get;", function () {
        calc.add('ddd');
        let value = calc.get();
        expect(value).to.be.NaN;
    });
    it("should return NaN for get;", function () {
        calc.subtract('ddd');
        let value = calc.get();
        expect(value).to.be.NaN;
    });
    it("should return 4.2 after add(5.3); subtract(1.1);", function () {
        calc.add(5.3);
        calc.subtract(1.1);
        let value = calc.get();
        expect(value).to.be.equal(5.3 - 1.1);
    });
    it("should return 2 after add(10); subtract('7'); add('-2'); subtract(-1)", function () {
        calc.add(10);
        calc.subtract('7');
        calc.add('-2');
        calc.subtract(-1);
        let value = calc.get();
        expect(value).to.be.equal(2);
    });
});