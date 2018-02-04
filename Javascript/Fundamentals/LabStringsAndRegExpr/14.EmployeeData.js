'use strict';

function Solve(input){

    for (let i = 0; i < input.length; i++) {
        //console.log(input[i]);
        let emp = {};
        const regex = /^[A-Z][a-z]*\s-\s[1-9][0-9]*\s-\s[a-zA-Z0-9- ]+$/gm;
        if(regex.test(input[i])){
            let args = input[i].split(' - ').filter(s=>s!="").map(s=>s.trim());
            emp.Name = args[0];
            emp.Position = args[2];
            emp.Salary = args[1];

            console.log(`Name: ${emp.Name}`);
            console.log(`Position: ${emp.Position}`);
            console.log(`Salary: ${emp.Salary}`);
        }
    }
}

Solve(['Isacc - 1000 - CEO',
    'Ivan - 500 - Employee',
    'Peter - 500 - Employee'
]);

Solve([]);

function parseTheEmployeeData(input) {
    let regex = /^([A-Z][a-zA-Z]*) - ([1-9][0-9]*) - ([a-zA-Z0-9\- ]+)$/;
    for(let employee of input) {
        let match = regex.exec(employee);
        if(match) {
            console.log(`Name: ${match[1]}`);
            console.log(`Position: ${match[3]}`);
            console.log(`Salary: ${match[2]}`);
        }
    }
}

