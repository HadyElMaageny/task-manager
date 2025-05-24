// src/App.js
import React, { useEffect, useState } from "react";
import { getTasks, createTask, updateTask, markComplete } from "./api/taskApi";
import TaskForm from "./components/TaskForm";
import TaskList from "./components/TaskList";
import styles from "./pages/TaskPage.module.css"; // Assuming you have some CSS for styling

function App() {
  const [tasks, setTasks] = useState([]);
  const [selectedTask, setSelectedTask] = useState(null);
  const [mode, setMode] = useState("list"); // "list" | "add" | "edit"

  const loadTasks = async () => {
    try {
      const response = await getTasks();
      setTasks(response.data);
    } catch (error) {
      if (error.response && error.response.status === 404) {
        console.warn("No tasks found.");
        setTasks([]);
      } else {
        console.error("Failed to load tasks:", error);
      }
    }
  };

  const handleAddClick = () => {
    setSelectedTask(null);
    setMode("add");
  };

  const handleEditClick = (task) => {
    setSelectedTask(task);
    setMode("edit");
  };

  const handleFormSubmit = async (task) => {
    if (mode === "edit") {
      await updateTask(task.id, task);
    } else {
      await createTask(task);
    }
    setMode("list");
    loadTasks();
  };

  const handleCancel = () => {
    setSelectedTask(null);
    setMode("list");
  };

  const handleMarkComplete = async (id) => {
    await markComplete(id);
    loadTasks();
  };

  useEffect(() => {
    loadTasks();
  }, []);

  return (
    <div>
      <h1>📝 My Tasks</h1>
      {mode === "list" && (
        <>
          {tasks.length > 0 && (
            <button className={styles.addButton} onClick={handleAddClick}>
              ➕ Add Task
            </button>
          )}
          <TaskList
          tasks={tasks}
          onEdit={handleEditClick}
          onMarkComplete={handleMarkComplete}
          onAddClick={handleAddClick}
        />
        </>
      )}
      {(mode === "add" || mode === "edit") && (
        <TaskForm onSubmit={handleFormSubmit} selectedTask={selectedTask} onCancel={handleCancel} />
      )}
    </div>
  );
}

export default App;
