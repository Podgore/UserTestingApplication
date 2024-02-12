import { Box, Button, Typography } from "@mui/material";

const NotFoundPage = () => {
    return (
        <Box
            sx={{
                display: 'flex',
                flexDirection: 'column',
                justifyContent: 'center',
                alignItems: 'center',
                height: '100vh'
            }}
        >
            <Typography color='#DB3069'
                width={'100%'}
                textAlign='center'
                mb={3}
                bgcolor={'#f0f0f0'}
            variant="h4">404</Typography>
            <Typography variant="h4">Not Found</Typography>
            <Typography variant="body2">Oops! The page you are looking for does not exist.</Typography>
            <Box>
                <Button
                    sx={{
                        mt: 5
                    }}
                    variant="contained"
                    color="primary"
                    onClick={() => {                       
                        return window.history.back();
                    }}
                >Go Back</Button>
            </Box>
        </Box>
    );
}

export default NotFoundPage;