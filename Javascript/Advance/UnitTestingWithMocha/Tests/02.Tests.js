let expect = require('chai').expect;

let isOddOrEven = require("../02.EvenOrOdd");

describe('isOddOrEven Tests',function(){
    it('Should expect even',function(){
        expect(isOddOrEven("test")).to.be.eq("even");
    });
    it('Should expect odd',function(){
        expect(isOddOrEven("tes")).to.be.eq("odd");
    });
    it('Should expect even',function(){
        expect(isOddOrEven("")).to.be.eq("even");
    });
    it('Should expect undefined',function(){
        expect(isOddOrEven(1)).to.be.eq(undefined);
    });
    it('Should expect undefined',function(){
        expect(isOddOrEven([])).to.be.eq(undefined);
    });
    it('Should expect undefined',function(){
        expect(isOddOrEven({})).to.be.eq(undefined);
    });
});