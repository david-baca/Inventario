import { useContext } from 'react'
import {Route, Routes, Navigate} from 'react-router-dom'
import {UserProvider} from "./Context/UserProvider"
import { ContextUser } from "./Context/ContextUser"
import { Login, Dash, Catalogos, Categorias, Historial, Area, Provedor, Fuente, Roles, Responsable } from './View'

export const App = () => {
    return (
      <UserProvider>
      <Routes>
        <Route path='/' element={
        <Avalide>
          <Login/>
        </Avalide>}/>

        
        
        <Route path='/Dash/*' element={<Protect>
          <Dash/>
        </Protect>}/>

        <Route path='/Dash/Catalogo/*' element={<Protect><Dash contenido={
          <Catalogos/>
        }/></Protect>}/>

        <Route path='Dash/Categorias/*' element={<Protect><Dash contenido={
          <Categorias/>
        }/></Protect>}/>

        <Route path='Dash/Area/*' element={<Protect><Dash contenido={
          <Area/>
        }/></Protect>}/>
        <Route path='Dash/Fuente/*' element={<Protect><Dash contenido={
          <Fuente/>
        }/></Protect>}/>
        <Route path='Dash/Provedor/*' element={<Protect><Dash contenido={
          <Provedor/>
        }/></Protect>}/>
        <Route path='Dash/Roles/*' element={<Protect><Dash contenido={
          <Roles/>
        }/></Protect>}/>
        <Route path='Dash/Responsable/*' element={<Protect><Dash contenido={
          <Responsable/>
        }/></Protect>}/>
        
        <Route path='/Dash/Historial/*' element={<Protect><Dash contenido={
          <Historial/>
        }/></Protect>}/>

      </Routes>
      </UserProvider>
    )
  }

export const Avalide = ({children}) =>{
  const { getUserLogin } = useContext( ContextUser );
  return (!getUserLogin())
  ? children
  : <Navigate to="/Dash" replace />
}

export const Protect = ({children}) =>{
  const { getUserLogin } = useContext( ContextUser );
  return (getUserLogin())
   ? children
   : <Navigate to="/" replace />
}