$(() => {
    const app = Sammy('#container', function () {
        this.use('Handlebars', 'hbs');

        this.get('#/home', homeController.showIndexPage);
        this.get('index.html', homeController.showIndexPage);

        this.post('#/register', userController.register);
        this.post('#/login', userController.login);
        this.get('#/logout', userController.logout);

        this.get('#/activeReceipt', receiptController.showActiveReceipt);

        //this.get('#/catalog', PostController.viewCatalog);
        //
        //
        //this.get('#/post/create', PostController.showCreatePost);
        this.post('#/addNewEntry', entriesController.addNewEntry);
        //
        //this.get('#/post/edit/:id', PostController.showEditPost);
        //this.post('#/post/edit', PostController.handleEditPost);
        //
        //this.get('#/post/delete/:id', PostController.deletePost);
        //
        //this.get('#/details/:id', PostController.showPostDetails);
        //
        //this.get('#/posts', PostController.showOwnPosts);
        //
        //this.get('#/post/:postId/comment/:commentId/delete', CommentController.deleteComment);
        //
        //this.post('#/post/comment', CommentController.addComment)


    });

    app.run();
});