function Solve(letter,character){

    let counter = 0;

   for(let i=0;i<letter.length;i+=1){
       if(letter[i]==character){
           counter++;
       }
   }
    console.log(counter)
}

Solve('hello', 'l');