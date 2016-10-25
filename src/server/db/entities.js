// List of entities so we can promisify them and also truncate them during test
// TODO: There are ways to make this automatically and eliminate the need for this. Do it
export default [
    'notification',
    'project',
    'task',
    'task_comment',
    'user',
    'user_tasks_following',
    'user_workplaces',
    'workplace'
];