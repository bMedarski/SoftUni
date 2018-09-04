let memesController = (() => {
    async function listAllMemes(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.userId = sessionStorage.getItem('userId');
        ctx.username = sessionStorage.getItem('username');
        await memesService.listAllMemes()
            .then((memes)=>{
                ctx.memes = memes;
                if(memes.length ===0){
                    ctx.noMemes = true;
                }
                for(let i = 0; i < memes.length;i++){
                    ctx.memes[i].id = memes[i]._id;
                    ctx.memes[i].creatorId = memes[i]._acl.creator;
                    if(memes[i].creator===sessionStorage.getItem('username')){
                        ctx.memes[i].author = true;
                    }
                }
            });
        ctx.loadPartials({
            footer: './templates/partials/footer.hbs',
            nav: './templates/partials/nav.hbs',
        }).then(function () {
            this.partial('./templates/memes/list-all.hbs');
        })
    }
    async function detailsGet(ctx) {
        ctx.isAuth = AuthService.isAuth();
        let username = sessionStorage.getItem('username');
        ctx.username = username;
        ctx.userId = sessionStorage.getItem('userId');
        let memeId = ctx.params.id;
        await memesService.getMeme(memeId).then((meme)=>{
            ctx.title = meme.title;
            ctx.description = meme.description;
            ctx.imageUrl = meme.imageUrl;
            ctx.creator = meme.creator;
            ctx.creatorId = meme._acl.creator;
            ctx.id = memeId;
            if(meme.creator===username){
                ctx.author = true;
            }
        });
        ctx.loadPartials({
            footer: './templates/partials/footer.hbs',
            nav: './templates/partials/nav.hbs',
        }).then(function () {
            this.partial('./templates/memes/details.hbs');
        })
    }

    function createGet(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        ctx.userId = sessionStorage.getItem('userId');
        ctx.loadPartials({
            footer: './templates/partials/footer.hbs',
            nav: './templates/partials/nav.hbs',
        }).then(function () {
            this.partial('./templates/memes/create.hbs');
        })
    }

    function createPost(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        ctx.userId = sessionStorage.getItem('userId');
        memesService.createMeme(ctx.params).then(()=>{
            NotifyService.showInfo(MEME_CREATED);
            ctx.redirect('#/list-all');
        })
            .catch(NotifyService.handleError)}

    async function editGet(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        ctx.userId = sessionStorage.getItem('userId');
        let memeId = ctx.params.id;
        await memesService.getMeme(memeId).then((meme)=>{
            ctx.title = meme.title;
            ctx.description = meme.description;ctx.imageUrl = meme.imageUrl;
            ctx.creator = meme.creator;
            ctx.id = memeId;
        });
        ctx.loadPartials({
            footer: './templates/partials/footer.hbs',
            nav: './templates/partials/nav.hbs',
        }).then(function () {
            this.partial('./templates/memes/edit.hbs');
        })
    }
    function editPost(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        ctx.userId = sessionStorage.getItem('userId');
        memesService.editMeme(ctx.params).then((meme)=>{
            let msg = `Meme ${meme.title} updated`;
            NotifyService.showInfo(msg);
            ctx.redirect('#/list-all');
        }).catch(NotifyService.handleError)
    }
    function deleteGet(ctx) {
            ctx.isAuth = AuthService.isAuth();
            ctx.username = sessionStorage.getItem('username');
            let memeId = ctx.params.id;
            memesService.deleteMeme(memeId).then(()=>{
                NotifyService.showInfo(MEME_DELETED);
                ctx.redirect('#/list-all');
            })
        }
    // async function deleteGetProfile(ctx) {
    //     ctx.isAuth = AuthService.isAuth();
    //     ctx.username = sessionStorage.getItem('username');
    //     let userId = sessionStorage.getItem('userId');
    //     let memeId = ctx.params.id;
    //     await memesService.deleteMeme(memeId).then(()=>{
    //         NotifyService.showInfo(MEME_DELETED)
    //     });
    //     ctx.redirect(`#/profile/:${userId}`);
    //     }
    return {
        listAllMemes,
        createGet,
        createPost,
        editGet,
        editPost,
        deleteGet,
        detailsGet,
        //deleteGetProfile
    }
})
();