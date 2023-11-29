import { useContext } from 'react';
import { ContextUser } from '../Context/ContextUser';

import ImgDelete from "../assets/Delete.svg"
import ImgUpdate from "../assets/Edit.svg"

export const BtnAddNav = ({pk,nombre,entidad,siguiente, Hilera}) => {

    const { AddNav } = useContext( ContextUser )

    const eliminar = (pk) =>{
        console.log("elimina")
    }
    const editar = (pk) =>{

    }
    return(
        <div onClick={() => AddNav({Nombre:nombre, Titulo:entidad, Siguiente:siguiente, Llave:pk, Index:Hilera} )} className="w-full bg-white p-2 text-center flex flex-col">
            <div className='flex flex-col items-end w-full'>
                <button onClick={eliminar} className='p-1 m-1 border-yellow-400 border-[2px] rounded-lg'> <img src={ImgUpdate}/> </button>
                <button onClick={editar} className='p-1 m-1 border-red-400 border-[2px] rounded-lg'> <img src={ImgDelete}/> </button>
            </div>
            <div className=' font-bold text-center w-full flex justify-center items-center h-[140px]'>
               <h1>{nombre}</h1> 
            </div>
        </div>
    )
}
