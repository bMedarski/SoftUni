class Repository {
    constructor(prop) {
        this.props = prop;
        this.currentId = -1;
        this.data = new Map();
    }

    add(entity) {
        this.validateEntity(entity);
        this.currentId = this.getNextId();
        this.data.set(this.currentId,entity);
        return this.currentId;
    }

    get(id) {
        if(this.data.has(id)){
            return this.data.get(id);
        }else{
            throw new Error(`Entity with id: ${id} does not exist!`);
        }
    }

    update(id, entity) {
        if(this.data.has(id)){
            this.validateEntity(entity);
            this.data.set(id,entity);
        }else{
            throw new Error(`Entity with id: ${id} does not exist!`);
        }
    }

    del(id) {
        if(this.data.has(id)){
            this.data.delete(id);
        }else{
            throw new Error(`Entity with id: ${id} does not exist!`);
        }
    }

    get count() {
        return this.data.size;
    }

    validateEntity(entity) {
        for (let propName in this.props) {
            if (!entity.hasOwnProperty(propName)) {
                throw new Error(`Property ${propName} is missing from the entity!`);
                //Property {propName} is missing from the entity!
            }
        }
        for (let propName in entity) {
            let val = entity[propName];
            if (typeof val !== this.props[propName]) {
                throw new TypeError(`Property ${propName} is of incorrect type!`);
                //Property {propertName} is of incorrect type!
            }
        }
    }
    getNextId() {
        this.currentId++;
        return this.currentId;
    }
}

let properties = { name: "string", age: "number", birthday: "object" };
 //Initialize the repository
let repository = new Repository(properties);
 // Add two entities
let entity = { name: "Kiril", age: 19, birthday: new Date(1998, 0, 7) };
repository.add(entity); // Returns 0
repository.add(entity); // Returns 1


//console.log(repository.get(0)); // {"name":"Kiril","age":19,"birthday":"1998-01-06T22:00:00.000Z"}
//console.log(repository.get(1)); // {"name":"Kiril","age":19,"birthday":"1998-01-06T22:00:00.000Z"}
//// Update an entity
entity = { name: 'Valio', age: 19, birthday: new Date(1998, 0, 7) };
repository.update(1, entity);

//console.log(repository.get(1)); // {"name":"Valio","age":19,"birthday":"1998-01-06T22:00:00.000Z"}
//// Delete an entity
repository.del(0);
//console.log(repository.count); // Returns 1
let anotherEntity = { name1: 'Nakov', age: 26, birthday: new Date(1991, 0, 21) };
//repository.add(anotherEntity);
//// should throw an Error
//anotherEntity = { name: 'Nakov', age: 26, birthday: 1991 };
//repository.add(anotherEntity);
//// should throw a TypeError
repository.del(-1); // should throw Error for invalid id
