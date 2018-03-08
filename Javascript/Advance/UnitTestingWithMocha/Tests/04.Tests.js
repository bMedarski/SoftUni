let expect = require('chai').expect;

let mathEnforcer = require("../04.MathEnforcer");

describe('mathEnforcer Tests',function(){

    it('Should expect 10 when input 5 ',function(){
        expect(mathEnforcer.addFive(5)).to.be.eq(10);
    });
    it('Should expect 5 when input 0 ',function(){
        expect(mathEnforcer.addFive(0)).to.be.eq(5);
    });
    it('Should expect 6.1 when input 1.1 ',function(){
        expect(mathEnforcer.addFive(1.1)).to.be.eq(6.1);
    });
    it('Should expect 0 when input -5 ',function(){
        expect(mathEnforcer.addFive(-5)).to.be.eq(0);
    });
    it('Should expect undefined when input string ',function(){
        expect(mathEnforcer.addFive('test')).to.be.eq(undefined);
    });
    it('Should expect 10 when input 20 ',function(){
        expect(mathEnforcer.subtractTen(20)).to.be.eq(10);
    });
    it('Should expect -10 when input 0 ',function(){
        expect(mathEnforcer.subtractTen(0)).to.be.eq(-10);
    });
    it('Should expect 6.5 when input 16.5 ',function(){
        expect(mathEnforcer.subtractTen(16.5)).to.be.eq(6.5);
    });
    it('Should expect -15 when input -5 ',function(){
        expect(mathEnforcer.subtractTen(-5)).to.be.eq(-15);
    });
    it('Should expect undefined when input string ',function(){
        expect(mathEnforcer.subtractTen('test')).to.be.eq(undefined);
    });
    it('Should expect undefined and 1 when input string ',function(){
        expect(mathEnforcer.sum('test',1)).to.be.eq(undefined);
    });
    it('Should expect 1 and undefined when input string ',function(){
        expect(mathEnforcer.sum(1,'test')).to.be.eq(undefined);
    });
    it('Should expect 1 and 2 when input string ',function(){
        expect(mathEnforcer.sum(1,2)).to.be.eq(3);
    });
    it('Should expect 1 and -2 when input string ',function(){
        expect(mathEnforcer.sum(1,-2)).to.be.eq(-1);
    });
    it('Should expect 1.1 and 2.2 when input string ',function(){
        expect(mathEnforcer.sum(1.1,2)).to.be.eq(3.1);
    });
    it('Should expect 1.1 and 2.2 when input string ',function(){
        expect(mathEnforcer.sum(5.5,4.5)).to.be.eq(10);
    });
});