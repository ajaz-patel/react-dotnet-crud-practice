import axios from "axios";
import { useRef, type FormEvent } from "react";

export type Goal = {
  id: number,
  title: string,
  description: string
}

export type AddGoalDto = {
  title: string,
  description: string
}

type newgoalprop={onAddGoal:(goal: Goal)=>void;}

export default function newGoal(props:newgoalprop) {


  // const[goals, setGoals] = useState<CouseGoal[]>([]);
  
  
  const goal=useRef<HTMLInputElement>(null);
  const summary=useRef<HTMLInputElement>(null);
  async function handleSubmit(e: FormEvent<HTMLFormElement>) {
    e.preventDefault();
    
    const entergoal=goal.current!.value;
    const entersummary=summary.current!.value;

    const newGoal: AddGoalDto = {
      title: entergoal,
      description: entersummary
    }
    
    const response = await axios.post('https://localhost:7166/AddGoals',newGoal,{
      headers: {
        'Content-Type':'Application/json'
      }
    }) 

    e.currentTarget.reset();
    props.onAddGoal(response.data);  

  }
  return (
    <>
    
    <form onSubmit={handleSubmit}>
      <p>
        <label htmlFor="goal">Your goal</label>
        <input id="goal" type="text" ref={goal}/>
      </p>
      <p>
        <label htmlFor="summary">summary </label>
        <input id="summary" type="text" ref={summary}/>
      </p>
      <p>
        <button >Add Goal</button>
      </p>
    </form>

    </>
  );
}
