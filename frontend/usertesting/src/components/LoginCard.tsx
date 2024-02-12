import { Box, Button, Card, TextField, Typography } from "@mui/material"
import { useEffect, useState } from "react";
import AuthRepository from "../services/AuthRepository";
import { useNavigate } from "react-router-dom";

const LoginCard = () => {
    const [email, setEmail] = useState<string>('');
    const [error, setError] = useState<string | false>(false);
    const navigate = useNavigate();


    const handleSingUpClick = async () => {
        const error = await AuthRepository.signIn(email);
        if (!error) {
            navigate('/');
        }
        setError(error?.message ?? 'Invalid');
    }

    useEffect(() => {
        setError(false)
    }, [email])

    return (
        <Card
            elevation={7}    
        sx={{
                display: 'flex',
                flexDirection: 'column',
                justifyContent: 'center',
                gap: '20px',
                height: '275px',
                padding: '10px 30px',
                alignItems: 'center',
            }}>
            <Typography
                variant="h6">
                Login
            </Typography>
            <Box
                sx={{
                    flexGrow: 1,
                    display: 'flex',
                    alignItems: 'center',
                    justifyContent: 'center'
                }}>
                <TextField
                    sx={{ width: '16hv' }}
                    label="Email"
                    type="email"
                    onChange={(e) => setEmail(e.target.value)}
                    error={!!error}
                    helperText={error}
                />
            </Box>
            <Button
                variant='contained'
                onClick={handleSingUpClick}
            >
                Sing up
            </Button>
        </Card>
    );
}

export default LoginCard;