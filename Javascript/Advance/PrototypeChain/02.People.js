function solve() {
    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
            //if (new.target === Employee) {
            //    throw new Error("Cannot be instantiated!");
            //}
        }
        getSalary(){
            return this.salary;
        }
        work() {
            let current = this.tasks.shift();
            console.log(this.name + current);
            this.tasks.push(current);
        }
        collectSalary() {
            console.log( `${this.name} received ${this.getSalary()} this month.`);

        }
    }
    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [
                ` is working on a complicated task.`,
                ` is taking time off work.`,
                ` is supervising junior workers.`
            ]
        }
    }
    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [
                ` is working on a simple task.`
            ]
        }
    }
    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.dividend = 0;
            this.tasks = [
                ` scheduled a meeting.`,
                ` is preparing a quarterly report.`
            ]
        }
        getSalary(){
            return this.salary + this.dividend;
        }
    }
    return {Employee, Junior, Senior, Manager}}