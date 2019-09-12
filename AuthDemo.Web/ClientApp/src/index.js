import React from 'react';
import App from './app/app.component';
import store from './redux/store/redux.store';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import './resources/styles.css';

render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.getElementById('app')
);