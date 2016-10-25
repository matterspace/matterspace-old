const ADD_PROJECT = 'ADD_Project';

export const addProject = (projectName) => ({
    type: ADD_PROJECT,
    projectName: projectName
});