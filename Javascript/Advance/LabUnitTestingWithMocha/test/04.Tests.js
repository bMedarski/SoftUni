let expect = require('chai').expect;

let sum = require("../04.SumOfNumbers").sum;

describe('Sum Tests',function(){
    it('Should expect 3',function(){
        expect(sum([1,2])).to.be.eq(3);
    });
    it('Should expect 1',function(){
        expect(sum([1])).to.be.eq(1);
    });
    it('Should expect 0',function(){
        expect(sum([])).to.be.eq(0);
    });
    it('Should expect 3',function(){
        expect(sum([-1,4])).to.be.eq(3);
    });
    it('Should expect 3',function(){
        expect(sum([1.1,-1,+1,8.9])).to.be.eq(10);
    });
    it('Should expect NaN',function(){
        expect(sum('test')).to.be.NaN;
    });
});