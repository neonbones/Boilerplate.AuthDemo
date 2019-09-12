import { postsConstants as c } from '../constants/posts.constants';

const posts = (state = {}, action) => {
    switch(action.type){
        case c.POSTS_GETALL_REQUEST: return { loading: true };
        case c.POSTS_GETALL_SUCCESS: return { items: action.posts, loading: false };
        default: return state;
    }
}

export default posts;