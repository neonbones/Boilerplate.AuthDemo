import React from 'react';
import { Route, Redirect } from 'react-router-dom';

const Guard = ({ component: Component, roles, ...rest }) => (
    <Route {...rest} render={props => {
        var auth = localStorage.getItem('auth')

        if(!auth)
            return <Redirect to={{ pathname: '/SignIn' }} /> 

        return <Component {...props} />}}
    />
)

export default Guard;