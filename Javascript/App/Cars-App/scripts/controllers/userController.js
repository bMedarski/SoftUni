let userController = (() => {
    function loginGet(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        if (!AuthService.isAuth()) {
            ctx.loadPartials({
                footer: './templates/partials/footer.hbs',
                navigation: './templates/partials/navigation.hbs',
            })
                .then(function () {
                    this.partial('./templates/common/login.hbs');
                })
                // .catch(NotifyService.handleError)
        } else {
            ctx.redirect('#/home');
        }
    }
    function loginPost(ctx) {
          AuthService.login(ctx.params)
              .then((userInfo) => {
                  AuthService.saveSession(userInfo);
                  NotifyService.showInfo(SUCCESSFUL_LOGIN);
                  ctx.redirect('#/cars/list');
              })
        // .catch(NotifyService.handleError)
      }
    function registerGet(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');

        if (!AuthService.isAuth()) {
            ctx.loadPartials({
                footer: './templates/partials/footer.hbs',
                navigation: './templates/partials/navigation.hbs',
            })
                .then(function () {
                    this.partial('./templates/common/register.hbs');
                })
                // .catch(NotifyService.handleError)
        } else {
            ctx.redirect('#/home');
        }
    }
    function registerPost(ctx) {
            AuthService.register(ctx.params)
                .then((userInfo) => {
                    AuthService.saveSession(userInfo);
                    NotifyService.showInfo(SUCCESSFUL_REGISTRATION);
                    ctx.redirect('#/cars/list');
                })
        // .catch(NotifyService.handleError)
        }
    function logout(ctx) {
        AuthService.logout()
            .then(() => {
                sessionStorage.clear();
                NotifyService.showInfo(SUCCESSFUL_LOGOUT);
                ctx.redirect('#/home')
            })
            // .catch(NotifyService.handleError);
    }
    return {
        loginGet,
        registerGet,
        loginPost,
        registerPost,
        logout,
    }
})();