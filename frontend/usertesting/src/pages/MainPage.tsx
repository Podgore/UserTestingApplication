import { Box, Typography } from "@mui/material";
import Bar from "../components/Bar";
import { useState, useEffect } from "react";
import { Test } from "../models/test/Test";
import TestRepository from "../services/TestRepository";
import TestCard from "../components/TestCard";

const MainPage = () => {
    const [tests, setTests] = useState<Test[] | undefined>(undefined);
    const [loading, setLoading] = useState<boolean>(false);

    useEffect(() => {
        const fetchTests = async () => {
            setLoading(true);
            const response = await TestRepository.getTests();
            setTests(response)
            setLoading(false);
        }

        fetchTests();
    }, []);


    return (
        <Box sx={{ display: 'flex', flexDirection: 'column' }}>
            <Bar />
            <Box sx={{
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'stretch',
                gap: '20px',
                padding: '20px'
            }}>
                <Typography textAlign='center' variant="h4">{'Your tests:'}</Typography>
                {
                    loading
                        ? <Typography textAlign='center' variant="h6">{'Loading...'}</Typography>
                        : (<>
                            {tests
                                ? <>{tests!.map((test) => <TestCard test={test} />)}</>
                                : <Typography
                                    textAlign='center'
                                    variant="h6">{'Unable to find tests for you :('}</Typography>
                            }
                        </>
                        )
                }
            </Box>
        </Box>

    );
}

export default MainPage;