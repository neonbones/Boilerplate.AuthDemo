const buildForm = (schema) => {
    const formArray = [];
    for(let id in schema)
        formArray.push({id,value: schema[id]});   
    return formArray;
}

export const extensions = {
    buildForm
}