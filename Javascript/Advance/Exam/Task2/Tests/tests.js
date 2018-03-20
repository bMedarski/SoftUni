let expect = require('chai').expect;
let PaymentPackage = require('../Task2');

describe('PaymentPackage tests', function () {

    let paymntPakg;
    beforeEach(function () {
        paymntPakg = new PaymentPackage('HR', 1500);
    });

    describe('Initialization test', function () {
        it('has functions attached to prototype', function () {
            expect(Object.getPrototypeOf(paymntPakg).hasOwnProperty('toString')).to.equal(true, "Missing toString function");
        });
        it('should throw with incorrect name', function () {

            let willThrow = () => new PaymentPackage(1, 3);
            expect(willThrow).to.throw();
        });

        it('should throw with incorrect value', function () {

            let willThrow = () => new PaymentPackage('test', 'test');
            expect(willThrow).to.throw();
        });

        it('should throw without name', function () {

            let willThrow = () => new PaymentPackage(1);
            expect(willThrow).to.throw();
        });
        it('should throw without value', function () {

            let willThrow = () => new PaymentPackage('test');
            expect(willThrow).to.throw();
        });

        it('should throw with empty name', function () {

            let willThrow = () => new PaymentPackage('', 1);
            expect(willThrow).to.throw();
        });
        it('should throw with negative value', function () {

            let willThrow = () => new PaymentPackage('test', -1);
            expect(willThrow).to.throw();
        });

    });
    describe('Name test', function () {
        it('get correct name with string', function () {
            expect(paymntPakg.name).to.equal('HR');
        });

        it('should throw with incorrect set', function () {
            let willThrow = () => paymntPakg.name = 5;
            expect(willThrow).to.throw();
        });
        it('should throw with empty set', function () {
            let willThrow = () => paymntPakg.name = '';
            expect(willThrow).to.throw();
        });

        it('set correct name', function () {
            paymntPakg.name = 'test';
            expect(paymntPakg.name).to.equal('test');
        });

    });
    describe('Value test', function () {
        it('get correct name with string', function () {
            expect(paymntPakg.value).to.equal(1500);
        });

        it('should throw with incorrect set', function () {
            let willThrow = () => paymntPakg.value = 'test';
            expect(willThrow).to.throw();
        });
        it('should throw with negative set', function () {
            let willThrow = () => paymntPakg.value = -1;
            expect(willThrow).to.throw();
        });

        it('set correct name', function () {
            paymntPakg.value = 1000;
            expect(paymntPakg.value).to.equal(1000);
        });

    });

    describe('VAT test', function () {
        it('get correct VAT', function () {
            expect(paymntPakg.VAT).to.equal(20);
        });

        it('should throw with incorrect set', function () {
            let willThrow = () => paymntPakg.VAT = 'test';
            expect(willThrow).to.throw();
        });
        it('should throw with negative set', function () {
            let willThrow = () => paymntPakg.VAT = -1;
            expect(willThrow).to.throw();
        });

        it('set correct name', function () {
            paymntPakg.VAT = 1000;
            expect(paymntPakg.VAT).to.equal(1000);
        });
    });

    describe('active test', function () {
        it('get correct active', function () {
            expect(paymntPakg.active).to.equal(true);
        });

        it('should throw with incorrect set', function () {
            let willThrow = () => paymntPakg.active = 'test';
            expect(willThrow).to.throw();
        });
        it('should throw with incorrect set', function () {
            let willThrow = () => paymntPakg.active = 1;
            expect(willThrow).to.throw();
        });


        it('set correct active', function () {
            paymntPakg.active = false;
            expect(paymntPakg.active).to.equal(false);
        });

        it('set correct active', function () {
            paymntPakg.active = false;
            paymntPakg.active = true;
            expect(paymntPakg.active).to.equal(true);
        });
    });

    describe('toString test', function () {
        it('get correct toString', function () {

            paymntPakg.VAT = 100;
            const output = `Package: HR` + '\n' + `- Value (excl. VAT): 1500` + '\n' + `- Value (VAT 100%): 3000`;
            expect(paymntPakg.toString()).to.equal(output);
        });
        it('get correct toString', function () {

            paymntPakg.VAT = 100;
            paymntPakg.active = false;
            const output = `Package: HR (inactive)` + '\n' + `- Value (excl. VAT): 1500` + '\n' + `- Value (VAT 100%): 3000`;
            expect(paymntPakg.toString()).to.equal(output);
        });

    });

});