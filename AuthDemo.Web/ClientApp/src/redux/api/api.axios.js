import axios from "axios";
import messages from '../resources/messages';

const api = axios.create({ baseURL: process.env.REACT_APP_API_URL });

api.interceptors.request.use(request => requestInterceptor(request));

api.interceptors.response.use(
    response => successHandler(response),
    error => errorHandler(error)
)

const requestInterceptor = (request) => {
    request.withCredentials = true;
    return request;
}

const successHandler = (response) => {
    return new Promise((resolve, reject) => {
        if (response.status === 200) {
            resolve(response.data)
        }
    });
}

const errorHandler = (error) => {
    return new Promise((resolve, reject) => {
        // TODO: Обрабатывайте тут свои ошибки

        console.log(error)
        if (error.response.status === 400) {
            return reject(messages[error.response.data.subStatus])
        }
        if (error.response.status === 401 || error.response.status === 403) {
            if ([401, 403].indexOf(error.response.status) !== -1) {
                //authActions.logout();         
            }
            reject();
        }

        return reject();
    })
}

export default api;