import { type PropsWithChildren } from "react";

// interface CouseGoalporp {
//   title: string;
//   children:ReactNode;
// }

type CouseGoalporp = { description: string, title: string ,id:number,onDelete:(id:number)=>void;};
export default function CouseGoal(props: CouseGoalporp) {

  const { title, description } = props
    
  return (
    <article>
      <div>
        <h2>{title}</h2>
        <p>{description}</p>
      </div>
      <button onClick={()=>props.onDelete(props.id)}>Delete</button>
    </article>
  );
}
