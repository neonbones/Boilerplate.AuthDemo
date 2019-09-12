import React from 'react';
import { Field, ErrorMessage, Form as F } from 'formik';
import { Button, types } from '../button';
import { Label, FormField } from './form.elements';
import { extensions as e } from './form.extensions';

export const Form = (props) => {
    const renderFields = () =>       
        e.buildForm(props.schema).map((item, i) => 
            <FormField key={i}>
                <Field name={item.id} type={item.value.config.type} className={(props.errors[item.id] && props.touched[item.id] && 'invalid')} />
                <Label id={item.id} label={item.value.label} />
                <ErrorMessage name={item.id} component="span" className="red-text helper-text" />
            </FormField>
        );  
        
    const renderButton = () =>
        <FormField>
            <Button type={types.submit} title='submit' icon='send' />
        </FormField>

    return (
        <F>
            {renderFields()}
            {renderButton()}
        </F>);
}