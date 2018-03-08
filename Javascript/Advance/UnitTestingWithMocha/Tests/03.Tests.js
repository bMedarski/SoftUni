let expect = require('chai').expect;

let lookupChar = require("../03.CharLookup");

describe('lookupChar Tests',function(){
    it('Should expect undefined with pesho pesho',function(){
        expect(lookupChar('pesho','pesho')).to.be.eq(undefined);
    });
    it('Should expect undefined with 1 1',function(){
        expect(lookupChar(1,1)).to.be.eq(undefined);
    });
    it('Should expect undefined with asd 1.5',function(){
        expect(lookupChar('asd',1.5)).to.be.eq(undefined);
    });
    it('Should expect undefined with pesho {}',function(){
        expect(lookupChar('pesho',{})).to.be.eq(undefined);
    });
    it('Should expect undefined with pesho []',function(){
        expect(lookupChar('pesho',[])).to.be.eq(undefined);
    });
    it('Should expect undefined with pesho true',function(){
        expect(lookupChar('pesho',true)).to.be.eq(undefined);
    });
    it('Should expect undefined with true pesho',function(){
        expect(lookupChar(true,'pesho')).to.be.eq(undefined);
    });
    it('Should expect undefined with 1 pesho',function(){
        expect(lookupChar(1,'pesho')).to.be.eq(undefined);
    });
    it('Should expect undefined with [] pesho',function(){
        expect(lookupChar([],'pesho')).to.be.eq(undefined);
    });
    it('Should expect undefined with {} pesho',function(){
        expect(lookupChar({},'pesho')).to.be.eq(undefined);
    });
    it('Should expect undefined with pesho',function(){
        expect(lookupChar('pesho')).to.be.eq(undefined);
    });
    it('Should expect undefined with 1',function(){
        expect(lookupChar(1)).to.be.eq(undefined);
    });
    it('Should expect undefined with []',function(){
        expect(lookupChar([])).to.be.eq(undefined);
    });
    it('Should expect undefined with {}',function(){
        expect(lookupChar({})).to.be.eq(undefined);
    });
    it('Should expect undefined with true',function(){
        expect(lookupChar(true)).to.be.eq(undefined);
    });
    it('Should expect undefined with pesho -1',function(){
        expect(lookupChar('pesho',-1)).to.be.eq('Incorrect index');
    });
    it('Should expect undefined with pesho -1',function(){
        expect(lookupChar('pesho',10)).to.be.eq('Incorrect index');
    });
    it('Should expect undefined with pesho -1',function(){
        expect(lookupChar('pesho',5)).to.be.eq('Incorrect index');
    });
    it('Should expect undefined with pesho -1',function(){
        expect(lookupChar('pesho',0)).to.be.eq('p');
    });
    it('Should expect undefined with pesho -1',function(){
        expect(lookupChar('pesho',4)).to.be.eq('o');
    });
});