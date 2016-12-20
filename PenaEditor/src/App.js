import React, {Component} from 'react';
import './App.css';
import Pena from './Pena';

class App extends Component {
    render() {
        return (
            <div className="App">
                <div className="editor-wrapper">
                    <Pena/>
                </div>
            </div>
        );
    }
}

export default App;
