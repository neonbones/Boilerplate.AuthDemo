import { combineReducers } from 'redux';
import posts from './posts.reducer';
import auth from './auth.reducer';

const rootReducer = combineReducers({
    posts,
    auth,
});

export default rootReducer;