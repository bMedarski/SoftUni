console.log('Before');

new Promise(function(resolve,reject){

    setTimeout(function(){
        resolve('done');
        console.log('In set timeout');

    },1000)

}).then(function(result){
        console.log(result);
    });

console.log('After');