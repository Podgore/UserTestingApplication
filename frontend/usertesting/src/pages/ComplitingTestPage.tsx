import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import TestRepository from "../services/TestRepository";
import { Box, Button, Card, CardActionArea, Radio, Slide, Snackbar, Typography } from "@mui/material";
import Bar from "../components/Bar";
import LiveHelpIcon from '@mui/icons-material/LiveHelp';
import { AnswersRequest } from "../models/api/request/AnswersRequest";
import { ExtendedTest } from "../models/test/ExtendedTest";
import { Answer } from "../models/test/Answer";

const ComplitingTestPage = () => {
    const { id } = useParams();

    const [error, setError] = useState<string | undefined>(undefined);

    const [test, setTest] = useState<ExtendedTest | undefined>(undefined);

    const [answers, setAnswers] = useState<Answer>({});

    const navigate = useNavigate();

    const handleSubmit = async () => {
        const request: AnswersRequest = {
            testId: test?.id ?? '',
            taskAnswers: Object.entries(answers).map(([taskId, optionId]) => ({ testTaskId: taskId, optionId }))
        }

        const response = await TestRepository.sumbitAnswers(request);
        if (response) {
            navigate('/');
        }
        else{
            setError('Unable to submit answers');
        }
    }

    useEffect(() => {
        const fetchTest = async () => {
            const response = await TestRepository.getTest(id ?? '');
            if (!response) {
                navigate('/');
            }
            setTest(response);
        }
        fetchTest();
    }, [id, navigate]);

    return (
        <>
            <Bar />
            <Card sx={{
                display: 'flex',
                flexDirection: 'column',
                margin: '20px auto',
                padding: '20px',
                minWidth: '400px',
                width: '50%',
            }}>
                <Typography
                    textAlign='center'
                    variant="h4"
                >{test?.lable}</Typography>
                <Box sx={{
                    display: 'flex',
                    flexDirection: 'column',
                    gap: '20px',
                    padding: '20px'
                }}>
                    {
                        test?.tasks.map((task) => (
                            <Box>
                                <Typography
                                    sx={{
                                        display: 'flex',
                                        flexDirection: 'row',
                                        gap: '10px',
                                        justifyItems: 'center',
                                    }}>
                                    <LiveHelpIcon />
                                    {task.label}
                                </Typography>
                                {
                                    task.options.map((option) => (
                                        <Box sx={{
                                            display: 'flex',
                                            flexDirection: 'row',
                                            gap: '3',
                                            alignItems: 'center',
                                        }}>
                                            <Radio
                                                onChange={(e) => {
                                                    setAnswers({
                                                        ...answers,
                                                        [task.id]: e.target.value
                                                    })
                                                }}
                                                checked={answers[task.id] === option.id}
                                                value={option.id} />
                                            <Typography>{option.label}</Typography>
                                        </Box>
                                    ))
                                }
                            </Box>
                        ))
                    }
                </Box>
                <CardActionArea sx={{
                    display: 'flex',
                    justifyContent: 'center'
                }}>
                    <Button
                        onClick={() => handleSubmit()}
                        variant="contained"
                        color="primary"
                    >Submit</Button>
                </CardActionArea>
            </Card>
            <Snackbar
                anchorOrigin={{
                    vertical: 'top',
                    horizontal: 'center',
                }}
                TransitionComponent={(props) => <Slide {...props} direction="down" />}
                open={!!error}
                autoHideDuration={3000}
                message={!!error ? error : ''}
                onClose={() => setError(undefined)}
            />
        </>
    );
}

export default ComplitingTestPage;