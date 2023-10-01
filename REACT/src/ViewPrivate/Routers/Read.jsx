import {Route, Router, Routes} from 'react-router-dom'
import Logo from "../../assets/Logo.png"
import { NavBoton } from "./Componentes/NavBoton"
import { useContext } from 'react';
import { ContextUser } from '../Context/ContextUser';
import { Link } from "react-router-dom"
import { T_Responsable, T_Articulos } from '../'

export const Read = () => {
    const { CleenData } = useContext( ContextUser)
    return (
      <>
        <div className="w-screen h-screen bg-black-500  flex flex-row items-center">     
        <div className='w-[320px] h-screen bg-white flex justify-center'>
            <div className=' max-w-[60%] pt-9'>
              <img src={Logo}/>
              <div className='w-[100%]'>
                <h1 className='pt-10'>
                  Articulos
                </h1>     
                <Link to="/Create/5" onClick={()=>CleenData()}>
                  <NavBoton titulo="Crear" funcion="C"/>
                </Link> 
                <Link to="/Read/Responsable">
                  <NavBoton titulo="Buscar" funcion="R"/>
                </Link>
              </div>
            </div>
          </div>

          <div className=' bg-gray-200 w-full h-full'>
              <div className="flex justify-end bg-white">
                <Link className='p-5' to="/">Cerrar sesion</Link>
              </div>
              
              <Routes>
                <Route path='/Articulo/:FK' element={<T_Articulos/>}/>
                <Route path='/Responsable' element={<T_Responsable/>}/>
              </Routes>
          </div>
        </div>
      </>
      
    )
  }