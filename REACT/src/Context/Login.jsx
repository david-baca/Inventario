import { useState } from "react"; 

export const Login = () =>{
    const [UserLogin, setUserLogin] = useState(true);

    const setLogin = (objeto)=>{
        setUserLogin(true)
        return(0)
    };//cambio de estatus a true
    
    const getLogin = ()=>{
        return(UserLogin)
    }//validacion de que el paquete logoin sea correcto

    return ({
        setLogin,
        getLogin
    })
}
