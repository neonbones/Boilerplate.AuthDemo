import React from 'react';
import Footer from '../footer/footer.component';
import Navigation from '../navigation/navigation.component';
import './styles.css';

const Layout = (props) => (
    <div className="site">
        <Navigation /> 
            <div className="content-wrapper">
                {props.children}
            </div>
        <Footer />
    </div>
)

export default Layout; 
