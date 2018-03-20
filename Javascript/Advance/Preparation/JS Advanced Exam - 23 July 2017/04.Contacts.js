class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email=email;
        this.online = false;
    }


    set online(value){
        let name = this.firstName+' '+this.lastName;
        if(value===true){
            console.log('true');
            $('div:contains(`${name}`)').addClass('online');
            this._online = value;
        }else{
            console.log('false');
            $('div:contains(name)').removeClass('online');
            this._online = value;
        }
    }
    get online(){
        return this._online;
    }

    render(id){

        let article = $('<article>');
        let title = $('<div>').addClass('title').html(this.firstName+' '+this.lastName);
        let button = $('<button>').html('&#8505;');
        let info = $('<div>').addClass('info');
        info.css('display','none');
        button.on('click',function(){
            info.toggle();
        });
        let phone = $('<span>').html('&phone; '+this.phone);
        let email = $('<span>').html('&#9993; ' + this.email);

        info.append(phone);
        info.append(email);
        title.append(button);
        article.append(title);
        article.append(info);
        $("#"+id).append(article);
    }
}