import React, { Component } from 'react';
import { connect } from 'react-redux';
import { CardWrapper, CardForm, CardContent, CardTitle, types } from '../../components/ui/cards';
import { Formik } from 'formik';
import { Form } from '../../components/ui/form/form.component';
import { authActions as a } from '../../redux/actions';
import schema from './login.schema';
import rules from '../../validation/yup.validation';
import './styles.css';
import * as Yup from 'yup';

class LoginPage extends Component {
    state = {
        schema
    };

    renderLoader() {
        const { loading } = this.props;
        return (
            loading
                ? <div className="progress signin-loader">
                    <div className="indeterminate" />
                </div>
                : <div className="signin-loader-wrapper" />
        );
    }

    onSubmit = (username, password) => {
        console.log({ username, password })
    }

    render() {
        const { schema } = this.state;
        const { login } = this.props;
        return (
            <CardWrapper width="30">
                <CardForm>
                    <CardContent type={types.form}>
                        <CardTitle type={types.form} title="Sign In" />
                        <Formik
                            initialValues={{ username: '', password: '' }}
                            validationSchema={Yup.object().shape({
                                username: rules.username,
                                password: rules.password
                            })}
                            onSubmit={({ username, password }) => { login(username, password) }}
                            render={({ errors, touched }) => (
                                <Form errors={errors} touched={touched} schema={schema} />
                            )}
                        />
                    </CardContent>
                </CardForm>
                {this.renderLoader()}
            </CardWrapper>
        );
    }
}

const mapStateToProps = (state) => {
    const { loading } = state.auth;
    return {
        loading
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        logout: () => {
            dispatch(a.logout());
        },
        login: (username, password) => {
            dispatch(a.login(username, password));
        }
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(LoginPage);