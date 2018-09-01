let homeController = (() => {
    function showIndexPage(ctx) {
        ctx.isAuth = AuthService.isAuth();
                ctx.username = sessionStorage.getItem('username');
                if (!AuthService.isAuth()) {
                    ctx.loadPartials({
                        footer: './templates/partials/footer.hbs',
                        nav: './templates/partials/nav.hbs',

                    }).then(function () {
                        this.partial('./templates/home.hbs');
                    })
                } else {
                    ctx.redirect('#/activeReceipt');
                }
    }
    return {
      showIndexPage
    }
})();