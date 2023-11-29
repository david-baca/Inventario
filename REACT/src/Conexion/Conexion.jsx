import axios from "axios";
import {BASE_URL} from '../utils/const'

export const Logueo = async ({Usuario:User, Contraseña:Pass}) => {
  let Request = BASE_URL;
  Request = Request+"Usuario?Usuario="+User+'&Contrasena='+Pass;
  const response = await axios.get(Request);
  const resultado = response.data.success;
  return (resultado)
};

export const Get = async ({Entidad:E, Text:T, FK:ID}) => {
  let Request = BASE_URL+E;
  if(T != null && ID == 0|null){
    Request = Request+"?Text="+T;
  }
  if(T != null && ID != 0|null){
    Request = Request+"?Text="+T+"&fk="+ID;
  }
  if(T == null && ID != 0|null){
    Request = Request+"?&fk="+ID;
  }
  const response = await axios.get(Request);

  const resultado = response.data.result;
  return (resultado)
};

export const Post = async ({Entidad:E,Datos:D}) => {
  const response = await axios.post(BASE_URL+E+"/Crear", D);
  const result = response.data
  return (result)
};

export const Put = async ({Entidad:E, Datos:D}) => {
  const response = await axios.put(BASE_URL+E+"/Actualizar/"+D.pk, D)
  const result = response.data
  return (result)
};

export const Delete = async ({Entidad:E, Pk:llave}) => {
  const response = await axios.put(BASE_URL+E+"/Borrar/"+llave)
  const result = response.data
  console.log(response)
  return (result)
};
