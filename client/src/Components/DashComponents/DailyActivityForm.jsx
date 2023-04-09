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


import TodayIcon from '@mui/icons-material/Today';



export default function MaxWidthDialog({vehicleId}) {
    const [open, setOpen] = React.useState(false);
    const [fullWidth, setFullWidth] = React.useState(true);
    const [maxWidth, setMaxWidth] = React.useState('xs');

    console.log(vehicleId);

    const { rootUser } = React.useContext(AppContext)

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const handleMaxWidthChange = (event) => {
        setMaxWidth(
            // @ts-expect-error autofill of arbitrary value is not handled.
            event.target.value,
        );
    };

    const handleFullWidthChange = (event) => {
        setFullWidth(event.target.checked);
    };

    const yourDate = new Date();

    const [formData, setFormData] = React.useState({
        "vehicleId": vehicleId,
        "date":  moment(new Date()).format("YYYY-MM-DD"),
        "odometerReading": 0,
        "runningHours": 0,
        "fuelFilled": 0,
        "fuelCost": 0,
        "amountOfFuel": 0,
        "maintenanceExpense": 0,
        "serviceDate": "2023-04-08T16:13:29.305Z"
    })

    const onChnageHandler = (e) => {
        var name = e.target.name;
        var value = e.target.value;

        setFormData({
            ...formData,
            [name]: value,
        })

    }

    const handleSubmit = async () => {
        console.log(formData);

        try {

            const res = await fetch('https://localhost:7059/api/DailyActivity', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            })

            console.log(res);

            setOpen(false)

            setFormData({
                "vehicleId": vehicleId,
                "date": moment(new Date()).format("YYYY-MM-DD"),
                "odometerReading": 0,
                "runningHours": 0,
                "fuelFilled": 0,
                "fuelCost": 0,
                "amountOfFuel": 0,
                "maintenanceExpense": 0,
                "serviceDate": ""
            })

        } catch (error) {
            console.log(error);
        }

        handleClose();
    }

    return (
        <React.Fragment>
            <Tooltip title="Add Daily Activity">

                <IconButton color='primary' onClick={handleClickOpen} > <TodayIcon /> </IconButton>
            </Tooltip>
            <Dialog
                fullWidth={fullWidth}
                maxWidth={maxWidth}
                open={open}
                onClose={handleClose}
            >
                <DialogTitle>Add Daily Activity</DialogTitle>
                <DialogContent>
                    
                   
                    <label > Date </label>
                    <TextField
                        type='date'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        variant="standard"
                        value={formData.date}
                        onChange={(e) => {
                            setFormData({
                                ...formData,
                                date: moment(e.target.value).format("YYYY-MM-DD")
                            })
                        }}
                    />

                    <TextField
                        type='number'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        label="Odometer Reading"
                        variant="standard"
                        name='odometerReading'
                        value={formData.odometerReading}
                        onChange={onChnageHandler}
                    />
                    <TextField
                        type='number'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        label="Running Hours"
                        variant="standard"
                        name='runningHours'
                        value={formData.runningHours}
                        onChange={onChnageHandler}
                    />
                    <TextField
                        type='number'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        label="Fuel Filled"
                        variant="standard"
                        name='fuelFilled'
                        value={formData.fuelFilled}
                        onChange={onChnageHandler}
                    />
                    <TextField
                        type='number'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        label="Fuel Cost"
                        variant="standard"
                        name='fuelCost'
                        value={formData.fuelCost}
                        onChange={onChnageHandler}
                    />
                    <TextField
                        type='number'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        label="Amount Of Fuel"
                        variant="standard"
                        name='amountOfFuel'
                        value={formData.amountOfFuel}
                        onChange={onChnageHandler}
                    />
                    <TextField
                        type='number'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        label="Maintenance Expense"
                        variant="standard"
                        name='maintenanceExpense'
                        value={formData.maintenanceExpense}
                        onChange={onChnageHandler}
                    />

                    <label > Service Date </label>
                    <TextField
                        type='date'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        variant="standard"
                        value={formData.serviceDate}
                        onChange={(e) => {
                            setFormData({
                                ...formData,
                                serviceDate: moment(e.target.value).format("YYYY-MM-DD")
                            })
                        }}
                    />

                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>Close</Button>
                    <Button variant='contained' onClick={handleSubmit} > Submit </Button>
                </DialogActions>
            </Dialog>
        </React.Fragment>
    );
}