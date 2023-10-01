import { Link } from 'react-router-dom'
import { Get, GetFK, Barra } from '../V-Contraller/0-Componentes'
import { useState, useEffect} from 'react'
import * as  XLSX from "xlsx";

export const T_Responsable = () =>{
    const [Roles,setRoles] = useState()
    const [Responsables, setResponsables] = useState()
    
    const [Busqueda, setBusqueda] = useState(null)
    const [Filter, setFilter] = useState(0)
    
    const ConsultarR = async()=>{
        let request = await Get({Entidad:"Roles", Text:Busqueda, FK:Filter})
        await setRoles(request)
    }

    const ConsultarRes = async()=>{
        let request = await GetFK({Entidad:"Responsable", Text:Busqueda, FK:Filter})
        await setResponsables(request)
    }

    const ChangeFilter = async (e) => {
        setFilter(e.target.value)
    };

    const Buscar = async (Search) =>{
        setBusqueda(Search)
    }

    const ConsultarArt = async(pk)=>{
        let request = await GetFK({Entidad:"Artículo", Text:Busqueda, FK:pk})
        await exportToExcel(request)
    }

    const exportToExcel = (result) => {
        if(result == null){
            alert("Este responsable no tiene articulos asignados")
            return 
        }
        const data = [
          ['Catalogo','Marca','Descripcion','Modelo','Proveedor','Fuente',
          'Área','Costo','No.Inventario','Fecha de Adquisición','Fecha de Asignación',
          'Factura','Poliza','Responsable', 'Cargo del responsable'],
          ...result.map(item => [
            item.catalogo.nombre,
            item.categoria.marca,
            item.categoria.descripcion,
            item.categoria.modelo,
            item.provedor.nombre,
            item.fuente.nombre,
            item.area.nombre,
            item.articulo.costo,
            item.articulo.token,
            item.articulo.feqadd,
            item.articulo.feqasic,
            item.articulo.factura,
            item.articulo.polisa,
            `${item.responsable.nombre} ${item.responsable.apellidoP} ${item.responsable.apellidoM}`,item.rol.nombre
          ])
        ];
    
        const ws = XLSX.utils.aoa_to_sheet(data);
        const wb = XLSX.utils.book_new();
        XLSX.utils.book_append_sheet(wb, ws, 'Datos');
        let date = new Date()
        XLSX.writeFile(wb, "Reporte de artículos de "+result[0].responsable.nombre+ " (" +
        date.getDate()+"-"+date.getMonth()+"-"+date.getFullYear()+').xlsx');
      };
    
    //Funcion de carga de elementos locales
    useEffect(() =>{ConsultarR(); ConsultarRes();},[]); // Array de dependencias vacío, indica que el efecto solo se ejecutará una vez.
    useEffect(() => {ConsultarRes();}, [Filter]);
    useEffect(() => {ConsultarRes();}, [Busqueda]);
    return(
        <div className="overflow-auto max-w-100 min-h-[87vh] max-h-[87vh] p-5 bg-gray-100">
            <h1 className='text-xl font-bold ps-5'>
                Responsables
            </h1>
            <div className="p-5">
                <div className='flex justify-between gap-5 p-5 mb-5 bg-white rounded-xl'>
                    
                    <div className='relative'>
                    <label className="px-1 absolute left-1.5 -top-3.5 bg-white">Rol</label>
                    <select
                        className="border-gray-400 border rounded-md min-w-[30%] p-2"
                        onChange={ChangeFilter}
                        value={Filter}
                    >
                        <option value={0}>Todos</option>

                        {Roles &&(
                            Roles.map((element) => 
                            (
                                <option value={element.pk} key={element.pk}>
                                   {element.nombre} 
                                </option>
                            ))
                        )}
                    </select>
                    </div>

                    
                    <Barra ReadBD={Buscar}/>
                </div>
                <div className='p-5 bg-white'>
                    <table className='bg-white'>
                        <thead>
                            <tr>
                                <td className='p-2 border border-gray-300'>#</td>
                                <td className='w-full p-2 border border-gray-300 '>Responsable</td>
                                <td className='p-2 border border-gray-300'>Árticulos</td>
                                <td className='p-2 border border-gray-300'>Reporte</td>
                            </tr>
                        </thead>
                        <tbody>
                            {Responsables &&(
                                Responsables.map((element, Index) => 
                                (
                                    <tr key={element.pk}>
                                        <td className='p-2 border border-gray-100'>
                                            {Index}
                                        </td>
                                        <td className='p-2 border border-gray-100'>
                                            {element.nombre +" "+
                                            element.apellidoP +" "+
                                            element.apellidoM}
                                        </td>
                                        <td className='p-1 border border-gray-100 ps-2'>
                                            <Link to={"../Articulo/"+element.pk}>
                                            <button className='p-1 px-4 text-white bg-lime-500'>
                                                    ver
                                            </button>
                                            </Link>
                                        </td>
                                        <td className='p-1 border border-gray-100 ps-2'>
                                            <button onClick={()=>ConsultarArt(element.pk)}
                                             className='p-1 px-4 text-white bg-sky-400'>
                                                ver
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
            
        
            // D.map((element, Index) => 
            // (
            //     <h1>{element}</h1>
            //     ))
    
    )
}