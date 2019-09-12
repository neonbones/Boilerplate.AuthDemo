import { post } from './crud.service';

const login = async (username, password) => await post('authorize', { username, password });

export const authService = {
    login
};
