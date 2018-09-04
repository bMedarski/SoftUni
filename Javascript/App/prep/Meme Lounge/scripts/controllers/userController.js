let userController = (() => {
    function loginGet(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        if (!AuthService.isAuth()) {
            ctx.loadPartials({
                footer: './templates/partials/footer.hbs',
                nav: './templates/partials/nav.hbs',
            })
                .then(function () {
                    this.partial('./templates/common/login.hbs');
                })
        } else {
            ctx.redirect('#/home');
        }
    }
    function loginPost(ctx) {
          AuthService.login(ctx.params)
              .then((userInfo) => {
                  AuthService.saveSession(userInfo);
                  NotifyService.showInfo(SUCCESSFUL_LOGIN);
                  ctx.redirect('#/list-all');
              })
              .catch(NotifyService.handleError)
      }
    function registerGet(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');

        if (!AuthService.isAuth()) {
            ctx.loadPartials({
                footer: './templates/partials/footer.hbs',
                nav: './templates/partials/nav.hbs',
            })
                .then(function () {
                    this.partial('./templates/common/register.hbs');
                })
        } else {
            ctx.redirect('#/home');
        }
    }
    function registerPost(ctx) {
            AuthService.register(ctx.params)
                .then((userInfo) => {
                    AuthService.saveSession(userInfo);
                    NotifyService.showInfo(SUCCESSFUL_REGISTRATION);
                    ctx.redirect('#/list-all');
                })
        .catch(NotifyService.handleError)
        }
    function logout(ctx) {
        AuthService.logout()
            .then(() => {
                sessionStorage.clear();
                NotifyService.showInfo(SUCCESSFUL_LOGOUT);
                ctx.redirect('#/home')
            })
    }
    async function deleteUser(ctx){
        let userId = sessionStorage.getItem('userId');
        await AuthService.deleteUser(userId).then(()=>{
            sessionStorage.clear();
            NotifyService.showInfo(USER_DELETED);
            ctx.redirect('#/home');
        });

    }
    async function getUser(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');

        await AuthService.getUser(ctx.params.id).then((user)=>{
            ctx.currentUser = user.username;
            ctx.email = user.email;
            ctx.avatarUrl = user.avatarUrl;
            ctx.id = user._id;
            if(user.username===ctx.username){
                ctx.owner = true;
            }
        });
        await memesService.listMyMemes(ctx.currentUser)
            .then((memes)=>{

                ctx.memes = memes;
                if(memes.length ===0){
                    ctx.noMemes = true;
                }
                for(let i = 0; i<memes.length;i++){
                    ctx.memes[i].id = memes[i]._id;
                    if(memes[i].creator===sessionStorage.getItem('username')){
                        ctx.memes[i].author = true;
                    }
                }});
        if (AuthService.isAuth()) {
            ctx.loadPartials({
                footer: './templates/partials/footer.hbs',
                nav: './templates/partials/nav.hbs',
            })
                .then(function () {
                    this.partial('./templates/user/profile.hbs');
                })
        } else {
            ctx.redirect('#/home');
        }
    }
    return {
        loginGet,
        registerGet,
        loginPost,
        registerPost,
        logout,
        getUser,
        deleteUser
    }
})();