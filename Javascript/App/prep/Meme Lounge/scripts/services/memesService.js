let memesService = (() => {

    function listAllMemes() {
        const endpoint = `memes?query={}&sort={"_kmd.ect": -1}`;
        return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
    }
    function getMeme(id) {
        const endpoint = `memes/${id}`;
        return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
    }
    function createMeme(meme) {
            const endpoint = `memes`;
            let data = {
                "title": meme.title,
                "description":meme.description,
                "imageUrl":meme.imageUrl,
                "creator": sessionStorage.getItem("username"),
            };
           data = validatorService.validateMeme(data);
            if (data.error=== undefined){
                return kinveyService.post(APP_DATA, endpoint, AUTH_METHOD, data);
            }
            else {
                return Promise.reject(data.error)
            }
        }
    function editMeme(meme) {
            const endpoint = `memes/${meme.id}`;
            let data = {
                "title": meme.title,
                "description":meme.description,
                "imageUrl":meme.imageUrl,
                "creator": sessionStorage.getItem("username"),
                };
            data = validatorService.validateMeme(data);
            if (data.error=== undefined){
                return kinveyService.update(APP_DATA, endpoint, AUTH_METHOD, data);
            }
            else {
                return Promise.reject(data.error)
            }
        }
    function deleteMeme(id) {
        const endpoint = `memes/${id}`;
            return kinveyService.remove(APP_DATA, endpoint, AUTH_METHOD);
        }
    function listMyMemes(username) {
            const endpoint = `memes?query={"creator":"${username}"}&sort={"_kmd.ect": -1}`;
            return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
        }

    return {
        listAllMemes,
        getMeme,
        createMeme,
        editMeme,
        deleteMeme,
        listMyMemes,

    }
})
();