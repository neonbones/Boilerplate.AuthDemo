import React from 'react';

export const Label = (props) =>
    <label htmlFor={props.id}>{props.label}</label>

export const FormField = (props) =>
    <div className="row">
        <div className="input-field col s12">
            {props.children}
        </div>
    </div>