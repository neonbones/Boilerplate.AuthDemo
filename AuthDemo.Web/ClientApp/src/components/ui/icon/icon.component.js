import React from 'react';
import { Icon as I } from 'react-materialize';

export const Icon = (props) =>
    <I className={props.color + "-text"}>{props.icon}</I>

