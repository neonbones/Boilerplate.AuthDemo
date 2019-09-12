import React, { Component } from 'react';
import { connect } from 'react-redux';
import { postsActions as actions } from '../../redux/actions';
import Grid from '../../components/ui/grid/grid.component';
import schema from './home.schema';

class HomePage extends Component {
    state = { schema, loading: true};

    componentDidMount() {
        this.props.getAll();
    }

    componentDidUpdate(prevProps) {
        const { loading } = this.props;
        if (prevProps.loading !== loading)
            this.setState({ loading });
    }

    render() {
        const { schema, loading } = this.state;
        const { posts } = this.props;
        return (
            <div>
                {
                    loading
                        ? <p>Loading</p>
                        : <Grid data={posts.items} schema={schema} />
                }
            </div>
        );
    }
}


const mapStateToProps = (state) => {
    const { posts } = state;
    const { loading } = posts;
    return { posts, loading };
}

const mapDispatchToProps = (dispatch) => {
    return { getAll: () => { dispatch(actions.getAll()); } };
}


export default connect(mapStateToProps, mapDispatchToProps)(HomePage);

