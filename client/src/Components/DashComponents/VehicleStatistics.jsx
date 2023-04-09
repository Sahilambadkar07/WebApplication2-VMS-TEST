import * as React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import FormControl from '@mui/material/FormControl';
import FormControlLabel from '@mui/material/FormControlLabel';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import Select from '@mui/material/Select';
import Switch from '@mui/material/Switch';
import { IconButton, TextField, Tooltip } from '@mui/material';
import { AppContext } from '../../App';
import moment from "moment";


import AnalyticsIcon from '@mui/icons-material/Analytics';
import BasicTabs from './AnaliticsTabs';


export default function VehicleStatistics({vehicleId}) {
    const [open, setOpen] = React.useState(false);
    const [fullWidth, setFullWidth] = React.useState(true);
    const [maxWidth, setMaxWidth] = React.useState('md');

    console.log(vehicleId);


    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    return (
        <React.Fragment>
            <Tooltip title="Vehicle Statistics">

                <IconButton color='primary' onClick={handleClickOpen} > <AnalyticsIcon /> </IconButton>
            </Tooltip>
            <Dialog
                fullWidth={fullWidth}
                maxWidth={maxWidth}
                open={open}
                onClose={handleClose}
            >
                <DialogTitle>Vehicle Statistics</DialogTitle>
                <DialogContent>
                    <BasicTabs vehicleId={vehicleId} />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Close</Button>
                </DialogActions>
            </Dialog>
        </React.Fragment>
    );
}