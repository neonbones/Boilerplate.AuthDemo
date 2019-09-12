import React, { Component } from 'react';
import { Navbar } from 'react-materialize'
import { Link } from 'react-router-dom';
import './styles.css';

class Navigation extends Component {

    render() {
        return (
            <Navbar brand={<Link to='/'>Client App</Link>} centerLogo alignLinks="right">
                <ul>
                    <li>
                        <Link className="nav-link" to='/SignIn'>Sign In</Link>
                    </li>
                </ul>              
            </Navbar>
        );
    }
}

export default Navigation; 
