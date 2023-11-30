import Logo from "../assets/Logo.png"
import { Link } from 'react-router-dom';
import { DashBtn } from "../Components/DashBtn"

export const Dash = ({contenido}) =>{
    return(
        <>
        <div className="w-screen h-screen bg-black-500  flex flex-row items-start">
          <div className='w-[320px] max-h-screen overflow-auto bg-white flex flex-col justify-center items-center'>
            <div className='max-w-[70%] pt-9'>
              <img src={Logo}/>
            </div>
            <div className='overflow-auto p-5 w-[80%] pt-0 mt-10'>
              <div className='w-[100%]'>
                <h1>
                  Herramientas
                </h1>      
                <Link to="/">
                    <DashBtn Titulo="Articulos"/>
                </Link>
                <Link to="/Dash/Catalogo">
                    <DashBtn Titulo="Catalogos"/>
                </Link>
                <Link to="/Dash/Categorias">
                    <DashBtn Titulo="Categorias"/>
                </Link>
                <Link to="/Dash/Historial">
                    <DashBtn Titulo="Historial"/>
                </Link>
              
              </div>
            </div>
          </div> 
          <div className='bg-gray-200 w-full max-h-screen min-h-screen overflow-hidden'>
              <div className=" flex justify-end bg-white">
                <Link className='p-5' to="/">Cerrar sesion</Link>
              </div>
              <div className='w-full'>
                {contenido}
              </div>
          </div>
        </div>
      </>
    )
} 