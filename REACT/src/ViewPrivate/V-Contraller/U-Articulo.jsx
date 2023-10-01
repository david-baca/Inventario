import { useContext, useState } from "react"
import { ContextUser } from "../Context/ContextUser"
import { Put, TrueModal } from './0-Componentes'
import { useNavigate } from 'react-router-dom'
import { GeneraQR } from "../../GeneraQR"

export const EArticulo = () => {
    const navigate = useNavigate();
    const [TrueOpen, setTrueOpen] = useState(false)
    const { Data } = useContext( ContextUser )
    const URL = {...Data[6]}
    const [request, setRequest] = useState({...Data[7]})
    
    const TrueOn = (element) => setTrueOpen(element)
    const TrueOff = () =>{
        setTrueOpen(false)
        navigate('/Read/Articulo/'+URL.pk, {replace: true})
    }
    
    const FacturaChange = (e) => {
      let newValue = {...request};
      newValue.factura = e.target.value
      newValue.polisa = "N/A"
      setRequest(newValue);    
    };

  const PolizaChange = (e) => {
      let newValue = {...request};
      newValue.polisa = e.target.value
      newValue.factura = "N/A"
      setRequest(newValue);    
    };

    const CostoChange = (e) => {
        let newValue = {...request};
        newValue.costo = e.target.value
        setRequest(newValue);    
      };

    const FeqaddChange = (e) => {
        let newValue = {...request};
        newValue.feqadd = e.target.value
        setRequest(newValue);    
      };

    const FeqasicChange = (e) => {
        let newValue = {...request};
        newValue.feqasic = e.target.value
        console.log(newValue)
        setRequest(newValue);    
      };

    const TokenChange = (e) => {
        let newValue = {...request};
        newValue.token = e.target.value
        setRequest(newValue);    
      };

    const Enviar = () =>{
        if (request.costo == "") {
            alert('El costo no puede estar vacío');
            return;
          }
          if (request.polisa == "") {
            alert('Asegúrese de usar N/A al no requerir una Póliza');
            return;
          }
          if (request.factura == "") {
            alert('Asegúrese de usar N/A al no requerir una Factura');
            return;
          }
          if (request.token === "") {
            alert('El No.Inventario no puede estar vacío');
            return;
          }
          if (request.feqadd === "") {
            alert('La fecha de adquisición no puede estar vacío');
            return;
          }
          if (request.feqasic === "") {
            alert('La fecha de asignación no puede estar vacío');
            return;
          }
          if (Data[0] == null) {
            alert('Selecciona un catalogo');
            return;
          }
          if (Data[1] == null) {
            alert('Selecciona una categoría');
            return;
          }
          if (Data[2] == null) {
            alert('Selecciona un provedor');
            return;
          }
          if (Data[3] == null) {
            alert('Selecciona un fuente');
            return;
          }
          if (Data[4] == null) {
            alert('Selecciona un área');
            return;
          }
          if (Data[5] == null) {
            alert('Selecciona un rol');
            return;
          }
          if (Data[6] == null) {
            alert('Selecciona un responsable');
            return;
          }

          let newRequest = {...request,
          fkCategoria: Data[1].pk,
          fkProvedor:Data[2].pk,
          fkFuente:Data[3].pk,
          fkArea:Data[4].pk,
          fkResonsable:Data[6].pk}

          EnviarDatos(newRequest);
    }
    
    const EnviarDatos = async (Item) =>{
      const Mensaje = await Put({Entidad:"Artículo", Datos:Item})
      if(!Mensaje.success){
        alert(Mensaje.message) 
        return
       }
      await TrueOn(Mensaje.message)
    }
    
    return(
      <>
        <div className="overflow-auto max-w-100 min-h-[87vh] max-h-[87vh] p-5 bg-gray-200">
            <div className="p-5 bg-white">
              <div className="flex">
                <div className="flex flex-col min-w-[35%]">
                  <div className="min-h-[150px] min-w-screen p-5 flex flex-col gap-6">
                    Código QR
                    <GeneraQR Codigo={request.token}/>
                  </div>
                </div>
                <div className="flex flex-col">
                    <div className="min-h-[150px] min-w-screen p-5 flex flex-wrap gap-6">

                        <div className="bg-orange-500 min-w-[100%] p-4 text-white">
                          Detalles del artículo
                        </div>
                        <Segmento Entidad={"Catalogo"} BD={Data[0]?.nombre ?? 'Pendiente'} />
                        <Segmento Entidad={"Categoría"} BD={Data[1]?.descripcion ?? 'Pendiente'} />
                        <Segmento Entidad={"Provedor"} BD={Data[2]?.nombre ?? 'Pendiente'} />
                        <Segmento Entidad={"Fuente"} BD={Data[3]?.nombre ?? 'Pendiente'} />
                        <Segmento Entidad={"Área"} BD={Data[4]?.nombre ?? 'Pendiente'} />
                        
                        <InputValue Value={request.costo} onChange={CostoChange} 
                        placeholder={"Costo"} Type={"number"}/>

                        <InputValue Value={request.token} onChange={TokenChange}  
                        placeholder={"No.Inventario"} />

                        <InputValue Value={request.feqadd} onChange={FeqaddChange}  
                        placeholder={"Fecha de adquisición"}  Type={'date'}/>

                        <InputValue Value={request.polisa} onChange={PolizaChange}  
                        placeholder={"Póliza"} />

                        <InputValue Value={request.factura} onChange={FacturaChange}  
                        placeholder={"Factura"} />

                        <div className="bg-orange-500 min-w-[100%] p-4 text-white">
                          Detalles del Responsable
                        </div>
                        
                        <Segmento Entidad={"Rol"} BD={Data[5]?.nombre ?? 'Pendiente'} />
                        <Segmento Entidad={"Responsabe"} BD={(Data[6]?.nombre + " " + Data[6]?.apellidoP + " " + Data[6]?.apellidoM) ?? 'Pendiente'} />

                        <InputValue Value={request.feqasic} onChange={FeqasicChange}  
                        placeholder={"Fecha de asignación"}  Type={'date'}/>
                      
                    </div>
                </div>
              </div>
              <div className="p-5">
                <button onClick={Enviar} className="bg-green-500 text-white w-full rounded-md px-2 py-1">
                      Submit
                  </button>
              </div>
            </div>
        </div>

        <TrueModal Off={TrueOff} IsOpen={TrueOpen}/>
    </>
    )
}

const Segmento = ({Entidad, BD}) => {
    return(
        
        <div className="relative min-w-[30%] bg-gray-100">
            <label className="absolute left-0 -top-3.5">{Entidad}</label>
                <h1 className="peer placeholder-transparent p-2 border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:border-rose-600">
                {BD}    
                </h1>
        </div>
    )
}

const InputValue = ({Type,Value, onChange, placeholder}) => {
    return(
    <div className="relative min-w-[30%]">
        <input value={Value} onChange={(e)=>onChange(e)} required autoComplete="off" 
        type={Type ?? 'Text'} className="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:border-rose-600" placeholder={placeholder}/>
        <label className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm">{placeholder}</label>
    </div>

    )
    
}