import React, { Component, PropTypes } from 'react';
import { ReactMde, ReactMdeCommands } from 'react-mde';

const propTypes = {
    textareaId: PropTypes.string.isRequired,
    textareaName: PropTypes.string.isRequired,
    initialValue: PropTypes.string
};

class MarkdownEditor extends Component {

    constructor(props) {
        super(props);

        let { initialValue } = props;

        this.state = {
            mdeValue: { text: initialValue, selection: null }
        }
    }

    handleValueChange(value) {
        this.setState({ mdeValue: value });
    }

    render() {
        let { textareaId, textareaName } = this.props;
        let commands = ReactMdeCommands.getDefaultCommands();
        return (
            <div className="markdown-editor">
                <ReactMde
                    textareaId={textareaId}
                    textareaName={textareaId}
                    value={this.state.mdeValue}
                    onChange={this.handleValueChange.bind(this)}
                    commands={commands} />
            </div>
        );
    }
}

MarkdownEditor.propTypes = propTypes;

export default MarkdownEditor;