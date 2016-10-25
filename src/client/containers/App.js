import React, { Component } from 'react';
import DevTools from '../components/DevTools';

class App extends Component {
    render() {
        return (
            <div>
                {this.props.children}
                <DevTools />
            </div>
        );
    }
}

export default App;