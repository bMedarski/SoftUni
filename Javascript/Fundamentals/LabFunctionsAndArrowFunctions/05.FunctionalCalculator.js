function Solve(a,b,action){

    if(action=="*"){
        return a*b;
    }else if(action=="/"){
        return a/b;
    }else if(action=="+"){
        return a+b;
    }else if(action=="-"){
        return a-b;
    }else{
        return "error"
    }
}
