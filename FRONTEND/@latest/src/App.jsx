import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import studentAdd from './components/Student';

function App() {
  const [userType, setUserType] = useState(null);
  const [userId, setUserId] = useState(null);
  

  return (
    <Router>
      <Routes>
        
        <Route path="/student" element={<Dashboard userType={userType} userId={userId} />} />
        
      </Routes>
    </Router>
  );
}

export default App
