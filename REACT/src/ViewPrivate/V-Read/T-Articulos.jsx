import { Link, useParams } from 'react-router-dom'
import { GetFK, Barra } from '../V-Contraller/0-Componentes'
import { useState, useEffect, useContext } from 'react'
import { ContextUser } from '../Context/ContextUser';
export const T_Articulos = () =>{
    const { CargarData } = useContext( ContextUser)
    const { FK } = useParams();
    const [Articulos, setArticulos] = useState()
    const [Busqueda, setBusqueda] = useState(null)

    const ConsultarArt = async()=>{
        let request = await GetFK({Entidad:"Artículo", Text:Busqueda, FK:FK})
        await setArticulos(request)
    }

    const Buscar = async (Search) =>{
        setBusqueda(Search)
    }
    //Funcion de carga de elementos locales
    useEffect(() =>{ConsultarArt();},[]); // Array de dependencias vacío, indica que el efecto solo se ejecutará una vez.
    useEffect(() => {ConsultarArt();}, [Busqueda]);
    return(
        
            
            <div className=" bg-gray-100 overflow-auto max-w-100 min-h-[87vh] max-h-[87vh] p-5 ">
            
            <h1 className='ps-5 font-bold text-xl'>
                Árticulos
            </h1>

            <div className="p-5">
                <div className='bg-white mb-5 rounded-xl p-5 flex gap-5 justify-end'>
                    <Barra ReadBD={Buscar}/>
                </div>
                <div className='p-5 bg-white'>
                    <table className='bg-white w-full'>
                        <thead>
                            <tr>
                                <td className='border border-gray-300 p-2'>#</td>
                                <td className='border border-gray-300 p-2'>No.Inventario</td>
                                <td className='border border-gray-300 p-2'>Catalogo</td>
                                <td className='border border-gray-300 p-2'>Categoría</td>
                                <td className='border border-gray-300 p-2'>Póliza</td>
                                <td className='border border-gray-300 p-2'>Factura</td>
                                <td className='border border-gray-300 p-2'>Costo</td>
                                <td className='border border-gray-300 p-2'>Acciones</td>
                            </tr>
                        </thead>
                        <tbody>
                            {Articulos &&(
                                Articulos.map((element, Index) => 
                                (
                                    <tr key={element.pk}>
                                        <td className='border border-gray-200 p-2'>
                                            {Index}
                                        </td>
                                        <td className='border border-gray-200 p-2'>
                                            {element.articulo.token}
                                        </td>
                                        <td className='border border-gray-200 p-2'>
                                            {element.catalogo.nombre}
                                        </td>
                                        <td className='border border-gray-200 p-2'>
                                            {element.categoria.descripcion}
                                        </td>
                                        <td className='border border-gray-200 p-2'>
                                            {element.articulo.polisa}
                                        </td>
                                        <td className='border border-gray-200 p-2'>
                                            {element.articulo.factura}
                                        </td>
                                        <td className='border border-gray-200 p-2'>
                                            {element.articulo.costo}
                                        </td>
                                        <td className='ps-2 flex gap-3 border border-gray-200'>
                                            <Link to={"../../../Edit/5"} onClick={()=>CargarData(element)}>
                                                <button className='bg-yellow-300 p-1 px-4'>
                                                    Editar
                                                </button>
                                            </Link>
                                            

                                            <button className='bg-red-400 px-4 p-1 text-white'>
                                                Eliminar
                                            </button>
                                        </td>
                                        
                                    </tr>
                                ))
                            )}
                        </tbody>
                    </table>
                </div>
            </div>
            </div>
    )
}