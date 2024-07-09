import { PropsWithChildren } from "react"

type Headerprop=PropsWithChildren<{image:{src:string;}}>;

export default function Header(props:Headerprop) {
  return (
   <header>
       <img src={props.image.src}/>
       {props.children}

   </header>
    
  )
}
