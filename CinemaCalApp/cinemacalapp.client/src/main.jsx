import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import ExpenseList from './ExpenseList.jsx'
import './index.css'

createRoot(document.getElementById('root')).render(
  <StrictMode>
       <ExpenseList />
      
  </StrictMode>,
)
