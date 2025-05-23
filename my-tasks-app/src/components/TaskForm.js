import React, { useState, useEffect } from "react";
import styles from "./TaskForm.module.css";

const initialState = {
  title: "",
  description: "",
  assignedUserId: 1,
  startDate: "",
  endDate: "",
  isCompleted: false,
};

const TaskForm = ({ onSubmit, selectedTask, onCancel }) => {
  const [task, setTask] = useState(initialState);
  const [error, setError] = useState(null);


  useEffect(() => {
    if (selectedTask) {
      setTask(selectedTask);
    }
  }, [selectedTask]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setTask({ ...task, [name]: value });
  };

  const handleSubmit = async (e) => {
  e.preventDefault();
  try {
    await onSubmit(task);
    setTask(initialState);
    setError(null);
  } catch (err) {
    if (err.response && err.response.data && err.response.data.errors) {
      const backendErrors = err.response.data.errors;
      const firstError = Object.values(backendErrors)[0][0];
      setError(firstError);
    } else {
      setError("Something went wrong.");
    }
  }
};


  return (
    <form className={styles.formContainer} onSubmit={handleSubmit}>
      {error && <div style={{ color: "red", marginBottom: "10px" }}>{error}</div>}
      <h3>{selectedTask ? "Edit Task" : "Add Task"}</h3>
      <input name="title" value={task.title} onChange={handleChange} placeholder="Title" required />
      <input name="description" value={task.description} onChange={handleChange} placeholder="Description" required />
      <input type="number" name="assignedUserId" value={task.assignedUserId} onChange={handleChange} placeholder="Assigned User ID" required />
      <input type="datetime-local" name="startDate" value={task.startDate} onChange={handleChange} required />
      <input type="datetime-local" name="endDate" value={task.endDate} onChange={handleChange} required />
      <button type="submit">{selectedTask ? "Update" : "Create"}</button>
      <button type="button" onClick={onCancel}>Cancel</button>
    </form>
  );
};

export default TaskForm;
