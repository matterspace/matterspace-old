import React, { Component, PropTypes } from 'react';
import ArrowLeft from 'material-ui/svg-icons/hardware/keyboard-arrow-left';
import ArrowRight from 'material-ui/svg-icons/hardware/keyboard-arrow-right';
import { Drawer, MenuItem, IconButton } from 'material-ui';

const isMobile = () => {
	if (navigator.userAgent) {
		return (/Android|webOS|iPhone|iPad|iPod|BlackBerry|Mobile/i.test(navigator.userAgent));
	}

	return false;
};

class NavigationDrawer extends Component {
	render() {
		let { drawerResize, width, drawerOpen, drawerWidth, handleResize } = this.props;
		let icon = null;

		if (drawerResize) {
			icon = (
				<IconButton>
					<ArrowRight/>
				</IconButton>
			)
		} else {
			icon = (
				<IconButton>
					<ArrowLeft/>
				</IconButton>
			);
		}


		if (!isMobile() || width > 360) {
			return (
				<Drawer
					open={drawerOpen}
					containerClassName='drawer-container'
					width={drawerWidth}
				>
					<div className="bottom-div">
						<MenuItem onTouchTap={handleResize}>
							{icon}
						</MenuItem>
					</div>
				</Drawer>
			)
		} else {
			return (
				<Drawer
					open={drawerOpen}
					containerClassName='drawer-container'
					width={drawerWidth}
				>
				</Drawer>
			)
		}
	}
}

NavigationDrawer.propTypes = {
	drawerResize: PropTypes.any,
	drawerOpen: PropTypes.any,
	drawerWidth: PropTypes.any,
	width: PropTypes.any,
	handleResize: PropTypes.func
};

export default NavigationDrawer;