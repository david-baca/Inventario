import {Route, Routes} from 'react-router-dom'
import Logo from "../../assets/Logo.png"
// import { Catalogo, Categoria, Provedor, Fuente, Area, Rol, Responsable, Articulo } from "../index"
import { EArticulo, Catalogos, Categorias, Provedores, Fuentes, Areas, Roles, Responsables } from '../'
import { ENavBoton } from "./Componentes/NavBoton"
import { useContext } from 'react';
import { ContextUser } from '../Context/ContextUser';
import { Link } from 'react-router-dom';

export const Edit = () => {
const { CleenData, Nav } = useContext( ContextUser)

const Color =[
  "bg-[#0032FF]",
  "bg-[#0C86E8]",
  "bg-[#00EAFF]",
  "bg-[#12DEA1]",
  "bg-[#02E049]",
]

    return (
      <>
        <div className="w-screen h-screen bg-black-500  flex flex-row items-center">
          <div className='w-[320px] max-h-screen overflow-auto bg-white flex flex-col justify-center items-center'>
            <div className='max-w-[70%] pt-9'>
              <img src={Logo}/>
            </div>
            <div className='overflow-auto p-5 w-[80%] pt-0 mt-10'>
              <div className='w-[100%]'>
                <h1>
                  Articulos
                </h1> 
                <Link to="/Create/5" onClick={()=>CleenData()}>
                  <ENavBoton titulo="Crear" funcion="C"/>
                </Link>     
                <ENavBoton titulo="Editar" funcion="R" color="bg-yellow-300"/>
                  {Nav.map((element, index) => 
                    (
                        <ENavBoton key={index}
                          direccion = {index}
                          color={Color[index]}
                          titulo={element.Titulo}
                          funcion={element.Funcion}
                          sub={element.Tabla}
                        />
                      )
                    )
                  }
                <Link to="/Read/Responsable">
                <ENavBoton titulo="Buscar" funcion="R"/>
                </Link>
              
              </div>
            </div>
          </div> 
          <div className='bg-gray-200 w-full max-h-screen min-h-screen overflow-hidden'>
              <div className=" flex justify-end bg-white">
                <Link className='p-5' to="/">Cerrar sesion</Link>
              </div>
              <div className='w-full'>
                <Routes>
                  <Route path='/0' element={<Catalogos/>}/> 
                  <Route path='/0_1' element={<Categorias/>}/>
                  <Route path='/1' element={<Provedores/>}/>
                  <Route path='/2' element={<Fuentes/>}/>
                  <Route path='/3' element={<Areas/>}/>
                  <Route path='/4' element={<Roles/>}/>
                  <Route path='/4_1' element={<Responsables/>}/>
                  <Route path='/5' element={<EArticulo/>}/>

                  
                  {/* 
                  <Route path='/1/:Search' element={<Provedor/>}/>
                  <Route path='/2/:Search' element={<Fuente/>}/>
                  <Route path='/3/:Search' element={<Area/>}/>
                  <Route path='/4/:Search' element={<Rol/>}/>
                  <Route path='/4_1/:Search' element={<Responsable/>}/>
                  <Route path='/5/:Search' element={<Articulo/>}/>
                  <Route path='/*' element={<Catalogo/>}/> 
                  */}
                </Routes>
              </div>
          </div>
        </div>
      </>
      
    )
  }