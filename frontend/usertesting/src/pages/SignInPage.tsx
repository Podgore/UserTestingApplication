import { Box } from "@mui/material";
import LoginCard from "../components/LoginCard";

const SignInPage = () => {
    return (
        <Box sx={{
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'center',
            height: '100vh'
        }}>
            <Box
                sx={{
                    display: 'flex',
                    justifyContent: 'center'
                }}
            >
                <LoginCard />
            </Box>
        </Box>
    );
}

export default SignInPage;