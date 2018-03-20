let expect = require('chai').expect;
let Sumator = require('../02.SumatorClass');

describe('sumator tests',function(){

    describe('with empty constructor', function () {
        beforeEach(function () {
            sumator = new Sumator();
        });

        it('has all properties', function () {
            expect(sumator.hasOwnProperty('data')).to.equal(true, "Missing data property");
        });

        it('has functions attached to prototype', function () {
            expect(Object.getPrototypeOf(sumator).hasOwnProperty('add')).to.equal(true, "Missing add function");
            expect(Object.getPrototypeOf(sumator).hasOwnProperty('sumNums')).to.equal(true, "Missing sumNums function");
            expect(Object.getPrototypeOf(sumator).hasOwnProperty('removeByFilter')).to.equal(true, "removeByFilter insertAt function");
            expect(Object.getPrototypeOf(sumator).hasOwnProperty('toString')).to.equal(true, "Missing toString function");
        });

        it('must initialize data to an empty array', function () {
            expect(sumator.data instanceof Array).to.equal(true, 'Data must be of type array');
            expect(sumator.data.length).to.equal(0, 'Data array must be initialized empty');
        });
    });

    describe('test add function',function(){
        beforeEach(function () {
            sumator = new Sumator();
        });

        it('add function to add to data any kind of types',function(){
            sumator.add(5);
            sumator.add('test');
            sumator.add([1]);

            expect(sumator.data[0]).to.be.equal(5);
            expect(sumator.data[1]).to.be.equal('test');
            expect(sumator.data[2][0]).to.be.equal(1);
            expect(sumator.data[2] instanceof Array).to.be.equal(true)
        });
    });
    describe('test sumNums function',function(){
        beforeEach(function () {
            sumator = new Sumator();
        });

        it('sumNums to return correct sum with different types',function(){
            sumator.add(5);
            sumator.add('test');
            sumator.add([1]);
            sumator.add(0);
            expect(sumator.sumNums()).to.be.equal(5);
        });
        it('sumNums to return correct sum with multiple numbers',function(){
            sumator.add(5);
            sumator.add(4);
            sumator.add(1);
            sumator.add(0);
            expect(sumator.sumNums()).to.be.equal(10);
        });
        it('sumNums to return correct sum with negative  numbers',function(){
            sumator.add(5);
            sumator.add(-4);
            sumator.add(-1);
            sumator.add(0);
            expect(sumator.sumNums()).to.be.equal(0);
        });
        it('sumNums to return correct sum with float  numbers',function(){
            sumator.add(5);
            sumator.add(1.5);
            sumator.add(3.5);
            sumator.add(0);
            expect(sumator.sumNums()).to.be.equal(10);
        });
        it('sumNums to return correct sum with no  numbers',function(){
            sumator.add('asd');
            sumator.add('test');
            sumator.add([1]);
            sumator.add({});
            expect(sumator.sumNums()).to.be.equal(0);
        });
        it('sumNums to return correct sum with nothing',function(){
            expect(sumator.sumNums()).to.be.equal(0);
        })
    });
    describe('test removeByFilter function',function(){
        beforeEach(function () {
            sumator = new Sumator();
        });

        it('to filter all positive numbers',function(){
            sumator.add(5);
            sumator.add('test');
            sumator.add({});
            sumator.add(5);
            sumator.add(-4);
            sumator.add(-1);
            sumator.add(0);

            let positive = function(x){
                return x>0
            };
            sumator.removeByFilter(positive);
            expect(sumator.data[0]).to.be.equal('test');
            expect(sumator.data[2]).to.be.equal(-4);
            expect(sumator.data.length).to.be.equal(5)

        });
    });
    describe('test toString function',function(){
        beforeEach(function () {
            sumator = new Sumator();
        });

        it('to return correct result',function(){
            sumator.add(5);
            sumator.add('test');
            sumator.add(5);
            sumator.add(-4);
            sumator.add(-1);
            sumator.add(0);
            sumator.add('end');

            expect(sumator.toString()).to.be.equal('5, test, 5, -4, -1, 0, end')

        });
        it('to return empty  when no elements',function(){

            expect(sumator.toString()).to.be.equal('(empty)')

        });
    });
});