import * as React from 'react';
import PropTypes from 'prop-types';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import DashBoard from './AnalyticsTabs/DashBoard';
import TabularView from './AnalyticsTabs/TabularView';
import AverageView from './AnalyticsTabs/AverageView';
import { Button, TextField } from '@mui/material';
import moment from 'moment';

function TabPanel(props) {
    const { children, value, index, ...other } = props;

    return (
        <div
            role="tabpanel"
            hidden={value !== index}
            id={`simple-tabpanel-${index}`}
            aria-labelledby={`simple-tab-${index}`}
            {...other}
        >
            {value === index && (
                <Box sx={{ p: 3 }}>
                    <Typography>{children}</Typography>
                </Box>
            )}
        </div>
    );
}

TabPanel.propTypes = {
    children: PropTypes.node,
    index: PropTypes.number.isRequired,
    value: PropTypes.number.isRequired,
};

function a11yProps(index) {
    return {
        id: `simple-tab-${index}`,
        'aria-controls': `simple-tabpanel-${index}`,
    };
}

export default function BasicTabs({ vehicleId }) {
    const [value, setValue] = React.useState(0);

    const handleChange = (event, newValue) => {
        setValue(newValue);
    };


    const currentDate = new Date();

    // Get the start date of the current month
    const startDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);

    // Get the end date of the current month
    const endDate = new Date(currentDate.getFullYear(), currentDate.getMonth() + 1, 0);


    const [formData, setFormData] = React.useState({
        startdate: moment(startDate).format("YYYY-MM-DD"),
        enddate: moment(endDate).format("YYYY-MM-DD")
    })

    // console.log({
    //     startdate: startDateFormatted,
    //     enddate: endDateFormatted
    // });

    const handleFormChange = (e) => {
        var name = e.target.name;
        var value = e.target.value;
        console.log(value);
        setFormData({
            ...formData,
            [name]: value
        })
    }

    const handlePages = () => {

    }

    return (
        <Box sx={{ width: '100%' }}>
            <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
                <Tabs value={value} onChange={handleChange} aria-label="basic tabs example">
                    <Tab label="Dashboard" {...a11yProps(0)} />
                    <Tab label="Tabular View" {...a11yProps(1)} />
                    <Tab label="Average View" {...a11yProps(2)} />
                </Tabs>
            </Box>
            <div style={{
                display: 'flex',
                marginTop: '1rem',
                width: '100%',
                justifyContent: 'space-between'
            }} >
                <div style={{ width: '48%' }} >

                    <label > Start Date </label>
                    <TextField
                        type='date'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        variant="standard"
                        value={formData.startdate}
                        name="startdate"
                        onChange={handleFormChange}
                    />
                </div>
                <div style={{ width: '48%' }}>

                    <label > End Date </label>
                    <TextField
                        type='date'
                        InputProps={{ inputProps: { min: 0 } }}
                        style={{ width: '100%', marginBottom: '2rem' }}
                        id="standard-basic"
                        variant="standard"
                        value={formData.enddate}
                        name="enddate"
                        onChange={handleFormChange}
                    />
                </div>
            </div>

            <TabPanel value={value} index={0}>
                <DashBoard vehicleId={vehicleId} formData={formData} />
            </TabPanel>
            <TabPanel value={value} index={1}>
                <TabularView vehicleId={vehicleId} formData={formData} />
            </TabPanel>
            <TabPanel value={value} index={2}>
                <AverageView vehicleId={vehicleId} formData={formData} />
            </TabPanel>
        </Box>
    );
}