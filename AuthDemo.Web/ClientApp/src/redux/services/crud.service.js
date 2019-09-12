import api from '../api/api.axios';

export const get = async (url, config = {}) => await api.get(url, config)

export const post = async (url, payload, config = {}) => await api.post(url, payload, config)