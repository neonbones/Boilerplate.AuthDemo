import React, { Component } from 'react';
import { gridExtensions as ex } from './grid.extensions';
import { Link } from 'react-router-dom';
import { Table } from 'react-materialize';
import { CardTitle, CardGrid } from '../cards'
import { Icon } from '../icon/icon.component';
import { Button, types as ButtonTypes } from '../button';
import './styles.css';

class Grid extends Component {
    renderTHead = () =>
        <thead>
            <tr style={{borderBottom: `1px solid rgba(0,0,0,0.12)`}}>
                {this.renderHead()}
                {this.props.schema.actions.show &&
                    <th style={{ width: `${this.props.schema.actions.width}%`, textAlign: `right` }}>
                        {this.props.schema.actions.name}
                    </th>
                }
            </tr>
        </thead>

    renderHead = () =>
        ex.buildHead(this.props.schema.columns).map((item) =>
            <th key={item.id} style={{ width: `${item.value.width}%` }}>
                {item.value.name}
            </th>
        );

    renderTBody = () =>
        <tbody>
            {this.props.data.map((item, i) => 
                <tr key={i}>
                    {this.renderItem(item)}
                </tr>)}
        </tbody>

    renderItem(item) {
        const columns = ex.buildColumns(this.props.schema.columns);
        const rows = ex.buildRows(columns, item, this.props.schema.actions);
        const id = item.id;

        return rows.map((item, i) => {
            switch (item.value) {
                case 'actions': return this.renderActions(this.props.schema.actions, id);
                default: return this.renderDefault(item);
            }
        });
    }

    renderDefault = (item) =>
        <td key={item.key}>
            <div>{item.value}</div>
        </td>

    renderActions = (actions, id) =>
        <td key={id} style={{ textAlign: `right`}}>
            <Link to={`${actions.preview}/${id}`} ><Icon icon="insert_photo" color="pink" /></Link>
            <Link to={`${actions.edit}/${id}`} ><Icon icon="edit" color="pink" /></Link>
            <Link to={`${actions.delete}/${id}`} ><Icon icon="clear" color="pink" /></Link>
        </td>

    renderTable = () =>
        !this.props.loading &&
        <Table className={this.props.schema.type}>
            {this.renderTHead()}
            {this.renderTBody()}
        </Table>

    renderTitle = () =>
        <div className="row" style={{ marginBottom: 0 }}>
            <div className="col s10" style={{ padding: 0 }}>
                <CardTitle title={this.props.schema.title} />
            </div>
            {this.props.schema.search && this.renderSearch()}
        </div>

    renderButton = () =>
        this.props.schema.create.show &&
        <center>
            <Button type={ButtonTypes.link}
                title={this.props.schema.create.title}
                style={{margin: 15}}
                icon='plus_one'
                link={this.props.schema.create.link}
            />
        </center>

    render = () =>
        <CardGrid>
            {this.renderTitle()}
            {this.renderTable()}
            {this.renderButton()}
        </CardGrid>
}

export default Grid;