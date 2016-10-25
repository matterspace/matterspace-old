import React, {Component} from 'react';

class Login extends Component {

    render() {
        return <div className="container">
            <div className="form-signin">
                <h2 className="form-signin-heading">Please sign in</h2>
                <a className="btn btn-block btn-social btn-google" href="/auth/google">
                    <i className="fa fa-google"></i> Sign in with Google
                </a>
            </div>
        </div>
    }
}

export default Login;