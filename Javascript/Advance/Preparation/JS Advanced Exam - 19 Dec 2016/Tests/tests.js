let expect = require('chai').expect;
let makeList = require('../02.List');


describe('make list tests', function () {

    describe('initial tests', function () {

        let myList = {};

        beforeEach(function () {
            myList = makeList();
        });
        it("should contain all properties", function () {
            expect(myList.addLeft).to.exist;
            expect(myList.addRight).to.exist;
            expect(myList.clear).to.exist;
            expect(myList.toString).to.exist;
        });
    });
});