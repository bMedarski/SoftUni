let userController = (() => {
    function login(ctx) {
        AuthService.login(ctx.params)
            .then((userInfo) => {
                AuthService.saveSession(userInfo);
                NotifyService.showInfo(SUCCESSFUL_LOGIN);
                ctx.redirect('#/activeReceipt');
            }).catch(NotifyService.handleError);
    }
    function register(ctx) {
        AuthService.register(ctx.params)
            .then((userInfo) => {
                AuthService.saveSession(userInfo);
                NotifyService.showInfo(SUCCESSFUL_REGISTRATION);
                ctx.redirect('#/activeReceipt');
            })
            .catch(NotifyService.handleError);
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
        login,
        register,
        logout
    }
})();