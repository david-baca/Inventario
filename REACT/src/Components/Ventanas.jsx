import Modal from "react-modal";
import { Post, Delete, Put, Get } from "../Conexion/Conexion"
import { useLocation, useNavigate } from 'react-router-dom';
import { useState } from "react";

const customStyles = {
  content: {
    top: '50%',
    left: '50%',
    right: 'auto',
    bottom: 'auto',
    marginRight: '-50%',
    transform: 'translate(-50%, -50%)',
    background: '#00000076',
    width: '100vw',
    height: '100vh'
  },
};

Modal.setAppElement('#root');

export const Toolbox = ({Entidad:E, Reload:R}) =>{
  const Kit_creation = ModulCreate({Entidad:E, Recargar:R});
  const Kit_Edit = ModulEdit({Entidad:E, Recargar:R});
  const Kit_Eliminate = ModulEliminate({Entidad:E, Recargar:R});
  return({Kit_creation,Kit_Edit,Kit_Eliminate})
}

const FormVentana = (Accion) => {
  const [Value, setValue] = useState(false);
  const [packCatalogos, setpackCatalogos] = useState();
  const [packRoles, setpackRoles] = useState();

  const CargarCatalogos = async () =>{
    const pack = await Get({Entidad:"Catalogos"});
    setpackCatalogos(pack);
  }

  const CargarRoles = async () =>{
    const pack = await Get({Entidad:"Roles"});
    setpackRoles(pack);
  }

  const On = (val) => {
    setValue(val)
    CargarCatalogos();
    CargarRoles();
  };
  const Off = () => setValue(false);
  const Change = {
    Nombre: (e) => {
      let newValue = {...Value};
      newValue.nombre = e.target.value
      setValue(newValue);    
    },
    ApellidoP:(e) => {
      let newValue = {...Value};
      newValue.apellidoP = e.target.value
      setValue(newValue);    
    },
    ApellidoM : (e) => {
      let newValue = {...Value};
      newValue.apellidoM = e.target.value
      setValue(newValue);    
    },
    Marca : (e) => {
      let newValue = {...Value};
      newValue.marca = e.target.value
      setValue(newValue);    
    },
    Modelo : (e) => {
      let newValue = {...Value};
      newValue.modelo = e.target.value
      setValue(newValue);    
    },
    Descripcion : (e) => {
      let newValue = {...Value};
      newValue.descripcion = e.target.value
      setValue(newValue);    
    },
    Costo : (e) => {
      let newValue = {...Value};
      newValue.costo = e.target.value
      setValue(newValue);    
    }
  }
  const SaveChanges = () => {
    if (Value.nombre === '') {
      alert('El nombre no puede estar vacío');
      return;
    }
    if (Value.marca === '') {
      alert('La marca no puede estar vacía');
      return;
    }
    if (Value.modelo === '') {
      alert('El modelo no puede estar vacío');
      return;
    }
    if (Value.descripcion === '') {
      alert('La descripcion no puede estar vacío');
      return;
    }
    if (Value.costo === '') {
      alert('El costo no puede estar vacío');
      return;
    }
    if (Value.apellidoP === '') {
      alert('El apellido paterno no puede estar vacío');
      return;
    }
    if (Value.apellidoM === '') {
      alert('El apellido materno no puede estar vacío');
      return;
    }
    
    Accion(Value)
    Off();
  }
  return ({
    On,
    View:
        <Modal isOpen={!!Value} style={customStyles}>
        <div className="flex justify-center items-center w-full h-full ">
          <div className=" bg-white p-10 max-h-[80vh] overflow-auto w-[80vw] py-8 leading-6 space-y-4 sm:text-lg sm:leading-7">
          {Value.nombre != null && (
              <div className="relative min-w-[50vw]">
              <input value={Value.nombre} onChange={Change.Nombre} required autoComplete="off" type="text" className="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:border-rose-600" placeholder="Nombre" />
                  <label className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm">Nombre</label>
              </div>
            )}
            {Value.apellidoP != null && (
              <div className="relative min-w-[50vw]">
              <input value={Value.apellidoP} onChange={Change.ApellidoP} required autoComplete="off" type="text" className="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:border-rose-600" placeholder="Apellido Paterno" />
                  <label className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm">Apellido Paterno</label>
              </div>
            )}
            {Value.apellidoM != null && (
              <div className="relative min-w-[50vw]">
              <input value={Value.apellidoM} onChange={Change.ApellidoM} required autoComplete="off" type="text" className="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:border-rose-600" placeholder="Apellido Materno" />
                  <label className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm">Apellido Mateterno</label>
              </div>
            )}
            {Value.marca != null && (
              <div className="relative min-w-[50vw]">
              <input value={Value.marca} onChange={Change.Marca} required autoComplete="off" type="text" className="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:border-rose-600" placeholder="Marca" />
                  <label htmlFor="email" className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm">Marca</label>
              </div>
            )}
            {Value.modelo != null && (
              <div className="relative min-w-[50vw]">
              <input value={Value.modelo} onChange={Change.Modelo} required autoComplete="off" type="text" className="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:border-rose-600" placeholder="Modelo" />
                  <label className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm">Modelo</label>
              </div>
            )}
            {Value.descripcion != null && (
              <div className="relative min-w-[50vw]">
              <input value={Value.descripcion} onChange={Change.Descripcion} required autoComplete="off" type="text" className="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:border-rose-600" placeholder="Descripcion" />
                  <label htmlFor="email" className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm">Descripcion</label>
              </div>
            )}
            {Value.costo != null && (
              <div className="relative min-w-[50vw]">
              <input value={Value.costo} onChange={Change.Costo} required autoComplete="off" type="text" className="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:border-rose-600" placeholder="Costo" />
                  <label className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm">Costo</label>
              </div>
            )}

            {Value.fkCatalogo != null && (
              <select name="select">
              <option value={3} disabled selected>Selecciona un Catalogo</option>
              {packCatalogos != null && packCatalogos.length > 0 ? (
                packCatalogos.map((element) => (
                  <option key={element.pk} value={element.pk}>
                    {element.nombre}
                  </option>
                ))
              ) : (
                <option value="" disabled>No hay datos disponibles..</option>
              )}
            </select>
            )}

            {Value.fkrol != null && (
              <select name="select">
              <option value={3}  >Selecciona una opción</option>
              {packRoles != null && packRoles.length > 0 ? (
                packRoles.map((element) => (
                  <option key={element.pk} value={element.pk}>
                    {element.nombre}
                  </option>
                ))
              ) : (
                <option value="" >No hay datos disponibles</option>
              )}
            </select>
            
            )}
          <div className="flex gap-5 pt-5">
          <button onClick={()=>Off()} className="bg-blue-500 text-white w-full rounded-md px-2 py-1"> Cancelar </button>
          <button onClick={SaveChanges} className="bg-green-500 text-white w-full rounded-md px-2 py-1">
            Submit
          </button>
          </div>
          </div>
        </div>
        </Modal>
      

  });
};

const TrueVentana = (Recargar) => {
  const [IsOpen, setIsOpen] = useState(false);
  const On = (Text) => setIsOpen(Text);
  const Off = () =>  {
    setIsOpen(false),
    Recargar();
    }
  return ({
    On,
    View:
    <Modal isOpen={!!IsOpen} style={customStyles}>
     <div className="w-full h-full flex justify-center items-center">
      <div className="bg-white border-t-4 border-blue-500 rounded-b text-green-600 px-4 py-3 shadow-md" role="alert">
      <div className="flex flex-col items-center px-7">
        <div className="py-1"><svg xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="rgb(22 163 74)" className="bi bi-check-circle" viewBox="0 0 16 16">
        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
        <path d="M10.97 4.97a.235.235 0 0 0-.02.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-1.071-1.05z"/>
        </svg>
      </div>
        <div>
          <p className="font-bold">{IsOpen}</p>
        </div>
      </div>
      <div className="mt-5 flex justify-evenly">
        <button onClick={()=>Off()} className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-8 rounded">
          Ok
        </button>
      </div>
      </div>
     </div>
    </Modal>
});
};

export const DeleteVentana = (Accion) => {
  const [IsOpen, setIsOpen] = useState(false);
  const On = (pk) => setIsOpen(pk);
  const Off = () => setIsOpen(false);
  const Eliminar = () =>{
    Accion(IsOpen)
    Off()
  }
  return ({
    On,
    View:
    <Modal isOpen={!!IsOpen} style={customStyles}>
     <div className="w-full h-full flex justify-center items-center">
      <div className="bg-white border-t-4 border-red-500 rounded-b text-teal-900 px-4 py-3 shadow-md" role="alert">
      <div className="flex">
        <div className="py-1"><svg className="fill-current h-6 w-6 text-red-500 mr-4" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20"><path d="M2.93 17.07A10 10 0 1 1 17.07 2.93 10 10 0 0 1 2.93 17.07zm12.73-1.41A8 8 0 1 0 4.34 4.34a8 8 0 0 0 11.32 11.32zM9 11V9h2v6H9v-4zm0-6h2v2H9V5z"/></svg></div>
        <div>
          <p className="font-bold">Accion de eliminacion</p>
          <p className="text-sm">Estas seguro de eliminar este elemento?</p>
        </div>
      </div>
      <div className="mt-5 flex justify-evenly">
      <button onClick={Eliminar} className="bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-8 rounded">
        Si, eliminar
      </button>
      <button onClick={Off} className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-8 rounded">
        Cancelar
      </button>
      </div>
      </div>
     </div>
    </Modal>
  });
};

export const ModulCreate =  ({Entidad:E, Recargar:R}) => {
  const MsjTrue = TrueVentana(R);
  const Create = async (Item) =>{
    const Mensaje = await Post({Entidad:E,Datos:Item})
    MsjTrue.On(Mensaje.message);
  }
  const TolsCreate = FormVentana(Create);
  return({
    MsjTrue,
    TolsCreate
  })
}

export const ModulEdit =  ({Entidad:E, Recargar:R}) => {
  const MsjTrue = TrueVentana(R);
  const Edit = async (Item) =>{
    const Mensaje = await Put({Entidad:E,Datos:Item})
    MsjTrue.On(Mensaje.message);
  }
  const TolsEdit = FormVentana(Edit);
  return({
    MsjTrue,
    TolsEdit
  })
}

export const ModulEliminate = ({Entidad:E, Recargar:R}) => {
  const MsjTrue = TrueVentana(R);
  const Eliminate = async (Item) => {
    const Mensaje = await Delete({Entidad:E,Pk:Item})
    MsjTrue.On(Mensaje.message)
  }
  const Tols = DeleteVentana(Eliminate);
  return({
    MsjTrue,
    Tols
  })
}