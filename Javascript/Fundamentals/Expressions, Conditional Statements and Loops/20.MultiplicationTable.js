function Solve(n){
    console.log("<table border=\"1\">");
    let header = "<tr>";
    for(let i=0;i<=n;i++){
        if(i==0){
            header+="<th>x</th>";
        }else{
            header+="<th>"+i+"</th>";
        }
    }
    header += "</tr>";
    console.log(header);

    for(let i = 1; i<=n;i++){
        let line = "<tr>";
       for(let j = 1; j<=n;j++){
           if(j==1){
               line+= "<th>"+i*j+"</th>";
               line+= "<td>"+i*j+"</td>";
           }else{
               line+= "<td>"+i*j+"</td>";
           }
       }
        line+="<tr/>";
        console.log(line);
    }
    console.log("</table>");
}

Solve(5);