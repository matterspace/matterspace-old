import React, {Component} from 'react';
import {Router} from 'react-router'
import routes from './routes/Routes';
import configureStore from './redux/store/Store';
import {Provider} from 'react-redux';
import {syncHistoryWithStore} from 'react-router-redux';
import {browserHistory} from 'react-router'
import ReactDOM from 'react-dom';
import injectTapEventPlugin from 'react-tap-event-plugin';

import './styles/app.scss';

injectTapEventPlugin();

const Client = ({store, history}) => (
    <Provider store={store}>
        <Router history={history} routes={routes}/>
    </Provider>
);

const getMountPoint = () => {
    return document.getElementById("app");
};

ReactDOM.render(
    <Client
        store={configureStore()}
        history={syncHistoryWithStore(browserHistory, configureStore())}
    />,
    getMountPoint()
);