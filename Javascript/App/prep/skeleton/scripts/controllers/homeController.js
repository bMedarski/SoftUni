let homeController = (() => {

    function showIndexPage(ctx) {

        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        if (!AuthService.isAuth()) {
            ctx.loadPartials({
                footer: './templates/partials/footer.hbs',
                navigation: './templates/partials/navigation.hbs',
            }).then(function () {
                this.partial('./templates/home.hbs');
            })
                // .catch(NotifyService.handleError)
        } else {
            ctx.redirect('#/cars/list');
        }
    }
    return {
        showIndexPage
    }
})();