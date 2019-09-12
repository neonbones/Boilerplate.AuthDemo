import React, { Component } from 'react';
import { Router, Route } from 'react-router-dom';
import { connect } from 'react-redux';
import history from '../redux/helpers/history'
import Layout from '../components/ui/layout/layout.component';
import Guard from '../components/crosscutting/guard/guard.component';
import HomePage from '../containers/home/home.page';
import LoginPage from '../containers/login/login.page';

class App extends Component {
    render() {
        return (
            <Router history={history}>
                <Layout>
                    <Guard exact path='/' component={HomePage} />
                    <Route path='/SignIn' component={LoginPage} />
                </Layout>
            </Router>
        );
    }
}



export default connect()(App);