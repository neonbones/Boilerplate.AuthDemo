import { get } from './crud.service';

const getAll = async () => await get('Administrator/Posts');

export const postsService = {
    getAll
}

 