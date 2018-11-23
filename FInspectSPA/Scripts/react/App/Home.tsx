// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX
import * 
var HelloWorld = React.createClass({
    render: function () {
        return (
            <div> Hello {this.props.name} </div>
        );
    }
});

React.render(
    <HelloWorld name="world" />,
    document.getElementById('reactApp')
);