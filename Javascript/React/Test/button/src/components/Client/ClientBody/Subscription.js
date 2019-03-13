import React from 'react';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Switch from '@material-ui/core/Switch';
import { withStyles } from '@material-ui/core/styles';
import okIcon from './onIcon.jpg';

const styles = theme => ({
    root:{
        padding:0,
        margin:10,
    },
    label:{
        color:"#3DB29F",
    },
    // colorPrimary:{
    //     color:"#3DB29F",
    // },
    colorSecondary:{
        color:"#3DB29F",
        '& + $iOSBar': {
            backgroundColor: '#546A78',
        },
    },
    iOSSwitchBase: {
        '&$iOSChecked': {
            color: "#3DB29F",
            '& + $iOSBar': {
                backgroundColor: '#546A78',
            },
        },
        transition: theme.transitions.create('transform', {
            duration: theme.transitions.duration.shortest,
            easing: theme.transitions.easing.sharp,
        }),
    },
    iOSChecked: {
        transform: 'translateX(25px)',
        '& + $iOSBar': {
            opacity: 1,
            border: 'none',
        },
    },
    iOSBar: {
        borderRadius: 13,
        width: 52,
        height: 26,
        marginTop: -13,
        marginLeft: -21,
        border: 'solid 1px',
        borderColor: theme.palette.grey[400],
        backgroundColor:okIcon,
        opacity: 1,
        transition: theme.transitions.create(['background-color', 'border']),
    },
    iOSIcon: {
        width: 24,
        height: 24,
    },
    iOSIconChecked: {
        boxShadow: theme.shadows[1],
        backgroundColor: okIcon,
    },
});


class Subscription extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            checkedB: true,
        };
    }


    handleChange = name => event => {
        this.setState({ [name]: event.target.checked });
    };

    render() {
        const { classes } = this.props;

        return (
            <li>
                <FormControlLabel
                    control={
                        <Switch
                            classes={{
                                switchBase: classes.iOSSwitchBase,
                                bar: classes.iOSBar,
                                icon: okIcon,
                                iconChecked: classes.iOSIconChecked,
                                checked: classes.iOSChecked,
                                root:classes.root,
                                colorPrimary:classes.colorPrimary,
                                colorSecondary:classes.colorSecondary,
                            }}
                            disableRipple
                            checked={this.state.checkedB}
                            onChange={this.handleChange('checkedB')}
                            value="checkedB"
                        />
                    }
                    label={this.props.subscription}
                />
            </li>
        )
    }
}
export default withStyles(styles)(Subscription);