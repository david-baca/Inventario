import { useState } from "react"; 
import { useNavigate } from "react-router-dom";

export const Data = () =>{
    const navigate = useNavigate();
    const [Data, setData] = useState([]);

    const getData = ()=>{
        return(Data)
    }

    const setDataItem = ({Dato:BD, noData:FilaD}) => {
        let newData = [...Data];
        newData[FilaD] = BD
        setData(newData);
    }

    const CleenData = () =>{
        setData([])
    }

    const setDataArray = (item) => {
        let newData = [item.catalogo,item.categoria,item.provedor,item.fuente,
            item.area,item.rol,item.responsable,item.articulo,]
        setData(newData)
    }

    return({
        getData,
        setDataItem,
        setDataArray,
        CleenData
    })
}