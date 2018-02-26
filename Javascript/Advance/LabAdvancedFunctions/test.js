function invokeAll(functionsArr) {
    for (let func of functionsArr) func();
}
let last = function() { console.error("last"); };


invokeAll([() => console.info('first'), () => console.warn('second'), last]);
