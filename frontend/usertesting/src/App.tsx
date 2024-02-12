import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import MainPage from './pages/MainPage';
import { ThemeProvider, createTheme } from '@mui/material';
import SignInPage from './pages/SignInPage';
import NotFoundPage from './pages/NotFoundPage';
import ComplitingTestPage from './pages/ComplitingTestPage';

function App() {

  const theme = createTheme({
    palette: {
      mode: 'light',
      primary: {
        main: '#6096BA'
      },
      secondary:{
        main: '#09BC8A'
      },
      background:{
        paper: '#EFF1ED'
      }
    }
  })

  return (
    <>
    <ThemeProvider theme={theme}>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<MainPage />} />
          <Route path="/sign-in" element={<SignInPage />} />
          <Route path='test/:id' element={<ComplitingTestPage />} />
          <Route path="*" element={<NotFoundPage/>} />
          <Route path='/not-found' element={<NotFoundPage/>} />
        </Routes>
      </BrowserRouter>
      </ThemeProvider>
    </>
  );
}

export default App;
