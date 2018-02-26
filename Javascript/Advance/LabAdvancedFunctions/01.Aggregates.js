function reducer(array) {

    let sum = array.reduce((a, b)=>a + b);
    let min = Math.min(...array);
    let max = Math.max(...array);
    let product = array.reduce((a, b)=>a * b);
    let join = array.join("");
    console.log(`Sum = ${sum}`);
    console.log(`Min = ${min}`);
    console.log(`Max = ${max}`);
    console.log(`Product = ${product}`);
    console.log(`Join = ${join}`);
}

reducer([2,3,10,5]);