import React from 'react';
import './styles.css'

export const CardForm = (props) =>
    <div className="card-form card-default scrollspy white z-depth-2 s1">
        {props.children}
    </div>

export const CardGrid = (props) =>
    <div className="container table-card white z-depth-2 s1">
        {props.children}
    </div>

export const CardContent = (props) =>
    <div className={`${props.type ? props.type + "-" : ''}card-content`}>
        {props.children}
    </div>

export const CardTitle = (props) =>
    <h4 className={`${props.type ? props.type + "-" : ''}card-title`}>
        {props.title}
    </h4>

export const CardWrapper = (props) =>
    <div className="container" style={{ width: `${props.width}%` }}>
        {props.children}
    </div>