class PaymentProcessor {
    constructor(options) {
        this.setOptions(options)
        this.payments = [];
    }

    registerPayment(id, name, type, value) {
        let precision = this.options.precision;
        if (id === '' || name === '') {
            throw new Error('Invalid Id or name')
        }
        if (!this.options.types.includes(type)) {
            throw new Error('Invalid type')
        }
        if (isNaN(value)) {
            throw new Error('Invalid value')
        }

        for (let i of this.payments) {
            if (i.Id === id) {
                throw new Error('Same Id')
            }
        }
        let payment = {
            Id: id,
            Name: name,
            Type: type,
            Value: Number(value.toFixed(precision))
        };
        this.payments.push(payment);
    }

    deletePayment(id) {
        let idToDelete = -1;
        for (let i = 0; i < this.payments.length; i++) {
            if (this.payments[i].Id === id) {
                idToDelete = i;
            }
        }

        if (idToDelete === -1) {
            throw new Error('Id not fount')
        }
        this.payments.splice(idToDelete, 1);
    }

    get(id) {
        let precision = this.options.precision;
        let payment = {};
        let idToDelete = -1;
        for (let i = 0; i < this.payments.length; i++) {
            if (this.payments[i].Id === id) {
                payment = this.payments[i];
                idToDelete = i;
            }
        }

        if (idToDelete === -1) {
            throw new Error('Id not fount')
        }
        ///Details about payment ID: E028
        //- Name: Rare-earth elements
        //- Type: material
        //- Value: 8000.00
        const output = [
            `Details about payment ID: ${payment.Id}:`,
            `- Name: ${payment.Name}`,
            `- Type: ${payment.Type}`,
            `- Value: ${payment.Value}`
        ];
        return output.join('\n');


    }

    setOptions(options) {
        let opt = {};
        if (options === undefined) {
            opt = {
                types: ["service", "product", "other"],
                precision: 2
            };
            this.options = opt;
        }
        else if (options.hasOwnProperty('types') && !options.hasOwnProperty('precision')) {
            opt = {
                types: options.types,
                precision: 2
            };
            this.options = opt;
        }
        else if (!options.hasOwnProperty('types') && options.hasOwnProperty('precision')) {
            opt = {
                types: ["service", "product", "other"],
                precision: options.precision
            };
            this.options = opt;
        }
        else if (options.hasOwnProperty('types') && options.hasOwnProperty('precision')) {
            opt = {
                types: options.types,
                precision: options.precision
            };
            this.options = opt;
        }
    }

    toString() {
        let precision = this.options.precision;
        let sum = 0;
        for (let i of this.payments) {

            sum += i.Value;
        }
        const output = [
            `Summary:`,
            `- Payments: ${this.payments.length}`,
            `- Balance: ${sum.toFixed(precision)}`
        ];
        return output.join('\n');
    }
}
const generalPayments = new PaymentProcessor();
console.log(generalPayments.toString());

generalPayments.registerPayment('0001', 'Microchips', 'product', 15000);
generalPayments.registerPayment('01A3', 'Biopolymer', 'product', 23000);
console.log(generalPayments.toString());

const transactionLog = new PaymentProcessor({precision: 5});
transactionLog.registerPayment('b5af2d02-327e-4cbf', 'Interest', 'other', 0.00153);
console.log(transactionLog.toString());
