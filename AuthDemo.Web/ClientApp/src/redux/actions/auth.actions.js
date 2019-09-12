import { authConstants as c } from '../constants';
import { authService as s } from '../services';
import history from '../helpers/history';

const login = (username, password) => {
    return dispatch => {
        dispatch(request({ username }));

        s.login(username, password)
            .then(
                auth => {
                    localStorage.setItem('auth', auth);
                    dispatch(success(auth));
                    history.push('/');               
                },
                error => {
                    history.push('/SignIn'); 
                    dispatch(failure());
                }
            );
    };
};

const logout = dispatch => {
    localStorage.removeItem('auth');
    dispatch(logoutReq());
}

const request = (auth) => { return { type: c.LOGIN_REQUEST, auth }; }
const success = (auth) => { return { type: c.LOGIN_SUCCESS, auth }; }
const failure = () => { return { type: c.LOGIN_FAILURE }; }
const logoutReq = () => { return { type: c.LOGOUT }; }

export const authActions = {
    login,
    logout
};
