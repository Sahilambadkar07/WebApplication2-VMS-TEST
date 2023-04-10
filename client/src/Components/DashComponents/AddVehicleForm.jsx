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
import { TextField } from '@mui/material';
import { AppContext } from '../../App';
import moment from "moment";


export default function MaxWidthDialog({setRows}) {
    const [open, setOpen] = React.useState(false);
    const [fullWidth, setFullWidth] = React.useState(true);
    const [maxWidth, setMaxWidth] = React.useState('xs');


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

    const [formData, setFormData] = React.useState({
        "userId": rootUser.userId,
        "vehicleType": "Two Wheeler",
        "vehicleNumber": "",
        "isSmartVehicle": false,
        "fuelType": "",
        "fuelCapacity": 0,
        "odometerReading": 0,
        "lastServiceDate": "",
        "lastServiceCharge": 0,
        "fuelAmount": 0
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

            const res = await fetch('https://localhost:7059/api/Vehicle/CreateVehicle', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            })

            console.log(res);

            setFormData({
                "userId": rootUser.userId,
                "vehicleType": "Two Wheeler",
                "vehicleNumber": "",
                "isSmartVehicle": false,
                "fuelType": "",
                "fuelCapacity": 0,
                "odometerReading": 0,
                "lastServiceDate": "",
                "lastServiceCharge": 0,
                "fuelAmount": 0
            })

            setOpen(false);

        } catch (error) {
            console.log(error);
        }

        handleClose();
    }

    return (
        <React.Fragment>
            <Button variant="contained" sx={{ margin: '1rem 0' }} onClick={handleClickOpen}>
                Add Vehicle
            </Button>
            <Dialog
                fullWidth={fullWidth}
                maxWidth={maxWidth}
                open={open}
                onClose={handleClose}
            >
                <DialogTitle>Add Vehicle</DialogTitle>
                <DialogContent>

                    <TextField
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        label="Vehicle Number"
                        variant="standard"
                        name='vehicleNumber'
                        value={formData.vehicleNumber}
                        onChange={onChnageHandler}
                    />

                    <TextField
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-select-currency"
                        select
                        label="Vehicle Type"
                        variant="standard"
                        name='vehicleType'
                        value={formData.vehicleType}
                        onChange={onChnageHandler}
                    >
                        <MenuItem value={"Two Wheeler"}>
                            Two Wheeler
                        </MenuItem>
                        <MenuItem value={"Four Wheeler"}>
                            Four Wheeler
                        </MenuItem>
                    </TextField>
                    <div style={{
                        display: 'flex',
                        alignItems: 'center',
                        marginBottom: '2rem'
                    }} >
                        <div>Is Smart Vehicle</div>
                        <Switch checked={formData.isSmartVehicle} onClick={() => {
                            setFormData({
                                ...formData,
                                isSmartVehicle: !formData.isSmartVehicle
                            })
                        }} />

                    </div>
                    <TextField
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-select-currency"
                        select
                        label="Fuel Type"
                        defaultValue="Petrol"
                        variant="standard"
                        name='fuelType'
                        value={formData.fuelType}
                        onChange={onChnageHandler}
                    >
                        <MenuItem value={"Petrol"}>
                            Petrol
                        </MenuItem>
                        <MenuItem value={"Diesel"}>
                            Diesel
                        </MenuItem>
                    </TextField>
                    <TextField
                        type='number'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        label="Fuel Capacity"
                        variant="standard"
                        name='fuelCapacity'
                        value={formData.fuelCapacity}
                        onChange={onChnageHandler}
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

                    <label > Last Service Date </label>
                    <TextField
                        type='date'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        variant="standard"
                        value={formData.lastServiceDate}
                        onChange={(e) => {
                            setFormData({
                                ...formData,
                                lastServiceDate: moment(e.target.value).format("YYYY-MM-DD")
                            })
                        }}
                    />

                    <TextField
                        type='number'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        label="Last Service Charge"
                        variant="standard"
                        name='lastServiceCharge'
                        value={formData.lastServiceCharge}
                        onChange={onChnageHandler}
                    />

                    <TextField
                        type='number'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        label="Amount of fuel in vehicle"
                        variant="standard"
                        name='fuelAmount'
                        value={formData.fuelAmount}
                        onChange={onChnageHandler}
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