import { authConstants as c } from '../constants';

let authUser = localStorage.getItem('auth');

const initialState = authUser
    ? { loggedIn: true, authUser }
    : {};

const auth = (state = initialState, action) => {
    switch (action.type) {
        case c.LOGIN_REQUEST: return { loggedIn: false, loading: true, user: action.user };
        case c.LOGIN_SUCCESS: return { loggedIn: true, loading: false, user: action.user };
        case c.LOGIN_FAILURE: return { loggedIn: false, loading: false };
        case c.LOGOUT: return {};
        default: return state;
    }
}

export default auth;