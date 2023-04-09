import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';

import BikeScooterIcon from '@mui/icons-material/BikeScooter';

export default function DenseAppBar() {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static" style={{
        backgroundColor:'white',
        color : 'black',
        boxShadow: 'rgba(99, 99, 99, 0.2) 0px 2px 8px 0px'
      }} >
        <Toolbar variant="dense">
          <IconButton edge="start" color="inherit" aria-label="menu" sx={{ mr: 2 }}>
            <BikeScooterIcon color='primary' sx={{ fontSize: "60px" }}/>
          </IconButton>
          <Typography variant="h6" color="inherit" component="div" sx={{
            fontWeight:'bold',
            textTransform:'uppercase',
            letterSpacing:'2px',
            wordSpacing:'3px'
          }} >
            vehicle management system
          </Typography>
        </Toolbar>
      </AppBar>
    </Box>
  );
}