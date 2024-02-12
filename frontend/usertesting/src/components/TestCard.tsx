import { Box, Button, Card, CardActions, CardContent, Chip, Typography } from "@mui/material";
import { Test } from "../models/test/Test";

import RadioButtonUncheckedIcon from '@mui/icons-material/RadioButtonUnchecked';
import TaskAltIcon from '@mui/icons-material/TaskAlt';
import { useNavigate } from "react-router-dom";

const TestCard = ({ test }: { test: Test }) => {
  const navigate = useNavigate();

  const getColorByProgress = (mark: number, maxMark: number): 'success' | 'warning' | 'error' => {
    const percent = mark / maxMark * 100;

    if (percent < 60) {
      return 'error';
    }
    if (percent < 80) {
      return 'warning';
    }
    return 'success';
  }

  return (
    <Card
      elevation={5}>
      <CardContent
        sx={{
          padding: '20px'
        }}>
        <Box sx={{
          display: 'flex',
          flexDirection: 'row',
          justifyContent: 'space-between'
        }}>
          <Box sx={{
            display: 'flex',
            flexDirection: 'row',
            gap: '10px'
          }}>
            <Typography variant="h6">
              {test.lable}
            </Typography>
            {
              test.isComplited
                ? <Chip color="success" icon={<TaskAltIcon />} label='Completed' />
                : <Chip color='warning' icon={<RadioButtonUncheckedIcon />} label='Open' />
            }
          </Box>
          <Chip
            label={`${test.mark}/${test.maxMark}`}
            color={test.isComplited ? getColorByProgress(test.mark, test.maxMark) : 'info'}
          />
        </Box>

        <Typography variant="body2">
        </Typography>
      </CardContent>
      <CardActions sx={{
        justifyContent: "flex-end",
        padding: '10px 20px'
      }}>
        {
          test.isComplited
            ? <></>
            : <Button
              size="small"
              variant="contained"
              onClick={() => navigate(`/test/${test.id}`)}
              color="primary">
              {'Start test'}
            </Button>
        }
      </CardActions>
    </Card>
  );
}

export default TestCard;