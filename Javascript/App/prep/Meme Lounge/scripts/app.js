$(() => {
    const app = Sammy('#container', function () {
        this.use('Handlebars', 'hbs');

        this.get('#/home', homeController.showIndexPage);
        this.get('index.html', homeController.showIndexPage);

        this.get('#/register',userController.registerGet);
        this.post('#/register', userController.registerPost);
        this.get('#/login',userController.loginGet);
        this.post('#/login', userController.loginPost);
        this.get('#/logout', userController.logout);

        this.get('#/list-all', memesController.listAllMemes);
        this.get('#/list-my', memesController.listMyMemes);

        this.get('#/meme-create',memesController.createGet);
        this.post('#/meme-create',memesController.createPost);

        this.get('#/meme-edit/:id',memesController.editGet);
        this.post('#/meme-edit/:id',memesController.editPost);

        this.get('#/meme-delete/:id',memesController.deleteGet);
        //this.get('#/meme-delete/profile/:id',memesController.deleteGetProfile);
        this.get('#/meme-details/:id',memesController.detailsGet);

        this.get('#/profile/:id',userController.getUser);
        this.get('#/user-delete',userController.deleteUser);
    });

    app.run();
});