import React from 'react';
import {render} from 'react-dom';
import App from './App';


// stylings
    import 'normalize.css/normalize.css';
    import 'font-awesome/css/font-awesome.css';
    import 'react-mde/lib/styles/react-mde.scss';
    import 'react-mde/lib/styles/react-mde-command-styles.scss';
    import 'react-mde/lib/styles/markdown-default-theme.scss';
    import '../src/styles/markdown-editor.scss';
    import './styles/demo.scss';

render(
    <App>
    </App>,
    document.getElementById('app_container')
);