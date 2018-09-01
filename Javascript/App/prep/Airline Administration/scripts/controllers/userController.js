let userController = (() => {
    function loginGet(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        if (!AuthService.isAuth()) {
            ctx.loadPartials({
                footer: './templates/common/footer.hbs',
                nav: './templates/common/nav.hbs',
            })
                .then(function () {
                    this.partial('./templates/user/login.hbs');
                })
                .catch(NotifyService.handleError)
        } else {
            ctx.redirect('#/home');
        }
    }
    function loginPost(ctx) {
          AuthService.login(ctx.params)
              .then((userInfo) => {
                  AuthService.saveSession(userInfo);
                  NotifyService.showInfo(SUCCESSFUL_LOGIN);
                  ctx.redirect('#/home');
              })
              .catch(NotifyService.handleError)
      }
    function registerGet(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');

        if (!AuthService.isAuth()) {
            ctx.loadPartials({
                footer: './templates/common/footer.hbs',
                nav: './templates/common/nav.hbs',
            })
                .then(function () {
                    this.partial('./templates/user/register.hbs');
                })
               .catch(NotifyService.handleError)
        } else {
            ctx.redirect('#/home');
        }
    }
    function registerPost(ctx) {
            AuthService.register(ctx.params)
                .then((userInfo) => {
                    AuthService.saveSession(userInfo);
                    NotifyService.showInfo(SUCCESSFUL_REGISTRATION);
                    ctx.redirect('#/home');
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
            .catch(NotifyService.handleError);
    }
    return {
        loginGet,
        registerGet,
        loginPost,
        registerPost,
        logout,
    }
})();