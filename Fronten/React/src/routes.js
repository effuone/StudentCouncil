import Home from "./pages/Home"
import About from "./pages/About"
import Members from "./pages/Members"
import Departments from "./pages/Departments"
import Projects from "./pages/Projects"
import {
    HOME_ROUTE, ABOUT_ROUTE, MEMBERS_ROUTE,
    PROJECTS_ROUTE, DEPARTMENTS_ROUTE
} from "./utils/consts"

export const publicRoutes = [
    {
        path: HOME_ROUTE,
        component: Home
    },
    {
        path: ABOUT_ROUTE,
        component: About
    },
    {
        path: MEMBERS_ROUTE,
        component: Members
    },
    {
        path: PROJECTS_ROUTE,
        component: Projects
    },
    {
        path: DEPARTMENTS_ROUTE,
        component: Departments
    }
]