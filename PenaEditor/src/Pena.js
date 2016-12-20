import React from 'react';
import getCaretCoordinates from 'textarea-caret';

class Pena extends React.Component {

    componentDidMount() {
        this.refs.ta.addEventListener('input', function() {
            var coordinates = getCaretCoordinates(this, this.selectionEnd);
            console.log(coordinates.top);
            console.log(coordinates.left);
            console.log(this.selectionStart);
        });



    }

    render() {
        return (
            <div>
                <textarea ref="ta"></textarea>
            </div>
        );
    }
}

export default Pena;