import { ContextUser } from "./ContextUser";
import { Login } from './Login'
import { Data } from "./Data"

export const UserProvider = ({ children }) => {

    const LoginComponent = Login();
    const Datacomponent = Data();
    
    return (
        <ContextUser.Provider 
        value={{getData:()=>Datacomponent.getData(),
                setDataArray:(e)=>Datacomponent.setDataArray(e),
                setDataItem:(e)=>Datacomponent.setDataItem(e), 
                cleenData:()=>Datacomponent.CleenData(), 
                setUsuario:(e)=>LoginComponent.setLogin(e),
                getUserLogin:()=>LoginComponent.getLogin()
                }}>
            {children}
        </ContextUser.Provider>
    )
  }









