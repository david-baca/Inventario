import { useContext } from 'react'
import {Route, Routes, Navigate} from 'react-router-dom'
import {UserProvider} from "./ViewPrivate/Context/UserProvider"
import { ContextUser } from "./ViewPrivate/Context/ContextUser"

import {Create, Read, Edit} from "./ViewPrivate/index"
import {Error, HomePage, Login} from './View'

import { CodigoQR } from "./View/visualizacion"
import { ImageUploader } from "./View/fila"


export const App = () => {
    return (
      <UserProvider>
      <Routes>
        <Route path='/' element={<Login/>}/>

        <Route path='/Create/*' element={<Protect>
          <Create/>
        </Protect>}/>
        <Route path='/Read/*' element={<Protect>
          <Read/>
        </Protect>}/>
        <Route path='/Edit/*' element={<Protect>
          <Edit/>
        </Protect>}/>

        <Route path='/Inicio' element={<HomePage/>}/> 
        <Route path='/:Pk' element={ <CodigoQR/> }/>  
        <Route path='/file' element={ <ImageUploader/> }/> 
      </Routes>
      </UserProvider>
    )
  }

export const Protect = ({children}) =>{
  const { UserLogin } = useContext( ContextUser );
  return (UserLogin)
   ? children
   : <Navigate to="/" replace />
}