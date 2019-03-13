import React, {Component} from 'react';
import Switch from 'react-toggle-switch'

class MyButton extends Component {
  constructor(props) {
    super(props);
    this.state = {
      switched: true
    };
  }

  toggleSwitch = () => {
    this.setState(prevState => {
      return {
        switched: !prevState.switched
      };
    });
  };

  render() {
    return (
        <div>
            {/* Basic Switch */}
            <Switch onClick={this.toggleSwitch} on={this.state.switched}/>

            {/* With children */}
            <Switch onClick={this.toggleSwitch} on={this.state.switched}>
              text
            </Switch>

            {/* Disabled */}
            <Switch onClick={this.toggleSwitch} on={this.state.switched} enabled={false}/>

            {/* Custom classnames */}
            <Switch onClick={this.toggleSwitch} on={this.state.switched} className='other-class' style={{color:"#000"}}/>
        </div>
    );
  }

}

export default MyButton;