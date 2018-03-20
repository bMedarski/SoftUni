let expect = require('chai').expect;

let StringBuilder = require('../02.StringBuilder');

describe('StringBuilder Tests',function(){

    let strBulder;
    beforeEach(function(){
        strBulder = new StringBuilder('pesho');
    });

    describe('Initialize tests',function(){
        it('initialize with number expect to throw',function(){
            expect(()=> new StringBuilder(5).to.throw(TypeError,'Argument must be string'));
        });
        it('initialize with empty expect not to throw',function(){
            expect(()=> new StringBuilder().not.to.throw());
        });
        it('initialize with string expect not to throw',function(){
            expect(()=> new StringBuilder('pesho').not.to.throw());
        });
    });

    describe('Tests append',function(){

        it('append string at the end',function(){
            strBulder.append('123');
            expect(strBulder.toString()).to.be.equal('pesho123')
        });
        it('append string at the end when multiple appends',function(){
            strBulder.append('123');
            strBulder.append('456');
            expect(strBulder.toString()).to.be.equal('pesho123456')
        });
        it('append string at the end when initial empty',function(){
            let strBulder = new StringBuilder();
            strBulder.append('123');
            expect(strBulder.toString()).to.be.equal('123')
        });
        it('expect to throw when append with not a string',function(){
            expect(()=> strBulder.append(5).to.throw(TypeError));
        });
        it('expect to throw when append empty string',function(){
            expect(()=> strBulder.append().to.throw(TypeError));
        });
    });

    describe('Tests prepend',function(){

        it('prepend  string at the start',function(){
            strBulder.prepend('123');
            expect(strBulder.toString()).to.be.equal('123pesho')
        });
        it('prepend string at the end when multiple appends',function(){
            strBulder.prepend('456');
            strBulder.prepend('123');
            expect(strBulder.toString()).to.be.equal('123456pesho')
        });
        it('prepend string at the end when initial empty',function(){
            let strBulder = new StringBuilder();
            strBulder.prepend('123');
            expect(strBulder.toString()).to.be.equal('123')
        });
        it('expect to throw when append with not a string',function(){
            expect(()=> strBulder.prepend(5).to.throw(TypeError));
        });
        it('expect to throw when append empty string',function(){
            expect(()=> strBulder.prepend().to.throw(TypeError));
        });
    });
    describe('Tests insertAt',function(){
        it('expect to throw when insertAt empty',function(){
            expect(()=> strBulder.insertAt().to.throw(TypeError));
        });
        it('expect to throw when insertAt first param is not string ',function(){
            expect(()=> strBulder.insertAt(1,2).to.throw(TypeError));
        });
        it('expect to insert and the from when index is 0',function(){
            let strBulder = new StringBuilder();
            strBulder.append('123');
            strBulder.insertAt('0',0);
            expect(strBulder.toString()).to.be.equal('0123')
        });
        it('expect to insert and the back when index is max',function(){
            let strBulder = new StringBuilder();
            strBulder.append('123');
            strBulder.insertAt('abv',3);
            expect(strBulder.toString()).to.be.equal('123abv');
        });
        it('expect to insert and the back when index is max',function(){
            let strBulder = new StringBuilder();
            strBulder.append('123');
            strBulder.insertAt('abv',1);
            expect(strBulder.toString()).to.be.equal('1abv23');
        });
    });
    describe('Tests remove',function(){
        it('expect to throw when insertAt empty',function(){
            expect(()=> strBulder.remove().to.throw(TypeError));
        });

        it('expect to insert and the back when index is max',function(){
            let strBulder = new StringBuilder();
            strBulder.append('123');
            strBulder.remove(0,1);
            expect(strBulder.toString()).to.be.equal('23');
        });
        it('expect to insert and the back when index is max',function(){
            let strBulder = new StringBuilder();
            strBulder.append('123');
            strBulder.remove(0,3);
            expect(strBulder.toString()).to.be.equal('');
        });
        it('expect to insert and the back when index is max',function(){
            let strBulder = new StringBuilder();
            strBulder.append('123456');
            strBulder.remove(3,3);
            expect(strBulder.toString()).to.be.equal('123');
        });
        it('expect to insert and the back when index is max',function(){
            let strBulder = new StringBuilder();
            strBulder.append('123456');
            strBulder.remove(3,10);
            expect(strBulder.toString()).to.be.equal('123');
        });
        it('expect to insert and the back when index is max',function(){
            let strBulder = new StringBuilder();

            expect(strBulder.toString()).to.be.equal('');
        });
    })
    describe('with empty constructor', function () {
        beforeEach(function () {
            builder = new StringBuilder();
        });

        it('has all properties', function () {
            expect(builder.hasOwnProperty('_stringArray')).to.equal(true, "Missing _stringArray property");
        });

        it('has functions attached to prototype', function () {
            expect(Object.getPrototypeOf(builder).hasOwnProperty('append')).to.equal(true, "Missing append function");
            expect(Object.getPrototypeOf(builder).hasOwnProperty('prepend')).to.equal(true, "Missing prepend function");
            expect(Object.getPrototypeOf(builder).hasOwnProperty('insertAt')).to.equal(true, "Missing insertAt function");
            expect(Object.getPrototypeOf(builder).hasOwnProperty('remove')).to.equal(true, "Missing remove function");
            expect(Object.getPrototypeOf(builder).hasOwnProperty('toString')).to.equal(true, "Missing toString function");
        });

        it('must initialize data to an empty array', function () {
            expect(builder._stringArray instanceof Array).to.equal(true, 'Data must be of type array');
            expect(builder._stringArray.length).to.equal(0, 'Data array must be initialized empty');
        });
    });

});