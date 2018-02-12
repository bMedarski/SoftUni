function Solve(arguments){
    console.log("<table>");
    for (let i = 0; i < arguments.length; i++) {
            let person = JSON.parse(arguments[i]);
            console.log("<tr>");
            console.log(`<td>${person.name}</td>`);
            console.log(`<td>${person.position}</td>`);
            console.log(`<td>${person.salary}</td>`);
            console.log("<tr>");
    }
    console.log("</table>");
}
Solve(
    [
        '{"name":"Pesho","position":"Promenliva","salary":100000}',
        '{"name":"Teo","position":"Lecturer","salary":1000}',
        '{"name":"Georgi","position":"Lecturer","salary":1000}',

    ]
);