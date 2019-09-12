import React from 'react';
import { types } from './button.types';
import { Link } from 'react-router-dom';
import './styles.css';

const Button = (props) => {
    switch (props.type) {
        case types.link:
            return (
                <Link to={props.link} className={"waves-effect waves-dark btn btn-primary cyan"} style={props.style}>
                    {props.title ? props.title : 'Link'} <i className="material-icons right">{props.icon ? props.icon : 'done'}</i>
                </Link>)
        case types.submit:
            return (
                <div>
                    {props.loading
                        ? <div>
                            <button className="btn cyan waves-effect waves-light right disabled-link" type="submit">
                                {props.title ? props.title : 'Submit'} <i className="material-icons right">{props.icon ? props.icon : 'send'}</i>
                            </button>
                            <div className="progress submit-progress-bar">
                                <div className="indeterminate" />
                            </div>
                        </div>
                        : <button className="btn cyan waves-effect waves-light right" type="submit">
                            {props.title ? props.title : 'Submit'} <i className="material-icons right">{props.icon ? props.icon : 'send'}</i>
                        </button>
                    }
                </div>)
        default:
            return null;
    }
};

export { Button }; 
