import { types } from '../../components/ui/grid/grid.types';

const schema = {
    title: 'Posts',
    type: types.highlight,
    columns: {
        title: { name: 'Title', width: 35 },
        content: { name: 'Content', width: 40 }
    },
    create: {
        show: true,
        title: 'Create',
        link: 'Posts/Create',
    },
    actions: {
        show: true,
        width: 20,
        name: 'Actions',       
        preview: 'Posts/Preview',
        delete: 'Posts/Delete',
        edit: 'Posts/Edit'
    },
    search: false
}

export default schema;