import React from 'react';
import { render } from 'react-dom';
import MarkdownEditor from './MarkdownEditor';

// stylings
import 'react-mde/lib/styles/react-mde.scss';
import 'react-mde/lib/styles/react-mde-command-styles.scss';
import 'react-mde/lib/styles/markdown-default-theme.scss';
import './styles/markdown-editor.scss';

window._renderMarkdownEditor = function (selector, textareaId, textareaName, initialValue) {
    render(
        <MarkdownEditor textareaId={textareaId} textareaName={textareaName} initialValue={initialValue}>
        </MarkdownEditor>,
        document.querySelector(selector)
    );
}