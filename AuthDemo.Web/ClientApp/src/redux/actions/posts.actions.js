import { postsService as s } from '../services';
import { postsConstants as c } from '../constants';

const getAll = () => dispatch => {
    dispatch(request());

    s.getAll()
        .then(
            data => {
                dispatch(success(data))
            },
            error => {
            }
        )
}

const request = () => { return { type: c.POSTS_GETALL_REQUEST } };
const success = (posts) => { return { type: c.POSTS_GETALL_SUCCESS, posts } };

export const postsActions = {
    getAll
}
