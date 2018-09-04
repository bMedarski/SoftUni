let AuthService = (() => {
    function isAuth() {
        return sessionStorage.getItem('authtoken') !== null;
    }

    function saveSession(userData) {
        sessionStorage.setItem('authtoken', userData._kmd.authtoken);
        sessionStorage.setItem('username', userData.username);
        sessionStorage.setItem('userId', userData._id);
    }
    function register(params) {
        let username = params.username;
        let password = params.password;
        let repeatPass = params.repeatPass;
        let email = params.email;
        let avatarUrl = params.avatarUrl;
        let user = {
            username,
            password,
            repeatPass,
            email,
            avatarUrl
        };
        user = validatorService.validateRegisterFields(user);

        if (user.error === undefined) {
            let obj = {username, password,email,avatarUrl};
            return kinveyService.post('user', '', 'basic', obj);
        } else {
            return Promise.reject(user.error)
        }
    }
    function login(params) {
        let username = params.username;
        let password = params.password;
        let user = {username, password};
        user = validatorService.validateUser(user);
        if (user.error === undefined) {
            return kinveyService.post('user', 'login', 'basic', user)
        } else {
            return Promise.reject(user.error)
        }
    }

    function logout() {
        return kinveyService.post('user', '_logout', 'kinvey');
    }
    function getUser(id) {
        return kinveyService.get('user',`${id}`,'kinvey')
    }
    function deleteUser(id) {
        return kinveyService.remove('user',`${id}`,'kinvey')
    }
    return {
        isAuth,
        login,
        logout,
        register,
        saveSession,
        getUser,
        deleteUser
    }
})();