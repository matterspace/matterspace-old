import React, { Component } from 'react';
import MarkdownEditor from '../src/MarkdownEditor';

class App extends Component {

    render() {
        return (
            <div className="container">
                <MarkdownEditor
                    initialValue="This is some initial value"
                    textareaId="ta1"
                    textareaName="ta1"
                    />
            </div>
        );
    }
}

export default App;