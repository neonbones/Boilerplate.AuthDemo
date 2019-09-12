import * as Yup from 'yup';

const rules = {
    username: Yup.string().required('Username обязателен'),
    password: Yup.string().required('Password обязателен')
}

export default rules;