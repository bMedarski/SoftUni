function Solve(n){

    let m=n;
if(n%2==0){
    m=n-1
}
    //console.log(n);
    let mid = parseInt(n/2)+1;
    //console.log(mid);
    for(let i=1;i<=m;i++){
        let line = "";
        for(let j=1;j<=2*n-1;j++){
            if(mid%2!=0){
                mid+=1;
            }
            //console.log(mid);
            if(i==1||i==m||i==mid){

                if(j==1||j==n||j==2*n-1){
                    line+="+";
                }else{
                    line+="-";
                }
            }else if(j==1||j==n||j==2*n-1){
                line+="-";
            }else{
                line+=" ";
            }
        }
        console.log(line)
    }
}
function figure(n) {
    let counter = (n - 2);

    let dash = '-';
    let char = '|';
    let plus = '+';

    if (n == 2) {
        console.log(plus + plus + plus);
    }
    else {

        if (n % 2 == 0) {//четни
            console.log("+" + "-".repeat(counter) + "+" + '-'.repeat(counter) + '+');
            for (i = 0; i < n / 2 - 2; i++) {
                console.log('|' + " ".repeat(counter) + '|' + " ".repeat(counter) + '|');
            }
            console.log("+" + "-".repeat(counter) + "+" + '-'.repeat(counter) + '+');
            for (i = 0; i < n / 2 - 2; i++) {
                console.log('|' + " ".repeat(counter) + '|' + " ".repeat(counter) + '|');
            }
            console.log("+" + "-".repeat(counter) + "+" + '-'.repeat(counter) + '+');
        }
        else {// нечетни
            console.log("+" + "-".repeat(counter) + "+" + '-'.repeat(counter) + '+');
            for (i = 0; i < n / 2 - 2; i++) {
                console.log('|' + " ".repeat(counter) + '|' + " ".repeat(counter) + '|');
            }
            console.log("+" + "-".repeat(counter) + "+" + '-'.repeat(counter) + '+');
            for (i = 0; i < n / 2 - 2; i++) {
                console.log('|' + " ".repeat(counter) + '|' + " ".repeat(counter) + '|');
            }
            console.log("+" + "-".repeat(counter) + "+" + '-'.repeat(counter) + '+');
        }
    }
}

figure(4);
figure(5);
figure(6);