/**
 * Evaluates the given expression for the given object. Returns the given defaultValue if there's an error.
 * This is useful when you want to read a long expression line a.b.c.d.e... without caring whether or not any of the parts are null
 * @param expression
 * @param object
 * @param defaultValue
 * @returns {*}
 */
export function safeRead(expression, object, defaultValue) {
    if (!expression) throw Error('\'expression\' should be truthy');
    if (!object) throw Error('\'object\' should be truthy');

    try {
        return expression(object);
    }
    catch(ex) {
        return defaultValue;
    }
}