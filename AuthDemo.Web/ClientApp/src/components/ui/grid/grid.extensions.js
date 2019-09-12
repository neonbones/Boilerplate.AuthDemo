const buildColumns = (items) =>  {
    let keyCollection = [];
    for(let key in items)
        keyCollection.push({ key: key, hidden: items[key].hidden ? true : false });      
    
    return keyCollection;
}

const buildRows = (keys, item, actions) => {
    let items = [];
    for(let i in keys)
        items.push({ key: keys[i].key, value: item[keys[i].key], hidden: keys[i].hidden})

    if(actions.show)
        items.push({key:'actions', value: 'actions'}); 

    return items;
}

const buildHead = (array) => {
    let output = [];
    for(let key in array){     
        output.push({
            id: key,
            value: array[key]
        });
    }    
    return output;
}

export const gridExtensions = {
    buildColumns,
    buildRows,
    buildHead
}