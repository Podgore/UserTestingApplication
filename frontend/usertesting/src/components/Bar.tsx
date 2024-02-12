import { AppBar, Button, IconButton, Toolbar, Typography } from '@mui/material';
import Box from '@mui/material/Box';
import QuizIcon from '@mui/icons-material/Quiz';
import { useNavigate } from 'react-router-dom';
import { useEffect } from 'react';

const Bar = () => {
    const navigate = useNavigate();

    const hasToken = !!localStorage.getItem('accessToken');

    useEffect(() => {
        if (!hasToken) {
            navigate('/sign-in');
        }
    }, [hasToken, navigate]);

    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static" sx={{ backgroundColor: 'black' }}>
                <Toolbar>
                    <IconButton
                        sx={{ mr: 2 }}
                        size="large"
                        edge="start"
                        color="inherit"
                        onClick={() => navigate('/')}
                    >
                        <QuizIcon />
                    </IconButton>
                    <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                        User Testing
                    </Typography>
                    {
                        hasToken && (
                            <Button
                                color="inherit"
                                onClick={() => {
                                    localStorage.removeItem('accessToken');
                                    navigate('/');
                                }}>
                                Sign Out
                            </Button>
                            )
                    }
                </Toolbar>
            </AppBar>
        </Box>
    );
}

export default Bar;