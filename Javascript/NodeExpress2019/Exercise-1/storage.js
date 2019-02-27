const fs = require('fs');


let storage = {};

function ifString(key) {
    if (typeof (key) !== 'string') {
        throw new Error('Key should be a string');
    } else {
        return true;
    }
}

let commands = {
    put: (key, value) => {
        if (ifString(key)) {
            if (storage.hasOwnProperty(key)) {
                throw new Error('Key exist');
            };
            storage[key] = value;
        };
    },
    get: (key) => {
        if (ifString(key)) {
            if (!storage.hasOwnProperty(key)) {
                throw new Error('Key does not exist');
            } else {
                return storage[key];
            };
        };
    },
    getAll: () => {
        if (Object.entries(storage).length === 0 && storage.constructor === Object) {
            return 'Storage is empty!';
        } else {
            return storage;
        }
    },
    update: (key, newValue) => {
        if (ifString(key)) {
            if (!storage.hasOwnProperty(key)) {
                throw new Error('Key exist');
            };
            storage[key] = newValue;
        };
    },
    delete: (key) => {
        if (ifString(key)) {
            if (!storage.hasOwnProperty(key)) {
                throw new Error('Key does not exist');
            } else {
                delete storage[key];
            };
        };
    },
    clear: () => {
        storage = {};
    },
    saveAsync: () => {

        fs.writeFile('storage.json', JSON.stringify(storage), 'utf-8',(err) => {
            if (err) {
                throw err;
            }
        })
    },
    save: () => {

        fs.writeFileSync('storage.json', JSON.stringify(storage), 'utf-8')
    },
    loadAsync(){
        if (fs.existsSync('storage.json')) {
            let data = fs.readFile('storage.json',(err, data) => {
                if (err) {
                    throw err;
                }
                //let data = fs.readFileSync('storage.json');
                console.log(JSON.parse(data));
                storage = JSON.parse(data);

              });
        }
    },
    load: () => {
        if (fs.existsSync('storage.json')) {
            let data = fs.readFileSync('storage.json');
            storage = JSON.parse(data);
        }

    },
}
module.exports = commands;