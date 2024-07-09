
import {type CouseGoal as cgoal} from "../App.tsx";
import CouseGoal from "./CouseGoal.tsx";

type CouseGoalLisr = {
        goals:cgoal[]
        onDelete:(id:number)=>void;
  };
export default function CourseList(props:CouseGoalLisr) {
  return (
    
      <ul>
        {props.goals.map((goal) => (
          <li key={goal.id}>
            <CouseGoal id={goal.id} title={goal.title} description = {goal.description} onDelete={props.onDelete}>
            </CouseGoal>
          </li>
        ))}
      </ul>
  )
}
