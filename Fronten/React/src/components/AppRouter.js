import React from 'react';
import { Redirect, Switch } from 'react-router-dom';
import { Route } from 'react-router-dom';
import { publicRoutes } from "../routes";
import { HOME_ROUTE } from '../utils/consts';
import Home from '../pages/Home';

const AppRouter = () => {
    return (
        <Switch>
            {publicRoutes.map(({ path, component }) =>
                <Route key={path} path={path} component={component} exact />
            )}
            <Redirect to={HOME_ROUTE} />
        </Switch>
    );
}

export default AppRouter;
