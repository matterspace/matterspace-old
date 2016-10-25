import React from 'react';
import App from '../containers/App';
import Home from '../containers/Home';
import Login from '../containers/Login';

import { Route, IndexRoute } from 'react-router';

export default (
    <Route>
        <Route name='app' path='/' component={App}>
            <IndexRoute component={Home}/>
        </Route>
        <Route name='login' path='/login' component={Login}/>
    </Route>
);
