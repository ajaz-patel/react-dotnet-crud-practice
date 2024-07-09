import CouseGoal from "./component/CouseGoal";
import goalsImg from "./assets/goals.jpg";
import Header from "./component/Header";
import { useEffect, useState } from "react";
import CourseList from "./component/CourseList";
import NewGoal, { Goal } from "./component/NewGoal";
import axios from "axios";

export type CouseGoal = {
  title: string;
  description: string;
  id: number;
};

export default function App() {
  const [goals, setGoals] = useState<CouseGoal[]>([]);

  async function fetchGoals() {
    try {
      
      const response = await axios.get("https://localhost:7166/GetGoal")
      const data = response.data
      setGoals(data)
    } catch (error) {
      console.log(error);
      
    }
  }

  useEffect(() => {
    fetchGoals()
  },[goals])

  async function handleAddGoals(goal: Goal) {
    setGoals((p) => {return [...p,goal]})
  }

  async function handleDelete(id: number) {
    const response = await axios.delete(`https://localhost:7166/delete/${id}`)
    if(response.data){
       setGoals((prevgolas) => prevgolas.filter((goal) => goal.id !== response.data.id));
    }
  }
  return (
    <main>
      <Header image={{ src: goalsImg }}>
        <h1>your course goals</h1>
      </Header>
      <NewGoal onAddGoal={handleAddGoals}/>
      <CourseList goals={goals} onDelete={handleDelete}/>
    </main>
  );
}
